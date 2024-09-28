

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ICashFlowReadRepository
    {
        Task<CashFlow> GetCashFlowAsync(string idNumber);
        Task<List<CashFlow>> GetCashFlowListAsync(int schoolYearId);
        Task<CashFlow> GetLastCashFlowAsync();
        Task<TuitionPayment> GetLastTuitionPaymentAsync();
        Task<TuitionDiscount> GetTuitionDiscountAsync(int enrollingId, int cashFlowTypeId);
        Task<List<TuitionDiscount>> GetTuitionDiscountByEnrollingListAsync(int enrollingId);
        Task<List<TuitionDiscount>> GetTuitionDiscountBySchoolYearListAsync(int schoolYearId);
        Task<TuitionPayment> GetTuitionPaymentAsync(string idNumber);
        Task<List<TuitionPayment>> GetTuitionPaymentByEnrollingListAsync(int enrollingId);
        Task<List<TuitionPayment>> GetTuitionPaymentBySchoolYearListAsync(int schoolYearId);
    }
}
