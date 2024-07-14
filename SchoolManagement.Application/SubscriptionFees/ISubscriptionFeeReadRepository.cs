

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SubscriptionFees
{
    public  interface ISubscriptionFeeReadRepository
    {
        public Task<SubscriptionFee> GetAsync(int cashFlowTypeId, int schoolYearId);
        public Task<IList<SubscriptionFee>> GetListAsync();
    }
}
