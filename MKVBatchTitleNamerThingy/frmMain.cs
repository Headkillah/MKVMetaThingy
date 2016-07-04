using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MKVMetaThingyUtils;

namespace MKVBatchTitleNamerThingy
{
    public partial class frmMain : Form
    {
        #region globals

        string[] mkvFiles;

        Label[] lblTitleFileNames;      // Globally initialize some arrays used throughout program
        TextBox[] txtTitles;
        CheckBox[] chkTitleEdit;

        Label[] lblFileFileNames;
        TextBox[] txtFileNames;
        CheckBox[] chkFileEdit;

        #endregion globals

        #region init

        public frmMain()
        {
            InitializeComponent();
            // Get Form icon from exe icon
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        #endregion init

        #region events

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Update APpInfo label with app name and version
            lblAppInfo.Text = Application.ProductName + " ver" + Application.ProductVersion + lblAppInfo.Text;

            // Disable some controls until data is loaded
            btnTitleCopy.Enabled = false;
            chkTitleSelectAll.Enabled = false;
            chkFileSelectAll.Enabled = false;

            // Enabling/Disabling some default options
            chkTitlePrepShow.Checked = true;
            chkTitlePrepEpPrefix.Checked = true;
            chkTitlePrepEpNo.Checked = true;
            cboTitleEpisodePre.SelectedItem = "#";

            chkFilePrepSeasonPre.Checked = true;
            chkFilePrepEpPrefix.Checked = true;
            chkFilePrepEpiZeros.Checked = true;
            chkFilePrepEpNo.Checked = true;
            chkFilePrepDash.Checked = true;
            nudFileMinDigits.Value = 2;
            txtFileSeasonPre.Text = "S0";
            cboFileEpisodePre.SelectedItem = "E";

            // Check for MKVToolNix installed on system
            if (!MKVToolNix.IsInstalled())
            {
                UnlockFormControls(false);
                MKVToolNix.FoundNotify(false);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void btnLoadDir_Click(object sender, EventArgs e)
        {
            LoadDir();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnTitleCopy_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < txtFileNames.Length; i++)           // For each file name...
                txtFileNames[i].Text = txtTitles[i].Text;           // Get the respective title from it's title textbox and copy it to the filename textbox
        }

        private void loadDataFromMKVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void loadDataFromDirectoryOfMKVFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDir();
        }

        private void saveDataToMKVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void goToMKVToolNixHomepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenURL(MKVToolNix.urlHome);
        }

        private void goToMKVToolNixDownloadPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenURL(MKVToolNix.urlDownload);
        }

        private void recheckToSeeIfMKVToolNixIsInstalledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool installed = MKVToolNix.IsInstalled();

            UnlockFormControls(installed);
            MKVToolNix.FoundNotify(installed);
        }

        private void llbMKVToolNix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURL(MKVToolNix.urlHome);
        }

        private void cboTitleEpisodePre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cboTitleEpisodePre.SelectedItem == "Custom")    // If selected prefix is "Custom"
                txtTitleEpisodePre.Enabled = true;                      // Enable the custom prefix input textbox
            else
                txtTitleEpisodePre.Enabled = false;                     // Otherwise disable the textbox
        }

        private void cboFileEpisodePre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cboFileEpisodePre.SelectedItem == "Custom")     // If selected prefix is "Custom"
                txtFileEpisodePre.Enabled = true;                       // Enable the custom prefix input textbox
            else
                txtFileEpisodePre.Enabled = false;                      // Otherwise disable the textbox
        }

        private void chkTitleSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkTitleEdit.Length; i++)                           // For each "Edit" Checkbox in title panel...
                chkTitleEdit[i].Checked = chkTitleSelectAll.Checked;                // Set them all to SelectAll Checked value
        }

        private void chkFileSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkFileEdit.Length; i++)                            // For each "Edit" Checkbox in file name panel...
                chkFileEdit[i].Checked = chkFileSelectAll.Checked;                  // Set them all to SelectAll Checked value
        }

        #endregion events

        #region methods

        /// <summary>
        /// Method to lock/unlock form controls based on supplied value
        /// </summary>
        /// <param name="unlocked">Boolean representing whether to lock or unlock certain form controls</param>
        private void UnlockFormControls(bool unlocked)
        {
            loadDataFromMKVToolStripMenuItem.Enabled = unlocked;                    // Controls to lock unlock
            loadDataFromDirectoryOfMKVFilesToolStripMenuItem.Enabled = unlocked;
            saveDataToMKVToolStripMenuItem.Enabled = unlocked;
            btnLoad.Enabled = unlocked;
            btnLoadDir.Enabled = unlocked;
            btnSave.Enabled = unlocked;
        }

        /// <summary>
        /// Method to load files with an OpenFileDialog
        /// </summary>
        private void LoadFile()
        {
            DialogResult result = ofdMKV.ShowDialog();      // Show dialog and get result from it
            if (result == DialogResult.OK)                  // If user clicks OK
            {
                rtxLog.Clear();                                     // Clear the log
                List<string> goodFileNames = new List<string>();    // make new list for fileNames are are actually .mkv files

                for (int i = 0; i < ofdMKV.FileNames.Length; i++)   // For each of the selected files...
                {
                    if (ofdMKV.FileNames[i].EndsWith(".mkv"))           // Sanity checking: if the file name ends with .mkv...
                        goodFileNames.Add(ofdMKV.FileNames[i]);             // Add it to the "good file names" list
                    else
                        rtxLog.SendToLog("ERROR!: Selected file is not an .mkv file! Skipping... (" + ofdMKV.FileNames[i] + ")");   // Otherwise print error to log
                }

                mkvFiles = goodFileNames.ToArray();                 // Convert good file name List to Array for LoadFileInfo()

                if (mkvFiles.Length < 1)                            // If there are no filenames in array...
                    rtxLog.SendToLog("ERROR!: There are no .mkv files selected! Nothing to do.");   // Print error to log regarding this and do nothing else
                else
                    LoadFileInfo();                                 // Otherwise load the file info into form
            }
        }

        /// <summary>
        /// Method to load a whole directory of files with a FolderBrowserDialog
        /// </summary>
        private void LoadDir()
        {
            // Set description in dialog box
            fbdMKVDir.Description = "Please select the folder containing all the .mkv files you want to modify:";
            DialogResult result = fbdMKVDir.ShowDialog();       // Show dialog and get result from it
            if (result == DialogResult.OK)                      // If user clicked OK...
            {
                rtxLog.Clear();                                                     // Clear the log
                mkvFiles = Directory.GetFiles(fbdMKVDir.SelectedPath, "*.mkv");     // Get the filepaths for each .mkv file in directory and store in array

                if (mkvFiles.Length < 1)                                                // If there are no .mkv files...
                    rtxLog.SendToLog("ERROR!: There are no .mkv files in this folder! (" + fbdMKVDir.SelectedPath + ")");   // Print error to log regarding this and do nothing else
                else
                    LoadFileInfo();                                                     // Otherwise load the file info to form
            }
        }

        /// <summary>
        /// Method to initialize a panel with its various controls
        /// </summary>
        /// <param name="pnl">The Panel to initialize</param>
        /// <param name="fileCount">Amount of files to init controls for</param>
        /// <param name="labelArray">The array for the Labels going in this Panel</param>
        /// <param name="textBoxArray">The array for the TextBoxes going in this Panel</param>
        /// <param name="checkBoxArray">The array for the "Edit" CheckBoxes going in this Panel</param>
        private void InitPanel(Panel pnl, int fileCount, Label[] labelArray, TextBox[] textBoxArray, CheckBox[] checkBoxArray)
        {
            int left = 0;                       // Initialize some coordinate-related values
            int labelTop = 0;
            int textBoxTop = labelTop + 25;
            int controlGap = textBoxTop + 40;

            if (pnl.Controls.Count > 0)         // If there are still controls in this panel...
            {
                pnl.Controls.Clear();           // Clear Controls from Panel
                for (int i = pnl.Controls.Count - 1; i >= 0; i--)   // For each of the Panel's Controls... (Need reverse for loop for Control.Dispose())
                    pnl.Controls[i].Dispose();  // Dispose of it to remove it from memory
            }

            for (int i = 0; i < fileCount; i++)             // For each of the files...
            {
                Label trackNo = new Label();                // mMke new Label to display track no.
                trackNo.Left = left;                        // Set position of label in panel
                trackNo.Top = controlGap * i;
                trackNo.Text = "File No." + (i + 1) + ":";  // Set text for this label
                trackNo.Width = 60;                         // Set width for this label
                pnl.Controls.Add(trackNo);                  // Add it to Panel

                labelArray[i] = new Label();                // make new Label in labelArray
                labelArray[i].Left = 65;                    // Set position of label in Panel
                labelArray[i].Top = controlGap * i;
                labelArray[i].Width = 210;                  // Set width of label
                pnl.Controls.Add(labelArray[i]);            // Add it to Panel

                textBoxArray[i] = new TextBox();            // Make new TextBox in textBoxArray
                textBoxArray[i].Left = left;                // Set position of TextBox in Panel
                textBoxArray[i].Top = textBoxTop + (controlGap * i);
                textBoxArray[i].Width = 300;                // Set width of TextBox
                pnl.Controls.Add(textBoxArray[i]);          // Add it to Panel

                checkBoxArray[i] = new CheckBox();          // make new CheckBox in checkBoxArray
                checkBoxArray[i].Text = "Edit";             // Set Text for CheckBox
                checkBoxArray[i].Left = 275;                // Set position of CheckBox in Panel
                checkBoxArray[i].Top = (controlGap * i) - 5;
                checkBoxArray[i].Width = 45;                // Set witdh of CheckBox control
                checkBoxArray[i].Checked = true;            // Set default checked value
                pnl.Controls.Add(checkBoxArray[i]);         // Add it to Panel
            }
        }

        /// <summary>
        /// Method to load the data from files to fform
        /// </summary>
        private void LoadFileInfo()
        {
            string exeName = "\"" + MKVToolNix.ExeGetPath(MKVToolNix.mkvmergeExe) + "\"";   // Get path for mkvmeerge and wrap in quotes for RunProcess arg
            int fileCount = mkvFiles.Length;                                // Get count of files loaded

            lblTitleFileNames = new Label[fileCount];                       // Make new TitleFileNames Array
            txtTitles = new TextBox[fileCount];                             // make new TitlesTextBox array
            chkTitleEdit = new CheckBox[fileCount];                         // make new "Edit" CheckBox array for titles
            InitPanel(pnlTitles, fileCount, lblTitleFileNames, txtTitles, chkTitleEdit);    // Init Titles Panel with these arrays

            lblFileFileNames = new Label[fileCount];                        // Make new FileFileNames Array
            txtFileNames = new TextBox[fileCount];                          // make new FileNamesTextBox array
            chkFileEdit = new CheckBox[fileCount];                          // make new "Edit" CheckBox array for filenames
            InitPanel(pnlFileNames, fileCount, lblFileFileNames, txtFileNames, chkFileEdit);    // Init filenames Panel with these arrays

            lblDir.Text = Path.GetDirectoryName(mkvFiles[0]);               // Get directory of loaded files for dir Label
            for (int i = 0; i < fileCount; i++)                             // For each file...
            {
                // Set the dynamic json object to...
                // ...the output derived from the JSON string...
                // ...which is taken from the output from mkvmerge.exe
                dynamic json = Utils.GetJsonObject(Utils.RunProcess(exeName, "-i -F json \"" + mkvFiles[i] + "\""));
                
                lblTitleFileNames[i].Text = Path.GetFileName(mkvFiles[i]);  // Get Filename of file and add its element in Label arrays, and to main filenames "Label" (it is really a textbox)
                lblFileFileNames[i].Text = Path.GetFileName(mkvFiles[i]);
                txtFileNames[i].Text = Path.GetFileName(mkvFiles[i]);

                try
                {
                    txtTitles[i].Text = json["container"]["properties"]["title"];   // Try to display video Title from JSON Object
                }
                catch (KeyNotFoundException)
                {
                    myDebug.WriteLine("This mkv has no Title set, using blank one... ");
                    txtTitles[i].Text = "";                                         // Display blank title if not present
                }
            }
            btnTitleCopy.Enabled = true;                // Enable Copy Titles Over button, and the select all checkboxes
            chkTitleSelectAll.Enabled = true;
            chkFileSelectAll.Enabled = true;
            txtShowTitle.Focus();                       // Put cursor focus on the shot title textbox for user to type in the show's title
        }

        /// <summary>
        /// Default Save wrapper method that calls both the title saving and filename saving methods
        /// </summary>
        private void Save()
        {
            rtxLog.Clear();                         // Clear log

            if (chkTitleEditActivate.Checked)       // If title "Activate" checkbox is checked...
                SaveTitleNames();                   // Save the titles

            if (chkFileNameEditActivate.Checked)    // If file "Activate" checkbox is checked...
                SaveFileNames();                    // Save the filenames
        }

        /// <summary>
        /// Method to save modified internal titles inside each file
        /// </summary>
        private void SaveTitleNames()
        {
            int filesModified = 0;                              // Initialize count of successfully modified files
            int fileCount = lblTitleFileNames.Length;           // Get cunt of all files
            string retStr = null;                               // init string retStr for RunProcess output
            string exeName = "\"" + MKVToolNix.ExeGetPath(MKVToolNix.mkvpropeditExe) + "\"";    // Get path for mkvpropedit.exe and wrap in quotes for RunProcess arg
            string sType = "s";                                 // init setting type string, default is "s"

            for (int i = 0; i < fileCount; i++)                 // For each file...
            {
                string filePath = "\"" + mkvFiles[i] + "\"";    // get file path and wrap in quotes for RunProcess arg 

                rtxLog.SendToLog("TITLE SAVE: File No." + (i + 1) + " of " + fileCount + ": " + filePath);

                if (chkTitleEdit[i].Checked == true)                        // If "Edit" checkbox is checked...
                {
                    int epNum = i + 1;                                      // get episode no.
                    StringBuilder title = new StringBuilder();              // Initialize new StringBUilder for title

                    if (chkTitlePrepShow.Checked)                           // If "Prepend Show Title" is checked...
                        title.Append(txtShowTitle.Text + " ");              // Add show title to title

                    if (chkTitlePrepSeasonPre.Checked)                      // If "Prepend Season Prefix" is checked...
                        title.Append(txtTitleSeasonPre.Text);               // Add season prefix to title

                    if (chkTitlePrepEpPrefix.Checked)                       // If "Prepend Episode Prefix" is checked...
                        if ((string)cboTitleEpisodePre.SelectedItem == "Custom")    // If selected prefix is "Custom"...
                            title.Append(txtTitleEpisodePre.Text);                  // Add custom prefix to title
                        else
                            title.Append(cboTitleEpisodePre.SelectedItem);  // Otherwise add selected prefix to title

                    if (chkTitlePrepEpOffset.Checked)                       // "Offset Episode no." is checked...
                        epNum += (int)nudTitleEpOffset.Value;               // Offset episode no. by amount in respective numeric up-down

                    if (chkTitlePrepEpiZeros.Checked)                       // If "Prepend leading zeros" is checked...
                    {
                        int baseNum = 10;                                   // Base is 10
                        int power = (int)nudTitleMinDigits.Value - 1;       // power is minumim anount of digits minus one

                        for (int p = power; p > 0; p--)                     // For each power...
                            if (epNum < baseNum.PowerOf(power))             // If episode no. is less than 10 to the power of power...
                                title.Append("0");                          // add a "0" to title
                    }

                    if (chkTitlePrepEpNo.Checked)                           // If "Prepend Episode No." is checked...
                            title.Append(epNum.ToString() + " ");           // Add the episode no. to title

                    title.Append(txtTitles[i].Text);                        // Add the title textbox contrnts to title

                    string arg = " -e info -" + sType + " \"title=" + title.ToString() + "\"";  // make track edit args for mkvpropedit

                    retStr = Utils.RunProcess(exeName, filePath + arg);     // Run mkvpropedit with specified args
                    rtxLog.SendToLog(exeName + " " + filePath + arg);       // Send full command to log
                    rtxLog.SendToLog(retStr);                               // Send output from mkvpropedit to log

                    while (retStr != MKVToolNix.mkvpropedit_ReturnOK)       // While mkvpropedit returns something that is not "OK"...
                    {   // If returned message is file could not be accessed...
                        if (retStr.Contains("The file is being analyzed.\r\nError: This file could not be opened or parsed.\r\n"))
                        {
                            // Send error to log, and skip file
                            rtxLog.SendToLog("ERROR: could not seem to access this file, Skipping..." + Environment.NewLine);
                            //filesModified--;
                            break;
                        }
                    }
                    filesModified++;    // increment filesModified
                }
                else
                {   // If the "Edit" checkbox is not checked, send notice to log and move to next file
                    rtxLog.SendToLog("This file is not marked for editing. Skipping..." + Environment.NewLine);
                }
            }
            // Once done, if there was more than one file involved, display batch message with amount of successfully modified files
            if (fileCount > 1)
                MessageBox.Show(filesModified + " of " + mkvFiles.Length + " files successfully modified!" + Environment.NewLine +
                    Environment.NewLine +
                    "Check the log for more details.", "Batch title save complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Method to save the modified file names, renaming the respective files
        /// </summary>
        private void SaveFileNames()
        {
            int filesModified = 0;                          // Initialize counnt for amount of files successfully modified
            int fileCount = lblFileFileNames.Length;        // Get file count

            for (int i = 0; i < fileCount; i++)                 // For each file...
            {
                string filePath = "\"" + mkvFiles[i] + "\"";    // Wrap filename in quotes for RunProcess arg

                rtxLog.SendToLog("RENAME: File No." + (i + 1) + " of " + fileCount + ": " + filePath);

                if (chkFileEdit[i].Checked == true)                 // If the "Edit" checkbox for this track is checked...
                {
                    int epNum = i + 1;                              // Initialize episode no.
                    StringBuilder fileName = new StringBuilder();   // Initialize new StringBuilder for new file name

                    if (chkFilePrepShow.Checked)                    // If "Prepend Show Title"
                        fileName.Append(txtShowTitle.Text + " ");   // Add Show Title plus a trailing space to filename

                    if (chkFilePrepSeasonPre.Checked)               // If "Prepend Season Prefix" is checked...
                        fileName.Append(txtFileSeasonPre.Text);     // Add Season Prefix to filename

                    if (chkFilePrepEpPrefix.Checked)                // If "Prepend Episode Prefix"is checked...
                        if ((string)cboFileEpisodePre.SelectedItem == "Custom") // If prefix type is Custom...
                            fileName.Append(txtFileEpisodePre.Text);            // Append Custom episode prefix to filename
                        else
                            fileName.Append(cboFileEpisodePre.SelectedItem);    // Otherwise appeend selectedprefix to filename

                    if (chkFilePrepEpOffset.Checked)                // If "Offset Episode No." is checked...
                        epNum += (int)nudFileEpOffset.Value;        // Offset the episode no. by the amount specified in the respective numeric up-down

                    if (chkFilePrepEpNo.Checked)                    // If "Prepend Episode No." is checked...
                    {
                        if (chkFilePrepEpiZeros.Checked)            // If "Prepend zeros to episode no." is checked...
                        {
                            int baseNum = 10;                               // Base is 10
                            int power = (int)nudFileMinDigits.Value - 1;    // "to the power of" is the minimum amount of digits minus one

                            for (int p = power; p > 0; p--)         // For each power
                                if (epNum < baseNum.PowerOf(power)) // if the episode no is less than 10 to the power of power
                                    fileName.Append("0");           // Add a leading "0" to filename
                        }
                        fileName.Append(epNum.ToString() + " ");    // Append the episode no. to filename
                    }
                    
                    if (chkFilePrepDash.Checked)                    // If "Prepend " - " " is checked
                        fileName.Append("- ");                      // add the "- " to filename

                    fileName.Append(txtFileNames[i].Text);          // Add the file name textbox contents to filename

                    if (!fileName.ToString().EndsWith(".mkv"))      // If filename does not already end with ".mkv"
                        fileName.Append(".mkv");                    // then add ".mkv"

                    string newFileName = fileName.ToString();       // Get string from filename StringBuilder
                    string newFilePath = lblDir.Text + "\\" + newFileName;  //use it to create full path

                    if (newFileName == "")                          // Ifthe new file name string is blank...
                    {
                        rtxLog.SendToLog("ERROR: No new file name set, Skipping..." + Environment.NewLine);
                        break;                                      // Then print error to log and skip this file
                    }

                    if (File.Exists(mkvFiles[i]) && (!File.Exists(newFilePath)))    // If the file you are trying to rename still exists AND the file with newFileName does not already exist...
                    {
                        try
                        {
                            // Try to rename the file to the new filename
                            rtxLog.SendToLog("Trying to rename \"" + mkvFiles[i] + "\" to \"" + newFilePath + "\"...");
                            File.Move(mkvFiles[i], newFilePath);
                        }
                        catch (ArgumentException)
                        {
                            // If that fails due to invalid characters in name, print error to log and skip file
                            rtxLog.SendToLog("ERROR: new file name contains invalid characters. Skipping..." + Environment.NewLine);
                            break;
                        }
                    }
                    else
                    {                                           // Otherwise...
                        if (!File.Exists(mkvFiles[i]))          // If the file does not exist for whatever reason...
                        {
                            // print error to log and skip file
                            rtxLog.SendToLog("ERROR: File does not actually seem to exist... Skipping..." + Environment.NewLine);
                            break;
                        }

                        if (File.Exists(newFilePath))           // If file with newFileName already exists...
                        {
                            // print error to log and skip file
                            rtxLog.SendToLog("ERROR: File at " + newFilePath + " already exists. Skipping..." + Environment.NewLine);
                            break;
                        }
                    }
                    mkvFiles[i] = newFilePath;                  // Update mkvfiles array with filenames of successfully renamed files
                    filesModified++;                            // Increnemt filesModified
                    rtxLog.SendToLog("Looks like file rename was successful.");
                }
                else
                {   // If the "Edit" checkbox is not checked, send notice to log and move to next file
                    rtxLog.SendToLog("This file is not marked for editing. Skipping..." + Environment.NewLine);
                }
            }
            // Once done, if there was more than one file involved, display batch message with amount of successfully modified files
            if (fileCount > 1)
                MessageBox.Show(filesModified + " of " + mkvFiles.Length + " files successfully renamed!" + Environment.NewLine +
                    Environment.NewLine +
                    "Check the log for more details.", "Batch file rename complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion methods
    }
}
