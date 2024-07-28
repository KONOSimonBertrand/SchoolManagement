using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;


namespace SchoolManagement.Application
{
    public class UserService : IUserService
    {
       private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository) {
        this.userRepository = userRepository;
        }

        public async Task<bool> CreateUser(User user)
        {
            return await userRepository.AddAsync(user);
        }

        public async Task<User?> GetUser(string userName, string userPassword)
        {           
            return await userRepository.GetAsync(userName, userPassword);
        }
        public async Task<User?> GetUser(string userName)
        {
            return await userRepository.GetAsync(userName);
        }

        public async Task<IList<User>> GetUserList()
        {
            var users = await userRepository.GetListAsync();   
            return users;
        }

        public async Task<IList<UserModule>> GetUserModuleList(int userId)
        {
            return await userRepository.GetModuleListAsync(userId);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await userRepository.UpdateAsync(user);
        }
    }
}
