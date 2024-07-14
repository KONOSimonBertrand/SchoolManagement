

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Logs
{
    public  interface ILogService
    {
        public Task<bool> CreateLog(Log log);
        public Task<IEnumerable<Log>> GetLogListAsync(DateTime start, DateTime end);
        public Task<IEnumerable<Log>> GetLogListAsync(int userId);
        public Task<IEnumerable<Log>> GetLogListAsync(DateTime date);
    }
}
