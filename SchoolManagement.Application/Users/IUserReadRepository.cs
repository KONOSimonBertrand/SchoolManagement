
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Users
{
    public  interface IUserReadRepository
    {
        public Task<List<User>> GetUsers();
        public Task<User?> GetUser(string userName, string userPassword);
        public Task<bool> Login(string userName, string userPassword);
    }
}
