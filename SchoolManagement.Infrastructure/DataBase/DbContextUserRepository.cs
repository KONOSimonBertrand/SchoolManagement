using SchoolManagement.Application.Users;
using SchoolManagement.Core.Model;


namespace SchoolManagement.Infrastructure.DataBase
{
    public class DbContextUserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextUserRepository(AppDbContext appDbContext) { 
            this.appDbContext = appDbContext;
        }
        public  Task<List<User>> GetUsers()
        {
          return Task.FromResult( appDbContext.Users.ToList());
        }

        public Task<User?> GetUser(string userName, string userPassword)
        {
            var user = appDbContext.Users.SingleOrDefault(user => user.Username == userName && user.Password == userPassword);
            return Task.FromResult(user);
        }

        public Task<bool> Login(string userName, string userPassword)
        {
            var user = appDbContext.Users.SingleOrDefault(user => user.Username == userName && user.Password == userPassword);
            return Task.FromResult( user != null);
        }
    }
}
