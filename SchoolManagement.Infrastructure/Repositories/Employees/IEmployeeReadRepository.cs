using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IEmployeeReadRepository
    {
        public Task<Employee?> GetAsync(string IdNumber);
        public Task<IList<Employee>> GetListAsync();
    }
}