

using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;
using System.Xml.Linq;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextModuleRepository : IModuleRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextModuleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Module?> GetAsync(string name)
        {
            var result=appDbContext.Modules.FirstOrDefault(m => m.Name == name);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Module>> GetListAsync()
        {
            var result = appDbContext.Modules.ToList();
            await Task.Delay(0);
            return result;
        }
    }
}
