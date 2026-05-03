

namespace SchoolManagement.Application
{
    public class GenerateIdNumberService : IGenerateIdNumberService
    {

        public GenerateIdNumberService() { }
        public  string GenerateNextIdNumberWithFourDigit(char prefix, int lastNumber, int year)
        {
            string prefixIdNumber = year.ToString().Substring(2, 2) + prefix;
            if (lastNumber.ToString().Length == 1)
            {

                return prefixIdNumber + "000" + lastNumber;
            }
            if (lastNumber.ToString().Length == 2)
            {

                return prefixIdNumber + "00" + lastNumber;
            }
            if (lastNumber.ToString().Length == 3)
            {

                return prefixIdNumber + "0" + lastNumber;
            }
            if (lastNumber.ToString().Length == 4)
            {

                return prefixIdNumber + lastNumber;
            }
            if (lastNumber.ToString().Length > 4)
            {

                return GenerateNextIdNumberWithFourDigit(prefix, 1, year + 1);
            }
            return prefixIdNumber + "0000";
        }
        public  string GenerateNextIdNumberWithFiveDigit(char prefix, int lastNumber, int year)
        {
            string prefixIdNumber = year.ToString().Substring(2, 2) + prefix;
            if (lastNumber.ToString().Length == 1)
            {

                return prefixIdNumber + "0000" + lastNumber;
            }
            if (lastNumber.ToString().Length == 2)
            {

                return prefixIdNumber+ "000" + lastNumber;
            }
            if (lastNumber.ToString().Length == 3)
            {

                return prefixIdNumber + "00" + lastNumber;
            }
            if (lastNumber.ToString().Length == 4)
            {

                return prefixIdNumber + "0" + lastNumber;
            }
            if (lastNumber.ToString().Length == 5)
            {

                return prefixIdNumber + lastNumber;
            }
            if (lastNumber.ToString().Length > 4)
            {

                return GenerateNextIdNumberWithFiveDigit(prefix, 1, year + 1);
            }
            return prefixIdNumber + "00000";
        }

        public string GenerateNextIdNumberWithFourDigit(string prefix, int lastNumber)
        {
            string prefixIdNumber =  prefix;
            if (lastNumber.ToString().Length == 1)
            {

                return  string.Concat(prefixIdNumber,"-","000", lastNumber);
            }
            if (lastNumber.ToString().Length == 2)
            {

                return string.Concat(prefixIdNumber, "-", "00", lastNumber);
            }
            if (lastNumber.ToString().Length == 3)
            {

                return prefixIdNumber + "0" + lastNumber;
            }
            if (lastNumber.ToString().Length == 4)
            {

                return string.Concat(prefixIdNumber, "-", lastNumber);
            }
            return string.Concat(prefixIdNumber, "-", "0000");
        }

        public string GenerateNextIdNumberWithFiveDigit(string prefix, int lastNumber)
        {
            string prefixIdNumber = prefix;
            if (lastNumber.ToString().Length == 1)
            {

                return string.Concat(prefixIdNumber, "-", "0000", lastNumber);
            }
            if (lastNumber.ToString().Length == 2)
            {

                return string.Concat(prefixIdNumber, "-", "000", lastNumber);
            }
            if (lastNumber.ToString().Length == 3)
            {

                return string.Concat(prefixIdNumber, "-", "00", lastNumber);
            }
            if (lastNumber.ToString().Length == 4)
            {

                return string.Concat(prefixIdNumber, "-", "0", lastNumber);
            }
            if (lastNumber.ToString().Length == 5)
            {

                return string.Concat(prefixIdNumber, "-", lastNumber);
            }
            return string.Concat(prefixIdNumber, "-", "00000");
        }
    }
}
