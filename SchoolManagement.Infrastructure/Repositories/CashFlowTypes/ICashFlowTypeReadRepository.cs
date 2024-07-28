using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ICashFlowTypeReadRepository
    {
        public Task<CashFlowType?> GetAsyn(string name);
        public Task<IList<CashFlowType>> GetAsynList();
    }
}
