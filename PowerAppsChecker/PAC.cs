using McTools.Xrm.Connection;
using Microsoft.CodeAnalysis.Sarif;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC
{
    public partial class PAC : PluginControlBase
    {
        #region Private Fields

        private HttpClient client;
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
                    txtRunCorrId.Text = "";
                    txtStatusUrl.Text = "";
                    txtStatus.Text = "";
                    progAnalysis.Value = 0;
                    txtResultFile.Text = "";
                }
            }
            Enable(true);
        }

        private void btnOpenSarif_Click(object sender, EventArgs e)
        {
            using (var od = new OpenFileDialog
            {
                CheckPathExists = true,
                DefaultExt = "sarif",
                Filter = "SARIF files|*.sarif|All files|*.*",
                Title = "Open SARIF result file"
            })
            {
                if (od.ShowDialog() == DialogResult.OK)
                {
                    var sarif = File.ReadAllText(od.FileName);
                    ParseSarifLog(PACHelper.GetSarifFromString(sarif));
                }
            }
        }

        private void btnSaveSarif_Click(object sender, EventArgs e)
        {
            var filename = Path.GetFileNameWithoutExtension(txtResultFile.Text.Split('?')[0]);
            using (var sd = new SaveFileDialog
            {
                CheckPathExists = true,
                DefaultExt = "sarif",
                FileName = filename,
                Filter = "SARIF files|*.sarif|All files|*.*",
                OverwritePrompt = true,
                Title = "Save SARIF result file"
            })
            {
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sd.FileName, txtSarif.Text);
                    MessageBox.Show($"{sd.FileName} saved!");
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadSolutionFile();
        }

        private void cbRuleset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRuleset.SelectedItem != null)
            {
                LoadRuleSetSelections(cbRuleset.SelectedItem as RuleSet);
            }
        }

        private void cdSolution_SelectedItemChanged(object sender, EventArgs e)
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgResults.Columns[e.ColumnIndex].Name == FilePath.Name && ConnectionDetail != null)
            {
                var file = dgResults[e.ColumnIndex, e.RowIndex].Value.ToString();
                var url = ConnectionDetail.WebApplicationUrl + file;
                Process.Start(url);
            }
        }

        private void dgResults_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var col = dgResults.Columns[e.ColumnIndex];
            dgGrouper.Options.StartCollapsed = true;
            dgGrouper.SetGroupOn(col);
        }

        private void linkUploaded_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkUploaded.Text);
        }

        private void llGroupBoxExpander_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GroupBoxToggle(sender as LinkLabel);
        }

        private void llGroupBy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ll = sender as LinkLabel;
            if (ll.Tag == null)
            {
                dgGrouper.RemoveGrouping();
            }
            else
            {
                dgGrouper.Options.StartCollapsed = true;
                dgGrouper.SetGroupOn(ll.Tag.ToString());
            }
        }

        private void lvRules_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateRuleCounts();
        }

        private void lvRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRules.SelectedItems.Count > 0 && lvRules.SelectedItems[0].Tag is Helpers.Rule rule)
            {
                txtRuleDescr.Text = rule.Summary;
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
                SettingsApplyToUI(settings);
                ConnectPAChecker(true);
            }
        }

        private void picRuleHelp_Click(object sender, EventArgs e)
        {
            if (lvRules.SelectedItems.Count > 0 && lvRules.SelectedItems[0].Tag is Helpers.Rule rule)
            {
                Process.Start(rule.GuidanceUrl.Replace("client=PAChecker", "client=Rappen.XTB.PAC"));
            }
        }

        private void rbGroupBy_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                LoadRules();
            }
        }

        private void rbScope_CheckedChanged(object sender, EventArgs e)
        {
            Enable(true);
        }

        private void tmStatus_Tick(object sender, EventArgs e)
        {
            CheckAnalysisStatus();
        }

        #endregion Private event handlers

        #region Private Methods

        private void CheckAnalysisStatus()
        {
            tmStatus.Enabled = false;
            Enable(false);
            var enabled = true;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Checking analysis status",
                AsyncArgument = txtStatusUrl.Text,
                Work = (worker, args) =>
                {
                    args.Result = client.GetStatus(args.Argument.ToString());
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is AnalysisStatus status)
                    {
                        txtRunCorrId.Text = status.RunCorrelationId.ToString();
                        txtStatus.Text = status.Status;
                        progAnalysis.Value = status.Progress;
                        if (status.Progress >= 100)
                        {
                            WriteToLog($"{status.IssueSummary.CriticalIssueCount} Critical");
                            WriteToLog($"{status.IssueSummary.HighIssueCount} High");
                            WriteToLog($"{status.IssueSummary.MediumIssueCount} Medium");
                            WriteToLog($"{status.IssueSummary.LowIssueCount} Low");
                            WriteToLog($"{status.IssueSummary.InformationalIssueCount} Informational");
                            if (status.ResultFileUris != null && status.ResultFileUris.Length > 0)
                            {
                                txtResultFile.Text = status.ResultFileUris[0];
                                GetResultFile(status);
                                enabled = false;
                            }
                        }
                        else
                        {
                            tmStatus.Start();
                        }
                    }
                    Enable(enabled);
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
            var enable = true;
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
                        enable = false;
                    }
                    Enable(enable);
                }
            });
        }

        private void Enable(bool enable)
        {
            Enabled = enable;
            btnConnectPAC.Enabled = enable && Guid.TryParse(txtTenantId.Text, out Guid t) && Guid.TryParse(txtClientId.Text, out Guid c) && !string.IsNullOrWhiteSpace(txtClientSec.Text);
            cbRuleset.Enabled = enable && client != null && cbRuleset.Items.Count > 0;
            picRuleHelp.Enabled = enable && lvRules.SelectedItems.Count > 0;
            cbSolution.Enabled = enable && Service != null;
            btnExport.Enabled = enable && cbSolution.SelectedEntity != null;
            btnUpload.Enabled = enable && client != null && File.Exists(txtFilename.Text);
            btnAnalyze.Enabled = enable && client != null && !string.IsNullOrEmpty(linkUploaded.Text) &&
                ((rbScopeRuleset.Checked && cbRuleset.SelectedItem is RuleSet) || (rbScopeRules.Checked && lvRules.CheckedItems.Count > 0));
            btnSaveSarif.Enabled = enable && !string.IsNullOrWhiteSpace(txtResultFile.Text);
            picRuleHelp.Cursor = picRuleHelp.Enabled ? Cursors.Hand : Cursors.No;
        }

        private void ExportSolution(Entity solution)
        {
            Enable(false);
            txtFilename.Text = "";
            txtCorrId.Text = "";
            linkUploaded.Text = "";
            txtRunCorrId.Text = "";
            txtStatusUrl.Text = "";
            txtStatus.Text = "";
            progAnalysis.Value = 0;
            txtResultFile.Text = "";
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

        private AnalysisArgs GetAnalysisArgs()
        {
            var args = new AnalysisArgs
            {
                CorrId = new Guid(txtCorrId.Text),
                FileUrl = linkUploaded.Text,
                RuleSets = new List<RuleSet>(),
                Rules = new List<Helpers.Rule>(),
                Exclusions = txtExclusions.Text.Split(',').Select(e => e.Trim()).Where(e => !string.IsNullOrEmpty(e)).ToList()
            };
            if (rbScopeRuleset.Checked && cbRuleset.SelectedItem is RuleSet ruleset)
            {
                args.RuleSets.Add(ruleset);
            }
            else if (rbScopeRules.Checked)
            {
                foreach (ListViewItem item in lvRules.CheckedItems)
                {
                    if (item.Tag is Helpers.Rule rule)
                    {
                        args.Rules.Add(rule);
                    }
                }
            }
            return args;
        }

        private void GetResultFile(AnalysisStatus status)
        {
            if (status.ResultFileUris != null)
            {
                Enable(false);
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Getting result file",
                    AsyncArgument = status.ResultFileUris,
                    Work = (worker, args) =>
                    {
                        var files = args.Argument as string[];
                        var results = new List<string>();
                        foreach (var resultfile in files)
                        {
                            results.Add(PACHelper.GetResultFile(resultfile));
                        }
                        args.Result = results;
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.Message);
                        }
                        else if (args.Result is List<string> results && results.Count > 0)
                        {
                            txtSarif.Text = results[0];
                            btnSaveSarif.Enabled = true;
                            foreach (var result in results)
                            {
                                ParseSarifLog(PACHelper.GetSarifFromString(result));
                            }
                        }
                        Enable(true);
                        progAnalysis.Value = 0;
                    }
                });
            }
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

        private void GroupBoxSetState(LinkLabel link, bool expanded)
        {
            if (expanded)
            {
                GroupBoxExpand(link);
            }
            else
            {
                GroupBoxCollapse(link);
            }
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
            splitContainer2.Height = Math.Max(gbSolution.Height, gbAnalysis.Height + gbResults.Height) + 3;
        }

        private void LoadRules()
        {
            Enable(false);
            var enabled = true;
            lvRules.Items.Clear();
            lvRules.Groups.Clear();
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading rules",
                Work = (worker, args) =>
                {
                    args.Result = client.GetRules();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is Helpers.Rule[] rulelist)
                    {
                        lvRules.Items.AddRange(rulelist.Select(r => RuleToListItem(r)).ToArray());
                        if (cbRuleset.SelectedItem != null)
                        {
                            LoadRuleSetSelections(cbRuleset.SelectedItem as RuleSet);
                            enabled = false;
                        }
                    }
                    Enable(enabled);
                }
            });
        }

        private void LoadRuleSets()
        {
            Enable(false);
            var enabled = true;
            cbRuleset.Items.Clear();
            cbRuleset.Items.Add("");
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading rulesets",
                Work = (worker, args) =>
                {
                    args.Result = client.GetRuleSets();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is RuleSet[] rulesetlist)
                    {
                        cbRuleset.Items.AddRange(rulesetlist);
                        LoadRules();
                        enabled = false;
                    }
                    Enable(enabled);
                }
            });
        }

        private void LoadRuleSetSelections(RuleSet ruleset)
        {
            ListViewItem GetListViewItemByRule(Helpers.Rule rule)
            {
                ListViewItem[] items = new ListViewItem[lvRules.Items.Count];
                lvRules.Items.CopyTo(items, 0);
                return items.FirstOrDefault(i => i.Tag is Helpers.Rule && ((Helpers.Rule)i.Tag).Code == rule.Code);
            }

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
                    args.Result = client.GetRules(ruleset.Id);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is Helpers.Rule[] rulelist)
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

        private void ParseSarifLog(SarifLog result)
        {
            var maxcount = 100;
            foreach (var run in result.Runs)
            {
                var severity = "";
                //WriteToLog($"Results: {run.Results.Count}");
                //var summary = run.Results.GroupBy(
                //    r => r.GetProperty("severity"),
                //    r => r.RuleId, (sev, values) =>
                //    new
                //    {
                //        Severity = sev,
                //        Count = values.Count()
                //    }).OrderBy(s => s.Severity);
                //foreach (var sum in summary)
                //{
                //    WriteToLog($"{sum.Severity}: {sum.Count}");
                //}
                if (run.Results.Count > maxcount)
                {
                    WriteToLog($"Showing first {maxcount} results of total {run.Results.Count}");
                }
                dgResults.DataSource = FlattenedResult.GetFlattenedResults(run);
            }
        }

        private ListViewItem RuleToListItem(Helpers.Rule rule)
        {
            var groupby = (rbGroupCategory.Checked ? $"Category: {rule.PrimaryCategory}" : $"Severity: {rule.Severity}");
            var groups = new ListViewGroup[lvRules.Groups.Count];
            lvRules.Groups.CopyTo(groups, 0);
            var group = groups.FirstOrDefault(g => g.Header == groupby);
            if (group == null)
            {
                group = lvRules.Groups.Add(groupby, groupby);
                group.HeaderAlignment = HorizontalAlignment.Center;
            }
            var item = new ListViewItem(rule.ToString())
            {
                Tag = rule,
                Checked = rule.Include,
                Group = group
            };
            return item;
        }

        private void SendAnalysis()
        {
            Enable(false);
            txtRunCorrId.Text = "";
            txtStatusUrl.Text = "";
            txtStatus.Text = "";
            progAnalysis.Value = 0;
            txtResultFile.Text = "";
            var analysisargs = GetAnalysisArgs();
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
                            txtStatus.Text = "Sent";
                            progAnalysis.Value = 1;
                            txtStatusUrl.Text = response.Headers.Location.ToString();
                            txtAnalysis.Text = "Analysis sent\r\n";
                            tmStatus.Start();
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
            txtExclusions.Text = settings.FileExclusions;
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
            settings.FileExclusions = txtExclusions.Text;
            return settings;
        }

        private void UpdateRuleCounts()
        {
            lblRules.Text = $"{lvRules.CheckedItems.Count}  selected of {lvRules.Items.Count} rules.";
        }

        private void UploadSolutionFile()
        {
            Enable(false);
            txtCorrId.Text = "";
            linkUploaded.Text = "";
            txtRunCorrId.Text = "";
            txtStatusUrl.Text = "";
            txtStatus.Text = "";
            progAnalysis.Value = 0;
            txtResultFile.Text = "";
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
                        linkUploaded.Text = bloburl;
                    }
                    Enable(true);
                }
            });
        }

        private void WriteToLog(string text)
        {
            txtAnalysis.Text += $"{text}\r\n";
        }

        #endregion Private Methods
    }
}