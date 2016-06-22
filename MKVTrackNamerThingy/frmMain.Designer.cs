namespace MKVTrackNamerThingy
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
            this.lblAppInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ofdMKV = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataFromMKVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataFromDirectoryOfMKVFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToMKVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mKVToolNixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToMKVToolNixHomepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToMKVToolNixDownloadPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbxAudio = new System.Windows.Forms.GroupBox();
            this.pnlAudio = new System.Windows.Forms.Panel();
            this.gbxSubtitle = new System.Windows.Forms.GroupBox();
            this.pnlSubtitle = new System.Windows.Forms.Panel();
            this.gbxAudipPrep = new System.Windows.Forms.GroupBox();
            this.chkAudioPrepChan = new System.Windows.Forms.CheckBox();
            this.chkAudioPrepCodec = new System.Windows.Forms.CheckBox();
            this.chkAudioPrepLang = new System.Windows.Forms.CheckBox();
            this.gbxSubPrep = new System.Windows.Forms.GroupBox();
            this.chkSubPrepCodec = new System.Windows.Forms.CheckBox();
            this.chkSubPrepLang = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxLog = new System.Windows.Forms.RichTextBox();
            this.fbdMKVDir = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLoadDir = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.gbxAudio.SuspendLayout();
            this.gbxSubtitle.SuspendLayout();
            this.gbxAudipPrep.SuspendLayout();
            this.gbxSubPrep.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(11, 101);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(81, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "L&oad File(s)...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblAppInfo
            // 
            this.lblAppInfo.AutoSize = true;
            this.lblAppInfo.Location = new System.Drawing.Point(12, 33);
            this.lblAppInfo.Name = "lblAppInfo";
            this.lblAppInfo.Size = new System.Drawing.Size(91, 13);
            this.lblAppInfo.TabIndex = 1;
            this.lblAppInfo.Text = " by damysteryman";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File(s):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Title:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(188, 101);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ofdMKV
            // 
            this.ofdMKV.Filter = "Matroska Video files|*.mkv";
            this.ofdMKV.Multiselect = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mKVToolNixToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(886, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataFromMKVToolStripMenuItem,
            this.loadDataFromDirectoryOfMKVFilesToolStripMenuItem,
            this.saveDataToMKVToolStripMenuItem,
            this.exitProgramToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadDataFromMKVToolStripMenuItem
            // 
            this.loadDataFromMKVToolStripMenuItem.Name = "loadDataFromMKVToolStripMenuItem";
            this.loadDataFromMKVToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadDataFromMKVToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.loadDataFromMKVToolStripMenuItem.Text = "L&oad Data from MKV file(s)...";
            this.loadDataFromMKVToolStripMenuItem.Click += new System.EventHandler(this.loadDataFromMKVToolStripMenuItem_Click);
            // 
            // loadDataFromDirectoryOfMKVFilesToolStripMenuItem
            // 
            this.loadDataFromDirectoryOfMKVFilesToolStripMenuItem.Name = "loadDataFromDirectoryOfMKVFilesToolStripMenuItem";
            this.loadDataFromDirectoryOfMKVFilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.loadDataFromDirectoryOfMKVFilesToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.loadDataFromDirectoryOfMKVFilesToolStripMenuItem.Text = "Load Data from &Folder of MKV files...";
            this.loadDataFromDirectoryOfMKVFilesToolStripMenuItem.Click += new System.EventHandler(this.loadDataFromDirectoryOfMKVFilesToolStripMenuItem_Click);
            // 
            // saveDataToMKVToolStripMenuItem
            // 
            this.saveDataToMKVToolStripMenuItem.Name = "saveDataToMKVToolStripMenuItem";
            this.saveDataToMKVToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveDataToMKVToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.saveDataToMKVToolStripMenuItem.Text = "&Save Data to MKV file(s)...";
            this.saveDataToMKVToolStripMenuItem.Click += new System.EventHandler(this.saveDataToMKVToolStripMenuItem_Click);
            // 
            // exitProgramToolStripMenuItem
            // 
            this.exitProgramToolStripMenuItem.Name = "exitProgramToolStripMenuItem";
            this.exitProgramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitProgramToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.exitProgramToolStripMenuItem.Text = "E&xit Program";
            this.exitProgramToolStripMenuItem.Click += new System.EventHandler(this.exitProgramToolStripMenuItem_Click);
            // 
            // mKVToolNixToolStripMenuItem
            // 
            this.mKVToolNixToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToMKVToolNixHomepageToolStripMenuItem,
            this.goToMKVToolNixDownloadPageToolStripMenuItem,
            this.recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem});
            this.mKVToolNixToolStripMenuItem.Name = "mKVToolNixToolStripMenuItem";
            this.mKVToolNixToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.mKVToolNixToolStripMenuItem.Text = "&MKVToolNix";
            // 
            // goToMKVToolNixHomepageToolStripMenuItem
            // 
            this.goToMKVToolNixHomepageToolStripMenuItem.Name = "goToMKVToolNixHomepageToolStripMenuItem";
            this.goToMKVToolNixHomepageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.goToMKVToolNixHomepageToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.goToMKVToolNixHomepageToolStripMenuItem.Text = "Go to MKVToolNix &Homepage...";
            this.goToMKVToolNixHomepageToolStripMenuItem.Click += new System.EventHandler(this.goToMKVToolNixHomepageToolStripMenuItem_Click);
            // 
            // goToMKVToolNixDownloadPageToolStripMenuItem
            // 
            this.goToMKVToolNixDownloadPageToolStripMenuItem.Name = "goToMKVToolNixDownloadPageToolStripMenuItem";
            this.goToMKVToolNixDownloadPageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.goToMKVToolNixDownloadPageToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.goToMKVToolNixDownloadPageToolStripMenuItem.Text = "Go to MKVToolNix &Download page...";
            this.goToMKVToolNixDownloadPageToolStripMenuItem.Click += new System.EventHandler(this.goToMKVToolNixDownloadPageToolStripMenuItem_Click);
            // 
            // recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem
            // 
            this.recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem.Name = "recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem";
            this.recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem.Text = "&Recheck to see if MKVToolNix is installed";
            this.recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem.Click += new System.EventHandler(this.recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(49, 85);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 13);
            this.lblTitle.TabIndex = 7;
            // 
            // gbxAudio
            // 
            this.gbxAudio.Controls.Add(this.pnlAudio);
            this.gbxAudio.Location = new System.Drawing.Point(12, 130);
            this.gbxAudio.Name = "gbxAudio";
            this.gbxAudio.Size = new System.Drawing.Size(336, 214);
            this.gbxAudio.TabIndex = 8;
            this.gbxAudio.TabStop = false;
            this.gbxAudio.Text = "Audio Tracks:";
            // 
            // pnlAudio
            // 
            this.pnlAudio.AutoScroll = true;
            this.pnlAudio.Location = new System.Drawing.Point(6, 19);
            this.pnlAudio.Name = "pnlAudio";
            this.pnlAudio.Size = new System.Drawing.Size(324, 189);
            this.pnlAudio.TabIndex = 11;
            // 
            // gbxSubtitle
            // 
            this.gbxSubtitle.Controls.Add(this.pnlSubtitle);
            this.gbxSubtitle.Location = new System.Drawing.Point(449, 130);
            this.gbxSubtitle.Name = "gbxSubtitle";
            this.gbxSubtitle.Size = new System.Drawing.Size(336, 214);
            this.gbxSubtitle.TabIndex = 9;
            this.gbxSubtitle.TabStop = false;
            this.gbxSubtitle.Text = "Subtitle Tracks:";
            // 
            // pnlSubtitle
            // 
            this.pnlSubtitle.AutoScroll = true;
            this.pnlSubtitle.Location = new System.Drawing.Point(6, 19);
            this.pnlSubtitle.Name = "pnlSubtitle";
            this.pnlSubtitle.Size = new System.Drawing.Size(324, 189);
            this.pnlSubtitle.TabIndex = 12;
            // 
            // gbxAudipPrep
            // 
            this.gbxAudipPrep.Controls.Add(this.chkAudioPrepChan);
            this.gbxAudipPrep.Controls.Add(this.chkAudioPrepCodec);
            this.gbxAudipPrep.Controls.Add(this.chkAudioPrepLang);
            this.gbxAudipPrep.Location = new System.Drawing.Point(354, 130);
            this.gbxAudipPrep.Name = "gbxAudipPrep";
            this.gbxAudipPrep.Size = new System.Drawing.Size(85, 92);
            this.gbxAudipPrep.TabIndex = 0;
            this.gbxAudipPrep.TabStop = false;
            this.gbxAudipPrep.Text = "Prepend";
            // 
            // chkAudioPrepChan
            // 
            this.chkAudioPrepChan.AutoSize = true;
            this.chkAudioPrepChan.Location = new System.Drawing.Point(7, 68);
            this.chkAudioPrepChan.Name = "chkAudioPrepChan";
            this.chkAudioPrepChan.Size = new System.Drawing.Size(70, 17);
            this.chkAudioPrepChan.TabIndex = 2;
            this.chkAudioPrepChan.Text = "Channels";
            this.chkAudioPrepChan.UseVisualStyleBackColor = true;
            // 
            // chkAudioPrepCodec
            // 
            this.chkAudioPrepCodec.AutoSize = true;
            this.chkAudioPrepCodec.Location = new System.Drawing.Point(7, 44);
            this.chkAudioPrepCodec.Name = "chkAudioPrepCodec";
            this.chkAudioPrepCodec.Size = new System.Drawing.Size(57, 17);
            this.chkAudioPrepCodec.TabIndex = 1;
            this.chkAudioPrepCodec.Text = "Codec";
            this.chkAudioPrepCodec.UseVisualStyleBackColor = true;
            // 
            // chkAudioPrepLang
            // 
            this.chkAudioPrepLang.AutoSize = true;
            this.chkAudioPrepLang.Location = new System.Drawing.Point(7, 20);
            this.chkAudioPrepLang.Name = "chkAudioPrepLang";
            this.chkAudioPrepLang.Size = new System.Drawing.Size(77, 17);
            this.chkAudioPrepLang.TabIndex = 0;
            this.chkAudioPrepLang.Text = "Lang code";
            this.chkAudioPrepLang.UseVisualStyleBackColor = true;
            // 
            // gbxSubPrep
            // 
            this.gbxSubPrep.Controls.Add(this.chkSubPrepCodec);
            this.gbxSubPrep.Controls.Add(this.chkSubPrepLang);
            this.gbxSubPrep.Location = new System.Drawing.Point(791, 130);
            this.gbxSubPrep.Name = "gbxSubPrep";
            this.gbxSubPrep.Size = new System.Drawing.Size(85, 66);
            this.gbxSubPrep.TabIndex = 10;
            this.gbxSubPrep.TabStop = false;
            this.gbxSubPrep.Text = "Prepend";
            // 
            // chkSubPrepCodec
            // 
            this.chkSubPrepCodec.AutoSize = true;
            this.chkSubPrepCodec.Location = new System.Drawing.Point(6, 42);
            this.chkSubPrepCodec.Name = "chkSubPrepCodec";
            this.chkSubPrepCodec.Size = new System.Drawing.Size(57, 17);
            this.chkSubPrepCodec.TabIndex = 3;
            this.chkSubPrepCodec.Text = "Codec";
            this.chkSubPrepCodec.UseVisualStyleBackColor = true;
            // 
            // chkSubPrepLang
            // 
            this.chkSubPrepLang.AutoSize = true;
            this.chkSubPrepLang.Location = new System.Drawing.Point(6, 19);
            this.chkSubPrepLang.Name = "chkSubPrepLang";
            this.chkSubPrepLang.Size = new System.Drawing.Size(77, 17);
            this.chkSubPrepLang.TabIndex = 3;
            this.chkSubPrepLang.Text = "Lang code";
            this.chkSubPrepLang.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "mkvpropedit.exe File Edit Output Log:";
            // 
            // rtxLog
            // 
            this.rtxLog.Location = new System.Drawing.Point(11, 374);
            this.rtxLog.Name = "rtxLog";
            this.rtxLog.Size = new System.Drawing.Size(863, 95);
            this.rtxLog.TabIndex = 12;
            this.rtxLog.Text = "";
            // 
            // btnLoadDir
            // 
            this.btnLoadDir.Location = new System.Drawing.Point(98, 101);
            this.btnLoadDir.Name = "btnLoadDir";
            this.btnLoadDir.Size = new System.Drawing.Size(84, 23);
            this.btnLoadDir.TabIndex = 13;
            this.btnLoadDir.Text = "Load &Folder";
            this.btnLoadDir.UseVisualStyleBackColor = true;
            this.btnLoadDir.Click += new System.EventHandler(this.btnLoadDir_Click);
            // 
            // txtFile
            // 
            this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFile.HideSelection = false;
            this.txtFile.Location = new System.Drawing.Point(52, 61);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFile.Size = new System.Drawing.Size(395, 20);
            this.txtFile.TabIndex = 14;
            this.txtFile.WordWrap = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(11, 10);
            this.linkLabel1.Location = new System.Drawing.Point(746, 33);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(130, 17);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Powered by MKVToolNix";
            this.linkLabel1.UseCompatibleTextRendering = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 477);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnLoadDir);
            this.Controls.Add(this.rtxLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbxSubPrep);
            this.Controls.Add(this.gbxAudipPrep);
            this.Controls.Add(this.gbxSubtitle);
            this.Controls.Add(this.gbxAudio);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAppInfo);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "MKVTrackNamerThingy";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbxAudio.ResumeLayout(false);
            this.gbxSubtitle.ResumeLayout(false);
            this.gbxAudipPrep.ResumeLayout(false);
            this.gbxAudipPrep.PerformLayout();
            this.gbxSubPrep.ResumeLayout(false);
            this.gbxSubPrep.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblAppInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog ofdMKV;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mKVToolNixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataFromMKVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToMKVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitProgramToolStripMenuItem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbxAudio;
        private System.Windows.Forms.GroupBox gbxSubtitle;
        private System.Windows.Forms.GroupBox gbxAudipPrep;
        private System.Windows.Forms.CheckBox chkAudioPrepChan;
        private System.Windows.Forms.CheckBox chkAudioPrepCodec;
        private System.Windows.Forms.CheckBox chkAudioPrepLang;
        private System.Windows.Forms.GroupBox gbxSubPrep;
        private System.Windows.Forms.CheckBox chkSubPrepCodec;
        private System.Windows.Forms.CheckBox chkSubPrepLang;
        private System.Windows.Forms.Panel pnlAudio;
        private System.Windows.Forms.Panel pnlSubtitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxLog;
        private System.Windows.Forms.FolderBrowserDialog fbdMKVDir;
        private System.Windows.Forms.Button btnLoadDir;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.ToolStripMenuItem goToMKVToolNixHomepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToMKVToolNixDownloadPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataFromDirectoryOfMKVFilesToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

