using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MKVMetaThingyUtils;
using System.IO;

namespace MKVTrackNamerThingy
{
    public partial class frmMain : Form
    {
        #region globals

        TextBox[] audioTextBoxes;
        TextBox[] subTextBoxes;
        Label[] audioLabels;
        Label[] subLabels;
        string[,] audioMeta;
        string[,] subMeta;

        #endregion globals

        #region init

        public frmMain()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);     // Set form icon to one in program's exe
        }

        #endregion init

        #region events

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblAppInfo.Text = Application.ProductName + " ver" + Application.ProductVersion + lblAppInfo.Text;

            if (!MKVToolNix.IsInstalled())          // If MKVToolNix is not installed
            {
                UnlockFormControls(false);          // Lock certain form controls
                MKVToolNix.FoundNotify(false);      // Inform user of the issue
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
            SaveTrackNames();
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
            SaveTrackNames();
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
            bool installed = MKVToolNix.IsInstalled();          // Checkif MKVToolNix is installed

            UnlockFormControls(installed);                      // Lock/Unlock form controls based on result
            MKVToolNix.FoundNotify(installed);                  // Display message based on result
        }

        #endregion events

        #region methods

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
        /// Methodto load data from selected files
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

                txtFile.AppendText(mkvFiles[i]);                // Add current file's pathto file name TextBox
                if (i < (mkvFiles.Length - 1))                  // If the file is not the last one...
                    txtFile.AppendText(Environment.NewLine);    // Also add a new line for nextfile name
            }
            // Get dynamic object from JSON string from mkvmerge.exe for file in folder with max amount of audio tracks
            json = Utils.GetJsonObject(Utils.RunProcess(exeName, "-i -F json \"" + mkvFiles[maxAudioIndex] + "\""));

            audioMeta = InitMetaArray(json, MKVToolNix.TRACK_AUDIO, 3);                             // Initialize audio meta array
            InitTrackArrays(json, MKVToolNix.TRACK_AUDIO, out audioLabels, out audioTextBoxes);     // Initialize Label and TextBox arrays for the audio tracks
            InitPanel(pnlAudio, audioLabels.Length, audioLabels, audioTextBoxes);                   // Initialize the Panel for all the audio track controls
            GetTracks(json, MKVToolNix.TRACK_AUDIO);                                                // Get the audio track info

            if (maxAudioIndex != maxSubIndex)   // If the "max audio tracks" file and the "max subtitle tracks" file are not the same...
                // Get dynamic object from JSON string from mkvmerge.exe for file in folder with max amount of subtitle tracks
                json = Utils.GetJsonObject(Utils.RunProcess(exeName, "-i -F json \"" + mkvFiles[maxSubIndex] + "\""));

            subMeta = InitMetaArray(json, MKVToolNix.TRACK_SUB, 2);                                 // Initialize subtitle meta array
            InitTrackArrays(json, MKVToolNix.TRACK_SUB, out subLabels, out subTextBoxes);           // Initialize Label and TextBox arrays for the subtitle tracks
            InitPanel(pnlSubtitle, subLabels.Length, subLabels, subTextBoxes);                      // Initialize the Panel for all the subtitle track controls
            GetTracks(json, MKVToolNix.TRACK_SUB);                                                  // Get the subtitle track info

            myDebug.WriteLine(Path.GetFileName(mkvFiles[maxAudioIndex]) + " has the most Audio tracks.");
            myDebug.WriteLine(Path.GetFileName(mkvFiles[maxSubIndex]) + " has the most Subtitle tracks.");

            lblTitle.Text = "(Multiple files are loaded)";         // Change title label to inform that there are multiple files loadad
        }

        /// <summary>
        /// Overload for LoadFileInfo that takes just one filename instead of many
        /// </summary>
        /// <param name="fileName">The file path to load data from</param>
        private void LoadFileInfo(string fileName)
        {
            string exeName = "\"" + MKVToolNix.ExeGetPath(MKVToolNix.mkvmergeExe) + "\"";           // Get path for mkvmerge.exe and wrap in quotes for RunProcess

            // Get dynamic object from JSON string from mkvmerge.exe
            dynamic json = Utils.GetJsonObject(Utils.RunProcess(exeName, "-i -F json \"" + fileName + "\""));

            audioMeta = InitMetaArray(json, MKVToolNix.TRACK_AUDIO, 3);                             // Initialize Meta Arrays
            subMeta = InitMetaArray(json, MKVToolNix.TRACK_SUB, 2);
            InitTrackArrays(json, MKVToolNix.TRACK_AUDIO, out audioLabels, out audioTextBoxes);     // Initialize label and TextBox Arrays
            InitTrackArrays(json, MKVToolNix.TRACK_SUB, out subLabels, out subTextBoxes);
            InitPanel(pnlAudio, audioLabels.Length, audioLabels, audioTextBoxes);                   // Initialize Panels
            InitPanel(pnlSubtitle, subLabels.Length, subLabels, subTextBoxes);
            GetTracks(json, MKVToolNix.TRACK_AUDIO);                                                // Get info for audio and subtitle tracks from dynamic object
            GetTracks(json, MKVToolNix.TRACK_SUB);

            try
            {
                lblTitle.Text = json["container"]["properties"]["title"];   // Try to display video Title from JSON Object
            }
            catch (KeyNotFoundException)
            {
                myDebug.WriteLine("This mkv has no Title set, using blank one... ");
                lblTitle.Text = "";                                         // Display blank title if not present
            }
            txtFile.Text = fileName;                                        // Put file name in file name textbox
        }

        /// <summary>
        /// Method to save the track names from form to the MKV file(s)
        /// </summary>
        private void SaveTrackNames()
        {
            if (txtFile.Text != "")             // If the file name TextBox actually has something in it...
            {
                rtxLog.Text = "";                   // Clear the log

                int filesModified = 0;              // Initialize a counter to count the amount of files successfully modified
                string retStr;                      // Declare string for RunProcess output
                string[] mkvFiles = txtFile.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);  // Build array of filenames from file name TextBox
                string exeName = "\"" + MKVToolNix.ExeGetPath(MKVToolNix.mkvpropeditExe) + "\"";    // Get path for mkvpropedit.exe and wrap in quotes for use as RunProcess arg
                
                StringBuilder args = new StringBuilder();           // Make new StringBuilder for arguments
                args.Append(BuildArgs(audioTextBoxes, false));      // Add arguments for audio tracks
                args.Append(BuildArgs(subTextBoxes, false));        // Add arguments for subtitle tracks

                if (mkvFiles.Length > 1)                            // If there is more than one file to modify...
                {
                    for (int i = 0; i < mkvFiles.Length; i++)           // For each file...
                    {
                        myDebug.WriteLine(mkvFiles[i]);
                        string fileName = "\"" + mkvFiles[i] + "\"";    // Wrap file name in quotes for use in args

                        rtxLog.SendToLog("File No." + (i + 1) + " of " + mkvFiles.Length + ": " + mkvFiles[i]); // Send to log file no. and name
                        rtxLog.SendToLog(exeName + " " + fileName + args.ToString());   // Send to log the complete command sent to mkvpropedit
                        retStr = Utils.RunProcess(exeName, fileName + args.ToString()); // Run mkvpropedit with final generated args
                        rtxLog.SendToLog(retStr);                       // send returned result from mkvpropedit to log

                        int goodAudioCount = audioTextBoxes.Length;     // Initialize count of "good" audio, count of audio tracks found in file (needed for batch mode, may not have all tracks in selected file) 
                        int goodSubCount = subTextBoxes.Length;         // Initialize count of "good" subtitle, count of subtitle tracks found in file
                        StringBuilder argsAlt;                          // Declare another StringBuilder for an alternate final arg (used for batch mode, in case some tracks are not found)

                        filesModified++;                                // Increment filesModified

                        while (retStr != MKVToolNix.mkvpropedit_ReturnOK)                                                               // While mkvpropedit does not return the "everything completed OK" result
                        {
                            if (retStr.Contains("The file is being analyzed.\r\nError: This file could not be opened or parsed.\r\n"))  //If file couldnot be accessed...
                            {
                                rtxLog.SendToLog("ERROR: could not seem to access this file, skipping it...");  // Inform user if the issue
                                filesModified--;    // decrement filesModified
                                break;              // Break out of while loop, skipping file.
                            }

                            if (retStr.Contains("Error: No track corresponding to the edit specification 'a"))          // If returned error was an audio track not found...
                                goodAudioCount--;                                       // Means the last audio track was not found, so decrement good audio count
                            else if (retStr.Contains("Error: No track corresponding to the edit specification 's"))     // If returned error was a subtitle track not found...
                                goodSubCount--;                                         // Means the last subtitle track was not found, so decrement good subtitle count

                            argsAlt = new StringBuilder();                                          // Instantiate new StringBuilder for alternate args
                            argsAlt.Append(BuildArgs(audioTextBoxes, false, goodAudioCount));       // Build new audio tracks args based on updated good audio count
                            argsAlt.Append(BuildArgs(subTextBoxes, false, goodSubCount));           // Build new subtitle track args based on updated good subtitle count

                            rtxLog.SendToLog(exeName + " " + fileName + argsAlt.ToString());        // Send new complete command to log
                            retStr = Utils.RunProcess(exeName, fileName + argsAlt.ToString());      // Try running mkvpropedit with new args
                            rtxLog.SendToLog(retStr);                                               // send result from mkvpropedit to log
                        }
                    }
                    // Finally show message to user when batch operation is done including count of files successfully modified
                    MessageBox.Show(filesModified + " of " + mkvFiles.Length + " files successfully modified!" + Environment.NewLine +
                    Environment.NewLine +
                    "Check the log for more details.", "Batch save complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadFileInfo(mkvFiles);             // Reload the files after modification
                }
                else
                {
                    string fileName = mkvFiles[0];                                          // If there is only one file, just get filename from array
                    string wrappedFileName = "\"" + fileName + "\"";                        // Wrap filename in quotes for RunProcess arg
                    rtxLog.SendToLog("File: " + wrappedFileName);                           // Send to log file name
                    rtxLog.SendToLog(exeName + " " + wrappedFileName + args.ToString());    // Send to log the complete command sent to mkvpropedit
                    retStr = Utils.RunProcess(exeName, wrappedFileName + args.ToString());  // Run mkvpropedit with final generated args
                    rtxLog.SendToLog(retStr);                                               // send returned result from mkvpropedit to log
                    LoadFileInfo(fileName);                                                 // Reload file after modification
                }
            }
        }

        /// <summary>
        /// Method to get track information from dynamic object and add it to form controls
        /// </summary>
        /// <param name="json">the dynamic json object obtained from GetJsonObject()</param>
        private void GetTracks(dynamic json, string trackType)
        {
            int count = 0;                                                      // Initialize count
            int trackCount = json["tracks"].Length;                             // Get amount of tracks

            for (int i = 0; i < trackCount; i++)                                // For each track...
            {
                if ((string)json["tracks"][i]["type"] == trackType)                 // If the current track is the specified type...
                {
                    string trackName;                                               // Declare trackName var
                    string trackLang = json["tracks"][i]["properties"]["language"].ToUpper();   // Get track language from dynamic object
                    string trackCodec = (string)json["tracks"][i]["codec"];         //Get track Codec from dynamic object
                    if (trackCodec == "AC-3/E-AC-3")
                        trackCodec = "DD";

                    try
                    {
                        trackName = json["tracks"][i]["properties"]["track_name"];  // Try to get track name from dynamic object
                    }
                    catch (KeyNotFoundException)
                    {
                        myDebug.WriteLine("Track No." + i + " has no name... using blank name instead.");
                        trackName = "";                                             // If that fails, means that it doesn't exist, so use blank name instead
                    }

                    switch (trackType)
                    {
                        case MKVToolNix.TRACK_AUDIO:                    // If track is an audio track...
                            int channels = (int)json["tracks"][i]["properties"]["audio_channels"];  // Get the amount if audio channels from dynamic object
                            string audioChan = "";                      // Init string representing audio channel type

                            switch (channels)                           // assign description to audioChan depending on the amount of channels in audio
                            {
                                case 2:
                                    audioChan = "Stereo";
                                    break;

                                case 6:
                                    audioChan = "Surround 5.1";
                                    break;

                                case 8:
                                    audioChan = "Surround 7.1";
                                    break;

                                default:
                                    audioChan = channels + "-Channel";
                                    break;
                            }

                            audioMeta[count, 0] = trackLang;            // Add track language code to audioMeta array
                            audioMeta[count, 1] = trackCodec;           // Add track codec to audioMeta array
                            audioMeta[count, 2] = audioChan;            // Add channels description to audioMeta array

                            myDebug.WriteLine(audioMeta[count, 0] + " - " + audioMeta[count, 1] + " - " + audioMeta[count, 2]);
                            audioLabels[count].Text = audioMeta[count, 0] + " - " + audioMeta[count, 1] + " - " + audioMeta[count, 2];  // Set label text for track to string made from the track's Metadata
                            audioTextBoxes[count].Text = trackName;     // Put the track's name in the track's TextBox

                            count++;                                    // Increment count
                            break;

                        case MKVToolNix.TRACK_SUB:                      // If track is a subtitle track...
                            subMeta[count, 0] = trackLang;              // Add track language code to subMeta array
                            subMeta[count, 1] = trackCodec;             // Add track codec to subMeta array
                            myDebug.WriteLine(subMeta[count, 0] + " - " + subMeta[count, 1]);
                            subLabels[count].Text = subMeta[count, 0] + " - " + subMeta[count, 1];  // Set label text for track to string made from the track's Metadata
                            subTextBoxes[count].Text = trackName;       // Put the track's name in the track's TextBox

                            count++;                                    // Increment count
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Method to initialize a panel with its various controls
        /// </summary>
        /// <param name="pnl">The Panel to initialize</param>
        /// <param name="trackCount">The amount of tracks going into the Panel</param>
        /// <param name="labelArray">The array for the Labels going in this Panel</param>
        /// <param name="textBoxArray">The array for the TextBoxes going in this Panel</param>
        private void InitPanel(Panel pnl, int trackCount, Label[] labelArray, TextBox[] textBoxArray)
        {
            int left = 0;                                       // Initialize vars to define some distances
            int labelTop = 0;
            int textBoxTop = labelTop + 25;
            int controlGap = textBoxTop + 40;

            if (pnl.Controls.Count > 0)                         // If there are already controls in this Panel
            {
                pnl.Controls.Clear();                           // Clear controls from Panel
                for (int i = pnl.Controls.Count - 1; i >= 0; i--)   // For each of the Panel's Controls... (Need reverse for loop for Control.Dispose())
                    pnl.Controls[i].Dispose();                  // Dispose of it to remove it from memory
            }

            for (int i = 0; i < trackCount; i++)                        // For each of the tracks...
            {
                Label trackNo = new Label();                            // Make new Label for Track No.
                trackNo.Left = left;                                    // Set X coordinate location in panel for this Label
                trackNo.Top = labelTop + (controlGap * i);              // Set Y coordinate location in panel for this Label
                trackNo.Text = "Track No." + (i + 1) + ":";             // Add respective text to Label
                trackNo.Width = 75;                                     // Set width for Label
                pnl.Controls.Add(trackNo);                              // Add the control to the Panel

                labelArray[i] = new Label();                            // Make new Label for current index in LabelArray
                labelArray[i].Left = left + trackNo.Width + 10;         // Set X coordinate location in panel for this Label
                labelArray[i].Top = labelTop + (controlGap * i);        // Set Y coordinate location in panel for this Label
                labelArray[i].Width = 220;                              // Set width for Label
                pnl.Controls.Add(labelArray[i]);                        // Add the control to the Panel

                textBoxArray[i] = new TextBox();                        // Make new TextBox for current index in TextBoxArray
                textBoxArray[i].Left = left;                            // Set X coordinate location in panel for this TextBox
                textBoxArray[i].Top = textBoxTop + (controlGap * i);    // Set Y coordinate location in panel for this TextBox
                textBoxArray[i].Width = 300;                            // Set  width for TextBox
                pnl.Controls.Add(textBoxArray[i]);                      // Add the control to the Panel
            }
        }

        /// <summary>
        /// Method to initialize a 2D arrayfor holding metadata for each track
        /// </summary>
        /// <param name="json">dynamic object holding data about the mkv file</param>
        /// <param name="type">"audio" fo audio, "subtitles" for subtitles</param>
        /// <returns>A 2D array ready to be populated with metadata for the tracks</returns>
        private string[,] InitMetaArray(dynamic json, string trackType, int arrayFields)
        {
            int count = 0;                                              // Initialize a count
            string[,] meta;                                             // Declare the 2D array

            for (int i = 0; i < json["tracks"].Length; i++)             // For each track...
                if ((string)json["tracks"][i]["type"] == trackType)         // If the current track is the specified tyoe...
                    count++;                                                // Increment the count

            meta = new string[count, arrayFields];                      // Instantiate new 2D array with supplied sizes
            return meta;                                                // return the created array
        }

        /// <summary>
        /// Method to initializethe TextBox and Label arrays for each track type
        /// </summary>
        /// <param name="json">dynamic object holding data about the mkv file</param>
        /// <param name="trackType">A string identifying what track type to use</param>
        /// <param name="labels">The Label Array to init</param>
        /// <param name="textBoxes">The TextBox Array to init</param>
        private void InitTrackArrays(dynamic json, string trackType, out Label[] labels, out TextBox[] textBoxes)
        {
            int count = 0;                                              // Initialize a count
            for (int i = 0; i < json["tracks"].Length; i++)                 // For each of the tracks...
                if ((string)json["tracks"][i]["type"] == trackType)         // If the current track is the specified tyoe...
                    count++;                                                // Increment the count

            labels = new Label[count];                                  // Create new Label array with count as its size
            textBoxes = new TextBox[count];                             // Create new TextBox array with count as its size
        }

        /// <summary>
        /// Method to build the arguments to tell mkvpropedit to edit which tracks, and with what values
        /// </summary>
        /// <param name="textBoxArray">The array of TextBoxes to hold names for the tracks (either audio or subtitle)</param>
        /// <param name="addSetting">Boolean to specify whether the argument edits the existing setting in the track in file, or adds it anew. Used for when the setting does not exist in the track in file.</param>
        /// <param name="trackCount">Optional. Used to specify how many tracks in the Array are being processed. Will use the TextBox Array's Item Count as default.</param>
        /// <returns>String of arguments for editing the tracks in the ListBox</returns>
        private string BuildArgs(TextBox[] textBoxArray, bool addSetting, int trackCount = 0)
        {
            if (trackCount == 0)                                    // If trackCount is defaul sentinel value of zero
                trackCount = textBoxArray.Length;                   // Set trackCount to amount if TextBoxes

            string arg = "";                                        // initialize the string vars, the arg, its track type, and its setting type
            string tType = "";                                      
            string sType = "";
            
            if (textBoxArray.Equals(audioTextBoxes))                // If the TextBox array is the audioTextBoxes...
                tType = "a";                                        // set arg track type to audio
            else if (textBoxArray.Equals(subTextBoxes))             // Else If the TextBox array is the audioTextBoxes...
                tType = "s";                                        // set arg track type to subtitle

            for (int i = 0; i < trackCount; i++)                        // For each of the tracks (up to the specified count)...
            {
                if (addSetting)                                         // If addSetting is true...
                    sType = "a";                                        // Set argument's setting type to "add"
                else
                    sType = "s";                                        // Otherwise set argument's setting type to "set"

                StringBuilder name = new StringBuilder();               // Instantiate new StringBuilder to construct track name
                switch(tType)
                {
                    case "a":                                           // If it is an audio track...
                        if (chkAudioPrepLang.Checked)                   // If Audio Prepend Lang code is checked...
                            name.Append(audioMeta[i, 0] + " ");         // Get Lang code from audio meta array and add to name

                        if (chkAudioPrepCodec.Checked)                  // If Audio Prepend Codec is checked...
                            name.Append(audioMeta[i, 1] + " ");         // Get Codec from audio meta array and add to name

                        if (chkAudioPrepChan.Checked)                   // Get Audio Prepend Channels is checked...
                            name.Append(audioMeta[i, 2] + " ");         // Get Channels from audio meta array and add to name
                        break;

                    case "s":                                           // If it is a subtitle track...
                        if (chkSubPrepLang.Checked)                     // If Subtitle Prepend Lang code is checked...
                            name.Append(subMeta[i, 0] + " ");           // Get Lang code from subtitle meta array and add to name

                        if (chkSubPrepCodec.Checked)                    // If Subtitle Prepend Codec is checked...
                            name.Append(subMeta[i, 1] + " ");           // Get Codec from subtitle meta array and add to name
                        break;
                }

                if (textBoxArray[i].Text == "")                         // If Name TextBox for this track is empty...
                    name.Remove(name.Length-1, 1);                      // remove the last trailing space from name
                else
                    name.Append(textBoxArray[i].Text);                  // Otherwise dd contents of TextBox to name

                myDebug.WriteLine(name.ToString());

                // append constructed argument for this track to arg
                arg += " -e track:" + tType + (i + 1) + " -" + sType + " \"name=" + name.ToString() + "\"";
            }
            return arg;                                             // return the completed arg
        }

        /// <summary>
        /// Method to unlock certain form controls based onbool value passed to it
        /// </summary>
        /// <param name="unlocked">Boolean representing whether to lock or unlock certain controls</param>
        private void UnlockFormControls(bool unlocked)
        {
            loadDataFromMKVToolStripMenuItem.Enabled = unlocked;                    // Lock/Unlock these controls based on passed unlocked value
            loadDataFromDirectoryOfMKVFilesToolStripMenuItem.Enabled = unlocked;
            saveDataToMKVToolStripMenuItem.Enabled = unlocked;
            btnLoad.Enabled = unlocked;
            btnLoadDir.Enabled = unlocked;
            btnSave.Enabled = unlocked;
        }

        #endregion methods
    }
}
