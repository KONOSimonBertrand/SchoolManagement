
using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolRoomReadRepository
    {
        public Task<IList<SchoolRoom>> GetListAsync();
        public Task<SchoolRoom?> GetAsync(string name);
    }
}
