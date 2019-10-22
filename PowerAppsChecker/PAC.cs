using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Rappen.XTB.PAC.Helpers;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC
{
    public partial class PAC : PluginControlBase
    {
        private HttpClient client;

        public PAC()
        {
            InitializeComponent();
        }

        private void PAC_Load(object sender, EventArgs e)
        {
            txtTenant_TextChanged(null, null);
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            cbSolutions.Service = newService;
            Enable(true);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectPAChecker();
        }

        private void btnLoadRulesets_Click(object sender, EventArgs e)
        {
            LoadRuleSets();
        }

        private void btnLoadRules_Click(object sender, EventArgs e)
        {
            LoadRules(cbRuleset.SelectedItem as PACRuleSet);
        }

        private void cbRuleset_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enable(true);
            LoadRules(cbRuleset.SelectedItem as PACRuleSet);
        }

        private void cdSolutions_SelectedItemChanged(object sender, EventArgs e)
        {
            Enable(true);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export(cbSolutions.SelectedSolution);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            Upload();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            Analyze(txtBlobUrl.Text);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var od = new OpenFileDialog
            {
                InitialDirectory = Paths.LogsPath
            };
            if (od.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = od.FileName;
            }
            Enable(true);
        }

        private void lvRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRules.SelectedItems.Count > 0 && lvRules.SelectedItems[0].Tag is PACRule rule)
            {
                txtRuleDescr.Text = rule.Description;
            }
            else
            {
                txtRuleDescr.Text = "";
            }
        }

        private void txtTenant_TextChanged(object sender, EventArgs e)
        {
            if (Guid.TryParse(txtTenantId.Text, out Guid t) && Guid.TryParse(txtClientId.Text, out Guid c) && !string.IsNullOrWhiteSpace(txtClientSec.Text))
            {
                ConnectPAChecker();
            }
        }

        private void Enable(bool enable)
        {
            Enabled = enable;
            btnLoadRulesets.Enabled = enable && client != null;
            cbRuleset.Enabled = enable && client != null && cbRuleset.Items.Count > 0;
            btnLoadRules.Enabled = enable && cbRuleset.Enabled && cbRuleset.SelectedItem is PACRuleSet;
            cbSolutions.Enabled = enable && Service != null;
            btnExport.Enabled = enable && cbSolutions.SelectedSolution is Entity solution
                    && (solution["ismanaged"] as bool? == false);
            btnUpload.Enabled = enable && client != null && File.Exists(txtFilename.Text);
            btnAnalyze.Enabled = enable && client != null && !string.IsNullOrEmpty(txtBlobUrl.Text);
        }

        private void ConnectPAChecker()
        {
            Enable(false);
            if (!Guid.TryParse(txtTenantId.Text, out var tenantId))
            {
                MessageBox.Show("Bad Tenant Guid");
                return;
            }
            if (!Guid.TryParse(txtClientId.Text, out var clientId))
            {
                MessageBox.Show("Bad Client Guid");
                return;
            }
            var clientSec = txtClientSec.Text;

            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Connecting PAC",
                Work = (worker, args) =>
                {
                    args.Result = PACHelper.GetClient(tenantId, clientId, clientSec);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is HttpClient pacclient)
                    {
                        client = pacclient;
                        LoadRuleSets();
                    }
                    Enable(true);
                }
            });
        }

        private void LoadRuleSets()
        {
            Enable(false);
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading rulesets",
                Work = (worker, args) =>
                {
                    var rulesets = client.Get("ruleset");
                    var jss = new JavaScriptSerializer();
                    args.Result = jss.Deserialize<PACRuleSet[]>(rulesets);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is PACRuleSet[] rulesetlist)
                    {
                        cbRuleset.Items.AddRange(rulesetlist);
                    }
                    Enable(true);
                }
            });
        }

        private void LoadRules(PACRuleSet ruleset)
        {
            Enable(false);
            lvRules.Items.Clear();
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading rules",
                Work = (worker, args) =>
                {
                    var rules = client.Get($"rule?ruleset={ruleset.Id}");
                    var jss = new JavaScriptSerializer();
                    args.Result = jss.Deserialize<PACRule[]>(rules);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is PACRule[] rulelist)
                    {
                        lvRules.Items.AddRange(rulelist.Select(r => RuleToListItem(r)).ToArray());
                    }
                    Enable(true);
                }
            });
        }

        private static ListViewItem RuleToListItem(PACRule rule)
        {
            var item = new ListViewItem(rule.Code)
            {
                Tag = rule,
                Checked = rule.Include
            };
            return item;
        }

        private void Export(Entity solution)
        {
            Enable(false);
            var solname = solution["uniquename"].ToString();
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
                        var filename = Path.Combine(Paths.LogsPath, solname + ".zip");
                        File.WriteAllBytes(filename, exportXml);
                        txtFilename.Text = filename;
                    }
                    Enable(true);
                }
            });
        }

        private void Upload()
        {
            Enable(false);
            var corrid = Guid.NewGuid();
            txtCorrId.Text = corrid.ToString();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Uploading",
                AsyncArgument = corrid,
                Work = (worker, args) =>
                {
                    args.Result = client.Upload(corrid, txtFilename.Text);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is string bloburl)
                    {
                        txtBlobUrl.Text = bloburl;
                    }
                    Enable(true);
                }
            });
        }

        private void Analyze(string blobfile)
        {
            Enable(false);
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initiating analysis",
                Work = (worker, args) =>
                {
                    //                    args.Result = client.Upload(corrid, txtFilename.Text);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else if (args.Result is string bloburl)
                    {
                        //                        txtBlobUrl.Text = bloburl;
                    }
                    Enable(true);
                }
            });
        }
    }
}