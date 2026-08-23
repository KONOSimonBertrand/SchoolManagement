
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class SchoolSupplieService : ISchoolSupplieService
    {
        private readonly ISchoolSupplieReadRepository schoolSupplieReadRepository;
        private readonly ISchoolSupplieWriteRepository schoolSupplieWriteRepository;
        private readonly ISchoolYearReadRepository schoolYearReadRepository;
        private readonly IGenerateIdNumberService generateIdNumberService;
        public SchoolSupplieService(ISchoolSupplieRepository schoolSupplieRepository, ISchoolYearRepository schoolYearRepository, IGenerateIdNumberService generateIdNumberService)
        {
            this.schoolSupplieReadRepository = schoolSupplieRepository;
            this.schoolSupplieWriteRepository = schoolSupplieRepository;
            this.schoolYearReadRepository = schoolYearRepository;
            this.generateIdNumberService = generateIdNumberService;
        }
        public async Task<bool> CreateSchoolSupplie(SchoolSupplie schoolSupplie)
        {
            schoolSupplie.IdNumber = await GenerateIdNumber();
            return await schoolSupplieWriteRepository.AddSchoolSupplieAsync(schoolSupplie);
        }


        public async Task<SchoolSupplie?> GetSchoolSupplie(string idNumber)
        {
            return await schoolSupplieReadRepository.GetSchoolSupplieAsync(idNumber) ;
        }

        public async Task<List<SchoolSupplie>> GetSchoolSupplieByEnrollingList(int enrollingId)
        {
            return await schoolSupplieReadRepository.GetSchoolSupplieByEnrollingListAsync(enrollingId);
        }

        public async Task<List<SchoolSupplie>> GetSchoolSupplieBySchoolYearList(int schoolYearId)
        {
            return await schoolSupplieReadRepository.GetSchoolSupplieBySchoolYearListAsync(schoolYearId);
        }


        public async Task<bool> ReturnSchoolSupplie(SchoolSupplie schoolSupplie)
        {
            schoolSupplie.IdNumber = schoolSupplie.IdNumber + "-R";
            schoolSupplie.Amount=schoolSupplie.Amount!=0? (-1) * schoolSupplie.Amount:0;
            schoolSupplie.Quantity = schoolSupplie.Quantity!= 0 ? (-1) * schoolSupplie.Quantity : 0;
            return await schoolSupplieWriteRepository.AddSchoolSupplieAsync(schoolSupplie); ;
        }


        public async  Task<bool> ValidateSchoolSupplie(int schoolSupplieId)
        {
            return await schoolSupplieWriteRepository.ValidateSchoolSupplieAsync(schoolSupplieId);
        }

        public async Task<string> GenerateIdNumber()
        {
            string idNumber;
            var lastRecord = await schoolSupplieReadRepository.GetLastSchoolSupplieAsync();
            SchoolYear? lastSchoolYear = await schoolYearReadRepository.GetLastSchoolYearAsync();
            int lastNumber = lastRecord!=null? int.Parse(lastRecord.IdNumber.Substring(3, 5)):0;
            int year = lastSchoolYear != null? int.Parse(lastSchoolYear.Name.Substring(0, 4)) : DateTime.Now.Year;
            lastNumber++;
            idNumber = generateIdNumberService.GenerateNextIdNumberWithFiveDigit('F', lastNumber, year);
            return idNumber;
        }

    }
}
