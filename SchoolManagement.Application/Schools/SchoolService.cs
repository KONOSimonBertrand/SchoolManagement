

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
namespace SchoolManagement.Application
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolWriteRepository writeRepository;
        private readonly ISchoolReadRepository readRepository;
     
        public SchoolService(ISchoolRepository repository)
        {
            this.writeRepository = repository;
            this.readRepository = repository;
        }

        public async Task<bool> CreateSchoolAsync(School school)
        {
            var result=await writeRepository.AddSchoolAsync(school) ;
            await Task.Delay(0);
            return result;
        }

        public async Task<School?> GetLastSchooAsync()
        {
           var result= await readRepository.GetLastSchooAsync();
            await Task.Delay(0);
            return result;
        }

        public async Task<School?> GetSchoolAsync(string name)
        {
            var result=await readRepository.GetSchoolAsync(name);
            await Task.Delay(0);
            return result;
        }

        public async Task<List<School>> GetSchoolsAsync()
        {
            var result=await readRepository.GetSchoolsAsync();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateSchoolAsync(School school)
        {
           var isdone=await writeRepository.UpdateSchoolAsync(school) ;
            await Task.Delay(0);
            return isdone;
        }

        public async Task<bool> UpdateSerialKeyAsync(int schoolId, string serialKey)
        {
            var isDone=await writeRepository.UpdateSerialKeyAsync(schoolId, serialKey) ;
            await Task.Delay(0);
            return isDone;
        }
    }
}
