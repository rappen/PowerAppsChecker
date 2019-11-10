namespace Rappen.XTB.PAC
{
    partial class AzureLoginDialog
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
            this.btnConnectPAC = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClientSec = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.txtTenantId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabClientSecret = new System.Windows.Forms.TabPage();
            this.tabUserPwd = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabClientSecret.SuspendLayout();
            this.tabUserPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnectPAC
            // 
            this.btnConnectPAC.BackColor = System.Drawing.SystemColors.Window;
            this.btnConnectPAC.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConnectPAC.Location = new System.Drawing.Point(250, 93);
            this.btnConnectPAC.Name = "btnConnectPAC";
            this.btnConnectPAC.Size = new System.Drawing.Size(135, 23);
            this.btnConnectPAC.TabIndex = 11;
            this.btnConnectPAC.Text = "Connect";
            this.btnConnectPAC.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Client Secret";
            // 
            // txtClientSec
            // 
            this.txtClientSec.Location = new System.Drawing.Point(100, 67);
            this.txtClientSec.Name = "txtClientSec";
            this.txtClientSec.PasswordChar = '*';
            this.txtClientSec.Size = new System.Drawing.Size(285, 20);
            this.txtClientSec.TabIndex = 9;
            this.txtClientSec.Text = "7:7.RNl]/7yoqsR9/+e54JGE4A3.MM6z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Client Id";
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(100, 41);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(285, 20);
            this.txtClientId.TabIndex = 7;
            this.txtClientId.Text = "774beb47-454d-450c-980e-07bad5477469";
            // 
            // txtTenantId
            // 
            this.txtTenantId.Location = new System.Drawing.Point(100, 14);
            this.txtTenantId.Name = "txtTenantId";
            this.txtTenantId.Size = new System.Drawing.Size(285, 20);
            this.txtTenantId.TabIndex = 6;
            this.txtTenantId.Text = "03ef9e5e-caa4-41ad-b7a5-d657624eb692";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tenant Id";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabClientSecret);
            this.tabControl1.Controls.Add(this.tabUserPwd);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(419, 159);
            this.tabControl1.TabIndex = 3;
            // 
            // tabClientSecret
            // 
            this.tabClientSecret.Controls.Add(this.label1);
            this.tabClientSecret.Controls.Add(this.btnConnectPAC);
            this.tabClientSecret.Controls.Add(this.txtTenantId);
            this.tabClientSecret.Controls.Add(this.label3);
            this.tabClientSecret.Controls.Add(this.txtClientId);
            this.tabClientSecret.Controls.Add(this.txtClientSec);
            this.tabClientSecret.Controls.Add(this.label2);
            this.tabClientSecret.Location = new System.Drawing.Point(4, 22);
            this.tabClientSecret.Name = "tabClientSecret";
            this.tabClientSecret.Padding = new System.Windows.Forms.Padding(3);
            this.tabClientSecret.Size = new System.Drawing.Size(411, 133);
            this.tabClientSecret.TabIndex = 0;
            this.tabClientSecret.Text = "ClientID and Secret";
            this.tabClientSecret.UseVisualStyleBackColor = true;
            // 
            // tabUserPwd
            // 
            this.tabUserPwd.Controls.Add(this.label4);
            this.tabUserPwd.Location = new System.Drawing.Point(4, 22);
            this.tabUserPwd.Name = "tabUserPwd";
            this.tabUserPwd.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserPwd.Size = new System.Drawing.Size(533, 220);
            this.tabUserPwd.TabIndex = 1;
            this.tabUserPwd.Text = "Username and Password";
            this.tabUserPwd.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Support for Username and Password will be added in a future release";
            // 
            // AzureLoginDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 159);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AzureLoginDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Azure Login";
            this.tabControl1.ResumeLayout(false);
            this.tabClientSecret.ResumeLayout(false);
            this.tabClientSecret.PerformLayout();
            this.tabUserPwd.ResumeLayout(false);
            this.tabUserPwd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnConnectPAC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClientSec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.TextBox txtTenantId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabClientSecret;
        private System.Windows.Forms.TabPage tabUserPwd;
        private System.Windows.Forms.Label label4;
    }
}