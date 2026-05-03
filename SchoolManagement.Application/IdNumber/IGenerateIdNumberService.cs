

namespace SchoolManagement.Application
{
    public  interface IGenerateIdNumberService
    {
        public string GenerateNextIdNumberWithFourDigit(char prefix, int lastNumber, int year);
        public string GenerateNextIdNumberWithFourDigit(string prefix, int lastNumber);
        public string GenerateNextIdNumberWithFiveDigit(char prefix, int lastNumber, int year);
        public string GenerateNextIdNumberWithFiveDigit(string prefix, int lastNumber);
    }
}
