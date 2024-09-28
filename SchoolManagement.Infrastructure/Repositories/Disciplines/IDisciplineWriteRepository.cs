using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IDisciplineWriteRepository
    {
        Task<bool> AddDisciplineAsync(Discipline discipline);
        Task<bool> AddDisciplineSubjectAsync(DisciplineSubject subject);
        Task<bool> DeleteDisciplineAsync(int disciplineId);
        Task<bool> UpdateDisciplineAsync(Discipline discipline);
        Task<bool> UpdateDisciplineSubjectAsync(DisciplineSubject subject);
    }
}