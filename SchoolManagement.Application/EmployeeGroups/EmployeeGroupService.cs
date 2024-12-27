

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class EmployeeGroupService : IEmployeeGroupService
    {
        private readonly IEmployeeGroupReadRepository employeeGroupReadRepository;
        private readonly IEmployeeGroupWriteRepository employeeGroupWriteRepository;
        public EmployeeGroupService(IEmployeeGroupRepository employeeGroupRepository)
        {
            this.employeeGroupReadRepository = employeeGroupRepository;
            this.employeeGroupWriteRepository = employeeGroupRepository;
        }

        public async Task<bool> CreateEmployeeGroup(EmployeeGroup group)
        {
            return await  employeeGroupWriteRepository.AddAsync(group);
        }

        public async Task<EmployeeGroup?> GetEmployeeGroup(string name)
        {
            return await employeeGroupReadRepository.GetAsync(name);
        }

        public async Task<IList<EmployeeGroup>> GetEmployeeGroupList()
        {
           return await employeeGroupReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateEmployeeGroup(EmployeeGroup group)
        {
            return await employeeGroupWriteRepository.UpdateAsync(group);
        }
    }
}
