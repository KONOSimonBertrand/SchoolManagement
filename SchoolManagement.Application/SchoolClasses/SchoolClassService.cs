using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;


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

        public async Task<bool> DeleteClassSubject(int classId, int subjectId, int bookId)
        {
            return await classWriteRepository.DeleteSubjectAsync(classId, subjectId,bookId);
        }

        public async Task<ClassSubject?> GetClassSubject(int classId, int subjectId, int bookId)
        {
            return await classReadRepository.GetSubjectAsync(classId, subjectId, bookId);
        }

        public async Task<IList<ClassSubject>> GetClassSubjectList()
        {
            return await classReadRepository.GetSubjectListAsync();
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

        public async Task<bool> UpdateClassSubject(ClassSubject ClassSubject)
        {
           return await classWriteRepository.UpdateSubjectAsync(ClassSubject);
        }

        public async Task<bool> UpdateSchoolClass(SchoolClass schoolClass)
        {
            return await classWriteRepository.UpdateAsync(schoolClass);
        }
    }
}
