
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISchoolRoomReadRepository
    {
        public Task<IList<SchoolRoom>> GetListAsync();
        public Task<SchoolRoom?> GetAsync(string name);
    }
}
