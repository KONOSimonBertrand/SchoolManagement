using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IEmployeeGroupService
    {
        public Task<bool> CreateEmployeeGroup(EmployeeGroup group);
        public Task<bool> UpdateEmployeeGroup(EmployeeGroup group);
        public Task<IList<EmployeeGroup>> GetEmployeeGroupList();
        public Task<EmployeeGroup?> GetEmployeeGroup(string name);
    }
}