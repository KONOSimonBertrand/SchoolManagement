
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Logs
{
    public interface ILogWriteRepository
    {
        public Task<bool> AddAsync(Log log);
    }
}
