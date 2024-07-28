
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public  interface IUserWriteRepository
    {
        public Task<bool> AddAsync(User user);
        public Task<bool> UpdateAsync(User user);
        public Task<bool> AddModuleListAsync(User user);
    }
}
