
using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolGroupReadRepository
    {
        public Task<List<SchoolGroup>> GetListAsync();
        public Task<SchoolGroup?> GetAsync(string name);
    }
}
