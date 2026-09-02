using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;

namespace Primary.SchoolApp.Mapping
{
    public static class SchoolSupplieMapping
    {
        public static SchoolSupplieDTO ToSchoolSupplieDTO(this SchoolSupplie entity)
        {
            if (entity == null) return null;
            return new SchoolSupplieDTO
            {
                Id = entity.Id,
                IdNumber = entity.IdNumber,
                Date = entity.Date,
                Amount = entity.Amount,
                Quantity = entity.Quantity,
                EnrollingId = entity.EnrollingId,
                Enrolling = entity.Enrolling,
                CashFlowTypeId = entity.CashFlowTypeId,
                CashFlowType = entity.CashFlowType,
                PaymentMeanId = entity.PaymentMeanId,
                PaymentMean = entity.PaymentMean,
                Balance = entity.Balance,
                DoneBy = entity.DoneBy,
                TransactionDate = entity.TransactionDate,
                TransactionId = entity.TransactionId,
                ReceiptId = entity.ReceiptId,
                Receipt = entity.Receipt,
                IsValidated = entity.IsValidated
            };
        }
        public static SchoolSupplie ToSchoolSupplie(this SchoolSupplieDTO dto)
        {
            if (dto == null) return null;
            return new SchoolSupplie
            {
                Id = dto.Id,
                IdNumber = dto.IdNumber,
                Date = dto.Date,
                Amount = dto.Amount,
                Quantity = dto.Quantity,
                EnrollingId = dto.EnrollingId,
                Enrolling = dto.Enrolling,
                CashFlowTypeId = dto.CashFlowTypeId,
                CashFlowType = dto.CashFlowType,
                PaymentMeanId = dto.PaymentMeanId,
                PaymentMean = dto.PaymentMean,
                Balance = dto.Balance,
                DoneBy = dto.DoneBy,
                TransactionDate = dto.TransactionDate,
                TransactionId = dto.TransactionId,
                ReceiptId = dto.ReceiptId,
                Receipt = dto.Receipt,
                IsValidated = dto.IsValidated
            };
        }
    }
}
