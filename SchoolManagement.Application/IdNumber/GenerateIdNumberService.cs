

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
    }
}
