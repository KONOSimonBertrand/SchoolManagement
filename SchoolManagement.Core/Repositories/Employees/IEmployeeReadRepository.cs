using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IEmployeeReadRepository
    {
        Task<IList<EmployeeAccountTransaction>> GetAccountTransactionListByEmployeeAsync(int employeeId,int schoolYearId);
        Task<IList<EmployeeAccountTransaction>> GetAccountTransactionListBySchoolYearAsync(int schoolYearId);
        public Task<Employee?> GetEmployeeAsync(string IdNumber);
        Task<IList<EmployeeAttendance>> GetAttendanceListByEmployeeAsync(int employeeId,int schoolYearId);
        Task<IList<EmployeeAttendance>> GetAttendanceListBySchoolYearAsync(int schoolYearId);
        public Task<EmployeeEnrolling?> GetEnrollingAsync(int employeeId, int schoolYearId);
        public Task<IList<EmployeeEnrolling>> GetEnrollingListAsync(int schoolYearId);
        Task<Employee?> GetLastEmployeeAsync();
        public Task<IList<Employee>> GetEmployeeListAsync();
        Task<IList<EmployeeNote>> GetNoteListByEmployeeAsync(int employeeId,int schoolYearId);
        Task<IList<EmployeeNote>> GetNoteListBySchoolYearAsync(int schoolYearId);
        public Task<IList<EmployeeRoom>> GetRoomListByEmployeeAsync(int employeeId, int schoolYearId);
        public Task<IList<EmployeeRoom>> GetRoomListBySchoolYearAsync(int schoolYearId);
        public Task<IList<EmployeeSubject>> GetSubjectListByEmployeeAsync(int employeeId,int schoolYearId);
        public Task<IList<EmployeeSubject>> GetSubjectListBySchoolYearAsync(int schoolYearId);
        public Task<int> GetTotalEmployeeAsync();
        Task<EmployeeAccountTransaction?> GetLastAccountTransactionAsync();
        Task<int> GetTotalAccountTransactionAsync();
    }
}