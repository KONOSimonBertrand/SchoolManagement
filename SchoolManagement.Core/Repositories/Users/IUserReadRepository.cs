
using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public  interface IUserReadRepository
    {
        public Task<List<User>> GetListAsync();
        public Task<User?> GetAsync(string userName, string password);
        public Task<User?> GetAsync(string userName);
        public Task<IList<UserModule>> GetModuleListAsync(int userId);
        public Task<IList<UserRoom>> GetRoomListAsync(int userId);
    }
}
