using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IEmployeeReadRepository
    {
        Task<IList<EmployeeAccountTransaction>> GetAccountTransactionListAsync(int enrollingId);
        public Task<Employee?> GetEmployeeAsync(string IdNumber);
        Task<IList<EmployeeAttendance>> GetAttendanceListAsync(int enrollingId);
        public Task<EmployeeEnrolling?> GetEnrollingAsync(int employeeId, int schoolYearId);
        public Task<IList<EmployeeEnrolling>> GetEnrollingListAsync(int schoolYearId);
        Task<Employee?> GetLastEmployeeAsync();
        public Task<IList<Employee>> GetEmployeeListAsync();
        Task<IList<EmployeeNote>> GetNoteListAsync(int enrollingId);
        public Task<IList<EmployeeRoom>> GetRoomListAsync(int enrollingId);
        public Task<IList<EmployeeSubject>> GetSubjectListAsync(int enrollingId);
        public Task<int> GetTotalEmployeeAsync();
        Task<EmployeeAccountTransaction?> GetLastAccountTransactionAsync();
        Task<int> GetTotalAccountTransactionAsync();
    }
}