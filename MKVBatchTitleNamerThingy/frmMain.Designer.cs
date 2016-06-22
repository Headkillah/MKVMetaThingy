namespace MKVBatchTitleNamerThingy
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
            this.lblAppInfo = new System.Windows.Forms.Label();
            this.llbMKVToolNix = new System.Windows.Forms.LinkLabel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.nudTitleMinDigits = new System.Windows.Forms.NumericUpDown();
            this.pnlTitles = new System.Windows.Forms.Panel();
            this.ofdMKV = new System.Windows.Forms.OpenFileDialog();
            this.rtxLog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDir = new System.Windows.Forms.Label();
            this.btnLoadDir = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTitleSelectAll = new System.Windows.Forms.CheckBox();
            this.chkTitleEditActivate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShowTitle = new System.Windows.Forms.TextBox();
            this.gbxTitlePrep = new System.Windows.Forms.GroupBox();
            this.btnTitleCopy = new System.Windows.Forms.Button();
            this.nudTitleEpOffset = new System.Windows.Forms.NumericUpDown();
            this.chkTitlePrepEpNo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTitleEpisodePre = new System.Windows.Forms.TextBox();
            this.cboTitleEpisodePre = new System.Windows.Forms.ComboBox();
            this.chkTitlePrepEpOffset = new System.Windows.Forms.CheckBox();
            this.txtTitleSeasonPre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkTitlePrepSeasonPre = new System.Windows.Forms.CheckBox();
            this.chkTitlePrepEpPrefix = new System.Windows.Forms.CheckBox();
            this.chkTitlePrepShow = new System.Windows.Forms.CheckBox();
            this.chkTitlePrepEpiZeros = new System.Windows.Forms.CheckBox();
            this.fbdMKVDir = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFileSelectAll = new System.Windows.Forms.CheckBox();
            this.chkFileNameEditActivate = new System.Windows.Forms.CheckBox();
            this.pnlFileNames = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkFilePrepDash = new System.Windows.Forms.CheckBox();
            this.nudFileEpOffset = new System.Windows.Forms.NumericUpDown();
            this.chkFilePrepEpNo = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFileEpisodePre = new System.Windows.Forms.TextBox();
            this.cboFileEpisodePre = new System.Windows.Forms.ComboBox();
            this.chkFilePrepEpOffset = new System.Windows.Forms.CheckBox();
            this.txtFileSeasonPre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkFilePrepSeasonPre = new System.Windows.Forms.CheckBox();
            this.chkFilePrepEpPrefix = new System.Windows.Forms.CheckBox();
            this.chkFilePrepShow = new System.Windows.Forms.CheckBox();
            this.chkFilePrepEpiZeros = new System.Windows.Forms.CheckBox();
            this.nudFileMinDigits = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTitleMinDigits)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbxTitlePrep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTitleEpOffset)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileEpOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileMinDigits)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mKVToolNixToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 6;
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
            // lblAppInfo
            // 
            this.lblAppInfo.AutoSize = true;
            this.lblAppInfo.Location = new System.Drawing.Point(12, 33);
            this.lblAppInfo.Name = "lblAppInfo";
            this.lblAppInfo.Size = new System.Drawing.Size(91, 13);
            this.lblAppInfo.TabIndex = 7;
            this.lblAppInfo.Text = " by damysteryman";
            // 
            // llbMKVToolNix
            // 
            this.llbMKVToolNix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llbMKVToolNix.AutoSize = true;
            this.llbMKVToolNix.LinkArea = new System.Windows.Forms.LinkArea(11, 10);
            this.llbMKVToolNix.Location = new System.Drawing.Point(878, 33);
            this.llbMKVToolNix.Name = "llbMKVToolNix";
            this.llbMKVToolNix.Size = new System.Drawing.Size(130, 17);
            this.llbMKVToolNix.TabIndex = 16;
            this.llbMKVToolNix.TabStop = true;
            this.llbMKVToolNix.Text = "Powered by MKVToolNix";
            this.llbMKVToolNix.UseCompatibleTextRendering = true;
            this.llbMKVToolNix.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbMKVToolNix_LinkClicked);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 91);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 17;
            this.btnLoad.Text = "L&oad File(s)";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // nudTitleMinDigits
            // 
            this.nudTitleMinDigits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudTitleMinDigits.Location = new System.Drawing.Point(92, 213);
            this.nudTitleMinDigits.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudTitleMinDigits.Name = "nudTitleMinDigits";
            this.nudTitleMinDigits.Size = new System.Drawing.Size(29, 20);
            this.nudTitleMinDigits.TabIndex = 21;
            this.nudTitleMinDigits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlTitles
            // 
            this.pnlTitles.AutoScroll = true;
            this.pnlTitles.Location = new System.Drawing.Point(6, 19);
            this.pnlTitles.Name = "pnlTitles";
            this.pnlTitles.Size = new System.Drawing.Size(339, 317);
            this.pnlTitles.TabIndex = 22;
            // 
            // ofdMKV
            // 
            this.ofdMKV.Filter = "Matroska Video files|*.mkv";
            this.ofdMKV.Multiselect = true;
            // 
            // rtxLog
            // 
            this.rtxLog.Location = new System.Drawing.Point(9, 508);
            this.rtxLog.Name = "rtxLog";
            this.rtxLog.Size = new System.Drawing.Size(991, 95);
            this.rtxLog.TabIndex = 23;
            this.rtxLog.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 492);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "File Edit Output Log:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Folder:";
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Location = new System.Drawing.Point(61, 72);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(0, 13);
            this.lblDir.TabIndex = 26;
            // 
            // btnLoadDir
            // 
            this.btnLoadDir.Location = new System.Drawing.Point(93, 91);
            this.btnLoadDir.Name = "btnLoadDir";
            this.btnLoadDir.Size = new System.Drawing.Size(75, 23);
            this.btnLoadDir.TabIndex = 27;
            this.btnLoadDir.Text = "Load &Folder";
            this.btnLoadDir.UseVisualStyleBackColor = true;
            this.btnLoadDir.Click += new System.EventHandler(this.btnLoadDir_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(174, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkTitleSelectAll);
            this.groupBox1.Controls.Add(this.chkTitleEditActivate);
            this.groupBox1.Controls.Add(this.pnlTitles);
            this.groupBox1.Location = new System.Drawing.Point(9, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 342);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Titles Edit";
            // 
            // chkTitleSelectAll
            // 
            this.chkTitleSelectAll.AutoSize = true;
            this.chkTitleSelectAll.Location = new System.Drawing.Point(234, 0);
            this.chkTitleSelectAll.Name = "chkTitleSelectAll";
            this.chkTitleSelectAll.Size = new System.Drawing.Size(117, 17);
            this.chkTitleSelectAll.TabIndex = 35;
            this.chkTitleSelectAll.Text = "Select/Deselect All";
            this.chkTitleSelectAll.UseVisualStyleBackColor = true;
            this.chkTitleSelectAll.CheckedChanged += new System.EventHandler(this.chkTitleSelectAll_CheckedChanged);
            // 
            // chkTitleEditActivate
            // 
            this.chkTitleEditActivate.AutoSize = true;
            this.chkTitleEditActivate.Location = new System.Drawing.Point(72, 0);
            this.chkTitleEditActivate.Name = "chkTitleEditActivate";
            this.chkTitleEditActivate.Size = new System.Drawing.Size(65, 17);
            this.chkTitleEditActivate.TabIndex = 23;
            this.chkTitleEditActivate.Text = "Activate";
            this.chkTitleEditActivate.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Show Title:";
            // 
            // txtShowTitle
            // 
            this.txtShowTitle.Location = new System.Drawing.Point(81, 125);
            this.txtShowTitle.Name = "txtShowTitle";
            this.txtShowTitle.Size = new System.Drawing.Size(204, 20);
            this.txtShowTitle.TabIndex = 31;
            // 
            // gbxTitlePrep
            // 
            this.gbxTitlePrep.Controls.Add(this.btnTitleCopy);
            this.gbxTitlePrep.Controls.Add(this.nudTitleEpOffset);
            this.gbxTitlePrep.Controls.Add(this.chkTitlePrepEpNo);
            this.gbxTitlePrep.Controls.Add(this.label6);
            this.gbxTitlePrep.Controls.Add(this.txtTitleEpisodePre);
            this.gbxTitlePrep.Controls.Add(this.cboTitleEpisodePre);
            this.gbxTitlePrep.Controls.Add(this.chkTitlePrepEpOffset);
            this.gbxTitlePrep.Controls.Add(this.txtTitleSeasonPre);
            this.gbxTitlePrep.Controls.Add(this.label5);
            this.gbxTitlePrep.Controls.Add(this.chkTitlePrepSeasonPre);
            this.gbxTitlePrep.Controls.Add(this.chkTitlePrepEpPrefix);
            this.gbxTitlePrep.Controls.Add(this.chkTitlePrepShow);
            this.gbxTitlePrep.Controls.Add(this.chkTitlePrepEpiZeros);
            this.gbxTitlePrep.Controls.Add(this.nudTitleMinDigits);
            this.gbxTitlePrep.Location = new System.Drawing.Point(366, 147);
            this.gbxTitlePrep.Name = "gbxTitlePrep";
            this.gbxTitlePrep.Size = new System.Drawing.Size(135, 342);
            this.gbxTitlePrep.TabIndex = 32;
            this.gbxTitlePrep.TabStop = false;
            this.gbxTitlePrep.Text = "Prepend";
            // 
            // btnTitleCopy
            // 
            this.btnTitleCopy.Location = new System.Drawing.Point(7, 285);
            this.btnTitleCopy.Name = "btnTitleCopy";
            this.btnTitleCopy.Size = new System.Drawing.Size(122, 23);
            this.btnTitleCopy.TabIndex = 35;
            this.btnTitleCopy.Text = "Copy Titles Over ==>";
            this.btnTitleCopy.UseVisualStyleBackColor = true;
            this.btnTitleCopy.Click += new System.EventHandler(this.btnTitleCopy_Click);
            // 
            // nudTitleEpOffset
            // 
            this.nudTitleEpOffset.Location = new System.Drawing.Point(65, 261);
            this.nudTitleEpOffset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTitleEpOffset.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudTitleEpOffset.Name = "nudTitleEpOffset";
            this.nudTitleEpOffset.Size = new System.Drawing.Size(57, 20);
            this.nudTitleEpOffset.TabIndex = 25;
            this.nudTitleEpOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkTitlePrepEpNo
            // 
            this.chkTitlePrepEpNo.AutoSize = true;
            this.chkTitlePrepEpNo.Location = new System.Drawing.Point(6, 169);
            this.chkTitlePrepEpNo.Name = "chkTitlePrepEpNo";
            this.chkTitlePrepEpNo.Size = new System.Drawing.Size(84, 17);
            this.chkTitlePrepEpNo.TabIndex = 8;
            this.chkTitlePrepEpNo.Text = "Episode No.";
            this.chkTitlePrepEpNo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Offset By:";
            // 
            // txtTitleEpisodePre
            // 
            this.txtTitleEpisodePre.Enabled = false;
            this.txtTitleEpisodePre.Location = new System.Drawing.Point(6, 142);
            this.txtTitleEpisodePre.Name = "txtTitleEpisodePre";
            this.txtTitleEpisodePre.Size = new System.Drawing.Size(123, 20);
            this.txtTitleEpisodePre.TabIndex = 7;
            // 
            // cboTitleEpisodePre
            // 
            this.cboTitleEpisodePre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTitleEpisodePre.FormattingEnabled = true;
            this.cboTitleEpisodePre.Items.AddRange(new object[] {
            "#",
            "E",
            "Episode ",
            "Custom"});
            this.cboTitleEpisodePre.Location = new System.Drawing.Point(6, 115);
            this.cboTitleEpisodePre.Name = "cboTitleEpisodePre";
            this.cboTitleEpisodePre.Size = new System.Drawing.Size(121, 21);
            this.cboTitleEpisodePre.TabIndex = 6;
            this.cboTitleEpisodePre.SelectedIndexChanged += new System.EventHandler(this.cboTitleEpisodePre_SelectedIndexChanged);
            // 
            // chkTitlePrepEpOffset
            // 
            this.chkTitlePrepEpOffset.AutoSize = true;
            this.chkTitlePrepEpOffset.Location = new System.Drawing.Point(6, 239);
            this.chkTitlePrepEpOffset.Name = "chkTitlePrepEpOffset";
            this.chkTitlePrepEpOffset.Size = new System.Drawing.Size(115, 17);
            this.chkTitlePrepEpOffset.TabIndex = 23;
            this.chkTitlePrepEpOffset.Text = "Offset Episode No.";
            this.chkTitlePrepEpOffset.UseVisualStyleBackColor = true;
            // 
            // txtTitleSeasonPre
            // 
            this.txtTitleSeasonPre.Location = new System.Drawing.Point(6, 66);
            this.txtTitleSeasonPre.Name = "txtTitleSeasonPre";
            this.txtTitleSeasonPre.Size = new System.Drawing.Size(123, 20);
            this.txtTitleSeasonPre.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Min. Digits:";
            // 
            // chkTitlePrepSeasonPre
            // 
            this.chkTitlePrepSeasonPre.AutoSize = true;
            this.chkTitlePrepSeasonPre.Location = new System.Drawing.Point(6, 43);
            this.chkTitlePrepSeasonPre.Name = "chkTitlePrepSeasonPre";
            this.chkTitlePrepSeasonPre.Size = new System.Drawing.Size(91, 17);
            this.chkTitlePrepSeasonPre.TabIndex = 3;
            this.chkTitlePrepSeasonPre.Text = "Season Prefix";
            this.chkTitlePrepSeasonPre.UseVisualStyleBackColor = true;
            // 
            // chkTitlePrepEpPrefix
            // 
            this.chkTitlePrepEpPrefix.AutoSize = true;
            this.chkTitlePrepEpPrefix.Location = new System.Drawing.Point(6, 92);
            this.chkTitlePrepEpPrefix.Name = "chkTitlePrepEpPrefix";
            this.chkTitlePrepEpPrefix.Size = new System.Drawing.Size(93, 17);
            this.chkTitlePrepEpPrefix.TabIndex = 1;
            this.chkTitlePrepEpPrefix.Text = "Episode Prefix";
            this.chkTitlePrepEpPrefix.UseVisualStyleBackColor = true;
            // 
            // chkTitlePrepShow
            // 
            this.chkTitlePrepShow.AutoSize = true;
            this.chkTitlePrepShow.Location = new System.Drawing.Point(6, 20);
            this.chkTitlePrepShow.Name = "chkTitlePrepShow";
            this.chkTitlePrepShow.Size = new System.Drawing.Size(76, 17);
            this.chkTitlePrepShow.TabIndex = 0;
            this.chkTitlePrepShow.Text = "Show Title";
            this.chkTitlePrepShow.UseVisualStyleBackColor = true;
            // 
            // chkTitlePrepEpiZeros
            // 
            this.chkTitlePrepEpiZeros.AutoSize = true;
            this.chkTitlePrepEpiZeros.Location = new System.Drawing.Point(6, 192);
            this.chkTitlePrepEpiZeros.Name = "chkTitlePrepEpiZeros";
            this.chkTitlePrepEpiZeros.Size = new System.Drawing.Size(125, 17);
            this.chkTitlePrepEpiZeros.TabIndex = 2;
            this.chkTitlePrepEpiZeros.Text = "\"0-Pad\" Episode No.";
            this.chkTitlePrepEpiZeros.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkFileSelectAll);
            this.groupBox2.Controls.Add(this.chkFileNameEditActivate);
            this.groupBox2.Controls.Add(this.pnlFileNames);
            this.groupBox2.Location = new System.Drawing.Point(508, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 342);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Names Edit";
            // 
            // chkFileSelectAll
            // 
            this.chkFileSelectAll.AutoSize = true;
            this.chkFileSelectAll.Location = new System.Drawing.Point(234, 0);
            this.chkFileSelectAll.Name = "chkFileSelectAll";
            this.chkFileSelectAll.Size = new System.Drawing.Size(117, 17);
            this.chkFileSelectAll.TabIndex = 36;
            this.chkFileSelectAll.Text = "Select/Deselect All";
            this.chkFileSelectAll.UseVisualStyleBackColor = true;
            this.chkFileSelectAll.CheckedChanged += new System.EventHandler(this.chkFileSelectAll_CheckedChanged);
            // 
            // chkFileNameEditActivate
            // 
            this.chkFileNameEditActivate.AutoSize = true;
            this.chkFileNameEditActivate.Location = new System.Drawing.Point(99, 0);
            this.chkFileNameEditActivate.Name = "chkFileNameEditActivate";
            this.chkFileNameEditActivate.Size = new System.Drawing.Size(65, 17);
            this.chkFileNameEditActivate.TabIndex = 1;
            this.chkFileNameEditActivate.Text = "Activate";
            this.chkFileNameEditActivate.UseVisualStyleBackColor = true;
            // 
            // pnlFileNames
            // 
            this.pnlFileNames.AutoScroll = true;
            this.pnlFileNames.Location = new System.Drawing.Point(7, 19);
            this.pnlFileNames.Name = "pnlFileNames";
            this.pnlFileNames.Size = new System.Drawing.Size(338, 317);
            this.pnlFileNames.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkFilePrepDash);
            this.groupBox3.Controls.Add(this.nudFileEpOffset);
            this.groupBox3.Controls.Add(this.chkFilePrepEpNo);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtFileEpisodePre);
            this.groupBox3.Controls.Add(this.cboFileEpisodePre);
            this.groupBox3.Controls.Add(this.chkFilePrepEpOffset);
            this.groupBox3.Controls.Add(this.txtFileSeasonPre);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.chkFilePrepSeasonPre);
            this.groupBox3.Controls.Add(this.chkFilePrepEpPrefix);
            this.groupBox3.Controls.Add(this.chkFilePrepShow);
            this.groupBox3.Controls.Add(this.chkFilePrepEpiZeros);
            this.groupBox3.Controls.Add(this.nudFileMinDigits);
            this.groupBox3.Location = new System.Drawing.Point(865, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 342);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Prepend";
            // 
            // chkFilePrepDash
            // 
            this.chkFilePrepDash.AutoSize = true;
            this.chkFilePrepDash.Location = new System.Drawing.Point(6, 291);
            this.chkFilePrepDash.Name = "chkFilePrepDash";
            this.chkFilePrepDash.Size = new System.Drawing.Size(88, 17);
            this.chkFilePrepDash.TabIndex = 26;
            this.chkFilePrepDash.Text = "Prepend \" - \"";
            this.chkFilePrepDash.UseVisualStyleBackColor = true;
            // 
            // nudFileEpOffset
            // 
            this.nudFileEpOffset.Location = new System.Drawing.Point(65, 261);
            this.nudFileEpOffset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudFileEpOffset.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudFileEpOffset.Name = "nudFileEpOffset";
            this.nudFileEpOffset.Size = new System.Drawing.Size(57, 20);
            this.nudFileEpOffset.TabIndex = 25;
            this.nudFileEpOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkFilePrepEpNo
            // 
            this.chkFilePrepEpNo.AutoSize = true;
            this.chkFilePrepEpNo.Location = new System.Drawing.Point(6, 169);
            this.chkFilePrepEpNo.Name = "chkFilePrepEpNo";
            this.chkFilePrepEpNo.Size = new System.Drawing.Size(84, 17);
            this.chkFilePrepEpNo.TabIndex = 8;
            this.chkFilePrepEpNo.Text = "Episode No.";
            this.chkFilePrepEpNo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Offset By:";
            // 
            // txtFileEpisodePre
            // 
            this.txtFileEpisodePre.Enabled = false;
            this.txtFileEpisodePre.Location = new System.Drawing.Point(6, 142);
            this.txtFileEpisodePre.Name = "txtFileEpisodePre";
            this.txtFileEpisodePre.Size = new System.Drawing.Size(123, 20);
            this.txtFileEpisodePre.TabIndex = 7;
            // 
            // cboFileEpisodePre
            // 
            this.cboFileEpisodePre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileEpisodePre.FormattingEnabled = true;
            this.cboFileEpisodePre.Items.AddRange(new object[] {
            "#",
            "E",
            "Episode ",
            "Custom"});
            this.cboFileEpisodePre.Location = new System.Drawing.Point(6, 115);
            this.cboFileEpisodePre.Name = "cboFileEpisodePre";
            this.cboFileEpisodePre.Size = new System.Drawing.Size(121, 21);
            this.cboFileEpisodePre.TabIndex = 6;
            this.cboFileEpisodePre.SelectedIndexChanged += new System.EventHandler(this.cboFileEpisodePre_SelectedIndexChanged);
            // 
            // chkFilePrepEpOffset
            // 
            this.chkFilePrepEpOffset.AutoSize = true;
            this.chkFilePrepEpOffset.Location = new System.Drawing.Point(6, 239);
            this.chkFilePrepEpOffset.Name = "chkFilePrepEpOffset";
            this.chkFilePrepEpOffset.Size = new System.Drawing.Size(115, 17);
            this.chkFilePrepEpOffset.TabIndex = 23;
            this.chkFilePrepEpOffset.Text = "Offset Episode No.";
            this.chkFilePrepEpOffset.UseVisualStyleBackColor = true;
            // 
            // txtFileSeasonPre
            // 
            this.txtFileSeasonPre.Location = new System.Drawing.Point(6, 66);
            this.txtFileSeasonPre.Name = "txtFileSeasonPre";
            this.txtFileSeasonPre.Size = new System.Drawing.Size(123, 20);
            this.txtFileSeasonPre.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Min. Digits:";
            // 
            // chkFilePrepSeasonPre
            // 
            this.chkFilePrepSeasonPre.AutoSize = true;
            this.chkFilePrepSeasonPre.Location = new System.Drawing.Point(6, 43);
            this.chkFilePrepSeasonPre.Name = "chkFilePrepSeasonPre";
            this.chkFilePrepSeasonPre.Size = new System.Drawing.Size(91, 17);
            this.chkFilePrepSeasonPre.TabIndex = 3;
            this.chkFilePrepSeasonPre.Text = "Season Prefix";
            this.chkFilePrepSeasonPre.UseVisualStyleBackColor = true;
            // 
            // chkFilePrepEpPrefix
            // 
            this.chkFilePrepEpPrefix.AutoSize = true;
            this.chkFilePrepEpPrefix.Location = new System.Drawing.Point(6, 92);
            this.chkFilePrepEpPrefix.Name = "chkFilePrepEpPrefix";
            this.chkFilePrepEpPrefix.Size = new System.Drawing.Size(93, 17);
            this.chkFilePrepEpPrefix.TabIndex = 1;
            this.chkFilePrepEpPrefix.Text = "Episode Prefix";
            this.chkFilePrepEpPrefix.UseVisualStyleBackColor = true;
            // 
            // chkFilePrepShow
            // 
            this.chkFilePrepShow.AutoSize = true;
            this.chkFilePrepShow.Location = new System.Drawing.Point(6, 20);
            this.chkFilePrepShow.Name = "chkFilePrepShow";
            this.chkFilePrepShow.Size = new System.Drawing.Size(76, 17);
            this.chkFilePrepShow.TabIndex = 0;
            this.chkFilePrepShow.Text = "Show Title";
            this.chkFilePrepShow.UseVisualStyleBackColor = true;
            // 
            // chkFilePrepEpiZeros
            // 
            this.chkFilePrepEpiZeros.AutoSize = true;
            this.chkFilePrepEpiZeros.Location = new System.Drawing.Point(6, 192);
            this.chkFilePrepEpiZeros.Name = "chkFilePrepEpiZeros";
            this.chkFilePrepEpiZeros.Size = new System.Drawing.Size(125, 17);
            this.chkFilePrepEpiZeros.TabIndex = 2;
            this.chkFilePrepEpiZeros.Text = "\"0-Pad\" Episode No.";
            this.chkFilePrepEpiZeros.UseVisualStyleBackColor = true;
            // 
            // nudFileMinDigits
            // 
            this.nudFileMinDigits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudFileMinDigits.Location = new System.Drawing.Point(92, 213);
            this.nudFileMinDigits.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudFileMinDigits.Name = "nudFileMinDigits";
            this.nudFileMinDigits.Size = new System.Drawing.Size(29, 20);
            this.nudFileMinDigits.TabIndex = 21;
            this.nudFileMinDigits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 611);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxTitlePrep);
            this.Controls.Add(this.txtShowTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoadDir);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtxLog);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.llbMKVToolNix);
            this.Controls.Add(this.lblAppInfo);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MKVBatchTitleRenamerThingy";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTitleMinDigits)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxTitlePrep.ResumeLayout(false);
            this.gbxTitlePrep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTitleEpOffset)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileEpOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileMinDigits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataFromMKVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataFromDirectoryOfMKVFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToMKVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mKVToolNixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToMKVToolNixHomepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToMKVToolNixDownloadPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem;
        private System.Windows.Forms.Label lblAppInfo;
        private System.Windows.Forms.LinkLabel llbMKVToolNix;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.NumericUpDown nudTitleMinDigits;
        private System.Windows.Forms.Panel pnlTitles;
        private System.Windows.Forms.OpenFileDialog ofdMKV;
        private System.Windows.Forms.RichTextBox rtxLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.Button btnLoadDir;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShowTitle;
        private System.Windows.Forms.GroupBox gbxTitlePrep;
        private System.Windows.Forms.CheckBox chkTitlePrepSeasonPre;
        private System.Windows.Forms.CheckBox chkTitlePrepEpiZeros;
        private System.Windows.Forms.CheckBox chkTitlePrepEpPrefix;
        private System.Windows.Forms.CheckBox chkTitlePrepShow;
        private System.Windows.Forms.TextBox txtTitleSeasonPre;
        private System.Windows.Forms.TextBox txtTitleEpisodePre;
        private System.Windows.Forms.ComboBox cboTitleEpisodePre;
        private System.Windows.Forms.CheckBox chkTitlePrepEpOffset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog fbdMKVDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudTitleEpOffset;
        private System.Windows.Forms.CheckBox chkTitlePrepEpNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlFileNames;
        private System.Windows.Forms.CheckBox chkTitleEditActivate;
        private System.Windows.Forms.CheckBox chkFileNameEditActivate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudFileEpOffset;
        private System.Windows.Forms.CheckBox chkFilePrepEpNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFileEpisodePre;
        private System.Windows.Forms.ComboBox cboFileEpisodePre;
        private System.Windows.Forms.CheckBox chkFilePrepEpOffset;
        private System.Windows.Forms.TextBox txtFileSeasonPre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkFilePrepSeasonPre;
        private System.Windows.Forms.CheckBox chkFilePrepEpPrefix;
        private System.Windows.Forms.CheckBox chkFilePrepShow;
        private System.Windows.Forms.CheckBox chkFilePrepEpiZeros;
        private System.Windows.Forms.NumericUpDown nudFileMinDigits;
        private System.Windows.Forms.CheckBox chkFilePrepDash;
        private System.Windows.Forms.Button btnTitleCopy;
        private System.Windows.Forms.CheckBox chkTitleSelectAll;
        private System.Windows.Forms.CheckBox chkFileSelectAll;
    }
}

