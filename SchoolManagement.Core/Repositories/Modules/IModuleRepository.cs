
using SchoolManagement.Core.Model;
namespace SchoolManagement.Core.Repositories
{
    public  interface IModuleRepository 
    {

        public Task<IList<Module>> GetListAsync();
        public Task<Module?> GetAsync(string name);
    }
}