

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SubjectGroups
{
    public  interface ISubjectGroupReadRepository
    {
        public Task<SubjectGroup?> GetAsync(string frenchName);
        public Task<IList<SubjectGroup>> GetListAsync();
    }
}
