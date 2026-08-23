

using Dapper;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSubscriptionRepository : ISubscriptionRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        private readonly ILogger<DapperSubscriptionRepository> logger;
        public DapperSubscriptionRepository(IDbConnectionFactory dbConnectionFactory, ILogger<DapperSubscriptionRepository> logger)
        {
            this.dbConnectionFactory = dbConnectionFactory;
            this.logger = logger;
        }
        public async Task<bool> AddSubscriptionAsync(Subscription subscription)
        {
            var connection = dbConnectionFactory.CreateConnection();
            int result = 0;
            string query = @"INSERT INTO Subscriptions(IdNumber,StartDate,Amount,DoneBy,EndDate,CashFlowTypeId,PaymentMeanId,TransactionId,TransactionDate,StudentId,SchoolYearId,ReceiptId)  
                                          VALUES(@idNumber,@startDate,@amount,@doneBy,@endDate,@cashFlowTypeId,@paymentMeanId,@transactionId,@transactionDate,@studentId,@schoolYearId,@receiptId);";
            try
            {
                result = await connection.ExecuteAsync(query, new
                {
                    idNumber = subscription.IdNumber,
                    startDate = subscription.StartDate,
                    amount = subscription.Amount,
                    doneBy = subscription.DoneBy,
                    endDate = subscription.EndDate,
                    cashFlowTypeId = subscription.CashFlowTypeId,
                    paymentMeanId = subscription.PaymentMeanId,
                    transactionId = subscription.TransactionId,
                    transactionDate = subscription.TransactionDate,
                    studentId = subscription.StudentId,
                    schoolYearId = subscription.SchoolYearId,
                    receiptId = subscription.ReceiptId,
                });
            }
            catch (Exception ex) {
                logger.LogError(ex, "Une erreur s'est produite lors de l'ajout d'un abonnement en base");
            }
            return result > 0;
        }

        public async Task<List<Subscription>> GetSubscriptionListAsync(int studentId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN PaymentMeans B ON A.PaymentMeanId=B.Id 
                             INNER JOIN CashFlowTypes C ON A.CashFlowTypeId=C.Id 
                             INNER JOIN Receipts D ON A.ReceiptId=D.Id
                             WHERE A.StudentId=@studentId  AND A.SchoolYearId=@schoolYearId ORDER BY A.Id DESC;";
            var result = connection.Query<Subscription, PaymentMean, CashFlowType, Receipt, Subscription>(
                query, (subscription, paymentMean,  cashFlowType, receipt) =>
                {
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
                    subscription.Receipt = receipt;
                    return subscription;
                }, new { studentId,schoolYearId}).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<Subscription>> GetSubscriptionListAsync(int schoolyearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN Students B ON A.StudentId=B.Id 
                             INNER JOIN PaymentMeans C ON A.PaymentMeanId=C.Id 
                             INNER JOIN CashFlowTypes D ON A.CashFlowTypeId=D.Id 
                             INNER JOIN Receipts E ON A.ReceiptId=E.Id
                             WHERE A.SchoolyearId=@schoolyearId ORDER BY A.Id DESC ;";
            var result = connection.Query<Subscription, Student, PaymentMean, CashFlowType, Receipt, Subscription>(
                query, (subscription, student, paymentMean, cashFlowType, receipt) =>
                {
                    subscription.Student = student;
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
                    subscription.Receipt = receipt;
                    return subscription;
                }, new { schoolyearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<Subscription?> GetSubscriptionAsync(int studentId,int schoolYearId, int cashFlowTypeId, DateTime dateSubscription)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN PaymentMeans B ON A.PaymentMeanId=B.Id 
                             INNER JOIN CashFlowTypes C ON A.CashFlowTypeId=C.Id 
                             INNER JOIN Receipts D ON A.ReceiptId=D.Id
                             WHERE  A.StudentId=@studentId AND A.SchoolYearId=@schoolYearId
                             AND A.CashFlowTypeId=@cashFlowTypeId AND DATE(StartDate)=@dateSubscriptionx ;";
            var result = connection.Query<Subscription, PaymentMean, CashFlowType, Receipt, Subscription>(
                query, (subscription, paymentMean, cashFlowType, receipt) =>
                {
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
                    subscription.Receipt = receipt;
                    return subscription;
                }, new { studentId,schoolYearId, cashFlowTypeId, dateSubscriptionx=dateSubscription.Date }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
        public async Task<Subscription?> GetSubscriptionAsync(string idNumber)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN PaymentMeans B ON A.PaymentMeanId=B.Id 
                             INNER JOIN CashFlowTypes C ON A.CashFlowTypeId=C.Id 
                             INNER JOIN Receipts D ON A.ReceiptId=D.Id
                             WHERE A.IdNumber=@idNumber  ;";
            var result = connection.Query<Subscription, PaymentMean, CashFlowType, Receipt, Subscription>(
                query, (subscription, paymentMean, cashFlowType, receipt) =>
                {
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
                    subscription.Receipt = receipt;
                    return subscription;
                }, new { idNumber }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
        public async Task<Subscription?> GetLastSubscriptionAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM Subscriptions ORDER BY Id DESC LIMIT 1 ;";
            var result = connection.Query<Subscription>(query).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
        public async Task<bool> ValidateSubscriptionAsync(int subscriptionId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Subscriptions SET IsValidated=1 WHERE Id=@subscriptionId AND IsValidated=0;";
            int result = 0;
            try
            {
                result = await connection.ExecuteAsync(query, new { subscriptionId });
            }
            catch (Exception ex) {
                logger.LogError(ex, "Une erreur s'est produite lors de la validation de l'abonnement {subscriptionId}.", subscriptionId);
            }
            return result > 0;
        }
    }
}
