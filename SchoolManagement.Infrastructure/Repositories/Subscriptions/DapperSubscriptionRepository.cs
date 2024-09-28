

using Dapper;
using SchoolManagement.Core.Model;
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
            string query = @"INSERT INTO Subscriptions(Date,Amount,Discount,DoneBy,EndDate,CashFlowTypeId,PaymentMeanId,TransactionId,TransactionDate,EnrollingId)  
                                          VALUES(@date,@amount,@discount,@doneBy,@endDate,@cashFlowTypeId,@paymentMeanId,@transactionId,@transactionDate,@enrollingId);";
            var result = connection.Execute(query, new
            {
                date = subscription.Date,
                amount = subscription.Amount,
                discount = subscription.Discount,
                doneBy = subscription.DoneBy,
                endDate = subscription.EndDate,
                cashFlowTypeId = subscription.CashFlowTypeId,
                paymentMeanId = subscription.PaymentMeanId,
                transactionId = subscription.TransactionId,
                transactionDate = subscription.TransactionDate,
                enrollingId = subscription.EnrollingId,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> CancelSubscriptionAsync(int subscriptionId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Subscriptions SET IsCancel=1 WHERE id=@subscriptionId ;";
            var result = connection.Execute(query, new{ subscriptionId });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<List<Subscription>> GetSubscriptionListByEnrollingAsync(int enrollingId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN PaymentMeans B ON A.PaymentMeanId=B.Id 
                             INNER JOIN CashFlowTypes C ON A.CashFlowTypeId=C.Id 
                             WHERE A.EnrollingId=@enrollingId ;";
            var result = connection.Query<Subscription, PaymentMean, CashFlowType, Subscription>(
                query, (subscription, paymentMean,  cashFlowType) =>
                {
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
                    return subscription;
                }, new { enrollingId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<Subscription>> GetSubscriptionListBySchoolYearAsync(int schoolyearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN StudentEnrolling B ON A.EnrollingId=B.Id 
                             INNER JOIN PaymentMeans C ON A.PaymentMeanId=C.Id 
                             INNER JOIN CashFlowTypes D ON A.CashFlowTypeId=D.Id 
                             WHERE B.SchoolyearId=@schoolyearId ;";
            var result = connection.Query<Subscription, StudentEnrolling, PaymentMean, CashFlowType, Subscription>(
                query, (subscription, enrolling, paymentMean, cashFlowType) =>
                {
                    subscription.Enrolling = enrolling;
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
                    return subscription;
                }, new { schoolyearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<Subscription?> GetSubscriptionAsync(int enrollingId, int cashFlowTypeId, DateTime dateSubscription)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN PaymentMeans B ON A.PaymentMeanId=B.Id 
                             INNER JOIN CashFlowTypes C ON A.CashFlowTypeId=C.Id 
                             WHERE A.EnrollingId=@enrollingId AND A.CashFlowTypeId=@cashFlowTypeId AND DATE(Date)=@dateSubscriptionx ;";
            var result = connection.Query<Subscription, PaymentMean, CashFlowType, Subscription>(
                query, (subscription, paymentMean, cashFlowType) =>
                {
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
                    return subscription;
                }, new { enrollingId, cashFlowTypeId, dateSubscriptionx=dateSubscription.Date }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateSubscriptionAsync(Subscription subscription)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Subscriptions SET Date=@date,Discount=@discount,DoneBy=@doneBy,EndDate=@endDate,
                             PaymentMeanId=@paymentMeanId,TransactionId=@transactionId,TransactionDate=@transactionDate 
                             WHERE id=@id;";
            var result = connection.Execute(query, new
            {
                date = subscription.Date,
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
    }
}
