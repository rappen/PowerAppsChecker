using McTools.Xrm.Connection;
using Microsoft.CodeAnalysis.Sarif;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.PAC.DockControls;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using XrmToolBox.Extensibility;
using static System.Windows.Forms.ListView;

namespace Rappen.XTB.PAC
{
    public partial class PAC : PluginControlBase
    {
        #region Private Fields

        internal HttpClient client;
        private readonly SarifControl sarifControl;
        private readonly ScopeControl scopeControl;
        private Dictionary<string, int> groupBoxHeights;

        #endregion Private Fields

        #region Public Constructors

        public PAC()
        {
            IEnumerable<Control> GetAll(Control control, Type type)
            {
                var controls = control.Controls.Cast<Control>().ToArray();
                return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                          .Concat(controls)
                                          .Where(c => c.GetType() == type);
            }

            InitializeComponent();
            var theme = new VS2015LightTheme();
            dockContainer.Theme = theme;
            scopeControl = new ScopeControl(this);
            sarifControl = new SarifControl(this);
            groupBoxHeights = new Dictionary<string, int>();
            foreach (var gb in GetAll(this, typeof(GroupBox)))
            {
                groupBoxHeights.Add(gb.Name, gb.Height);
            }
        }

        #endregion Public Constructors

        #region Public Methods

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            SettingsManager.Instance.Save(GetType(), SettingsGetFromUI(), ConnectionDetail?.ConnectionName);
            SaveDockPanels();
            base.ClosingPlugin(info);
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            cbSolution.OrganizationService = newService;
            LoadSolutions();
            if (SettingsManager.Instance.TryLoad(GetType(), out Settings settings, detail.ConnectionName))
            {
                SettingsApplyToUI(settings);
            }
            Enable(true);
        }

        #endregion Public Methods

