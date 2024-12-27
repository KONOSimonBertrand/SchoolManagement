using SchoolManagement.Core.Model;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Core.Repositories;

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
            return await readRepository.GetSchoolYearAsync(name);
        }

        //
        public async Task<List<SchoolYear>> GetSchoolYearList()
        {
            return await readRepository.GetSchoolYearListAsync();          
        }

        public async Task<bool> CreateSchoolYear(SchoolYear schoolYear)
        {
            return await writeRepository.AddSchoolYearAsync(schoolYear);
        }

        public async Task<bool> UpdateSchoolYear(SchoolYear schoolYear)
        {
            return await writeRepository.UpdateSchoolYearAsync(schoolYear);
        }

        public async Task<bool> ChangeSchoolYearStatus(SchoolYear schoolYear)
        {
            return await writeRepository.ChangeSchoolYearStatusAsync(schoolYear);
        }

        public async Task<SchoolYear?> GetLastSchoolYear()
        {
            return await readRepository.GetLastSchoolYearAsync();
        }

        public async Task<int> GetTotalSchoolYear()
        {
            return await readRepository.GetTotalSchoolYearAsync();
        }
    }
}
