using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKVMetaThingyUtils
{
    public class MKVToolNix
    {
        /// <summary>
        /// Name of mkvmerge executable
        /// </summary>
        public const string mkvmergeExe = "mkvmerge.exe";

        /// <summary>
        /// name of mkvpropedit executable
        /// </summary>
        public const string mkvpropeditExe = "mkvpropedit.exe";

        /// <summary>
        /// MKVToolNix Homepage url
        /// </summary>
        public const string urlHome = "https://mkvtoolnix.download/";

        /// <summary>
        /// MKVToolNix Download page URL
        /// </summary>
        public const string urlDownload = "http://www.fosshub.com/MKVToolNix.html";

        /// <summary>
        /// The default out returned from mkvpropedit when everything is completed ok
        /// </summary>
        public const string mkvpropedit_ReturnOK = "The file is being analyzed.\r\nThe changes are written to the file.\r\nDone.\r\n";

        /// <summary>
        /// String representing the Audio track type
        /// </summary>
        public const string TRACK_AUDIO = "audio";

        /// <summary>
        /// String representing the Subtitle track type
        /// </summary>
        public const string TRACK_SUB = "subtitles";

        /// <summary>
        /// Method to get the paths of certain MKVToolNix Executables
        /// </summary>
        /// <param name="exeName">The specific MKVToolNix-related executable to look for</param>
        /// <returns>Full path of the executable</returns>
        public static string ExeGetPath(string exeName)
        {
            // Array of paths to look in, default paths are "C:\Program Files\MKVToolNix\", "C:\Program Files (x86)\MKVToolNix\", and current directory
            string[] paths = { @"C:\Program Files\MKVToolNix\" + exeName, @"C:\Program Files (x86)\MKVToolNix\" + exeName, exeName };

            for (int i = 0; i < paths.Length; i++)      // For each potential path
                if (File.Exists(paths[i]))              // If the exe exists in that path
                    return paths[i];                    // Return the full path for the found exe
            
            return null;                                // If not found just return null string
        }

        /// <summary>
        /// Method to check if MKVToolNix is installed or not
        /// </summary>
        /// <returns>bool representing: true if MKVToolNix is installed, false if it is not.</returns>
        public static bool IsInstalled()
        {
            bool isInstalled = true;    // default assign to true

            if (ExeGetPath(mkvmergeExe) == null || ExeGetPath(mkvpropeditExe) == null)
                isInstalled = false;    // change to false if mkvmerge or mkvpropedit could not be found

            return isInstalled;         // return the result
        }

        /// <summary>
        /// Method that notifies the user regarding whether or not MKVToolNix was found or not
        /// </summary>
        /// <param name="found">bool representing whether or not MKVToolNix was found</param>
        public static void FoundNotify(bool found)
        {
            if  (!found)
            {
                // Show messagebox informing user of the issue, asking if they want to download MKVToolNix
                DialogResult result = MessageBox.Show("MKVToolNix does not seem to be installed on this machine, but it is needed for this program to function." + Environment.NewLine +
                                    "Would you like to go to MKVToolNix's download page?",
                                    "MKVToolNix not found!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (result == DialogResult.OK)      // Means they said OK to downloading MKVToolNix
                    Utils.OpenURL(urlDownload);     // Open the MKVToolNix download page in user's default browser
            }
            else
            {
                // Show message box informing the user that MKVToolNix was found already installed
                MessageBox.Show("Looks like MKVToolnix is installed on this machine, so you should be good to go!", "MKVToolNix was found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
        }
    }
}
