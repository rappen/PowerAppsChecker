﻿namespace Rappen.XTB.PAC.DockControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SarifControl));
            this.tabControlResults = new System.Windows.Forms.TabControl();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.Severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RuleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Snippet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panTop = new System.Windows.Forms.Panel();
            this.panTopStatus = new System.Windows.Forms.Panel();
            this.btnOpenSarif = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtResultFile = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.progAnalysis = new System.Windows.Forms.ProgressBar();
            this.txtStatusUrl = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRunCorrId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSaveSarif = new System.Windows.Forms.Button();
            this.panTopCounts = new System.Windows.Forms.Panel();
            this.txtResultCountInfo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResultCountLow = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResultCountMedium = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResultCountHigh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResultCountCritical = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSarif = new System.Windows.Forms.TabPage();
            this.txtSarif = new System.Windows.Forms.RichTextBox();
            this.dgGrouper = new Subro.Controls.DataGridViewGrouper(this.components);
            this.tmStatus = new System.Windows.Forms.Timer(this.components);
            this.tabControlResults.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.panTop.SuspendLayout();
            this.panTopStatus.SuspendLayout();
            this.panTopCounts.SuspendLayout();
            this.tabSarif.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlResults
            // 
            this.tabControlResults.Controls.Add(this.tabResults);
            this.tabControlResults.Controls.Add(this.tabSarif);
            this.tabControlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlResults.Location = new System.Drawing.Point(0, 0);
            this.tabControlResults.Name = "tabControlResults";
            this.tabControlResults.SelectedIndex = 0;
            this.tabControlResults.Size = new System.Drawing.Size(962, 669);
            this.tabControlResults.TabIndex = 10;
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.dgResults);
            this.tabResults.Controls.Add(this.panTop);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(954, 643);
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
            this.dgResults.Location = new System.Drawing.Point(3, 125);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.RowHeadersVisible = false;
            this.dgResults.Size = new System.Drawing.Size(948, 515);
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
            // panTop
            // 
            this.panTop.Controls.Add(this.panTopStatus);
            this.panTop.Controls.Add(this.panTopCounts);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(3, 3);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(948, 122);
            this.panTop.TabIndex = 2;
            // 
            // panTopStatus
            // 
            this.panTopStatus.Controls.Add(this.btnOpenSarif);
            this.panTopStatus.Controls.Add(this.label10);
            this.panTopStatus.Controls.Add(this.txtResultFile);
            this.panTopStatus.Controls.Add(this.label12);
            this.panTopStatus.Controls.Add(this.progAnalysis);
            this.panTopStatus.Controls.Add(this.txtStatusUrl);
            this.panTopStatus.Controls.Add(this.txtStatus);
            this.panTopStatus.Controls.Add(this.label13);
            this.panTopStatus.Controls.Add(this.txtRunCorrId);
            this.panTopStatus.Controls.Add(this.label11);
            this.panTopStatus.Controls.Add(this.btnSaveSarif);
            this.panTopStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTopStatus.Location = new System.Drawing.Point(214, 0);
            this.panTopStatus.Name = "panTopStatus";
            this.panTopStatus.Size = new System.Drawing.Size(734, 122);
            this.panTopStatus.TabIndex = 46;
            // 
            // btnOpenSarif
            // 
            this.btnOpenSarif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSarif.BackColor = System.Drawing.SystemColors.Window;
            this.btnOpenSarif.Location = new System.Drawing.Point(569, 87);
            this.btnOpenSarif.Name = "btnOpenSarif";
            this.btnOpenSarif.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSarif.TabIndex = 46;
            this.btnOpenSarif.Text = "Open";
            this.btnOpenSarif.UseVisualStyleBackColor = false;
            this.btnOpenSarif.Click += new System.EventHandler(this.btnOpenSarif_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Status Url";
            // 
            // txtResultFile
            // 
            this.txtResultFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultFile.Location = new System.Drawing.Point(98, 89);
            this.txtResultFile.Name = "txtResultFile";
            this.txtResultFile.ReadOnly = true;
            this.txtResultFile.Size = new System.Drawing.Size(465, 20);
            this.txtResultFile.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Status";
            // 
            // progAnalysis
            // 
            this.progAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progAnalysis.BackColor = System.Drawing.SystemColors.Window;
            this.progAnalysis.Location = new System.Drawing.Point(201, 63);
            this.progAnalysis.Name = "progAnalysis";
            this.progAnalysis.Size = new System.Drawing.Size(524, 20);
            this.progAnalysis.TabIndex = 39;
            // 
            // txtStatusUrl
            // 
            this.txtStatusUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatusUrl.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatusUrl.Location = new System.Drawing.Point(98, 11);
            this.txtStatusUrl.Name = "txtStatusUrl";
            this.txtStatusUrl.ReadOnly = true;
            this.txtStatusUrl.Size = new System.Drawing.Size(627, 20);
            this.txtStatusUrl.TabIndex = 36;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.Location = new System.Drawing.Point(98, 63);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(97, 20);
            this.txtStatus.TabIndex = 38;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "SARIF file";
            // 
            // txtRunCorrId
            // 
            this.txtRunCorrId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRunCorrId.BackColor = System.Drawing.SystemColors.Window;
            this.txtRunCorrId.Location = new System.Drawing.Point(98, 37);
            this.txtRunCorrId.Name = "txtRunCorrId";
            this.txtRunCorrId.ReadOnly = true;
            this.txtRunCorrId.Size = new System.Drawing.Size(627, 20);
            this.txtRunCorrId.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Run Corr Id";
            // 
            // btnSaveSarif
            // 
            this.btnSaveSarif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSarif.BackColor = System.Drawing.SystemColors.Window;
            this.btnSaveSarif.Location = new System.Drawing.Point(650, 87);
            this.btnSaveSarif.Name = "btnSaveSarif";
            this.btnSaveSarif.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSarif.TabIndex = 41;
            this.btnSaveSarif.Text = "Save";
            this.btnSaveSarif.UseVisualStyleBackColor = false;
            this.btnSaveSarif.Click += new System.EventHandler(this.btnSaveSarif_Click);
            // 
            // panTopCounts
            // 
            this.panTopCounts.Controls.Add(this.txtResultCountInfo);
            this.panTopCounts.Controls.Add(this.label5);
            this.panTopCounts.Controls.Add(this.txtResultCountLow);
            this.panTopCounts.Controls.Add(this.label4);
            this.panTopCounts.Controls.Add(this.txtResultCountMedium);
            this.panTopCounts.Controls.Add(this.label3);
            this.panTopCounts.Controls.Add(this.txtResultCountHigh);
            this.panTopCounts.Controls.Add(this.label2);
            this.panTopCounts.Controls.Add(this.txtResultCountCritical);
            this.panTopCounts.Controls.Add(this.label1);
            this.panTopCounts.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTopCounts.Location = new System.Drawing.Point(0, 0);
            this.panTopCounts.Name = "panTopCounts";
            this.panTopCounts.Size = new System.Drawing.Size(214, 122);
            this.panTopCounts.TabIndex = 47;
            // 
            // txtResultCountInfo
            // 
            this.txtResultCountInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountInfo.Location = new System.Drawing.Point(95, 87);
            this.txtResultCountInfo.Name = "txtResultCountInfo";
            this.txtResultCountInfo.ReadOnly = true;
            this.txtResultCountInfo.Size = new System.Drawing.Size(100, 20);
            this.txtResultCountInfo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Informational";
            // 
            // txtResultCountLow
            // 
            this.txtResultCountLow.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountLow.Location = new System.Drawing.Point(95, 68);
            this.txtResultCountLow.Name = "txtResultCountLow";
            this.txtResultCountLow.ReadOnly = true;
            this.txtResultCountLow.Size = new System.Drawing.Size(100, 20);
            this.txtResultCountLow.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Low";
            // 
            // txtResultCountMedium
            // 
            this.txtResultCountMedium.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountMedium.Location = new System.Drawing.Point(95, 49);
            this.txtResultCountMedium.Name = "txtResultCountMedium";
            this.txtResultCountMedium.ReadOnly = true;
            this.txtResultCountMedium.Size = new System.Drawing.Size(100, 20);
            this.txtResultCountMedium.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Medium";
            // 
            // txtResultCountHigh
            // 
            this.txtResultCountHigh.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountHigh.Location = new System.Drawing.Point(95, 30);
            this.txtResultCountHigh.Name = "txtResultCountHigh";
            this.txtResultCountHigh.ReadOnly = true;
            this.txtResultCountHigh.Size = new System.Drawing.Size(100, 20);
            this.txtResultCountHigh.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "High";
            // 
            // txtResultCountCritical
            // 
            this.txtResultCountCritical.BackColor = System.Drawing.SystemColors.Window;
            this.txtResultCountCritical.Location = new System.Drawing.Point(95, 11);
            this.txtResultCountCritical.Name = "txtResultCountCritical";
            this.txtResultCountCritical.ReadOnly = true;
            this.txtResultCountCritical.Size = new System.Drawing.Size(100, 20);
            this.txtResultCountCritical.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Critical";
            // 
            // tabSarif
            // 
            this.tabSarif.Controls.Add(this.txtSarif);
            this.tabSarif.Location = new System.Drawing.Point(4, 22);
            this.tabSarif.Name = "tabSarif";
            this.tabSarif.Padding = new System.Windows.Forms.Padding(3);
            this.tabSarif.Size = new System.Drawing.Size(954, 643);
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
            this.txtSarif.Size = new System.Drawing.Size(948, 637);
            this.txtSarif.TabIndex = 0;
            this.txtSarif.Text = "";
            this.txtSarif.WordWrap = false;
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
            // SarifControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 669);
            this.Controls.Add(this.tabControlResults);
            this.Name = "SarifControl";
            this.tabControlResults.ResumeLayout(false);
            this.tabResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTopStatus.ResumeLayout(false);
            this.panTopStatus.PerformLayout();
            this.panTopCounts.ResumeLayout(false);
            this.panTopCounts.PerformLayout();
            this.tabSarif.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlResults;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn Severity;
        private System.Windows.Forms.DataGridViewTextBoxColumn RuleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Snippet;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartLine;
        private System.Windows.Forms.TabPage tabSarif;
        private System.Windows.Forms.RichTextBox txtSarif;
        private Subro.Controls.DataGridViewGrouper dgGrouper;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Panel panTopStatus;
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
        private System.Windows.Forms.Panel panTopCounts;
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
    }
}
