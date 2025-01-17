﻿
using SchoolManagement.Core.Model;
namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolClassReadRepository
    {
        public Task<IList<SchoolClass>>GetListAsync();
        public Task<SchoolClass?> GetAsync(string name);
        public Task<IList<ClassSubject>> GetSubjectListAsync();
        public Task<IList<ClassSubject>> GetSubjectListAsync(int classId);
        public Task<ClassSubject> GetSubjectAsync(int classId,int subjectId, int bookId);
    }
}
