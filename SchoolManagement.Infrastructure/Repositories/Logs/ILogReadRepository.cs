
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public  interface ILogReadRepository
    {
        public Task<IEnumerable<Log>> GetListAsync(DateTime date);
        public Task<IEnumerable<Log>> GetListAsync(int userId);
        public Task<IEnumerable<Log>> GetListAsync(DateTime start, DateTime end);
    }
}
