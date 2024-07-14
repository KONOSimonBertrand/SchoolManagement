using SchoolManagement.Core.Model;


namespace SchoolManagement.Application.SchoolClasses
{
    public class SchoolClassService : ISchoolClassService
    {
        private readonly ISchoolClassRepository classRepository;
        public SchoolClassService(ISchoolClassRepository classRepository) { 
        this.classRepository = classRepository;
        }
        public async Task<bool> CreateSchoolClass(SchoolClass schoolClass)
        {
           return await classRepository.AddAsync(schoolClass);
        }

        public async  Task<SchoolClass?> GetSchoolClass(string name)
        {
            return await classRepository.GetAsync(name);
        }

        public async Task<IList<SchoolClass>> GetSchoolClassList()
        {
            return await classRepository.GetListAsync();
        }

        public async Task<bool> UpdateSchoolClass(SchoolClass schoolClass)
        {
            return await classRepository.UpdateAsync(schoolClass);
        }
    }
}
