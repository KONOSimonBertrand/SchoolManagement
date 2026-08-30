

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public  interface ISubscriptionService
    {
        public Task<bool> CreateSubscriptionAsync(Subscription subscription);
        public Task<Subscription?> GetSubscriptionAsync(int enrollingId,int cashFlowTypeId,DateTime dateSubscription);
        public Task<Subscription?> GetSubscriptionAsync(string idNumber);
        public Task<List<Subscription>> GetSubscriptionListBySchoolYearAsync(int schoolyearId);
        public Task<List<Subscription>> GetSubscriptionListByEnrollingAsync(int enrollingId);
        public Task<bool> ReturnSubscriptionAsync(Subscription subscription);
        public Task<bool> ValidateSubscriptionAsync(int subscriptionId);
    }
}
