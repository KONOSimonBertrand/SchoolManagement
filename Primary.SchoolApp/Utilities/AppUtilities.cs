
using System;
using System.Collections.Generic;
using System.IO;

namespace Primary.SchoolApp.Utilities
{
    internal static class AppUtilities
    {
        public static List<string> Religions()
        {
            List<string> religions = new List<string>();
            religions.Add("Inonnue");
            religions.Add("Christianisme");
            religions.Add("Christianisme-Catholicisme");
            religions.Add("Christianisme-Protestantisme");
            religions.Add("Christianisme-Orthodoxe");
            religions.Add("Judaïsme");
            religions.Add("Islam");
            religions.Add("Islam-Sunnisme");
            religions.Add("Islam-Chiisme");
            religions.Add("Islam-Ahmadisme");
            religions.Add("Bahaïsme");
            religions.Add("Hindouisme");
            religions.Add("Bouddhisme");
            religions.Add("Taoïsme");
            religions.Add("Jaïnisme");
            religions.Add("Sikhisme");

            return religions;

        }


        #region LogManager
        public static void AddLog(string logMessage)
        {
            using (StreamWriter w = File.AppendText(System.Windows.Forms.Application.StartupPath + @"\Log\Log.txt"))
            {
                AddLogMessage(logMessage, w);
            }

        }
        private static void AddLogMessage(string logMessage, TextWriter w)
        {
            w.Write("\r\nDate   : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            // w.WriteLine("  :");
            w.WriteLine("Message: {0}", logMessage);
            w.WriteLine("-------------------------------");

        }
        #endregion
    }
}
