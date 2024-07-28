using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class DbContextLogRepository : ILogRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextLogRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(Log log)
        {
            appDbContext.ChangeTracker.Clear();
            log.CreateDate = DateTime.Now;
            log.Id = Guid.NewGuid();
            appDbContext.Logs.Add(log);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<IEnumerable<Log>> GetListAsync(DateTime date)
        {
            var result = appDbContext.Logs.Where(l => l.CreateDate.Value.Date == date.Date).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IEnumerable<Log>> GetListAsync(int userId)
        {
            var result = appDbContext.Logs.Where(l => l.UserId == userId).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IEnumerable<Log>> GetListAsync(DateTime start, DateTime end)
        {
            var result = appDbContext.Logs.Where(l => l.CreateDate.Value.Date >= start.Date && l.CreateDate.Value.Date <= end.Date).ToList();
            await Task.Delay(0);
            return result;
        }
    }
}
