

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class LogService : ILogService
    {
        private readonly ILogRepository logRepository;
        public LogService(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public async Task<bool> CreateLog(Log log)
        {
          return await logRepository.AddAsync(log);
        }

        public async Task<IEnumerable<Log>> GetLogListAsync(DateTime start, DateTime end)
        {
            return await logRepository.GetListAsync(start, end);
        }

        public async Task<IEnumerable<Log>> GetLogListAsync(int userId)
        {
            return await logRepository.GetListAsync(userId);
        }

        public async Task<IEnumerable<Log>> GetLogListAsync(DateTime date)
        {
            return await logRepository.GetListAsync(date);
        }
    }
}
