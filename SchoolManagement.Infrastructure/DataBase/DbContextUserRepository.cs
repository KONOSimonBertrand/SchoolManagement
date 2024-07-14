using SchoolManagement.Application.Users;
using SchoolManagement.Core.Model;
using System;


namespace SchoolManagement.Infrastructure.DataBase
{
    public class DbContextUserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextUserRepository(AppDbContext appDbContext) { 
            this.appDbContext = appDbContext;
        }
        public async  Task<List<User>> GetListAsync()
        {
            var result = appDbContext.Users.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<User?> GetAsync(string userName, string userPassword)
        {
            var user = appDbContext.Users.SingleOrDefault(user => user.Username == userName && user.Password == userPassword);
            await Task.Delay(0);
            return user;
        }
        public async Task<bool> LoginAsync(string userName, string userPassword)
        {
            var user = appDbContext.Users.SingleOrDefault(user => user.Username == userName && user.Password == userPassword);
            await Task.Delay(0);
            return user!=null;
        }
    }
}
