

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.CashFlowTypes
{
    public interface ICashFlowTypeWriteRepository
    {
        public Task<bool> AddAsync(CashFlowType cashFlowType);
        public Task<bool> UpdateAsync(CashFlowType cashFlowType);
    }
}
