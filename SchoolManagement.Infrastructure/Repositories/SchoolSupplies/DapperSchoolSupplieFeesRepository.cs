

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSchoolSupplieFeesRepository : ISchoolSupplieFeeRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public DapperSchoolSupplieFeesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddAsync(SchoolSupplieFee schoolSupplieFee)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO SchoolSupplieFees(Amount,RequiredQuantity,IsPayable,SchoolClassId,CashFlowTypeId,SchoolYearId)  
                                          VALUES(@amount,@quantity,@isPayable,@schoolClassId ,@cashFlowTypeId,@schoolYearId);";
            var result = connection.Execute(query, new
            {
                amount = schoolSupplieFee.Amount,
                quantity = schoolSupplieFee.RequiredQuantity,
                isPayable = schoolSupplieFee.IsPayable,
                schoolClassId=schoolSupplieFee.SchoolClassId,
                cashFlowTypeId = schoolSupplieFee.CashFlowTypeId,
                schoolYearId = schoolSupplieFee.SchoolYearId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SchoolSupplieFee> GetAsync(int schoolClassId, int cashFlowTypeId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplieFees  A   
                             INNER JOIN CashFlowTypes B ON A.CashFlowTypeId=B.Id  
                             INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id 
                             INNER JOIN SchoolClasses D ON A.SchoolClassId=D.Id
                             WHERE  SchoolClassId=@schoolClassId AND CashFlowTypeId=@cashFlowTypeId AND SchoolYearId=@schoolYearId";
            var result = connection.Query<SchoolSupplieFee,SchoolClass, CashFlowType, SchoolYear, SchoolSupplieFee>(query,
                 (schoolSupplieFee, schoolClass, cashFlowType, schoolYear) =>
                 {
                     schoolSupplieFee.SchoolClass = schoolClass;
                     schoolSupplieFee.CashFlowType = cashFlowType;
                     schoolSupplieFee.SchoolYear = schoolYear;
                     return schoolSupplieFee;
                 }
                , new
                {
                    schoolClassId,
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
                             INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id  
                             INNER JOIN SchoolClasses D ON A.SchoolClassId=D.Id
                             ORDER BY A.SchoolYearId DESC;";
            var result = connection.Query<SchoolSupplieFee,CashFlowType, SchoolYear, SchoolClass, SchoolSupplieFee >(query,
                (schoolSupplieFee, cashFlowType, schoolYear, schoolClass) =>
                {
                    schoolSupplieFee.CashFlowType = cashFlowType;
                    schoolSupplieFee.SchoolYear = schoolYear;
                    schoolSupplieFee.SchoolClass = schoolClass;
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
                             INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id  
                             INNER JOIN SchoolClasses D ON A.SchoolClassId=D.Id
                             WHERE A.SchoolYearId=@schoolYearId   
                             ORDER BY A.SchoolYearId DESC ";
            var result = connection.Query<SchoolSupplieFee, CashFlowType, SchoolYear, SchoolClass,   SchoolSupplieFee>(query,
                (schoolSupplieFee,cashFlowType, schoolYear, schoolClass) =>
                {
                    
                    schoolSupplieFee.CashFlowType = cashFlowType;
                    schoolSupplieFee.SchoolYear = schoolYear;
                    schoolSupplieFee.SchoolClass = schoolClass;
                    return schoolSupplieFee;
                },
                new {
                    schoolYearId
                }
            ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolSupplieFee>> GetListAsync(List<int> classIdlist, int cashFlowTypeId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplieFees A   
                             INNER JOIN CashFlowTypes B ON A.CashFlowTypeId=B.Id  
                             INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id  
                             INNER JOIN SchoolClasses D ON A.SchoolClassId=D.Id
                             WHERE   A.SchoolClassId IN @classIdList AND A.CashFlowTypeId=@cashFlowTypeId AND A.SchoolYearId=@schoolYearId   
                             ORDER BY A.SchoolYearId DESC ";
            var result = connection.Query<SchoolSupplieFee, CashFlowType, SchoolYear, SchoolClass, SchoolSupplieFee>(query,
                (schoolSupplieFee, cashFlowType, schoolYear, schoolClass) =>
                {
                    schoolSupplieFee.CashFlowType = cashFlowType;
                    schoolSupplieFee.SchoolYear = schoolYear;
                    schoolSupplieFee.SchoolClass = schoolClass;
                    return schoolSupplieFee;
                },
                new
                {
                    classIdlist,
                    cashFlowTypeId,
                    schoolYearId
                }
            ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SchoolSupplieFee schoolSupplieFee)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE SchoolSupplieFees SET Amount=@amount,RequiredQuantity=@quantity,IsPayable=@isPayable,CashFlowTypeId=@cashFlowTypeId,SchoolYearId=@schoolYearId  
                                          WHERE id=@id  ;";
            var result = connection.Execute(query, new
            {
                amount = schoolSupplieFee.Amount,
                quantity= schoolSupplieFee.RequiredQuantity,
                isPayable=schoolSupplieFee.IsPayable,
                cashFlowTypeId = schoolSupplieFee.CashFlowTypeId,
                schoolYearId = schoolSupplieFee.SchoolYearId,
                id = schoolSupplieFee.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
