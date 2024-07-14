
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolGroups
{
    public interface ISchoolGroupReadRepository
    {
        public Task<List<SchoolGroup>> GetListAsync();
        public Task<SchoolGroup?> GetAsync(string name);
    }
}
