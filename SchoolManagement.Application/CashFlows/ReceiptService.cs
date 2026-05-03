

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptWriteRepository receiptWriteRepository;
        private readonly IReceiptReadRepository receiptReadRepository;
        private readonly IGenerateIdNumberService generateIdNumberService;
        public ReceiptService(IReceiptRepository receiptRepository, IGenerateIdNumberService generateIdNumberService)
        {
            this.receiptWriteRepository = receiptRepository;
            this.receiptReadRepository = receiptRepository;
            this.generateIdNumberService = generateIdNumberService;
        }
        public async Task<Receipt> CreateReceiptAsync(Receipt receipt)
        {
            receipt.IdNumber = await GenerateReceiptIdNumberAsync();
            return await receiptWriteRepository.AddAsync(receipt);
        }

        public async Task<string> GenerateReceiptIdNumberAsync()
        {
            var selectedDate = DateTime.Now;    
            var receipts = await receiptReadRepository.GetListByDateAsync(selectedDate);
            var prefix=string.Concat(selectedDate.Year.ToString(),"-",selectedDate.Month.ToString());
            var idNumber =generateIdNumberService.GenerateNextIdNumberWithFourDigit(prefix, receipts.Count+1);
            return idNumber;
        }

        public Task<Receipt?> GetReceiptByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Receipt?> GetReceiptByIdNumberAsync(string idNumber)
        {
            throw new NotImplementedException();
        }

        public Task<List<Receipt>> GetReceiptListAsync(int schoolYearId)
        {
            throw new NotImplementedException();
        }
    }
}
