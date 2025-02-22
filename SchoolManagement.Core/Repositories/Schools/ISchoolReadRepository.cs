using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolReadRepository
    {
        public Task<List<School>> GetSchoolsAsync();
        public Task<School?> GetSchoolAsync(string name);
        public Task<School?> GetLastSchooAsync();
    }
}