using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC.Dialogs
{
    public partial class AzureLoginDialog : Form
    {
        #region Private Fields

        private const string serviceUrl = "https://{0}api.advisor.powerapps.com";
        private readonly PAC pac;
        private Guid clientforsecret;
        private Guid clientforuser;

        #endregion Private Fields

        #region Public Constructors

        public AzureLoginDialog(PAC pac)
        {
            InitializeComponent();
            this.pac = pac;
        }

        #endregion Public Constructors

        #region Public Methods

        public PACClientInfo GetPACClientInfo()
        {
            if (ShowDialog(pac) == DialogResult.OK)
            {
                return ConnectPAChecker();
            }
            return null;
        }

        #endregion Public Methods

        #region Internal Methods

        internal void SettingsApplyToUI(Settings settings)
        {
            rbUser.Checked = settings.AuthMethod == AuthMethod.User;
            rbSecret.Checked = settings.AuthMethod == AuthMethod.Secret;
            clientforuser = settings.ClientIdForUser;
            clientforsecret = settings.ClientIdForSecret;
            MethodSwitch();
            if (!settings.TenantId.Equals(Guid.Empty)) txtTenantId.Text = settings.TenantId.ToString();
            if (!string.IsNullOrEmpty(settings.ClientSecret)) txtClientSec.Text = settings.ClientSecret;
            if (!string.IsNullOrEmpty(settings.Region)) cbRegion.SelectedIndex = cbRegion.Items.IndexOf(settings.Region);
            txtRegionUrl.Text = settings.ServiceUrl;
            cbLanguage.Items.Clear();
            cbLanguage.Items.AddRange(settings.Languages.ToArray());
            if (!string.IsNullOrEmpty(settings.Language)) cbLanguage.SelectedIndex = cbLanguage.Items.IndexOf(settings.Language);
            CheckInputs();
        }

        internal void SettingsGetFromUI(Settings settings)
        {
            settings.AuthMethod = rbSecret.Checked ? AuthMethod.Secret : AuthMethod.User;
            if (Guid.TryParse(txtTenantId.Text, out Guid tid))
            {
                settings.TenantId = tid;
            }
            settings.ClientIdForUser = clientforuser;
            settings.ClientIdForSecret = clientforsecret;
            settings.ClientSecret = txtClientSec.Text;
            settings.Region = cbRegion.Text;
            settings.ServiceUrl = txtRegionUrl.Text;
            settings.Language = cbLanguage.Text;
        }

        #endregion Internal Methods

        #region Private Methods

        private void cbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckInputs();
            txtRegionUrl.Enabled = cbRegion.Text == "[Custom]";
        }

        private void CheckInputs()
        {
            txtRegionUrl.Text = GetServiceUrl();
            btnConnectPAC.Enabled =
                Guid.TryParse(txtClientId.Text, out var clientId) &&
                cbRegion.SelectedItem != null &&
                (rbUser.Checked || (Guid.TryParse(txtTenantId.Text, out var tenantId) && !string.IsNullOrEmpty(txtClientSec.Text)));
        }

        private PACClientInfo ConnectPAChecker()
        {
            var clientinfo = new PACClientInfo
            {
                ServiceUrl = GetServiceUrl(),
                Language = GetLanguage()
            };
            if (!Guid.TryParse(txtClientId.Text, out clientinfo.ClientId))
            {
                pac.ShowError("Bad Client Guid");
                return null;
            }
            if (cbRegion.SelectedItem == null)
            {
                pac.ShowError("Select Region");
                return null;
            }
            try
            {
                if (rbSecret.Checked)
                {
                    if (!Guid.TryParse(txtTenantId.Text, out clientinfo.TenantId))
                    {
                        pac.ShowError("Bad Tenant Guid");
                        return null;
                    }
                    clientinfo.ClientSec = txtClientSec.Text;
                }
                if (PACHelper.GetClient(clientinfo, PromptBehavior.SelectAccount) != null)
                {
                    pac.ai.WriteEvent($"Connect OK {cbRegion.Text}");
                }
            }
            catch (Exception ex)
            {
                pac.ShowError(ex, "Connect");
                return null;
            }
            return clientinfo;
        }

        private string GetServiceUrl()
        {
            if (cbRegion.Text == "[Custom]")
            {
                return txtRegionUrl.Text;
            }
            var region = cbRegion.Text == "Default" ? "" : cbRegion.Text.Replace(" ", "").ToLowerInvariant() + ".";
            var url = string.Format(serviceUrl, region);
            return url;
        }

        private string GetLanguage()
        {
            return cbLanguage.Text;
        }

        private void MethodSwitch()
        {
            panClientSecret.Visible = rbSecret.Checked;
            txtClientId.Text = rbSecret.Checked ? clientforsecret.ToString() : clientforuser.ToString();
            CheckInputs();
        }

        private void picClient_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/powershell/powerapps/get-started-powerapps-checker?view=pa-ps-latest#powerapps-checker-authentication-and-authorization");
        }

        private void picRegion_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/checker/webapi/overview#determine-a-geography");
        }

        private void picSecret_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/azure/active-directory/develop/howto-create-service-principal-portal#certificates-and-secrets");
        }

        private void picTenant_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/onedrive/find-your-office-365-tenant-id");
        }

        private void rbMethod_CheckedChanged(object sender, EventArgs e)
        {
            MethodSwitch();
        }

        private void txtClientId_Leave(object sender, EventArgs e)
        {
            if (rbSecret.Checked)
            {
                Guid.TryParse(txtClientId.Text, out clientforsecret);
            }
            else
            {
                Guid.TryParse(txtClientId.Text, out clientforuser);
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            CheckInputs();
        }

        #endregion Private Methods
    }
}
