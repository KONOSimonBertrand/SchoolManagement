using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ICashFlowTypeWriteRepository
    {
        public Task<bool> AddAsync(CashFlowType cashFlowType);
        public Task<bool> UpdateAsync(CashFlowType cashFlowType);
    }
}
