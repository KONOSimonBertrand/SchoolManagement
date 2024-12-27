
using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ILogWriteRepository
    {
        public Task<bool> AddAsync(Log log);
    }
}
