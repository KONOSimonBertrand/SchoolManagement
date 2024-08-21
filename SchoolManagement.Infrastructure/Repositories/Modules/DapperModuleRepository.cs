

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperModuleRepository : IModuleRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperModuleRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<Module?> GetAsync(string name)
        {
            var connection=dbConnectionFactory.CreateConnection();
            string query = @"SELECT *  FROM Modules  WHERE Name=@name;";
            var result = connection.Query<Module>(query, new {name}).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Module>> GetListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT *  FROM Modules ;";
            var result = connection.Query<Module>(query).ToList();
            await Task.Delay(0);
            return result;
        }
    }
}
