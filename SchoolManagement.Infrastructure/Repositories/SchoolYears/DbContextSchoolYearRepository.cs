using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextSchoolYearRepository : ISchoolYearRepository
    {

        private readonly AppDbContext appDbContext;
        private readonly ClientApp clientApp;
        public DbContextSchoolYearRepository(ClientApp clientApp, AppDbContext appDbContext)
        {
            this.clientApp = clientApp;
            this.appDbContext = appDbContext;
        }

        public async Task<List<SchoolYear>> GetSchoolYearListAsync()
        {
            var result = appDbContext.SchoolYears
                .OrderByDescending(x => x.Id)
                .ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<bool> AddSchoolYearAsync(SchoolYear schoolYear)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.SchoolYears.Add(schoolYear);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateSchoolYearAsync(SchoolYear schoolYear)
        {
            bool isDone = false;
            var item = appDbContext.SchoolYears.FirstOrDefault(s => s.Id == schoolYear.Id);
            if (item != null)
            {
                appDbContext.ChangeTracker.Clear();
                item.Name = schoolYear.Name;
                item.StartFirstQuarter = schoolYear.StartFirstQuarter;
                item.EndFirstQuarter = schoolYear.EndFirstQuarter;
                item.StartSecondQuarter = schoolYear.StartSecondQuarter;
                item.EndSecondQuarter = schoolYear.EndSecondQuarter;
                item.StartThirdQuarter = schoolYear.StartThirdQuarter;
                item.EndThirdQuarter = schoolYear.EndThirdQuarter;
                item.IsClosed = schoolYear.IsClosed;
                appDbContext.SchoolYears.Update(item);
                if (appDbContext.SaveChanges() > 0) isDone = true;
            }
            await Task.Delay(0);
            return isDone;
        }

        public async Task<SchoolYear?> GetSchoolYearAsync(string name)
        {
            var result = appDbContext.SchoolYears.FirstOrDefault(s => s.Name == name);
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> ChangeSchoolYearStatusAsync(SchoolYear schoolYear)
        {
            bool isDone = false;
            var item = appDbContext.SchoolYears.FirstOrDefault(s => s.Id == schoolYear.Id);
            if (item != null)
            {
                appDbContext.ChangeTracker.Clear();
                item.IsClosed = !schoolYear.IsClosed;
                appDbContext.SchoolYears.Update(item);
                if (appDbContext.SaveChanges() > 0) isDone = true;
            }
            await Task.Delay(0);
            return isDone;
        }

        public Task<SchoolYear?> GetLastSchoolYearAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalSchoolYearAsync()
        {
            throw new NotImplementedException();
        }
    }
}
