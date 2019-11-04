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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenantId = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientSec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRuleset = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbAPI = new System.Windows.Forms.GroupBox();
            this.llFileOptionsExpander = new System.Windows.Forms.LinkLabel();
            this.btnConnectPAC = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCorrId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.gbRules = new System.Windows.Forms.GroupBox();
            this.picRuleHelp = new System.Windows.Forms.PictureBox();
            this.rbGroupCategory = new System.Windows.Forms.RadioButton();
            this.rbGroupSeverity = new System.Windows.Forms.RadioButton();
            this.chkAllRules = new System.Windows.Forms.CheckBox();
            this.lblRules = new System.Windows.Forms.Label();
            this.txtRuleDescr = new System.Windows.Forms.TextBox();
            this.lvRules = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbSolution = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbSolution = new xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.linkUploaded = new System.Windows.Forms.LinkLabel();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlResults = new System.Windows.Forms.TabControl();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.Severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RuleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Snippet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAnalysis = new System.Windows.Forms.TextBox();
            this.tabSarif = new System.Windows.Forms.TabPage();
            this.txtSarif = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.txtResultFile = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStatusUrl = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSaveSarif = new System.Windows.Forms.Button();
            this.txtRunCorrId = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.progAnalysis = new System.Windows.Forms.ProgressBar();
            this.label12 = new System.Windows.Forms.Label();
            this.gbAnalysis = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.txtExclusions = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rbScopeRules = new System.Windows.Forms.RadioButton();
            this.rbScopeRuleset = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tmStatus = new System.Windows.Forms.Timer(this.components);
            this.dgGrouper = new Subro.Controls.DataGridViewGrouper(this.components);
            this.btnOpenSarif = new System.Windows.Forms.Button();
            this.gbAPI.SuspendLayout();
            this.gbRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRuleHelp)).BeginInit();
            this.gbSolution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlResults.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.tabSarif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbResults.SuspendLayout();
            this.gbAnalysis.SuspendLayout();
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
            this.txtClientSec.Size = new System.Drawing.Size(246, 20);
            this.txtClientSec.TabIndex = 9;
            this.txtClientSec.Text = "7:7.RNl]/7yoqsR9/+e54JGE4A3.MM6z";
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
            this.cbRuleset.BackColor = System.Drawing.SystemColors.Window;
            this.cbRuleset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRuleset.Enabled = false;
            this.cbRuleset.FormattingEnabled = true;
            this.cbRuleset.Location = new System.Drawing.Point(95, 22);
            this.cbRuleset.Name = "cbRuleset";
            this.cbRuleset.Size = new System.Drawing.Size(327, 21);
            this.cbRuleset.TabIndex = 1;
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
            // gbAPI
            // 
            this.gbAPI.Controls.Add(this.llFileOptionsExpander);
            this.gbAPI.Controls.Add(this.btnConnectPAC);
            this.gbAPI.Controls.Add(this.label3);
            this.gbAPI.Controls.Add(this.txtClientSec);
            this.gbAPI.Controls.Add(this.label2);
            this.gbAPI.Controls.Add(this.txtClientId);
            this.gbAPI.Controls.Add(this.txtTenantId);
            this.gbAPI.Controls.Add(this.label1);
            this.gbAPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAPI.Location = new System.Drawing.Point(0, 0);
            this.gbAPI.Name = "gbAPI";
            this.gbAPI.Size = new System.Drawing.Size(434, 110);
            this.gbAPI.TabIndex = 1;
            this.gbAPI.TabStop = false;
            this.gbAPI.Text = "Power Apps Checker API";
            // 
            // llFileOptionsExpander
            // 
            this.llFileOptionsExpander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llFileOptionsExpander.AutoSize = true;
            this.llFileOptionsExpander.Location = new System.Drawing.Point(399, 0);
            this.llFileOptionsExpander.Name = "llFileOptionsExpander";
            this.llFileOptionsExpander.Size = new System.Drawing.Size(29, 13);
            this.llFileOptionsExpander.TabIndex = 14;
            this.llFileOptionsExpander.TabStop = true;
            this.llFileOptionsExpander.Text = "Hide";
            this.llFileOptionsExpander.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGroupBoxExpander_LinkClicked);
            // 
            // btnConnectPAC
            // 
            this.btnConnectPAC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectPAC.BackColor = System.Drawing.SystemColors.Window;
            this.btnConnectPAC.Location = new System.Drawing.Point(347, 77);
            this.btnConnectPAC.Name = "btnConnectPAC";
            this.btnConnectPAC.Size = new System.Drawing.Size(75, 23);
            this.btnConnectPAC.TabIndex = 11;
            this.btnConnectPAC.Text = "Connect";
            this.btnConnectPAC.UseVisualStyleBackColor = false;
            this.btnConnectPAC.Click += new System.EventHandler(this.btnConnectPAC_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Uploaded File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Correlation Id";
            // 
            // txtCorrId
            // 
            this.txtCorrId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorrId.BackColor = System.Drawing.SystemColors.Window;
            this.txtCorrId.Location = new System.Drawing.Point(95, 79);
            this.txtCorrId.Name = "txtCorrId";
            this.txtCorrId.ReadOnly = true;
            this.txtCorrId.Size = new System.Drawing.Size(356, 20);
            this.txtCorrId.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Filename";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.BackColor = System.Drawing.SystemColors.Window;
            this.txtFilename.Enabled = false;
            this.txtFilename.Location = new System.Drawing.Point(95, 53);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(242, 20);
            this.txtFilename.TabIndex = 3;
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
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.Window;
            this.btnOpenFile.Location = new System.Drawing.Point(343, 51);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(27, 23);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // gbRules
            // 
            this.gbRules.Controls.Add(this.picRuleHelp);
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
            this.gbRules.Location = new System.Drawing.Point(0, 110);
            this.gbRules.Name = "gbRules";
            this.gbRules.Size = new System.Drawing.Size(434, 522);
            this.gbRules.TabIndex = 2;
            this.gbRules.TabStop = false;
            this.gbRules.Text = "Rules";
            // 
            // picRuleHelp
            // 
            this.picRuleHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picRuleHelp.Cursor = System.Windows.Forms.Cursors.No;
            this.picRuleHelp.Image = ((System.Drawing.Image)(resources.GetObject("picRuleHelp.Image")));
            this.picRuleHelp.Location = new System.Drawing.Point(398, 463);
            this.picRuleHelp.Name = "picRuleHelp";
            this.picRuleHelp.Size = new System.Drawing.Size(24, 24);
            this.picRuleHelp.TabIndex = 18;
            this.picRuleHelp.TabStop = false;
            this.picRuleHelp.Click += new System.EventHandler(this.picRuleHelp_Click);
            // 
            // rbGroupCategory
            // 
            this.rbGroupCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGroupCategory.AutoSize = true;
            this.rbGroupCategory.Location = new System.Drawing.Point(356, 54);
            this.rbGroupCategory.Name = "rbGroupCategory";
            this.rbGroupCategory.Size = new System.Drawing.Size(67, 17);
            this.rbGroupCategory.TabIndex = 4;
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
            this.rbGroupSeverity.TabIndex = 3;
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
            this.chkAllRules.TabIndex = 2;
            this.chkAllRules.Text = "Check/Uncheck all";
            this.chkAllRules.UseVisualStyleBackColor = true;
            this.chkAllRules.CheckedChanged += new System.EventHandler(this.chkAllRules_CheckedChanged);
            // 
            // lblRules
            // 
            this.lblRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRules.AutoSize = true;
            this.lblRules.Location = new System.Drawing.Point(12, 440);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(87, 13);
            this.lblRules.TabIndex = 14;
            this.lblRules.Text = "Rules not loaded";
            // 
            // txtRuleDescr
            // 
            this.txtRuleDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuleDescr.BackColor = System.Drawing.SystemColors.Window;
            this.txtRuleDescr.Location = new System.Drawing.Point(15, 463);
            this.txtRuleDescr.Multiline = true;
            this.txtRuleDescr.Name = "txtRuleDescr";
            this.txtRuleDescr.ReadOnly = true;
            this.txtRuleDescr.Size = new System.Drawing.Size(377, 53);
            this.txtRuleDescr.TabIndex = 6;
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
            this.lvRules.Size = new System.Drawing.Size(407, 359);
            this.lvRules.TabIndex = 5;
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
            this.gbSolution.Controls.Add(this.linkLabel1);
            this.gbSolution.Controls.Add(this.cbSolution);
            this.gbSolution.Controls.Add(this.btnUpload);
            this.gbSolution.Controls.Add(this.btnExport);
            this.gbSolution.Controls.Add(this.linkUploaded);
            this.gbSolution.Controls.Add(this.label8);
            this.gbSolution.Controls.Add(this.txtFilename);
            this.gbSolution.Controls.Add(this.label4);
            this.gbSolution.Controls.Add(this.txtCorrId);
            this.gbSolution.Controls.Add(this.btnOpenFile);
            this.gbSolution.Controls.Add(this.label6);
            this.gbSolution.Controls.Add(this.label7);
            this.gbSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSolution.Location = new System.Drawing.Point(0, 0);
            this.gbSolution.Name = "gbSolution";
            this.gbSolution.Size = new System.Drawing.Size(463, 135);
            this.gbSolution.TabIndex = 3;
            this.gbSolution.TabStop = false;
            this.gbSolution.Text = "Solution";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(428, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 13);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Hide";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGroupBoxExpander_LinkClicked);
            // 
            // cbSolution
            // 
            this.cbSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSolution.BackColor = System.Drawing.SystemColors.Window;
            this.cbSolution.DisplayFormat = "{{friendlyname}} ({{uniquename}}) {{version}}";
            this.cbSolution.FormattingEnabled = true;
            this.cbSolution.Location = new System.Drawing.Point(95, 26);
            this.cbSolution.Name = "cbSolution";
            this.cbSolution.Size = new System.Drawing.Size(275, 21);
            this.cbSolution.TabIndex = 1;
            this.cbSolution.SelectedIndexChanged += new System.EventHandler(this.cdSolution_SelectedItemChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.SystemColors.Window;
            this.btnUpload.Location = new System.Drawing.Point(376, 51);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.SystemColors.Window;
            this.btnExport.Location = new System.Drawing.Point(376, 24);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // linkUploaded
            // 
            this.linkUploaded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkUploaded.BackColor = System.Drawing.SystemColors.Window;
            this.linkUploaded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkUploaded.Location = new System.Drawing.Point(95, 105);
            this.linkUploaded.Name = "linkUploaded";
            this.linkUploaded.Size = new System.Drawing.Size(356, 20);
            this.linkUploaded.TabIndex = 7;
            this.linkUploaded.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUploaded_LinkClicked);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalyze.BackColor = System.Drawing.SystemColors.Window;
            this.btnAnalyze.Location = new System.Drawing.Point(340, 20);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.gbAPI);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlResults);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1340, 632);
            this.splitContainer1.SplitterDistance = 434;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 23;
            // 
            // tabControlResults
            // 
            this.tabControlResults.Controls.Add(this.tabResults);
            this.tabControlResults.Controls.Add(this.tabSarif);
            this.tabControlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlResults.Location = new System.Drawing.Point(0, 218);
            this.tabControlResults.Name = "tabControlResults";
            this.tabControlResults.SelectedIndex = 0;
            this.tabControlResults.Size = new System.Drawing.Size(898, 414);
            this.tabControlResults.TabIndex = 9;
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.dgResults);
            this.tabResults.Controls.Add(this.txtAnalysis);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(890, 388);
            this.tabResults.TabIndex = 0;
            this.tabResults.Text = "Results";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToDeleteRows = false;
            this.dgResults.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgResults.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Severity,
            this.RuleId,
            this.Message,
            this.Snippet,
            this.FilePath,
            this.StartLine});
            this.dgResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgResults.Location = new System.Drawing.Point(3, 62);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.RowHeadersVisible = false;
            this.dgResults.Size = new System.Drawing.Size(884, 323);
            this.dgResults.TabIndex = 1;
            this.dgResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dgResults.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgResults_ColumnHeaderMouseClick);
            // 
            // Severity
            // 
            this.Severity.DataPropertyName = "Severity";
            this.Severity.FillWeight = 70F;
            this.Severity.HeaderText = "Severity";
            this.Severity.Name = "Severity";
            this.Severity.ReadOnly = true;
            // 
            // RuleId
            // 
            this.RuleId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RuleId.DataPropertyName = "RuleId";
            this.RuleId.HeaderText = "Rule";
            this.RuleId.Name = "RuleId";
            this.RuleId.ReadOnly = true;
            this.RuleId.Width = 54;
            // 
            // Message
            // 
            this.Message.DataPropertyName = "Message";
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Width = 200;
            // 
            // Snippet
            // 
            this.Snippet.DataPropertyName = "Snippet";
            this.Snippet.HeaderText = "Snippet";
            this.Snippet.Name = "Snippet";
            this.Snippet.ReadOnly = true;
            this.Snippet.Width = 200;
            // 
            // FilePath
            // 
            this.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "File";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Width = 48;
            // 
            // StartLine
            // 
            this.StartLine.DataPropertyName = "StartLine";
            this.StartLine.HeaderText = "Start Line";
            this.StartLine.Name = "StartLine";
            this.StartLine.ReadOnly = true;
            this.StartLine.Width = 70;
            // 
            // txtAnalysis
            // 
            this.txtAnalysis.BackColor = System.Drawing.SystemColors.Window;
            this.txtAnalysis.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAnalysis.Location = new System.Drawing.Point(3, 3);
            this.txtAnalysis.Multiline = true;
            this.txtAnalysis.Name = "txtAnalysis";
            this.txtAnalysis.ReadOnly = true;
            this.txtAnalysis.Size = new System.Drawing.Size(884, 59);
            this.txtAnalysis.TabIndex = 0;
            this.txtAnalysis.WordWrap = false;
            // 
            // tabSarif
            // 
            this.tabSarif.Controls.Add(this.txtSarif);
            this.tabSarif.Location = new System.Drawing.Point(4, 22);
            this.tabSarif.Name = "tabSarif";
            this.tabSarif.Padding = new System.Windows.Forms.Padding(3);
            this.tabSarif.Size = new System.Drawing.Size(672, 388);
            this.tabSarif.TabIndex = 1;
            this.tabSarif.Text = "SARIF (raw)";
            this.tabSarif.UseVisualStyleBackColor = true;
            // 
            // txtSarif
            // 
            this.txtSarif.BackColor = System.Drawing.SystemColors.Window;
            this.txtSarif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSarif.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSarif.Location = new System.Drawing.Point(3, 3);
            this.txtSarif.Name = "txtSarif";
            this.txtSarif.ReadOnly = true;
            this.txtSarif.Size = new System.Drawing.Size(666, 382);
            this.txtSarif.TabIndex = 0;
            this.txtSarif.Text = "";
            this.txtSarif.WordWrap = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnOpenSarif);
            this.splitContainer2.Panel1.Controls.Add(this.gbSolution);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbResults);
            this.splitContainer2.Panel2.Controls.Add(this.gbAnalysis);
            this.splitContainer2.Size = new System.Drawing.Size(898, 218);
            this.splitContainer2.SplitterDistance = 463;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 11;
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.linkLabel3);
            this.gbResults.Controls.Add(this.txtResultFile);
            this.gbResults.Controls.Add(this.label10);
            this.gbResults.Controls.Add(this.txtStatusUrl);
            this.gbResults.Controls.Add(this.label13);
            this.gbResults.Controls.Add(this.label11);
            this.gbResults.Controls.Add(this.btnSaveSarif);
            this.gbResults.Controls.Add(this.txtRunCorrId);
            this.gbResults.Controls.Add(this.txtStatus);
            this.gbResults.Controls.Add(this.progAnalysis);
            this.gbResults.Controls.Add(this.label12);
            this.gbResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbResults.Location = new System.Drawing.Point(0, 85);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(427, 130);
            this.gbResults.TabIndex = 10;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Results";
            // 
            // linkLabel3
            // 
            this.linkLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(392, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(29, 13);
            this.linkLabel3.TabIndex = 39;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Hide";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGroupBoxExpander_LinkClicked);
            // 
            // txtResultFile
            // 
            this.txtResultFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultFile.Location = new System.Drawing.Point(95, 101);
            this.txtResultFile.Name = "txtResultFile";
            this.txtResultFile.ReadOnly = true;
            this.txtResultFile.Size = new System.Drawing.Size(239, 20);
            this.txtResultFile.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Status Url";
            // 
            // txtStatusUrl
            // 
            this.txtStatusUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatusUrl.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatusUrl.Location = new System.Drawing.Point(95, 23);
            this.txtStatusUrl.Name = "txtStatusUrl";
            this.txtStatusUrl.ReadOnly = true;
            this.txtStatusUrl.Size = new System.Drawing.Size(320, 20);
            this.txtStatusUrl.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Result file";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Run Corr Id";
            // 
            // btnSaveSarif
            // 
            this.btnSaveSarif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSarif.BackColor = System.Drawing.SystemColors.Window;
            this.btnSaveSarif.Location = new System.Drawing.Point(340, 99);
            this.btnSaveSarif.Name = "btnSaveSarif";
            this.btnSaveSarif.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSarif.TabIndex = 9;
            this.btnSaveSarif.Text = "Save SARIF";
            this.btnSaveSarif.UseVisualStyleBackColor = false;
            this.btnSaveSarif.Click += new System.EventHandler(this.btnSaveSarif_Click);
            // 
            // txtRunCorrId
            // 
            this.txtRunCorrId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRunCorrId.BackColor = System.Drawing.SystemColors.Window;
            this.txtRunCorrId.Location = new System.Drawing.Point(95, 49);
            this.txtRunCorrId.Name = "txtRunCorrId";
            this.txtRunCorrId.ReadOnly = true;
            this.txtRunCorrId.Size = new System.Drawing.Size(320, 20);
            this.txtRunCorrId.TabIndex = 5;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.Location = new System.Drawing.Point(95, 75);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(97, 20);
            this.txtStatus.TabIndex = 6;
            // 
            // progAnalysis
            // 
            this.progAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progAnalysis.BackColor = System.Drawing.SystemColors.Window;
            this.progAnalysis.Location = new System.Drawing.Point(198, 75);
            this.progAnalysis.Name = "progAnalysis";
            this.progAnalysis.Size = new System.Drawing.Size(217, 20);
            this.progAnalysis.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Status";
            // 
            // gbAnalysis
            // 
            this.gbAnalysis.Controls.Add(this.linkLabel2);
            this.gbAnalysis.Controls.Add(this.txtExclusions);
            this.gbAnalysis.Controls.Add(this.label14);
            this.gbAnalysis.Controls.Add(this.btnAnalyze);
            this.gbAnalysis.Controls.Add(this.rbScopeRules);
            this.gbAnalysis.Controls.Add(this.rbScopeRuleset);
            this.gbAnalysis.Controls.Add(this.label9);
            this.gbAnalysis.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAnalysis.Location = new System.Drawing.Point(0, 0);
            this.gbAnalysis.Name = "gbAnalysis";
            this.gbAnalysis.Size = new System.Drawing.Size(427, 85);
            this.gbAnalysis.TabIndex = 4;
            this.gbAnalysis.TabStop = false;
            this.gbAnalysis.Text = "Analysis";
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(392, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(29, 13);
            this.linkLabel2.TabIndex = 38;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Hide";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGroupBoxExpander_LinkClicked);
            // 
            // txtExclusions
            // 
            this.txtExclusions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExclusions.Location = new System.Drawing.Point(95, 49);
            this.txtExclusions.Name = "txtExclusions";
            this.txtExclusions.Size = new System.Drawing.Size(320, 20);
            this.txtExclusions.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "File Exclusions";
            // 
            // rbScopeRules
            // 
            this.rbScopeRules.AutoSize = true;
            this.rbScopeRules.Location = new System.Drawing.Point(207, 23);
            this.rbScopeRules.Name = "rbScopeRules";
            this.rbScopeRules.Size = new System.Drawing.Size(97, 17);
            this.rbScopeRules.TabIndex = 2;
            this.rbScopeRules.Text = "Selected Rules";
            this.rbScopeRules.UseVisualStyleBackColor = true;
            this.rbScopeRules.CheckedChanged += new System.EventHandler(this.rbScope_CheckedChanged);
            // 
            // rbScopeRuleset
            // 
            this.rbScopeRuleset.AutoSize = true;
            this.rbScopeRuleset.Checked = true;
            this.rbScopeRuleset.Location = new System.Drawing.Point(95, 23);
            this.rbScopeRuleset.Name = "rbScopeRuleset";
            this.rbScopeRuleset.Size = new System.Drawing.Size(106, 17);
            this.rbScopeRuleset.TabIndex = 1;
            this.rbScopeRuleset.TabStop = true;
            this.rbScopeRuleset.Text = "Selected Ruleset";
            this.rbScopeRuleset.UseVisualStyleBackColor = true;
            this.rbScopeRuleset.CheckedChanged += new System.EventHandler(this.rbScope_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Scope";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1340, 10);
            this.panel1.TabIndex = 24;
            // 
            // tmStatus
            // 
            this.tmStatus.Interval = 5000;
            this.tmStatus.Tick += new System.EventHandler(this.tmStatus_Tick);
            // 
            // dgGrouper
            // 
            this.dgGrouper.DataGridView = this.dgResults;
            this.dgGrouper.Options = ((Subro.Controls.GroupingOptions)(resources.GetObject("dgGrouper.Options")));
            // 
            // btnOpenSarif
            // 
            this.btnOpenSarif.Location = new System.Drawing.Point(132, 155);
            this.btnOpenSarif.Name = "btnOpenSarif";
            this.btnOpenSarif.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSarif.TabIndex = 4;
            this.btnOpenSarif.Text = "Open SARIF";
            this.btnOpenSarif.UseVisualStyleBackColor = true;
            this.btnOpenSarif.Click += new System.EventHandler(this.btnOpenSarif_Click);
            // 
            // PAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "PAC";
            this.Size = new System.Drawing.Size(1340, 642);
            this.Load += new System.EventHandler(this.PAC_Load);
            this.gbAPI.ResumeLayout(false);
            this.gbAPI.PerformLayout();
            this.gbRules.ResumeLayout(false);
            this.gbRules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRuleHelp)).EndInit();
            this.gbSolution.ResumeLayout(false);
            this.gbSolution.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlResults.ResumeLayout(false);
            this.tabResults.ResumeLayout(false);
            this.tabResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.tabSarif.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbResults.ResumeLayout(false);
            this.gbResults.PerformLayout();
            this.gbAnalysis.ResumeLayout(false);
            this.gbAnalysis.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbAPI;
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
        private System.Windows.Forms.LinkLabel linkUploaded;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picRuleHelp;
        private System.Windows.Forms.GroupBox gbAnalysis;
        private System.Windows.Forms.RadioButton rbScopeRules;
        private System.Windows.Forms.RadioButton rbScopeRuleset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStatusUrl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer tmStatus;
        private System.Windows.Forms.TextBox txtRunCorrId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar progAnalysis;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStatus;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox cbSolution;
        private System.Windows.Forms.Button btnSaveSarif;
        private System.Windows.Forms.TextBox txtResultFile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabControl tabControlResults;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.TabPage tabSarif;
        private System.Windows.Forms.RichTextBox txtSarif;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.TextBox txtExclusions;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel llFileOptionsExpander;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox txtAnalysis;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgResults;
        private Subro.Controls.DataGridViewGrouper dgGrouper;
        private System.Windows.Forms.DataGridViewTextBoxColumn Severity;
        private System.Windows.Forms.DataGridViewTextBoxColumn RuleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Snippet;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartLine;
        private System.Windows.Forms.Button btnOpenSarif;
    }
}
