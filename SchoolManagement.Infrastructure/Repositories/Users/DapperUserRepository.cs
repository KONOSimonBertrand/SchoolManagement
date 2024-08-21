

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperUserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperUserRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddAsync(User user)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO Users(UserName,Password,Name,Email,EmployeeId) 
                           VALUES(@userName,@password,@name,@email,@employeeId) ;";
            var result = connection.Execute(query, new
            {
                userName = user.UserName,
                password = user.Password,
                name = user.Name,
                email = user.Email,
                employeeId = user.EmployeeId
            });
            await Task.Delay(0);
            return result > 0;
        }
        private async Task<bool> AddModuleAsync(UserModule module)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO UsersModules(UserId,ModuleId,IsDefault,AllowCreate,AllowUpdate,AllowDelete,AllowRead,AllowPrint,AllowMail) 
                           VALUES(@userId,@moduleId,@isDefault,@allowCreate,@allowUpdate,@allowDelete,@allowRead,@allowPrint,@allowMail) ;";
            var result = connection.Execute(query, new
            {
                userId = module.UserId,
                moduleId = module.ModuleId,
                isDefault = module.IsDefault,
                allowCreate = module.AllowCreate,
                allowUpdate = module.AllowUpdate,
                allowDelete = module.AllowDelete,
                allowRead = module.AllowRead,
                allowPrint = module.AllowPrint,
                allowMail = module.AllowMail
            });
            await Task.Delay(0);
            return result > 0;
        }
        private async Task<bool> DeleteModuleListAsync(int userId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"DELETE FROM UsersModules WHERE UserId=@userId ;";
            var result = connection.Execute(query, new
            {
                userId 
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async Task<bool> AddModuleListAsync(int userId, IList<UserModule> modules)
        {
            await DeleteModuleListAsync(userId);
            int recordCount = 0;
            foreach (var module in modules)
            {
                if (await AddModuleAsync(module) == true)
                {
                    recordCount++;
                }
            }
            return recordCount== modules.Count;
        }
        public async Task<User?> GetAsync(string userName, string password)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Users A 
                           WHERE UserName=@userName AND Password=@password ;";
            var result = connection.Query<User>(query, new { userName, password }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
        public async Task<User?> GetAsync(string userName)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Users A 
                           LEFT JOIN Employees B ON A.EmployeeId=B.Id
                           WHERE UserName=@userName  ;";
            var result = connection.Query<User, Employee, User>(query,
                (user, employee) =>
                {
                    user.Employee = employee;
                    return user;
                }
                , new { userName }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<User>> GetListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Users A 
                           LEFT JOIN Employees B ON A.EmployeeId=B.Id;";
            var result = connection.Query<User, Employee, User>(query,
                (user, employee) =>
                {
                    user.Employee = employee;
                    return user;
                }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<IList<UserModule>> GetModuleListAsync(int userId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM UsersModules A 
                           INNER JOIN Users B ON A.UserId=B.Id
                           INNER JOIN Modules C ON A.ModuleId=C.Id
                           WHERE A.UserId=@userId  ;";
            var result = connection.Query<UserModule, User, Module, UserModule>(query,
                (userModule, user, module) =>
                {
                    userModule.User = user;
                    userModule.Module = module;
                    return userModule;
                }
                , new { userId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<bool> UpdateAsync(User user)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Users SET UserName=@userName,Password=@password,Name=@name,Email=@email,EmployeeId=@employeeId 
                              WHERE Id=@id ;";
            var result = connection.Execute(query, new
            {
                userName = user.UserName,
                password = user.Password,
                name = user.Name,
                email = user.Email,
                employeeId = user.EmployeeId,
                id = user.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async  Task<IList<UserRoom>> GetRoomListAsync(int userId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM UsersRooms A 
                           INNER JOIN Users B ON A.UserId=B.Id
                           INNER JOIN SchoolRooms C ON A.RoomId=C.Id
                           WHERE A.UserId=@userId  ;";
            var result = connection.Query<UserRoom, User, SchoolRoom, UserRoom>(query,
                (userRoom, user, room) =>
                {
                    userRoom.User = user;
                    userRoom.Room = room;
                    return userRoom;
                }
                , new { userId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<bool> AddRoomListAsync(int userId, IList<UserRoom> rooms)
        {
            await DeleteRoomListAsync(userId);
            int recordCount = 0;
            foreach (var room in rooms)
            {
                if (await AddRoomAsync(room) == true)
                {
                    recordCount++;
                }
            }
            return recordCount == rooms.Count;
        }
        private async Task<bool> AddRoomAsync(UserRoom room)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO UsersRooms(UserId,RoomId) 
                           VALUES(@userId,@roomId) ;";
            var result = connection.Execute(query, new
            {
                userId = room.UserId,
                roomId = room.RoomId,
               
            });
            await Task.Delay(0);
            return result > 0;
        }
        private async Task<bool> DeleteRoomListAsync(int userId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"DELETE FROM UsersRooms WHERE UserId=@userId ;";
            var result = connection.Execute(query, new
            {
                userId
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async Task<bool> ChangePasswordAsync(int userId, string password)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Users SET Password=@password WHERE Id=@userId ;";                             
            var result = connection.Execute(query, new
            {
                password ,
                userId
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
