using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IEmployeeReadRepository
    {
        public Task<Employee?> GetAsync(string IdNumber);
        Task<IList<EmployeeAttendance>> GetAttendanceListAsync(int enrollingId);
        public Task<EmployeeEnrolling?> GetEnrollingAsync(int employeeId, int schoolYearId);
        public Task<IList<EmployeeEnrolling>> GetEnrollingListAsync(int schoolYearId);
        public Task<IList<Employee>> GetListAsync();
        public Task<IList<EmployeeRoom>> GetRoomListAsync(int enrollingId);
        public Task<IList<EmployeeSubject>> GetSubjectListAsync(int enrollingId);
    }
}