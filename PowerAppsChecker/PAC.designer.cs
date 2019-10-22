namespace Rappen.XTB.PAC
{
    partial class PAC
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAC));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenantId = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientSec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRuleset = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConnectPAC = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCorrId = new System.Windows.Forms.TextBox();
            this.cbSolutions = new xrmtb.XrmToolBox.Controls.SolutionsDropdownControl();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.gbRules = new System.Windows.Forms.GroupBox();
            this.rbGroupCategory = new System.Windows.Forms.RadioButton();
            this.rbGroupSeverity = new System.Windows.Forms.RadioButton();
            this.chkAllRules = new System.Windows.Forms.CheckBox();
            this.lblRules = new System.Windows.Forms.Label();
            this.txtRuleDescr = new System.Windows.Forms.TextBox();
            this.lvRules = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbSolution = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.linkBlob = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAnalysis = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.gbRules.SuspendLayout();
            this.gbSolution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tenant Id";
            // 
            // txtTenantId
            // 
            this.txtTenantId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenantId.Location = new System.Drawing.Point(95, 26);
            this.txtTenantId.Name = "txtTenantId";
            this.txtTenantId.Size = new System.Drawing.Size(327, 20);
            this.txtTenantId.TabIndex = 6;
            this.txtTenantId.Text = "03ef9e5e-caa4-41ad-b7a5-d657624eb692";
            this.txtTenantId.TextChanged += new System.EventHandler(this.txtTenant_TextChanged);
            // 
            // txtClientId
            // 
            this.txtClientId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientId.Location = new System.Drawing.Point(95, 53);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(327, 20);
            this.txtClientId.TabIndex = 7;
            this.txtClientId.Text = "774beb47-454d-450c-980e-07bad5477469";
            this.txtClientId.TextChanged += new System.EventHandler(this.txtTenant_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Client Id";
            // 
            // txtClientSec
            // 
            this.txtClientSec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientSec.Location = new System.Drawing.Point(95, 79);
            this.txtClientSec.Name = "txtClientSec";
            this.txtClientSec.PasswordChar = '*';
            this.txtClientSec.Size = new System.Drawing.Size(327, 20);
            this.txtClientSec.TabIndex = 9;
            this.txtClientSec.Text = "7:7.RNl]/7yoqsR9/+e54JGE4A3.MM6z";
            this.txtClientSec.TextChanged += new System.EventHandler(this.txtTenant_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Client Secret";
            // 
            // cbRuleset
            // 
            this.cbRuleset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRuleset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRuleset.Enabled = false;
            this.cbRuleset.FormattingEnabled = true;
            this.cbRuleset.Location = new System.Drawing.Point(95, 22);
            this.cbRuleset.Name = "cbRuleset";
            this.cbRuleset.Size = new System.Drawing.Size(327, 21);
            this.cbRuleset.TabIndex = 11;
            this.cbRuleset.SelectedIndexChanged += new System.EventHandler(this.cbRuleset_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ruleset";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConnectPAC);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtClientSec);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtClientId);
            this.groupBox2.Controls.Add(this.txtTenantId);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 137);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PowerApps Checker API";
            // 
            // btnConnectPAC
            // 
            this.btnConnectPAC.Location = new System.Drawing.Point(95, 106);
            this.btnConnectPAC.Name = "btnConnectPAC";
            this.btnConnectPAC.Size = new System.Drawing.Size(75, 23);
            this.btnConnectPAC.TabIndex = 11;
            this.btnConnectPAC.Text = "Connect";
            this.btnConnectPAC.UseVisualStyleBackColor = true;
            this.btnConnectPAC.Click += new System.EventHandler(this.btnConnectPAC_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Blob Url";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Correlation Id";
            // 
            // txtCorrId
            // 
            this.txtCorrId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorrId.Location = new System.Drawing.Point(88, 134);
            this.txtCorrId.Name = "txtCorrId";
            this.txtCorrId.ReadOnly = true;
            this.txtCorrId.Size = new System.Drawing.Size(333, 20);
            this.txtCorrId.TabIndex = 14;
            // 
            // cbSolutions
            // 
            this.cbSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSolutions.AutoLoadData = true;
            this.cbSolutions.Enabled = false;
            this.cbSolutions.LanguageCode = 1033;
            this.cbSolutions.Location = new System.Drawing.Point(84, 21);
            this.cbSolutions.Margin = new System.Windows.Forms.Padding(1);
            this.cbSolutions.Name = "cbSolutions";
            this.cbSolutions.PublisherPrefixes = ((System.Collections.Generic.List<string>)(resources.GetObject("cbSolutions.PublisherPrefixes")));
            this.cbSolutions.Service = null;
            this.cbSolutions.Size = new System.Drawing.Size(365, 25);
            this.cbSolutions.TabIndex = 16;
            this.cbSolutions.SelectedItemChanged += new System.EventHandler(this.cdSolutions_SelectedItemChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Filename";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Enabled = false;
            this.txtFilename.Location = new System.Drawing.Point(88, 79);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(333, 20);
            this.txtFilename.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Solution";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(427, 79);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(27, 20);
            this.btnOpenFile.TabIndex = 20;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // gbRules
            // 
            this.gbRules.Controls.Add(this.rbGroupCategory);
            this.gbRules.Controls.Add(this.rbGroupSeverity);
            this.gbRules.Controls.Add(this.chkAllRules);
            this.gbRules.Controls.Add(this.lblRules);
            this.gbRules.Controls.Add(this.cbRuleset);
            this.gbRules.Controls.Add(this.label5);
            this.gbRules.Controls.Add(this.txtRuleDescr);
            this.gbRules.Controls.Add(this.lvRules);
            this.gbRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRules.Location = new System.Drawing.Point(0, 137);
            this.gbRules.Name = "gbRules";
            this.gbRules.Size = new System.Drawing.Size(434, 495);
            this.gbRules.TabIndex = 21;
            this.gbRules.TabStop = false;
            this.gbRules.Text = "Rules";
            // 
            // rbGroupCategory
            // 
            this.rbGroupCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGroupCategory.AutoSize = true;
            this.rbGroupCategory.Location = new System.Drawing.Point(356, 54);
            this.rbGroupCategory.Name = "rbGroupCategory";
            this.rbGroupCategory.Size = new System.Drawing.Size(67, 17);
            this.rbGroupCategory.TabIndex = 17;
            this.rbGroupCategory.Text = "Category";
            this.rbGroupCategory.UseVisualStyleBackColor = true;
            this.rbGroupCategory.CheckedChanged += new System.EventHandler(this.rbGroupBy_CheckedChanged);
            // 
            // rbGroupSeverity
            // 
            this.rbGroupSeverity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGroupSeverity.AutoSize = true;
            this.rbGroupSeverity.Checked = true;
            this.rbGroupSeverity.Location = new System.Drawing.Point(287, 54);
            this.rbGroupSeverity.Name = "rbGroupSeverity";
            this.rbGroupSeverity.Size = new System.Drawing.Size(63, 17);
            this.rbGroupSeverity.TabIndex = 16;
            this.rbGroupSeverity.TabStop = true;
            this.rbGroupSeverity.Text = "Severity";
            this.rbGroupSeverity.UseVisualStyleBackColor = true;
            this.rbGroupSeverity.CheckedChanged += new System.EventHandler(this.rbGroupBy_CheckedChanged);
            // 
            // chkAllRules
            // 
            this.chkAllRules.AutoSize = true;
            this.chkAllRules.Location = new System.Drawing.Point(21, 55);
            this.chkAllRules.Name = "chkAllRules";
            this.chkAllRules.Size = new System.Drawing.Size(119, 17);
            this.chkAllRules.TabIndex = 15;
            this.chkAllRules.Text = "Check/Uncheck all";
            this.chkAllRules.UseVisualStyleBackColor = true;
            this.chkAllRules.CheckedChanged += new System.EventHandler(this.chkAllRules_CheckedChanged);
            // 
            // lblRules
            // 
            this.lblRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRules.AutoSize = true;
            this.lblRules.Location = new System.Drawing.Point(12, 413);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(87, 13);
            this.lblRules.TabIndex = 14;
            this.lblRules.Text = "Rules not loaded";
            // 
            // txtRuleDescr
            // 
            this.txtRuleDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuleDescr.Location = new System.Drawing.Point(15, 436);
            this.txtRuleDescr.Multiline = true;
            this.txtRuleDescr.Name = "txtRuleDescr";
            this.txtRuleDescr.ReadOnly = true;
            this.txtRuleDescr.Size = new System.Drawing.Size(408, 53);
            this.txtRuleDescr.TabIndex = 1;
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
            this.lvRules.Location = new System.Drawing.Point(15, 78);
            this.lvRules.Name = "lvRules";
            this.lvRules.Size = new System.Drawing.Size(407, 332);
            this.lvRules.TabIndex = 0;
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
            // gbSolution
            // 
            this.gbSolution.Controls.Add(this.btnAnalyze);
            this.gbSolution.Controls.Add(this.btnUpload);
            this.gbSolution.Controls.Add(this.btnExport);
            this.gbSolution.Controls.Add(this.linkBlob);
            this.gbSolution.Controls.Add(this.label8);
            this.gbSolution.Controls.Add(this.cbSolutions);
            this.gbSolution.Controls.Add(this.txtFilename);
            this.gbSolution.Controls.Add(this.label4);
            this.gbSolution.Controls.Add(this.txtCorrId);
            this.gbSolution.Controls.Add(this.btnOpenFile);
            this.gbSolution.Controls.Add(this.label6);
            this.gbSolution.Controls.Add(this.label7);
            this.gbSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSolution.Location = new System.Drawing.Point(0, 0);
            this.gbSolution.Name = "gbSolution";
            this.gbSolution.Size = new System.Drawing.Size(471, 234);
            this.gbSolution.TabIndex = 22;
            this.gbSolution.TabStop = false;
            this.gbSolution.Text = "Solution";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(88, 51);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 24;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // linkBlob
            // 
            this.linkBlob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkBlob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkBlob.Location = new System.Drawing.Point(88, 160);
            this.linkBlob.Name = "linkBlob";
            this.linkBlob.Size = new System.Drawing.Size(333, 20);
            this.linkBlob.TabIndex = 23;
            this.linkBlob.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbRules);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtAnalysis);
            this.splitContainer1.Panel2.Controls.Add(this.gbSolution);
            this.splitContainer1.Size = new System.Drawing.Size(913, 632);
            this.splitContainer1.SplitterDistance = 434;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 23;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(88, 104);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 25;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(88, 184);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyze.TabIndex = 26;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 10);
            this.panel1.TabIndex = 24;
            // 
            // txtAnalysis
            // 
            this.txtAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnalysis.Location = new System.Drawing.Point(0, 234);
            this.txtAnalysis.Multiline = true;
            this.txtAnalysis.Name = "txtAnalysis";
            this.txtAnalysis.ReadOnly = true;
            this.txtAnalysis.Size = new System.Drawing.Size(471, 398);
            this.txtAnalysis.TabIndex = 23;
            // 
            // PAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "PAC";
            this.Size = new System.Drawing.Size(913, 642);
            this.Load += new System.EventHandler(this.PAC_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbRules.ResumeLayout(false);
            this.gbRules.PerformLayout();
            this.gbSolution.ResumeLayout(false);
            this.gbSolution.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenantId;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientSec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRuleset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private xrmtb.XrmToolBox.Controls.SolutionsDropdownControl cbSolutions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCorrId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbRules;
        private System.Windows.Forms.ListView lvRules;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox txtRuleDescr;
        private System.Windows.Forms.GroupBox gbSolution;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.CheckBox chkAllRules;
        private System.Windows.Forms.Button btnConnectPAC;
        private System.Windows.Forms.RadioButton rbGroupCategory;
        private System.Windows.Forms.RadioButton rbGroupSeverity;
        private System.Windows.Forms.LinkLabel linkBlob;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtAnalysis;
        private System.Windows.Forms.Panel panel1;
    }
}
