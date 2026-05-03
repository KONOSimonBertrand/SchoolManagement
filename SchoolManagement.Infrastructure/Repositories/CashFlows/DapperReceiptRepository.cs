
using Dapper;
using Microsoft.Extensions.Logging;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperReceiptRepository : IReceiptRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        private readonly ILogger<DapperReceiptRepository> logger;
        public DapperReceiptRepository(IDbConnectionFactory dbConnectionFactory, ILogger<DapperReceiptRepository> logger)
        {
            this.dbConnectionFactory = dbConnectionFactory;
            this.logger = logger;
        }
        public async Task<Receipt> AddAsync(Receipt receipt)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            var sql = @"INSERT INTO Receipts (IdNumber, Amount, Balance, OpFor, OpDoneBy, Date, SchoolYearId)
                        VALUES (@IdNumber, @Amount, @Balance, @OpFor, @OpDoneBy, @Date, @SchoolYearId);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
            try
            {
                var id = await connection.QuerySingleAsync<int>(sql, receipt);
                receipt.Id = id;

            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenue lors de l'enregistrement du réçu {errorMessgae}", ex.Message);
            }
            return receipt;
        }

        public async Task<Receipt?> GetByIdAsync(int id)
        {
            Receipt? receipt = null;
            try
            {
                using var dbConnection = dbConnectionFactory.CreateConnection();
                var sql = @"SELECT * FROM Receipts WHERE Id=@id";
                receipt = await dbConnection.QueryFirstOrDefaultAsync<Receipt>(sql, id);
            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenue lors de l'extraction du réçu {id}: {errorMessgae}", id, ex.Message);
            }
            return receipt;
        }

        public async Task<Receipt?> GetByIdNumberAsync(string idNumber)
        {
            Receipt? receipt = null;
            try
            {
                using var dbConnection = dbConnectionFactory.CreateConnection();
                var sql = @"SELECT * FROM Receipts WHERE IdNumber=@idNumber";
                receipt = await dbConnection.QueryFirstOrDefaultAsync<Receipt>(sql, idNumber);
            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenu lors de l'extraction du réçu {id}: {errorMessgae}", idNumber, ex.Message);
            }
            return receipt;
        }

        public async Task<List<Receipt>> GetListBySchoolYearIdAsync(int schoolYearId)
        {
            List<Receipt> receiptList = new();
            try
            {
                using var dbConnection = dbConnectionFactory.CreateConnection();
                var sql = @"SELECT * FROM Receipts WHERE SchoolYearId=@schoolYearId";
                receiptList = (await dbConnection.QueryAsync<Receipt>(sql, schoolYearId)).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenu lors de l'extraction de la liste des réçus pour l'année {id}: {errorMessgae}", schoolYearId, ex.Message);
            }
            return receiptList;
        }

        public async Task<List<Receipt>> GetListByDateAsync(DateTime date)
        {
            List<Receipt> receiptList = new();
            try
            {
                using var dbConnection =  dbConnectionFactory.CreateConnection();
                var sql = @"SELECT * FROM Receipts  WHERE YEAR(Date) = @Year AND MONTH(Date) = @Month ;";
                receiptList = ( dbConnection.Query<Receipt>(sql, date)).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenu lors de l'extraction de la liste des réçus pour le mois de {month}-{year}: {errorMessgae}", date.Month, date.Year, ex.Message);
            }
            await Task.Delay(0);
            return receiptList;
        }
    }
}
