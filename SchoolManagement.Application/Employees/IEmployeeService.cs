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
        public Task<bool>AddRoomList(int employeeId,int schoolYearId,IList<EmployeeRoom> roomList);
        public Task<IList<EmployeeRoom>> GetRoomListByEmployee(int employeeId,int schoolYearId);
        public Task<IList<EmployeeRoom>> GetRoomListBySchoolYear(int schoolYearId);
        public Task<bool> AddSubjectList(int employeeId,int schoolYearId, IList<EmployeeSubject> subjectList);
        public Task<IList<EmployeeSubject>> GetSubjectListByEmployee(int employeeId,int schoolYearId);
        public Task<IList<EmployeeSubject>> GetSubjectListBySchoolYear(int schoolYearId);
        public Task<bool> AddAttendance(EmployeeAttendance attendance);
        public Task<bool> UpdateAttendance(EmployeeAttendance attendance);
        public Task<bool> DeleteAttendance(int attendanceId);
        public Task<IList<EmployeeAttendance>> GetAttendanceListByEmployee(int employeeId,int schoolYearId);
        public Task<IList<EmployeeAttendance>> GetAttendanceListBySchoolYear(int schoolYearId);
        public Task<bool> AddNote(EmployeeNote note);
        public Task<bool> UpdateNote(EmployeeNote note);
        public Task<bool> DeleteNote(int noteId);
        public Task<IList<EmployeeNote>> GetNoteListByEmployee(int employeeId,int schoolYearId);
        public Task<IList<EmployeeNote>> GetNoteListBySchoolYear(int schoolYearId);
        public Task<string> GenerateAccountTransactionIdNumber();
        public Task<bool> AddAccountTransaction(EmployeeAccountTransaction transaction);
        public Task<IList<EmployeeAccountTransaction>> GetAccountTransactionListByEmployee(int employeeId,int schoolYearId);
        public Task<IList<EmployeeAccountTransaction>> GetAccountTransactionListBySchoolYear(int schoolYearId);
        public Task<EmployeeAccountTransaction?> GetLastAccountTransaction();
        public Task<int> GetTotalAccountTransaction();
    }
}