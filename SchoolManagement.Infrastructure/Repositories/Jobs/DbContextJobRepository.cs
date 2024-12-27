
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextJobRepository : IJobRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextJobRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(Job job)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.Jobs.Add(job);
            var result=appDbContext.SaveChanges();
            await Task.Delay(0);
            return result>0;
        }

        public async  Task<Job?> GetAsync(string name)
        {
           var result= appDbContext.Jobs.FirstOrDefault(x=>x.Name==name);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Job>> GetListAsync()
        {
            var result = appDbContext.Jobs.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(Job job)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.Jobs.Update(job);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
    }
}
