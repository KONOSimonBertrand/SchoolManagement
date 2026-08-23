using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISubscriptionWriteRepository
    {
        public Task<bool> AddSubscriptionAsync(Subscription subscription);
        public Task<bool> ValidateSubscriptionAsync(int subscriptionId);
    }
}