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
            this.gbSolution = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbSolution = new xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.linkUploaded = new System.Windows.Forms.LinkLabel();
            this.dockContainer = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbCloseThisTab = new System.Windows.Forms.ToolStripButton();
            this.btnResetWindows = new System.Windows.Forms.ToolStripButton();
            this.btnAnalyze = new System.Windows.Forms.ToolStripButton();
            this.gbAPI.SuspendLayout();
            this.gbSolution.SuspendLayout();
            this.toolStrip.SuspendLayout();
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
            // gbAPI
            // 
            this.gbAPI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbAPI.Controls.Add(this.llFileOptionsExpander);
            this.gbAPI.Controls.Add(this.btnConnectPAC);
            this.gbAPI.Controls.Add(this.label3);
            this.gbAPI.Controls.Add(this.txtClientSec);
            this.gbAPI.Controls.Add(this.label2);
            this.gbAPI.Controls.Add(this.txtClientId);
            this.gbAPI.Controls.Add(this.txtTenantId);
            this.gbAPI.Controls.Add(this.label1);
            this.gbAPI.Location = new System.Drawing.Point(3, 643);
            this.gbAPI.Name = "gbAPI";
            this.gbAPI.Size = new System.Drawing.Size(434, 135);
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
            this.txtCorrId.Size = new System.Drawing.Size(532, 20);
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
            this.txtFilename.Size = new System.Drawing.Size(418, 20);
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
            this.btnOpenFile.Location = new System.Drawing.Point(519, 51);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(27, 23);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // gbSolution
            // 
            this.gbSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.gbSolution.Location = new System.Drawing.Point(443, 643);
            this.gbSolution.Name = "gbSolution";
            this.gbSolution.Size = new System.Drawing.Size(639, 135);
            this.gbSolution.TabIndex = 3;
            this.gbSolution.TabStop = false;
            this.gbSolution.Text = "Solution";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(604, 0);
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
            this.cbSolution.Size = new System.Drawing.Size(451, 21);
            this.cbSolution.TabIndex = 1;
            this.cbSolution.SelectedIndexChanged += new System.EventHandler(this.cdSolution_SelectedItemChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.SystemColors.Window;
            this.btnUpload.Location = new System.Drawing.Point(552, 51);
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
            this.btnExport.Location = new System.Drawing.Point(552, 24);
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
            this.linkUploaded.Size = new System.Drawing.Size(532, 20);
            this.linkUploaded.TabIndex = 7;
            this.linkUploaded.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUploaded_LinkClicked);
            // 
            // dockContainer
            // 
            this.dockContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dockContainer.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockContainer.Location = new System.Drawing.Point(3, 34);
            this.dockContainer.Name = "dockContainer";
            this.dockContainer.Size = new System.Drawing.Size(1089, 603);
            this.dockContainer.TabIndex = 25;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Window;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCloseThisTab,
            this.btnResetWindows,
            this.btnAnalyze});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1095, 31);
            this.toolStrip.TabIndex = 27;
            // 
            // tsbCloseThisTab
            // 
            this.tsbCloseThisTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloseThisTab.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseThisTab.Image")));
            this.tsbCloseThisTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseThisTab.Name = "tsbCloseThisTab";
            this.tsbCloseThisTab.Size = new System.Drawing.Size(28, 28);
            this.tsbCloseThisTab.Text = "Close this tab";
            this.tsbCloseThisTab.Click += new System.EventHandler(this.tsbCloseThisTab_Click);
            // 
            // btnResetWindows
            // 
            this.btnResetWindows.Image = ((System.Drawing.Image)(resources.GetObject("btnResetWindows.Image")));
            this.btnResetWindows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResetWindows.Name = "btnResetWindows";
            this.btnResetWindows.Size = new System.Drawing.Size(113, 28);
            this.btnResetWindows.Text = "Reset windows";
            this.btnResetWindows.Click += new System.EventHandler(this.btnResetWindows_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Image = ((System.Drawing.Image)(resources.GetObject("btnAnalyze.Image")));
            this.btnAnalyze.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(76, 28);
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // PAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.gbAPI);
            this.Controls.Add(this.gbSolution);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dockContainer);
            this.Name = "PAC";
            this.Size = new System.Drawing.Size(1095, 781);
            this.Load += new System.EventHandler(this.PAC_Load);
            this.gbAPI.ResumeLayout(false);
            this.gbAPI.PerformLayout();
            this.gbSolution.ResumeLayout(false);
            this.gbSolution.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenantId;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientSec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbAPI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCorrId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbSolution;
        private System.Windows.Forms.Button btnConnectPAC;
        private System.Windows.Forms.LinkLabel linkUploaded;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnUpload;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox cbSolution;
        private System.Windows.Forms.LinkLabel llFileOptionsExpander;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockContainer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbCloseThisTab;
        private System.Windows.Forms.ToolStripButton btnResetWindows;
        private System.Windows.Forms.ToolStripButton btnAnalyze;
    }
}
