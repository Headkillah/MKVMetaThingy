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

        // None here atm

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
            LoadFile();                             // Load track info from file(s)
        }

        private void btnLoadDir_Click(object sender, EventArgs e)
        {
            LoadDir();                              // Load track info from all mkv files in a directory
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveNewSettings();                      // Save the selecetd settings to file(s)
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();                             // Load track info from file(s)
        }

        private void loadDataFromFolderOfMKVFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDir();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveNewSettings();                      // Save the selecetd settings to file(s)
        }

        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();                     // Exit Program
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
        /// Method that Makes a TrackList Object, that contains A List of String Descriptions of the tracks from provided json data, along with the index of the current default track.
        /// </summary>
        /// <param name="json">The json data with information on the tracks in the mkv file.</param>
        /// <param name="trackType">Either MKVToolNix.TRACK_AUDIO or MKVToolNix.TRACK_SUB</param>
        /// <returns>A TTrackList coontaiining a Striing List of the Descriptions of the tracks, along with the index of the default track.</returns>
        private TrackList GetTracks(dynamic json, string trackType)
        {
            int trackCount = 0;         // Initialize counts and selected values
            int defaultTrack = 0;

            TrackList trackList = new TrackList();

            for (int i = 0; i < json["tracks"].Length; i++)             // For each track...
            {
                if ((string)json["tracks"][i]["type"] == trackType)     // If the track type is equal to the supplied track type
                {
                    string trackName;                                   // Declare track name and isDefault vars
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
                        myDebug.WriteLine("Track No." + i + "'s \"Default Track\" flag does not even exist... setting default track flag to false.");
                        trackIsDefault = false;                                         // If it is not even present in object, use default of false
                    }

                    string trackLang = json["tracks"][i]["properties"]["language"].ToUpper();   // Get track language code from dynamic object
                    string listItem = trackLang + " - " + trackName;                            // Construct List Item string in format of "LANG - Track Name"
                    myDebug.WriteLine(trackType.ToUpper() + "\t" + trackLang + "\t" + trackIsDefault + "\t" + trackName);

                    trackCount++;                           // Increment track counter

                    trackList.tracks.Add(listItem);                // Add constructed List Item to tracks list
                    if (trackIsDefault)                     // If this track is the default subtitle track
                        defaultTrack = trackCount;          // Set the defaultSub value to the current subtitle track count
                }
            }
            trackList.defaultTrack = defaultTrack;          // Set the Selected value of the ListBox to match the defaultTrack value
            return trackList;
        }

        /// <summary>
        /// Method to load files using an OpenFileDialog
        /// </summary>
        private void LoadFile()
        {
            DialogResult result = ofdMKV.ShowDialog();      // Show dialog
            if (result == DialogResult.OK)                  // If user clicks OK...
            {
                rtxLog.Clear();                                     // Clear the log
                List<string> goodFileNames = new List<string>();    // make new list for fileNames are are actually .mkv files
                string[] mkvFiles;                                  // declare array for fileNames from list

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
                else if (mkvFiles.Length > 1)                       // Else if there is, and more than one
                    LoadFileInfo(mkvFiles);                             // Load the array into LoadFileInfo
                else
                    LoadFileInfo(mkvFiles[0]);                      // Otherwise just load the one filename
            }
        }

        /// <summary>
        /// Method to load files using a FolderBrowserDialog
        /// </summary>
        private void LoadDir()
        {
            fbdMKVDir.Description = "Please select the folder containing all the .mkv files you want to modify:";
            DialogResult result = fbdMKVDir.ShowDialog();                               // Show dialog
            if (result == DialogResult.OK)                                              // If user clicks OK...
            {
                rtxLog.Clear();                                                             // Clear the log
                string[] mkvFiles = Directory.GetFiles(fbdMKVDir.SelectedPath, "*.mkv");    // Get filenames of .mkv files in directory from dialog

                if (mkvFiles.Length < 1)                                                    // If there are no .mkv files...
                    rtxLog.SendToLog("ERROR!: There are no .mkv files in this folder! (" + fbdMKVDir.SelectedPath + ")");   // Print error to log regarding this and do nothing else
                else if (mkvFiles.Length > 1)                                               // Else if there is, and  more than one
                    LoadFileInfo(mkvFiles);                                                     // Load the array into LoadFileInfo
                else
                    LoadFileInfo(mkvFiles[0]);                                                  // Otherwise just load the one filename
            }
        }

        /// <summary>
        /// Method to load info from file to form
        /// </summary>
        private void LoadFileInfo(string fileName)
        {
            string exeName = "\"" + MKVToolNix.ExeGetPath(MKVToolNix.mkvmergeExe) + "\"";   // Get path for mkvmerge.exe and wrap in quotes for RunProcess

            dynamic mkvData = Utils.GetJsonObject(Utils.RunProcess(exeName, "-i -F json \"" + fileName + "\""));    // Get JSON string from mkvmerge file analysis output and turn it into dynamic object                               
            RefreshListBox(lbxAudio, GetTracks(mkvData, MKVToolNix.TRACK_AUDIO));      // Call GetTracks with the created dynamic object to get audio tracks
            RefreshListBox(lbxSubtitle, GetTracks(mkvData, MKVToolNix.TRACK_SUB));     // Call GetTracks with the created dynamic object to get sub tracks

            try
            {
                lblTitle.Text = mkvData["container"]["properties"]["title"];   // Try to display video Title from JSON Object
            }
            catch(KeyNotFoundException)
            {
                myDebug.WriteLine("This mkv has no Title set, using blank one... ");   
                lblTitle.Text = "";                                         // Display blank title if not present
            }
            txtFile.Text = fileName;                                        // Put file name in file name textbox
        }

        /// <summary>
        /// Method to load data from selected files
        /// </summary>
        /// <param name="mkvFiles">Array of selected files' paths</param>
        private void LoadFileInfo(string[] mkvFiles)
        {
            string exeName = "\"" + MKVToolNix.ExeGetPath(MKVToolNix.mkvmergeExe) + "\"";   // Get path for mkvmerge.exe and wrap in quotes for RunProcess
            dynamic json = null;

            int maxAudioIndex = 0;                              // Initialize index of file holding the most audio tracks
            int maxAudioValue = 0;                              // Initialize value of how many audio tracks are in the above described file 
            int maxSubIndex = 0;                                // Initialize index of file holding the most subtitle tracks
            int maxSubValue = 0;                                // Initialize value of how many subtitle tracks are in the above described file 

            txtFile.Clear();                                    // Clear the file name TextBox

            for (int i = 0; i < mkvFiles.Length; i++)           // For each file in the directory...
            {
                // Set the dynamic json object to...
                // ...the output derived from the JSON string...
                // ...which is taken from the output from mkvmerge.exe
                json = Utils.GetJsonObject(Utils.RunProcess(exeName, "-i -F json \"" + mkvFiles[i] + "\""));

                int audioCount = 0;                             // Initialize audio track counter
                int subCount = 0;                               // Initialize subtitle track counter

                for (int j = 0; j < json["tracks"].Length; j++)         // For each track in the file...
                {
                    switch ((string)json["tracks"][j]["type"])          // Check the track type
                    {
                        case MKVToolNix.TRACK_AUDIO:                    // If it is an audio track
                            audioCount++;                               // Increment audio track counter
                            break;                                      // Break out of switch statement

                        case MKVToolNix.TRACK_SUB:                      // If it is a subtitle track
                            subCount++;                                 // Increment subtitle track counter
                            break;                                      // Break out of switch statement
                    }
                }

                if (maxAudioValue < audioCount)                 // If the amount of audio tracks in this file is greater than current maximum found...
                {
                    maxAudioValue = audioCount;                 // set new maximum to amount found in this file
                    maxAudioIndex = i;                          // Set the index holding max audio tracks to current file's index
                }

                if (maxSubValue < subCount)                     // If the amount of subtitle tracks in this file is greater than current maximum found...
                {
                    maxSubValue = subCount;                     // set new maximum to amount found in this file
                    maxSubIndex = i;                            // Set the index holding max subtitle tracks to current file's index
                }

                myDebug.WriteLine(Path.GetFileName(mkvFiles[i]) + ":\thas " + audioCount + " audio, and " + subCount + " subs.");

                txtFile.AppendText(mkvFiles[i]);                // Add current file's path to file name TextBox
                if (i < (mkvFiles.Length - 1))                  // If the file is not the last one...
                    txtFile.AppendText(Environment.NewLine);    // Also add a new line for nextfile name
            }

            
            
            // Get dynamic object from JSON string from mkvmerge.exe for file in folder with max amount of audio tracks
            json = Utils.GetJsonObject(Utils.RunProcess(exeName, "-i -F json \"" + mkvFiles[maxAudioIndex] + "\""));

            RefreshListBox(lbxAudio, GetTracks(json, MKVToolNix.TRACK_AUDIO));      // Call GetTracks with the created dynamic object to get audio tracks

            if (maxAudioIndex != maxSubIndex)   // If the "max audio tracks" file and the "max subtitle tracks" file are not the same...
                // Get dynamic object from JSON string from mkvmerge.exe for file in folder with max amount of subtitle tracks
                json = Utils.GetJsonObject(Utils.RunProcess(exeName, "-i -F json \"" + mkvFiles[maxSubIndex] + "\""));

            RefreshListBox(lbxSubtitle, GetTracks(json, MKVToolNix.TRACK_SUB));     // Call GetTracks with the created dynamic object to get sub tracks

            lblTitle.Text = "(Multiple files are loaded)";         // Change title label to inform that there are multiple files loadad
        }


        /// <summary>
        /// Method to save the currently selected default track configuration to file(s)
        /// </summary>
        private void SaveNewSettings()
        {
            if (txtFile.Text != "")                             // If the filename label actually has text in it... (meaning something is actually loaded)
            {
                rtxLog.Text = "";                               // Clear the log

                string retStr;                                  // Initialize retStr (used to hold string returned by Utils.RunProcess)
                //string fileName = "\"" + lblFile.Text + "\"";   // Initialize file name, wrapping it in quotes for use in final arg for mkvpropedit
                string[] mkvFiles = txtFile.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);  // Build array of filenames from file name TextBox
                string exeName = "\"" + MKVToolNix.ExeGetPath(MKVToolNix.mkvpropeditExe) + "\"";    // Initialize name for exe for Utils.RunProcess, grabbing path for currently installed mkvpropedit.exe and wrapping in quotes

                StringBuilder args = new StringBuilder();       // Instantiate new StringBuilder to construct final arguments string 
                args.Append(BuildArgs(lbxAudio, false));        // Call BuildArgs for all audio track args and append to StringBuilder
                args.Append(BuildArgs(lbxSubtitle, false));     // Call BuildArgs for all subtitle track args and append to StringBuilder

                if (mkvFiles.Length > 1)                              // If the "User Is Insane" batch mode option is on...
                {
                    int filesModified = 0;                                              // Initialize counter to count how maky files were successfully modified

                    for(int i = 0; i < mkvFiles.Length; i++)                            // For each file...
                    {
                        string fileName = "\"" + mkvFiles[i] + "\"";                           // Wrap file name in quotes for final arg
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
                    string fileName = mkvFiles[0];                                          // If there is only one file, just get filename from array
                    string wrappedFileName = "\"" + fileName + "\"";                        // Wrap filename in quotes for RunProcess arg
                    rtxLog.SendToLog("File: " + wrappedFileName);                           // Send file name to log
                    rtxLog.SendToLog(exeName + " " + wrappedFileName + args.ToString());    // Send complete mkvpropedit arg to log
                    retStr = Utils.RunProcess(exeName, wrappedFileName + args.ToString());  // Run mkvpropedit with arg
                    rtxLog.SendToLog(retStr);                                               // send returned result to log
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
        /// Method to refresh and re-bind a List of Strings to a corresponding ListBox control on the form, and auto-select the default track.
        /// </summary>
        /// <param name="listBox">The ListBox to bind the String List Data to.</param>
        /// <param name="trackList">The TrackList containing the human readable track descriptions for that ListBox, along with the index of the default track.</param>
        private void RefreshListBox(ListBox listBox, TrackList trackList)
        {
            listBox.DataSource = null;
            listBox.DataSource = trackList.tracks;
            listBox.SelectedIndex = trackList.defaultTrack;
        }

        /// <summary>
        /// Method to lock or unlock certain form controls, useful to prevent user from trying stuffif certain conditions are not met
        /// </summary>
        /// <param name="unlocked">Boolean value representing wether or notto uunlock certain controls</param>
        private void UnlockFormControls(bool unlocked)
        {
            loadToolStripMenuItem.Enabled = unlocked;   // Enable or disable the following controls depending on the boool passed toit
            saveToolStripMenuItem.Enabled = unlocked;
            btnLoadDir.Enabled = unlocked;
            btnLoad.Enabled = unlocked;
            btnSave.Enabled = unlocked;
        }

        #endregion methods
    }
}
