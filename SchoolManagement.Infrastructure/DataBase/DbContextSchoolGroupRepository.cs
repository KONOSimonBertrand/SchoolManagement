using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.SchoolGroups;
using SchoolManagement.Core.Model;


namespace SchoolManagement.Infrastructure.DataBase
{
    public class DbContextSchoolGroupRepository : ISchoolGroupRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextSchoolGroupRepository( AppDbContext appDbContext) { 
            this.appDbContext = appDbContext;
        }
        public async Task<bool> AddAsync(SchoolGroup schoolGroup)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.SchoolGroups.Add(schoolGroup);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return (result > 0);
        }

        public async Task<List<SchoolGroup>> GetListAsync()
        {
            var result = appDbContext.SchoolGroups.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<SchoolGroup?> GetAsync(string name)
        {
            var result = appDbContext.SchoolGroups.FirstOrDefault(s => s.Name == name);
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SchoolGroup schoolGroup)
        {
            bool isDone=false;
            var item = appDbContext.SchoolGroups.FirstOrDefault(s => s.Id == schoolGroup.Id);
            if (item != null)
            {
                appDbContext.ChangeTracker.Clear();
                item.Name = schoolGroup.Name;
                item.Sequence=schoolGroup.Sequence;               
                appDbContext.SchoolGroups.Update(item);
                if (appDbContext.SaveChanges() > 0) isDone = true;
            }
            await Task.Delay(0);
            return isDone;
        }
    }
}
