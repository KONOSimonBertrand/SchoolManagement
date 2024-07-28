

using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;
using System.Reflection.PortableExecutable;

namespace SchoolManagement.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeReadRepository employeeReadRepository;
        private readonly IEmployeeWriteRepository employeerWriteRepository;
        private readonly ISchoolYearReadRepository schoolYearReadRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, ISchoolYearRepository schoolYearRepository)
        {
            this.employeeReadRepository = employeeRepository;
            this.employeerWriteRepository = employeeRepository;
            this.schoolYearReadRepository = schoolYearRepository;
        }

        public async Task<bool> CreateEmploye(Employee employee)
        {
            return await employeerWriteRepository.AddAsync(employee);
        }

        public async Task<string> GenerateEmployeeIdNumber()
        {
            string idNumber = string.Empty;
            var employeeList = await employeeReadRepository.GetListAsync();
            var yearList = await schoolYearReadRepository.GetListAsync();
            var lastEmployee = employeeList.OrderBy(x => x.Id).LastOrDefault();
            var lastSchoolYear = yearList.Where(x => x.IsClosed == false).OrderBy(x => x.Id).LastOrDefault();
            int lastNumber = 0;
            int year = DateTime.Now.Year;
            if (lastEmployee != null)
            {
                lastNumber = int.Parse(lastEmployee.IdNumber.Substring(3, 4));
            }
            if (lastSchoolYear != null)
            {
                year = int.Parse(lastSchoolYear.Name.Substring(0, 4));
            }
            lastNumber++;
            idNumber = GenerateNextIdNumber(lastNumber, year);
            return idNumber;
        }
        private string GenerateNextIdNumber(int lastNumber, int year)
        {
            if (lastNumber.ToString().Length == 1)
            {

                return year.ToString().Substring(2, 2) + "P000" + lastNumber;
            }
            if (lastNumber.ToString().Length == 2)
            {

                return year.ToString().Substring(2, 2) + "P00" + lastNumber;
            }
            if (lastNumber.ToString().Length == 3)
            {

                return year.ToString().Substring(2, 2) + "P0" + lastNumber;
            }
            if (lastNumber.ToString().Length == 4)
            {

                return year.ToString().Substring(2, 2) + "P" + lastNumber;
            }
            if (lastNumber.ToString().Length > 4)
            {

                return GenerateNextIdNumber(1, year + 1);
            }
            return year.ToString().Substring(2, 2) + "P0000";
        }

        public async Task<Employee?> GetEmployee(string idNumber)
        {
            return await employeeReadRepository.GetAsync(idNumber);
        }

        public async Task<IList<Employee>> GetEmployeeList()
        {
            return await employeeReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateEmploye(Employee employee)
        {
            return await employeerWriteRepository.UpdateAsync(employee);
        }
    }
}
