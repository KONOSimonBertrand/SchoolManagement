

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllAsync();
    }
}
