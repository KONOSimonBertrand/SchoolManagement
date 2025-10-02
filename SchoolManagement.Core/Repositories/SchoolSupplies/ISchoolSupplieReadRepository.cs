using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolSupplieReadRepository
    {
        Task<SchoolSupplie?> GetLastSchoolSupplieAsync();
        Task<SchoolSupplie?> GetSchoolSupplieAsync(string idNumber);
        Task<List<SchoolSupplie>> GetSchoolSupplieByEnrollingListAsync(int enrollingId);
        Task<List<SchoolSupplie>> GetSchoolSupplieBySchoolYearListAsync(int schoolYearId);
    }
}