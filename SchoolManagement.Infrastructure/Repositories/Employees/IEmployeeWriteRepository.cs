using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IEmployeeWriteRepository
    {
        public Task<bool> AddAsync(Employee employee);
        public Task<bool> AddEnrollingAsync(EmployeeEnrolling enrolling);
        public Task<bool> UpdateEnrollingAsync(EmployeeEnrolling enrolling);
        public Task<bool> UpdateAsync(Employee employee);
        public Task<bool> AddPictureAsync(int employeeId,string urlPicture);
        public Task<bool> AddEnrollingPictureAsync(int enrollingId, string urlPicture);
        public Task<bool> AddRoomListAsync(int enrollingId, IList<EmployeeRoom> roomList);
        public Task<bool> AddSubjectListAsync(int enrollingId, IList<EmployeeSubject> subjectList);
        Task<bool> AddAttendanceAsync(EmployeeAttendance attendance);
        Task<bool> UpdateAttendanceAsync(EmployeeAttendance attendance);
        Task<bool> DeleteAttendanceAsync(int attendanceId);
    }
}