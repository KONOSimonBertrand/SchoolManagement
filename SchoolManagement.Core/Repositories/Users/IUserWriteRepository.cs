
using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public  interface IUserWriteRepository
    {
        public Task<bool> AddAsync(User user);
        public Task<bool> UpdateAsync(User user);
        public Task<bool> ChangePasswordAsync(int userId,string password);
        public Task<bool> AddModuleListAsync(int userId,IList<UserModule> modules);
        public Task<bool> AddRoomListAsync(int userId, IList<UserRoom> rooms);
    }
}
