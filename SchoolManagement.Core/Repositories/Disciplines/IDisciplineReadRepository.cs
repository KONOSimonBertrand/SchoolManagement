using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IDisciplineReadRepository
    {
        Task<Discipline?> GetDisciplineAsync(int studentId, int subjectId, DateTime date);
        Task<IList<Discipline>> GetDisciplineListByStudentAsync(int studentId,int schoolYearId);
        Task<IList<Discipline>> GetDisciplineListByClassAsync(int classId, int schoolYearId);
        Task<IList<Discipline>> GetDisciplineListBySchoolYearAsync(int schoolYearId);
        Task<DisciplineSubject?> GetDisciplineSubjectAsync(int subjectId);
        Task<IList<DisciplineSubject>> GetDisciplineSubjectListAsync();
    }
}