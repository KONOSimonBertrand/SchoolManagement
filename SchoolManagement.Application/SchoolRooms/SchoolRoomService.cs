

using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public class SchoolRoomService : ISchoolRoomService
    {
        private readonly ISchoolRoomReadRepository schoolRoomReadRepository;
        private readonly ISchoolRoomWriteRepository schoolRoomWriteRepository;
        public SchoolRoomService(ISchoolRoomRepository schoolRoomRepository) { 
        schoolRoomReadRepository = schoolRoomRepository;
            schoolRoomWriteRepository = schoolRoomRepository;
        }
        public  async Task<bool> CreateSchoolRoom(SchoolRoom room)
        {
            return await schoolRoomWriteRepository.AddAsync(room);
        }

        public async Task<SchoolRoom?> GetSchoolRoom(string name)
        {
            return await schoolRoomReadRepository.GetAsync(name);
        }

        public async Task<IList<SchoolRoom>> GetSchoolRoomList()
        {
            return await schoolRoomReadRepository.GetListAsync();
        }

        public async  Task<bool> UpdateSchoolRoom(SchoolRoom room)
        {
           return await schoolRoomWriteRepository.UpdateAsync(room);
        }
    }
}
