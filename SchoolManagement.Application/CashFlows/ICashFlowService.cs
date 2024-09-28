﻿

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
   public interface ICashFlowService
    {
        public Task<bool> CreateTuitionPayment(TuitionPayment payment);
        public Task<bool> ValidateTuitionPayment(int paymentId);
        public Task<bool> ReturnTuitionPayment(TuitionPayment payment);
        public Task<TuitionPayment> GetTuitionPayment(string idNumber);
        public Task<List<TuitionPayment>> GetTuitionPaymentBySchoolYearList(int schoolYearId);
        public Task<List<TuitionPayment>> GetTuitionPaymentByEnrollingList(int enrollingId);

        public Task<bool> CreateTuitionDiscount(TuitionDiscount discount);
        public Task<bool> UpdateTuitionDiscount(TuitionDiscount discount);
        public Task<TuitionDiscount> GetTuitionDiscount(int enrollingId,int cashFlowTypeId);
        public Task<List<TuitionDiscount>> GetTuitionDiscountByEnrollingList(int enrollingId);
        public Task<List<TuitionDiscount>> GetTuitionDiscountBySchoolYearList(int schoolYearId);

        public Task<bool> CreateCashFlow(CashFlow cashFlow);
        public Task<CashFlow> GetCashFlow(string idNumber);
        public Task<List<CashFlow>> GetCashFlowList(int schoolYearId);

    }
}
