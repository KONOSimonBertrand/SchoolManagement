using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IStudentReadRepository
    {
        Task<Student?> GetLastStudentAsync();
        Task<Student?> GetStudentAsync(string idNumber);
        Task<List<Student>> GetStudentListAsync();
    }
}