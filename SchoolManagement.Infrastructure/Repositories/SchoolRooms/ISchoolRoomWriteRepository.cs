
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISchoolRoomWriteRepository
    {
        public Task<bool> AddAsync(SchoolRoom room);
        public Task<bool> UpdateAsync(SchoolRoom room);
    }
}
