

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSubscriptionRepository : ISubscriptionRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperSubscriptionRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> AddSubscriptionAsync(Subscription subscription)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO Subscriptions(IdNumber,StartDate,Amount,Discount,DoneBy,EndDate,CashFlowTypeId,PaymentMeanId,TransactionId,TransactionDate,StudentId,SchoolYearId)  
                                          VALUES(@idNumber,@startDate,@amount,@discount,@doneBy,@endDate,@cashFlowTypeId,@paymentMeanId,@transactionId,@transactionDate,@studentId,@schoolYearId);";
            var result = connection.Execute(query, new
            {
                idNumber= subscription.IdNumber,
                startDate = subscription.StartDate,
                amount = subscription.Amount,
                discount = subscription.Discount,
                doneBy = subscription.DoneBy,
                endDate = subscription.EndDate,
                cashFlowTypeId = subscription.CashFlowTypeId,
                paymentMeanId = subscription.PaymentMeanId,
                transactionId = subscription.TransactionId,
                transactionDate = subscription.TransactionDate,
                studentId = subscription.StudentId,
                schoolYearId= subscription.SchoolYearId,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<List<Subscription>> GetSubscriptionListAsync(int studentId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN PaymentMeans B ON A.PaymentMeanId=B.Id 
                             INNER JOIN CashFlowTypes C ON A.CashFlowTypeId=C.Id 
                             WHERE A.StudentId=@studentId  AND A.SchoolYearId=@schoolYearId ORDER BY A.Id DESC;";
            var result = connection.Query<Subscription, PaymentMean, CashFlowType, Subscription>(
                query, (subscription, paymentMean,  cashFlowType) =>
                {
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
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
                             WHERE A.SchoolyearId=@schoolyearId ORDER BY A.Id DESC ;";
            var result = connection.Query<Subscription, Student, PaymentMean, CashFlowType, Subscription>(
                query, (subscription, student, paymentMean, cashFlowType) =>
                {
                    subscription.Student = student;
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
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
                             WHERE  A.StudentId=@studentId AND A.SchoolYearId=@schoolYearId
                             AND A.CashFlowTypeId=@cashFlowTypeId AND DATE(StartDate)=@dateSubscriptionx ;";
            var result = connection.Query<Subscription, PaymentMean, CashFlowType, Subscription>(
                query, (subscription, paymentMean, cashFlowType) =>
                {
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
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
                             WHERE A.IdNumber=@idNumber  ;";
            var result = connection.Query<Subscription, PaymentMean, CashFlowType, Subscription>(
                query, (subscription, paymentMean, cashFlowType) =>
                {
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
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

        public async Task<bool> UpdateSubscriptionAsync(Subscription subscription)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Subscriptions SET StartDate=@startDate,Discount=@discount,DoneBy=@doneBy,EndDate=@endDate,
                             PaymentMeanId=@paymentMeanId,TransactionId=@transactionId,TransactionDate=@transactionDate 
                             WHERE id=@id;";
            var result = connection.Execute(query, new
            {
                startDate = subscription.StartDate,
                discount = subscription.Discount,
                doneBy = subscription.DoneBy,
                endDate = subscription.EndDate,
                paymentMeanId = subscription.PaymentMeanId,
                transactionId = subscription.TransactionId,
                transactionDate = subscription.TransactionDate,
                id = subscription.Id,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> ValidateSubscriptionAsync(int subscriptionId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Subscriptions SET IsValidated=1 WHERE Id=@subscriptionId AND IsValidated=0;";
            var result = connection.Execute(query, new { subscriptionId });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
