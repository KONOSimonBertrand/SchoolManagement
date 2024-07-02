using SchoolManagement.Core.Model;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.SchoolYears
{
    public class SchoolYearService : ISchoolYearService
    {
        private readonly ISchoolYearReadRepository readRepository;
        private readonly ISchoolYearWriteRepository writeRepository;
        private readonly ClientApp clientApp;
        private readonly IConfiguration configuration;
        public SchoolYearService(ISchoolYearRepository  repository, IConfiguration configuration , ClientApp clientApp)
        {
           readRepository=repository;
            writeRepository=repository;
           this.clientApp = clientApp;
           this.configuration = configuration;
        }
        public async Task<SchoolYear> GetSchoolYear(string name)
        {
            return await readRepository.GetSchoolYear(name);
        }

        //
        public async Task<List<SchoolYear>> GetAllSchoolYears()
        {
            return await readRepository.GetAllAsync();          
        }

        public async Task<bool> CreateSchoolYear(SchoolYear schoolYear)
        {
            return await writeRepository.AddAsync(schoolYear);
        }

        public async Task<bool> UpdateSchoolYear(SchoolYear schoolYear)
        {
            return await writeRepository.UpdateAsync(schoolYear);
        }
    }
}
