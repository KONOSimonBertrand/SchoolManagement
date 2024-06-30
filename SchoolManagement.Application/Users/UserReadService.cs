using SchoolManagement.Core.Model;


namespace SchoolManagement.Application.Users
{
    public class UserReadService : IUserReadService
    {
       private readonly IUserRepository _userRepository;
        public UserReadService(IUserRepository userRepository) {
        _userRepository = userRepository;
        }
        public async Task<User?> GetUserAsync(string userName, string userPassword)
        {           
            return await _userRepository.GetUser(userName, userPassword);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsers();   
            return users;
        }

        public async Task<bool> LoginAsync(string userName, string userPassword)
        {
            return await _userRepository.Login(userName, userPassword);
        }
    }
}
