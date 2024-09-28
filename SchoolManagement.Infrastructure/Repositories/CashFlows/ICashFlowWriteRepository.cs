
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ICashFlowWriteRepository
    {
        Task<bool> AddCashFlowAsync(CashFlow cashFlow);
        Task<bool> AddTuitionDiscountAsync(TuitionDiscount discount);
        Task<bool> AddTuitionPaymentAsync(TuitionPayment payment);
        Task<bool> UpdateTuitionDiscountAsync(TuitionDiscount discount);
        Task<bool> ValidateTuitionPaymentAsync(int paymentId);
    }
}
