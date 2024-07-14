

using Dapper;
using SchoolManagement.Application.Users;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class DapperUserRepository : IUserRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperUserRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<User?> GetAsync(string userName, string password)
        {
            var connection= dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM Users 
                           WHERE UserName=@userName AND Password=@password ;";
            var result= connection.Query<User>(query, new { userName,password }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<User>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM Users ;";
            var result = connection.Query<User>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM Users 
                           WHERE UserName=@userName AND Password=@password ;";
            var result = connection.Query<User>(query, new { userName, password }).FirstOrDefault();
            await Task.Delay(0);
            return result!=null;
        }
    }
}
