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

        internal readonly SarifControl sarifControl;
        private readonly AzureLoginDialog azureLogin;
        internal readonly ScopeControl scopeControl;
        private readonly SolutionControl solutionControl;
        private HttpClient pacclient;
        private string pacregion;

        #endregion Private Fields

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

        internal string PACRegion { get => pacregion; }

        #endregion Internal Properties

        #region Public Constructors

        public PAC()
        {
            InitializeComponent();
            var theme = new VS2015LightTheme();
            dockContainer.Theme = theme;
            scopeControl = new ScopeControl(this);
            sarifControl = new SarifControl(this);
            solutionControl = new SolutionControl(this);
            azureLogin = new AzureLoginDialog(this);
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
            solutionControl.UpdateConnection(newService);
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

        private void btnResetWindows_Click(object sender, EventArgs e)
        {
            ResetDockLayout();
        }

        private void PAC_Load(object sender, EventArgs e)
        {
            if (SettingsManager.Instance.TryLoad(GetType(), out Settings settings, ConnectionDetail?.ConnectionName))
            {
                SettingsApplyToUI(settings);
            }
            SetupDockControls();
            scopeControl.LoadRuleSets();
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
                case "Rappen.XTB.PAC.DockControls.SolutionControl":
                    return solutionControl;
                default:
                    return null;
            }
        }

        private void ResetDockLayout()
        {
            sarifControl.Show(dockContainer, DockState.Document);
            solutionControl.Show(dockContainer, DockState.DockTop);
            scopeControl.Show(dockContainer, DockState.DockLeft);
            dockContainer.DockTopPortion = solutionControl.originalSize.Height;
            dockContainer.DockLeftPortion = scopeControl.originalSize.Width;
            //solutionControl.Show(sarifControl.Pane, DockAlignment.Top, solutionControl.originalSize.Height);
        }

        private void SaveDockPanels()
        {
            var dockFile = GetDockFileName();
            dockContainer.SaveAsXml(dockFile);
        }

        private void SetupDockControls()
        {
            //string dockFile = GetDockFileName();
            //if (File.Exists(dockFile))
            //{
            //    try
            //    {
            //        dockContainer.LoadFromXml(dockFile, dockDeSerialization);
            //        return;
            //    }
            //    catch (InvalidOperationException)
            //    {
            //        // Restore from file failed
            //    }
            //    catch (ArgumentOutOfRangeException)
            //    {
            //        // Restore from file failed
            //    }
            //}
            ResetDockLayout();
        }

        #endregion Dock methods

        #region Private Methods

        internal void Enable(bool enable)
        {
            Enabled = enable;
            btnAnalyze.Enabled = enable && solutionControl.Uploaded && scopeControl.EnableAnalysis();
            scopeControl.Enable(enable);
            sarifControl.Enable(enable);
            solutionControl.Enable(enable);
        }

        private void SendAnalysis()
        {
            Enable(false);
            sarifControl.Reset();
            var analysisargs = scopeControl.GetAnalysisScopeArgs();
            solutionControl.GetAnalysisSolutionArgs(analysisargs);
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
            solutionControl.SettingsApplyToUI(settings);
            scopeControl.txtExclusions.Text = settings.FileExclusions;
            azureLogin.SettingsApplyToUI(settings);
        }

        private Settings SettingsGetFromUI()
        {
            var settings = new Settings();
            solutionControl.SettingsGetFromUI(settings);
            settings.FileExclusions = scopeControl.txtExclusions.Text;
            azureLogin.SettingsGetFromUI(settings);
            return settings;
        }

        #endregion Private Methods

        private void btnConnectPAC_Click(object sender, EventArgs e)
        {
            pacclient = null;
            var a = PACClient;
        }
    }
}