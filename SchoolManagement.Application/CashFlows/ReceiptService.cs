

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
        public async Task<Receipt> ReturnReceiptAsync(Receipt receipt)
        {
            receipt.IdNumber = receipt.IdNumber+"-R";
            receipt.Amount = receipt.Amount * (-1);
            return await receiptWriteRepository.AddAsync(receipt);
        }
        public async Task<string> GenerateReceiptIdNumberAsync()
        {
            var selectedDate = DateTime.Now;    
            var receipts = await receiptReadRepository.GetListByDateAsync(selectedDate);
            var month = selectedDate.Month.ToString().Length == 1 ? string.Concat("0", selectedDate.Month.ToString()) : selectedDate.Month.ToString();
            var prefix=string.Concat(selectedDate.Year.ToString(),"-",month);
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
            return receiptReadRepository.GetListBySchoolYearIdAsync(schoolYearId);
        }
        public async Task<bool> ValidateReceiptAsync(int receiptId)
        {
            return await receiptWriteRepository.ValidateReceiptAsync(receiptId);
        }
    }
}
