

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ICashFlowReadRepository
    {
        Task<CashFlow> GetCashFlowAsync(string idNumber);
        Task<List<CashFlow>> GetCashFlowListAsync(int schoolYearId);
        Task<CashFlow> GetLastCashFlowAsync();
        Task<TuitionPayment?> GetLastTuitionPaymentAsync();
        Task<TuitionDiscount> GetTuitionDiscountAsync(int enrollingId, int cashFlowTypeId);
        Task<List<TuitionDiscount>> GetTuitionDiscountByEnrollingListAsync(int enrollingId);
        Task<List<TuitionDiscount>> GetTuitionDiscountBySchoolYearListAsync(int schoolYearId);
        Task<TuitionPayment?> GetTuitionPaymentAsync(string idNumber);
        Task<List<TuitionPayment>> GetTuitionPaymentByEnrollingListAsync(int enrollingId);
        Task<List<TuitionPayment>> GetTuitionPaymentBySchoolYearListAsync(int schoolYearId);
        Task<CashBoxOut?> GetCashBoxOutAsync(string idNumber);
        Task<List<CashBoxOut>> GetCashBoxOutListAsync(int schoolYearId);
        Task<CashBoxOut?> GetLastCashBoxOutAsync();
        Task<CashBoxIn?> GetCashBoxInAsync(string idNumber);
        Task<List<CashBoxIn>> GetCashBoxInListAsync(int schoolYearId);
        Task<CashBoxIn?> GetLastCashBoxInAsync();
    }
}
