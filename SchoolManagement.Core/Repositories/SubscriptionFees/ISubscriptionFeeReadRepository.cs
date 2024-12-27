

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public  interface ISubscriptionFeeReadRepository
    {
        public Task<SubscriptionFee> GetAsync(int cashFlowTypeId, int schoolYearId);
        public Task<IList<SubscriptionFee>> GetListAsync();
    }
}
