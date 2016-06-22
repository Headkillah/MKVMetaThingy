using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MKVMetaThingyUtils
{
    public static class Utils
    {
        // taken from http://www.dotnetperls.com/redirectstandardoutput
        /// <summary>
        /// Method to run a command line process with arguments, redirecting stdout and returning it as a string
        /// </summary>
        /// <param name="exeName">Name of the Executable program</param>
        /// <param name="args">Command line paguments to pass to the program</param>
        /// <returns>stdout from program</returns>
        public static string RunProcess(string exeName, string args)
        {
            myDebug.WriteLine(exeName + " " + args);
            ProcessStartInfo start = new ProcessStartInfo();            // Instantiate new ProcessStartInfo for process
            start.FileName = exeName;                                   // process file name
            start.Arguments = args;                                     // process arguments
            start.UseShellExecute = false;                              // don't use OS shell to run process
            start.RedirectStandardOutput = true;                        // redirect the stdout from process back to program
            start.CreateNoWindow = true;                                // don't create a visible window for process

            using (Process process = Process.Start(start))              // Start the process
            {
                using (StreamReader reader = process.StandardOutput)    // Create reader to read process output
                {
                    string result = reader.ReadToEnd();                 // read all output
                    return result;                                      // return output
                }
            }
        }

        /// <summary>
        /// Simple method to Open a URL in the user's default browser program
        /// </summary>
        /// <param name="url">The full URL to load</param>
        public static void OpenURL(string url)
        {
            Process.Start(url);                                             // Load URL as per OS and User's default settings
        }

        /// <summary>
        /// Method that gets a JSON text as string and turns it into a dynamic object
        /// </summary>
        /// <param name="jsonString">The actual JSON formatted text</param>
        /// <returns>dynamic object with data from JSON</returns>
        public static dynamic GetJsonObject(string jsonString)
        {
            // myDebug.WriteLine(jsonString);
            JavaScriptSerializer serializer = new JavaScriptSerializer();   // Instantiate new JavaScriptSerializer
            dynamic json = serializer.Deserialize<object>(jsonString);      // Deserialize the JSON string to dynamic object

            return json;                                                    // return the dynamic object
        }

        // http://stackoverflow.com/questions/1896973/is-path-a-directory
        public static bool IsDirectory(this string path)
        {
            bool isDirectory = false;
            FileAttributes fa = File.GetAttributes(path);
            if ((fa & FileAttributes.Directory) == FileAttributes.Directory)
                isDirectory = true;

            return isDirectory;
        }

        /// <summary>
        /// Method to send text to the rtxLog RichTextBox on form
        /// </summary>
        /// <param name="text">Text to send to log</param>
        /// <param name="membername"></param>
        public static void SendToLog(this RichTextBox rtxLog, string text, [System.Runtime.CompilerServices.CallerMemberName] string membername = "")
        {
            rtxLog.AppendText(text + Environment.NewLine);        // Append line of text to contents of rtxLog RichTextBox
            myDebug.WriteLine(text, membername);
        }

        /// <summary>
        /// Simple method to calculatethe value of a number to the power of another
        /// </summary>
        /// <param name="baseNum">The base number supplied</param>
        /// <param name="power">The power by which to raise the base number</param>
        /// <returns>The value of the number raised to the power of the specified power value</returns>
        public static int PowerOf(this int baseNum, int power)
        {
            int num = baseNum;                  // Init num as a copy of baseNum (num will change, baseNum will not)
            for (int i = 1; i < power; i++)     // for each order of magnitude...
                num = num * baseNum;            // num equals baseNum multiplied by num

            return num;                         // return num as final value
        }
    }
}
