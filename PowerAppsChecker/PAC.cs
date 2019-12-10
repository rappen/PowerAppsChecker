using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk;
using Rappen.XTB.PAC.Dialogs;
using Rappen.XTB.PAC.DockControls;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Rappen.XTB.PAC
{
    public partial class PAC : PluginControlBase, IGitHubPlugin, IPayPalPlugin, IHelpPlugin, IAboutPlugin
    {

        #region Internal Fields

        internal readonly SarifControl sarifControl;
        internal readonly ScopeControl scopeControl;
        internal AppInsights ai = new AppInsights(new AiConfig(aiEndpoint, aiKey) { PluginName = "Power Apps Checker" });

        #endregion Internal Fields

        #region Private Fields

        private const string aiEndpoint = "https://dc.services.visualstudio.com/v2/track";
        //private const string aiKey = "cc7cb081-b489-421d-bb61-2ee53495c336";    // jonas@rappen.net tenant, TestAI 
        private const string aiKey = "eed73022-2444-45fd-928b-5eebd8fa46a6";    // jonas@rappen.net tenant, XrmToolBox
        private readonly AzureLoginDialog azureLogin;
        private readonly SolutionDialog solutionSelector;
        private PACClientInfo pacclientinfo;
        private List<Solution> solutions;
        private Solution LastExportTry;
        private Solution LastUploadTry;

        #endregion Private Fields

        #region Public Constructors

        public PAC()
        {
            InitializeComponent();
            var theme = new VS2015LightTheme();
            dockContainer.Theme = theme;
            scopeControl = new ScopeControl(this);
            sarifControl = new SarifControl(this);
            azureLogin = new AzureLoginDialog(this);
            solutionSelector = new SolutionDialog(this);
        }

        #endregion Public Constructors

        #region Public Properties

        public string DonationDescription => "Power Apps Checker fan club";

        public string EmailAccount => "jonas@rappen.net";

        public string RepositoryName => "PowerAppsChecker";

        public string UserName => "rappen";

        #endregion Public Properties

        #region Internal Properties

        internal PACClientInfo PACClientInfo
        {
            get
            {
                if (pacclientinfo == null || pacclientinfo.ClientId.Equals(Guid.Empty))
                {
                    pacclientinfo = azureLogin.GetPACClientInfo();
                }
                return pacclientinfo;
            }
        }

        internal string WorkingFolder
        {
            get
            {
                var path = Path.Combine(Paths.XrmToolBoxPath, "Rappen.XTB.PAC");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        public string HelpUrl => "https://powerappschecker.com/";

        #endregion Internal Properties

        #region Public Methods

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            SettingsManager.Instance.Save(GetType(), SettingsGetFromUI(), ConnectionDetail?.ConnectionName);
            base.ClosingPlugin(info);
        }

        public void ShowAboutDialog()
        {
            using (var about = new About(this))
            {
                about.ShowDialog(this);
            }
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            if (SettingsManager.Instance.TryLoad(GetType(), out Settings settings, detail.ConnectionName))
            {
                SettingsApplyToUI(settings);
            }
            solutionSelector.LoadSolutions(settings);
            Enable(true);
        }

        #endregion Public Methods

        #region Internal Methods

        internal void Enable(bool enable)
        {
            Enabled = enable;
            btnAnalyze.Enabled = enable && solutions != null && solutions.Count > 0 && scopeControl.EnableAnalysis();
            scopeControl.Enable(enable);
            sarifControl.Enable(enable);
        }

        #endregion Internal Methods

        #region Event handlers

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            Analyze();
        }

        private void btnConnectPAC_Click(object sender, EventArgs e)
        {
            var clientinfo = azureLogin.GetPACClientInfo();
            if (clientinfo != null)
            {
                pacclientinfo = clientinfo;
                scopeControl.SetUrlAndLanguage(pacclientinfo.ServiceUrl, pacclientinfo.Language);
            }
        }

        private void btnSelectSolutions_Click(object sender, EventArgs e)
        {
            solutions = solutionSelector.GetSolutions();
            scopeControl.SetSolutions(solutions);
            Enable(true);
        }

        private void PAC_Load(object sender, EventArgs e)
        {
            ai.WriteEvent("Load");
            if (SettingsManager.Instance.TryLoad(GetType(), out Settings settings, ConnectionDetail?.ConnectionName))
            {
                SettingsApplyToUI(settings);
            }
            ResetDockLayout();
            scopeControl.LoadRuleSets();
        }

        private void PAC_OnCloseTool(object sender, EventArgs e)
        {
            ai.WriteEvent("Close");
        }

        private void tslByJonas_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        #endregion Event handlers

        #region Private Methods

        private void Analyze()
        {
            ai.WriteEvent("Analyze");
            LastExportTry = null;
            LastUploadTry = null;
            if (pacclientinfo != null)
            {
                pacclientinfo.Token = null;
            }
            SendAnalysis(GetAnalysisArgs());
        }

        private void ExportSolution(AnalysisArgs analysisargs, Solution solution)
        {
            if (LastExportTry == solution)
            {
                ShowError($"Failed to export {solution}");
                return;
            }
            LastExportTry = solution;
            Enable(false);
            var solname = solution.UniqueName;
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Exporting {solname}",
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
                        ShowError(args.Error);
                    }
                    else if (args.Result is ExportSolutionResponse resp)
                    {
                        var exportXml = resp.ExportSolutionFile;
                        var filepath = WorkingFolder;
                        var filename = $"{solname} {solution.Version}";
                        var fullpath = Path.Combine(filepath, filename + ".zip");
                        int i = 0;
                        while (File.Exists(fullpath))
                        {
                            fullpath = Path.Combine(filepath, $"{filename} ({++i}).zip");
                        }
                        File.WriteAllBytes(fullpath, exportXml);
                        solution.LocalFilePath = fullpath;
                    }
                    Enable(true);
                    SendAnalysis(analysisargs);
                }
            });
        }

        private AnalysisArgs GetAnalysisArgs()
        {
            var analysisargs = scopeControl.GetAnalysisScopeArgs();
            analysisargs.Solutions = solutions;
            sarifControl.SetArgs(analysisargs);
            return analysisargs;
        }

        private void ResetDockLayout()
        {
            sarifControl.Show(dockContainer, DockState.Document);
            scopeControl.Show(dockContainer, DockState.DockLeft);
            dockContainer.DockLeftPortion = scopeControl.originalSize.Width;
        }

        private void SendAnalysis(AnalysisArgs analysisargs)
        {
            var notexported = analysisargs.Solutions.FirstOrDefault(s => !string.IsNullOrEmpty(s.UniqueName) && string.IsNullOrEmpty(s.LocalFilePath));
            if (notexported != null)
            {
                ExportSolution(analysisargs, notexported);
                return;
            }
            var notuploaded = analysisargs.Solutions.FirstOrDefault(s => !string.IsNullOrEmpty(s.LocalFilePath) && s.UploadUrl == null);
            if (notuploaded != null)
            {
                UploadSolutionFile(analysisargs, notuploaded);
                return;
            }
            var pci = PACClientInfo;
            if (pci == null)
            {
                return;
            }
            Enable(false);
            sarifControl.panAnalyzing.Visible = true;
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Sending {analysisargs.SolutionNames} for analysis",
                AsyncArgument = new { clientinfo = pci, analysisargs },
                Work = (worker, args) =>
                {
                    var a = args.Argument as dynamic;
                    var clientinfo = a.clientinfo as PACClientInfo;
                    var aa = a.analysisargs as AnalysisArgs;
                    args.Result = PACHelper.SendAnalysis(clientinfo, aa);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowError(args.Error);
                    }
                    else if (args.Result is HttpResponseMessage response)
                    {
                        if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                        {
                            sarifControl.panAnalyzing.Visible = false;
                            LogError("SendAnalysis:\r\n{0}", response);
                            ShowError($"Status: {response.StatusCode}\r\n{response.ReasonPhrase}\r\nSee XrmToolBox log for details.", "Send for Analysis");
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
            scopeControl.SetUrlAndLanguage(settings.ServiceUrl, settings.Language);
            scopeControl.txtExclusions.Text = settings.FileExclusions;
            azureLogin.SettingsApplyToUI(settings);
            solutionSelector.SettingsApplyToUI(settings);
        }

        private Settings SettingsGetFromUI()
        {
            var settings = new Settings();
            settings.FileExclusions = scopeControl.txtExclusions.Text;
            azureLogin.SettingsGetFromUI(settings);
            solutionSelector.SettingsGetFromUI(settings);
            return settings;
        }

        private void UploadSolutionFile(AnalysisArgs analysisargs, Solution solution)
        {
            if (LastUploadTry == solution)
            {
                ShowError($"Failed to upload {solution}", "Upload");
                return;
            }
            LastUploadTry = solution;
            var pci = PACClientInfo;
            if (pci == null)
            {
                return;
            }
            Enable(false);
            var corrid = Guid.NewGuid();
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Uploading {solution.LocalFileName}",
                AsyncArgument = new { clientinfo = pci, corr = corrid, file = solution.LocalFilePath },
                Work = (worker, args) =>
                {
                    var a = args.Argument as dynamic;
                    var clientinfo = a.clientinfo as PACClientInfo;
                    var corr = a.corr as Guid?;
                    var file = a.file as string;
                    args.Result = PACHelper.UploadSolution(clientinfo, (Guid)corr, file);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowError(args.Error);
                    }
                    else if (args.Result is string bloburl)
                    {
                        solution.UploadUrl = new Uri(bloburl);
                    }
                    Enable(true);
                    SendAnalysis(analysisargs);
                }
            });
        }

        internal void ShowError(string error, string caption = null)
        {
            ShowError(new PACInnerException(error), caption);
        }

        internal void ShowError(Exception error, string caption = null)
        {
            LogError(error.ToString());
            if (error.InnerException != null)
            {
                ShowError(error.InnerException);
            }
            else
            {
                MessageBox.Show(error.Message, caption ?? "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Private Methods
    }
}