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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScopeControl));
            this.picRuleHelp = new System.Windows.Forms.PictureBox();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picRuleHelp)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picRuleHelp
            // 
            this.picRuleHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picRuleHelp.Cursor = System.Windows.Forms.Cursors.No;
            this.picRuleHelp.Image = ((System.Drawing.Image)(resources.GetObject("picRuleHelp.Image")));
            this.picRuleHelp.Location = new System.Drawing.Point(376, 295);
            this.picRuleHelp.Name = "picRuleHelp";
            this.picRuleHelp.Size = new System.Drawing.Size(24, 24);
            this.picRuleHelp.TabIndex = 27;
            this.picRuleHelp.TabStop = false;
            this.picRuleHelp.Click += new System.EventHandler(this.picRuleHelp_Click);
            // 
            // rbGroupCategory
            // 
            this.rbGroupCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGroupCategory.AutoSize = true;
            this.rbGroupCategory.Location = new System.Drawing.Point(327, 46);
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
            this.rbGroupSeverity.Location = new System.Drawing.Point(258, 46);
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
            this.chkAllRules.Location = new System.Drawing.Point(15, 47);
            this.chkAllRules.Name = "chkAllRules";
            this.chkAllRules.Size = new System.Drawing.Size(119, 17);
            this.chkAllRules.TabIndex = 20;
            this.chkAllRules.Text = "Check/Uncheck all";
            this.chkAllRules.UseVisualStyleBackColor = true;
            this.chkAllRules.CheckedChanged += new System.EventHandler(this.chkAllRules_CheckedChanged);
            // 
            // lblRules
            // 
            this.lblRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRules.AutoSize = true;
            this.lblRules.Location = new System.Drawing.Point(18, 270);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(87, 13);
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
            this.cbRuleset.Location = new System.Drawing.Point(95, 10);
            this.cbRuleset.Name = "cbRuleset";
            this.cbRuleset.Size = new System.Drawing.Size(304, 21);
            this.cbRuleset.TabIndex = 19;
            this.cbRuleset.SelectedIndexChanged += new System.EventHandler(this.cbRuleset_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Ruleset";
            // 
            // txtRuleDescr
            // 
            this.txtRuleDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuleDescr.BackColor = System.Drawing.SystemColors.Window;
            this.txtRuleDescr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRuleDescr.Location = new System.Drawing.Point(15, 295);
            this.txtRuleDescr.Multiline = true;
            this.txtRuleDescr.Name = "txtRuleDescr";
            this.txtRuleDescr.ReadOnly = true;
            this.txtRuleDescr.Size = new System.Drawing.Size(355, 53);
            this.txtRuleDescr.TabIndex = 24;
            this.txtRuleDescr.Text = "No rule selected";
            // 
            // lvRules
            // 
            this.lvRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRules.CheckBoxes = true;
            this.lvRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvRules.HideSelection = false;
            this.lvRules.Location = new System.Drawing.Point(15, 66);
            this.lvRules.Name = "lvRules";
            this.lvRules.Size = new System.Drawing.Size(384, 201);
            this.lvRules.TabIndex = 23;
            this.lvRules.UseCompatibleStateImageBehavior = false;
            this.lvRules.View = System.Windows.Forms.View.Details;
            this.lvRules.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvRules_ItemChecked);
            this.lvRules.SelectedIndexChanged += new System.EventHandler(this.lvRules_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Rule";
            this.columnHeader1.Width = 377;
            // 
            // txtExclusions
            // 
            this.txtExclusions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExclusions.Location = new System.Drawing.Point(94, 11);
            this.txtExclusions.Name = "txtExclusions";
            this.txtExclusions.Size = new System.Drawing.Size(305, 20);
            this.txtExclusions.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "File Exclusions";
            // 
            // rbScopeRules
            // 
            this.rbScopeRules.AutoSize = true;
            this.rbScopeRules.Location = new System.Drawing.Point(206, 37);
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
            this.rbScopeRuleset.Location = new System.Drawing.Point(94, 37);
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
            this.label9.Location = new System.Drawing.Point(12, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Scope";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.rbScopeRules);
            this.panel1.Controls.Add(this.txtExclusions);
            this.panel1.Controls.Add(this.rbScopeRuleset);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 67);
            this.panel1.TabIndex = 43;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbRuleset);
            this.panel2.Controls.Add(this.picRuleHelp);
            this.panel2.Controls.Add(this.chkAllRules);
            this.panel2.Controls.Add(this.lblRules);
            this.panel2.Controls.Add(this.txtRuleDescr);
            this.panel2.Controls.Add(this.rbGroupCategory);
            this.panel2.Controls.Add(this.rbGroupSeverity);
            this.panel2.Controls.Add(this.lvRules);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 362);
            this.panel2.TabIndex = 44;
            // 
            // ScopeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(409, 429);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.HideOnClose = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 0);
            this.Name = "ScopeControl";
            this.TabText = "Analysis Scope";
            this.Text = "Analysis Scope";
            ((System.ComponentModel.ISupportInitialize)(this.picRuleHelp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRuleHelp;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
