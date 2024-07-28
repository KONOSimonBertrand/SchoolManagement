

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISubjectReadRepository
    {
        public Task<Subject?> GetAsync(string frenchName);
        public Task<IList<Subject>> GetListAsync();
    }
}
