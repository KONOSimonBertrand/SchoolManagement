

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ITuitionOrderWriteRepository
    {
        public Task<bool> SaveTuitionOrderAsync(TuitionOrder order);
        public Task<bool> SaveTuitionOrderItemAsync(TuitionOrderItem item);
        public Task<bool> SaveTuitionOrderItemsAsync(List<TuitionOrderItem> items);
        public Task<bool> ValidateAsync(int orderId);
    }
}
