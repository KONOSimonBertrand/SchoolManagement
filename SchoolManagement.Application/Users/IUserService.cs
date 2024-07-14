

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Users
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(string userName,string userPassword);
        Task<List<User>> GetUsersAsync();
        Task<bool> LoginAsync(string userName, string userPassword);
    }
}
