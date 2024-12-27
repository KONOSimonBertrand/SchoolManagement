using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class SchoolGroupService : ISchoolGroupService
    {
        
        private readonly ISchoolGroupReadRepository readRepository;
        private readonly ISchoolGroupWriteRepository writeRepository;
        public SchoolGroupService(ISchoolGroupRepository repository) { 
            this.readRepository = repository;
            this.writeRepository = repository;
        }
        public async Task<bool> CreateSchoolGroup(SchoolGroup schoolGroup)
        {
            return  await writeRepository.AddAsync(schoolGroup);
        }

        public async Task<List<SchoolGroup>> GetSchoolGroupList()
        {
            return await readRepository.GetListAsync();
        }

        public async Task<SchoolGroup?> GetSchoolGroup(string name)
        {
            return await readRepository.GetAsync(name);
        }

        public async Task<bool> UpdateSchoolGroup(SchoolGroup schoolGroup)
        {
            return await writeRepository.UpdateAsync(schoolGroup);
        }
    }
}
