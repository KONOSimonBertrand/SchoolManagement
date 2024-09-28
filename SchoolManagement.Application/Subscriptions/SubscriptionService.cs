

using SchoolManagement.Application.Subscriptions;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionWriteRepository subscriptionWriteRepository;
        private readonly ISubscriptionReadRepository subscriptionReadRepository;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionWriteRepository = subscriptionRepository;
            this.subscriptionReadRepository = subscriptionRepository;
        }

        public async Task<bool> CancelSubscriptionAsync(int subscriptionId)
        {
            return await subscriptionWriteRepository.CancelSubscriptionAsync(subscriptionId);
        }

        public async Task<bool> CreateSubscriptionAsync(Subscription subscription)
        {
           return await subscriptionWriteRepository.AddSubscriptionAsync(subscription);
        }

        public async Task<Subscription?> GetSubscriptionAsync(int enrollingId, int cashFlowTypeId, DateTime subscriptionDate)
        {
            return await subscriptionReadRepository.GetSubscriptionAsync(enrollingId, cashFlowTypeId,subscriptionDate);
        }

        public async Task<List<Subscription>> GetSubscriptionListByEnrollingAsync(int enrollingId)
        {
            return await subscriptionReadRepository.GetSubscriptionListByEnrollingAsync(enrollingId);
        }

        public  async Task<List<Subscription>> GetSubscriptionListBySchoolYearAsync(int schoolyearId)
        {
            return await subscriptionReadRepository.GetSubscriptionListBySchoolYearAsync(schoolyearId);
        }

        public async Task<bool> UpdateSubscriptiongAsync(Subscription subscription)
        {
            return await subscriptionWriteRepository.UpdateSubscriptionAsync(subscription);
        }
    }
}
