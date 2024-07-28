
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository moduleRepository;
        public ModuleService(IModuleRepository moduleRepository)
        {
            this.moduleRepository = moduleRepository;
        }

        public async Task<Module?> GetModule(string name)
        {
            return await moduleRepository.GetAsync(name);
        }

        public async Task<IList<Module>> GetModuleList()
        {
            return await moduleRepository.GetListAsync();
        }
    }
}
