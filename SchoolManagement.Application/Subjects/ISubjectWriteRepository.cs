

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Subjects
{
    public  interface ISubjectWriteRepository
    {
        public Task<bool> AddAsync(Subject subject);
        public Task<bool> UpdateAsync(Subject subject);
    }
}
