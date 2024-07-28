using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IModuleService
    {
        public Task<Module?> GetModule(string name);
        public Task<IList<Module>> GetModuleList();
    }
}