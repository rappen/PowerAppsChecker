namespace Rappen.XTB.PAC.DockControls
{
    partial class SolutionControl
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
            this.cbSolution = new xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.linkUploaded = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCorrId = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSolution
            // 
            this.cbSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSolution.BackColor = System.Drawing.SystemColors.Window;
            this.cbSolution.DisplayFormat = "{{friendlyname}} ({{uniquename}}) {{version}}";
            this.cbSolution.FormattingEnabled = true;
            this.cbSolution.Location = new System.Drawing.Point(94, 11);
            this.cbSolution.Name = "cbSolution";
            this.cbSolution.Size = new System.Drawing.Size(304, 21);
            this.cbSolution.TabIndex = 1;
            this.cbSolution.SelectedIndexChanged += new System.EventHandler(this.cdSolution_SelectedIndexChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.SystemColors.Window;
            this.btnUpload.Location = new System.Drawing.Point(404, 36);
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
            this.btnExport.Location = new System.Drawing.Point(404, 9);
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
            this.linkUploaded.Location = new System.Drawing.Point(94, 90);
            this.linkUploaded.Name = "linkUploaded";
            this.linkUploaded.Size = new System.Drawing.Size(385, 20);
            this.linkUploaded.TabIndex = 7;
            this.linkUploaded.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUploaded_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Uploaded File";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.BackColor = System.Drawing.SystemColors.Window;
            this.txtFilename.Enabled = false;
            this.txtFilename.Location = new System.Drawing.Point(94, 38);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(271, 20);
            this.txtFilename.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
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
            this.txtCorrId.Location = new System.Drawing.Point(94, 64);
            this.txtCorrId.Name = "txtCorrId";
            this.txtCorrId.ReadOnly = true;
            this.txtCorrId.Size = new System.Drawing.Size(385, 20);
            this.txtCorrId.TabIndex = 6;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.Window;
            this.btnOpenFile.Location = new System.Drawing.Point(371, 36);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(27, 23);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Filename";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Solution";
            // 
            // SolutionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 111);
            this.Controls.Add(this.cbSolution);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linkUploaded);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCorrId);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HideOnClose = true;
            this.MaximumSize = new System.Drawing.Size(10000, 150);
            this.MinimumSize = new System.Drawing.Size(0, 150);
            this.Name = "SolutionControl";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TabText = "Solution";
            this.Text = "Solution";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox cbSolution;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.LinkLabel linkUploaded;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCorrId;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
