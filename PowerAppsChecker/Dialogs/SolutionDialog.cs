using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using xrmtb.XrmToolBox.Controls.Controls;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC.Dialogs
{
    public partial class SolutionDialog : Form
    {

        #region Private Fields

        private readonly PAC pac;
        private List<Solution> solutions;

        #endregion Private Fields

        #region Public Constructors

        public SolutionDialog(PAC pac)
        {
            InitializeComponent();
            this.pac = pac;
        }

        #endregion Public Constructors

        #region Public Methods

        public List<Solution> GetSolutions()
        {
            solutions = new List<Solution>();
            if (ShowDialog(pac) == DialogResult.OK)
            {
                return SelectSolutions();
            }
            return null;
        }

        #endregion Public Methods

        #region Internal Methods

        internal void LoadSolutions(Settings settings)
        {
            cbSolution.DataSource = null;
            if (pac.Service == null)
            {
                return;
            }
            cbSolution.OrganizationService = pac.Service;
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
                    SettingsApplyToUI(settings);
                    CheckInputs();
                }
            });
        }

        internal void SettingsApplyToUI(Settings settings)
        {
            if (!string.IsNullOrEmpty(settings.SolutionName))
            {
                foreach (var solution in cbSolution.Items)
                {
                    if (solution is CDSComboBoxItem solitem)
                    {
                        if (solitem.Entity["uniquename"].ToString() == settings.SolutionName)
                        {
                            cbSolution.SelectedItem = solution;
                        }
                    }
                }
            }
            txtFilename.Text = settings.SolutionFile;
        }

        internal void SettingsGetFromUI(Settings settings)
        {
            settings.SolutionName = cbSolution.SelectedEntity != null ? cbSolution.SelectedEntity["uniquename"].ToString() : null;
            settings.SolutionFile = txtFilename.Text;
        }

        #endregion Internal Methods

        #region Private Methods

        private void AddSelectedSolution()
        {
            solutions.Add(new Solution
            {
                UniqueName = rbOrg.Checked ? cbSolution.SelectedEntity["uniquename"].ToString() : null,
                Version = rbOrg.Checked ? new Version(cbSolution.SelectedEntity["version"].ToString()) : null,
                LocalFilePath = rbLocal.Checked ? txtFilename.Text : null
            });
        }

        private void btnAddSolution_Click(object sender, EventArgs e)
        {
            AddSelectedSolution();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (var od = new OpenFileDialog
            {
                CheckPathExists = true,
                DefaultExt = "zip",
                Filter = "ZIP files|*.zip|All files|*.*",
                Title = "Select Solution file"
            })
            {
                if (od.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = od.FileName;
                }
            }
        }

        private void CheckInputs()
        {
            rbOrg.Enabled = pac.Service != null;
            if (!rbOrg.Enabled)
            {
                rbLocal.Checked = true;
            }
            btnOK.Enabled =
                (rbOrg.Checked && cbSolution.SelectedEntity != null) ||
                (rbLocal.Checked && File.Exists(txtFilename.Text));
        }

        private void inputs_Changed(object sender, EventArgs e)
        {
            CheckInputs();
        }

        private void rbSource_CheckedChanged(object sender, EventArgs e)
        {
            panOrgSolution.Visible = rbOrg.Checked;
            panLocal.Visible = rbLocal.Checked;
            CheckInputs();
        }

        private List<Solution> SelectSolutions()
        {
            AddSelectedSolution();
            return solutions;
        }

        #endregion Private Methods

    }
}
