

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ISchoolSupplieService
    {
        public Task<bool> CreateSchoolSupplie(SchoolSupplie schoolSupplie);
        public Task<bool> ValidateSchoolSupplie(int schoolSupplieId);
        public Task<bool> ReturnSchoolSupplie(SchoolSupplie schoolSupplie);
        public Task<SchoolSupplie?> GetSchoolSupplie(string idNumber);
        public Task<List<SchoolSupplie>> GetSchoolSupplieBySchoolYearList(int schoolYearId);
        public Task<List<SchoolSupplie>> GetSchoolSupplieByEnrollingList(int enrollingId);

    }
}
