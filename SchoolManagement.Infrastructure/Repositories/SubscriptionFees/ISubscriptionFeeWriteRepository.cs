

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISubscriptionFeeWriteRepository
    {
        public Task<bool> AddAsync(SubscriptionFee subscriptionFee);
        public Task<bool> Updatesync(SubscriptionFee subscriptionFee);
    }
}
