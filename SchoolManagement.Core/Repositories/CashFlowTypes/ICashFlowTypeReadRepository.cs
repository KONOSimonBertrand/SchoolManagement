using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ICashFlowTypeReadRepository
    {
        public Task<CashFlowType?> GetAsync(string name);
        public Task<IList<CashFlowType>> GetAsyncList();
    }
}
