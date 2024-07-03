using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolGroups
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

        public async Task<List<SchoolGroup>> GetAllSchoolGroups()
        {
            return await readRepository.GetAllAsync();
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
