using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ICashFlowTypeReadRepository
    {
        public Task<CashFlowType?> GetAsyn(string name);
        public Task<IList<CashFlowType>> GetAsynList();
    }
}
