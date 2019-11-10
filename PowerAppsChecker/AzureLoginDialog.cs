using Rappen.XTB.PAC.Helpers;
using System;
using System.Net.Http;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC
{
    public partial class AzureLoginDialog : Form
    {
        #region Public Constructors

        public AzureLoginDialog(PAC pac)
        {
            InitializeComponent();
            btnConnectPAC.Enabled = Guid.TryParse(txtTenantId.Text, out Guid t) && Guid.TryParse(txtClientId.Text, out Guid c) && !string.IsNullOrWhiteSpace(txtClientSec.Text);
        }

        #endregion Public Constructors

        #region Public Methods

        public HttpClient GetPACClient(PAC pac)
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
            if (!settings.TenantId.Equals(Guid.Empty)) txtTenantId.Text = settings.TenantId.ToString();
            if (!settings.ClientId.Equals(Guid.Empty)) txtClientId.Text = settings.ClientId.ToString();
            if (!string.IsNullOrEmpty(settings.ClientSecret)) txtClientSec.Text = settings.ClientSecret;
        }

        internal void SettingsGetFromUI(Settings settings)
        {
            if (Guid.TryParse(txtTenantId.Text, out Guid tid))
            {
                settings.TenantId = tid;
            }
            if (Guid.TryParse(txtClientId.Text, out Guid cid))
            {
                settings.ClientId = cid;
            }
            settings.ClientSecret = txtClientSec.Text;
        }

        #endregion Internal Methods

        #region Private Methods

        private HttpClient ConnectPAChecker(bool silent = false)
        {
            if (silent && !(Guid.TryParse(txtTenantId.Text, out Guid t) && Guid.TryParse(txtClientId.Text, out Guid c) && !string.IsNullOrWhiteSpace(txtClientSec.Text)))
            {
                return null;
            }
            if (!Guid.TryParse(txtTenantId.Text, out var tenantId))
            {
                MessageBox.Show("Bad Tenant Guid");
                return null;
            }
            if (!Guid.TryParse(txtClientId.Text, out var clientId))
            {
                MessageBox.Show("Bad Client Guid");
                return null;
            }
            var clientSec = txtClientSec.Text;
            return PACHelper.GetClient(tenantId, clientId, clientSec);
        }

        #endregion Private Methods
    }
}
