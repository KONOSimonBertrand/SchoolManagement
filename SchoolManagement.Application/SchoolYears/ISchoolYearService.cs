using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolYears
{
    public  interface ISchoolYearService
    {
        public Task<bool> CreateSchoolYear(SchoolYear schoolYear);
        public Task<bool> UpdateSchoolYear(SchoolYear schoolYear);
        public Task<List<SchoolYear>> GetAllSchoolYears();
        public Task<SchoolYear?> GetSchoolYear(string name);
    }
}
