

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class DapperSchoolingCostRepository : ISchoolingCostRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperSchoolingCostRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddAsync(SchoolingCost cost)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO SchoolingCosts(SchoolClassId,CashFlowTypeId,SchoolYearId,Amount,TrancheNumber,IsPayable) 
                                                 VALUES(@classId,@typeId,@yearId,@amount,@tranches,@isPayable) ;";
            var result = connection.Execute(query, new
            {
                classId = cost.SchoolClassId,
                typeId = cost.CashFlowTypeId,
                yearId = cost.SchoolYearId,
                amount = cost.Amount,
                tranches = cost.TrancheNumber,
                isPayable = cost.IsPayable,
            });
            if (result > 0)
            {
                var costWithId = await GetAsync(cost.SchoolClassId, cost.CashFlowTypeId, cost.SchoolYearId);
                cost.Id = costWithId.Id;
                foreach (var item in cost.SchoolingCostItems)
                {
                    item.SchoolingCostId = cost.Id;
                }
                await AddAsyncItems(cost);
            }
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SchoolingCost> GetAsync(int classId, int costTypeId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolingCosts AS A 
                             INNER JOIN SchoolClasses AS  B ON A.SchoolClassId=B.Id 
                             INNER JOIN CashFlowTypes AS D ON A.CashFlowTypeId=D.Id 
                             INNER JOIN SchoolYears   AS C ON A.SchoolYearId= C.Id  
                             WHERE A.SchoolClassId=@classId AND A.CashFlowTypeId=@costTypeId AND A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<SchoolingCost, SchoolClass, CashFlowType, SchoolYear, SchoolingCost>(query,
                (schoolingCost, schoolClass, cashFlowType, schoolYear) =>
                {
                    schoolingCost.SchoolClass = schoolClass;
                    schoolingCost.CashFlowType = cashFlowType;
                    schoolingCost.SchoolYear = schoolYear;
                    return schoolingCost;
                },
                new
                {
                    classId,
                    costTypeId,
                    schoolYearId
                }
                ).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolingCostItem>> GetItemsAsync(int schoolingCostId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM SchoolingCostItems WHERE SchoolingCostId=@id ;";
            var result = connection.Query<SchoolingCostItem>(query, new { id = schoolingCostId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolingCost>> GetListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolingCosts AS A 
                             INNER JOIN SchoolClasses  AS B ON A.SchoolClassId=B.Id 
                             INNER JOIN CashFlowTypes AS D ON A.CashFlowTypeId=D.Id 
                             INNER JOIN SchoolYears   AS C ON A.SchoolYearId= C.Id 
                             ORDER BY A.SchoolYearId DESC ;";
            var result = connection.Query<SchoolingCost, SchoolClass, CashFlowType, SchoolYear, SchoolingCost>(query,
                (schoolingCost, schoolClass, cashFlowType, schoolYear) =>
                {
                    schoolingCost.SchoolClass = schoolClass;
                    schoolingCost.CashFlowType = cashFlowType;
                    schoolingCost.SchoolYear = schoolYear;
                    return schoolingCost;
                }
                ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SchoolingCost cost)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE SchoolingCosts SET SchoolClassId=@classId,CashFlowTypeId=@typeId,
                             SchoolYearId=@yearId,Amount=@amount,TrancheNumber=@tranches,IsPayable=@isPayable  WHERE Id=@id ;";

            var result = connection.Execute(query, new
            {
                classId = cost.SchoolClassId,
                typeId = cost.CashFlowTypeId,
                yearId = cost.SchoolYearId,
                amount = cost.Amount,
                tranches = cost.TrancheNumber,
                isPayable = cost.IsPayable,
                id = cost.Id
            });
            if (result > 0)
            {
                await DeleteAsyncItems(cost);
                await AddAsyncItems(cost);
            }
            await Task.Delay(0);
            return result > 0;

        }

        private async Task<bool> AddAsyncItems(SchoolingCost cost)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO SchoolingCostItems(Amount,DeadLine,SchoolingCostId) 
                                         VALUES(@amount,@deadLine,@schoolingCostId);";
            var resut = connection.Execute(query, cost.SchoolingCostItems);
            await Task.Delay(0);
            return resut > 0;
        }
        private async Task<bool> DeleteAsyncItems(SchoolingCost cost)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "DELETE FROM SchoolingCostItems WHERE SchoolingCostId=@id";
            var resut = connection.Execute(query, new { id = cost.Id });
            await Task.Delay(0);
            return resut > 0;
        }
    }
}
