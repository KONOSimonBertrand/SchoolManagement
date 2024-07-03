
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Core.Model;


namespace SchoolManagement.Infrastructure.DataBase
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

        public async Task<List<SchoolYear>> GetAllAsync()
        {
            var result = appDbContext.SchoolYears.ToList();
            await Task.Delay(0);
            return result;           
        }
        public async Task<bool> AddAsync(SchoolYear schoolYear)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.SchoolYears.Add(schoolYear);
            var result=appDbContext.SaveChanges();
            await Task.Delay(0);
            return (result > 0);
        }

        public async Task<bool> UpdateAsync(SchoolYear schoolYear)
        {
            int result = 0;
            var item=appDbContext.SchoolYears.FirstOrDefault(s=>s.Id==schoolYear.Id);
            if (item != null)
            {
                appDbContext.ChangeTracker.Clear();
                item.Name = schoolYear.Name;
                item.StartFirstQuarter=schoolYear.StartFirstQuarter;
                item.EndFirstQuarter=schoolYear.EndFirstQuarter;
                item.StartSecondQuarter=schoolYear.StartSecondQuarter;
                item.EndSecondQuarter=schoolYear.EndSecondQuarter;
                item.StartThirdQuarter=schoolYear.StartThirdQuarter;
                item.EndThirdQuarter=schoolYear.EndThirdQuarter;
                item.IsClosed=schoolYear.IsClosed;
                appDbContext.SchoolYears.Update(item);
                result =appDbContext.SaveChanges();
            }
            await Task.Delay(0);
            return (result > 0);
        }

        public async Task<SchoolYear?> GetAsync(string name)
        {
            var result = appDbContext.SchoolYears.FirstOrDefault(s=>s.Name==name);
            await Task.Delay(0);
            return result;
        }
    }
}