        #region Private event handlers

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            SendAnalysis();
        }

        private void btnConnectPAC_Click(object sender, EventArgs e)
        {
            ConnectPAChecker();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportSolution(cbSolution.SelectedEntity);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (var od = new OpenFileDialog
            {
                InitialDirectory = Paths.LogsPath
            })
            {
                if (od.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = od.FileName;
                    txtCorrId.Text = "";
                    linkUploaded.Text = "";
                    sarifControl.Reset();
                }
            }
            Enable(true);
        }

        private void btnResetWindows_Click(object sender, EventArgs e)
        {
            ResetDockLayout();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadSolutionFile();
        }

        private void cdSolution_SelectedItemChanged(object sender, EventArgs e)
        {
            Enable(true);
        }

        private void linkUploaded_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkUploaded.Text);
        }

        private void llGroupBoxExpander_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GroupBoxToggle(sender as LinkLabel);
        }

        private void PAC_Load(object sender, EventArgs e)
        {
            if (SettingsManager.Instance.TryLoad(GetType(), out Settings settings, ConnectionDetail?.ConnectionName))
            {
                SettingsApplyToUI(settings);
            }
            SetupDockControls();
            LoadRuleSets();
        }

        private void tsbCloseThisTab_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        #endregion Private event handlers

        #region Dock methods

        private static string GetDockFileName()
        {
            return Path.Combine(Paths.SettingsPath, "Rappen.XTB.PAC_DockPanels.xml");
        }

        private IDockContent dockDeSerialization(string persistString)
        {
            switch (persistString)
            {
                case "Rappen.XTB.PAC.DockControls.RuleControl":
                    return scopeControl;
                case "Rappen.XTB.PAC.DockControls.SarifControl":
                    return sarifControl;
                default:
                    return null;
            }
        }

        private void ResetDockLayout()
        {
            scopeControl.Show(dockContainer, DockState.DockLeft);
            sarifControl.Show(dockContainer, DockState.Document);
        }

        private void SaveDockPanels()
        {
            var dockFile = GetDockFileName();
            dockContainer.SaveAsXml(dockFile);
        }

        private void SetupDockControls()
        {
            string dockFile = GetDockFileName();
            if (File.Exists(dockFile))
            {
                try
                {
                    dockContainer.LoadFromXml(dockFile, dockDeSerialization);
                    return;
                }
                catch (InvalidOperationException)
                {
                    // Restore from file failed
                }
            }
            ResetDockLayout();
        }

        #endregion Dock methods

        #region Private Methods

        internal void Enable(bool enable)
        {
            Enabled = enable;
            btnConnectPAC.Enabled = enable && Guid.TryParse(txtTenantId.Text, out Guid t) && Guid.TryParse(txtClientId.Text, out Guid c) && !string.IsNullOrWhiteSpace(txtClientSec.Text);
            cbSolution.Enabled = enable && Service != null;
            btnExport.Enabled = enable && cbSolution.SelectedEntity != null;
            btnUpload.Enabled = enable && client != null && File.Exists(txtFilename.Text);
            btnAnalyze.Enabled = enable && client != null && !string.IsNullOrEmpty(linkUploaded.Text) && scopeControl.EnableAnalysis();
            scopeControl.Enable(enable);
            sarifControl.Enable(enable);
        }

        internal void LoadRules()
        {
            Enable(false);
            var enabled = true;
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading rules",
                Work = (worker, args) =>
                {
                    args.Result = PACHelper.GetRules();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is Helpers.Rule[] rulelist)
                    {
                        if (scopeControl.AddRules(rulelist))
                        {
                            enabled = false;
                        }
                    }
                    Enable(enabled);
                }
            });
        }

        internal void LoadRuleSets()
        {
            Enable(false);
            var enabled = true;
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading rulesets",
                Work = (worker, args) =>
                {
                    args.Result = PACHelper.GetRuleSets();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is RuleSet[] rulesetlist)
                    {
                        scopeControl.AddRuleSets(rulesetlist);
                        LoadRules();
                        enabled = false;
                    }
                    Enable(enabled);
                }
            });
        }

        internal void LoadRuleSetSelections(RuleSet ruleset, List<ListViewItem> rules)
        {
            if (ruleset == null)
            {
                return;
            }
            Enable(false);
            WorkAsync(new WorkAsyncInfo()
            {
                Message = $"Loading rules for {ruleset.Name}",
                Work = (worker, args) =>
                {
                    args.Result = PACHelper.GetRules(ruleset.Id);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is Helpers.Rule[] rulelist)
                    {
                        foreach (ListViewItem item in rules)
                        {
                            item.Checked = false;
                        }
                        foreach (var rule in rulelist)
                        {
                            var item = rules.FirstOrDefault(i => i.Tag is Helpers.Rule && ((Helpers.Rule)i.Tag).Code == rule.Code);
                            if (item != null)
                            {
                                item.Checked = true;
                            }
                        }
                    }
                    Enable(true);
                }
            });
        }

        private void ConnectPAChecker(bool silent = false)
        {
            if (silent && !(Guid.TryParse(txtTenantId.Text, out Guid t) && Guid.TryParse(txtClientId.Text, out Guid c) && !string.IsNullOrWhiteSpace(txtClientSec.Text)))
            {
                return;
            }
            if (!Guid.TryParse(txtTenantId.Text, out var tenantId))
            {
                MessageBox.Show("Bad Tenant Guid");
                return;
            }
            if (!Guid.TryParse(txtClientId.Text, out var clientId))
            {
                MessageBox.Show("Bad Client Guid");
                return;
            }
            var clientSec = txtClientSec.Text;

            Enable(false);
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Connecting PAC",
                Work = (worker, args) =>
                {
                    args.Result = PACHelper.GetClient(tenantId, clientId, clientSec);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is HttpClient pacclient)
                    {
                        client = pacclient;
                    }
                    Enable(true);
                }
            });
        }

        private void ExportSolution(Entity solution)
        {
            Enable(false);
            txtFilename.Text = "";
            txtCorrId.Text = "";
            linkUploaded.Text = "";
            sarifControl.Reset();
            var solname = solution["uniquename"].ToString();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Exporting",
                AsyncArgument = solname,
                Work = (worker, args) =>
                {
                    var sol = args.Argument as string;
                    var req = new ExportSolutionRequest
                    {
                        SolutionName = sol,
                        Managed = false
                    };
                    args.Result = Service.Execute(req) as ExportSolutionResponse;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is ExportSolutionResponse resp)
                    {
                        var exportXml = resp.ExportSolutionFile;
                        var filename = Path.Combine(Paths.LogsPath, solname + ".zip");
                        File.WriteAllBytes(filename, exportXml);
                        txtFilename.Text = filename;
                    }
                    Enable(true);
                }
            });
        }

        private void GroupBoxCollapse(LinkLabel link)
        {
            link.Parent.Height = 18;
            link.Text = "Show";
        }

        private void GroupBoxExpand(LinkLabel link)
        {
            link.Parent.Height = groupBoxHeights[link.Parent.Name];
            link.Text = "Hide";
        }

        private void GroupBoxToggle(LinkLabel link)
        {
            if (link.Parent.Height > 20)
            {
                GroupBoxCollapse(link);
            }
            else
            {
                GroupBoxExpand(link);
            }
        }

        private void LoadSolutions()
        {
            Enable(false);
            cbSolution.DataSource = null;
            if (Service == null)
            {
                return;
            }
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solutions",
                Work = (worker, args) =>
                {
                    var qx = new QueryExpression("solution");
                    qx.ColumnSet.AddColumns("friendlyname", "solutionid", "uniquename", "version");
                    qx.AddOrder("friendlyname", OrderType.Ascending);
                    qx.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, false);
                    qx.Criteria.AddCondition("isvisible", ConditionOperator.Equal, true);
                    qx.Criteria.AddCondition("uniquename", ConditionOperator.NotEqual, "Default");
                    args.Result = Service.RetrieveMultiple(qx);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is EntityCollection solutions)
                    {
                        cbSolution.DataSource = solutions;
                    }
                    Enable(true);
                }
            });
        }

        private void SendAnalysis()
        {
            Enable(false);
            sarifControl.Reset();
            var analysisargs = scopeControl.GetAnalysisArgs(new Guid(txtCorrId.Text), linkUploaded.Text);
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initiating analysis",
                AsyncArgument = analysisargs,
                Work = (worker, args) =>
                {
                    args.Result = client.SendAnalysis(args.Argument as AnalysisArgs);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is HttpResponseMessage response)
                    {
                        if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                        {
                            LogError("SendAnalysis:\r\n{0}", response);
                            MessageBox.Show($"Status: {response.StatusCode}\r\n{response.ReasonPhrase}\r\nSee XrmToolBox log for details.", "Send for Analysis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            sarifControl.StartStatusCheck(response.Headers.Location.ToString());
                        }
                    }
                    Enable(true);
                }
            });
        }

        private void SettingsApplyToUI(Settings settings)
        {
            if (!settings.TenantId.Equals(Guid.Empty)) txtTenantId.Text = settings.TenantId.ToString();
            if (!settings.ClientId.Equals(Guid.Empty)) txtClientId.Text = settings.ClientId.ToString();
            if (!string.IsNullOrEmpty(settings.ClientSecret)) txtClientSec.Text = settings.ClientSecret;
            txtFilename.Text = settings.SolutionFile;
            txtCorrId.Text = settings.CorrelationId.ToString();
            linkUploaded.Text = settings.UploadedFile;
            scopeControl.txtExclusions.Text = settings.FileExclusions;
        }

        private Settings SettingsGetFromUI()
        {
            var settings = new Settings();
            if (Guid.TryParse(txtTenantId.Text, out Guid tid))
            {
                settings.TenantId = tid;
            }
            if (Guid.TryParse(txtClientId.Text, out Guid cid))
            {
                settings.ClientId = cid;
            }
            settings.ClientSecret = txtClientSec.Text;
            settings.SolutionFile = txtFilename.Text;
            if (Guid.TryParse(txtCorrId.Text, out Guid coid))
            {
                settings.CorrelationId = coid;
            }
            settings.UploadedFile = linkUploaded.Text;
            settings.FileExclusions = scopeControl.txtExclusions.Text;
            return settings;
        }

        private void UploadSolutionFile()
        {
            Enable(false);
            txtCorrId.Text = "";
            linkUploaded.Text = "";
            sarifControl.Reset();
            var corrid = Guid.NewGuid();
            txtCorrId.Text = corrid.ToString();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Uploading",
                AsyncArgument = corrid,
                Work = (worker, args) =>
                {
                    args.Result = client.UploadSolution(corrid, txtFilename.Text);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is string bloburl)
                    {
                        linkUploaded.Text = bloburl;
                    }
                    Enable(true);
                }
            });
        }

        #endregion Private Methods
    }
}