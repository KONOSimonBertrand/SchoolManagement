

using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public  class DisciplineService:IDisciplineService
    {
        private readonly IDisciplineReadRepository disciplineReadRepository;
        private readonly IDisciplineWriteRepository disciplineWriteRepository;
        public DisciplineService(IDisciplineRepository disciplineRepository)
        {
            disciplineReadRepository = disciplineRepository;
            disciplineWriteRepository = disciplineRepository;
        }

        public async Task<bool> CreateDiscipline(Discipline discipline)
        {
           return await disciplineWriteRepository.AddDisciplineAsync(discipline);
        }

        public async Task<bool> CreateDisciplineSubject(DisciplineSubject subject)
        {
            return await disciplineWriteRepository.AddDisciplineSubjectAsync(subject);
        }

        public async Task<bool> DeleteDiscipline(int disciplineId)
        {
            return await disciplineWriteRepository.DeleteDisciplineAsync(disciplineId);
        }

        public async Task<Discipline?> GetDiscipline(int enrollingId, int subjectId, DateTime date)
        {
            return await disciplineReadRepository.GetDisciplineAsync(enrollingId,subjectId,date);
        }

        public async Task<IList<Discipline>> GetDisciplineListByEnrolling(int enrollingId)
        {
            return await disciplineReadRepository.GetDisciplineListByEnrollingAsync(enrollingId);
        }
        public async Task<IList<Discipline>> GetDisciplineListBySchoolYear(int schoolYearId)
        {
            return await disciplineReadRepository.GetDisciplineListByEnrollingAsync(schoolYearId);
        }

        public async Task<DisciplineSubject?> GetDisciplineSubject(int subjectId)
        {
            return await disciplineReadRepository.GetDisciplineSubjectAsync(subjectId);
        }

        public async Task<IList<DisciplineSubject>> GetDisciplineSubjectList()
        {
            return await disciplineReadRepository.GetDisciplineSubjectListAsync();
        }

        public async Task<bool> UpdateDiscipline(Discipline discipline)
        {
            return await disciplineWriteRepository.UpdateDisciplineAsync(discipline);
        }

        public async Task<bool> UpdateDisciplineSubject(DisciplineSubject subject)
        {
            return await disciplineWriteRepository.UpdateDisciplineSubjectAsync(subject);
        }
    }
}
