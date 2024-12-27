
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ISchoolClassService
    {
        public Task<bool> CreateSchoolClass(SchoolClass schoolClass);
        public Task<bool> CreateClassSubject(ClassSubject ClassSubject);
        public Task<bool> UpdateClassSubject(ClassSubject ClassSubject);
        public Task<bool> UpdateSchoolClass(SchoolClass schoolClass);
        public Task<bool> DeleteClassSubject(int classId,int subjectId, int bookId);
        public Task<IList<SchoolClass>> GetSchoolClassList();
        public Task<IList<ClassSubject>> GetClassSubjectList();
        public Task<IList<ClassSubject>> GetClassSubjectList(int classId);
        public Task<SchoolClass?> GetSchoolClass(string name);
        public Task<ClassSubject?> GetClassSubject(int classId,int subjectId,int bookId);
    }
}
