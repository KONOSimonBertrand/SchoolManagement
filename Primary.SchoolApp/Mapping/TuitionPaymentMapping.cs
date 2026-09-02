

using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;

namespace Primary.SchoolApp.Mapping
{
    public static class TuitionPaymentMapping
    {
        public static TuitionPaymentDTO ToTuitionPaymentDTO(this TuitionPayment entity)
        {
            return new TuitionPaymentDTO
            {
                Id = entity.Id,
                IdNumber = entity.IdNumber,
                Date = entity.Date,
                Amount = entity.Amount,
                EnrollingId = entity.EnrollingId,
                Enrolling= entity.Enrolling,
                CashFlowTypeId = entity.CashFlowTypeId,
                CashFlowType= entity.CashFlowType,
                PaymentMeanId = entity.PaymentMeanId,
                PaymentMean= entity.PaymentMean,
                Balance = entity.Balance,
                DoneBy = entity.DoneBy,
                TransactionDate = entity.TransactionDate,
                TransactionId = entity.TransactionId,
                ReceiptId = entity.ReceiptId,
                Receipt= entity.Receipt,
                Note = entity.Note,
                IsValidated = entity.IsValidated
            };
        }
    }
    public static class TuitionPaymentDTOExtensions
    {
        public static TuitionPayment ToTuitionPayment(this TuitionPaymentDTO dto)
        {
            return new TuitionPayment
            {
                Id = dto.Id,
                IdNumber = dto.IdNumber,
                Date = dto.Date,
                Amount = dto.Amount,
                EnrollingId = dto.EnrollingId,
                Enrolling= dto.Enrolling,
                CashFlowTypeId = dto.CashFlowTypeId,
                CashFlowType= dto.CashFlowType,
                PaymentMeanId = dto.PaymentMeanId,
                PaymentMean= dto.PaymentMean,
                Balance = dto.Balance,
                DoneBy = dto.DoneBy,
                TransactionDate = dto.TransactionDate,
                TransactionId = dto.TransactionId,
                ReceiptId = dto.ReceiptId,
                Receipt= dto.Receipt,
                Note = dto.Note,
                IsValidated = dto.IsValidated
            };
        }
    }
}