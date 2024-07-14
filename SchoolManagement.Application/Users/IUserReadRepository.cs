
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Users
{
    public  interface IUserReadRepository
    {
        public Task<List<User>> GetListAsync();
        public Task<User?> GetAsync(string userName, string password);
        public Task<bool> LoginAsync(string userName, string password);
    }
}
