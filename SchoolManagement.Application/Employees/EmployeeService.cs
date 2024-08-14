

using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeReadRepository employeeReadRepository;
        private readonly IEmployeeWriteRepository employeeWriteRepository;
        private readonly ISchoolYearReadRepository schoolYearReadRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, ISchoolYearRepository schoolYearRepository)
        {
            this.employeeReadRepository = employeeRepository;
            this.employeeWriteRepository = employeeRepository;
            this.schoolYearReadRepository = schoolYearRepository;
        }

        public async Task<bool> CreateEmploye(Employee employee)
        {
            return await employeeWriteRepository.AddAsync(employee);
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
            return await employeeWriteRepository.UpdateAsync(employee);
        }

        public async Task<bool> CreateEmployeeEnrolling(EmployeeEnrolling employeeEnrolling)
        {
            return await employeeWriteRepository.AddEnrollingAsync(employeeEnrolling);
        }

        public async Task<IList<EmployeeEnrolling>> GetEmployeeEnrollingList(int schoolYearId)
        {
           return await employeeReadRepository.GetEnrollingListAsync(schoolYearId); 
        }

        public async Task<EmployeeEnrolling?> GetEmployeeEnrolling(int employeeId, int schoolYearId)
        {
            return await employeeReadRepository.GetEnrollingAsync(employeeId,schoolYearId);
        }

        public async Task<bool> UpdateEmployeeEnrolling(EmployeeEnrolling employeeEnrolling)
        {
            return await employeeWriteRepository.UpdateEnrollingAsync(employeeEnrolling);
        }

        public async  Task<bool> SaveEmployeePicture(int employeeId,string urlPicture)
        {
           return await employeeWriteRepository.AddPictureAsync(employeeId,urlPicture);
        }
        public async Task<bool> SaveEmployeeEnrollingPicture(int enrollingId, string urlPicture)
        {
            return await employeeWriteRepository.AddEnrollingPictureAsync(enrollingId, urlPicture);
        }

        public Task<bool> AddRoomList(int enrollingId, IList<EmployeeRoom> roomList)
        {
            return employeeWriteRepository.AddRoomListAsync(enrollingId,roomList);
        }

        public async Task<IList<EmployeeRoom>> GetRoomList(int enrollingId)
        {
            return await employeeReadRepository.GetRoomListAsync(enrollingId);
        }

        public async Task<bool> AddSubjectList(int enrollingId, IList<EmployeeSubject> subjectList)
        {
            return await  employeeWriteRepository.AddSubjectListAsync(enrollingId,subjectList);
        }

        public async Task<IList<EmployeeSubject>> GetSubjectList(int enrollingId)
        {
            return await employeeReadRepository.GetSubjectListAsync(enrollingId);
        }

        public async Task<bool> AddAttendance(EmployeeAttendance attendance)
        {
           return await employeeWriteRepository.AddAttendanceAsync(attendance);
        }

        public async  Task<bool> UpdateAttendance(EmployeeAttendance attendance)
        {
            return await employeeWriteRepository.UpdateAttendanceAsync(attendance);
        }

        public async Task<bool> DeleteAttendance(int attendanceId)
        {
            return await employeeWriteRepository.DeleteAttendanceAsync(attendanceId);
        }

        public async Task<IList<EmployeeAttendance>> GetAttendanceList(int enrollingId)
        {
            return await employeeReadRepository.GetAttendanceListAsync(enrollingId);
        }
    }
}
