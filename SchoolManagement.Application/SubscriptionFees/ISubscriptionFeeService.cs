
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ISubscriptionFeeService
    {
        public Task<bool> CreateSubscriptionFee(SubscriptionFee subscriptionFee);
        public Task<bool> UpdateSubscriptionFee(SubscriptionFee subscriptionFee);
        public Task<SubscriptionFee> GetSubscriptionFee(int cashFlowTypeId, int schoolYearId);
        public Task<IList<SubscriptionFee>> GetSubscriptionFeeList();

    }
}
