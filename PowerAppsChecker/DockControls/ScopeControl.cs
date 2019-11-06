using System;
using System.Linq;
using System.Windows.Forms;
using Rappen.XTB.PAC.Helpers;
using System.Diagnostics;
using System.Collections.Generic;

namespace Rappen.XTB.PAC.DockControls
{
    public partial class ScopeControl : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region Private Fields

        private readonly PAC pac;

        #endregion Private Fields

        #region Public Constructors

        public ScopeControl(PAC pac)
        {
            this.pac = pac;
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Internal Methods

        internal bool AddRules(Rule[] rules)
        {
            lvRules.Items.Clear();
            lvRules.Items.AddRange(rules.Select(r => RuleToListItem(r)).ToArray());
            return UpdateRuleSelections();
        }

        internal void AddRuleSets(RuleSet[] rulesets)
        {
            cbRuleset.Items.Clear();
            cbRuleset.Items.Add("");
            cbRuleset.Items.AddRange(rulesets);
        }

        internal void Enable(bool enable)
        {
            Enabled = enable;
            cbRuleset.Enabled = enable && cbRuleset.Items.Count > 0;
            picRuleHelp.Enabled = enable && lvRules.SelectedItems.Count > 0;
            picRuleHelp.Cursor = picRuleHelp.Enabled ? Cursors.Hand : Cursors.No;
        }

        internal bool EnableAnalysis()
        {
            return (rbScopeRules.Checked && lvRules.CheckedItems.Count > 0) || (rbScopeRuleset.Checked && cbRuleset.SelectedItem is RuleSet);
        }

        internal AnalysisArgs GetAnalysisArgs(Guid corrid, string fileurl)
        {
            var args = new AnalysisArgs
            {
                CorrId = corrid,
                FileUrl = fileurl,
                RuleSets = new List<RuleSet>(),
                Rules = new List<Rule>(),
                Exclusions = txtExclusions.Text.Split(',').Select(e => e.Trim()).Where(e => !string.IsNullOrEmpty(e)).ToList()
            };
            if (rbScopeRuleset.Checked && cbRuleset.SelectedItem is RuleSet ruleset)
            {
                args.RuleSets.Add(ruleset);
            }
            else if (rbScopeRules.Checked)
            {
                foreach (ListViewItem item in lvRules.CheckedItems)
                {
                    if (item.Tag is Helpers.Rule rule)
                    {
                        args.Rules.Add(rule);
                    }
                }
            }
            return args;
        }

        #endregion Internal Methods

        #region Private Methods

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

        private void lvRules_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateRuleCounts();
        }

        private void lvRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRules.SelectedItems.Count > 0 && lvRules.SelectedItems[0].Tag is Helpers.Rule rule)
            {
                txtRuleDescr.Text = rule.Summary;
            }
            else
            {
                txtRuleDescr.Text = "";
            }
            pac.Enable(true);
        }

        private void picRuleHelp_Click(object sender, EventArgs e)
        {
            if (lvRules.SelectedItems.Count > 0 && lvRules.SelectedItems[0].Tag is Helpers.Rule rule)
            {
                Process.Start(rule.GuidanceUrl.Replace("client=PAChecker", "client=Rappen.XTB.PAC"));
            }
        }

        private void rbGroupBy_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                pac.LoadRules();
            }
        }

        private void rbScope_CheckedChanged(object sender, EventArgs e)
        {
            pac.Enable(true);
        }

        private ListViewItem RuleToListItem(Helpers.Rule rule)
        {
            var groupby = (rbGroupCategory.Checked ? $"Category: {rule.PrimaryCategory}" : $"Severity: {rule.Severity}");
            var groups = new ListViewGroup[lvRules.Groups.Count];
            lvRules.Groups.CopyTo(groups, 0);
            var group = groups.FirstOrDefault(g => g.Header == groupby);
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
            ListViewItem[] items = new ListViewItem[lvRules.Items.Count];
            lvRules.Items.CopyTo(items, 0);
            pac.LoadRuleSetSelections(cbRuleset.SelectedItem as RuleSet, items.ToList());
            return true;
        }

        #endregion Private Methods
    }
}
