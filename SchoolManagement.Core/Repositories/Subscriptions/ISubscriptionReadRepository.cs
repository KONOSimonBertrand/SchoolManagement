using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISubscriptionReadRepository
    {
        public Task<List<Subscription>> GetSubscriptionListAsync(int studentId,int schoolYearId);
        Task<List<Subscription>> GetSubscriptionListAsync(int schoolyearId);
        public Task<Subscription?> GetSubscriptionAsync(int studentId, int schoolYearId, int subscriptionFeeId,DateTime dateSubscription);
        public Task<Subscription?> GetLastSubscriptionAsync();
        public Task<Subscription?> GetSubscriptionAsync(string idNumber);
    }
}