using SchoolManagement.Core.Model;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public class SchoolYearService : ISchoolYearService
    {
        private readonly ISchoolYearReadRepository readRepository;
        private readonly ISchoolYearWriteRepository writeRepository;
        public SchoolYearService(ISchoolYearRepository  repository)
        {
           readRepository=repository;
            writeRepository=repository;
        }
        public async Task<SchoolYear?> GetSchoolYear(string name)
        {
            return await readRepository.GetAsync(name);
        }

        //
        public async Task<List<SchoolYear>> GetSchoolYearList()
        {
            return await readRepository.GetListAsync();          
        }

        public async Task<bool> CreateSchoolYear(SchoolYear schoolYear)
        {
            return await writeRepository.AddAsync(schoolYear);
        }

        public async Task<bool> UpdateSchoolYear(SchoolYear schoolYear)
        {
            return await writeRepository.UpdateAsync(schoolYear);
        }

        public async Task<bool> ChangeSchoolYearStatus(SchoolYear schoolYear)
        {
            return await writeRepository.ChangeStatusAsync(schoolYear);
        }
    }
}
