

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ITuitionOrderReadRepository
    {
        public Task<TuitionOrder?> GetTuitionOrderAsync(string idNumber);
        public Task<TuitionOrder?> GetLastTuitionOrderAsync();
        public Task<List<TuitionOrderItem>> GetTuitionOrderItemsAsync(int orderId);
        public Task<List<TuitionOrderItem>> GetTuitionOrderItemsAsync(string orderIdNumber);
        public Task<List<TuitionOrder>> GetTuitionOrdersBySchoolYearAsync(int schoolYearId);
        public Task<List<TuitionOrder>> GetTuitionOrdersByEnrollingAsync(int enrollingId);
    }
}
