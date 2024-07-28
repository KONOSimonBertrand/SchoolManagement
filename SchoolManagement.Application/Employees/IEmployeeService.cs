using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IEmployeeService
    {
        public Task<bool>CreateEmploye(Employee employee);
        public Task<bool> UpdateEmploye(Employee employee);
        public Task<string> GenerateEmployeeIdNumber();
        public Task<Employee?> GetEmployee(string IdNumber);
        public Task<IList<Employee>> GetEmployeeList();
    }
}