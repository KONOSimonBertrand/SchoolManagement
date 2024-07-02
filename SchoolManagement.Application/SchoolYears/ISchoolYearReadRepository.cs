

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolYears
{
    public  interface ISchoolYearReadRepository
    {
        public Task<List<SchoolYear>> GetAllAsync();
        public Task<SchoolYear> GetSchoolYear(string name);
    }
}
