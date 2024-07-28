
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

    }
}
