using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC
{
    public partial class PAC : PluginControlBase
    {
        #region Private Fields

        private HttpClient client;

        #endregion Private Fields

        #region Public Constructors

        public PAC()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            cbSolutions.Service = newService;
            if (SettingsManager.Instance.TryLoad(GetType(), out Settings settings, detail.ConnectionName))
            {
                ApplySettingsToUI(settings);
            }
            Enable(true);
        }

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            SettingsManager.Instance.Save(GetType(), GetSettingsFromUI(), ConnectionDetail?.ConnectionName);
            base.ClosingPlugin(info);
        }

        #endregion Public Methods

        #region Private event handlers

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            Analyze();
        }

        private void btnConnectPAC_Click(object sender, EventArgs e)
        {
            ConnectPAChecker();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export(cbSolutions.SelectedSolution);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var od = new OpenFileDialog
            {
                InitialDirectory = Paths.LogsPath
            };
            if (od.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = od.FileName;
            }
            Enable(true);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            Upload();
        }

        private void cbRuleset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRuleset.SelectedItem != null)
            {
                LoadRuleSetSelections(cbRuleset.SelectedItem as PACRuleSet);
            }
        }

        private void cdSolutions_SelectedItemChanged(object sender, EventArgs e)
        {
            Enable(true);
        }

        private void chkAllRules_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvRules.Items)
            {
                item.Checked = chkAllRules.Checked;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkBlob.Text);
        }

        private void lvRules_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateRuleCounts();
        }

        private void lvRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRules.SelectedItems.Count > 0 && lvRules.SelectedItems[0].Tag is PACRule rule)
            {
                txtRuleDescr.Text = rule.Description;
            }
            else
            {
                txtRuleDescr.Text = "";
            }
            Enable(true);
        }

        private void PAC_Load(object sender, EventArgs e)
        {
            if (SettingsManager.Instance.TryLoad(GetType(), out Settings settings, ConnectionDetail?.ConnectionName))
            {
                ApplySettingsToUI(settings);
                ConnectPAChecker(true);
            }
        }

        private void rbGroupBy_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                LoadRules();
            }
        }

        private void picRuleHelp_Click(object sender, EventArgs e)
        {
            if (lvRules.SelectedItems.Count > 0 && lvRules.SelectedItems[0].Tag is PACRule rule)
            {
                Process.Start(rule.GuidanceUrl.Replace("client=PAChecker", "client=Rappen.XTB.PAC"));
            }
        }

        private void tmStatus_Tick(object sender, EventArgs e)
        {
            CheckStatus();
        }

        #endregion Private event handlers

        #region Private Methods

        private void Analyze()
        {
            Enable(false);
            var analysisargs = GetAnalysisArgs();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initiating analysis",
                AsyncArgument = analysisargs,
                Work = (worker, args) =>
                {
                    args.Result = client.Analyze(args.Argument as PACAnalysisArgs);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is Uri location)
                    {
                        txtStatusUrl.Text = location.ToString();
                        txtAnalysis.Text = "Analysis sent\r\n";
                        tmStatus.Start();
                    }
                    Enable(true);
                }
            });
        }

        private void ApplySettingsToUI(Settings settings)
        {
            if (!settings.TenantId.Equals(Guid.Empty)) txtTenantId.Text = settings.TenantId.ToString();
            if (!settings.ClientId.Equals(Guid.Empty)) txtClientId.Text = settings.ClientId.ToString();
            if (!string.IsNullOrEmpty(settings.ClientSecret)) txtClientSec.Text = settings.ClientSecret;
            txtFilename.Text = settings.SolutionFile;
        }

        private PACAnalysisArgs GetAnalysisArgs()
        {
            var args = new PACAnalysisArgs
            {
                CorrId = new Guid(txtCorrId.Text),
                FileUrl = linkBlob.Text,
                RuleSets = new List<PACRuleSet>(),
                Rules = new List<PACRule>(),
                Exclusions = null
            };
            if (rbScopeRuleset.Checked && cbRuleset.SelectedItem is PACRuleSet ruleset)
            {
                args.RuleSets.Add(ruleset);
            }
            else if (rbScopeRules.Checked)
            {
                foreach (ListViewItem item in lvRules.CheckedItems)
                {
                    if (item.Tag is PACRule rule)
                    {
                        args.Rules.Add(rule);
                    }
                }
            }
            return args;
        }

        private void CheckStatus()
        {
            tmStatus.Enabled = false;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Checking analysis status",
                AsyncArgument = txtStatusUrl.Text,
                Work = (worker, args) =>
                {
                    var status = client.Get(new Uri(args.Argument.ToString()));
                    var jss = new JavaScriptSerializer();
                    args.Result = jss.Deserialize<PACStatus>(status);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is PACStatus status)
                    {
                        txtRunCorrId.Text = status.RunCorrelationId.ToString();
                        txtStatus.Text = status.Status;
                        progAnalysis.Value = status.Progress;
                        if (status.Progress >= 100)
                        {
                            if (status.ResultFileUris != null)
                            {
                                foreach (var resultfile in status.ResultFileUris)
                                {
                                    txtAnalysis.Text += $"Result file: {resultfile}\r\n";
                                    var result = client.Get(new Uri(resultfile));
                                    txtAnalysis.Text += result + "\r\n\r\n";
                                }
                            }
                        }
                        else
                        {
                            tmStatus.Start();
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
            Enable(false);
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
                        LoadRuleSets();
                    }
                    Enable(true);
                }
            });
        }

        private void Enable(bool enable)
        {
            Enabled = enable;
            btnConnectPAC.Enabled = enable && Guid.TryParse(txtTenantId.Text, out Guid t) && Guid.TryParse(txtClientId.Text, out Guid c) && !string.IsNullOrWhiteSpace(txtClientSec.Text);
            cbRuleset.Enabled = enable && client != null && cbRuleset.Items.Count > 0;
            picRuleHelp.Enabled = enable && lvRules.SelectedItems.Count > 0;
            cbSolutions.Enabled = enable && Service != null;
            btnExport.Enabled = enable && cbSolutions.SelectedSolution is Entity solution
                    && (solution["ismanaged"] as bool? == false);
            btnUpload.Enabled = enable && client != null && File.Exists(txtFilename.Text);
            btnAnalyze.Enabled = enable && client != null && !string.IsNullOrEmpty(linkBlob.Text) && 
                ((rbScopeRuleset.Checked && cbRuleset.SelectedItem is PACRuleSet) || (rbScopeRules.Checked && lvRules.CheckedItems.Count > 0));
            picRuleHelp.Cursor = picRuleHelp.Enabled ? Cursors.Hand : Cursors.No;
        }

        private void Export(Entity solution)
        {
            Enable(false);
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

        private ListViewGroup GetGroupForRule(PACRule rule)
        {
            var groupby = (rbGroupCategory.Checked ? $"Category: {rule.PrimaryCategory}" : $"Severity: {rule.Severity}");
            ListViewGroup[] groups = new ListViewGroup[lvRules.Groups.Count];
            lvRules.Groups.CopyTo(groups, 0);
            var group = groups.FirstOrDefault(g => g.Header == groupby);
            if (group == null)
            {
                group = lvRules.Groups.Add(groupby, groupby);
                group.HeaderAlignment = HorizontalAlignment.Center;
            }
            return group;
        }

        private ListViewItem GetListViewItemByRule(PACRule rule)
        {
            ListViewItem[] items = new ListViewItem[lvRules.Items.Count];
            lvRules.Items.CopyTo(items, 0);
            return items.FirstOrDefault(i => i.Tag is PACRule && ((PACRule)i.Tag).Code == rule.Code);
        }

        private Settings GetSettingsFromUI()
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
            return settings;
        }

        private void LoadRules()
        {
            Enable(false);
            lvRules.Items.Clear();
            lvRules.Groups.Clear();
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading rules",
                Work = (worker, args) =>
                {
                    var rules = client.Get("rule");
                    var jss = new JavaScriptSerializer();
                    args.Result = jss.Deserialize<PACRule[]>(rules);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is PACRule[] rulelist)
                    {
                        lvRules.Items.AddRange(rulelist.Select(r => RuleToListItem(r)).ToArray());
                        if (cbRuleset.SelectedItem != null)
                        {
                            LoadRuleSetSelections(cbRuleset.SelectedItem as PACRuleSet);
                        }
                    }
                    Enable(true);
                }
            });
        }

        private void LoadRuleSets()
        {
            Enable(false);
            cbRuleset.Items.Clear();
            cbRuleset.Items.Add("");
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading rulesets",
                Work = (worker, args) =>
                {
                    var rulesets = client.Get("ruleset");
                    var jss = new JavaScriptSerializer();
                    args.Result = jss.Deserialize<PACRuleSet[]>(rulesets);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is PACRuleSet[] rulesetlist)
                    {
                        cbRuleset.Items.AddRange(rulesetlist);
                        LoadRules();
                    }
                    Enable(true);
                }
            });
        }

        private void LoadRuleSetSelections(PACRuleSet ruleset)
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
                    var rules = client.Get($"rule?ruleset={ruleset.Id}");
                    var jss = new JavaScriptSerializer();
                    args.Result = jss.Deserialize<PACRule[]>(rules);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is PACRule[] rulelist)
                    {
                        foreach (ListViewItem item in lvRules.Items)
                        {
                            item.Checked = false;
                        }
                        foreach (var rule in rulelist)
                        {
                            var item = GetListViewItemByRule(rule);
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

        private ListViewItem RuleToListItem(PACRule rule)
        {
            var group = GetGroupForRule(rule);
            var item = new ListViewItem(rule.ToString())
            {
                Tag = rule,
                Checked = rule.Include,
                Group = group
            };
            return item;
        }

        private void UpdateRuleCounts()
        {
            lblRules.Text = $"{lvRules.CheckedItems.Count}  selected of {lvRules.Items.Count} rules.";
        }

        private void Upload()
        {
            Enable(false);
            var corrid = Guid.NewGuid();
            txtCorrId.Text = corrid.ToString();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Uploading",
                AsyncArgument = corrid,
                Work = (worker, args) =>
                {
                    args.Result = client.Upload(corrid, txtFilename.Text);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is string bloburl)
                    {
                        linkBlob.Text = bloburl;
                    }
                    Enable(true);
                }
            });
        }

        #endregion Private Methods

        private void rbScope_CheckedChanged(object sender, EventArgs e)
        {
            Enable(true);
        }
    }
}