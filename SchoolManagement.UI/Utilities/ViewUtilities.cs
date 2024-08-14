

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace SchoolManagement.UI.Utilities
{
    internal static class ViewUtilities
    {
        public static Color MainThemeColor;
        public static string MainFont = "Roboto";
        public static string MainFontMedium = "Roboto Medium";
       
        public static bool IsNumber(string text)
        {
            bool res = true;
            try
            {
                if (!string.IsNullOrEmpty(text) && ((text.Length != 1) || (text != "-")))
                {
                    Decimal d = decimal.Parse(text, System.Globalization.CultureInfo.CurrentCulture);
                }
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public static List<string> Religions()
        {
            List<string> religions = new()
            {
                "Inonnue",
                "Christianisme",
                "Christianisme-Catholicisme",
                "Christianisme-Protestantisme",
                "Christianisme-Orthodoxe",
                "Judaïsme",
                "Islam",
                "Islam-Sunnisme",
                "Islam-Chiisme",
                "Islam-Ahmadisme",
                "Bahaïsme",
                "Hindouisme",
                "Bouddhisme",
                "Taoïsme",
                "Jaïnisme",
                "Sikhisme"
            };

            return religions;

        }
        //get image from resource file
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
                        case "Add":
                            image = Resources.add_blue;
                            break;
                        case "Excel":
                            image = Resources.excel_blue;
                            break;
                        case "Printer":
                            image = Resources.printer_blue;
                            break;
                        case "View":
                            image= Resources.view_blue;
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
                        case "Add":
                            image = Resources.add_blue_grey;
                            break;
                        case "Excel":
                            image = Resources.excel_blue_grey;
                            break;
                        case "Printer":
                            image = Resources.printer_blue_grey;
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
                        case "Add":
                            image = Resources.add_pink;
                            break;
                        case "Excel":
                            image = Resources.excel_pink;
                            break;
                        case "Printer":
                            image = Resources.printer_pink;
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
                        case "Add":
                            image = Resources.add_teal;
                            break;
                        case "Excel":
                            image = Resources.excel_teal;
                            break;
                        case "Printer":
                            image = Resources.printer_teal;
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
    
       

    }
}
