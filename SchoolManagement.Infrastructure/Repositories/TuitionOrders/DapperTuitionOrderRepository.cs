

using Dapper;
using Microsoft.Extensions.Logging;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperTuitionOrderRepository : ITuitionOrderRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        private readonly ILogger<DapperTuitionOrderRepository> logger;
        public DapperTuitionOrderRepository(IDbConnectionFactory dbConnectionFactory,ILogger<DapperTuitionOrderRepository> logger)
        {
            this.dbConnectionFactory = dbConnectionFactory;
            this.logger = logger;
        }

        public async Task<TuitionOrder?> GetLastTuitionOrderAsync()
        {
            string query = "SELECT * FROM TuitionOrders WHERE IdNumber NOT LIKE '%return' ORDER BY Id DESC LIMIT 1 ;";
            var result = new TuitionOrder() { 
             IdNumber=string.Empty,
             TuitionOrderItems = new List<TuitionOrderItem>()
            };
            try
            {
                var connection = dbConnectionFactory.CreateConnection();
                result = connection.Query<TuitionOrder>(query).FirstOrDefault();
            }
            catch (Exception ex) {
                logger.LogError(ex, "Erreur d'extraction du dernier versement");
            }
            
            await Task.Delay(0);
            return result;
        }

        public async Task<TuitionOrder?> GetTuitionOrderAsync(string idNumber)
        {
            TuitionOrder? result;
            string query = @"SELECT * FROM TuitionOrders  AS A
                               INNER JOIN StudentsEnrollings AS C ON A.EnrollingId=C.Id
                               INNER JOIN PaymentMeans AS B ON A.PaymentMeanId=B.Id
                               WHERE IdNumber=@idNumber ;";
            try
            {
                var connection = dbConnectionFactory.CreateConnection();
                result = connection.Query<TuitionOrder, StudentEnrolling, PaymentMean, TuitionOrder>(query,
                    (order, enrolling, paymentMean) =>
                    {
                        order.Enrolling = enrolling;
                        order.PaymentMean = paymentMean;
                        return order;
                    },
                    new { idNumber }).FirstOrDefault();
            }
            catch (Exception ex) {

                logger.LogError(ex, "Erreur d'extraction des versements");
                return null;
            }
           
            await Task.Delay(0);
            return result;
        }

        public async Task<List<TuitionOrderItem>> GetTuitionOrderItemsAsync(int orderId)
        {
            var result = new List<TuitionOrderItem>();
            string query = @"SELECT * FROM TuitionOrderItems  AS A
                               INNER JOIN TuitionOrders AS C ON A.TuitionOrderId=C.Id
                               INNER JOIN CashFlowTypes AS D ON A.CashFlowTypeId=D.Id
                               WHERE A.TuitionOrderId=@orderId  ORDER BY A.Id DESC ;";
            try
            {
                var connection = dbConnectionFactory.CreateConnection();
                result = connection.Query<TuitionOrderItem, TuitionOrder, CashFlowType, TuitionOrderItem>(query,
                (orderItem, order, cashFlowType) =>
                {
                    orderItem.TuitionOrder = order;
                    orderItem.CashFlowType = cashFlowType;
                    return orderItem;
                },
                new { orderId }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Erreur d'extraction des versements relatifs au frais scolaires pour la transaction{orderId}");
                return result;
            }
            await Task.Delay(0);
            return result;
        }

        public async Task<List<TuitionOrderItem>> GetTuitionOrderItemsAsync(string orderIdNumber)
        {
           
            var result = new List<TuitionOrderItem>();
            string query = @"SELECT * FROM TuitionOrderItems  AS A
                               INNER JOIN TuitionOrders AS C ON A.TuitionOrderId=C.Id
                               INNER JOIN CashFlowTypes AS D ON A.CashFlowTypeId=D.Id
                               WHERE C.IdNumber=@orderIdNumber  ORDER BY A.Id DESC ;";
            try
            {
                var connection = dbConnectionFactory.CreateConnection();
                result = connection.Query<TuitionOrderItem, TuitionOrder,CashFlowType, TuitionOrderItem>(query,
                (orderItem, order, cashFlowType) =>
                {
                    orderItem.TuitionOrder = order;
                    orderItem.CashFlowType = cashFlowType;
                    return orderItem;
                },
                new { orderIdNumber }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Erreur d'extraction des versements relatifs au frais scolaires pour la transaction{orderIdNumber}");
            }
            await Task.Delay(0);
            return result;
        }

        public async Task<List<TuitionOrder>> GetTuitionOrdersByEnrollingAsync(int enrollingId)
        {
            var result= new List<TuitionOrder>();
            string query = @"SELECT * FROM TuitionOrders  AS A
                               INNER JOIN StudentsEnrollings AS C ON A.EnrollingId=C.Id
                               INNER JOIN PaymentMeans AS B ON A.PaymentMeanId=B.Id
                               WHERE EnrollingId=@enrollingId  ORDER BY A.Id DESC;";
            try
            {
                var connection = dbConnectionFactory.CreateConnection();
                result = connection.Query<TuitionOrder, StudentEnrolling, PaymentMean, TuitionOrder>(query,
                                (order, enrolling, paymentMean) =>
                                {
                                    order.Enrolling = enrolling;
                                    order.PaymentMean = paymentMean;
                                    return order;
                                },
                                new { enrollingId }).ToList();
            }
            catch (Exception ex) {
                logger.LogError(ex, "Erreur d'extraction des versements");
            }
            
            await Task.Delay(0);
            return result;
        }

        public async Task<List<TuitionOrder>> GetTuitionOrdersBySchoolYearAsync(int schoolYearId)
        {
          
            var result = new List<TuitionOrder>();
            string query = @"SELECT * FROM TuitionOrders  AS A
                               INNER JOIN StudentsEnrollings AS C ON A.EnrollingId=C.Id
                               INNER JOIN PaymentMeans AS B ON A.PaymentMeanId=B.Id
                               WHERE C.SchoolYearId=@schoolYearId  ORDER BY A.Id DESC ;";        
            try
            {
                var connection = dbConnectionFactory.CreateConnection();
                result = connection.Query<TuitionOrder, StudentEnrolling, PaymentMean, TuitionOrder>(query,
                (order, enrolling, paymentMean) =>
                {
                    order.Enrolling = enrolling;
                    order.PaymentMean = paymentMean;
                    return order;
                },
                new { schoolYearId }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur d'extraction des versements");
            }
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> SaveTuitionOrderAsync(TuitionOrder order)
        {
          bool isDone=false;
            string query = @"INSERT INTO TuitionOrders(IdNumber,Date,Amount,Discount,Balance,TransactionDate,TransactionId,PaymentMeanId,Note,DoneBy,EnrollingId,IsDuringEnrolling) 
                              VALUES(@idNumber,@date,@amount,@discount,@balance,@transactionDate,@transactionId,@paymentMeanId,@note,@doneBy,@enrollingId,@isDuringEnrolling);";
            try
            {
                var connection = dbConnectionFactory.CreateConnection();
                var result = connection.Execute(query, new
                {
                    idNumber = order.IdNumber,
                    date = order.Date,
                    amount = order.Amount,
                    discount = order.Discount,
                    balance = order.Balance,
                    transactionDate = order.TransactionDate,
                    transactionId = order.TransactionId,
                    paymentMeanId = order.PaymentMeanId,
                    note = order.Note,
                    doneBy = order.DoneBy,
                    enrollingId = order.EnrollingId,
                    isDuringEnrolling = order.IsDuringEnrolling
                });
                isDone = result > 0;
                var orderSaved = await GetTuitionOrderAsync(order.IdNumber);
                if (orderSaved != null && order.TuitionOrderItems.Any())
                {
                    string sql = "INSERT INTO TuitionOrderItems(Amount,Balance,Discount,CashFlowTypeId,TuitionOrderId) VALUES(@Amount,@Balance,@Discount,@CashFlowTypeId,@TuitionOrderId)";
                    foreach (var item in order.TuitionOrderItems)
                    {
                        item.TuitionOrder = orderSaved;
                        item.TuitionOrderId = orderSaved.Id;
                    }
                    connection.Execute(sql, order.TuitionOrderItems);
                }
            }
            catch (Exception ex) { 
            
            }
            await Task.Delay(0);
            return isDone;
        }

        public Task<bool> ValidateAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
