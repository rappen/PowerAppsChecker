using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC.DockControls
{
    public partial class SolutionControl : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region Internal Fields

        internal Size originalSize;

        #endregion Internal Fields

        #region Private Fields

        private readonly PAC pac;

        #endregion Private Fields

        #region Public Constructors

        public SolutionControl(PAC pac)
        {
            this.pac = pac;
            InitializeComponent();
            originalSize = Size;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool Uploaded => !string.IsNullOrEmpty(linkUploaded.Text);

        #endregion Public Properties

        #region Internal Methods

        internal void Enable(bool enable)
        {
            cbSolution.Enabled = enable && pac.Service != null;
            btnExport.Enabled = enable && cbSolution.SelectedEntity != null;
            btnUpload.Enabled = enable && File.Exists(txtFilename.Text);
        }

        internal void GetAnalysisSolutionArgs(AnalysisArgs analysisargs)
        {
            analysisargs.CorrId = new Guid(txtCorrId.Text);
            analysisargs.FileUrl = linkUploaded.Text;
        }

        internal void Reset()
        {
            txtFilename.Text = "";
            txtCorrId.Text = "";
            linkUploaded.Text = "";
        }

        internal void SettingsApplyToUI(Settings settings)
        {
            txtFilename.Text = settings.SolutionFile;
            txtCorrId.Text = settings.CorrelationId.ToString();
            linkUploaded.Text = settings.UploadedFile;
        }

        internal void SettingsGetFromUI(Settings settings)
        {
            settings.SolutionFile = txtFilename.Text;
            if (Guid.TryParse(txtCorrId.Text, out Guid coid))
            {
                settings.CorrelationId = coid;
            }
            settings.UploadedFile = linkUploaded.Text;
        }

        internal void UpdateConnection(IOrganizationService newService)
        {
            cbSolution.OrganizationService = newService;
            LoadSolutions();
        }

        #endregion Internal Methods

        #region Private Methods

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
                    pac.sarifControl.Reset();
                }
            }
            pac.Enable(true);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadSolutionFile();
        }

        private void cdSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            pac.Enable(true);
        }

        private void ExportSolution(Entity solution)
        {
            pac.Enable(false);
            Reset();
            pac.sarifControl.Reset();
            var solname = solution["uniquename"].ToString();
            pac.WorkAsync(new WorkAsyncInfo
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
                    args.Result = pac.Service.Execute(req) as ExportSolutionResponse;
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
                    pac.Enable(true);
                }
            });
        }

        private void linkUploaded_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkUploaded.Text);
        }

        private void LoadSolutions()
        {
            pac.Enable(false);
            cbSolution.DataSource = null;
            if (pac.Service == null)
            {
                return;
            }
            pac.WorkAsync(new WorkAsyncInfo
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
                    args.Result = pac.Service.RetrieveMultiple(qx);
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
                    pac.Enable(true);
                }
            });
        }

        private void UploadSolutionFile()
        {
            pac.Enable(false);
            txtCorrId.Text = "";
            linkUploaded.Text = "";
            pac.sarifControl.Reset();
            var corrid = Guid.NewGuid();
            txtCorrId.Text = corrid.ToString();
            pac.WorkAsync(new WorkAsyncInfo
            {
                Message = "Uploading",
                AsyncArgument =new { client = pac.PACClient, corr = corrid, file = txtFilename.Text },
                Work = (worker, args) =>
                {
                    var a = args.Argument as dynamic;
                    var client = a.client as HttpClient;
                    var corr = a.corr as Guid?;
                    var file = a.file as string;
                    args.Result = client.UploadSolution(pac.PACRegion, (Guid)corr, file);
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
                    pac.Enable(true);
                }
            });
        }

        #endregion Private Methods
    }
}
