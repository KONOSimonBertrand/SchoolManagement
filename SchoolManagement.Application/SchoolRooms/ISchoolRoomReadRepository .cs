
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolRooms
{
    public interface ISchoolRoomReadRepository
    {
        public Task<IList<SchoolRoom>> GetListAsync();
        public Task<SchoolRoom?> GetAsync(string name);
    }
}
