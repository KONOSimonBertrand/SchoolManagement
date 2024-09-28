

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Subscriptions
{
    public  interface ISubscriptionService
    {
        public Task<bool> CreateSubscriptionAsync(Subscription subscription);
        public Task<bool> UpdateSubscriptiongAsync(Subscription subscription);
        public Task<Subscription?> GetSubscriptionAsync(int enrollingId, int cashFlowTypeId,DateTime dateSubscription);
        public Task<List<Subscription>> GetSubscriptionListBySchoolYearAsync(int schoolyearId);
        public Task<List<Subscription>> GetSubscriptionListByEnrollingAsync(int enrollingId);
        public Task<bool> CancelSubscriptionAsync(int subscriptionId);
    }
}
