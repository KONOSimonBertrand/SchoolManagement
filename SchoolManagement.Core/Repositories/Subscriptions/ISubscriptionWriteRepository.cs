using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISubscriptionWriteRepository
    {
        public Task<bool> AddSubscriptionAsync(Subscription subscription);
        Task<bool> UpdateSubscriptionAsync(Subscription subscription);
        public Task<bool> ValidateSubscriptionAsync(int subscriptionId);
    }
}