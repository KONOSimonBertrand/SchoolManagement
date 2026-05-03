using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories { 
    public interface IReceiptReadRepository
    {
        public Task<Receipt?> GetByIdAsync(int id);
        public Task<Receipt?> GetByIdNumberAsync(string idNumber);
        public Task<List<Receipt>> GetListByDateAsync(DateTime date);
        public Task<List<Receipt>> GetListBySchoolYearIdAsync(int schoolYearId);
    }
}