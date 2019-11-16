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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SarifControl));
            this.tabControlResults = new System.Windows.Forms.TabControl();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.colSeverity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSnippet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panTop = new System.Windows.Forms.Panel();
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
            this.dgGrouper = new Subro.Controls.DataGridViewGrouper(this.components);
            this.tmStatus = new System.Windows.Forms.Timer(this.components);
            this.picRuleHelp = new System.Windows.Forms.PictureBox();
            this.txtHowToFix = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tabControlResults.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.panTop.SuspendLayout();
            this.panStatus.SuspendLayout();
            this.tabSarif.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabTech.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSolutions)).BeginInit();
            this.tabFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArtifacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRuleHelp)).BeginInit();
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
            this.tabControlResults.Size = new System.Drawing.Size(934, 486);
            this.tabControlResults.TabIndex = 10;
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.splitContainer1);
            this.tabResults.Controls.Add(this.panTop);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(926, 460);
            this.tabResults.TabIndex = 0;
            this.tabResults.Text = "Results";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 64);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgResults);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtHowToFix);
            this.splitContainer1.Panel2.Controls.Add(this.label19);
            this.splitContainer1.Panel2.Controls.Add(this.picRuleHelp);
            this.splitContainer1.Panel2.Controls.Add(this.txtSnippet);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.txtMessage);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Size = new System.Drawing.Size(920, 393);
            this.splitContainer1.SplitterDistance = 298;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 3;
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
            this.colSeverity,
            this.colRule,
            this.colCategory,
            this.colModule,
            this.colFile,
            this.colStartLine});
            this.dgResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgResults.Location = new System.Drawing.Point(0, 0);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.RowHeadersVisible = false;
            this.dgResults.Size = new System.Drawing.Size(920, 298);
            this.dgResults.TabIndex = 1;
            this.dgResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResults_CellDoubleClick);
            this.dgResults.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResults_CellEnter);
            this.dgResults.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgResults_ColumnHeaderMouseClick);
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
            // colModule
            // 
            this.colModule.DataPropertyName = "Module";
            this.colModule.HeaderText = "Module";
            this.colModule.Name = "colModule";
            this.colModule.ReadOnly = true;
            this.colModule.Width = 200;
            // 
            // colFile
            // 
            this.colFile.DataPropertyName = "FilePath";
            this.colFile.HeaderText = "File";
            this.colFile.Name = "colFile";
            this.colFile.ReadOnly = true;
            this.colFile.Width = 200;
            // 
            // colStartLine
            // 
            this.colStartLine.DataPropertyName = "StartLine";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colStartLine.DefaultCellStyle = dataGridViewCellStyle2;
            this.colStartLine.HeaderText = "Line";
            this.colStartLine.Name = "colStartLine";
            this.colStartLine.ReadOnly = true;
            this.colStartLine.Width = 50;
            // 
            // txtSnippet
            // 
            this.txtSnippet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSnippet.BackColor = System.Drawing.SystemColors.Window;
            this.txtSnippet.Location = new System.Drawing.Point(95, 31);
            this.txtSnippet.Multiline = true;
            this.txtSnippet.Name = "txtSnippet";
            this.txtSnippet.ReadOnly = true;
            this.txtSnippet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSnippet.Size = new System.Drawing.Size(816, 23);
            this.txtSnippet.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Snippet";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtMessage.Location = new System.Drawing.Point(95, 5);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(816, 20);
            this.txtMessage.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Message";
            // 
            // panTop
            // 
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
            this.panTop.Location = new System.Drawing.Point(3, 3);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(920, 61);
            this.panTop.TabIndex = 2;
            this.panTop.Visible = false;
            // 
            // panStatus
            // 
            this.panStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panStatus.Controls.Add(this.progAnalysis);
            this.panStatus.Controls.Add(this.txtStatus);
            this.panStatus.Controls.Add(this.label12);
            this.panStatus.Location = new System.Drawing.Point(317, 10);
            this.panStatus.Name = "panStatus";
            this.panStatus.Size = new System.Drawing.Size(604, 43);
            this.panStatus.TabIndex = 45;
            // 
            // progAnalysis
            // 
            this.progAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progAnalysis.BackColor = System.Drawing.SystemColors.Window;
            this.progAnalysis.Location = new System.Drawing.Point(108, 16);
            this.progAnalysis.Name = "progAnalysis";
            this.progAnalysis.Size = new System.Drawing.Size(493, 20);
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
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Info";
            // 
            // txtResultCountInfo
            // 
            this.txtResultCountInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtResultCountInfo.Location = new System.Drawing.Point(248, 26);
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
            this.label4.Location = new System.Drawing.Point(206, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Low";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Medium";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "High";
            // 
            // txtResultCountLow
            // 
            this.txtResultCountLow.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountLow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtResultCountLow.Location = new System.Drawing.Point(186, 26);
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
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Critical";
            // 
            // txtResultCountCritical
            // 
            this.txtResultCountCritical.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountCritical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtResultCountCritical.Location = new System.Drawing.Point(0, 26);
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
            this.txtResultCountMedium.Location = new System.Drawing.Point(124, 26);
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
            this.txtResultCountHigh.Location = new System.Drawing.Point(62, 26);
            this.txtResultCountHigh.Name = "txtResultCountHigh";
            this.txtResultCountHigh.ReadOnly = true;
            this.txtResultCountHigh.Size = new System.Drawing.Size(63, 20);
            this.txtResultCountHigh.TabIndex = 3;
            this.txtResultCountHigh.Tag = "High";
            this.txtResultCountHigh.Text = "-";
            this.txtResultCountHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtResultCountHigh.Click += new System.EventHandler(this.txtResultCountInfo_Click);
            // 
            // tabSarif
            // 
            this.tabSarif.Controls.Add(this.txtSarif);
            this.tabSarif.Controls.Add(this.panel1);
            this.tabSarif.Location = new System.Drawing.Point(4, 22);
            this.tabSarif.Name = "tabSarif";
            this.tabSarif.Padding = new System.Windows.Forms.Padding(3);
            this.tabSarif.Size = new System.Drawing.Size(926, 460);
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
            this.txtSarif.Size = new System.Drawing.Size(920, 410);
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
            this.panel1.Size = new System.Drawing.Size(920, 44);
            this.panel1.TabIndex = 1;
            // 
            // btnOpenSarif
            // 
            this.btnOpenSarif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSarif.BackColor = System.Drawing.SystemColors.Window;
            this.btnOpenSarif.Location = new System.Drawing.Point(759, 10);
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
            this.txtResultFile.Size = new System.Drawing.Size(655, 20);
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
            this.btnSaveSarif.Location = new System.Drawing.Point(840, 10);
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
            this.tabTech.Size = new System.Drawing.Size(926, 460);
            this.tabTech.TabIndex = 2;
            this.tabTech.Text = "Analysis Details";
            this.tabTech.UseVisualStyleBackColor = true;
            // 
            // txtEndTime
            // 
            this.txtEndTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndTime.Location = new System.Drawing.Point(576, 18);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(254, 20);
            this.txtEndTime.TabIndex = 56;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(439, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 13);
            this.label18.TabIndex = 57;
            this.label18.Text = "End Time";
            // 
            // txtStartTime
            // 
            this.txtStartTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartTime.Location = new System.Drawing.Point(154, 18);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(254, 20);
            this.txtStartTime.TabIndex = 54;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 21);
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
            this.lbRules.Size = new System.Drawing.Size(386, 134);
            this.lbRules.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Analysis Correlation Id";
            // 
            // txtCorrId
            // 
            this.txtCorrId.BackColor = System.Drawing.SystemColors.Window;
            this.txtCorrId.Location = new System.Drawing.Point(154, 44);
            this.txtCorrId.Name = "txtCorrId";
            this.txtCorrId.ReadOnly = true;
            this.txtCorrId.Size = new System.Drawing.Size(254, 20);
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
            this.label11.Location = new System.Drawing.Point(439, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Run Correlation Id";
            // 
            // txtRunCorrId
            // 
            this.txtRunCorrId.BackColor = System.Drawing.SystemColors.Window;
            this.txtRunCorrId.Location = new System.Drawing.Point(576, 44);
            this.txtRunCorrId.Name = "txtRunCorrId";
            this.txtRunCorrId.ReadOnly = true;
            this.txtRunCorrId.Size = new System.Drawing.Size(254, 20);
            this.txtRunCorrId.TabIndex = 37;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.dgArtifacts);
            this.tabFiles.Location = new System.Drawing.Point(4, 22);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Size = new System.Drawing.Size(926, 460);
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
            this.dgArtifacts.Size = new System.Drawing.Size(926, 460);
            this.dgArtifacts.TabIndex = 0;
            // 
            // dgGrouper
            // 
            this.dgGrouper.DataGridView = this.dgResults;
            this.dgGrouper.Options = ((Subro.Controls.GroupingOptions)(resources.GetObject("dgGrouper.Options")));
            // 
            // tmStatus
            // 
            this.tmStatus.Interval = 5000;
            this.tmStatus.Tick += new System.EventHandler(this.tmStatus_Tick);
            // 
            // picRuleHelp
            // 
            this.picRuleHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picRuleHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRuleHelp.Image = ((System.Drawing.Image)(resources.GetObject("picRuleHelp.Image")));
            this.picRuleHelp.Location = new System.Drawing.Point(887, 58);
            this.picRuleHelp.Name = "picRuleHelp";
            this.picRuleHelp.Size = new System.Drawing.Size(24, 24);
            this.picRuleHelp.TabIndex = 32;
            this.picRuleHelp.TabStop = false;
            this.picRuleHelp.Click += new System.EventHandler(this.picRuleHelp_Click);
            // 
            // txtHowToFix
            // 
            this.txtHowToFix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHowToFix.BackColor = System.Drawing.SystemColors.Window;
            this.txtHowToFix.Location = new System.Drawing.Point(95, 60);
            this.txtHowToFix.Name = "txtHowToFix";
            this.txtHowToFix.ReadOnly = true;
            this.txtHowToFix.Size = new System.Drawing.Size(786, 20);
            this.txtHowToFix.TabIndex = 34;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "How To Fix";
            // 
            // SarifControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(934, 486);
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panStatus.ResumeLayout(false);
            this.panStatus.PerformLayout();
            this.tabSarif.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabTech.ResumeLayout(false);
            this.tabTech.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSolutions)).EndInit();
            this.tabFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgArtifacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRuleHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlResults;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.TabPage tabSarif;
        private System.Windows.Forms.RichTextBox txtSarif;
        private Subro.Controls.DataGridViewGrouper dgGrouper;
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSnippet;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartLine;
        private System.Windows.Forms.PictureBox picRuleHelp;
        private System.Windows.Forms.TextBox txtHowToFix;
        private System.Windows.Forms.Label label19;
    }
}
