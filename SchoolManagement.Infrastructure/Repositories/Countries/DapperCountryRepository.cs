using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperCountryRepository : ICountryRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperCountryRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<IList<Country>> GetLIstAsync()
        {
            var connection=dbConnectionFactoty.CreateConnection();
            string query = "SELECT * FROM Countries ;";
            var result=connection.Query<Country>(query).ToList();
            await Task.Delay(0);
            return result;
        }
    }
}
