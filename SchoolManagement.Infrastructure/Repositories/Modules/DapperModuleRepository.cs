

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperModuleRepository : IModuleRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperModuleRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<Module?> GetAsync(string name)
        {
            var connection=dbConnectionFactoty.CreateConnection();
            string query = @"SELECT *  FROM Modules  WHERE Name=@name;";
            var result = connection.Query<Module>(query, new {name}).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Module>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT *  FROM Modules ;";
            var result = connection.Query<Module>(query).ToList();
            await Task.Delay(0);
            return result;
        }
    }
}
