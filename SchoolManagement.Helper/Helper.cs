using SchoolManagement.Core.Enum;
using System.Drawing;
using System.Runtime.Versioning;

namespace SchoolManagement.Helper
{
    public static class Helper
    {
        [SupportedOSPlatform("windows")]
        public static Image? GetImage(Byte[] byteImage)
        {
            ArgumentNullException.ThrowIfNull(byteImage);
            return new ImageConverter().ConvertFrom(byteImage) as Bitmap;
        }
        [SupportedOSPlatform("windows")]
        public static Icon? GetIcon(Byte[] byteImage)
        {
            ArgumentNullException.ThrowIfNull(byteImage);
            return new IconConverter().ConvertFrom(byteImage) as Icon;
        }

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


        /// <summary>
        /// permet de faire le rounding d'une valeur double en utilisant la culture courante de l'utilisateur
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double RoundingValue(double value)
        {
            return double.Parse(value.ToString("F", System.Globalization.CultureInfo.CurrentCulture));
        }
        /// <summary>
        /// permet de faire le truncating d'une valeur double en utilisant la culture courante de l'utilisateur
        /// </summary>
        /// <param name="value"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static double TruncateDouble(double value, int precision)
        {
            var divisor = (decimal)Math.Pow(10, -1 * 2);
            decimal decimalValue = (decimal)value;
            var actual = (decimalValue - (decimalValue % divisor));
            return (double)actual;
        }


       public static string GetFlowCategoryName(FlowCategory category)
        {
            return category switch
            {
                FlowCategory.Subscription => Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "SUBSCRIPTION" : "ABONNEMENT",
                FlowCategory.Expense => Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "EXPENSE" : "DEPENSE",
                FlowCategory.CashSupply => Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "CASH SUPPLY" : "APPROVISIONNEMENT",
                FlowCategory.SchoolSupplie => Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "SCHOOL SUPPLIES" : "FOURNITURES SCOLAIRE",
                FlowCategory.TuitionFee => Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "TUITION FEE" : "FRAIS SCOLAIRE",
                _ => string.Empty,
            };
        }
        public static string GetFlowTypeName(FlowType flowType)
        {
            return flowType switch
            {
                FlowType.Inflow => Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "INFLOW" : "ENTREE",
                FlowType.Outflow => Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "OUTFLOW" : "SORTIE",
                _ => string.Empty,
            };
        }
    }
}
