using System;
using System.Linq;
using System.Windows.Forms;
using Rappen.XTB.PAC.Helpers;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.PAC.DockControls
{
    public partial class ScopeControl : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region Private Fields

        private readonly PAC pac;

        #endregion Private Fields

        #region Internal Fields

        internal Size originalSize;
        internal List<Rule> Rules => lvRules.Items.Cast<ListViewItem>().Select(i => RuleFromListItem(i)).Where(r => r != null).ToList();

        #endregion Internal Fields

        #region Public Constructors

        public ScopeControl(PAC pac)
        {
            this.pac = pac;
            InitializeComponent();
            originalSize = Size;
        }

        #endregion Public Constructors

        #region Internal Methods

        internal void Enable(bool enable)
        {
            Enabled = enable;
            cbRuleset.Enabled = enable && cbRuleset.Items.Count > 0;
        }

        internal bool EnableAnalysis()
        {
            return (rbScopeRules.Checked && lvRules.CheckedItems.Count > 0) || (rbScopeRuleset.Checked && cbRuleset.SelectedItem is RuleSet);
        }

        internal AnalysisArgs GetAnalysisScopeArgs()
        {
            var args = new AnalysisArgs
            {
                RuleSets = new List<RuleSet>(),
                Rules = new List<Rule>(),
                FileExclusions = txtExclusions.Text.Split(',').Select(e => e.Trim()).Where(e => !string.IsNullOrEmpty(e)).ToList()
            };
            if (rbScopeRuleset.Checked && cbRuleset.SelectedItem is RuleSet ruleset)
            {
                args.RuleSets.Add(ruleset);
            }
            else if (rbScopeRules.Checked)
            {
                foreach (ListViewItem item in lvRules.CheckedItems)
                {
                    if (item.Tag is Rule rule)
                    {
                        args.Rules.Add(rule);
                    }
                }
            }
            return args;
        }

        internal void LoadRuleSets()
        {
            pac.Enable(false);
            var enabled = true;
            pac.WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading rulesets",
                Work = (worker, args) =>
                {
                    args.Result = PACHelper.GetRuleSets(pac.PACServiceUrl);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        pac.ShowError(args.Error);
                    }
                    else if (args.Result is RuleSet[] rulesetlist)
                    {
                        AddRuleSets(rulesetlist);
                        LoadRules();
                        enabled = false;
                    }
                    pac.Enable(enabled);
                }
            });
        }

        internal void SetSolutions(List<Solution> solutions)
        {
            txtSolutions.Text = string.Join(", ", solutions.Select(s => s.ToString()));
        }

        #endregion Internal Methods

        #region Private Methods

        private bool AddRules(Rule[] rules)
        {
            lvRules.Items.Clear();
            lvRules.Items.AddRange(rules.Select(r => RuleToListItem(r)).ToArray());
            return UpdateRuleSelections();
        }

        private void AddRuleSets(RuleSet[] rulesets)
        {
            cbRuleset.Items.Clear();
            cbRuleset.Items.Add("");
            cbRuleset.Items.AddRange(rulesets);
        }

        private void cbRuleset_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRuleSelections();
        }

        private void chkAllRules_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvRules.Items)
            {
                item.Checked = chkAllRules.Checked;
            }
        }

        private void LoadRules()
        {
            pac.Enable(false);
            var enabled = true;
            pac.WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading rules",
                Work = (worker, args) =>
                {
                    args.Result = PACHelper.GetRules(pac.PACServiceUrl);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        pac.ShowError(args.Error);
                    }
                    else if (args.Result is Rule[] rulelist)
                    {
                        if (AddRules(rulelist))
                        {
                            enabled = false;
                        }
                    }
                    pac.Enable(enabled);
                    SetRuleDetails();
                }
            });
        }

        private void LoadRuleSetSelections(RuleSet ruleset)
        {
            if (ruleset == null)
            {
                return;
            }
            pac.Enable(false);
            pac.WorkAsync(new WorkAsyncInfo()
            {
                Message = $"Loading rules for {ruleset.Name}",
                Work = (worker, args) =>
                {
                    args.Result = PACHelper.GetRules(pac.PACServiceUrl, ruleset.Id);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        pac.ShowError(args.Error);
                    }
                    else if (args.Result is Helpers.Rule[] rulelist)
                    {
                        var rules = lvRules.Items.Cast<ListViewItem>();
                        foreach (ListViewItem item in rules)
                        {
                            item.Checked = false;
                        }
                        foreach (var rule in rulelist)
                        {
                            var item = rules.FirstOrDefault(i => i.Tag is Helpers.Rule && ((Helpers.Rule)i.Tag).Code == rule.Code);
                            if (item != null)
                            {
                                item.Checked = true;
                            }
                        }
                    }
                    pac.Enable(true);
                }
            });
        }

        private void lvRules_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateRuleCounts();
        }

        private void lvRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRuleDetails();
        }

        private void SetRuleDetails()
        {
            lblCatSev.Text = rbGroupSeverity.Checked ? "Category" : "Severity";
            if (lvRules.SelectedItems.Count > 0 && lvRules.SelectedItems[0].Tag is Helpers.Rule rule)
            {
                linkRuleId.Text = rule.Code;
                //linkRuleId.LinkArea = new LinkArea(rule.Code.Length + 1, 9);
                lblCatSevValue.Text = rbGroupSeverity.Checked ? rule.PrimaryCategory.ToString() : rule.Severity.ToString();
                txtRuleDescr.Text = rule.Summary;
            }
            else
            {
                linkRuleId.Text = "";
                lblCatSevValue.Text = "";
                txtRuleDescr.Text = "";
            }
            pac.Enable(true);
        }

        private void rbGroupBy_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                var rules = Rules;
                lvRules.Items.Clear();
                lvRules.Items.AddRange(rules.Select(r => RuleToListItem(r)).ToArray());
            }
        }

        private void rbScope_CheckedChanged(object sender, EventArgs e)
        {
            pac.Enable(true);
        }

        private ListViewItem RuleToListItem(Rule rule)
        {
            var groupby = (rbGroupCategory.Checked ? $"Category: {rule.PrimaryCategory}" : $"Severity: {rule.Severity}");
            var group = lvRules.Groups.Cast<ListViewGroup>().FirstOrDefault(g => g.Header == groupby);
            if (group == null)
            {
                group = lvRules.Groups.Add(groupby, groupby);
                group.HeaderAlignment = HorizontalAlignment.Center;
            }
            var item = new ListViewItem(rule.ToString())
            {
                Tag = rule,
                Checked = rule.Include,
                Group = group
            };
            return item;
        }
        
        private static Rule RuleFromListItem(ListViewItem item)
        {
            if (item.Tag is Rule rule)
            {
                rule.Include = item.Checked;
                return rule;
            }
            return null;
        }

        private void UpdateRuleCounts()
        {
            lblRules.Text = $"{lvRules.CheckedItems.Count}  selected of {lvRules.Items.Count} rules.";
        }

        private bool UpdateRuleSelections()
        {
            if (cbRuleset.SelectedItem == null)
            {
                return false;
            }
            LoadRuleSetSelections(cbRuleset.SelectedItem as RuleSet);
            return true;
        }

        #endregion Private Methods

        private void linkExclusions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/checker/webapi/analyze#body");
        }

        private void linkRuleId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvRules.SelectedItems.Count > 0 && lvRules.SelectedItems[0].Tag is Rule rule)
            {
                Process.Start(rule.GuidanceUrl.Replace("client=PAChecker", "client=Rappen.XTB.PAC"));
            }
        }
    }
}
