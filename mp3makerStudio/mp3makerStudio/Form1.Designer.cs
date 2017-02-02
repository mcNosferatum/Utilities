namespace mp3makerStudio
{
    partial class Form1
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
            this.openM3UFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectM3U = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDownloadMP3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDownloadErrors = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDownloadFromOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenameFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCheckFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReDownloadMP3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openM3UFileDialog
            // 
            this.openM3UFileDialog.FileName = "openM3UFileDialog";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 249);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(439, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Location = new System.Drawing.Point(12, 31);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(439, 212);
            this.tbOutput.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMain,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(463, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemMain
            // 
            this.toolStripMenuItemMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSelectM3U,
            this.tsmiDownloadMP3,
            this.tsmiDownloadErrors,
            this.tsmiDownloadFromOutput,
            this.tsmiRenameFiles,
            this.tsmiCheckFiles});
            this.toolStripMenuItemMain.Name = "toolStripMenuItemMain";
            this.toolStripMenuItemMain.Size = new System.Drawing.Size(54, 24);
            this.toolStripMenuItemMain.Text = "Main";
            // 
            // tsmiSelectM3U
            // 
            this.tsmiSelectM3U.Name = "tsmiSelectM3U";
            this.tsmiSelectM3U.Size = new System.Drawing.Size(343, 24);
            this.tsmiSelectM3U.Text = "Select .m3u and create dowload link file";
            this.tsmiSelectM3U.Click += new System.EventHandler(this.tsmiSelectM3U_Click);
            // 
            // tsmiDownloadMP3
            // 
            this.tsmiDownloadMP3.Name = "tsmiDownloadMP3";
            this.tsmiDownloadMP3.Size = new System.Drawing.Size(343, 24);
            this.tsmiDownloadMP3.Text = "Download all mp3";
            this.tsmiDownloadMP3.Click += new System.EventHandler(this.tsmiDownloadMP3_Click);
            // 
            // tsmiDownloadErrors
            // 
            this.tsmiDownloadErrors.Name = "tsmiDownloadErrors";
            this.tsmiDownloadErrors.Size = new System.Drawing.Size(343, 24);
            this.tsmiDownloadErrors.Text = "Download errors from file";
            this.tsmiDownloadErrors.Click += new System.EventHandler(this.tsmiDownloadErrors_Click);
            // 
            // tsmiDownloadFromOutput
            // 
            this.tsmiDownloadFromOutput.Name = "tsmiDownloadFromOutput";
            this.tsmiDownloadFromOutput.Size = new System.Drawing.Size(343, 24);
            this.tsmiDownloadFromOutput.Text = "Download errors from output";
            this.tsmiDownloadFromOutput.Click += new System.EventHandler(this.tsmiDownloadFromOutput_Click);
            // 
            // tsmiRenameFiles
            // 
            this.tsmiRenameFiles.Name = "tsmiRenameFiles";
            this.tsmiRenameFiles.Size = new System.Drawing.Size(343, 24);
            this.tsmiRenameFiles.Text = "Rename files in current direcrory";
            this.tsmiRenameFiles.Click += new System.EventHandler(this.tsmiRenameFiles_Click);
            // 
            // tsmiCheckFiles
            // 
            this.tsmiCheckFiles.Name = "tsmiCheckFiles";
            this.tsmiCheckFiles.Size = new System.Drawing.Size(343, 24);
            this.tsmiCheckFiles.Text = "Check files";
            this.tsmiCheckFiles.Click += new System.EventHandler(this.tsmiCheckFiles_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReDownloadMP3});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // tsmiReDownloadMP3
            // 
            this.tsmiReDownloadMP3.CheckOnClick = true;
            this.tsmiReDownloadMP3.Name = "tsmiReDownloadMP3";
            this.tsmiReDownloadMP3.Size = new System.Drawing.Size(405, 24);
            this.tsmiReDownloadMP3.Text = "Перезаписывать файлы при совпадении имен";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 284);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openM3UFileDialog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectM3U;
        private System.Windows.Forms.ToolStripMenuItem tsmiDownloadMP3;
        private System.Windows.Forms.ToolStripMenuItem tsmiDownloadErrors;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenameFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiDownloadFromOutput;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiReDownloadMP3;
    }
}

