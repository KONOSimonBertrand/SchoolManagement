using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class DbContextEmployeeGroupRepository : IEmployeeGroupRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextEmployeeGroupRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(EmployeeGroup group)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.EmployeeGroups.Add(group);
            var result= appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<EmployeeGroup?> GetAsync(string name)
        {
            var result = appDbContext.EmployeeGroups.FirstOrDefault(x => x.Name == name);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EmployeeGroup>> GetListAsync()
        {
            var result = appDbContext.EmployeeGroups.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(EmployeeGroup group)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.EmployeeGroups.Update(group);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
    }
}
