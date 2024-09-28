using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISubscriptionReadRepository
    {
        public Task<List<Subscription>> GetSubscriptionListByEnrollingAsync(int enrollingId);
        Task<List<Subscription>> GetSubscriptionListBySchoolYearAsync(int schoolyearId);
        public Task<Subscription?> GetSubscriptionAsync(int studentId, int subscriptionFeeId,DateTime dateSubscription);
    }
}