
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories.Countries
{
    public class DbContextCountryRepository : ICountryRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextCountryRepository(AppDbContext appDbContext) { 
        this.appDbContext = appDbContext;
        }
        public async Task<IList<Country>> GetLIstAsync()
        {
            var result=appDbContext.Countries.ToList();
            await Task.Delay(0);
            return result;
        }
    }
}
