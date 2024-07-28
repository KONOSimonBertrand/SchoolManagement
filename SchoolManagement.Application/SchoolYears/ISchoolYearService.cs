using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public  interface ISchoolYearService
    {
        public Task<bool> CreateSchoolYear(SchoolYear schoolYear);
        public Task<bool> UpdateSchoolYear(SchoolYear schoolYear);
        public Task<bool> ChangeSchoolYearStatus(SchoolYear schoolYear);
        public Task<List<SchoolYear>> GetSchoolYearList();
        public Task<SchoolYear?> GetSchoolYear(string name);

    }
}
