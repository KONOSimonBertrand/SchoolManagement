

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSchoolSupplieRepository : ISchoolSupplieRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperSchoolSupplieRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddSchoolSupplieAsync(SchoolSupplie schoolSupplie)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO SchoolSupplies(IdNumber,Date,Amount,EnrollingId,CashFlowTypeId,PaymentMeanId,Balance,DoneBy,Note,TransactionDate,TransactionId,IsDuringEnrolling) 
                              VALUES(@idNumber,@date,@amount,@enrollingId,@cashFlowTypeId,@paymentMeanId,@balance,@doneBy,@note,@transactionDate,@transactionId,@isDuringEnrolling);";
            var result = connection.Execute(query, new
            {
                idNumber = schoolSupplie.IdNumber,
                date = schoolSupplie.Date,
                amount = schoolSupplie.Amount,
                quantity = schoolSupplie.Quantity,
                enrollingId = schoolSupplie.EnrollingId,
                cashFlowTypeId = schoolSupplie.CashFlowTypeId,
                paymentMeanId = schoolSupplie.PaymentMeanId,
                balance = schoolSupplie.Balance,
                doneBy = schoolSupplie.DoneBy,
                transactionDate = schoolSupplie.TransactionDate,
                transactionId = schoolSupplie.TransactionId,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SchoolSupplie?> GetLastSchoolSupplieAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM SchoolSupplies WHERE IdNumber NOT LIKE '%return' ORDER BY Id DESC LIMIT 1 ;";
            var result = connection.Query<SchoolSupplie>(query).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<SchoolSupplie?> GetSchoolSupplieAsync(string idNumber)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplies  AS A
                               INNER JOIN CashFlowTypes AS C ON A.CashFlowTypeId=C.Id
                               INNER JOIN PaymentMeans AS B ON A.PaymentMeanId=B.Id
                               WHERE IdNumber=@idNumber ;";
            var result = connection.Query<SchoolSupplie, CashFlowType, PaymentMean, SchoolSupplie>(query,
                (schoolSupplie, cashFlowType, paymentMean) =>
                {
                    schoolSupplie.CashFlowType = cashFlowType;
                    schoolSupplie.PaymentMean = paymentMean;
                    return schoolSupplie;
                },
                new { idNumber }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<SchoolSupplie>> GetSchoolSupplieByEnrollingListAsync(int enrollingId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplies  AS A  
                            INNER JOIN  CashFlowTypes AS B ON A.CashFlowTypeId=B.Id
                            INNER JOIN PaymentMeans AS C ON A.PaymentMeanId=C.Id
                            WHERE EnrollingId=@enrollingId   ORDER BY A.Id DESC ;";
            var result = connection.Query<SchoolSupplie, CashFlowType, PaymentMean, SchoolSupplie>(query,
                (schoolSupplie, cashFlowType, paymentMean) =>
                {
                    schoolSupplie.CashFlowType = cashFlowType;
                    schoolSupplie.PaymentMean = paymentMean;
                    return schoolSupplie;
                },
                new { enrollingId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<SchoolSupplie>> GetSchoolSupplieBySchoolYearListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplies AS A  
                            INNER JOIN  CashFlowTypes AS B ON A.CashFlowTypeId=B.Id
                            INNER JOIN PaymentMeans AS C ON A.PaymentMeanId=C.Id
                            WHERE A.EnrollingId IN (SELECT Id FROM StudentsEnrollings WHERE SchoolYearId=@schoolYearId) 
                             ORDER BY A.Id DESC ;";
            var result = connection.Query<SchoolSupplie, CashFlowType, PaymentMean, SchoolSupplie>(query,
                (schoolSupplie, cashFlowType, paymentMean) =>
                {
                    schoolSupplie.CashFlowType = cashFlowType;
                    schoolSupplie.PaymentMean = paymentMean;
                    return schoolSupplie;
                },
                new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> ValidateSchoolSupplieAsync(int schoolSupplieId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE SchoolSupplies SET IsValidated=1 WHERE Id=@paymentId AND IsValidated=0;";
            var result = connection.Execute(query, new { schoolSupplieId });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
