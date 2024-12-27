

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public  interface ISubscriptionService
    {
        public Task<bool> CreateSubscriptionAsync(Subscription subscription);
        public Task<bool> UpdateSubscriptiongAsync(Subscription subscription);
        public Task<Subscription?> GetSubscriptionAsync(int enrollingId,int schoolYearId, int cashFlowTypeId,DateTime dateSubscription);
        public Task<Subscription?> GetSubscriptionAsync(string idNumber);
        public Task<List<Subscription>> GetSubscriptionLisAsync(int schoolyearId);
        public Task<List<Subscription>> GetSubscriptionListAsync(int studentId,int schoolYearId);
        public Task<bool> ReturnSubscriptionAsync(Subscription subscription);
        public Task<bool> ValidateSubscriptionAsync(int subscriptionId);
    }
}
