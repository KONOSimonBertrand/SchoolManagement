

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISchoolClassWriteRepository
    {
        public Task<bool> AddAsync(SchoolClass schoolClass);
        public Task<bool> UpdateAsync(SchoolClass schoolClass);
        public Task<bool> AddSubjectAsync(ClassSubject classSubject);
        public Task<bool> UpdateSubjectAsync(ClassSubject classSubject);
        public Task<bool> DeleteSubjectAsync(int classId,int subjectId, int bookId);
    }
}
