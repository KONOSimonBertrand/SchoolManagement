

using Dapper;
using Microsoft.Extensions.Logging;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSchoolSupplieRepository : ISchoolSupplieRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        private readonly ILogger<DapperSchoolSupplieRepository> logger;
        public DapperSchoolSupplieRepository(IDbConnectionFactory dbConnectionFactory, ILogger<DapperSchoolSupplieRepository> logger)
        {
            this.dbConnectionFactory = dbConnectionFactory;
            this.logger = logger;
        }

        public async Task<bool> AddSchoolSupplieAsync(SchoolSupplie schoolSupplie)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO SchoolSupplies(IdNumber,Date,Amount,Quantity,EnrollingId,CashFlowTypeId,PaymentMeanId,Balance,DoneBy,TransactionDate,TransactionId,ReceiptId) 
                              VALUES(@idNumber,@date,@amount,@quantity,@enrollingId,@cashFlowTypeId,@paymentMeanId,@balance,@doneBy,@transactionDate,@transactionId,@receiptId);";
            int result = 0;
            try
            {
                result = await connection.ExecuteAsync(query, new
                {
                    idNumber = schoolSupplie.IdNumber,
                    date = schoolSupplie.Date,
                    amount = schoolSupplie.Amount,
                    quantity=schoolSupplie.Quantity,
                    enrollingId = schoolSupplie.EnrollingId,
                    cashFlowTypeId = schoolSupplie.CashFlowTypeId,
                    paymentMeanId = schoolSupplie.PaymentMeanId,
                    balance = schoolSupplie.Balance,
                    doneBy = schoolSupplie.DoneBy,
                    transactionDate = schoolSupplie.TransactionDate,
                    transactionId = schoolSupplie.TransactionId,
                    receiptId = schoolSupplie.ReceiptId
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de l'ajout de la fourniture scolaire {item}  de l'élève {student}", schoolSupplie?.CashFlowType?.Name, schoolSupplie?.Enrolling?.Student?.FullName);
            }
            return result > 0;
        }

        public async Task<SchoolSupplie?> GetLastSchoolSupplieAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM SchoolSupplies WHERE IdNumber NOT LIKE '%return' ORDER BY Id DESC LIMIT 1 ;";
            SchoolSupplie? result = null;
            try
            {
                result = await connection.QueryFirstOrDefaultAsync<SchoolSupplie>(query);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la récupération de la dernière fourniture scolaire.");
            }
            await Task.Delay(0);
            return result;
        }

        public async Task<SchoolSupplie?> GetSchoolSupplieAsync(string idNumber)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplies  AS A
                               INNER JOIN CashFlowTypes AS C ON A.CashFlowTypeId=C.Id
                               INNER JOIN PaymentMeans AS B ON A.PaymentMeanId=B.Id
                               INNER JOIN Receipts AS R ON A.ReceiptId=R.Id
                               WHERE A.IdNumber=@idNumber ;";
            SchoolSupplie? result = null;
            try
            {
                var getItem = await connection.QueryAsync<SchoolSupplie, CashFlowType, PaymentMean, Receipt, SchoolSupplie>(query,
               (schoolSupplie, cashFlowType, paymentMean, receipt) =>
               {
                   schoolSupplie.CashFlowType = cashFlowType;
                   schoolSupplie.PaymentMean = paymentMean;
                   schoolSupplie.Receipt = receipt;
                   return schoolSupplie;
               },
               new { idNumber });
               result = getItem?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la récupération de la fourniture scolaire avec le numéro d'identification {idNumber}.", idNumber);
            }
            return result;
        }

        public async Task<List<SchoolSupplie>> GetSchoolSupplieByEnrollingListAsync(int enrollingId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplies  AS A  
                            INNER JOIN  CashFlowTypes AS B ON A.CashFlowTypeId=B.Id
                            INNER JOIN PaymentMeans AS C ON A.PaymentMeanId=C.Id
                            INNER JOIN Receipts AS R ON A.ReceiptId=R.Id
                            WHERE EnrollingId=@enrollingId   ORDER BY A.Id DESC ;";
            
            List<SchoolSupplie> result = new ();
            try
            {
                var getItems = await connection.QueryAsync<SchoolSupplie, CashFlowType, PaymentMean, Receipt, SchoolSupplie>(query,
               (schoolSupplie, cashFlowType, paymentMean, receipt) =>
               {
                   schoolSupplie.CashFlowType = cashFlowType;
                   schoolSupplie.PaymentMean = paymentMean;
                   schoolSupplie.Receipt = receipt;
                   return schoolSupplie;
               },
               new { enrollingId });
               result = getItems?.ToList() ?? new List<SchoolSupplie>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la récupération de la liste des fournitures scolaires de l'inscription avec l'identifiant {enrollingId}.", enrollingId);
            }
            return result;
        }

        public async Task<List<SchoolSupplie>> GetSchoolSupplieBySchoolYearListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplies AS A  
                            INNER JOIN  CashFlowTypes AS B ON A.CashFlowTypeId=B.Id
                            INNER JOIN PaymentMeans AS C ON A.PaymentMeanId=C.Id
                            INNER JOIN Receipts AS R ON A.ReceiptId=R.Id
                            INNER JOIN StudentsEnrollings AS E ON A.EnrollingId=E.Id
                            INNER JOIN Students AS S ON E.StudentId=S.Id
                            WHERE E.SchoolYearId=@schoolYearId
                             ORDER BY A.Id DESC ;";

            List<SchoolSupplie> result = new();
            try
            {
                var getItems = await connection.QueryAsync<SchoolSupplie, CashFlowType, PaymentMean, Receipt,StudentEnrolling, Student, SchoolSupplie>(query,
                 (schoolSupplie, cashFlowType, paymentMean, receipt, enrolling, student) =>
                 {
                     schoolSupplie.CashFlowType = cashFlowType;
                     schoolSupplie.PaymentMean = paymentMean;
                     schoolSupplie.Receipt = receipt;
                     schoolSupplie.Enrolling = enrolling;
                     schoolSupplie.Enrolling.Student = student;
                     return schoolSupplie;
                 },
                 new { schoolYearId });
                result = getItems?.ToList() ?? new List<SchoolSupplie>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la récupération de la liste des fournitures scolaires de l'année scolaire avec l'identifiant {schoolYearId}.", schoolYearId);
            }

            
            return result;
        }

        public async Task<bool> ValidateSchoolSupplieAsync(int schoolSupplieId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE SchoolSupplies SET IsValidated=1 WHERE Id=@schoolSupplieId AND IsValidated=0;";
            int result = 0;
            try
            {
                result = await connection.ExecuteAsync(query, new { schoolSupplieId });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la validation de la fourniture scolaire avec l'identifiant {schoolSupplieId}.", schoolSupplieId);
            }
            return result > 0;
        }
    }
}
