using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISubscriptionReadRepository
    {
        public Task<List<Subscription>> GetSubscriptionListByEnrollingAsync(int enrollingId);
        public Task<List<Subscription>> GetSubscriptionListBySchoolYearAsync(int schoolyearId);
        public Task<Subscription?> GetSubscriptionAsync(int enrollingId, int subscriptionFeeId,DateTime dateSubscription);
        public Task<Subscription?> GetSubscriptionAsync(string idNumber);
        public Task<Subscription?> GetLastSubscriptionAsync();
       
    }
}