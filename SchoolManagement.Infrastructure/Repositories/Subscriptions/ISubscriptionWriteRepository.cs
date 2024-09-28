using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISubscriptionWriteRepository
    {
        public Task<bool> AddSubscriptionAsync(Subscription subscription);
        Task<bool> UpdateSubscriptionAsync(Subscription subscription);
        Task<bool> CancelSubscriptionAsync(int subscriptionId);
    }
}