using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;


namespace SchoolManagement.Application
{
    public class UserService : IUserService
    {
       private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository) {
        this.userRepository = userRepository;
        }

        public async Task<bool> AddModuleList(int userId,IList<UserModule> modules)
        {
            return await userRepository.AddModuleListAsync(userId,modules);
        }

        public async Task<bool> AddRoomList(int userId,IList<UserRoom> rooms)
        {
           return await userRepository.AddRoomListAsync(userId,rooms);
        }

        public async Task<bool> ChangePassword(int userId, string password)
        {
            return await userRepository.ChangePasswordAsync(userId,password);
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

        public async Task<IList<UserRoom>> GetUserRoomList(int userId)
        {
            return await userRepository.GetRoomListAsync(userId);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await userRepository.UpdateAsync(user);
        }
    }
}
