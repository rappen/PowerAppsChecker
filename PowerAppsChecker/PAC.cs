using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
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
    public partial class PAC : PluginControlBase, IGitHubPlugin, IPayPalPlugin, IAboutPlugin
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
        private HttpClient pacclient;
        private string pacregion;
        private List<Solution> solutions;

        #endregion Private Fields

        #region Public Constructors

        public PAC()
        {
            InitializeComponent();
            var theme = new VS2015LightTheme();
            dockContainer.Theme = theme;
            scopeControl = new ScopeControl(this);
            sarifControl = new SarifControl(this);
            azureLogin = new AzureLoginDialog();
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

        internal HttpClient PACClient
        {
            get
            {
                if (pacclient == null)
                {
                    var clientregion = azureLogin.GetPACClient(this);
                    if (clientregion != null)
                    {
                        pacclient = clientregion.Item1;
                        pacregion = clientregion.Item2;
                    }
                }
                return pacclient;
            }
        }

        internal string PACRegion => pacregion;

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
            ai.WriteEvent("Analyze");
            SendAnalysis(GetAnalysisArgs());
        }

        private void btnConnectPAC_Click(object sender, EventArgs e)
        {
            pacclient = null;
            var a = PACClient;
        }

        private void btnSelectSolutions_Click(object sender, EventArgs e)
        {
            solutions = solutionSelector.GetSolutions();
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
        
        private void ExportSolution(AnalysisArgs analysisargs, Solution solution)
        {
            Enable(false);
            var solname = solution.UniqueName;
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
                        var filename = Path.Combine(WorkingFolder, solname + ".zip");
                        File.WriteAllBytes(filename, exportXml);
                        solution.LocalFilePath = filename;
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
            Enable(false);
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
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initiating analysis",
                AsyncArgument = new { client = PACClient, analysisargs },
                Work = (worker, args) =>
                {
                    var a = args.Argument as dynamic;
                    var client = a.client as HttpClient;
                    var aa = a.analysisargs as AnalysisArgs;
                    args.Result = client.SendAnalysis(pacregion, aa);
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
            Enable(false);
            var corrid = Guid.NewGuid();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Uploading",
                AsyncArgument = new { client = PACClient, corr = corrid, file = solution.LocalFilePath },
                Work = (worker, args) =>
                {
                    var a = args.Argument as dynamic;
                    var client = a.client as HttpClient;
                    var corr = a.corr as Guid?;
                    var file = a.file as string;
                    args.Result = client.UploadSolution(PACRegion, (Guid)corr, file);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
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

        #endregion Private Methods
    }
}