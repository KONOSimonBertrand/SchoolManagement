﻿

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class CashFlowService : ICashFlowService
    {
        private readonly ICashFlowWriteRepository cashFlowWriteRepository;
        private readonly ICashFlowReadRepository cashFlowReadRepository;
        private readonly IGenerateIdNumberService generateIdNumberService;
        private readonly ISchoolYearReadRepository schoolYearReadRepository;
        public CashFlowService(ICashFlowRepository cashFlowRepository, IGenerateIdNumberService generateIdNumberService, ISchoolYearRepository schoolYearRepository)
        {
            this.cashFlowWriteRepository = cashFlowRepository;
            this.cashFlowReadRepository = cashFlowRepository;
            this.generateIdNumberService = generateIdNumberService;
            this.schoolYearReadRepository = schoolYearRepository;
        }

        public async Task<bool> CreateCashFlow (CashFlow cashFlow)
        {
            cashFlow.IdNumber = GenerateCashFlowIdNumber().Result;
            return await cashFlowWriteRepository.AddCashFlowAsync(cashFlow);
        }
        public async Task<bool> CreateCashBoxOut(CashBoxOut cashBox)
        {
            cashBox.IdNumber = GenerateCashBoxOutIdNumber().Result;
            return await cashFlowWriteRepository.AddCashBoxOutAsync(cashBox);
        }
        public async Task<bool> CreateCashBoxIn(CashBoxIn cashBox)
        {
            cashBox.IdNumber = GenerateCashBoxInIdNumber().Result;
            return await cashFlowWriteRepository.AddCashBoxInAsync(cashBox);
        }

        public async Task<bool> CreateTuitionDiscount(TuitionDiscount discount)
        {
            return await cashFlowWriteRepository.AddTuitionDiscountAsync(discount);
        }
     
        public async Task<bool> CreateTuitionPayment(TuitionPayment payment)
        {
            payment.IdNumber = GenerateTuitionPaymentIdNumber().Result;
            payment.TransactionId = payment.TransactionId.Trim() == string.Empty ? payment.IdNumber : payment.TransactionId;
            return await cashFlowWriteRepository.AddTuitionPaymentAsync(payment);
        }

        public async Task<List<CashFlow>> GetCashFlowList(int schoolYearId)
        {
            return await cashFlowReadRepository.GetCashFlowListAsync(schoolYearId);
        }

        public async Task<List<CashBoxOut>> GetCashBoxOutList(int schoolYearId)
        {
            return await cashFlowReadRepository.GetCashBoxOutListAsync(schoolYearId);
        }
        public async Task<List<CashBoxIn>> GetCashBoxInList(int schoolYearId)
        {
            return await cashFlowReadRepository.GetCashBoxInListAsync(schoolYearId);
        }
        public async Task<CashFlow> GetCashFlow(string IdNumber)
        {
            return await cashFlowReadRepository.GetCashFlowAsync(IdNumber);
        }
        public async Task<CashBoxOut> GetCashBoxOut(string IdNumber)
        {
            return await cashFlowReadRepository.GetCashBoxOutAsync(IdNumber);
        }
        public async Task<CashBoxIn> GetCashBoxIn(string IdNumber)
        {
            return await cashFlowReadRepository.GetCashBoxInAsync(IdNumber);
        }
        public async Task<TuitionDiscount> GetTuitionDiscount(int enrollingId, int cashFlowTypeId)
        {
            return await cashFlowReadRepository.GetTuitionDiscountAsync(enrollingId, cashFlowTypeId);
        }

        public async Task<List<TuitionDiscount>> GetTuitionDiscountByEnrollingList(int enrollingId)
        {
            return await cashFlowReadRepository.GetTuitionDiscountByEnrollingListAsync(enrollingId);
        }

        public async Task<List<TuitionDiscount>> GetTuitionDiscountBySchoolYearList(int schoolYearId)
        {
            return await cashFlowReadRepository.GetTuitionDiscountBySchoolYearListAsync(schoolYearId);
        }

        public async Task<TuitionPayment> GetTuitionPayment(string idNumber)
        {
            return await cashFlowReadRepository.GetTuitionPaymentAsync(idNumber);
        }

        public async Task<List<TuitionPayment>> GetTuitionPaymentByEnrollingList(int enrollingId)
        {
            return await cashFlowReadRepository.GetTuitionPaymentByEnrollingListAsync(enrollingId);
        }

        public async Task<List<TuitionPayment>> GetTuitionPaymentBySchoolYearList(int schoolYearId)
        {
            return await cashFlowReadRepository.GetTuitionPaymentBySchoolYearListAsync(schoolYearId);
        }

        public async Task<bool> ReturnTuitionPayment(TuitionPayment payment)
        {
            payment.IdNumber = payment.IdNumber + "-return";
            payment.Amount = (-1) * payment.Amount;
            return await cashFlowWriteRepository.AddTuitionPaymentAsync(payment);
        }

        public async Task<bool> ReturnCashBoxOut(CashBoxOut cashBox)
        {
            cashBox.IdNumber = cashBox.IdNumber + "-return";
            cashBox.Amount = (-1) * cashBox.Amount;
            return await cashFlowWriteRepository.AddCashBoxOutAsync(cashBox);
        }
        public async Task<bool> ReturnCashBoxIn(CashBoxIn cashBox)
        {
            cashBox.IdNumber = cashBox.IdNumber + "-return";
            cashBox.Amount = (-1) * cashBox.Amount;
            return await cashFlowWriteRepository.AddCashBoxInAsync(cashBox);
        }
        public async Task<bool> ValidateTuitionPayment(int paymentId)
        {
            return await cashFlowWriteRepository.ValidateTuitionPaymentAsync(paymentId);
        }

        public async Task<bool> ValidateCashBoxOut(int cashboxId)
        {
            return await cashFlowWriteRepository.ValidateCashBoxOutAsync(cashboxId);
        }
        public async Task<bool> ValidateCashBoxIn(int cashboxId)
        {
            return await cashFlowWriteRepository.ValidateCashBoxInAsync(cashboxId);
        }
        public async Task<string> GenerateTuitionPaymentIdNumber()
        {
            string idNumber;
            var lastPayment = cashFlowReadRepository.GetLastTuitionPaymentAsync().Result;
            SchoolYear? lastSchoolYear = await schoolYearReadRepository.GetLastSchoolYearAsync();
            int lastNumber = 0;
            int year = DateTime.Now.Year;
            if (lastPayment != null)
            {
                lastNumber = int.Parse(lastPayment.IdNumber.Substring(3, 5));
            }
            if (lastSchoolYear != null)
            {
                year = int.Parse(lastSchoolYear.Name.Substring(0, 4));
            }
            lastNumber++;
            idNumber = generateIdNumberService.GenerateNextIdNumberWithFiveDigit('V', lastNumber, year);
            await Task.Delay(0);
            return idNumber;
        }
        public async Task<string> GenerateCashFlowIdNumber()
        {
            string idNumber;
            var lastPayment = cashFlowReadRepository.GetLastCashFlowAsync().Result;
            SchoolYear? lastSchoolYear = await schoolYearReadRepository.GetLastSchoolYearAsync();
            int lastNumber = 0;
            int year = DateTime.Now.Year;
            if (lastPayment != null)
            {
                lastNumber = int.Parse(lastPayment.IdNumber.Substring(3, 5));
            }
            if (lastSchoolYear != null)
            {
                year = int.Parse(lastSchoolYear.Name.Substring(0, 4));
            }
            lastNumber++;
            idNumber = generateIdNumberService.GenerateNextIdNumberWithFiveDigit('F', lastNumber, year);
            await Task.Delay(0);
            return idNumber;
        }
        public async Task<string> GenerateCashBoxOutIdNumber()
        {
            string idNumber;
            var lastRecord = cashFlowReadRepository.GetLastCashBoxOutAsync().Result;
            SchoolYear? lastSchoolYear = await schoolYearReadRepository.GetLastSchoolYearAsync();
            int lastNumber = 0;
            int year = DateTime.Now.Year;
            if (lastRecord != null)
            {
                lastNumber = int.Parse(lastRecord.IdNumber.Substring(3, 5));
            }
            if (lastSchoolYear != null)
            {
                year = int.Parse(lastSchoolYear.Name.Substring(0, 4));
            }
            lastNumber++;
            idNumber = generateIdNumberService.GenerateNextIdNumberWithFiveDigit('S', lastNumber, year);
            await Task.Delay(0);
            return idNumber;
        }
        public async Task<string> GenerateCashBoxInIdNumber()
        {
            string idNumber;
            var lastRecord = cashFlowReadRepository.GetLastCashBoxInAsync().Result;
            SchoolYear? lastSchoolYear = await schoolYearReadRepository.GetLastSchoolYearAsync();
            int lastNumber = 0;
            int year = DateTime.Now.Year;
            if (lastRecord != null)
            {
                lastNumber = int.Parse(lastRecord.IdNumber.Substring(3, 5));
            }
            if (lastSchoolYear != null)
            {
                year = int.Parse(lastSchoolYear.Name.Substring(0, 4));
            }
            lastNumber++;
            idNumber = generateIdNumberService.GenerateNextIdNumberWithFiveDigit('E', lastNumber, year);
            await Task.Delay(0);
            return idNumber;
        }
        public async Task<bool> UpdateTuitionDiscount(TuitionDiscount discount)
        {
            return await cashFlowWriteRepository.UpdateTuitionDiscountAsync(discount);
        }
    }
}
