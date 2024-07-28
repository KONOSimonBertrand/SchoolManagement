using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;
using System;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextUserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextUserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<User>> GetListAsync()
        {
            var result = appDbContext.Users.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<User?> GetAsync(string userName, string userPassword)
        {
            var user = appDbContext.Users.SingleOrDefault(user => user.UserName == userName && user.Password == userPassword);
            await Task.Delay(0);
            return user;
        }
        public async Task<User?> GetAsync(string userName)
        {
            var user = appDbContext.Users.SingleOrDefault(user => user.UserName == userName);
            await Task.Delay(0);
            return user;
        }

        public async Task<bool> AddAsync(User user)
        {
            appDbContext.ChangeTracker.Clear();
            if (user.Employee != null) user.Employee = appDbContext.Employees.SingleOrDefault(x => x.Id == user.EmployeeId);
            appDbContext.Users.Add(user);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.Users.Update(user);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<IList<UserModule>> GetModuleListAsync(int userId)
        {
            var result = appDbContext.UsersModules.Include(x=>x.Module).Where(x => x.UserId == userId).ToList();
            await Task.Delay(0);
            return result;
        }

        private  async Task<bool> AddModuleAsync(UserModule module)
        {
            appDbContext.ChangeTracker.Clear();
            module.Module = appDbContext.Modules.FirstOrDefault(x => x.Id == module.ModuleId);
            module.User = appDbContext.Users.FirstOrDefault(x => x.Id == module.UserId);
            appDbContext.UsersModules.Add(module);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
        private async Task<bool> DeleteModuleAsync(UserModule module)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.UsersModules.Remove(module);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
        public async Task<bool> AddModuleListAsync(User user)
        {

            var modulesToDelete = await GetModuleListAsync(user.Id);
            foreach(var module in modulesToDelete)
            {
                await DeleteModuleAsync(module);
            }
            int recordCount = 0;
                foreach (var module in user.Modules)
            {
                if (await AddModuleAsync(module) == true)
                {
                    recordCount++;
                }
            }
            await Task.Delay(0);
            return recordCount > 0;
        }
    }
}
