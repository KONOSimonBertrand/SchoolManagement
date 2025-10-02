

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperTuitionOrderRepository : ITuitionOrderRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperTuitionOrderRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<TuitionOrder?> GetTuitionOrderAsync(string idNumber)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TuitionOrders  AS A
                               INNER JOIN StudentsEnrollings AS C ON A.EnrollingId=C.Id
                               INNER JOIN PaymentMeans AS B ON A.PaymentMeanId=B.Id
                               WHERE IdNumber=@idNumber ;";
            var result = connection.Query<TuitionOrder, StudentEnrolling, PaymentMean, TuitionOrder>(query,
                (order, enrolling, paymentMean) =>
                {
                    order.Enrolling = enrolling;
                    order.PaymentMean = paymentMean;
                    return order;
                },
                new { idNumber }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<TuitionOrder>> GetTuitionOrdersByEnrollingAsync(int enrollingId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TuitionOrders  AS A
                               INNER JOIN StudentsEnrollings AS C ON A.EnrollingId=C.Id
                               INNER JOIN PaymentMeans AS B ON A.PaymentMeanId=B.Id
                               WHERE EnrollingId=@enrollingId  ORDER BY A.Id DESC;";
            var result = connection.Query<TuitionOrder, StudentEnrolling, PaymentMean, TuitionOrder>(query,
                (order, enrolling, paymentMean) =>
                {
                    order.Enrolling = enrolling;
                    order.PaymentMean = paymentMean;
                    return order;
                },
                new { enrollingId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<TuitionOrder>> GetTuitionOrdersBySchoolYearAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TuitionOrders  AS A
                               INNER JOIN StudentsEnrollings AS C ON A.EnrollingId=C.Id
                               INNER JOIN PaymentMeans AS B ON A.PaymentMeanId=B.Id
                               WHERE WHERE C.SchoolYearId =@schoolYearId  ORDER BY A.Id DESC ;";
            var result = connection.Query<TuitionOrder, StudentEnrolling, PaymentMean, TuitionOrder>(query,
                (order, enrolling, paymentMean) =>
                {
                    order.Enrolling = enrolling;
                    order.PaymentMean = paymentMean;
                    return order;
                },
                new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> SaveTuitionOrderAsync(TuitionOrder order)
        {
            var connection = dbConnectionFactory.CreateConnection();
          
            string query = @"INSERT INTO TuitionOrders(IdNumber,Date,Amount,Discount,Balance,TransactionDate,TransactionId,PaymentMeanId,Note,DoneBy,EnrollingId) 
                              VALUES(@idNumber,@date,@amount,@discount,@balance,@transactionDate,@transactionId,@paymentMeanId,@note,@doneBy,@enrollingId);";
            var result = connection.Execute(query, new
            {
                idNumber = order.IdNumber,
                date = order.Date,
                amount = order.Amount,
                discount= order.Discount,
                balance = order.Balance,
                transactionDate = order.TransactionDate,
                transactionId = order.TransactionId,
                paymentMeanId = order.PaymentMeanId,
                note = order.Note,
                doneBy = order.DoneBy,
                enrollingId = order.EnrollingId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public Task<bool> SaveTuitionOrderItemAsync(TuitionOrderItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveTuitionOrderItemsAsync(List<TuitionOrderItem> items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
