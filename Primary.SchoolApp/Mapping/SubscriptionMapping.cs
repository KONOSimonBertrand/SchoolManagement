

using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;

namespace Primary.SchoolApp.Mapping
{
    static class SubscriptionMapping
    {
        public static SubscriptionDTO ToSubscriptionDTO(this Subscription sentity)
        {
            return new SubscriptionDTO
            {
                Id = sentity.Id,
                IdNumber = sentity.IdNumber,
                StartDate = sentity.StartDate,
                Amount = sentity.Amount,
                EndDate = sentity.EndDate,
                DoneBy = sentity.DoneBy,
                TransactionId = sentity.TransactionId,
                TransactionDate = sentity.TransactionDate,
                EnrollingId = sentity.EnrollingId,
                Enrolling=sentity.Enrolling,
                CashFlowTypeId = sentity.CashFlowTypeId,
                CashFlowType=sentity.CashFlowType,
                PaymentMeanId = sentity.PaymentMeanId,
                PaymentMean=sentity.PaymentMean,
                ReceiptId = sentity.ReceiptId,
                Receipt=sentity.Receipt,
                IsValidated = sentity.IsValidated
            };
        }
        public static Subscription ToSubscription(this SubscriptionDTO dto)
        {
            return new Subscription
            {
                Id = dto.Id,
                IdNumber = dto.IdNumber,
                StartDate = dto.StartDate,
                Amount = dto.Amount,
                EndDate = dto.EndDate,
                DoneBy = dto.DoneBy,
                TransactionId = dto.TransactionId,
                TransactionDate = dto.TransactionDate,
                EnrollingId = dto.EnrollingId,
                Enrolling=dto.Enrolling,
                CashFlowTypeId = dto.CashFlowTypeId,
                CashFlowType=dto.CashFlowType,
                PaymentMeanId = dto.PaymentMeanId,
                PaymentMean=dto.PaymentMean,
                ReceiptId = dto.ReceiptId,
                Receipt=dto.Receipt,
                IsValidated = dto.IsValidated
            };
        }
    }
}
