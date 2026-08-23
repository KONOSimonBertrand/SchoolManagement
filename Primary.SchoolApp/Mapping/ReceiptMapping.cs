

using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;

namespace Primary.SchoolApp.Mapping
{
    public static class ReceiptMapping
    {
        public static ReceiptDTO AsReceiptDTO(this Receipt receipt) {
            return new ReceiptDTO()
            {
                Id = receipt.Id,
                Amount = receipt.Amount,
                Balance = receipt.Balance,
                Date = receipt.Date,
                IdNumber = receipt.IdNumber,
                IsValidated = receipt.IsValidated,
                OpDoneBy = receipt.OpDoneBy,
                OpFor = receipt.OpFor,
                SchoolYear = receipt.SchoolYear,
                SchoolYearId = receipt.SchoolYearId,
            };
        }

        public static Receipt AsReceipt(this ReceiptDTO dto) {
            return new Receipt()
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Balance = dto.Balance,
                Date = dto.Date,
                IdNumber = dto.IdNumber,
                IsValidated = dto.IsValidated,
                SchoolYearId= dto.SchoolYearId,
                SchoolYear=dto.SchoolYear,
                OpDoneBy= dto.OpDoneBy,
                OpFor= dto.OpFor,
            };
        }
    }
}
