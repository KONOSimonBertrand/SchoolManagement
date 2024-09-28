using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IDisciplineReadRepository
    {
        Task<Discipline?> GetDisciplineAsync(int enrollingId, int subjectId, DateTime date);
        Task<IList<Discipline>> GetDisciplineListByEnrollingAsync(int enrollingId);
        Task<DisciplineSubject?> GetDisciplineSubjectAsync(int subjectId);
        Task<IList<DisciplineSubject>> GetDisciplineSubjectListAsync();
    }
}