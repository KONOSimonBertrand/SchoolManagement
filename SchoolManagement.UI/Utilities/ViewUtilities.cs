

using Telerik.WinControls;


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
                        case "Watch":
                            image = Resources.watch_blue;
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
                        case "Folder":
                            image= GetImage(Resources.folder_blue);
                            break;
                        case "Hide":
                            image = Resources.hide_blue;
                            break;
                        case "Save":
                            image = Resources.floppy_disk_blue;
                            break;
                        case "Import":
                            image = GetImage(Resources.import_blue);
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
                            image = Resources.pencil_blue_grey;
                            break;
                        case "Watch":
                            image = Resources.watch_blue_grey;
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
                        case "Folder":
                            image = GetImage(Resources.folder_blue_grey);
                            break;
                        case "Hide":
                            image = Resources.hide_blue_grey;
                            break;
                        case "Save":
                            image = Resources.floppy_disk_blue_grey;
                            break;
                        case "Import":
                            image = GetImage(Resources.import_blue_grey);
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
                            image = Resources.pencil_pink;
                            break;
                        case "Watch":
                            image = Resources.watch_pink;
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
                        case "Folder":
                            image = GetImage(Resources.folder_pink);
                            break;
                        case "Hide":
                            image = Resources.hide_pink;
                            break;
                        case "Save":
                            image = Resources.floppy_disk_pink;
                            break;
                        case "Import":
                            image = GetImage(Resources.import_pink);
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
                            image = Resources.pencil_teal;
                            break;
                        case "Watch":
                            image = Resources.watch_teal;
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
                        case "Folder":
                            image = GetImage(Resources.folder_teal);
                            break;
                        case "Hide":
                            image = Resources.hide_teal;
                            break;
                        case "Save":
                            image = Resources.floppy_disk_teal;
                            break;
                        case "Import":
                            image = GetImage(Resources.import_teal);
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
                            image = GetImage(Resources.pencil_white);
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
                        case "Save":
                            image = GetImage(Resources.floppy_disk_white);
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
                        case "Import":
                            image = GetImage(Resources.import_white);
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

        public static Image GetImage(Byte[] byteImage)
        {
            return (Bitmap)((new ImageConverter()).ConvertFrom(byteImage));
        }
        public static Icon GetIcon(Byte[] byteImage)
        {
            return (Icon)((new IconConverter()).ConvertFrom(byteImage));
        }

    }
}
