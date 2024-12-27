
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
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

        public Task<bool> AddAccountTransactionAsync(EmployeeAccountTransaction transaction)
        {
            throw new NotImplementedException();
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

        public Task<bool> AddNoteAsync(EmployeeNote note)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddEmployeePictureAsync(int employeeId, string urlPicture)
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

        public Task<bool> DeleteNoteAsync(int noteId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<EmployeeAccountTransaction>> GetAccountTransactionListAsync(int enrollingId)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee?> GetEmployeeAsync(string idNumber)
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

        public async Task<IList<Employee>> GetEmployeeListAsync()
        {
            var result=appDbContext.Employees.ToList();
            await Task.Delay(0);
            return result;
        }

        public Task<IList<EmployeeNote>> GetNoteListAsync(int enrollingId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<EmployeeRoom>> GetRoomListAsync(int enrollingId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<EmployeeSubject>> GetSubjectListAsync(int enrollingId)
        {
            throw new NotImplementedException();
        }

       

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
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

        public Task<bool> UpdateNoteAsync(EmployeeNote note)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetLastEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeAccountTransaction> GetLastAccountTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalAccountTransactionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
