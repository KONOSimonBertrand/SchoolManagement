using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolWriteRepository
    {
        public Task<bool> AddSchoolAsync(School school);
        public Task<bool> UpdateSchoolAsync(School school);
        public Task<bool> UpdateCodeAsync(int schoolId, string code);
        public Task<bool> UpdateSerialKeyAsync(int schoolId, string serialKey);
    }
}