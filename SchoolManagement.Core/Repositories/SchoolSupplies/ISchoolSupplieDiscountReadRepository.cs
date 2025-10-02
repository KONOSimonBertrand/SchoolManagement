using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolSupplieDiscountReadRepository
    {
        Task<List<SchoolSupplieDiscount>> GetSchoolSupplieDiscountByEnrollingListAsync(int enrollingId);
        Task<List<SchoolSupplieDiscount>> GetSchoolSupplieDiscountBySchoolYearListAsync(int schoolYearId);
    }
}