

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public  interface ISubjectGroupReadRepository
    {
        public Task<SubjectGroup?> GetAsync(string frenchName);
        public Task<IList<SubjectGroup>> GetListAsync();
    }
}
