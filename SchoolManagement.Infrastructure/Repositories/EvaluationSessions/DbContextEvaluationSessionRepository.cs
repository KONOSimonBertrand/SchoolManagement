

using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextEvaluationSessionRepository : IEvaluationSessionRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextEvaluationSessionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(EvaluationSession evaluationType)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.EvaluationSessions.Add(evaluationType);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;

        }

        public async Task<EvaluationSession?> GetAsync(string code)
        {
            var result = appDbContext.EvaluationSessions.FirstOrDefault(x => x.Code == code);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EvaluationSession>> GetListAsync()
        {
            var result = appDbContext.EvaluationSessions.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(EvaluationSession evaluationType)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.EvaluationSessions.Update(evaluationType);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;

        }
    }
}
