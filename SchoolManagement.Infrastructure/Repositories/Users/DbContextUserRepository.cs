using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
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
            var result = appDbContext.UsersModules.Include(x => x.Module).Where(x => x.UserId == userId).ToList();
            await Task.Delay(0);
            return result;
        }

        private async Task<bool> AddModuleAsync(UserModule module)
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
        public async Task<bool> AddModuleListAsync(int userId, IList<UserModule> modules)
        {

            var modulesToDelete = await GetModuleListAsync(userId);
            foreach (var module in modulesToDelete)
            {
                await DeleteModuleAsync(module);
            }
            int recordCount = 0;
            foreach (var module in modules)
            {
                if (await AddModuleAsync(module) == true)
                {
                    recordCount++;
                }
            }
            await Task.Delay(0);
            return recordCount == modules.Count;
        }

        public async Task<IList<UserRoom>> GetRoomListAsync(int userId)
        {
            var result = appDbContext.UsersRooms.Include(x => x.Room).Where(x => x.UserId == userId).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> AddRoomListAsync(int userId, IList<UserRoom> rooms)
        {
            var roomsToDelete = await GetRoomListAsync(userId);
            foreach (var room in roomsToDelete)
            {
                await DeleteRoomAsync(room);
            }
            int recordCount = 0;
            foreach (var room in rooms)
            {
                if (await AddRoomAsync(room) == true)
                {
                    recordCount++;
                }
            }
            await Task.Delay(0);
            return recordCount == rooms.Count;
        }
        private async Task<bool> AddRoomAsync(UserRoom room)
        {
            appDbContext.ChangeTracker.Clear();
            room.Room = appDbContext.ShoolRooms.FirstOrDefault(x => x.Id == room.RoomId);
            room.User = appDbContext.Users.FirstOrDefault(x => x.Id == room.UserId);
            appDbContext.UsersRooms.Add(room);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
        private async Task<bool> DeleteRoomAsync(UserRoom room)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.UsersRooms.Remove(room);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string password)
        {
            appDbContext.ChangeTracker.Clear();
            var user = await appDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            user.Password = password;
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
    }
}
