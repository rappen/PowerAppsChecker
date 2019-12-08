namespace Rappen.XTB.PAC.Dialogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AzureLoginDialog));
            this.btnConnectPAC = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClientSec = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.txtTenantId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panClientSecret = new System.Windows.Forms.Panel();
            this.picSecret = new System.Windows.Forms.PictureBox();
            this.picTenant = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbUser = new System.Windows.Forms.RadioButton();
            this.rbSecret = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picClient = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picRegion = new System.Windows.Forms.PictureBox();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRegionUrl = new System.Windows.Forms.TextBox();
            this.panClientSecret.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSecret)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTenant)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClient)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnectPAC
            // 
            this.btnConnectPAC.BackColor = System.Drawing.SystemColors.Window;
            this.btnConnectPAC.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConnectPAC.Enabled = false;
            this.btnConnectPAC.Location = new System.Drawing.Point(297, 292);
            this.btnConnectPAC.Name = "btnConnectPAC";
            this.btnConnectPAC.Size = new System.Drawing.Size(135, 33);
            this.btnConnectPAC.TabIndex = 5;
            this.btnConnectPAC.Text = "Authenticate";
            this.btnConnectPAC.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Client Secret";
            // 
            // txtClientSec
            // 
            this.txtClientSec.Location = new System.Drawing.Point(94, 5);
            this.txtClientSec.Name = "txtClientSec";
            this.txtClientSec.PasswordChar = '*';
            this.txtClientSec.Size = new System.Drawing.Size(255, 20);
            this.txtClientSec.TabIndex = 1;
            this.txtClientSec.Text = "7:7.RNl]/7yoqsR9/+e54JGE4A3.MM6z";
            this.txtClientSec.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Application ID";
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(108, 53);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(255, 20);
            this.txtClientId.TabIndex = 3;
            this.txtClientId.Text = "774beb47-454d-450c-980e-07bad5477469";
            this.txtClientId.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtClientId.Leave += new System.EventHandler(this.txtClientId_Leave);
            // 
            // txtTenantId
            // 
            this.txtTenantId.Location = new System.Drawing.Point(94, 31);
            this.txtTenantId.Name = "txtTenantId";
            this.txtTenantId.Size = new System.Drawing.Size(255, 20);
            this.txtTenantId.TabIndex = 2;
            this.txtTenantId.Text = "03ef9e5e-caa4-41ad-b7a5-d657624eb692";
            this.txtTenantId.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Directory ID";
            // 
            // panClientSecret
            // 
            this.panClientSecret.Controls.Add(this.picSecret);
            this.panClientSecret.Controls.Add(this.picTenant);
            this.panClientSecret.Controls.Add(this.label1);
            this.panClientSecret.Controls.Add(this.txtClientSec);
            this.panClientSecret.Controls.Add(this.label3);
            this.panClientSecret.Controls.Add(this.txtTenantId);
            this.panClientSecret.Location = new System.Drawing.Point(14, 74);
            this.panClientSecret.Name = "panClientSecret";
            this.panClientSecret.Size = new System.Drawing.Size(399, 60);
            this.panClientSecret.TabIndex = 12;
            this.panClientSecret.Visible = false;
            // 
            // picSecret
            // 
            this.picSecret.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSecret.Image = ((System.Drawing.Image)(resources.GetObject("picSecret.Image")));
            this.picSecret.Location = new System.Drawing.Point(355, 1);
            this.picSecret.Name = "picSecret";
            this.picSecret.Size = new System.Drawing.Size(24, 24);
            this.picSecret.TabIndex = 31;
            this.picSecret.TabStop = false;
            this.picSecret.Click += new System.EventHandler(this.picSecret_Click);
            // 
            // picTenant
            // 
            this.picTenant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTenant.Image = ((System.Drawing.Image)(resources.GetObject("picTenant.Image")));
            this.picTenant.Location = new System.Drawing.Point(355, 27);
            this.picTenant.Name = "picTenant";
            this.picTenant.Size = new System.Drawing.Size(24, 24);
            this.picTenant.TabIndex = 29;
            this.picTenant.TabStop = false;
            this.picTenant.Click += new System.EventHandler(this.picTenant_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Method";
            // 
            // rbUser
            // 
            this.rbUser.AutoSize = true;
            this.rbUser.Checked = true;
            this.rbUser.Location = new System.Drawing.Point(108, 28);
            this.rbUser.Name = "rbUser";
            this.rbUser.Size = new System.Drawing.Size(76, 17);
            this.rbUser.TabIndex = 1;
            this.rbUser.TabStop = true;
            this.rbUser.Text = "User Login";
            this.rbUser.UseVisualStyleBackColor = true;
            this.rbUser.CheckedChanged += new System.EventHandler(this.rbMethod_CheckedChanged);
            // 
            // rbSecret
            // 
            this.rbSecret.AutoSize = true;
            this.rbSecret.Location = new System.Drawing.Point(214, 28);
            this.rbSecret.Name = "rbSecret";
            this.rbSecret.Size = new System.Drawing.Size(85, 17);
            this.rbSecret.TabIndex = 2;
            this.rbSecret.Text = "Client Secret";
            this.rbSecret.UseVisualStyleBackColor = true;
            this.rbSecret.CheckedChanged += new System.EventHandler(this.rbMethod_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picClient);
            this.groupBox1.Controls.Add(this.rbSecret);
            this.groupBox1.Controls.Add(this.txtClientId);
            this.groupBox1.Controls.Add(this.rbUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.panClientSecret);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 144);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Azure AD Authentication";
            // 
            // picClient
            // 
            this.picClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClient.Image = ((System.Drawing.Image)(resources.GetObject("picClient.Image")));
            this.picClient.Location = new System.Drawing.Point(369, 49);
            this.picClient.Name = "picClient";
            this.picClient.Size = new System.Drawing.Size(24, 24);
            this.picClient.TabIndex = 30;
            this.picClient.TabStop = false;
            this.picClient.Click += new System.EventHandler(this.picClient_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRegionUrl);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.picRegion);
            this.groupBox2.Controls.Add(this.cbRegion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 94);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Power Apps Checker Service";
            // 
            // picRegion
            // 
            this.picRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRegion.Image = ((System.Drawing.Image)(resources.GetObject("picRegion.Image")));
            this.picRegion.Location = new System.Drawing.Point(369, 23);
            this.picRegion.Name = "picRegion";
            this.picRegion.Size = new System.Drawing.Size(24, 24);
            this.picRegion.TabIndex = 28;
            this.picRegion.TabStop = false;
            this.picRegion.Click += new System.EventHandler(this.picRegion_Click);
            // 
            // cbRegion
            // 
            this.cbRegion.BackColor = System.Drawing.SystemColors.Window;
            this.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Items.AddRange(new object[] {
            "Default",
            "United States First Release",
            "United States",
            "Europe",
            "Asia",
            "Australia",
            "Japan",
            "India",
            "Canada",
            "South America",
            "United Kingdom",
            "France",
            "[Custom]"});
            this.cbRegion.Location = new System.Drawing.Point(108, 26);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(255, 21);
            this.cbRegion.TabIndex = 1;
            this.cbRegion.SelectedIndexChanged += new System.EventHandler(this.cbRegion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Geography";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Url";
            // 
            // txtRegionUrl
            // 
            this.txtRegionUrl.Enabled = false;
            this.txtRegionUrl.Location = new System.Drawing.Point(108, 53);
            this.txtRegionUrl.Name = "txtRegionUrl";
            this.txtRegionUrl.Size = new System.Drawing.Size(255, 20);
            this.txtRegionUrl.TabIndex = 1;
            // 
            // AzureLoginDialog
            // 
            this.AcceptButton = this.btnConnectPAC;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(449, 337);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConnectPAC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AzureLoginDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Azure Login";
            this.panClientSecret.ResumeLayout(false);
            this.panClientSecret.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSecret)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTenant)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClient)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRegion)).EndInit();
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
        private System.Windows.Forms.Panel panClientSecret;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbUser;
        private System.Windows.Forms.RadioButton rbSecret;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picRegion;
        private System.Windows.Forms.PictureBox picSecret;
        private System.Windows.Forms.PictureBox picClient;
        private System.Windows.Forms.PictureBox picTenant;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtRegionUrl;
        private System.Windows.Forms.Label label6;
    }
}