using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ISchoolService
    {
        public Task<bool> CreateSchoolAsync(School school);
        public Task<bool> UpdateSchoolAsync(School school);
        public Task<bool> UpdateSerialKeyAsync(int schoolId, string serialKey);
        public Task<List<School>> GetSchoolsAsync();
        public Task<School?> GetSchoolAsync(string name);
        public Task<School?> GetLastSchooAsync();
    }
}