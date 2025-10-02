using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolSupplieDiscountWriteRepository
    {
        Task<bool> AddSchoolSupplieDiscountAsync(SchoolSupplieDiscount discount);
        Task<bool> ChangeStateSchoolSupplieDiscountAsync(SchoolSupplieDiscount discount);
        Task<bool> UpdateSchoolSupplieDiscountAsync(SchoolSupplieDiscount discount);
    }
}