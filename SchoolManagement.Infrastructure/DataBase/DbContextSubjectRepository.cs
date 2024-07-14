

using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Subjects;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    internal class DbContextSubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextSubjectRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(Subject subject)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.Subjects.Add(subject);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;

        }

        public async Task<Subject?> GetAsync(string frenchName)
        {
            var result = appDbContext.Subjects.FirstOrDefault(x => x.FrenchName == frenchName);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Subject>> GetListAsync()
        {
            var result = appDbContext.Subjects.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(Subject subject)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.Subjects.Update(subject);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
    }
}
