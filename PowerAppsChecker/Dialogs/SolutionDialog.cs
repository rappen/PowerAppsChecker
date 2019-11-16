using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC.Dialogs
{
    public partial class SolutionDialog : Form
    {
        private readonly PAC pac;
        private List<Solution> solutions;

        public SolutionDialog(PAC pac)
        {
            InitializeComponent();
            this.pac = pac;
        }

        public List<Solution> GetSolutions()
        {
            LoadSolutions();
            solutions = new List<Solution>();
            if (ShowDialog(pac) == DialogResult.OK)
            {
                return SelectSolutions();
            }
            return null;
        }

        private void CheckInputs()
        {
            btnOK.Enabled =
                (rbOrg.Checked && cbSolution.SelectedEntity != null) ||
                (rbLocal.Checked && File.Exists(txtFilename.Text));
        }

        private List<Solution> SelectSolutions()
        {
            AddSelectedSolution();
            return solutions;
        }

        private void LoadSolutions()
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
                    CheckInputs();
                }
            });
        }

        private void rbSource_CheckedChanged(object sender, EventArgs e)
        {
            panOrgSolution.Visible = rbOrg.Checked;
            panLocal.Visible = rbLocal.Checked;
            CheckInputs();
        }

        private void btnAddSolution_Click(object sender, EventArgs e)
        {
            AddSelectedSolution();
        }

        private void AddSelectedSolution()
        {
            solutions.Add(new Solution
            {
                UniqueName = rbOrg.Checked ? cbSolution.SelectedEntity["uniquename"].ToString() : null,
                LocalFilePath = rbLocal.Checked ? txtFilename.Text : null
            });
        }

        internal void SettingsApplyToUI(Settings settings)
        {
            txtFilename.Text = settings.SolutionFile;
        }

        internal void SettingsGetFromUI(Settings settings)
        {
            settings.SolutionFile = txtFilename.Text;
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
                }
            }
        }

        private void inputs_Changed(object sender, EventArgs e)
        {
            CheckInputs();
        }
    }
}
