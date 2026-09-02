

using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;

namespace Primary.SchoolApp.Mapping
{
    public static class ReceiptMapping
    {
        public static ReceiptDTO ToReceiptDTO(this Receipt entity) {
            return new ReceiptDTO()
            {
                Id = entity.Id,
                Amount = entity.Amount,
                Balance = entity.Balance,
                Date = entity.Date,
                IdNumber = entity.IdNumber,
                IsValidated = entity.IsValidated,
                OpDoneBy = entity.OpDoneBy,
                OpFor = entity.OpFor,
                SchoolYear = entity.SchoolYear,
                SchoolYearId = entity.SchoolYearId,
            };
        }

        public static Receipt ToReceipt(this ReceiptDTO dto) {
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
