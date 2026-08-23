

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class DapperCashFlowTypeRepository : ICashFlowTypeRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperCashFlowTypeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> AddAsync(CashFlowType cashFlowType)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO CashFlowTypes(Name,FlowCategory,TransactionType,FlowType,FlowDomain,Description,Sequence) 
                              VALUES(@name,@flowCategory,@transactionType,@flowType,@flowDomain,@description,@sequence);";
            var result = connection.Execute(query, new
            {
                name = cashFlowType.Name,
                flowCategory = cashFlowType.FlowCategory,
                transactionType = cashFlowType.TransactionType,
                flowType = cashFlowType.FlowType,
                flowDomain = cashFlowType.FlowDomain,
                description = cashFlowType.Description,
                sequence = cashFlowType.Sequence
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<CashFlowType?> GetAsync(string name)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM CashFlowTypes WHERE Name=@name ;";
            var result = connection.Query<CashFlowType>(query, new { name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<CashFlowType>> GetAsyncList()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM CashFlowTypes ORDER BY Sequence ;";
            var result = connection.Query<CashFlowType>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(CashFlowType cashFlowType)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE CashFlowTypes SET Name=@name,FlowCategory=@flowCategory,TransactionType=@transactionType,
                             FlowType=@flowType,FlowDomain=@flowDomain,Description=@description,Sequence=@sequence WHERE Id=@id";
            var result = connection.Execute(query, new
            {
                name = cashFlowType.Name,
                flowCategory = cashFlowType.FlowCategory,
                transactionType = cashFlowType.TransactionType,
                flowType = cashFlowType.FlowType,
                flowDomain = cashFlowType.FlowDomain,
                description = cashFlowType.Description,
                sequence = cashFlowType.Sequence,
                id = cashFlowType.Id

            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
