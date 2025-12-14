

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ITuitionOrderService
    {
        public Task<List<TuitionOrder>> GetTuitionOrdersByEnrollingAsync(int enrollingId);
        public Task<List<TuitionOrder>> GetTuitionOrdersBySchoolYearAsync(int schoolYearId);
        public Task<List<TuitionOrderItem>> GetTuitionOrderItemsAsync(int orderId);
        public Task<bool> CreateTuitionOrderAsync(TuitionOrder order);
    }
}
