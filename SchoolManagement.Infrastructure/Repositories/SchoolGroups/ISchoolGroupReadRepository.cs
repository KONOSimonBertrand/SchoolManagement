
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISchoolGroupReadRepository
    {
        public Task<List<SchoolGroup>> GetListAsync();
        public Task<SchoolGroup?> GetAsync(string name);
    }
}
