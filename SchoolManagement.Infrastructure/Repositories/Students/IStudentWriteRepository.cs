using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IStudentWriteRepository
    {
        Task<bool> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
    }
}