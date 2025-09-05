using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolSupplieFeesReadRepository
    {
        public Task<SchoolSupplieFee> GetAsync(int cashFlowTypeId, int schoolYearId);
        public Task<IList<SchoolSupplieFee>> GetListAsync();
        public Task<IList<SchoolSupplieFee>> GetListAsync(int schoolYearId);
    }
}