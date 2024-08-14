

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IUserService
    {
        public Task<bool> CreateUser(User user);
        public Task<bool> UpdateUser(User user);
        public Task<bool> ChangePassword(int userId,string password);
        public Task<bool> AddModuleList(int userId,IList<UserModule> modules);
        public Task<IList<UserModule>> GetUserModuleList(int userId);
        public Task<bool> AddRoomList(int userId, IList<UserRoom> rooms);
        public Task<IList<UserRoom>> GetUserRoomList(int userId);
        Task<User?> GetUser(string userName,string userPassword);
        Task<User?> GetUser(string userName);
        Task<IList<User>> GetUserList();
    }
}
