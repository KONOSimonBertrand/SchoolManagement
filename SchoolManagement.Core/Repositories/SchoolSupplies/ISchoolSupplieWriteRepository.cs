using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolSupplieWriteRepository
    {
        Task<bool> AddSchoolSupplieAsync(SchoolSupplie schoolSupplie);
        Task<bool> ValidateSchoolSupplieAsync(int schoolSupplieId);
    }
}