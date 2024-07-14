

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.CashFlowTypes
{
    public interface ICashFlowTypeReadRepository
    {
        public Task<CashFlowType?> GetAsyn(string name);
        public Task<IList<CashFlowType>> GetAsynList();
    }
}
