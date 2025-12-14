using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IReceiptWriteRepository
    {
        public Task<Receipt> Add(Receipt receipt);
    }
}