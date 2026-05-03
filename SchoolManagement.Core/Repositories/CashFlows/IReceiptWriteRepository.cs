using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IReceiptWriteRepository
    {
        public Task<Receipt> AddAsync(Receipt receipt);
    }
}