using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;


namespace SchoolManagement.Application
{
    public class SchoolClassService : ISchoolClassService
    {
        private readonly ISchoolClassReadRepository classReadRepository;
        private readonly ISchoolClassWriteRepository classWriteRepository;
        public SchoolClassService(ISchoolClassRepository classRepository) { 
        this.classReadRepository= classRepository;
         this.classWriteRepository= classRepository;
        }

        public async Task<bool> CreateClassSubject(ClassSubject ClassSubject)
        {
            return await classWriteRepository.AddSubjectAsync(ClassSubject);
        }

        public async Task<bool> CreateSchoolClass(SchoolClass schoolClass)
        {
           return await classWriteRepository.AddAsync(schoolClass);
        }

        public async Task<IList<ClassSubject>> GetClassSubjectList(int classId)
        {
            return await classReadRepository.GetSubjectListAsync(classId);
        }

        public async  Task<SchoolClass?> GetSchoolClass(string name)
        {
            return await classReadRepository.GetAsync(name);
        }

        public async Task<IList<SchoolClass>> GetSchoolClassList()
        {
            return await classReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateSchoolClass(SchoolClass schoolClass)
        {
            return await classWriteRepository.UpdateAsync(schoolClass);
        }
    }
}
