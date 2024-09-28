

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IDisciplineService
    {
        public Task<bool> CreateDisciplineSubject(DisciplineSubject subject);
        public Task<bool> UpdateDisciplineSubject(DisciplineSubject subject);
        public Task<IList<DisciplineSubject>> GetDisciplineSubjectList();
        public Task<DisciplineSubject?> GetDisciplineSubject(int subjectId);

        public Task<bool> CreateDiscipline(Discipline discipline);
        public Task<bool> UpdateDiscipline(Discipline discipline);
        public Task<bool> DeleteDiscipline(int disciplineId);
        public Task<IList<Discipline>> GetDisciplineListByEnrolling(int enrollingId);
        public Task<IList<Discipline>> GetDisciplineListBySchoolYear(int schoolYearId);
        public Task<Discipline?> GetDiscipline(int enrollingId,int subjectId,DateTime date);
    }
}
