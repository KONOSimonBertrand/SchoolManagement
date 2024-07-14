
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolRooms
{
    public interface ISchoolRoomWriteRepository
    {
        public Task<bool> AddAsync(SchoolRoom room);
        public Task<bool> UpdateAsync(SchoolRoom room);
    }
}
