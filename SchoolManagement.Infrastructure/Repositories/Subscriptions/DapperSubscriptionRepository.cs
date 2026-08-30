

using Dapper;
using Microsoft.Extensions.Logging;
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
            string query = @"INSERT INTO Subscriptions(IdNumber,StartDate,Amount,DoneBy,EndDate,CashFlowTypeId,PaymentMeanId,TransactionId,TransactionDate,EnrollingId,ReceiptId)  
                                          VALUES(@idNumber,@startDate,@amount,@doneBy,@endDate,@cashFlowTypeId,@paymentMeanId,@transactionId,@transactionDate,@enrollingId,@receiptId);";
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
                    enrollingId = subscription.EnrollingId,
                    receiptId = subscription.ReceiptId,
                });

                logger.LogInformation("Ajout de l'abonnement {subscriptionId} dans la base de donnée", subscription.IdNumber);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Une erreur s'est produite lors de l'ajout d'un abonnement {subscriptionId}  en base", subscription.IdNumber);
            }
            return result > 0;
        }

        public async Task<List<Subscription>> GetSubscriptionListByEnrollingAsync(int enrollingId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN PaymentMeans B ON A.PaymentMeanId=B.Id 
                             INNER JOIN CashFlowTypes C ON A.CashFlowTypeId=C.Id 
                             INNER JOIN Receipts D ON A.ReceiptId=D.Id
                             WHERE A.EnrollingId=@enrollingId  ORDER BY A.Id DESC;";
            List<Subscription> result = new();
            try
            {
                result= connection.Query<Subscription, PaymentMean, CashFlowType, Receipt, Subscription>(
                 query, (subscription, paymentMean, cashFlowType, receipt) =>
                 {
                     subscription.PaymentMean = paymentMean;
                     subscription.CashFlowType = cashFlowType;
                     subscription.Receipt = receipt;
                     return subscription;
                 }, new { enrollingId}).ToList();
            
                logger.LogInformation("Récupération des abonnements de l'élève avec numéro d'inscription {enrollingId}  dans la base de donnée.", enrollingId);
            }
            catch (Exception ex) { 
                logger.LogError(ex, "Une erreur est survenue lors de la récupération des abonnements de l'élève  avec numéro d'inscription{enrollingId} dans la base de donnée.", enrollingId);
            }
            await Task.Delay(0);
            return result;
        }

        public async Task<List<Subscription>> GetSubscriptionListBySchoolYearAsync(int schoolyearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN StudentsEnrollings B ON A.EnrollingId=B.Id 
                             INNER JOIN Students C ON B.StudentId=C.Id
                             INNER JOIN PaymentMeans D ON A.PaymentMeanId=D.Id 
                             INNER JOIN CashFlowTypes E ON A.CashFlowTypeId=E.Id 
                             INNER JOIN Receipts F ON A.ReceiptId=F.Id
                             
                             WHERE B.SchoolyearId=@schoolyearId ORDER BY A.Id DESC ;";
            List<Subscription> result= new();
            try
            {
                result = (await connection.QueryAsync<Subscription, StudentEnrolling, Student, PaymentMean, CashFlowType, Receipt, Subscription>(
                query, (subscription, enrolling, student, paymentMean, cashFlowType, receipt) =>
                {
                    subscription.Enrolling = enrolling;
                    subscription.Enrolling.Student = student;
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
                    subscription.Receipt = receipt;
                    return subscription;
                }, new { schoolyearId })).ToList();
                logger.LogInformation("Récupération de la liste des abonnements de l'année scolaire {yearId} dans la base de donnée.", schoolyearId);;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Une erreur est survenue lors de la récupération de la liste des abonnements de l'année scolaire {yearId}", schoolyearId);
            }
            return result;
        }

        public async Task<Subscription?> GetSubscriptionAsync(int enrollingId, int cashFlowTypeId, DateTime dateSubscription)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subscriptions A
                             INNER JOIN PaymentMeans B ON A.PaymentMeanId=B.Id 
                             INNER JOIN CashFlowTypes C ON A.CashFlowTypeId=C.Id 
                             INNER JOIN Receipts D ON A.ReceiptId=D.Id  AND A.CashFlowTypeId=@cashFlowTypeId AND 
                             WHERE  A.EnrollingId=@enrollingId 
                             DATE(StartDate)=@dateSubscription ;";
            var result = connection.Query<Subscription, PaymentMean, CashFlowType, Receipt, Subscription>(
                query, (subscription, paymentMean, cashFlowType, receipt) =>
                {
                    subscription.PaymentMean = paymentMean;
                    subscription.CashFlowType = cashFlowType;
                    subscription.Receipt = receipt;
                    return subscription;
                }, new { enrollingId, cashFlowTypeId, dateSubscription=dateSubscription.Date }).FirstOrDefault();
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
            Subscription? result = null;
            try
            {
                result = (await connection.QueryAsync<Subscription, PaymentMean, CashFlowType, Receipt, Subscription>(
                    query, (subscription, paymentMean, cashFlowType, receipt) =>
                    {
                        subscription.PaymentMean = paymentMean;
                        subscription.CashFlowType = cashFlowType;
                        subscription.Receipt = receipt;
                        return subscription;
                    }, new { idNumber })).FirstOrDefault();
                logger.LogInformation("Récupération de l'abonnement avec le numéro d'identification {idNumber} de la base de donnée.", idNumber);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la récupération de l'abonnement avec le numéro d'identification {idNumber} de la base de donnée.", idNumber);
            }
            return result;
        }
        public async Task<Subscription?> GetLastSubscriptionAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM Subscriptions ORDER BY Id DESC LIMIT 1 ;";
            Subscription? result = null;
            try
            {
                result = connection.Query<Subscription>(query).FirstOrDefault();
                logger.LogInformation("Récupération du dernier abonnement de la base de donnée.");
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"Une erreur est survenu lors de la récupération du dernier abonnement dans la base de donnée.");
            }
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
                logger.LogInformation("Validation de l'abonnement {subscriptionId} dans la base de donnée", subscriptionId);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Une erreur s'est produite lors de la validation de l'abonnement {subscriptionId} dans la base de donnée.", subscriptionId);
            }
            return result > 0;
        }
    }
}
