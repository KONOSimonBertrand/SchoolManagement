

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ITuitionOrderWriteRepository
    {
        public Task<bool> SaveTuitionOrderAsync(TuitionOrder order);
        public Task<bool> ValidateAsync(int orderId);
    }
}
