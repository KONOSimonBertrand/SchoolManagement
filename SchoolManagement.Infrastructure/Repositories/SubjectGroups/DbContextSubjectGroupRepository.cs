using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextSubjectGroupRepository : ISubjectGroupRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextSubjectGroupRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(SubjectGroup subjectGroup)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.SubjectGroups.Add(subjectGroup);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;

        }

        public async Task<SubjectGroup?> GetAsync(string frenchName)
        {
            var result = appDbContext.SubjectGroups.FirstOrDefault(x => x.FrenchName == frenchName);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SubjectGroup>> GetListAsync()
        {
            var result = appDbContext.SubjectGroups.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SubjectGroup subjectGroup)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.SubjectGroups.Update(subjectGroup);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
    }
}
