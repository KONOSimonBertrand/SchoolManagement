

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SubscriptionFees
{
    public interface ISubscriptionFeeWriteRepository
    {
        public Task<bool> AddAsync(SubscriptionFee subscriptionFee);
        public Task<bool> Updatesync(SubscriptionFee subscriptionFee);
    }
}
