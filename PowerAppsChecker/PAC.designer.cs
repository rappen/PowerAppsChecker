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
            this.dockContainer = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnConnectPAC = new System.Windows.Forms.ToolStripButton();
            this.btnSelectSolutions = new System.Windows.Forms.ToolStripButton();
            this.btnAnalyze = new System.Windows.Forms.ToolStripButton();
            this.tslByJonas = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockContainer
            // 
            this.dockContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dockContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockContainer.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockContainer.Location = new System.Drawing.Point(0, 31);
            this.dockContainer.Name = "dockContainer";
            this.dockContainer.Size = new System.Drawing.Size(747, 335);
            this.dockContainer.TabIndex = 25;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Window;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnectPAC,
            this.btnSelectSolutions,
            this.btnAnalyze,
            this.tslByJonas});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(747, 31);
            this.toolStrip.TabIndex = 27;
            // 
            // btnConnectPAC
            // 
            this.btnConnectPAC.Image = ((System.Drawing.Image)(resources.GetObject("btnConnectPAC.Image")));
            this.btnConnectPAC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnectPAC.Name = "btnConnectPAC";
            this.btnConnectPAC.Size = new System.Drawing.Size(105, 28);
            this.btnConnectPAC.Text = "Connect PAC";
            this.btnConnectPAC.Click += new System.EventHandler(this.btnConnectPAC_Click);
            // 
            // btnSelectSolutions
            // 
            this.btnSelectSolutions.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectSolutions.Image")));
            this.btnSelectSolutions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectSolutions.Name = "btnSelectSolutions";
            this.btnSelectSolutions.Size = new System.Drawing.Size(113, 28);
            this.btnSelectSolutions.Text = "Select Solution";
            this.btnSelectSolutions.Click += new System.EventHandler(this.btnSelectSolutions_Click);
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
            // tslByJonas
            // 
            this.tslByJonas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslByJonas.Image = ((System.Drawing.Image)(resources.GetObject("tslByJonas.Image")));
            this.tslByJonas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tslByJonas.IsLink = true;
            this.tslByJonas.Name = "tslByJonas";
            this.tslByJonas.Size = new System.Drawing.Size(106, 28);
            this.tslByJonas.Text = "by Jonas Rapp";
            this.tslByJonas.Click += new System.EventHandler(this.tslByJonas_Click);
            // 
            // PAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.dockContainer);
            this.Controls.Add(this.toolStrip);
            this.Name = "PAC";
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(747, 366);
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.OnCloseTool += new System.EventHandler(this.PAC_OnCloseTool);
            this.Load += new System.EventHandler(this.PAC_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockContainer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAnalyze;
        private System.Windows.Forms.ToolStripButton btnConnectPAC;
        private System.Windows.Forms.ToolStripButton btnSelectSolutions;
        private System.Windows.Forms.ToolStripLabel tslByJonas;
    }
}
