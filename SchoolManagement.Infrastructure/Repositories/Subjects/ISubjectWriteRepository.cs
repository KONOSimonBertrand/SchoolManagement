

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public  interface ISubjectWriteRepository
    {
        public Task<bool> AddAsync(Subject subject);
        public Task<bool> UpdateAsync(Subject subject);
    }
}
