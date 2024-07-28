
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ILogWriteRepository
    {
        public Task<bool> AddAsync(Log log);
    }
}
