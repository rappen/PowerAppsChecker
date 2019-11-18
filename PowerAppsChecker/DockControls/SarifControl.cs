using Microsoft.CodeAnalysis.Sarif;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC.DockControls
{
    public partial class SarifControl : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        #region Private Fields

        private readonly PAC pac;
        private TextBox filterSeverity;

        #endregion Private Fields

        #region Public Constructors

        public SarifControl(PAC pac)
        {
            this.pac = pac;
            InitializeComponent();
            DoubleBuffered = true;
        }

        #endregion Public Constructors

        #region Internal Methods

        internal void Enable(bool enable)
        {
            btnSaveSarif.Enabled = enable && !string.IsNullOrWhiteSpace(txtResultFile.Text);
        }

        internal void SetArgs(AnalysisArgs args)
        {
            Reset();
            txtCorrId.Text = args.CorrId.ToString();
            txtExclusions.Text = string.Join(", ", args.FileExclusions);
            txtRulesets.Text = string.Join(", ", args.RuleSets.Select(r => r.Name));
            lbRules.DataSource = args.Rules;
            dgSolutions.DataSource = args.Solutions;
            dgSolutions.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        internal void StartStatusCheck(string statusurl)
        {
            SetStatus("Sent", 1);
            txtStatusUrl.Text = statusurl;
            tmStatus.Start();
        }

        #endregion Internal Methods

        #region Private Methods

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
                    pac.ai.WriteEvent("OpenSarifFile");
                    Reset();
                    var sarif = File.ReadAllText(od.FileName);
                    txtSarif.Text = sarif;
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
                    pac.ai.WriteEvent("SaveSarifFile");
                    SaveSarifToFile(sd.FileName);
                    MessageBox.Show($"{sd.FileName} saved!");
                }
            }
        }

        private void CheckAnalysisStatus()
        {
            tmStatus.Enabled = false;
            pac.Enable(false);
            var enabled = true;
            pac.WorkAsync(new WorkAsyncInfo
            {
                Message = "Checking analysis status",
                AsyncArgument = new { client = pac.PACClient, url = txtStatusUrl.Text },
                Work = (worker, args) =>
                {
                    var a = args.Argument as dynamic;
                    var client = a.client as HttpClient;
                    var url = a.url as string;
                    args.Result = client.GetAnalysisStatus(url);
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
                        SetStatus(status.Status, status.Progress);
                        if (status.Progress >= 100)
                        {
                            SetStatus(status);
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
                    pac.Enable(enabled);
                }
            });
        }

        private void dgResults_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgResults.Rows[e.RowIndex].DataBoundItem is FlattenedSarifResult result)
            {
                txtMessage.Text = result.Message;
                txtHowToFix.Text = result.Rule.HowToFix?.Summary;
                txtSnippet.Text = result.Snippet.Replace("\n", "\r\n");
                picRuleHelp.Tag = result.Rule.GuidanceUrl;
            }
        }

        //private void dgResults_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    var col = dgResults.Columns[e.ColumnIndex];
        //    dgGrouper.Options.StartCollapsed = true;
        //    dgGrouper.SetGroupOn(col);
        //}

        private void GetResultFile(AnalysisStatus status)
        {
            if (status.ResultFileUris != null)
            {
                pac.Enable(false);
                pac.WorkAsync(new WorkAsyncInfo
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
                            SetStatus("", 0);
                            SetSarif(results[0]);
                            btnSaveSarif.Enabled = true;
                            foreach (var result in results)
                            {
                                ParseSarifLog(PACHelper.GetSarifFromString(result));
                            }
                        }
                        pac.Enable(true);
                    }
                });
            }
        }

        private void ParseSarifLog(SarifLog result)
        {
            if (result.Runs.Count == 0)
            {
                return;
            }
            dgResults.DataSource = FlattenedSarifResult.GetFlattenedResults(result.Runs[0], pac.scopeControl.Rules);
            dgResults.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgArtifacts.DataSource = result.Runs[0].Artifacts.Select(a => new Helpers.Artifact(a)).ToList();
            dgArtifacts.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (result.Runs[0].Invocations.Count == 1)
            {
                txtStatus.Text = result.Runs[0].Invocations[0].ExecutionSuccessful ? "Successful" : "Unsuccessful";
                txtStartTime.Text = result.Runs[0].Invocations[0].StartTimeUtc.ToLocalTime().ToString();
                txtEndTime.Text = result.Runs[0].Invocations[0].EndTimeUtc.ToLocalTime().ToString();
            }
        }

        private void picRuleHelp_Click(object sender, EventArgs e)
        {
            if (picRuleHelp.Tag is string helpurl)
            {
                Process.Start(helpurl.Replace("client=PAChecker", "client=Rappen.XTB.PAC"));
            }
        }

        private void Reset()
        {
            txtCorrId.Text = "";
            txtRunCorrId.Text = "";
            txtExclusions.Text = "";
            txtRulesets.Text = "";
            lbRules.DataSource = null;
            dgSolutions.DataSource = null;
            txtStatusUrl.Text = "";
            SetStatus("", 0);
            txtResultFile.Text = "";
            if (dgResults.DataSource != null)
            {
                var cols = dgResults.Columns.Cast<DataGridViewColumn>().ToArray();
                dgResults.DataSource = null;
                dgResults.Columns.AddRange(cols);
            }
            foreach (var severitybox in panTop.Controls.Cast<Control>().Select(c => c as TextBox).Where(t => t != null && t.Tag is string))
            {
                severitybox.Text = "-";
            }
            panTop.Visible = false;
        }

        private void SaveSarifToFile(string filename)
        {
            File.WriteAllText(filename, txtSarif.Text);
        }

        private void SetSarif(string sarif)
        {
            txtSarif.Text = sarif;
        }

        private void SetStatus(string status, int progress)
        {
            txtStatus.Text = status;
            progAnalysis.Value = progress;
            if (!string.IsNullOrEmpty(status))
            {
                panTop.Visible = true;
            }
            progAnalysis.Visible = !string.IsNullOrEmpty(status);
        }

        private void SetStatus(AnalysisStatus status)
        {
            txtResultCountCritical.Text = status.IssueSummary.CriticalIssueCount.ToString();
            txtResultCountHigh.Text = status.IssueSummary.HighIssueCount.ToString();
            txtResultCountMedium.Text = status.IssueSummary.MediumIssueCount.ToString();
            txtResultCountLow.Text = status.IssueSummary.LowIssueCount.ToString();
            txtResultCountInfo.Text = status.IssueSummary.InformationalIssueCount.ToString();
            panTop.Visible = true;
        }

        private void tmStatus_Tick(object sender, EventArgs e)
        {
            CheckAnalysisStatus();
        }

        private void txtResultCountInfo_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textbox && textbox.Tag is string tagstr)
            {
                if (filterSeverity == textbox)
                {
                    tagstr = null;
                    filterSeverity = null;
                }
                else
                {
                    filterSeverity = textbox;
                }
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgResults.DataSource];
                currencyManager.SuspendBinding();
                foreach (var row in dgResults.Rows.Cast<DataGridViewRow>())
                {
                    row.Visible = tagstr == null || row.Cells["colSeverity"].Value.ToString() == tagstr;
                }
                currencyManager.ResumeBinding();
                foreach (var severitybox in panTop.Controls.Cast<Control>().Select(c => c as TextBox).Where(t => t != null && t.Tag is string))
                {
                    severitybox.BackColor = filterSeverity == severitybox ? Color.Red : SystemColors.Window;
                }
            }
        }

        #endregion Private Methods
    }
}
