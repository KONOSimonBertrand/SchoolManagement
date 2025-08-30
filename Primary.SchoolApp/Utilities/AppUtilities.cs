
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI;
using System.Threading;
using System.Linq;
using SchoolManagement.Core.Model;
using System.Text;
using SchoolManagement.UI.Localization;
using System.Diagnostics;

namespace Primary.SchoolApp.Utilities
{
    internal static class AppUtilities
    {
        public static Color MainThemeColor;
        public static string MainFont = "Roboto";
        public static string MainFontMedium = "Roboto Medium";
        public readonly struct Relationship
        {
            public int Id { get; }
            public string Name { get; }
            public Relationship(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        static readonly List<Relationship> relationshipFrenchList = new() {
                new Relationship(0,"Père"),
                new Relationship(1,"Mère"),
                new Relationship(2,"Sœur"),
                new Relationship(3,"Frère"),
                new Relationship(4,"Oncle"),
                new Relationship(5,"Tante"),
                new Relationship(6,"Grand Père"),
                new Relationship(7,"Grand Mère"),
                new Relationship(8,"Cousin"),
                new Relationship(9,"Cousine"),
                new Relationship(10,"Tuteur"),
                new Relationship(11,"Tutrice"),
                new Relationship(12,"Parrain"),
                new Relationship(13,"Marraine"),
                new Relationship(14,"Chauffeur"),
                new Relationship(15,"Nounou"),
                new Relationship(16,"Domestique"),
                new Relationship(17,"Médecin"),
                new Relationship(18,"Autre"),
            };
        static readonly List<Relationship> relationshipEnglishList = new() {
                new Relationship(0,"Father"),
                new Relationship(1,"Mother"),
                new Relationship(2,"Sister"),
                new Relationship(3,"Brother"),
                new Relationship(4,"Uncle"),
                new Relationship(5,"Aunt"),
                new Relationship(6,"Grandfather"),
                new Relationship(7,"Grandmother"),
                new Relationship(8,"Cousin"),
                new Relationship(9,"Cousin"),
                new Relationship(10,"Tutor"),
                new Relationship(11,"Tutor"),
                new Relationship(12,"GodFather"),
                new Relationship(13,"GodMother"),
                new Relationship(14,"Driver"),
                new Relationship(15,"Nanny"),
                new Relationship(16,"household"),
                new Relationship(17,"Doctor"),
                new Relationship(18,"Other"),
            };
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
        public static String ConvertStringToHexString(string input)
        {

            return string.Join("", Encoding.UTF8.GetBytes(input).Select(b => $"{b:X2}"));
        }

        public static string ConvertHexToString(string hexInput)
        {
            if (string.IsNullOrWhiteSpace(hexInput)) return string.Empty;
            return Encoding.UTF8.GetString(Enumerable.Range(0, hexInput.Length / 2).Select(_ => Convert.ToByte(hexInput.Substring(_ * 2, 2), 16)).ToArray());
        }

        public static bool SerialKeyIsOk(string customer, string serialKey)
        {
            bool status = false;
            // un code est composé du nom du client, du type de licence
            // et la durée de la licence(M=mensuel,T=trimestriel,S=semestriel,A=annuel,I=infini
            var serialKeytring = ConvertHexToString(serialKey);
            var serialKeyData = serialKeytring.Split('@');
            if (serialKeyData.Length == 3)
            {
                var customerName = serialKeyData[0];
                var codeType = serialKeyData[1];
                var codeValue = serialKeyData[2];
                try
                {
                    switch (codeType)
                    {
                        case "I":
                            status = customer.ToLower() == customerName.ToLower();
                            break;
                        case "A":
                            var isCustomerA = customer.ToLower() == customerName.ToLower();
                            var startA = Convert.ToDateTime(codeValue);
                            var isNoteExpiredA = startA.AddDays(360) > DateTime.Now;
                            status = isCustomerA && isNoteExpiredA;
                            break;
                        case "S":
                            var isCustomerS = customer.ToLower() == customerName.ToLower();
                            var startS = Convert.ToDateTime(codeValue);
                            var isNoteExpiredS = startS.AddDays(180) > DateTime.Now;
                            status = isCustomerS && isNoteExpiredS;
                            break;
                        case "T":
                            var isCustomerT = customer.ToLower() == customerName.ToLower();
                            var startT = Convert.ToDateTime(codeValue);
                            var isNoteExpiredT = startT.AddDays(90) > DateTime.Now;
                            status = isCustomerT && isNoteExpiredT;
                            break;
                        case "M":
                            var isCustomerM = customer.ToLower() == customerName.ToLower();
                            var startM = Convert.ToDateTime(codeValue);
                            var isNoteExpiredM = startM.AddDays(180) > DateTime.Now;
                            status = isCustomerM && isNoteExpiredM;
                            break;
                    }
                }
                catch (Exception)
                {

                }
            }
                return status;
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
                            image = GetImage(Resources.pencil_blue);
                            break;
                        case "Watch":
                            image = Resources.watch_blue;
                            break;
                        case "Image":
                            image = Resources.add_image_blue;
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
                        case "Folder":
                            image = GetImage(Resources.folder_blue);
                            break;
                        case "Hide":
                            image = Resources.hide_blue;
                            break;
                        case "Undo":
                            image = Resources.undo_blue;
                            break;
                        case "Cancel":
                            image = Resources.cancel_blue;
                            break;
                        case "Search":
                            image = Resources.search_blue;
                            break;
                        case "Check":
                            image = (Bitmap)(new ImageConverter()).ConvertFrom(Resources.check_blue);
                            break;
                        case "Payment":
                            image = GetImage(Resources.add_payment_blue);
                            break;
                        case "Contact":
                            image = GetImage(Resources.add_contact_blue);
                            break;
                        case "Card":
                            image = GetImage(Resources.id_card_blue);
                            break;
                        case "Show":
                            image = GetImage(Resources.show_blue);
                            break;
                    }
                    break;
                case "MaterialBlueGrey":
                    switch (category)
                    {
                        case "Edit":
                            image = GetImage(Resources.pencil_blue_grey);
                            break;
                        case "Watch":
                            image = Resources.watch_blue_grey;
                            break;
                        case "Image":
                            image = Resources.add_image_blue_grey;
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
                        case "Folder":
                            image = GetImage(Resources.folder_blue_grey);
                            break;
                        case "Hide":
                            image = Resources.hide_blue_grey;
                            break;
                        case "Undo":
                            image = Resources.undo_blue_grey;
                            break;
                        case "Cancel":
                            image = Resources.cancel_blue_grey;
                            break;
                        case "Search":
                            image = Resources.search_blue_grey;
                            break;
                        case "Check":
                            image = (Bitmap)(new ImageConverter()).ConvertFrom(Resources.check_blue_grey);
                            break;
                        case "Payment":
                            image = GetImage(Resources.add_payment_blue_grey);
                            break;
                        case "Contact":
                            image = GetImage(Resources.add_contact_blue_grey);
                            break;
                        case "Card":
                            image = GetImage(Resources.id_card_blue_grey);
                            break;
                        case "Show":
                            image = GetImage(Resources.show_blue_grey);
                            break;
                    }
                    break;
                case "MaterialPink":
                    switch (category)
                    {
                        case "Edit":
                            image = GetImage(Resources.pencil_pink);
                            break;
                        case "Watch":
                            image = Resources.watch_pink;
                            break;
                        case "Image":
                            image = Resources.add_image_pink;
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
                        case "Folder":
                            image = GetImage(Resources.folder_pink);
                            break;
                        case "Hide":
                            image = Resources.hide_pink;
                            break;
                        case "Undo":
                            image = Resources.undo_pink;
                            break;
                        case "Cancel":
                            image = Resources.cancel_pink;
                            break;
                        case "Search":
                            image = Resources.search_pink;
                            break;
                        case "Check":
                            image = (Bitmap)(new ImageConverter()).ConvertFrom(Resources.check_pink);
                            break;
                        case "Payment":
                            image = GetImage(Resources.add_payment_pink);
                            break;
                        case "Contact":
                            image = GetImage(Resources.add_contact_pink);
                            break;
                        case "Card":
                            image = GetImage(Resources.id_card_pink);
                            break;
                        case "Show":
                            image = GetImage(Resources.show_pink);
                            break;
                    }
                    break;
                case "MaterialTeal":
                    switch (category)
                    {
                        case "Edit":
                            image = GetImage(Resources.pencil_teal);
                            break;
                        case "Watch":
                            image = Resources.watch_teal;
                            break;
                        case "Image":
                            image = Resources.add_image_teal;
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
                        case "Folder":
                            image = GetImage(Resources.folder_teal);
                            break;
                        case "Hide":
                            image = Resources.hide_teal;
                            break;
                        case "Undo":
                            image = Resources.undo_teal;
                            break;
                        case "Cancel":
                            image = Resources.cancel_teal;
                            break;
                        case "Search":
                            image = Resources.search_teal;
                            break;
                        case "Check":
                            image = (Bitmap)(new ImageConverter()).ConvertFrom(Resources.check_teal);
                            break;
                        case "Payment":
                            image = GetImage(Resources.add_payment_teal);
                            break;
                        case "Contact":
                            image = GetImage(Resources.add_contact_teal);
                            break;
                        case "Card":
                            image = GetImage(Resources.id_card_teal);
                            break;
                        case "Show":
                            image = GetImage(Resources.show_teal);
                            break;
                    }
                    break;
                case "Windows11Dark":
                    switch (category)
                    {
                        case "Edit":
                            image =GetImage(Resources.pencil_white);
                            break;
                        case "Watch":
                            image = GetImage(Resources.watch_white);
                            break;
                        case "Image":
                            image = GetImage(Resources.add_image_White);
                            break;
                        case "File":
                            image = GetImage(Resources.create_file_white);
                            break;
                        case "Lock":
                            image = GetImage(Resources.lock_white);
                            break;
                        case "Unlock":
                            image = GetImage(Resources.unlock_white);
                            break;
                        case "Close":
                            image = GetImage(Resources.close_white);
                            break;
                        case "Printer":
                            image = GetImage(Resources.printer_white);
                            break;
                        case "Add":
                            image = GetImage(Resources.add_white);
                            break;
                        case "Delete":
                            image = GetImage(Resources.delete_white);
                            break;
                        case "Excel":
                            image = GetImage(Resources.excel_white);
                            break;
                        case "Duplicate":
                            image = GetImage(Resources.duplicate_white);
                            break;
                        case "Folder":
                            image = GetImage(Resources.folder_white);
                            break;
                        case "Hide":
                            image = GetImage(Resources.hide_white);
                            break;
                        case "Undo":
                            image = GetImage(Resources.undo_white);
                            break;
                        case "Cancel":
                            image = GetImage(Resources.cancel_white);
                            break;
                        case "Search":
                            image = GetImage(Resources.search_white);
                            break;
                        case "Check":
                            image = GetImage(Resources.check_white);
                            break;
                        case "Payment":
                            image = GetImage(Resources.add_payment_white);
                            break;
                        case "Contact":
                            image = GetImage(Resources.add_contact_white);
                            break;
                        case "Card":
                            image = GetImage(Resources.id_card_white);
                            break;
                        case "Show":
                            image = GetImage(Resources.show_white);
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

        public static string GetCurrentMethodName()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            return stackFrame.GetMethod().DeclaringType + " :: " + stackFrame.GetMethod().Name;
        }

        #endregion

        private static double TruncateDouble(double value, int precision)
        {
            var divisor = (decimal)Math.Pow(10, -1 * 2);
            decimal decimalValue = (decimal)value;
            var actual = (decimalValue - (decimalValue % divisor));
            return (double)actual;
        }
        public static string GetRelationshipName(int relationshipId)
        {
            var relationship = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? relationshipEnglishList.FirstOrDefault(x => x.Id == relationshipId) : relationshipFrenchList.FirstOrDefault(x => x.Id == relationshipId);
            return relationship.Name;
        }
        public static List<Relationship> GetRelationshipList()
        {
            return Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? relationshipEnglishList : relationshipFrenchList;
        }
        public static Image GetImageFromUrl(string imageName)
        {
            var url = Application.StartupPath + @"\Images\" + imageName;
            try
            {
                var image = Image.FromFile(url);
                return image;
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
            return null;
        }

        public static Image GetImage(Byte[] byteImage)
        {
            return (Bitmap)((new ImageConverter()).ConvertFrom(byteImage));
        }
        public static Icon GetIcon(Byte[] byteImage)
        {
            return (Icon)((new IconConverter()).ConvertFrom(byteImage));
        }
        // return truncate or rounding value
        public static double GetTruncateOrRoundingValue(double value, SchoolGroup group)
        {
            double result = group.NoteIsTruncate ? TruncateDouble(value, 2) : RoundingValue(value);
            return result;
        }
        public static double RoundingValue(double value)
        {
            return double.Parse(value.ToString("F", System.Globalization.CultureInfo.CurrentCulture));
        }

        public static string ToLisenceType(string key) => key switch
        {
            "I" => Language.LabelInfinity,
            "A" => Language.LabelAnnualLisence,
            "S" => Language.LabelBiannualLisence,
            "T" => Language.LabelQuarterlyLisence,
            "M" => Language.LabelMonthlyLisence,
            _ => Language.LabelUnknowLisence,
        };
        public static string GetExpiryDate(string key, string data)
        {
            if (key == "I") return Language.LabelInfinity;
            if (key == "A")
            {
                try
                {
                    var startA = Convert.ToDateTime(data);
                    return startA.AddDays(360).ToShortDateString();
                }
                catch (Exception)
                {
                }
            }
            if (key == "S")
            {
                try
                {
                    var startA = Convert.ToDateTime(data);
                    return startA.AddDays(180).ToShortDateString();
                }
                catch (Exception)
                {
                }
            }
            if (key == "T")
            {
                try
                {
                    var startA = Convert.ToDateTime(data);
                    return startA.AddDays(90).ToShortDateString();
                }
                catch (Exception)
                {
                }
            }
            if (key == "M")
            {
                try
                {
                    var startA = Convert.ToDateTime(data);
                    return startA.AddDays(30).ToShortDateString();
                }
                catch (Exception)
                {
                }
            }
            return string.Empty;
        }

        public static string MonthToLongName(int index)
        {
            string name = "";
            switch (index)
            {
                case 1:
                    name = Language.LanguageName == "EN" ? "January" : "Janvier";
                    break;
                case 2:
                    name = Language.LanguageName == "EN" ? "February" : "Février";
                    break;
                case 3:
                    name = Language.LanguageName == "EN" ? "March" : "Mars";
                    break;
                case 4:
                    name = Language.LanguageName == "EN" ? "April" : "Avril";
                    break;
                case 5:
                    name = Language.LanguageName == "EN" ? "May" : "Mai";
                    break;
                case 6:
                    name = Language.LanguageName == "EN" ? "June" : "Juin";
                    break;
                case 7:
                    name = Language.LanguageName == "EN" ? "July" : "Juillet";
                    break;
                case 8:
                    name = Language.LanguageName == "EN" ? "August" : "Août";
                    break;
                case 9:
                    name = Language.LanguageName == "EN" ? "September" : "Septembre";
                    break;
                case 10:
                    name = Language.LanguageName == "EN" ? "October" : "Octobre";
                    break;
                case 11:
                    name = Language.LanguageName == "EN" ? "November" : "Novembre";
                    break;
                case 12:
                    name = Language.LanguageName == "EN" ? "December":"Decembre";
                    break;
            }
            return name;
        }
        public static string MonthToShortName(int index)
        {
            string name = "";
            switch (index)
            {
                case 1:
                    name = Language.LanguageName=="EN"? "Jan": "Jan";
                    break;
                case 2:
                    name = Language.LanguageName == "EN" ? "Feb": "Fév";
                    break;
                case 3:
                    name = Language.LanguageName == "EN" ?"March": "Mars";
                    break;
                case 4:
                    name = Language.LanguageName == "EN" ?"April": "Avril";
                    break;
                case 5:
                    name = Language.LanguageName == "EN" ? "May" : "Mai";
                    break;
                case 6:
                    name = Language.LanguageName == "EN" ? "June" : "Juin";
                    break;
                case 7:
                    name = Language.LanguageName == "EN" ? "July" : "Juil";
                    break;
                case 8:
                    name = Language.LanguageName == "EN" ? "Aug" : "Août";
                    break;
                case 9:
                    name = Language.LanguageName == "EN" ? "Sept" : "Sept";
                    break;
                case 10:
                    name = Language.LanguageName == "EN" ? "Oct" : "Oct";
                    break;
                case 11:
                    name = Language.LanguageName == "EN" ? "Nov" : "Nov";
                    break;
                case 12:
                    name = Language.LanguageName == "EN" ? "Dec" : "Déc";
                    break;
            }
            return name;
        }


        #region Report Card Method
        public static Dictionary<string, string> GetHeadTerm(string termCode, string language)
        {
            Dictionary<string, string> terms = new();
            switch (termCode)
            {
                case "TERM01":
                    terms.Add("Title", language == "FR" ? "BULLETIN DU PREMIER TRIMESTRE" : "FIRST TERM SUMMARY MARK");
                    terms.Add("FirstMonth", language == "FR" ? "1ʳᵉ EVAL" : "1ˢᵗ EVAL");
                    terms.Add("SecondMonth", language == "FR" ? "2ᵉ EVAL" : "2ⁿᵈ EVAL");
                    terms.Add("ThirdMonth", language == "FR" ? "3ᵉ  EVAL" : "3ʳᵈ EVAL");
                    break;
                case "TERM02":
                    terms.Add("Title", language == "FR" ? "BULLETIN DU DEUXIEME TRIMESTRE" : "SECOND TERM SUMMARY MARK");
                    terms.Add("FirstMonth", language == "FR" ? "4ᵉ  EVAL" : "4ᵗʰ EVAL");
                    terms.Add("SecondMonth", language == "FR" ? "5ᵉ EVAL" : "5ᵗʰ EVAL");
                    terms.Add("ThirdMonth", language == "FR" ? "6ᵉ  EVAL" : "6ᵗʰ EVAL");
                    break;
                case "TERM03":
                    terms.Add("Title", language == "FR" ? "BULLETIN DU TROISIEME TRIMESTRE" : "THIRD TERM SUMMARY MARK");
                    terms.Add("FirstMonth", language == "FR" ? "7ᵉ  EVAL" : "7ᵗʰ EVAL");
                    terms.Add("SecondMonth", language == "FR" ? "8ᵉ EVAL" : "8ᵗʰ EVAL");
                    terms.Add("ThirdMonth", language == "FR" ? "9ᵉ  EVAL" : "9ᵗʰ EVAL");
                    break;
            }
            return terms;
        }
        #endregion
    }
}
