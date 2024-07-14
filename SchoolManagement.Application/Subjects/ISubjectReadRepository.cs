

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Subjects
{
    public interface ISubjectReadRepository
    {
        public Task<Subject?> GetAsync(string frenchName);
        public Task<IList<Subject>> GetListAsync();
    }
}
