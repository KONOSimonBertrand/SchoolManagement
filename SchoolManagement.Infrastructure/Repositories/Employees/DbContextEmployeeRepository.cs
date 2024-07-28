
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextEmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.Employees.Add(employee);
            var result=appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<Employee?> GetAsync(string idNumber)
        {
            var result = appDbContext.Employees.Include(x => x.Job).Include(x => x.Group).FirstOrDefault(x=>x.IdNumber==idNumber);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Employee>> GetListAsync()
        {
            var result=appDbContext.Employees.Include(x=>x.Job).Include(x=>x.Group).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.Employees.Update(employee);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
    }
}
