

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSchoolSupplieFeesRepository : ISchoolSupplieFeesRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public DapperSchoolSupplieFeesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddAsync(SchoolSupplieFee schoolSupplieFee)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO SchoolSupplieFees(Amount,RequiredQuantity,CashFlowTypeId,SchoolYearId)  
                                          VALUES(@amount,@quantity,@cashFlowTypeId,@schoolYearId);";
            var result = connection.Execute(query, new
            {
                amount = schoolSupplieFee.Amount,
                quantity = schoolSupplieFee.RequiredQuantity,
                cashFlowTypeId = schoolSupplieFee.CashFlowTypeId,
                schoolYearId = schoolSupplieFee.SchoolYearId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SchoolSupplieFee> GetAsync(int cashFlowTypeId, int schoolYearId)
        {

            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplieFees  A   
                             INNER JOIN CashFlowTypes B ON A.CashFlowTypeId=B.Id  
                             INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id 
                             WHERE CashFlowTypeId=@cashFlowTypeId AND SchoolYearId=@schoolYearId";
            var result = connection.Query<SchoolSupplieFee, CashFlowType, SchoolYear, SchoolSupplieFee>(query,
                 (schoolSupplieFee, cashFlowType, schoolYear) =>
                 {
                     schoolSupplieFee.CashFlowType = cashFlowType;
                     schoolSupplieFee.SchoolYear = schoolYear;
                     return schoolSupplieFee;
                 }
                , new
                {
                    cashFlowTypeId,
                    schoolYearId
                }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolSupplieFee>> GetListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplieFees A   
                             INNER JOIN CashFlowTypes B ON A.CashFlowTypeId=B.Id  
                             INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id  ORDER BY A.SchoolYearId DESC;";
            var result = connection.Query<SchoolSupplieFee, CashFlowType, SchoolYear, SchoolSupplieFee>(query,
                (schoolSupplieFee, cashFlowType, schoolYear) =>
                {
                    schoolSupplieFee.CashFlowType = cashFlowType;
                    schoolSupplieFee.SchoolYear = schoolYear;
                    return schoolSupplieFee;
                }
            ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolSupplieFee>> GetListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplieFees A   
                             INNER JOIN CashFlowTypes B ON A.CashFlowTypeId=B.Id  
                             INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id  ORDER BY A.SchoolYearId DESC;
                             WHERE A.SchoolYearId=@schoolYearId";
            var result = connection.Query<SchoolSupplieFee, CashFlowType, SchoolYear, SchoolSupplieFee>(query,
                (schoolSupplieFee, cashFlowType, schoolYear) =>
                {
                    schoolSupplieFee.CashFlowType = cashFlowType;
                    schoolSupplieFee.SchoolYear = schoolYear;
                    return schoolSupplieFee;
                },
                new {
                    schoolYearId
                }
            ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> Updatesync(SchoolSupplieFee schoolSupplieFee)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE SchoolSupplieFees SET Amount=@amount,RequiredQuantity=@quantity,CashFlowTypeId=@cashFlowTypeId,SchoolYearId=@schoolYearId  
                                          WHERE id=@id  ;";
            var result = connection.Execute(query, new
            {
                amount = schoolSupplieFee.Amount,
                quantity= schoolSupplieFee.RequiredQuantity,
                cashFlowTypeId = schoolSupplieFee.CashFlowTypeId,
                schoolYearId = schoolSupplieFee.SchoolYearId,
                id = schoolSupplieFee.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
