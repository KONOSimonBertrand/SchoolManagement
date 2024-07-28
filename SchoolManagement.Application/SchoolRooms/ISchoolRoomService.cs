

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ISchoolRoomService
    {
        public Task<bool> CreateSchoolRoom(SchoolRoom room);
        public Task<bool> UpdateSchoolRoom(SchoolRoom room);
        public Task<SchoolRoom?> GetSchoolRoom(string name);
        public Task<IList<SchoolRoom>> GetSchoolRoomList();
    }
}
