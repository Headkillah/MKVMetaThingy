using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MKVMetaThingyUtils;

namespace MKVDefaultTrackChangerThingy
{
    public partial class frmMain : Form
    {
        #region globals

        /// <summary>
        /// List to add audio tracks in file to ListBox
        /// </summary>
        List<string> audioTracks;

        /// <summary>
        /// List to add subtitletracks in file in ListBox
        /// </summary>
        List<string> subTracks;

        #endregion globals

        #region init

        /// <summary>
        /// Main constructor for form
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);     // Set form icon to one in program's exe
        }

        #endregion init

        #region events

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Add application information to lblAppInfo label
            lblAppInfo.Text = Application.ProductName + " ver" + Application.ProductVersion + lblAppInfo.Text;

            if(!MKVToolNix.IsInstalled())           // Check for MKVTOolNix, and if MKVToolNix is not found in computer...
            {
                UnlockFormControls(false);          // Lock some form controls
                MKVToolNix.FoundNotify(false);      // Notify the user of the result of the check
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadFileInfo();                         // Load track info from file
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveNewSettings();                      // Save the selecetd settings to file(s)
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFileInfo();                         // Load track info from file
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveNewSettings();                      // Save the selecetd settings to file(s)
        }

        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();                     // Exit Program
        }

        private void userIsInsaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserIsInsaneWarning();                  // Display Warning message to user for batch mode
        }

        private void goToMKVToolNixsHomepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenURL(MKVToolNix.urlHome);      // Open the URL to the MKVToolNix Homepage in user's default browser
        }

        private void goToMKVToolNixdownloadPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenURL(MKVToolNix.urlDownload);  // Open the URL to the MKVToolNix Download Page in user's default browser
        }

        /// <summary>
        /// Event that rechecks if MKVToolNix is installed, notifies the user of the result, and locks/unlocks some form controls depending on the result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recheckToSeeIfMKVToolNixIsInstalledOnThisMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool installed = MKVToolNix.IsInstalled();      // Check if MKVToolNix is installed

            UnlockFormControls(installed);                  // Lock or Unlock certain form controls depending on result of above
            MKVToolNix.FoundNotify(installed);              // Display message to user depending on result of above
        }

        private void llbMKVToolNix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURL(MKVToolNix.urlHome);      // Open the URL to the MKVToolNix Homepage in user's default browser
        }

        #endregion events

        #region methods

        /// <summary>
        /// Method that identifies the Audio and Subtitle tracks from the dynamic object and puts their names in the respective listbox
        /// </summary>
        /// <param name="json">the dynamic json object obtained from GetJsonObject()</param>
        private void GetTracks(dynamic json)
        {
            int audioCount = 0;         // Initialize counts and selected values
            int subCount = 0;                                           
            int defaultAudio = 0;                                       
            int defaultSub = 0;                                         

            InitListBoxes();            // Initialize the ListBoxes

            for (int i = 0; i < json["tracks"].Length; i++)             // For each track...
            {
                string trackType = json["tracks"][i]["type"];           // Get the track type
                
                if (trackType == "audio" || trackType == "subtitles")   //  if the track type is audio or subtitle
                {
                    string trackName;                                   // Declare track name an isDefault vars
                    bool trackIsDefault;
                    
                    try
                    {
                        trackName = json["tracks"][i]["properties"]["track_name"];      // Try to get the track name from dynamic object
                    }
                    catch (KeyNotFoundException)
                    {
                        myDebug.WriteLine("Track No." + i + " has no name... using blank name instead.");
                        trackName = "";                                                 // If it is not even present in object, use blank name instead
                    }

                    try
                    {
                        trackIsDefault = json["tracks"][i]["properties"]["default_track"];  // Try to get the default track flag value from dynamic object
                    }
                    catch (KeyNotFoundException)
                    {
                        myDebug.WriteLine("Track No." + i + "'s \"Default Track\" flag does not even exist... using blank name instead.");
                        trackIsDefault = false;                                         // If it is not even present in object, use default of false
                    }

                    string trackLang = json["tracks"][i]["properties"]["language"].ToUpper();   // Get track language code from dynamic object
                    string listItem = trackLang + " - " + trackName;                            // Construct List Item string in format of "LANG - Track Name"
                    myDebug.WriteLine(trackType.ToUpper() + "\t" + trackLang + "\t" + trackIsDefault + "\t" + trackName);

                    switch (trackType)
                    {
                        case "audio":                       // If this track is an audio track
                            audioCount++;                   // Increment audio track counter
                            audioTracks.Add(listItem);      // Add constructed List Item to audioTracks list
                            if (trackIsDefault)             // If this track is the default audio track
                                defaultAudio = audioCount;  // Set the defaultAudio value to the current audio track count
                            break;

                        case "subtitles":                   // If this track is a subtitle track
                            subCount++;                     // Incremnt subtitle track counter
                            subTracks.Add(listItem);        // Add constructed List Item to subTracks list
                            if (trackIsDefault)             // If this track is the default subtitle track
                                defaultSub = subCount;      // Set the defaultSub value to the current subtitle track count
                            break;
                    }
                }
            }
            RefreshListBoxes();                             // Refresh the ListBoxes with the updated lists
            lbxAudio.SelectedIndex = defaultAudio;          // Set the Selected value of the audio ListBox to match the defaultAudio value
            lbxSubtitle.SelectedIndex = defaultSub;         // Set the Selected value of the subtitle ListBox to match the defaultSub value
        }

        /// <summary>
        /// Method to load info from file to form
        /// </summary>
        private void LoadFileInfo()
        {
            DialogResult result = ofdMKV.ShowDialog();          // Show open file dialog
            if (result == DialogResult.OK)                      // If user selected OK for opening file...
            {
                string exeName = "\"" + MKVToolNix.ExeGetPath(MKVToolNix.mkvmergeExe) + "\"";   // Get path for mkvmerge.exe and wrap in quotes for RunProcess

                dynamic json = Utils.GetJsonObject(Utils.RunProcess(exeName, "-i -F json \"" + ofdMKV.FileName + "\""));    // Get JSON string from mkvmerge file analysis output and turn it into dynamic object
                GetTracks(json);                                // Call GetTracks with the created dynamic object

                lblFile.Text = json["file_name"];                               // Display File Name from JSON Object
                try
                {
                    lblTitle.Text = json["container"]["properties"]["title"];   // Try to display video Title from JSON Object
                }
                catch(KeyNotFoundException)
                {
                    myDebug.WriteLine("This mkv has no Title set, using blank one... ");   
                    lblTitle.Text = "";                                         // Display blank title if not present
                }
            }
        }

        /// <summary>
        /// Method to save the currently selected default track configuration to file(s)
        /// </summary>
        private void SaveNewSettings()
        {
            if (lblFile.Text != "")                             // If the filename label actually has text in it... (meaning something is actually loaded)
            {
                rtxLog.Text = "";                               // Clear the log

                string retStr;                                  // Initialize retStr (used to hold string returned by Utils.RunProcess)
                string fileName = "\"" + lblFile.Text + "\"";   // Initialize file name, wrapping it in quotes for use in final arg for mkvpropedit
                string exeName = "\"" + MKVToolNix.ExeGetPath(MKVToolNix.mkvpropeditExe) + "\"";    // Initialize name for exe for Utils.RunProcess, grabbing path for currently installed mkvpropedit.exe and wrapping in quotes

                StringBuilder args = new StringBuilder();       // Instantiate new StringBuilder to construct final arguments string 
                args.Append(BuildArgs(lbxAudio, false));        // Call BuildArgs for all audio track args and append to StringBuilder
                args.Append(BuildArgs(lbxSubtitle, false));     // Call BuildArgs for all subtitle track args and append to StringBuilder

                if (userIsInsaneToolStripMenuItem.Checked)                              // If the "User Is Insane" batch mode option is on...
                {
                    string directory = Path.GetDirectoryName(lblFile.Text);             // Get directory the current file is in
                    string[] mkvFiles = Directory.GetFiles(directory, "*.mkv");         // build array of all MKV files in directory
                    int filesModified = 0;                                              // Initialize counter to count how maky files were successfully modified

                    for(int i = 0; i < mkvFiles.Length; i++)                            // For each file...
                    {
                        fileName = "\"" + mkvFiles[i] + "\"";                           // Wrap file name in quotes for final arg
                        rtxLog.SendToLog("File No." + (i + 1) + " of " + mkvFiles.Length + ": " + mkvFiles[i]); // Send to log file no. and name
                        rtxLog.SendToLog(exeName + " " + fileName + args.ToString());   // Send to log the complete command sent to mkvpropedit
                        retStr = Utils.RunProcess(exeName, fileName + args.ToString()); // Run mkvpropedit with final generated args
                        rtxLog.SendToLog(retStr);                                       // send returned result from mkvpropedit to log

                        int goodAudioCount = lbxAudio.Items.Count;                      // Initialize count of "good" audio, count of audio tracks found in file (needed for batch mode, may not have all tracks in selected file) 
                        int goodSubCount = lbxSubtitle.Items.Count;                     // Initialize count of "good" subtitle, count of subtitle tracks found in file
                        StringBuilder argsAlt;                                          // Declare another StringBuilder for an alternate final arg (used for batch mode, in case some tracks are not found)

                        filesModified++;                                                // Increment filesModified

                        while (retStr != MKVToolNix.mkvpropedit_ReturnOK)               // While mkvpropedit does not return the "everything completed OK" result
                        {
                            if (retStr.Contains("The file is being analyzed.\r\nError: This file could not be opened or parsed.\r\n"))
                            {
                                rtxLog.SendToLog("ERROR: could not seem to access this file, skipping it...");
                                filesModified--;
                                break;
                            }

                            if (retStr.Contains("Error: No track corresponding to the edit specification 'a"))          // If returned error was an audio track not found...
                                goodAudioCount--;                                       // Means the last audio track was not found, so decrement good audio count
                            else if (retStr.Contains("Error: No track corresponding to the edit specification 's"))     // If returned error was a subtitle track not found...
                                goodSubCount--;                                         // Means the last subtitle track was not found, so decrement good subtitle count
                            
                            if (goodAudioCount < (lbxAudio.SelectedIndex+1) || goodSubCount < (lbxSubtitle.SelectedIndex+1))    // If the selected default tracks are not in the "good" tracks avaible in file...
                            {
                                rtxLog.SendToLog("Default track selection does not exist in this file, skipping file...");      // inform user that their selected tracks are not present
                                filesModified--;                        // decrement filesModified
                                break;                                  // break out of while loop, skipping file
                            }

                            argsAlt = new StringBuilder();              // Instantiate new StringBuilder for alternate args
                            argsAlt.Append(BuildArgs(lbxAudio, false, goodAudioCount));         // Build new audio tracks args based on updated good audio count
                            argsAlt.Append(BuildArgs(lbxSubtitle, false, goodSubCount));        // Build new subtitle track args based on updated good subtitle count

                            rtxLog.SendToLog(exeName + " " + fileName + argsAlt.ToString());    // Send new complete command to log
                            retStr = Utils.RunProcess(exeName, fileName + argsAlt.ToString());  // Try running mkvpropedit with new args
                            rtxLog.SendToLog(retStr);                                           // send result from mkvpropedit to log
                        }
                    }
                    // Finally show message to user when batch operation is done including count of files successfully modified
                    MessageBox.Show(filesModified + " of " + mkvFiles.Length + " files successfully modified!", "Batch save complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {   // Else if the batch mode is off, just do the following
                    rtxLog.SendToLog("File: " + fileName);                          // Send file name to log
                    rtxLog.SendToLog(exeName + " " + fileName + args.ToString());   // Send complete mkvpropedit arg to log
                    retStr = Utils.RunProcess(exeName, fileName + args.ToString()); // Run mkvpropedit with arg
                    rtxLog.SendToLog(retStr);                                       // send returned result to log
                }
            }
        }

        /// <summary>
        /// Method to build the arguments to tell mkvpropedit to edit which tracks, and with what values
        /// </summary>
        /// <param name="listBox">The ListBox containing the tracks to generate arguments for.</param>
        /// <param name="addSetting">Boolean to specify whether the argument edits the existing setting in the track in file, or adds it anew. Used for when the setting does not exist in the track in file.</param>
        /// <param name="trackCount">Optional. Used to specify how many tracks in the ListBox are being processed. Will use the ListBox's Item Count as default.</param>
        /// <returns>String of arguments for editing the tracks in the ListBox</returns>
        private string BuildArgs(ListBox listBox, bool addSetting, int trackCount = 0)
        {
            if (trackCount == 0)                    // If trackCount is defaul sentinel value of zero
                trackCount = listBox.Items.Count;   // change it to the listBox's Item Count

            string arg = "";                        // initialize the string vars, the arg, its track type, and its setting type
            string tType = "";
            string sType = "";

            switch (listBox.Name)
            {
                case "lbxAudio":                    // If the listBox is the audio track one...
                    tType = "a";                    // set arg track type to audio
                    break;

                case "lbxSubtitle":                 // If the listBox is the subtitle track one...
                    tType = "s";                    // set arg track type to subtitle
                    break;
            }

            for (int i = 1; i < trackCount; i++)    // For each of the tracks (up to the specified count)
            {
                bool def = false;                   // Initialize boolean to represent part of argument for track's default flag
                                                    // Default is false
                if (i == listBox.SelectedIndex)     // But if the current track is selected in the listBox...
                    def = true;                     // set the default flag to true;

                if (addSetting)                     // If addSetting is true...
                    sType = "a";                    // Set argument's setting type to "add"
                else
                    sType = "s";                    // Otherwise set argument's setting type to "set"
                
                // Construct final argument for this track and add it to arg string
                arg += " -e track:" + tType + i + " -" + sType + " flag-default=" + Convert.ToInt16(def);
            }
            return arg;                             // Return the completed arg string string
        }

        /// <summary>
        /// Method that intializes the 2 ListBoxes
        /// </summary>
        private void InitListBoxes()
        {
            audioTracks = new List<string>();   // Instantiate new list for audioTracks
            subTracks = new List<string>();     // Instantiate new list for subTracks

            audioTracks.Add("(none)");          // Add the "(none)" item to the audioTracks list
            subTracks.Add("(none)");            // Add the "(none)" item to the subTracks list

            RefreshListBoxes();                 // Call ListBox refreshing method
        }

        /// <summary>
        /// Method to refresh and re-bind the audio and subtitle lists to the respective ListBoxeson screen
        /// </summary>
        private void RefreshListBoxes()
        {
            lbxAudio.DataSource = null;             // Must make datasource for each ListBox null for somereason, not really sure why though
            lbxSubtitle.DataSource = null;
            lbxAudio.DataSource = audioTracks;      // Bind the audioTracks and subTracks lists to the ListBoxes
            lbxSubtitle.DataSource = subTracks;
        }

        /// <summary>
        /// Method to warn the user about the batch file mode modifying entire folder's worth of MKV files
        /// </summary>
        private void UserIsInsaneWarning()
        {
            if (userIsInsaneToolStripMenuItem.Checked)          // If "User Is Insane" batch mode option is already checked...
            {
                userIsInsaneToolStripMenuItem.Checked = false;  // Uncheck it
                lblWarning.Visible = false;                     // Make big warning label invisible
            }
            else
            {                                                   // Otherwise...
                // Warinig string to display in message box to warn user
                string warning = "BATCH MODE!" + Environment.NewLine +
                    "This will Apply these default track settings..." + Environment.NewLine +
                    "...TO ALL .mkv FILES IN THE CURRENT FILE'S DIRECTORY!" + Environment.NewLine +
                    "(If your default-selected Audio or Subtitle track is not present in a file, that file will not be modified.)" + Environment.NewLine +
                    Environment.NewLine +
                    "Are you sure you want to do this?";

                frmWarning _frmWarning = new frmWarning(warning);   // Instantiate a new frmWarning with the above warning message
                if (_frmWarning.ShowDialog() == DialogResult.OK)    // Show the dialog and if the user responds with OK...
                {
                    userIsInsaneToolStripMenuItem.Checked = true;   // Check the "User Is Insane" batch mode option
                    lblWarning.Visible = true;                      // Make the big warning label visible
                }
            }
        }

        /// <summary>
        /// Method to lock or unlock certain form controls, useful to prevent user from trying stuffif certain conditions are not met
        /// </summary>
        /// <param name="unlocked">Boolean value representing wether or notto uunlock certain controls</param>
        private void UnlockFormControls(bool unlocked)
        {
            loadToolStripMenuItem.Enabled = unlocked;   // Enable or disable the following controls depending on the boool passed toit
            saveToolStripMenuItem.Enabled = unlocked;
            otherToolStripMenuItem.Enabled = unlocked;
            btnLoad.Enabled = unlocked;
            btnSave.Enabled = unlocked;
        }

        #endregion methods
    }
}
