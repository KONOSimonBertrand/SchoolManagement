

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public  interface ISubjectGroupWriteRepository
    {
        public Task<bool> AddAsync(SubjectGroup subjectGroup);
        public Task<bool> UpdateAsync(SubjectGroup subjectGroup);
    }
}
