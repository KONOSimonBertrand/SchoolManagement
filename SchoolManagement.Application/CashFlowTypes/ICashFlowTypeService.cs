
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ICashFlowTypeService
    {
        public Task<bool> CreateCashFlowType(CashFlowType cashFlowType);
        public Task<bool> UpdateCashFlowType(CashFlowType cashFlowType);
        public Task<CashFlowType> GetCashFlowType(string name);
        public Task<IList<CashFlowType>> GetCashFlowTypeList();
    }
}
