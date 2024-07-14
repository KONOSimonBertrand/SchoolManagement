

using Dapper;
using SchoolManagement.Application.CashFlowTypes;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    internal class DapperCashFlowTypeRepository : ICashFlowTypeRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperCashFlowTypeRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }
        public async Task<bool> AddAsync(CashFlowType cashFlowType)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO CashFlowTypes(Name,Category,Domain,Description,Sequence) 
                              VALUES(@name,@category,@domain,@description,@sequence);";
            var result = connection.Execute(query, new
            {
                name = cashFlowType.Name,
                category = cashFlowType.Category,
                domain = cashFlowType.Domain,
                description = cashFlowType.Description,
                sequence = cashFlowType.Sequence

            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<CashFlowType> GetAsyn(string name)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = "SELECT * FROM CashFlowTypes WHERE Name=@name ;";
            var result = connection.Query<CashFlowType>(query, new { name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<CashFlowType>> GetAsynList()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = "SELECT * FROM CashFlowTypes ;";
            var result = connection.Query<CashFlowType>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(CashFlowType cashFlowType)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"UPDATE CashFlowTypes SET Name=@name,Category=@category,Domain=@domain,
                             Description=@description,Sequence=@sequence WHERE Id=@id";
            var result = connection.Execute(query, new
            {
                name = cashFlowType.Name,
                category = cashFlowType.Category,
                domain = cashFlowType.Domain,
                description = cashFlowType.Description,
                sequence = cashFlowType.Sequence,
                id = cashFlowType.Id

            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
