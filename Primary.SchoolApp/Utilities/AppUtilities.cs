
using System.Collections.Generic;

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
    }
}
