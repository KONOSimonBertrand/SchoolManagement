
using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ICashFlowWriteRepository
    {
        Task<bool> AddCashFlowAsync(CashFlow cashFlow);
        Task<bool> AddTuitionDiscountAsync(TuitionDiscount discount);
        Task<bool> AddTuitionPaymentAsync(TuitionPayment payment);
        Task<bool> UpdateTuitionDiscountAsync(TuitionDiscount discount);
        Task<bool> ValidateTuitionPaymentAsync(int paymentId);
        Task<bool> AddCashBoxOutAsync(CashBoxOut cashBoxOut);
        Task<bool> AddCashBoxInAsync(CashBoxIn cashBoxIn);
        Task<bool> ValidateCashBoxInAsync(int cashBoxInId);
        Task<bool> ValidateCashBoxOutAsync(int cashBoxOutId);
    }
}
