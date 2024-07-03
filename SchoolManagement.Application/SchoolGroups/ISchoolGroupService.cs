

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolGroups
{
    public  interface ISchoolGroupService
    {
        public Task<bool> CreateSchoolGroup(SchoolGroup schoolGroup);
        public Task<bool> UpdateSchoolGroup(SchoolGroup schoolGroup);
        public Task<List<SchoolGroup>> GetAllSchoolGroups();
        public Task<SchoolGroup?> GetSchoolGroup(string name);
    }
}
