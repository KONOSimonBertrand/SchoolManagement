using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IEmployeeService
    {
        public Task<bool>CreateEmploye(Employee employee);
        public Task<bool> UpdateEmploye(Employee employee);
        public Task<string> GenerateEmployeeIdNumber();
        public Task<Employee?> GetEmployee(string IdNumber);
        public Task<Employee?> GetLastEmployee();
        public Task<int> GetTotalEmployee();
        public Task<IList<Employee>> GetEmployeeList();
        public Task<bool> CreateEmployeeEnrolling(EmployeeEnrolling employeeEnrolling);
        public Task<bool> UpdateEmployeeEnrolling(EmployeeEnrolling employeeEnrolling);
        public Task<IList<EmployeeEnrolling>> GetEmployeeEnrollingList(int schoolYearId);
        public Task<EmployeeEnrolling?> GetEmployeeEnrolling(int employeeId,int schoolYearId);
        public Task<bool> SaveEmployeePicture(int employeeId,string  urlPicture);
        public Task<bool> SaveEmployeeEnrollingPicture(int enrollingId, string urlPicture);
        public Task<bool>AddRoomList(int enrollingId,IList<EmployeeRoom> roomList);
        public Task<IList<EmployeeRoom>> GetRoomList(int enrollingId);
        public Task<bool> AddSubjectList(int enrollingId, IList<EmployeeSubject> subjectList);
        public Task<IList<EmployeeSubject>> GetSubjectList(int enrollingId);
        public Task<bool> AddAttendance(EmployeeAttendance attendance);
        public Task<bool> UpdateAttendance(EmployeeAttendance attendance);
        public Task<bool> DeleteAttendance(int attendanceId);
        public Task<IList<EmployeeAttendance>> GetAttendanceList(int enrollingId);
        public Task<bool> AddNote(EmployeeNote note);
        public Task<bool> UpdateNote(EmployeeNote note);
        public Task<bool> DeleteNote(int noteId);
        public Task<IList<EmployeeNote>> GetNoteList(int enrollingId);
        public Task<string> GenerateAccountTransactionIdNumber();
        public Task<bool> AddAccountTransaction(EmployeeAccountTransaction transaction);
        public Task<IList<EmployeeAccountTransaction>> GetAccountTransactionList(int enrollingId);
        public Task<EmployeeAccountTransaction?> GetLastAccountTransaction();
        public Task<int> GetTotalAccountTransaction();
    }
}