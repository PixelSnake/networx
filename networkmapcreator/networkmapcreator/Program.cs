using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace NetworkMapCreator
{
    static class Program
    {
        public static bool DeveloperMode { get; private set; }
        public static Config Config;

        public static string VERSION = "0.6.170322_2";
        public static string APPDATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PixelSnake\NetworX\";

        public static GridMode GridMode = GridMode.None;
        public static PlacementMode PlacementMode = PlacementMode.None;

        private static Form1 MainForm;

        [STAThread]
        static void Main(string[] args)
        {
            ProcessCommandLineArguments(args);

            #region MAC Locking. This protects a developer build from being used by unauthorized users.
#if DEBUG
            Utilities.ApplicationLocking.AddMACLock("0A0027000003");

            if (!Utilities.ApplicationLocking.CheckLocks())
            {
                MessageBox.Show("This version of NetworX is locked. You are not allowed to launch the application.");
                return;
            }
#endif
            #endregion

            CopyAppData();

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Config = new Config(Program.APPDATA + "config.xml");

            string exeDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            System.IO.Directory.SetCurrentDirectory(exeDir);

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run((MainForm = new Form1(args)));
            }
            catch (Exception e)
            {
                foreach (var f in Form1.Files)
                {
                    string autosave;

                    if (f.Map.FullName == "Untitled")
                        autosave = "crash_autosave_" + DateTime.Now.ToString("MM_dd_yyyy_hh_mm_tt") + ".tnm";
                    else
                        autosave = "crash_autosave_" + f.Map.Filename + DateTime.Now.ToString("MM_dd_yyyy_hh_mm_tt") + ".tnm";

                    IO.SaveAs(f.Map, autosave);
                }

                new ExceptionInfo(e, "").ShowDialog();
            }
        }

        public static void ProcessCommandLineArguments(string[] args)
        {
            if (args.Contains("--dev"))
                DeveloperMode = true;

            if (args.Contains("--showmac"))
                MessageBox.Show("Your MAC address equals: " + Utilities.ApplicationLocking.GetMACAddr());
        }

        public static bool CheckUpdates()
        {
            while (true)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create("http://api.pxsnake.de/nmc/update.php?v=" + Program.VERSION);
                    var response = (HttpWebResponse)request.GetResponse();
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    var json = JObject.Parse(responseString);
                    var update = bool.Parse(json["updateNeeded"].ToString());
                    if (update == true)
                        new UpdateSummary(json).ShowDialog();

                    return update;
                }
                catch (Exception)
                {
                    var r = MessageBox.Show("You do not seem to have a working internet connection. The program cannot check for updates.", "NetworX", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

                    if (r == DialogResult.Ignore)
                        return true;
                    else if (r == DialogResult.Abort)
                        Environment.Exit(0);
                }
            }
        }

        /* Copy AppData files to AppData */
        /* see here on why this is needed: http://www.delphipraxis.net/149987-programm-mit-inno-setup-richtig-installieren.html */
        private static void CopyAppData()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            /* in every case copy stylesheets, because they could have changed (the default ones should not be edited) */
            cmd.StandardInput.WriteLine(@"robocopy .\ToAppData\style C:\Users\" + Environment.UserName + @"\AppData\Roaming\PixelSnake\NetworX\style /E");
            cmd.StandardInput.Flush();

            /* if fresh installation, copy all */
            if (!Directory.Exists(APPDATA))
            {
                cmd.StandardInput.WriteLine(@"robocopy .\ToAppData C:\Users\" + Environment.UserName + @"\AppData\Roaming\PixelSnake\NetworX /E");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
            }
        }
    }
}
