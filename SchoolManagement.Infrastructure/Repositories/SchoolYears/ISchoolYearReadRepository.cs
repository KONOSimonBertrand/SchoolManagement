

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public  interface ISchoolYearReadRepository
    {
        public Task<List<SchoolYear>> GetListAsync();
        public Task<SchoolYear?> GetAsync(string name);
    }
}
