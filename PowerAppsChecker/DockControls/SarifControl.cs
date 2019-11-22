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
            Reset();
        }

        #endregion Public Constructors

        #region Private Properties

        private List<ComboBox> FilterComboBoxes
        {
            get
            {
                return splitter.Panel1.Controls.Cast<Control>().Where(c => c is ComboBox cb && cb.Tag.ToString().StartsWith("col")).Select(c => c as ComboBox).ToList();
            }
        }

        #endregion Private Properties

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

        private static void FixDetailVisibility(Label text, Label label)
        {
            label.Visible = !string.IsNullOrWhiteSpace(text.Text);
            text.Visible = label.Visible;
        }

        private void AlignFilters()
        {
            var offset = -dgResults.HorizontalScrollingOffset;
            foreach (var col in dgResults.Columns.Cast<DataGridViewColumn>())
            {
                if (splitter.Panel1.Controls.Cast<Control>().FirstOrDefault(c => c is ComboBox && c.Tag?.ToString() == col.Name) is ComboBox cb)
                {
                    cb.Left = offset + col.Width - cb.Width + 1;
                    offset += col.Width;
                }
            }
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

        private void cbFilter_DropDown(object sender, EventArgs e)
        {
            if (!(sender is ComboBox cb))
            {
                return;
            }
            SetFilterExpandedWidth(cb);
        }

        private void cbFilter_DropDownClosed(object sender, EventArgs e)
        {
            if (!(sender is ComboBox cb))
            {
                return;
            }
            SetFilterCollapsedWidth(cb);
            dgResults.Focus();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterResults();
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
                        panAnalyzing.Visible = false;
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is AnalysisStatus status)
                    {
                        txtRunCorrId.Text = status.RunCorrelationId.ToString();
                        SetStatus(status.Status, status.Progress);
                        if (status.Progress >= 100)
                        {
                            panAnalyzing.Visible = false;
                            SetCounts(status);
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

        private void dgResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgResults.Rows.Count)
            {
                return;
            }
            SetDetailInfo(dgResults.Rows[e.RowIndex].DataBoundItem as FlattenedSarifResult, true);
        }

        private void dgResults_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgResults.Rows.Count)
            {
                return;
            }
            SetDetailInfo(dgResults.Rows[e.RowIndex].DataBoundItem as FlattenedSarifResult);
        }

        private void dgResults_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            AlignFilters();
        }

        private void dgResults_Scroll(object sender, ScrollEventArgs e)
        {
            AlignFilters();
        }

        private void FilterResults()
        {
            if (dgResults.DataSource == null)
            {
                return;
            }
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgResults.DataSource];
            currencyManager.SuspendBinding();
            foreach (var row in dgResults.Rows.Cast<DataGridViewRow>())
            {
                var visible = true;
                foreach (var cb in FilterComboBoxes)
                {
                    var value = (cb.SelectedItem as FilterItem)?.Name ?? cb.Text;
                    visible = visible && (string.IsNullOrWhiteSpace(value) || value == row.Cells[cb.Tag.ToString()].Value.ToString());
                }
                row.Visible = visible;
            }
            currencyManager.ResumeBinding();
            SetFilters();
        }

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

        //private void dgResults_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    var col = dgResults.Columns[e.ColumnIndex];
        //    dgGrouper.Options.StartCollapsed = true;
        //    dgGrouper.SetGroupOn(col);
        //}
        private void linkFix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link?.LinkData != null)
            {
                Process.Start(e.Link.LinkData.ToString());
            }
        }

        private void ParseSarifLog(SarifLog result)
        {
            if (result.Runs.Count == 0)
            {
                return;
            }
            var flatresults = FlattenedSarifResult.GetFlattenedResults(result.Runs[0], pac.scopeControl.Rules);
            SetCounts(flatresults);
            dgResults.DataSource = flatresults;
            dgResults.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            SetFilters();
            dgArtifacts.DataSource = result.Runs[0].Artifacts.Select(a => new Helpers.Artifact(a)).ToList();
            dgArtifacts.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (result.Runs[0].Invocations.Count == 1)
            {
                txtStatus.Text = result.Runs[0].Invocations[0].ExecutionSuccessful ? "Successful" : "Unsuccessful";
                txtStartTime.Text = result.Runs[0].Invocations[0].StartTimeUtc.ToLocalTime().ToString();
                txtEndTime.Text = result.Runs[0].Invocations[0].EndTimeUtc.ToLocalTime().ToString();
            }
        }

        private void picDetailClose_Click(object sender, EventArgs e)
        {
            SetDetailInfo(null);
        }

        private void picDetailOpen_Click(object sender, EventArgs e)
        {
            SetDetailInfo(dgResults.SelectedCells
                .Cast<DataGridViewCell>()
                .FirstOrDefault()?.OwningRow.DataBoundItem as FlattenedSarifResult, true);
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
            FilterComboBoxes.ForEach(ResetFilter);
            if (dgResults.DataSource != null)
            {
                var cols = dgResults.Columns.Cast<DataGridViewColumn>().ToArray();
                dgResults.DataSource = null;
                dgResults.Columns.AddRange(cols);
                var i = 0;
                dgResults.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.DisplayIndex = i++);
            }
            panTop.Controls
                .Cast<Control>()
                .Select(c => c as TextBox)
                .Where(t => t != null && t.Tag is string)
                .ToList()
                .ForEach(t => t.Text = "-");
            SetDetailInfo(null);
        }

        private void ResetFilter(ComboBox cb)
        {
            cb.Items.Clear();
            cb.Items.Add("");
            SetFilterCollapsedWidth(cb);
        }

        private void SaveSarifToFile(string filename)
        {
            File.WriteAllText(filename, txtSarif.Text);
        }

        private void SetCounts(List<FlattenedSarifResult> flatresults)
        {
            txtResultCountCritical.Text = flatresults.Count(r => r.Severity == "Critical").ToString();
            txtResultCountHigh.Text = flatresults.Count(r => r.Severity == "High").ToString();
            txtResultCountMedium.Text = flatresults.Count(r => r.Severity == "Medium").ToString();
            txtResultCountLow.Text = flatresults.Count(r => r.Severity == "Low").ToString();
            txtResultCountInfo.Text = flatresults.Count(r => r.Severity == "Informational").ToString();
        }

        private void SetCounts(AnalysisStatus status)
        {
            txtResultCountCritical.Text = status.IssueSummary.CriticalIssueCount.ToString();
            txtResultCountHigh.Text = status.IssueSummary.HighIssueCount.ToString();
            txtResultCountMedium.Text = status.IssueSummary.MediumIssueCount.ToString();
            txtResultCountLow.Text = status.IssueSummary.LowIssueCount.ToString();
            txtResultCountInfo.Text = status.IssueSummary.InformationalIssueCount.ToString();
        }

        private void SetDetailInfo(FlattenedSarifResult result, bool forceopen = false)
        {
            if (result != null && forceopen)
            {
                splitter.Panel2Collapsed = false;
            }
            if (result == null)
            {
                splitter.Panel2Collapsed = true;
            }
            picDetailOpen.Visible = splitter.Panel2Collapsed;
            if (splitter.Panel2Collapsed)
            {
                return;
            }
            splitter.Panel2.SuspendLayout();
            lblDetailHeader.Text = $"Details - {result.Severity}";
            txtRule.Text = result.Rule.Code;
            txtCategory.Text = result.Category.ToString();
            txtIssue.Text = result.Message;
            txtFix.Text = result.Rule.HowToFix?.Summary;
            txtComponent.Text = result.Component.ToString();
            txtLocation.Text = result.FilePath.ToString();
            txtLine.Text = result.StartLine > 0 ? result.StartLine.ToString() : string.Empty;
            txtType.Text = result.Type;
            txtModule.Text = result.Module;
            txtMember.Text = result.Member;
            txtSnippet.Text = result.Snippet?.Replace("\n", "\r\n");
            linkFix.Links[0].LinkData = result.Rule?.GuidanceUrl?.Replace("client=PAChecker", "client=Rappen.XTB.PAC");
            FixDetailVisibility(txtIssue, lblIssue);
            FixDetailVisibility(txtFix, lblFix);
            FixDetailVisibility(txtComponent, lblComponent);
            FixDetailVisibility(txtLocation, lblLocation);
            FixDetailVisibility(txtLine, lblLine);
            FixDetailVisibility(txtType, lblType);
            FixDetailVisibility(txtModule, lblModule);
            FixDetailVisibility(txtMember, lblMember);
            FixDetailVisibility(txtSnippet, lblSnippet);
            splitter.Panel2.ResumeLayout();
        }

        private void SetFilter(ComboBox cb)
        {
            if (string.IsNullOrWhiteSpace(cb.Text))
            {
                ResetFilter(cb);
                var propname = cb.Tag.ToString().Replace("col", "");
                cb.Items.AddRange(dgResults.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Visible)
                    .Select(r => r.DataBoundItem as FlattenedSarifResult)
                    .Where(r => r != null)
                    .GroupBy(r => r.GetProperty(propname))
                    .Select(g => new FilterItem { Name = g.Key, Count = g.Count() })
                    .OrderBy(i => i.Name)
                    .ToArray());
            }
        }

        private void SetFilterCollapsedWidth(ComboBox cb)
        {
            if (!string.IsNullOrWhiteSpace(cb.Text) || !(cb.Tag is string colname) || !(dgResults.Columns[colname] is DataGridViewColumn col))
            {
                return;
            }
            var colx = dgResults.Columns.Cast<DataGridViewColumn>().Where(c => c.DisplayIndex <= col.DisplayIndex).Sum(c => c.Width);
            cb.Left = colx - 18;
            cb.Width = 19;
        }

        private void SetFilterExpandedWidth(ComboBox cb)
        {
            if (!(cb.Tag is string colname) || !(dgResults.Columns[colname] is DataGridViewColumn col))
            {
                return;
            }
            var x = cb.Location.X;
            var w = cb.Size.Width;
            var colw = col.Width;
            cb.Left = x - colw + w;
            cb.Width = colw;
        }

        private void SetFilters()
        {
            FilterComboBoxes.ForEach(SetFilter);
        }

        private void SetSarif(string sarif)
        {
            txtSarif.Text = sarif;
        }

        private void SetStatus(string status, int progress)
        {
            txtStatus.Text = status;
            progAnalysis.Value = progress;
            progAnalysis.Visible = !string.IsNullOrEmpty(status);
        }

        private void splitContainer1_Panel2_SizeChanged(object sender, EventArgs e)
        {
            splitter.Panel2.Controls.Cast<Control>()
                .Where(c => c is Label)
                .Where(c => c.MaximumSize.Width != 0)
                .ToList()
                .ForEach(c => c.MaximumSize = new Size(splitter.Panel2.Width - 20, c.MaximumSize.Height));
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
                panTop.Controls
                    .Cast<Control>()
                    .Select(c => c as TextBox)
                    .Where(t => t != null && t.Tag is string)
                    .ToList()
                    .ForEach(t => t.BackColor = filterSeverity == t ? Color.Red : SystemColors.Window);
            }
        }

        #endregion Private Methods
    }
}
