

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeReadRepository employeeReadRepository;
        private readonly IEmployeeWriteRepository employeeWriteRepository;
        private readonly ISchoolYearReadRepository schoolYearReadRepository;
        private readonly IGenerateIdNumberService generateIdNumberService;
        public EmployeeService(IEmployeeRepository employeeRepository, ISchoolYearRepository schoolYearRepository, IGenerateIdNumberService generateIdNumberService)
        {
            this.employeeReadRepository = employeeRepository;
            this.employeeWriteRepository = employeeRepository;
            this.schoolYearReadRepository = schoolYearRepository;
            this.generateIdNumberService = generateIdNumberService;
        }

        public async Task<bool> CreateEmploye(Employee employee)
        {
            return await employeeWriteRepository.AddAsync(employee);
        }

        public async Task<string> GenerateEmployeeIdNumber()
        {
            string idNumber;
            var lastEmployee = await GetLastEmployee();
            SchoolYear? lastSchoolYear = await schoolYearReadRepository.GetLastSchoolYearAsync();
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
            idNumber = generateIdNumberService.GenerateNextIdNumberWithFourDigit('P', lastNumber, year);
            await Task.Delay(0);
            return idNumber;
        }


        public async Task<Employee?> GetEmployee(string idNumber)
        {
            return await employeeReadRepository.GetEmployeeAsync(idNumber);
        }
        public async Task<Employee?> GetLastEmployee()
        {
            return await employeeReadRepository.GetLastEmployeeAsync();
        }
        public async Task<IList<Employee>> GetEmployeeList()
        {
            return await employeeReadRepository.GetEmployeeListAsync();
        }
        public async Task<int> GetTotalEmployee()
        {
            return await employeeReadRepository.GetTotalEmployeeAsync();
        }
        public async Task<bool> UpdateEmploye(Employee employee)
        {
            return await employeeWriteRepository.UpdateEmployeeAsync(employee);
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
            return await employeeReadRepository.GetEnrollingAsync(employeeId, schoolYearId);
        }

        public async Task<bool> UpdateEmployeeEnrolling(EmployeeEnrolling employeeEnrolling)
        {
            return await employeeWriteRepository.UpdateEnrollingAsync(employeeEnrolling);
        }

        public async Task<bool> SaveEmployeePicture(int employeeId, string urlPicture)
        {
            return await employeeWriteRepository.AddEmployeePictureAsync(employeeId, urlPicture);
        }
        public async Task<bool> SaveEmployeeEnrollingPicture(int enrollingId, string urlPicture)
        {
            return await employeeWriteRepository.AddEnrollingPictureAsync(enrollingId, urlPicture);
        }

        public Task<bool> AddRoomList(int enrollingId, IList<EmployeeRoom> roomList)
        {
            return employeeWriteRepository.AddRoomListAsync(enrollingId, roomList);
        }

        public async Task<IList<EmployeeRoom>> GetRoomList(int enrollingId)
        {
            return await employeeReadRepository.GetRoomListAsync(enrollingId);
        }

        public async Task<bool> AddSubjectList(int enrollingId, IList<EmployeeSubject> subjectList)
        {
            return await employeeWriteRepository.AddSubjectListAsync(enrollingId, subjectList);
        }

        public async Task<IList<EmployeeSubject>> GetSubjectList(int enrollingId)
        {
            return await employeeReadRepository.GetSubjectListAsync(enrollingId);
        }

        public async Task<bool> AddAttendance(EmployeeAttendance attendance)
        {
            return await employeeWriteRepository.AddAttendanceAsync(attendance);
        }

        public async Task<bool> UpdateAttendance(EmployeeAttendance attendance)
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

        public async Task<bool> AddNote(EmployeeNote note)
        {
            return await employeeWriteRepository.AddNoteAsync(note);
        }

        public async Task<bool> UpdateNote(EmployeeNote note)
        {
            return await employeeWriteRepository.UpdateNoteAsync(note);
        }

        public async Task<bool> DeleteNote(int noteId)
        {
            return await employeeWriteRepository.DeleteNoteAsync(noteId);
        }

        public async Task<IList<EmployeeNote>> GetNoteList(int enrollingId)
        {
            return await employeeReadRepository.GetNoteListAsync(enrollingId);
        }

        public async Task<string> GenerateAccountTransactionIdNumber()
        {
            string idNumber;
            var lastTransanction = employeeReadRepository.GetLastAccountTransactionAsync().Result;
            var lastSchoolYear = schoolYearReadRepository.GetLastSchoolYearAsync().Result;
            int lastNumber = 0;
            int year = DateTime.Now.Year;
            if (lastTransanction != null)
            {
                lastNumber = int.Parse(lastTransanction.TransactionId.Substring(3, 5));
            }
            if (lastSchoolYear != null)
            {
                year = int.Parse(lastSchoolYear.Name.Substring(0, 4));
            }
            lastNumber++;
            idNumber = generateIdNumberService.GenerateNextIdNumberWithFiveDigit('T', lastNumber, year);
            await Task.Delay(0);
            return idNumber;
        }
        public async Task<bool> AddAccountTransaction(EmployeeAccountTransaction transaction)
        {
            return await employeeWriteRepository.AddAccountTransactionAsync(transaction);
        }

        public async Task<IList<EmployeeAccountTransaction>> GetAccountTransactionList(int enrollingId)
        {
            return await employeeReadRepository.GetAccountTransactionListAsync(enrollingId);
        }

        public async Task<EmployeeAccountTransaction?> GetLastAccountTransaction()
        {
            return await employeeReadRepository.GetLastAccountTransactionAsync();
        }

        public async Task<int> GetTotalAccountTransaction()
        {
            return await employeeReadRepository.GetTotalAccountTransactionAsync();
        }
    }
}
