
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ISchoolClassService
    {
        public Task<bool> CreateSchoolClass(SchoolClass schoolClass);
        public Task<bool> CreateClassSubject(ClassSubject ClassSubject);
        public Task<bool> UpdateSchoolClass(SchoolClass schoolClass);
        public Task<IList<SchoolClass>> GetSchoolClassList();
        public Task<IList<ClassSubject>> GetClassSubjectList(int classId);
        public Task<SchoolClass?> GetSchoolClass(string name);
    }
}
