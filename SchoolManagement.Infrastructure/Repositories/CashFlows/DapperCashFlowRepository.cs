

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;
using System.Xml.Linq;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperCashFlowRepository : ICashFlowRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperCashFlowRepository(IDbConnectionFactory dbConnectionFactory) { 
        this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> AddCashFlowAsync(CashFlow cashFlow)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO CashFlows(IdNumber,Date,Amount,CashFlowTypeId,DoneBy,Note,SchoolYearId) 
                              VALUES(@idNumber,@date,@amount,@cashFlowTypeId,@doneBy,@note,@schoolYearId);";
            var result = connection.Execute(query, new
            {
                idNumber= cashFlow.IdNumber,
                date= cashFlow.Date,
                amount= cashFlow.Amount,
                cashFlowTypeId= cashFlow.CashFlowTypeId,
                doneBy= cashFlow.DoneBy,
                note= cashFlow.Note,
                schoolYearId=cashFlow.SchoolYearId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> AddTuitionDiscountAsync(TuitionDiscount discount)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO TuitionsDiscounts(Date,Amount,EnrollingId,CashFlowTypeId,OrderedBy,Reason) 
                              VALUES(@date,@amount,@enrollingId,@cashFlowTypeId,@orderedBy,@reason);";
            var result = connection.Execute(query, new
            {
                date = discount.Date,
                amount = discount.Amount,
                enrollingId= discount.EnrollingId,
                cashFlowTypeId = discount.CashFlowTypeId,
                orderedBy = discount.OrderedBy,
                reason = discount.Reason,

            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> AddTuitionPaymentAsync(TuitionPayment payment)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO TuitionsPayments(IdNumber,Date,Amount,EnrollingId,CashFlowTypeId,PaymentMeanId,Balance,DoneBy,Note,TransactionDate,TransactionId,IsDuringEnrolling) 
                              VALUES(@idNumber,@date,@amount,@enrollingId,@cashFlowTypeId,@paymentMeanId,@balance,@doneBy,@note,@transactionDate,@transactionId,@isDuringEnrolling);";
            var result = connection.Execute(query, new
            {
                idNumber= payment.IdNumber,
                date = payment.Date,
                amount = payment.Amount,
                enrollingId = payment.EnrollingId,
                cashFlowTypeId = payment.CashFlowTypeId,
                paymentMeanId=payment.PaymentMeanId,
                balance=payment.Balance,
                doneBy = payment.DoneBy,
                note = payment.Note,
                transactionDate = payment.TransactionDate,
                transactionId = payment.TransactionId,
                isDuringEnrolling=payment.IsDuringEnrolling,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<CashFlow> GetCashFlowAsync(string idNumber)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM CashFlows WHERE IdNumber=@idNumber ;";
            var result = connection.Query<CashFlow>(query, new { idNumber }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
        public async Task<CashFlow> GetLastCashFlowAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM CashFlows ORDER BY Id DESC LIMIT 1 ;";
            var result = connection.Query<CashFlow>(query).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<CashFlow>> GetCashFlowListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM CashFlows WHERE SchoolYearId=@schoolYearId ;";
            var result = connection.Query<CashFlow>(query, new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<TuitionDiscount> GetTuitionDiscountAsync(int enrollingId, int cashFlowTypeId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM TuitionsDiscounts WHERE EnrollingId=@enrollingId AND CashFlowTypeId=@cashFlowTypeId ;";
            var result = connection.Query<TuitionDiscount>(query, new { enrollingId,cashFlowTypeId }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<TuitionDiscount>> GetTuitionDiscountByEnrollingListAsync(int enrollingId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TuitionsDiscounts AS A 
                             INNER JOIN CashFlowTypes AS C ON A.CashFlowTypeId=C.Id
                             WHERE A.EnrollingId=@enrollingId;";
            var result = connection.Query<TuitionDiscount, CashFlowType, TuitionDiscount>(query,
                (discount, cashFlowType) =>
                {
                    discount.CashFlowType = cashFlowType;
                    return discount;
                }, new { enrollingId}).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<TuitionDiscount>> GetTuitionDiscountBySchoolYearListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TuitionsDiscounts AS A 
                            INNER JOIN CashFlowTypes AS C ON A.CashFlowTypeId=C.Id
                            WHERE A.EnrollingId IN (SELECT Id FROM StudentsEnrollings WHERE SchoolYearId=@schoolYearId);";
            var result = connection.Query<TuitionDiscount,CashFlowType, TuitionDiscount>(query,
                (discount, cashFlowType) =>
                {
                    discount.CashFlowType = cashFlowType;
                    return discount;
                },
                new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<TuitionPayment> GetTuitionPaymentAsync(string idNumber)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM TuitionsPayments WHERE IdNumber=@idNumber ;";
            var result = connection.Query<TuitionPayment>(query, new { idNumber}).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
        public async Task<TuitionPayment> GetLastTuitionPaymentAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM TuitionsPayments WHERE IdNumber NOT LIKE '%return' ORDER BY Id DESC LIMIT 1 ;";
            var result = connection.Query<TuitionPayment>(query).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<TuitionPayment>> GetTuitionPaymentByEnrollingListAsync(int enrollingId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TuitionsPayments  AS A  
                            INNER JOIN  CashFlowTypes AS B ON A.CashFlowTypeId=B.Id
                            INNER JOIN PaymentMeans AS C ON A.PaymentMeanId=C.Id
                            WHERE EnrollingId=@enrollingId;";                         
            var result = connection.Query < TuitionPayment,CashFlowType,PaymentMean, TuitionPayment>(query,
                (payment, cashFlowType, paymentMean) =>
                {
                    payment.CashFlowType = cashFlowType;
                    payment.PaymentMean = paymentMean;
                    return payment;
                },
                new { enrollingId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<TuitionPayment>> GetTuitionPaymentBySchoolYearListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TuitionsPayments AS A  
                            INNER JOIN  CashFlowTypes AS B ON A.CashFlowTypeId=B.Id
                            INNER JOIN PaymentMeans AS C ON A.PaymentMeanId=C.Id
                            WHERE A.EnrollingId IN (SELECT Id FROM StudentsEnrollings WHERE SchoolYearId=@schoolYearId) ;";
            var result = connection.Query<TuitionPayment, CashFlowType, PaymentMean, TuitionPayment>(query,
                (payment, cashFlowType, paymentMean) =>
                {
                    payment.CashFlowType = cashFlowType;
                    payment.PaymentMean = paymentMean;
                    return payment;
                },
                new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
       
        public async Task<bool> ValidateTuitionPaymentAsync(int paymentId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE TuitionsPayments SET IsDone=1 WHERE Id=@paymentId;";
            var result = connection.Execute(query, new {paymentId});
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateTuitionDiscountAsync(TuitionDiscount discount)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE TuitionsDiscounts SET Date=@date,Amount=@amount,OrderedBy=@orderedBy,Reason=@reason 
                              WHERE EnrollingId=@enrollingId AND CashFlowTypeId= @cashFlowTypeId  ;";
            var result = connection.Execute(query, new
            {
                date = discount.Date,
                amount = discount.Amount,                
                OrderedBy = discount.OrderedBy,
                reason = discount.Reason,
                enrollingId = discount.EnrollingId,
                cashFlowTypeId = discount.CashFlowTypeId,

            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
