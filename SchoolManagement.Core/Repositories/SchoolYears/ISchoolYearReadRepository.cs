

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public  interface ISchoolYearReadRepository
    {
        public Task<List<SchoolYear>> GetSchoolYearListAsync();
        public Task<SchoolYear?> GetSchoolYearAsync(string name);
        Task<SchoolYear?> GetLastSchoolYearAsync();
        Task<int> GetTotalSchoolYearAsync();
    }
}
