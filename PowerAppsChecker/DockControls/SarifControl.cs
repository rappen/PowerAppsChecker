using Microsoft.CodeAnalysis.Sarif;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC.DockControls
{
    public partial class SarifControl : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region Private Fields

        private readonly PAC pac;

        #endregion Private Fields

        #region Public Constructors

        public SarifControl(PAC pac)
        {
            this.pac = pac;
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Internal Methods

        internal void Enable(bool enable)
        {
            btnSaveSarif.Enabled = enable && !string.IsNullOrWhiteSpace(txtResultFile.Text);
        }

        internal void Reset()
        {
            txtRunCorrId.Text = "";
            txtStatusUrl.Text = "";
            txtStatus.Text = "";
            progAnalysis.Value = 0;
            txtResultFile.Text = "";
        }

        internal void SaveSarifToFile(string filename)
        {
            File.WriteAllText(filename, txtSarif.Text);
        }

        internal void SetSarif(string sarif)
        {
            txtSarif.Text = sarif;
        }

        internal void SetStatus(AnalysisStatus status)
        {
            txtResultCountCritical.Text = status.IssueSummary.CriticalIssueCount.ToString();
            txtResultCountHigh.Text = status.IssueSummary.HighIssueCount.ToString();
            txtResultCountMedium.Text = status.IssueSummary.MediumIssueCount.ToString();
            txtResultCountLow.Text = status.IssueSummary.LowIssueCount.ToString();
            txtResultCountInfo.Text = status.IssueSummary.InformationalIssueCount.ToString();
        }

        internal void StartStatusCheck(string statusurl)
        {
            txtStatus.Text = "Sent";
            progAnalysis.Value = 1;
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
                    SaveSarifToFile(sd.FileName);
                    MessageBox.Show($"{sd.FileName} saved!");
                }
            }
        }

        private void CheckAnalysisStatus()
        {
            tmStatus.Enabled = false;
            Enable(false);
            var enabled = true;
            pac.WorkAsync(new WorkAsyncInfo
            {
                Message = "Checking analysis status",
                AsyncArgument = txtStatusUrl.Text,
                Work = (worker, args) =>
                {
                    args.Result = pac.client.GetAnalysisStatus(args.Argument.ToString());
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
                    Enable(enabled);
                }
            });
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgResults.Columns[e.ColumnIndex].Name == FilePath.Name && pac.ConnectionDetail != null)
            {
                var file = dgResults[e.ColumnIndex, e.RowIndex].Value.ToString();
                var url = pac.ConnectionDetail.WebApplicationUrl + file;
                Process.Start(url);
            }
        }

        private void dgResults_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var col = dgResults.Columns[e.ColumnIndex];
            dgGrouper.Options.StartCollapsed = true;
            dgGrouper.SetGroupOn(col);
        }

        private void GetResultFile(AnalysisStatus status)
        {
            if (status.ResultFileUris != null)
            {
                Enable(false);
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
                            SetSarif(results[0]);
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

        private void ParseSarifLog(SarifLog result)
        {
            //var maxcount = 100;
            foreach (var run in result.Runs)
            {
                //var severity = "";
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
                //if (run.Results.Count > maxcount)
                //{
                //    sarifControl.WriteToLog($"Showing first {maxcount} results of total {run.Results.Count}");
                //}
                dgResults.DataSource = FlattenedResult.GetFlattenedResults(run);
            }
        }

        private void tmStatus_Tick(object sender, EventArgs e)
        {
            CheckAnalysisStatus();
        }

        #endregion Private Methods
    }
}
