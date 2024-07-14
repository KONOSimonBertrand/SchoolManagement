using SchoolManagement.Core.Model;


namespace SchoolManagement.Application.Users
{
    public class UserService : IUserService
    {
       private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;
        }
        public async Task<User?> GetUserAsync(string userName, string userPassword)
        {           
            return await _userRepository.GetAsync(userName, userPassword);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _userRepository.GetListAsync();   
            return users;
        }

        public async Task<bool> LoginAsync(string userName, string userPassword)
        {
            return await _userRepository.LoginAsync(userName, userPassword);
        }
    }
}
