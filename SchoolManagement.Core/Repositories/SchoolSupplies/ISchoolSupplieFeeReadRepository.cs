using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolSupplieFeeReadRepository
    {
        public Task<SchoolSupplieFee> GetAsync(int schoolClassId, int cashFlowTypeId, int schoolYearId);
        public Task<IList<SchoolSupplieFee>> GetListAsync();
        public Task<IList<SchoolSupplieFee>> GetListAsync(int schoolYearId);
        public Task<IList<SchoolSupplieFee>> GetListAsync(List<int> idClasslist, int cashFlowTypeId, int schoolYearId);
    }
}