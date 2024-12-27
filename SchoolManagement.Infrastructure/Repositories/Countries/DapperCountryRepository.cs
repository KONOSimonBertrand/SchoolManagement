using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperCountryRepository : ICountryRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperCountryRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IList<Country>> GetLIstAsync()
        {
            var connection=dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM Countries ORDER BY FrenchName ;";
            var result=connection.Query<Country>(query).ToList();
            await Task.Delay(0);
            return result;
        }
    }
}
