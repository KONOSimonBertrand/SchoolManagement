
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextEmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.Employees.Add(employee);
            var result=appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public Task<bool> AddAttendanceAsync(EmployeeAttendance attendance)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddEnrollingAsync(EmployeeEnrolling enrolling)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddEnrollingPictureAsync(int enrollingId, string urlPicture)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddPictureAsync(int employeeId, string urlPicture)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRoomListAsync(int enrollingId, IList<EmployeeRoom> roomList)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddSubjectListAsync(int enrollingId, IList<EmployeeRoom> roomList)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddSubjectListAsync(int enrollingId, IList<EmployeeSubject> subjectList)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAttendanceAsync(int attendanceId)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee?> GetAsync(string idNumber)
        {
            var result = appDbContext.Employees.FirstOrDefault(x=>x.IdNumber==idNumber);
            await Task.Delay(0);
            return result;
        }

        public Task<IList<EmployeeAttendance>> GetAttendanceListAsync(int enrollingId)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeEnrolling?> GetEnrollingAsync(int employeeId, int schoolYearId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<EmployeeEnrolling>> GetEnrollingListAsync(int schoolYearId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Employee>> GetListAsync()
        {
            var result=appDbContext.Employees.ToList();
            await Task.Delay(0);
            return result;
        }

        public Task<IList<EmployeeRoom>> GetRoomListAsync(int enrollingId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<EmployeeSubject>> GetSubjectListAsync(int enrollingId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.Employees.Update(employee);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public Task<bool> UpdateAttendanceAsync(EmployeeAttendance attendance)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEnrollingAsync(EmployeeEnrolling enrolling)
        {
            throw new NotImplementedException();
        }
    }
}
