using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IEmployeeWriteRepository
    {
        public Task<bool> AddAsync(Employee employee);
        public Task<bool> UpdateAsync(Employee employee);
    }
}