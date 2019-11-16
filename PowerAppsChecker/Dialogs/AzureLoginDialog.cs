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
        #region Public Constructors

        public AzureLoginDialog()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public Tuple<HttpClient, string> GetPACClient(PAC pac)
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
            if (!settings.TenantId.Equals(Guid.Empty)) txtTenantId.Text = settings.TenantId.ToString();
            if (!settings.ClientId.Equals(Guid.Empty)) txtClientId.Text = settings.ClientId.ToString();
            if (!string.IsNullOrEmpty(settings.ClientSecret)) txtClientSec.Text = settings.ClientSecret;
            if (!string.IsNullOrEmpty(settings.Region)) cbRegion.SelectedIndex = cbRegion.Items.IndexOf(settings.Region);
            CheckInputs();
        }

        internal void SettingsGetFromUI(Settings settings)
        {
            settings.AuthMethod = rbSecret.Checked ? AuthMethod.Secret : AuthMethod.User;
            if (Guid.TryParse(txtTenantId.Text, out Guid tid))
            {
                settings.TenantId = tid;
            }
            if (Guid.TryParse(txtClientId.Text, out Guid cid))
            {
                settings.ClientId = cid;
            }
            settings.ClientSecret = txtClientSec.Text;
            settings.Region = cbRegion.Text;
        }

        #endregion Internal Methods

        #region Private Methods

        private void cbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckInputs();
        }

        private void CheckInputs()
        {
            btnConnectPAC.Enabled =
                Guid.TryParse(txtClientId.Text, out var clientId) &&
                cbRegion.SelectedItem != null &&
                (rbUser.Checked || (Guid.TryParse(txtTenantId.Text, out var tenantId) && !string.IsNullOrEmpty(txtClientSec.Text)));
        }

        private Tuple<HttpClient, string> ConnectPAChecker(bool silent = false)
        {
            if (silent && !(Guid.TryParse(txtTenantId.Text, out Guid t) && Guid.TryParse(txtClientId.Text, out Guid c) && !string.IsNullOrWhiteSpace(txtClientSec.Text)))
            {
                return null;
            }
            if (!Guid.TryParse(txtClientId.Text, out var clientId))
            {
                MessageBox.Show("Bad Client Guid");
                return null;
            }
            if (cbRegion.SelectedItem == null)
            {
                MessageBox.Show("Select Region");
                return null;
            }
            var region = cbRegion.Text == "Default" ? "" : cbRegion.Text.Replace(" ", "").ToLowerInvariant() + ".";
            try
            {
                if (rbSecret.Checked)
                {
                    if (!Guid.TryParse(txtTenantId.Text, out var tenantId))
                    {
                        MessageBox.Show("Bad Tenant Guid");
                        return null;
                    }
                    var clientSec = txtClientSec.Text;
                    return new Tuple<HttpClient, string>(PACHelper.GetClient(region, tenantId, clientId, clientSec), region);
                }
                else
                {
                    return new Tuple<HttpClient, string>(PACHelper.GetClient(region, clientId), region);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
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
            panClientSecret.Visible = rbSecret.Checked;
            CheckInputs();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            CheckInputs();
        }

        #endregion Private Methods
    }
}
