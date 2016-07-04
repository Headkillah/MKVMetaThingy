namespace MKVDefaultTrackChangerThingy
{
    partial class frmMain
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.lbxAudio = new System.Windows.Forms.ListBox();
            this.lbxSubtitle = new System.Windows.Forms.ListBox();
            this.ofdMKV = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mKVToolNixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToMKVToolNixsHomepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToMKVToolNixdownloadPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxLog = new System.Windows.Forms.RichTextBox();
            this.lblAppInfo = new System.Windows.Forms.Label();
            this.llbMKVToolNix = new System.Windows.Forms.LinkLabel();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.fbdMKVDir = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLoadDir = new System.Windows.Forms.Button();
            this.loadDataFromFolderOfMKVFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 96);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "L&oad";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lbxAudio
            // 
            this.lbxAudio.FormattingEnabled = true;
            this.lbxAudio.Location = new System.Drawing.Point(12, 148);
            this.lbxAudio.Name = "lbxAudio";
            this.lbxAudio.Size = new System.Drawing.Size(429, 95);
            this.lbxAudio.TabIndex = 2;
            // 
            // lbxSubtitle
            // 
            this.lbxSubtitle.FormattingEnabled = true;
            this.lbxSubtitle.Location = new System.Drawing.Point(12, 280);
            this.lbxSubtitle.Name = "lbxSubtitle";
            this.lbxSubtitle.Size = new System.Drawing.Size(429, 95);
            this.lbxSubtitle.TabIndex = 3;
            // 
            // ofdMKV
            // 
            this.ofdMKV.Filter = "Matroska Video files|*.mkv";
            this.ofdMKV.Multiselect = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Audio Tracks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subtitle Tracks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "File:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Title:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(41, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 13);
            this.lblTitle.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(174, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mKVToolNixToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(454, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.loadDataFromFolderOfMKVFilesToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitProgramToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.loadToolStripMenuItem.Text = "L&oad data from MKV...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.saveToolStripMenuItem.Text = "&Save Settings to MKV";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitProgramToolStripMenuItem
            // 
            this.exitProgramToolStripMenuItem.Name = "exitProgramToolStripMenuItem";
            this.exitProgramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitProgramToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.exitProgramToolStripMenuItem.Text = "E&xit Program";
            this.exitProgramToolStripMenuItem.Click += new System.EventHandler(this.exitProgramToolStripMenuItem_Click);
            // 
            // mKVToolNixToolStripMenuItem
            // 
            this.mKVToolNixToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToMKVToolNixsHomepageToolStripMenuItem,
            this.goToMKVToolNixdownloadPageToolStripMenuItem,
            this.recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem});
            this.mKVToolNixToolStripMenuItem.Name = "mKVToolNixToolStripMenuItem";
            this.mKVToolNixToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.mKVToolNixToolStripMenuItem.Text = "&MKVToolNix";
            // 
            // goToMKVToolNixsHomepageToolStripMenuItem
            // 
            this.goToMKVToolNixsHomepageToolStripMenuItem.Name = "goToMKVToolNixsHomepageToolStripMenuItem";
            this.goToMKVToolNixsHomepageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.goToMKVToolNixsHomepageToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.goToMKVToolNixsHomepageToolStripMenuItem.Text = "Go to MKVToolNix &Homepage...";
            this.goToMKVToolNixsHomepageToolStripMenuItem.Click += new System.EventHandler(this.goToMKVToolNixsHomepageToolStripMenuItem_Click);
            // 
            // goToMKVToolNixdownloadPageToolStripMenuItem
            // 
            this.goToMKVToolNixdownloadPageToolStripMenuItem.Name = "goToMKVToolNixdownloadPageToolStripMenuItem";
            this.goToMKVToolNixdownloadPageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.goToMKVToolNixdownloadPageToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.goToMKVToolNixdownloadPageToolStripMenuItem.Text = "Go to MKVToolNix &Download page...";
            this.goToMKVToolNixdownloadPageToolStripMenuItem.Click += new System.EventHandler(this.goToMKVToolNixdownloadPageToolStripMenuItem_Click);
            // 
            // recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem
            // 
            this.recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem.Name = "recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem";
            this.recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem.Text = "&Recheck to see if MKVToolNix is installed";
            this.recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem.Click += new System.EventHandler(this.recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "mkvpropedit.exe File Edit Output Log:";
            // 
            // rtxLog
            // 
            this.rtxLog.Location = new System.Drawing.Point(12, 411);
            this.rtxLog.Name = "rtxLog";
            this.rtxLog.Size = new System.Drawing.Size(429, 95);
            this.rtxLog.TabIndex = 15;
            this.rtxLog.Text = "";
            // 
            // lblAppInfo
            // 
            this.lblAppInfo.AutoSize = true;
            this.lblAppInfo.Location = new System.Drawing.Point(12, 33);
            this.lblAppInfo.Name = "lblAppInfo";
            this.lblAppInfo.Size = new System.Drawing.Size(91, 13);
            this.lblAppInfo.TabIndex = 16;
            this.lblAppInfo.Text = " by damysteryman";
            // 
            // llbMKVToolNix
            // 
            this.llbMKVToolNix.AutoSize = true;
            this.llbMKVToolNix.LinkArea = new System.Windows.Forms.LinkArea(11, 10);
            this.llbMKVToolNix.Location = new System.Drawing.Point(324, 33);
            this.llbMKVToolNix.Name = "llbMKVToolNix";
            this.llbMKVToolNix.Size = new System.Drawing.Size(130, 17);
            this.llbMKVToolNix.TabIndex = 17;
            this.llbMKVToolNix.TabStop = true;
            this.llbMKVToolNix.Text = "Powered by MKVToolNix";
            this.llbMKVToolNix.UseCompatibleTextRendering = true;
            this.llbMKVToolNix.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbMKVToolNix_LinkClicked);
            // 
            // txtFile
            // 
            this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFile.HideSelection = false;
            this.txtFile.Location = new System.Drawing.Point(44, 56);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFile.Size = new System.Drawing.Size(395, 20);
            this.txtFile.TabIndex = 18;
            this.txtFile.WordWrap = false;
            // 
            // btnLoadDir
            // 
            this.btnLoadDir.Location = new System.Drawing.Point(93, 96);
            this.btnLoadDir.Name = "btnLoadDir";
            this.btnLoadDir.Size = new System.Drawing.Size(75, 23);
            this.btnLoadDir.TabIndex = 19;
            this.btnLoadDir.Text = "Load &Folder";
            this.btnLoadDir.UseVisualStyleBackColor = true;
            this.btnLoadDir.Click += new System.EventHandler(this.btnLoadDir_Click);
            // 
            // loadDataFromFolderOfMKVFilesToolStripMenuItem
            // 
            this.loadDataFromFolderOfMKVFilesToolStripMenuItem.Name = "loadDataFromFolderOfMKVFilesToolStripMenuItem";
            this.loadDataFromFolderOfMKVFilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.loadDataFromFolderOfMKVFilesToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.loadDataFromFolderOfMKVFilesToolStripMenuItem.Text = "Load Data from &Folder of MKV files...";
            this.loadDataFromFolderOfMKVFilesToolStripMenuItem.Click += new System.EventHandler(this.loadDataFromFolderOfMKVFilesToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 518);
            this.Controls.Add(this.btnLoadDir);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.llbMKVToolNix);
            this.Controls.Add(this.lblAppInfo);
            this.Controls.Add(this.rtxLog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxSubtitle);
            this.Controls.Add(this.lbxAudio);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "MKVDefaultTrackChangerThingy";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListBox lbxAudio;
        private System.Windows.Forms.ListBox lbxSubtitle;
        private System.Windows.Forms.OpenFileDialog ofdMKV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitProgramToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxLog;
        private System.Windows.Forms.ToolStripMenuItem mKVToolNixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToMKVToolNixsHomepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToMKVToolNixdownloadPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem;
        private System.Windows.Forms.Label lblAppInfo;
        private System.Windows.Forms.LinkLabel llbMKVToolNix;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.FolderBrowserDialog fbdMKVDir;
        private System.Windows.Forms.Button btnLoadDir;
        private System.Windows.Forms.ToolStripMenuItem loadDataFromFolderOfMKVFilesToolStripMenuItem;
    }
}

