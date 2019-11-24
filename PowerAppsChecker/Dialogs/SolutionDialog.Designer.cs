namespace Rappen.XTB.PAC.Dialogs
{
    partial class SolutionDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbSolution = new xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panLocal = new System.Windows.Forms.Panel();
            this.panOrgSolution = new System.Windows.Forms.Panel();
            this.panSource = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbLocal = new System.Windows.Forms.RadioButton();
            this.rbOrg = new System.Windows.Forms.RadioButton();
            this.btnAddSolution = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panLocal.SuspendLayout();
            this.panOrgSolution.SuspendLayout();
            this.panSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSolution
            // 
            this.cbSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSolution.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSolution.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSolution.BackColor = System.Drawing.SystemColors.Window;
            this.cbSolution.DisplayFormat = "{{friendlyname}} ({{uniquename}}) {{version}}";
            this.cbSolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSolution.FormattingEnabled = true;
            this.cbSolution.Location = new System.Drawing.Point(105, 3);
            this.cbSolution.Name = "cbSolution";
            this.cbSolution.Size = new System.Drawing.Size(392, 21);
            this.cbSolution.TabIndex = 23;
            this.cbSolution.SelectedIndexChanged += new System.EventHandler(this.inputs_Changed);
            this.cbSolution.Leave += new System.EventHandler(this.inputs_Changed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Solution";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Filename";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.Window;
            this.btnOpenFile.Location = new System.Drawing.Point(454, 2);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(43, 22);
            this.btnOpenFile.TabIndex = 26;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.BackColor = System.Drawing.SystemColors.Window;
            this.txtFilename.Location = new System.Drawing.Point(105, 3);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(343, 20);
            this.txtFilename.TabIndex = 25;
            this.txtFilename.TextChanged += new System.EventHandler(this.inputs_Changed);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 33);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.SystemColors.Window;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(397, 148);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(135, 33);
            this.btnOK.TabIndex = 34;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panLocal);
            this.groupBox1.Controls.Add(this.panOrgSolution);
            this.groupBox1.Controls.Add(this.panSource);
            this.groupBox1.Controls.Add(this.btnAddSolution);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 93);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solution";
            // 
            // panLocal
            // 
            this.panLocal.Controls.Add(this.label6);
            this.panLocal.Controls.Add(this.txtFilename);
            this.panLocal.Controls.Add(this.btnOpenFile);
            this.panLocal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panLocal.Location = new System.Drawing.Point(3, 76);
            this.panLocal.Name = "panLocal";
            this.panLocal.Size = new System.Drawing.Size(517, 26);
            this.panLocal.TabIndex = 21;
            this.panLocal.Visible = false;
            // 
            // panOrgSolution
            // 
            this.panOrgSolution.Controls.Add(this.label7);
            this.panOrgSolution.Controls.Add(this.cbSolution);
            this.panOrgSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.panOrgSolution.Location = new System.Drawing.Point(3, 50);
            this.panOrgSolution.Name = "panOrgSolution";
            this.panOrgSolution.Size = new System.Drawing.Size(517, 26);
            this.panOrgSolution.TabIndex = 20;
            // 
            // panSource
            // 
            this.panSource.Controls.Add(this.label1);
            this.panSource.Controls.Add(this.rbLocal);
            this.panSource.Controls.Add(this.rbOrg);
            this.panSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSource.Location = new System.Drawing.Point(3, 16);
            this.panSource.Name = "panSource";
            this.panSource.Size = new System.Drawing.Size(517, 34);
            this.panSource.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Source";
            // 
            // rbLocal
            // 
            this.rbLocal.AutoSize = true;
            this.rbLocal.Location = new System.Drawing.Point(240, 12);
            this.rbLocal.Name = "rbLocal";
            this.rbLocal.Size = new System.Drawing.Size(70, 17);
            this.rbLocal.TabIndex = 18;
            this.rbLocal.Text = "Local File";
            this.rbLocal.UseVisualStyleBackColor = true;
            this.rbLocal.CheckedChanged += new System.EventHandler(this.rbSource_CheckedChanged);
            // 
            // rbOrg
            // 
            this.rbOrg.AutoSize = true;
            this.rbOrg.Checked = true;
            this.rbOrg.Location = new System.Drawing.Point(105, 12);
            this.rbOrg.Name = "rbOrg";
            this.rbOrg.Size = new System.Drawing.Size(119, 17);
            this.rbOrg.TabIndex = 17;
            this.rbOrg.TabStop = true;
            this.rbOrg.Text = "CDS/Dynamics 365";
            this.rbOrg.UseVisualStyleBackColor = true;
            this.rbOrg.CheckedChanged += new System.EventHandler(this.rbSource_CheckedChanged);
            // 
            // btnAddSolution
            // 
            this.btnAddSolution.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddSolution.BackColor = System.Drawing.SystemColors.Window;
            this.btnAddSolution.Enabled = false;
            this.btnAddSolution.Location = new System.Drawing.Point(190, 117);
            this.btnAddSolution.Name = "btnAddSolution";
            this.btnAddSolution.Size = new System.Drawing.Size(135, 33);
            this.btnAddSolution.TabIndex = 35;
            this.btnAddSolution.Text = "Add";
            this.btnAddSolution.UseVisualStyleBackColor = false;
            this.btnAddSolution.Visible = false;
            this.btnAddSolution.Click += new System.EventHandler(this.btnAddSolution_Click);
            // 
            // SolutionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(552, 204);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SolutionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Solution";
            this.groupBox1.ResumeLayout(false);
            this.panLocal.ResumeLayout(false);
            this.panLocal.PerformLayout();
            this.panOrgSolution.ResumeLayout(false);
            this.panOrgSolution.PerformLayout();
            this.panSource.ResumeLayout(false);
            this.panSource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox cbSolution;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLocal;
        private System.Windows.Forms.RadioButton rbOrg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panSource;
        private System.Windows.Forms.Panel panLocal;
        private System.Windows.Forms.Panel panOrgSolution;
        private System.Windows.Forms.Button btnAddSolution;
    }
}