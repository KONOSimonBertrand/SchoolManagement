using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IReceiptService
    {
        public Task<string> GenerateReceiptIdNumberAsync(); 
        public Task<Receipt?> GetReceiptByIdAsync(int id);
        public Task<Receipt?> GetReceiptByIdNumberAsync(string idNumber);
        public Task<Receipt> CreateReceiptAsync(Receipt receipt);
        public Task<List<Receipt>> GetReceiptListAsync(int schoolYearId);
        public Task<bool> ValidateReceiptAsync(int receiptId);
        Task<Receipt> ReturnReceiptAsync(Receipt receipt);
    }
}