namespace OctoUpload
{
    partial class mainForm
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
            this.folderPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.watchFolder = new System.Windows.Forms.TextBox();
            this.pickWatchFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.octoPrintAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apiKey = new System.Windows.Forms.TextBox();
            this.enableKeywords = new System.Windows.Forms.CheckBox();
            this.localUpload = new System.Windows.Forms.CheckBox();
            this.enableWatch = new System.Windows.Forms.CheckBox();
            this.autoStart = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Watch Folder";
            // 
            // watchFolder
            // 
            this.watchFolder.Location = new System.Drawing.Point(12, 35);
            this.watchFolder.Name = "watchFolder";
            this.watchFolder.Size = new System.Drawing.Size(218, 20);
            this.watchFolder.TabIndex = 1;
            // 
            // pickWatchFolder
            // 
            this.pickWatchFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickWatchFolder.Location = new System.Drawing.Point(236, 35);
            this.pickWatchFolder.Name = "pickWatchFolder";
            this.pickWatchFolder.Size = new System.Drawing.Size(36, 20);
            this.pickWatchFolder.TabIndex = 2;
            this.pickWatchFolder.Text = "...";
            this.pickWatchFolder.UseVisualStyleBackColor = true;
            this.pickWatchFolder.Click += new System.EventHandler(this.pickWatchFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "OctoPrint Address";
            // 
            // octoPrintAddress
            // 
            this.octoPrintAddress.Cursor = System.Windows.Forms.Cursors.Default;
            this.octoPrintAddress.Location = new System.Drawing.Point(12, 74);
            this.octoPrintAddress.Name = "octoPrintAddress";
            this.octoPrintAddress.Size = new System.Drawing.Size(260, 20);
            this.octoPrintAddress.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "OctoPrint API Key";
            // 
            // apiKey
            // 
            this.apiKey.Location = new System.Drawing.Point(12, 113);
            this.apiKey.Name = "apiKey";
            this.apiKey.Size = new System.Drawing.Size(260, 20);
            this.apiKey.TabIndex = 6;
            // 
            // enableKeywords
            // 
            this.enableKeywords.AutoSize = true;
            this.enableKeywords.Checked = true;
            this.enableKeywords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableKeywords.Location = new System.Drawing.Point(12, 139);
            this.enableKeywords.Name = "enableKeywords";
            this.enableKeywords.Size = new System.Drawing.Size(108, 17);
            this.enableKeywords.TabIndex = 7;
            this.enableKeywords.Text = "Enable Keywords";
            this.enableKeywords.UseVisualStyleBackColor = true;
            // 
            // localUpload
            // 
            this.localUpload.AutoSize = true;
            this.localUpload.Checked = true;
            this.localUpload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.localUpload.Location = new System.Drawing.Point(12, 162);
            this.localUpload.Name = "localUpload";
            this.localUpload.Size = new System.Drawing.Size(141, 17);
            this.localUpload.TabIndex = 8;
            this.localUpload.Text = "Upload to Local Storage";
            this.localUpload.UseVisualStyleBackColor = true;
            // 
            // enableWatch
            // 
            this.enableWatch.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableWatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enableWatch.Location = new System.Drawing.Point(12, 209);
            this.enableWatch.Name = "enableWatch";
            this.enableWatch.Size = new System.Drawing.Size(260, 49);
            this.enableWatch.TabIndex = 9;
            this.enableWatch.Text = "Start Watching";
            this.enableWatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableWatch.UseVisualStyleBackColor = true;
            this.enableWatch.CheckedChanged += new System.EventHandler(this.enableWatch_CheckedChanged);
            // 
            // autoStart
            // 
            this.autoStart.AutoSize = true;
            this.autoStart.Location = new System.Drawing.Point(12, 185);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new System.Drawing.Size(162, 17);
            this.autoStart.TabIndex = 10;
            this.autoStart.Text = "Automatically Start Watching";
            this.autoStart.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 263);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 285);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.autoStart);
            this.Controls.Add(this.enableWatch);
            this.Controls.Add(this.localUpload);
            this.Controls.Add(this.enableKeywords);
            this.Controls.Add(this.apiKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.octoPrintAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pickWatchFolder);
            this.Controls.Add(this.watchFolder);
            this.Controls.Add(this.label1);
            this.Name = "mainForm";
            this.RightToLeftLayout = true;
            this.Text = "OctoUpload";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox watchFolder;
        private System.Windows.Forms.Button pickWatchFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox octoPrintAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apiKey;
        private System.Windows.Forms.CheckBox enableKeywords;
        private System.Windows.Forms.CheckBox localUpload;
        private System.Windows.Forms.CheckBox enableWatch;
        private System.Windows.Forms.CheckBox autoStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

