using System.Drawing;

namespace Rappen.XTB.PAC.DockControls
{
    partial class SarifControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SarifControl));
            this.tabControlResults = new System.Windows.Forms.TabControl();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.panAnalyzing = new System.Windows.Forms.Panel();
            this.panAnalyzing2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.cbComponent = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbRule = new System.Windows.Forms.ComboBox();
            this.cbSeverity = new System.Windows.Forms.ComboBox();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.colSeverity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panTop = new System.Windows.Forms.Panel();
            this.picDetailOpen = new System.Windows.Forms.PictureBox();
            this.panStatus = new System.Windows.Forms.Panel();
            this.progAnalysis = new System.Windows.Forms.ProgressBar();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResultCountInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResultCountLow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResultCountCritical = new System.Windows.Forms.TextBox();
            this.txtResultCountMedium = new System.Windows.Forms.TextBox();
            this.txtResultCountHigh = new System.Windows.Forms.TextBox();
            this.txtSnippet = new System.Windows.Forms.Label();
            this.lblSnippet = new System.Windows.Forms.Label();
            this.txtMember = new System.Windows.Forms.Label();
            this.lblMember = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.Label();
            this.lblModule = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtComponent = new System.Windows.Forms.Label();
            this.lblComponent = new System.Windows.Forms.Label();
            this.linkFix = new System.Windows.Forms.LinkLabel();
            this.txtFix = new System.Windows.Forms.Label();
            this.lblFix = new System.Windows.Forms.Label();
            this.txtIssue = new System.Windows.Forms.Label();
            this.lblIssue = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtRule = new System.Windows.Forms.Label();
            this.lblRule = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDetailHeader = new System.Windows.Forms.Label();
            this.picDetailClose = new System.Windows.Forms.PictureBox();
            this.tabSarif = new System.Windows.Forms.TabPage();
            this.txtSarif = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenSarif = new System.Windows.Forms.Button();
            this.txtResultFile = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSaveSarif = new System.Windows.Forms.Button();
            this.tabTech = new System.Windows.Forms.TabPage();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dgSolutions = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.txtExclusions = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRulesets = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbRules = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCorrId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStatusUrl = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRunCorrId = new System.Windows.Forms.TextBox();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.dgArtifacts = new System.Windows.Forms.DataGridView();
            this.tmStatus = new System.Windows.Forms.Timer(this.components);
            this.tabControlResults.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.panAnalyzing.SuspendLayout();
            this.panAnalyzing2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailOpen)).BeginInit();
            this.panStatus.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailClose)).BeginInit();
            this.tabSarif.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabTech.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSolutions)).BeginInit();
            this.tabFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArtifacts)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlResults
            // 
            this.tabControlResults.Controls.Add(this.tabResults);
            this.tabControlResults.Controls.Add(this.tabSarif);
            this.tabControlResults.Controls.Add(this.tabTech);
            this.tabControlResults.Controls.Add(this.tabFiles);
            this.tabControlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlResults.Location = new System.Drawing.Point(0, 0);
            this.tabControlResults.Name = "tabControlResults";
            this.tabControlResults.SelectedIndex = 0;
            this.tabControlResults.Size = new System.Drawing.Size(1032, 486);
            this.tabControlResults.TabIndex = 10;
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.splitter);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(1024, 460);
            this.tabResults.TabIndex = 0;
            this.tabResults.Text = "Results";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(3, 3);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.panAnalyzing);
            this.splitter.Panel1.Controls.Add(this.cbLocation);
            this.splitter.Panel1.Controls.Add(this.cbComponent);
            this.splitter.Panel1.Controls.Add(this.cbCategory);
            this.splitter.Panel1.Controls.Add(this.cbRule);
            this.splitter.Panel1.Controls.Add(this.cbSeverity);
            this.splitter.Panel1.Controls.Add(this.dgResults);
            this.splitter.Panel1.Controls.Add(this.panTop);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.AutoScroll = true;
            this.splitter.Panel2.Controls.Add(this.txtSnippet);
            this.splitter.Panel2.Controls.Add(this.lblSnippet);
            this.splitter.Panel2.Controls.Add(this.txtMember);
            this.splitter.Panel2.Controls.Add(this.lblMember);
            this.splitter.Panel2.Controls.Add(this.txtModule);
            this.splitter.Panel2.Controls.Add(this.lblModule);
            this.splitter.Panel2.Controls.Add(this.txtType);
            this.splitter.Panel2.Controls.Add(this.lblType);
            this.splitter.Panel2.Controls.Add(this.txtLine);
            this.splitter.Panel2.Controls.Add(this.lblLine);
            this.splitter.Panel2.Controls.Add(this.txtLocation);
            this.splitter.Panel2.Controls.Add(this.lblLocation);
            this.splitter.Panel2.Controls.Add(this.txtComponent);
            this.splitter.Panel2.Controls.Add(this.lblComponent);
            this.splitter.Panel2.Controls.Add(this.linkFix);
            this.splitter.Panel2.Controls.Add(this.txtFix);
            this.splitter.Panel2.Controls.Add(this.lblFix);
            this.splitter.Panel2.Controls.Add(this.txtIssue);
            this.splitter.Panel2.Controls.Add(this.lblIssue);
            this.splitter.Panel2.Controls.Add(this.txtCategory);
            this.splitter.Panel2.Controls.Add(this.lblCategory);
            this.splitter.Panel2.Controls.Add(this.txtRule);
            this.splitter.Panel2.Controls.Add(this.lblRule);
            this.splitter.Panel2.Controls.Add(this.panel2);
            this.splitter.Panel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.splitter.Panel2.SizeChanged += new System.EventHandler(this.splitContainer1_Panel2_SizeChanged);
            this.splitter.Panel2MinSize = 0;
            this.splitter.Size = new System.Drawing.Size(1018, 454);
            this.splitter.SplitterDistance = 683;
            this.splitter.SplitterWidth = 8;
            this.splitter.TabIndex = 3;
            // 
            // panAnalyzing
            // 
            this.panAnalyzing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panAnalyzing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(173)))));
            this.panAnalyzing.Controls.Add(this.panAnalyzing2);
            this.panAnalyzing.Location = new System.Drawing.Point(49, 110);
            this.panAnalyzing.Name = "panAnalyzing";
            this.panAnalyzing.Size = new System.Drawing.Size(580, 300);
            this.panAnalyzing.TabIndex = 8;
            this.panAnalyzing.Visible = false;
            // 
            // panAnalyzing2
            // 
            this.panAnalyzing2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panAnalyzing2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(39)))), ((int)(((byte)(117)))));
            this.panAnalyzing2.Controls.Add(this.pictureBox1);
            this.panAnalyzing2.Controls.Add(this.label6);
            this.panAnalyzing2.Location = new System.Drawing.Point(10, 10);
            this.panAnalyzing2.Name = "panAnalyzing2";
            this.panAnalyzing2.Size = new System.Drawing.Size(560, 280);
            this.panAnalyzing2.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Purple;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(186, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 100);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(0, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(560, 59);
            this.label6.TabIndex = 0;
            this.label6.Text = "Power Apps Checker is analyzing...";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbLocation
            // 
            this.cbLocation.BackColor = System.Drawing.SystemColors.Window;
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(614, 47);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(18, 21);
            this.cbLocation.TabIndex = 6;
            this.cbLocation.Tag = "colLocation";
            this.cbLocation.DropDown += new System.EventHandler(this.cbFilter_DropDown);
            this.cbLocation.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            this.cbLocation.DropDownClosed += new System.EventHandler(this.cbFilter_DropDownClosed);
            // 
            // cbComponent
            // 
            this.cbComponent.BackColor = System.Drawing.SystemColors.Window;
            this.cbComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComponent.FormattingEnabled = true;
            this.cbComponent.Location = new System.Drawing.Point(414, 47);
            this.cbComponent.Name = "cbComponent";
            this.cbComponent.Size = new System.Drawing.Size(18, 21);
            this.cbComponent.TabIndex = 5;
            this.cbComponent.Tag = "colComponent";
            this.cbComponent.DropDown += new System.EventHandler(this.cbFilter_DropDown);
            this.cbComponent.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            this.cbComponent.DropDownClosed += new System.EventHandler(this.cbFilter_DropDownClosed);
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.SystemColors.Window;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(313, 47);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(18, 21);
            this.cbCategory.TabIndex = 4;
            this.cbCategory.Tag = "colCategory";
            this.cbCategory.DropDown += new System.EventHandler(this.cbFilter_DropDown);
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            this.cbCategory.DropDownClosed += new System.EventHandler(this.cbFilter_DropDownClosed);
            // 
            // cbRule
            // 
            this.cbRule.BackColor = System.Drawing.SystemColors.Window;
            this.cbRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRule.FormattingEnabled = true;
            this.cbRule.Location = new System.Drawing.Point(213, 47);
            this.cbRule.Name = "cbRule";
            this.cbRule.Size = new System.Drawing.Size(18, 21);
            this.cbRule.TabIndex = 3;
            this.cbRule.Tag = "colRule";
            this.cbRule.DropDown += new System.EventHandler(this.cbFilter_DropDown);
            this.cbRule.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            this.cbRule.DropDownClosed += new System.EventHandler(this.cbFilter_DropDownClosed);
            // 
            // cbSeverity
            // 
            this.cbSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeverity.FormattingEnabled = true;
            this.cbSeverity.Location = new System.Drawing.Point(63, 47);
            this.cbSeverity.Name = "cbSeverity";
            this.cbSeverity.Size = new System.Drawing.Size(18, 21);
            this.cbSeverity.TabIndex = 0;
            this.cbSeverity.Tag = "colSeverity";
            this.cbSeverity.DropDown += new System.EventHandler(this.cbFilter_DropDown);
            this.cbSeverity.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            this.cbSeverity.DropDownClosed += new System.EventHandler(this.cbFilter_DropDownClosed);
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToDeleteRows = false;
            this.dgResults.AllowUserToResizeRows = false;
            this.dgResults.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeverity,
            this.colRule,
            this.colCategory,
            this.colComponent,
            this.colLocation});
            this.dgResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgResults.Location = new System.Drawing.Point(0, 46);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.RowHeadersVisible = false;
            this.dgResults.Size = new System.Drawing.Size(683, 408);
            this.dgResults.TabIndex = 1;
            this.dgResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResults_CellDoubleClick);
            this.dgResults.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResults_CellEnter);
            this.dgResults.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgResults_ColumnWidthChanged);
            this.dgResults.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgResults_Scroll);
            // 
            // colSeverity
            // 
            this.colSeverity.DataPropertyName = "Severity";
            this.colSeverity.HeaderText = "Severity";
            this.colSeverity.Name = "colSeverity";
            this.colSeverity.ReadOnly = true;
            this.colSeverity.Width = 80;
            // 
            // colRule
            // 
            this.colRule.DataPropertyName = "RuleDescription";
            this.colRule.HeaderText = "Rule";
            this.colRule.Name = "colRule";
            this.colRule.ReadOnly = true;
            this.colRule.Width = 150;
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "Category";
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colComponent
            // 
            this.colComponent.DataPropertyName = "Component";
            this.colComponent.HeaderText = "Component";
            this.colComponent.Name = "colComponent";
            this.colComponent.ReadOnly = true;
            // 
            // colLocation
            // 
            this.colLocation.DataPropertyName = "Location";
            this.colLocation.HeaderText = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            this.colLocation.Width = 200;
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.picDetailOpen);
            this.panTop.Controls.Add(this.panStatus);
            this.panTop.Controls.Add(this.label5);
            this.panTop.Controls.Add(this.txtResultCountInfo);
            this.panTop.Controls.Add(this.label4);
            this.panTop.Controls.Add(this.label3);
            this.panTop.Controls.Add(this.label2);
            this.panTop.Controls.Add(this.txtResultCountLow);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Controls.Add(this.txtResultCountCritical);
            this.panTop.Controls.Add(this.txtResultCountMedium);
            this.panTop.Controls.Add(this.txtResultCountHigh);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(683, 46);
            this.panTop.TabIndex = 2;
            // 
            // picDetailOpen
            // 
            this.picDetailOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picDetailOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDetailOpen.Image = ((System.Drawing.Image)(resources.GetObject("picDetailOpen.Image")));
            this.picDetailOpen.Location = new System.Drawing.Point(662, 9);
            this.picDetailOpen.Name = "picDetailOpen";
            this.picDetailOpen.Size = new System.Drawing.Size(16, 16);
            this.picDetailOpen.TabIndex = 46;
            this.picDetailOpen.TabStop = false;
            this.picDetailOpen.Click += new System.EventHandler(this.picDetailOpen_Click);
            // 
            // panStatus
            // 
            this.panStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panStatus.Controls.Add(this.progAnalysis);
            this.panStatus.Controls.Add(this.txtStatus);
            this.panStatus.Controls.Add(this.label12);
            this.panStatus.Location = new System.Drawing.Point(317, 2);
            this.panStatus.Name = "panStatus";
            this.panStatus.Size = new System.Drawing.Size(341, 43);
            this.panStatus.TabIndex = 45;
            // 
            // progAnalysis
            // 
            this.progAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progAnalysis.BackColor = System.Drawing.SystemColors.Window;
            this.progAnalysis.Location = new System.Drawing.Point(108, 16);
            this.progAnalysis.Name = "progAnalysis";
            this.progAnalysis.Size = new System.Drawing.Size(230, 20);
            this.progAnalysis.TabIndex = 39;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.Location = new System.Drawing.Point(5, 16);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(97, 20);
            this.txtStatus.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Analysis status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Info";
            // 
            // txtResultCountInfo
            // 
            this.txtResultCountInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtResultCountInfo.Location = new System.Drawing.Point(248, 18);
            this.txtResultCountInfo.Name = "txtResultCountInfo";
            this.txtResultCountInfo.ReadOnly = true;
            this.txtResultCountInfo.Size = new System.Drawing.Size(63, 20);
            this.txtResultCountInfo.TabIndex = 9;
            this.txtResultCountInfo.Tag = "Informational";
            this.txtResultCountInfo.Text = "-";
            this.txtResultCountInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtResultCountInfo.Click += new System.EventHandler(this.txtResultCountInfo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Low";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Medium";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "High";
            // 
            // txtResultCountLow
            // 
            this.txtResultCountLow.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountLow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtResultCountLow.Location = new System.Drawing.Point(186, 18);
            this.txtResultCountLow.Name = "txtResultCountLow";
            this.txtResultCountLow.ReadOnly = true;
            this.txtResultCountLow.Size = new System.Drawing.Size(63, 20);
            this.txtResultCountLow.TabIndex = 7;
            this.txtResultCountLow.Tag = "Low";
            this.txtResultCountLow.Text = "-";
            this.txtResultCountLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtResultCountLow.Click += new System.EventHandler(this.txtResultCountInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Critical";
            // 
            // txtResultCountCritical
            // 
            this.txtResultCountCritical.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountCritical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtResultCountCritical.Location = new System.Drawing.Point(0, 18);
            this.txtResultCountCritical.Name = "txtResultCountCritical";
            this.txtResultCountCritical.ReadOnly = true;
            this.txtResultCountCritical.Size = new System.Drawing.Size(63, 20);
            this.txtResultCountCritical.TabIndex = 1;
            this.txtResultCountCritical.Tag = "Critical";
            this.txtResultCountCritical.Text = "-";
            this.txtResultCountCritical.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtResultCountCritical.Click += new System.EventHandler(this.txtResultCountInfo_Click);
            // 
            // txtResultCountMedium
            // 
            this.txtResultCountMedium.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountMedium.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtResultCountMedium.Location = new System.Drawing.Point(124, 18);
            this.txtResultCountMedium.Name = "txtResultCountMedium";
            this.txtResultCountMedium.ReadOnly = true;
            this.txtResultCountMedium.Size = new System.Drawing.Size(63, 20);
            this.txtResultCountMedium.TabIndex = 5;
            this.txtResultCountMedium.Tag = "Medium";
            this.txtResultCountMedium.Text = "-";
            this.txtResultCountMedium.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtResultCountMedium.Click += new System.EventHandler(this.txtResultCountInfo_Click);
            // 
            // txtResultCountHigh
            // 
            this.txtResultCountHigh.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountHigh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtResultCountHigh.Location = new System.Drawing.Point(62, 18);
            this.txtResultCountHigh.Name = "txtResultCountHigh";
            this.txtResultCountHigh.ReadOnly = true;
            this.txtResultCountHigh.Size = new System.Drawing.Size(63, 20);
            this.txtResultCountHigh.TabIndex = 3;
            this.txtResultCountHigh.Tag = "High";
            this.txtResultCountHigh.Text = "-";
            this.txtResultCountHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtResultCountHigh.Click += new System.EventHandler(this.txtResultCountInfo_Click);
            // 
            // txtSnippet
            // 
            this.txtSnippet.AutoSize = true;
            this.txtSnippet.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSnippet.Location = new System.Drawing.Point(10, 426);
            this.txtSnippet.MaximumSize = new System.Drawing.Size(280, 200);
            this.txtSnippet.Name = "txtSnippet";
            this.txtSnippet.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtSnippet.Size = new System.Drawing.Size(47, 18);
            this.txtSnippet.TabIndex = 44;
            this.txtSnippet.Text = "-snippet-";
            // 
            // lblSnippet
            // 
            this.lblSnippet.AutoSize = true;
            this.lblSnippet.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSnippet.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSnippet.Location = new System.Drawing.Point(10, 408);
            this.lblSnippet.Name = "lblSnippet";
            this.lblSnippet.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblSnippet.Size = new System.Drawing.Size(43, 18);
            this.lblSnippet.TabIndex = 43;
            this.lblSnippet.Text = "Snippet";
            // 
            // txtMember
            // 
            this.txtMember.AutoSize = true;
            this.txtMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMember.Location = new System.Drawing.Point(10, 390);
            this.txtMember.MaximumSize = new System.Drawing.Size(280, 200);
            this.txtMember.Name = "txtMember";
            this.txtMember.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtMember.Size = new System.Drawing.Size(50, 18);
            this.txtMember.TabIndex = 59;
            this.txtMember.Text = "-member-";
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMember.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMember.Location = new System.Drawing.Point(10, 372);
            this.lblMember.Name = "lblMember";
            this.lblMember.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblMember.Size = new System.Drawing.Size(45, 18);
            this.lblMember.TabIndex = 58;
            this.lblMember.Text = "Member";
            // 
            // txtModule
            // 
            this.txtModule.AutoSize = true;
            this.txtModule.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtModule.Location = new System.Drawing.Point(10, 354);
            this.txtModule.MaximumSize = new System.Drawing.Size(280, 0);
            this.txtModule.Name = "txtModule";
            this.txtModule.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtModule.Size = new System.Drawing.Size(47, 18);
            this.txtModule.TabIndex = 51;
            this.txtModule.Text = "-module-";
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblModule.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblModule.Location = new System.Drawing.Point(10, 336);
            this.lblModule.Name = "lblModule";
            this.lblModule.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblModule.Size = new System.Drawing.Size(42, 18);
            this.lblModule.TabIndex = 50;
            this.lblModule.Text = "Module";
            // 
            // txtType
            // 
            this.txtType.AutoSize = true;
            this.txtType.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtType.Location = new System.Drawing.Point(10, 318);
            this.txtType.MaximumSize = new System.Drawing.Size(280, 0);
            this.txtType.Name = "txtType";
            this.txtType.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtType.Size = new System.Drawing.Size(33, 18);
            this.txtType.TabIndex = 55;
            this.txtType.Text = "-type-";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblType.Location = new System.Drawing.Point(10, 300);
            this.lblType.Name = "lblType";
            this.lblType.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblType.Size = new System.Drawing.Size(31, 18);
            this.lblType.TabIndex = 54;
            this.lblType.Text = "Type";
            // 
            // txtLine
            // 
            this.txtLine.AutoSize = true;
            this.txtLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLine.Location = new System.Drawing.Point(10, 282);
            this.txtLine.Name = "txtLine";
            this.txtLine.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtLine.Size = new System.Drawing.Size(29, 18);
            this.txtLine.TabIndex = 53;
            this.txtLine.Text = "-line-";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLine.Location = new System.Drawing.Point(10, 264);
            this.lblLine.Name = "lblLine";
            this.lblLine.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblLine.Size = new System.Drawing.Size(27, 18);
            this.lblLine.TabIndex = 52;
            this.lblLine.Text = "Line";
            // 
            // txtLocation
            // 
            this.txtLocation.AutoSize = true;
            this.txtLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLocation.Location = new System.Drawing.Point(10, 246);
            this.txtLocation.MaximumSize = new System.Drawing.Size(280, 0);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtLocation.Size = new System.Drawing.Size(50, 18);
            this.txtLocation.TabIndex = 49;
            this.txtLocation.Text = "-location-";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLocation.Location = new System.Drawing.Point(10, 228);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblLocation.Size = new System.Drawing.Size(23, 18);
            this.lblLocation.TabIndex = 48;
            this.lblLocation.Text = "File";
            // 
            // txtComponent
            // 
            this.txtComponent.AutoSize = true;
            this.txtComponent.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtComponent.Location = new System.Drawing.Point(10, 210);
            this.txtComponent.MaximumSize = new System.Drawing.Size(280, 0);
            this.txtComponent.Name = "txtComponent";
            this.txtComponent.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtComponent.Size = new System.Drawing.Size(66, 18);
            this.txtComponent.TabIndex = 61;
            this.txtComponent.Text = "-component-";
            // 
            // lblComponent
            // 
            this.lblComponent.AutoSize = true;
            this.lblComponent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComponent.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblComponent.Location = new System.Drawing.Point(10, 192);
            this.lblComponent.Name = "lblComponent";
            this.lblComponent.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblComponent.Size = new System.Drawing.Size(61, 18);
            this.lblComponent.TabIndex = 60;
            this.lblComponent.Text = "Component";
            // 
            // linkFix
            // 
            this.linkFix.AutoSize = true;
            this.linkFix.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkFix.LinkArea = new System.Windows.Forms.LinkArea(0, 16);
            this.linkFix.Location = new System.Drawing.Point(10, 174);
            this.linkFix.Name = "linkFix";
            this.linkFix.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.linkFix.Size = new System.Drawing.Size(90, 18);
            this.linkFix.TabIndex = 47;
            this.linkFix.TabStop = true;
            this.linkFix.Text = "Read more online";
            this.linkFix.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFix_LinkClicked);
            // 
            // txtFix
            // 
            this.txtFix.AutoSize = true;
            this.txtFix.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFix.Location = new System.Drawing.Point(10, 161);
            this.txtFix.MaximumSize = new System.Drawing.Size(280, 200);
            this.txtFix.Name = "txtFix";
            this.txtFix.Size = new System.Drawing.Size(23, 13);
            this.txtFix.TabIndex = 46;
            this.txtFix.Text = "-fix-";
            // 
            // lblFix
            // 
            this.lblFix.AutoSize = true;
            this.lblFix.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFix.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFix.Location = new System.Drawing.Point(10, 143);
            this.lblFix.Name = "lblFix";
            this.lblFix.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblFix.Size = new System.Drawing.Size(92, 18);
            this.lblFix.TabIndex = 45;
            this.lblFix.Text = "Recommended fix";
            // 
            // txtIssue
            // 
            this.txtIssue.AutoSize = true;
            this.txtIssue.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtIssue.Location = new System.Drawing.Point(10, 125);
            this.txtIssue.MaximumSize = new System.Drawing.Size(280, 200);
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtIssue.Size = new System.Drawing.Size(37, 18);
            this.txtIssue.TabIndex = 42;
            this.txtIssue.Text = "-issue-";
            // 
            // lblIssue
            // 
            this.lblIssue.AutoSize = true;
            this.lblIssue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIssue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIssue.Location = new System.Drawing.Point(10, 107);
            this.lblIssue.Name = "lblIssue";
            this.lblIssue.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblIssue.Size = new System.Drawing.Size(32, 18);
            this.lblIssue.TabIndex = 41;
            this.lblIssue.Text = "Issue";
            // 
            // txtCategory
            // 
            this.txtCategory.AutoSize = true;
            this.txtCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCategory.Location = new System.Drawing.Point(10, 89);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtCategory.Size = new System.Drawing.Size(54, 18);
            this.txtCategory.TabIndex = 57;
            this.txtCategory.Text = "-category-";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCategory.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCategory.Location = new System.Drawing.Point(10, 71);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblCategory.Size = new System.Drawing.Size(49, 18);
            this.lblCategory.TabIndex = 56;
            this.lblCategory.Text = "Category";
            // 
            // txtRule
            // 
            this.txtRule.AutoSize = true;
            this.txtRule.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRule.Location = new System.Drawing.Point(10, 53);
            this.txtRule.Name = "txtRule";
            this.txtRule.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtRule.Size = new System.Drawing.Size(59, 18);
            this.txtRule.TabIndex = 40;
            this.txtRule.Text = "-rule name-";
            // 
            // lblRule
            // 
            this.lblRule.AutoSize = true;
            this.lblRule.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRule.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRule.Location = new System.Drawing.Point(10, 35);
            this.lblRule.Name = "lblRule";
            this.lblRule.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblRule.Size = new System.Drawing.Size(29, 18);
            this.lblRule.TabIndex = 39;
            this.lblRule.Text = "Rule";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDetailHeader);
            this.panel2.Controls.Add(this.picDetailClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 35);
            this.panel2.TabIndex = 38;
            // 
            // lblDetailHeader
            // 
            this.lblDetailHeader.AutoSize = true;
            this.lblDetailHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDetailHeader.Location = new System.Drawing.Point(0, 6);
            this.lblDetailHeader.Name = "lblDetailHeader";
            this.lblDetailHeader.Size = new System.Drawing.Size(65, 24);
            this.lblDetailHeader.TabIndex = 37;
            this.lblDetailHeader.Text = "Details";
            // 
            // picDetailClose
            // 
            this.picDetailClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picDetailClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDetailClose.Image = ((System.Drawing.Image)(resources.GetObject("picDetailClose.Image")));
            this.picDetailClose.Location = new System.Drawing.Point(298, 9);
            this.picDetailClose.Name = "picDetailClose";
            this.picDetailClose.Size = new System.Drawing.Size(16, 16);
            this.picDetailClose.TabIndex = 36;
            this.picDetailClose.TabStop = false;
            this.picDetailClose.Click += new System.EventHandler(this.picDetailClose_Click);
            // 
            // tabSarif
            // 
            this.tabSarif.Controls.Add(this.txtSarif);
            this.tabSarif.Controls.Add(this.panel1);
            this.tabSarif.Location = new System.Drawing.Point(4, 22);
            this.tabSarif.Name = "tabSarif";
            this.tabSarif.Padding = new System.Windows.Forms.Padding(3);
            this.tabSarif.Size = new System.Drawing.Size(1024, 460);
            this.tabSarif.TabIndex = 1;
            this.tabSarif.Text = "SARIF File";
            this.tabSarif.UseVisualStyleBackColor = true;
            // 
            // txtSarif
            // 
            this.txtSarif.BackColor = System.Drawing.SystemColors.Window;
            this.txtSarif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSarif.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSarif.Location = new System.Drawing.Point(3, 47);
            this.txtSarif.Name = "txtSarif";
            this.txtSarif.ReadOnly = true;
            this.txtSarif.Size = new System.Drawing.Size(1018, 410);
            this.txtSarif.TabIndex = 0;
            this.txtSarif.Text = "";
            this.txtSarif.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpenSarif);
            this.panel1.Controls.Add(this.txtResultFile);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnSaveSarif);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 44);
            this.panel1.TabIndex = 1;
            // 
            // btnOpenSarif
            // 
            this.btnOpenSarif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSarif.BackColor = System.Drawing.SystemColors.Window;
            this.btnOpenSarif.Location = new System.Drawing.Point(857, 10);
            this.btnOpenSarif.Name = "btnOpenSarif";
            this.btnOpenSarif.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSarif.TabIndex = 46;
            this.btnOpenSarif.Text = "Open";
            this.btnOpenSarif.UseVisualStyleBackColor = false;
            this.btnOpenSarif.Click += new System.EventHandler(this.btnOpenSarif_Click);
            // 
            // txtResultFile
            // 
            this.txtResultFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultFile.Location = new System.Drawing.Point(98, 12);
            this.txtResultFile.Name = "txtResultFile";
            this.txtResultFile.ReadOnly = true;
            this.txtResultFile.Size = new System.Drawing.Size(753, 20);
            this.txtResultFile.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "SARIF file";
            // 
            // btnSaveSarif
            // 
            this.btnSaveSarif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSarif.BackColor = System.Drawing.SystemColors.Window;
            this.btnSaveSarif.Location = new System.Drawing.Point(938, 10);
            this.btnSaveSarif.Name = "btnSaveSarif";
            this.btnSaveSarif.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSarif.TabIndex = 41;
            this.btnSaveSarif.Text = "Save";
            this.btnSaveSarif.UseVisualStyleBackColor = false;
            this.btnSaveSarif.Click += new System.EventHandler(this.btnSaveSarif_Click);
            // 
            // tabTech
            // 
            this.tabTech.Controls.Add(this.txtEndTime);
            this.tabTech.Controls.Add(this.label18);
            this.tabTech.Controls.Add(this.txtStartTime);
            this.tabTech.Controls.Add(this.label17);
            this.tabTech.Controls.Add(this.label16);
            this.tabTech.Controls.Add(this.dgSolutions);
            this.tabTech.Controls.Add(this.label15);
            this.tabTech.Controls.Add(this.txtExclusions);
            this.tabTech.Controls.Add(this.label14);
            this.tabTech.Controls.Add(this.txtRulesets);
            this.tabTech.Controls.Add(this.label9);
            this.tabTech.Controls.Add(this.lbRules);
            this.tabTech.Controls.Add(this.label8);
            this.tabTech.Controls.Add(this.txtCorrId);
            this.tabTech.Controls.Add(this.label10);
            this.tabTech.Controls.Add(this.txtStatusUrl);
            this.tabTech.Controls.Add(this.label11);
            this.tabTech.Controls.Add(this.txtRunCorrId);
            this.tabTech.Location = new System.Drawing.Point(4, 22);
            this.tabTech.Name = "tabTech";
            this.tabTech.Size = new System.Drawing.Size(1024, 460);
            this.tabTech.TabIndex = 2;
            this.tabTech.Text = "Analysis Details";
            this.tabTech.UseVisualStyleBackColor = true;
            // 
            // txtEndTime
            // 
            this.txtEndTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndTime.Location = new System.Drawing.Point(480, 44);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(143, 20);
            this.txtEndTime.TabIndex = 56;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(393, 47);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 13);
            this.label18.TabIndex = 57;
            this.label18.Text = "End Time";
            // 
            // txtStartTime
            // 
            this.txtStartTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartTime.Location = new System.Drawing.Point(480, 18);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(143, 20);
            this.txtStartTime.TabIndex = 54;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(393, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 55;
            this.label17.Text = "Start Time";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 303);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 53;
            this.label16.Text = "Solutions";
            // 
            // dgSolutions
            // 
            this.dgSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSolutions.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgSolutions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSolutions.Location = new System.Drawing.Point(154, 300);
            this.dgSolutions.Name = "dgSolutions";
            this.dgSolutions.ReadOnly = true;
            this.dgSolutions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSolutions.Size = new System.Drawing.Size(753, 150);
            this.dgSolutions.TabIndex = 52;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "File Exclusions";
            // 
            // txtExclusions
            // 
            this.txtExclusions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExclusions.BackColor = System.Drawing.SystemColors.Window;
            this.txtExclusions.Location = new System.Drawing.Point(154, 96);
            this.txtExclusions.Name = "txtExclusions";
            this.txtExclusions.ReadOnly = true;
            this.txtExclusions.Size = new System.Drawing.Size(753, 20);
            this.txtExclusions.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Rulesets";
            // 
            // txtRulesets
            // 
            this.txtRulesets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRulesets.BackColor = System.Drawing.SystemColors.Window;
            this.txtRulesets.Location = new System.Drawing.Point(154, 122);
            this.txtRulesets.Name = "txtRulesets";
            this.txtRulesets.ReadOnly = true;
            this.txtRulesets.Size = new System.Drawing.Size(753, 20);
            this.txtRulesets.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Rules";
            // 
            // lbRules
            // 
            this.lbRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRules.FormattingEnabled = true;
            this.lbRules.Location = new System.Drawing.Point(154, 148);
            this.lbRules.Name = "lbRules";
            this.lbRules.Size = new System.Drawing.Size(469, 147);
            this.lbRules.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Analysis Correlation Id";
            // 
            // txtCorrId
            // 
            this.txtCorrId.BackColor = System.Drawing.SystemColors.Window;
            this.txtCorrId.Location = new System.Drawing.Point(154, 18);
            this.txtCorrId.Name = "txtCorrId";
            this.txtCorrId.ReadOnly = true;
            this.txtCorrId.Size = new System.Drawing.Size(219, 20);
            this.txtCorrId.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Status Url";
            // 
            // txtStatusUrl
            // 
            this.txtStatusUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatusUrl.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatusUrl.Location = new System.Drawing.Point(154, 70);
            this.txtStatusUrl.Name = "txtStatusUrl";
            this.txtStatusUrl.ReadOnly = true;
            this.txtStatusUrl.Size = new System.Drawing.Size(753, 20);
            this.txtStatusUrl.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Run Correlation Id";
            // 
            // txtRunCorrId
            // 
            this.txtRunCorrId.BackColor = System.Drawing.SystemColors.Window;
            this.txtRunCorrId.Location = new System.Drawing.Point(154, 44);
            this.txtRunCorrId.Name = "txtRunCorrId";
            this.txtRunCorrId.ReadOnly = true;
            this.txtRunCorrId.Size = new System.Drawing.Size(219, 20);
            this.txtRunCorrId.TabIndex = 37;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.dgArtifacts);
            this.tabFiles.Location = new System.Drawing.Point(4, 22);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Size = new System.Drawing.Size(1024, 460);
            this.tabFiles.TabIndex = 3;
            this.tabFiles.Text = "Analyzed Files";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // dgArtifacts
            // 
            this.dgArtifacts.AllowUserToAddRows = false;
            this.dgArtifacts.AllowUserToDeleteRows = false;
            this.dgArtifacts.AllowUserToOrderColumns = true;
            this.dgArtifacts.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgArtifacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArtifacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgArtifacts.Location = new System.Drawing.Point(0, 0);
            this.dgArtifacts.Name = "dgArtifacts";
            this.dgArtifacts.ReadOnly = true;
            this.dgArtifacts.RowHeadersVisible = false;
            this.dgArtifacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgArtifacts.Size = new System.Drawing.Size(1024, 460);
            this.dgArtifacts.TabIndex = 0;
            // 
            // tmStatus
            // 
            this.tmStatus.Interval = 5000;
            this.tmStatus.Tick += new System.EventHandler(this.tmStatus_Tick);
            // 
            // SarifControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1032, 486);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.tabControlResults);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.HideOnClose = true;
            this.MinimizeBox = false;
            this.Name = "SarifControl";
            this.TabText = "SARIF analyzer";
            this.Text = "SARIF analyzer";
            this.tabControlResults.ResumeLayout(false);
            this.tabResults.ResumeLayout(false);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.panAnalyzing.ResumeLayout(false);
            this.panAnalyzing2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailOpen)).EndInit();
            this.panStatus.ResumeLayout(false);
            this.panStatus.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailClose)).EndInit();
            this.tabSarif.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabTech.ResumeLayout(false);
            this.tabTech.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSolutions)).EndInit();
            this.tabFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgArtifacts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlResults;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.TabPage tabSarif;
        private System.Windows.Forms.RichTextBox txtSarif;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtResultFile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar progAnalysis;
        private System.Windows.Forms.TextBox txtStatusUrl;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRunCorrId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSaveSarif;
        private System.Windows.Forms.TextBox txtResultCountCritical;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResultCountInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResultCountLow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResultCountMedium;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResultCountHigh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmStatus;
        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.Button btnOpenSarif;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabTech;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCorrId;
        private System.Windows.Forms.ListBox lbRules;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRulesets;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtExclusions;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgSolutions;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.DataGridView dgArtifacts;
        private System.Windows.Forms.Panel panStatus;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeverity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.PictureBox picDetailClose;
        private System.Windows.Forms.Label lblDetailHeader;
        private System.Windows.Forms.Label txtIssue;
        private System.Windows.Forms.Label lblIssue;
        private System.Windows.Forms.Label txtRule;
        private System.Windows.Forms.Label lblRule;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSnippet;
        private System.Windows.Forms.Label txtSnippet;
        private System.Windows.Forms.Label txtFix;
        private System.Windows.Forms.Label lblFix;
        private System.Windows.Forms.Label txtLine;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label txtModule;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.Label txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.LinkLabel linkFix;
        private System.Windows.Forms.Label txtType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label txtCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.PictureBox picDetailOpen;
        private System.Windows.Forms.ComboBox cbSeverity;
        private System.Windows.Forms.ComboBox cbRule;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.ComboBox cbComponent;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label txtMember;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Label txtComponent;
        private System.Windows.Forms.Label lblComponent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panAnalyzing2;
        internal System.Windows.Forms.Panel panAnalyzing;
    }
}
