
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.Utilities
{
    internal static class AppUtilities
    {
        public static Color MainThemeColor;
        public static string MainFont = "Roboto";
        public static string MainFontMedium = "Roboto Medium";

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

        public static Image GetImage(string category)
        {
            Image image = null;
            switch (ThemeResolutionService.ApplicationThemeName)
            {
                case "Material":
                    switch (category)
                    {
                        case "Edit":
                            image = Resources.pencil_blue;
                            break;
                        case "Eye":
                            image = Resources.eye_blue;
                            break;
                        case "File":
                            image = Resources.create_file_blue;
                            break;
                        case "Lock":
                            image = Resources.lock_blue;
                            break;
                        case "Unlock":
                            image = Resources.unlock_blue;
                            break;
                        case "Close":
                            image = Resources.close_blue;
                            break;
                        case "Printer":
                            image = Resources.printer_blue;
                            break;
                        case "Add":
                            image = Resources.add_blue;
                            break;
                        case "Delete":
                            image = Resources.delete_blue;
                            break;
                        case "Excel":
                            image = Resources.excel_blue;
                            break;
                        case "Duplicate":
                            image = Resources.duplicate_blue;
                            break;
                        case "View":
                            image = Resources.view_blue;
                            break;
                        case "Hide":
                            image = Resources.hide_blue;
                            break;
                    }
                    break;
                case "MaterialBlueGrey":
                    switch (category)
                    {
                        case "Edit":
                            image = Resources.pencil_blue_grey;
                            break;
                        case "Eye":
                            image = Resources.eye_blue_grey;
                            break;
                        case "File":
                            image = Resources.create_file_blue_grey;
                            break;
                        case "Lock":
                            image = Resources.lock_blue_grey;
                            break;
                        case "Unlock":
                            image = Resources.unlock_blue_grey;
                            break;
                        case "Close":
                            image = Resources.close_blue_grey;
                            break;
                        case "Printer":
                            image = Resources.printer_blue_grey;
                            break;
                        case "Add":
                            image = Resources.add_blue_grey;
                            break;
                        case "Delete":
                            image = Resources.delete_blue_grey;
                            break;
                        case "Excel":
                            image = Resources.excel_blue_grey;
                            break;
                        case "Duplicate":
                            image = Resources.duplicate_blue_grey;
                            break;
                        case "View":
                            image = Resources.view_blue_grey;
                            break;
                        case "Hide":
                            image = Resources.hide_blue_grey;
                            break;
                    }
                    break;
                case "MaterialPink":
                    switch (category)
                    {
                        case "Edit":
                            image = Resources.pencil_pink;
                            break;
                        case "Eye":
                            image = Resources.eye_pink;
                            break;
                        case "File":
                            image = Resources.create_file_pink;
                            break;
                        case "Lock":
                            image = Resources.lock_pink;
                            break;
                        case "Unlock":
                            image = Resources.unlock_pink;
                            break;
                        case "Close":
                            image = Resources.close_pink;
                            break;
                        case "Printer":
                            image = Resources.printer_pink;
                            break;
                        case "Add":
                            image = Resources.add_pink;
                            break;
                        case "Delete":
                            image = Resources.delete_pink;
                            break;
                        case "Excel":
                            image = Resources.excel_pink;
                            break;
                        case "Duplicate":
                            image = Resources.duplicate_pink;
                            break;
                        case "View":
                            image = Resources.view_pink;
                            break;
                        case "Hide":
                            image = Resources.hide_pink;
                            break;
                    }
                    break;
                case "MaterialTeal":
                    switch (category)
                    {
                        case "Edit":
                            image = Resources.pencil_teal;
                            break;
                        case "Eye":
                            image = Resources.eye_teal;
                            break;
                        case "File":
                            image = Resources.create_file_teal;
                            break;
                        case "Lock":
                            image = Resources.lock_teal;
                            break;
                        case "Unlock":
                            image = Resources.unlock_teal;
                            break;
                        case "Close":
                            image = Resources.close_teal;
                            break;
                        case "Printer":
                            image = Resources.printer_teal;
                            break;
                        case "Add":
                            image = Resources.add_teal;
                            break;
                        case "Delete":
                            image = Resources.delete_teal;
                            break;
                        case "Excel":
                            image = Resources.excel_teal;
                            break;
                        case "Duplicate":
                            image = Resources.duplicate_teal;
                            break;
                        case "View":
                            image = Resources.view_teal;
                            break;
                        case "Hide":
                            image = Resources.hide_teal;
                            break;
                    }
                    break;
            }
            return image;
        }
        #region GridView Events
        public static void PrintGridView(RadGridView gridView, string title)
        {

            RadPrintDocument printer = new RadPrintDocument();
            printer.Landscape = true;
            printer.Margins.Right = 50;
            printer.Margins.Left = 50;
            printer.Margins.Top = 50;
            printer.Margins.Bottom = 50;
            printer.MiddleHeader = title;
            printer.RightFooter = "Date d'impression: [Date Printed]" + " [Time Printed]";
            printer.LeftFooter = "Page [Page #] sur [Total Pages]";

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            printer.AssociatedObject = gridView;
            dialog.Document = printer;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();

        }
        public static void ExportGridViewToExcel(RadGridView gridView, string title)
        {
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "Excel (*.xls;*xlsx)|*.xls;*.xlsx";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.Show("Entrer le nom du fichier.");
                return;
            }
            string fileName = saveFileDialog.FileName;
            bool openExportFile = false;
            ExportToExcel(fileName, ref openExportFile, gridView);

            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }
        private static void ExportToExcel(string fileName, ref bool openExportFile, RadGridView gridView)
        {
            ExportToExcelML excelExporter = new(gridView)
            {
                //"DATA";

                SummariesExportOption = SummariesOption.DoNotExport,
                //modification du nombre de lignes 
                SheetMaxRows = ExcelMaxRows._1048576,
                //excelExporter.SheetMaxRows = ExcelMaxRows._65536;
                //modification du visual setting            
                ExportVisualSettings = true
            };
            try
            {
                excelExporter.RunExport(fileName);
                DialogResult dr = RadMessageBox.Show("Expotation effectuée avec succès", "Exportation", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
            }
            catch (IOException ex)
            {
                RadMessageBox.Show(null, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        #endregion
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
