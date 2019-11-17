namespace Rappen.XTB.PAC.DockControls
{
    partial class ScopeControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbGroupCategory = new System.Windows.Forms.RadioButton();
            this.rbGroupSeverity = new System.Windows.Forms.RadioButton();
            this.chkAllRules = new System.Windows.Forms.CheckBox();
            this.lblRules = new System.Windows.Forms.Label();
            this.cbRuleset = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRuleDescr = new System.Windows.Forms.TextBox();
            this.lvRules = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtExclusions = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rbScopeRules = new System.Windows.Forms.RadioButton();
            this.rbScopeRuleset = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.panTop = new System.Windows.Forms.Panel();
            this.linkExclusions = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSolutions = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkRuleId = new System.Windows.Forms.LinkLabel();
            this.lblCatSev = new System.Windows.Forms.Label();
            this.lblCatSevValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbGroupCategory
            // 
            this.rbGroupCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGroupCategory.AutoSize = true;
            this.rbGroupCategory.Location = new System.Drawing.Point(279, 59);
            this.rbGroupCategory.Name = "rbGroupCategory";
            this.rbGroupCategory.Size = new System.Drawing.Size(67, 17);
            this.rbGroupCategory.TabIndex = 22;
            this.rbGroupCategory.Text = "Category";
            this.rbGroupCategory.UseVisualStyleBackColor = true;
            this.rbGroupCategory.CheckedChanged += new System.EventHandler(this.rbGroupBy_CheckedChanged);
            // 
            // rbGroupSeverity
            // 
            this.rbGroupSeverity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGroupSeverity.AutoSize = true;
            this.rbGroupSeverity.Checked = true;
            this.rbGroupSeverity.Location = new System.Drawing.Point(210, 59);
            this.rbGroupSeverity.Name = "rbGroupSeverity";
            this.rbGroupSeverity.Size = new System.Drawing.Size(63, 17);
            this.rbGroupSeverity.TabIndex = 21;
            this.rbGroupSeverity.TabStop = true;
            this.rbGroupSeverity.Text = "Severity";
            this.rbGroupSeverity.UseVisualStyleBackColor = true;
            this.rbGroupSeverity.CheckedChanged += new System.EventHandler(this.rbGroupBy_CheckedChanged);
            // 
            // chkAllRules
            // 
            this.chkAllRules.AutoSize = true;
            this.chkAllRules.Location = new System.Drawing.Point(3, 60);
            this.chkAllRules.Name = "chkAllRules";
            this.chkAllRules.Size = new System.Drawing.Size(119, 17);
            this.chkAllRules.TabIndex = 20;
            this.chkAllRules.Text = "Check/Uncheck all";
            this.chkAllRules.UseVisualStyleBackColor = true;
            this.chkAllRules.CheckedChanged += new System.EventHandler(this.chkAllRules_CheckedChanged);
            // 
            // lblRules
            // 
            this.lblRules.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRules.Location = new System.Drawing.Point(0, 340);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(356, 20);
            this.lblRules.TabIndex = 26;
            this.lblRules.Text = "Rules not loaded";
            // 
            // cbRuleset
            // 
            this.cbRuleset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRuleset.BackColor = System.Drawing.SystemColors.Window;
            this.cbRuleset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRuleset.Enabled = false;
            this.cbRuleset.FormattingEnabled = true;
            this.cbRuleset.Location = new System.Drawing.Point(94, 29);
            this.cbRuleset.Name = "cbRuleset";
            this.cbRuleset.Size = new System.Drawing.Size(262, 21);
            this.cbRuleset.TabIndex = 19;
            this.cbRuleset.SelectedIndexChanged += new System.EventHandler(this.cbRuleset_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Ruleset";
            // 
            // txtRuleDescr
            // 
            this.txtRuleDescr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuleDescr.BackColor = System.Drawing.SystemColors.Window;
            this.txtRuleDescr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRuleDescr.Location = new System.Drawing.Point(94, 35);
            this.txtRuleDescr.Multiline = true;
            this.txtRuleDescr.Name = "txtRuleDescr";
            this.txtRuleDescr.ReadOnly = true;
            this.txtRuleDescr.Size = new System.Drawing.Size(258, 46);
            this.txtRuleDescr.TabIndex = 24;
            this.txtRuleDescr.Text = "-";
            // 
            // lvRules
            // 
            this.lvRules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvRules.CheckBoxes = true;
            this.lvRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRules.HideSelection = false;
            this.lvRules.Location = new System.Drawing.Point(0, 0);
            this.lvRules.Name = "lvRules";
            this.lvRules.Size = new System.Drawing.Size(356, 340);
            this.lvRules.TabIndex = 23;
            this.lvRules.UseCompatibleStateImageBehavior = false;
            this.lvRules.View = System.Windows.Forms.View.Details;
            this.lvRules.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvRules_ItemChecked);
            this.lvRules.SelectedIndexChanged += new System.EventHandler(this.lvRules_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Rule";
            this.columnHeader1.Width = 350;
            // 
            // txtExclusions
            // 
            this.txtExclusions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExclusions.Location = new System.Drawing.Point(94, 38);
            this.txtExclusions.Name = "txtExclusions";
            this.txtExclusions.Size = new System.Drawing.Size(262, 20);
            this.txtExclusions.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(0, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "File Exclusions";
            // 
            // rbScopeRules
            // 
            this.rbScopeRules.AutoSize = true;
            this.rbScopeRules.Location = new System.Drawing.Point(206, 6);
            this.rbScopeRules.Name = "rbScopeRules";
            this.rbScopeRules.Size = new System.Drawing.Size(97, 17);
            this.rbScopeRules.TabIndex = 41;
            this.rbScopeRules.Text = "Selected Rules";
            this.rbScopeRules.UseVisualStyleBackColor = true;
            this.rbScopeRules.CheckedChanged += new System.EventHandler(this.rbScope_CheckedChanged);
            // 
            // rbScopeRuleset
            // 
            this.rbScopeRuleset.AutoSize = true;
            this.rbScopeRuleset.Checked = true;
            this.rbScopeRuleset.Location = new System.Drawing.Point(94, 6);
            this.rbScopeRuleset.Name = "rbScopeRuleset";
            this.rbScopeRuleset.Size = new System.Drawing.Size(106, 17);
            this.rbScopeRuleset.TabIndex = 40;
            this.rbScopeRuleset.TabStop = true;
            this.rbScopeRuleset.Text = "Selected Ruleset";
            this.rbScopeRuleset.UseVisualStyleBackColor = true;
            this.rbScopeRuleset.CheckedChanged += new System.EventHandler(this.rbScope_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Validate";
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.linkExclusions);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Controls.Add(this.txtSolutions);
            this.panTop.Controls.Add(this.label14);
            this.panTop.Controls.Add(this.txtExclusions);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(10, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(356, 83);
            this.panTop.TabIndex = 43;
            // 
            // linkExclusions
            // 
            this.linkExclusions.AutoSize = true;
            this.linkExclusions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkExclusions.LinkArea = new System.Windows.Forms.LinkArea(39, 9);
            this.linkExclusions.Location = new System.Drawing.Point(91, 59);
            this.linkExclusions.Name = "linkExclusions";
            this.linkExclusions.Size = new System.Drawing.Size(253, 17);
            this.linkExclusions.TabIndex = 43;
            this.linkExclusions.TabStop = true;
            this.linkExclusions.Text = "Comma separated list of file patterns. Read more.";
            this.linkExclusions.UseCompatibleTextRendering = true;
            this.linkExclusions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkExclusions_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Solution(s)";
            // 
            // txtSolutions
            // 
            this.txtSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSolutions.BackColor = System.Drawing.SystemColors.Window;
            this.txtSolutions.Location = new System.Drawing.Point(94, 12);
            this.txtSolutions.Name = "txtSolutions";
            this.txtSolutions.ReadOnly = true;
            this.txtSolutions.Size = new System.Drawing.Size(262, 20);
            this.txtSolutions.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.rbScopeRules);
            this.panel2.Controls.Add(this.cbRuleset);
            this.panel2.Controls.Add(this.rbScopeRuleset);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.chkAllRules);
            this.panel2.Controls.Add(this.rbGroupCategory);
            this.panel2.Controls.Add(this.rbGroupSeverity);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 81);
            this.panel2.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Rule Id";
            // 
            // linkRuleId
            // 
            this.linkRuleId.AutoSize = true;
            this.linkRuleId.LinkArea = new System.Windows.Forms.LinkArea(0, 100);
            this.linkRuleId.Location = new System.Drawing.Point(92, 1);
            this.linkRuleId.Name = "linkRuleId";
            this.linkRuleId.Size = new System.Drawing.Size(8, 17);
            this.linkRuleId.TabIndex = 44;
            this.linkRuleId.TabStop = true;
            this.linkRuleId.Text = "-";
            this.linkRuleId.UseCompatibleTextRendering = true;
            this.linkRuleId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRuleId_LinkClicked);
            // 
            // lblCatSev
            // 
            this.lblCatSev.AutoSize = true;
            this.lblCatSev.Location = new System.Drawing.Point(0, 18);
            this.lblCatSev.Name = "lblCatSev";
            this.lblCatSev.Size = new System.Drawing.Size(49, 13);
            this.lblCatSev.TabIndex = 45;
            this.lblCatSev.Text = "Category";
            // 
            // lblCatSevValue
            // 
            this.lblCatSevValue.AutoSize = true;
            this.lblCatSevValue.Location = new System.Drawing.Point(91, 18);
            this.lblCatSevValue.Name = "lblCatSevValue";
            this.lblCatSevValue.Size = new System.Drawing.Size(10, 13);
            this.lblCatSevValue.TabIndex = 46;
            this.lblCatSevValue.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Description";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(10, 164);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvRules);
            this.splitContainer1.Panel1.Controls.Add(this.lblRules);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lblCatSevValue);
            this.splitContainer1.Panel2.Controls.Add(this.txtRuleDescr);
            this.splitContainer1.Panel2.Controls.Add(this.lblCatSev);
            this.splitContainer1.Panel2.Controls.Add(this.linkRuleId);
            this.splitContainer1.Size = new System.Drawing.Size(356, 450);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 46;
            // 
            // ScopeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(376, 624);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panTop);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.HideOnClose = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 39);
            this.Name = "ScopeControl";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.TabText = "Analysis Scope";
            this.Text = "Analysis Scope";
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbGroupCategory;
        private System.Windows.Forms.RadioButton rbGroupSeverity;
        private System.Windows.Forms.CheckBox chkAllRules;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.ComboBox cbRuleset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRuleDescr;
        private System.Windows.Forms.ListView lvRules;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rbScopeRules;
        private System.Windows.Forms.RadioButton rbScopeRuleset;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtExclusions;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtSolutions;
        private System.Windows.Forms.LinkLabel linkExclusions;
        private System.Windows.Forms.LinkLabel linkRuleId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCatSevValue;
        private System.Windows.Forms.Label lblCatSev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
