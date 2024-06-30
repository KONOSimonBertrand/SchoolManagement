
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Core.Model;
using System;


namespace SchoolManagement.Infrastructure.DataBase
{
    public class DbContextSchoolYearRepository : ISchoolYearRepository
    {
      
        private readonly AppDbContext appDbContext;
        private readonly ClientApp _clientApp;
        public DbContextSchoolYearRepository(ClientApp clientApp, AppDbContext appDbContext)
        {
            _clientApp = clientApp;
            this.appDbContext = appDbContext;
        }

        public  Task<List<SchoolYear>> GetAllAsync()
        {
            var result = appDbContext.SchoolYears.ToList();
            return Task.FromResult(result);
        }
        public Task<bool> AddAsync(SchoolYear schoolYear)
        {
            appDbContext.SchoolYears.Add(schoolYear);
            var result=appDbContext.SaveChanges();
            return Task.FromResult(result > 0);
        }

        public Task<bool> UpdateAsync(SchoolYear schoolYear)
        {
            int result = 0;
            var item=appDbContext.SchoolYears.FirstOrDefault(s=>s.Id==schoolYear.Id);
            if (item != null)
            {
                item.Name = schoolYear.Name;
                item.StartFirstQuarter=schoolYear.StartFirstQuarter;
                item.EndFirstQuarter=schoolYear.EndFirstQuarter;
                item.StartSecondQuarter=schoolYear.StartSecondQuarter;
                item.EndSecondQuarter=schoolYear.EndSecondQuarter;
                item.StartThirdQuarter=schoolYear.StartThirdQuarter;
                item.EndThirdQuarter=schoolYear.EndThirdQuarter;
                item.IsClosed=schoolYear.IsClosed;
               appDbContext.SchoolYears.Update(item);
               result = appDbContext.SaveChanges();
            }
           
            return Task.FromResult(result > 0);
        }
    }
}
