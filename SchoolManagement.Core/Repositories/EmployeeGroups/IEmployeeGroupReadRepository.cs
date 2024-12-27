using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IEmployeeGroupReadRepository
    {
        public Task<IList<EmployeeGroup>> GetListAsync();
        public Task<EmployeeGroup?> GetAsync(string name);
    }
}