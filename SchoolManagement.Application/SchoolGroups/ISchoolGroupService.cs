

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public  interface ISchoolGroupService
    {
        public Task<bool> CreateSchoolGroup(SchoolGroup schoolGroup);
        public Task<bool> UpdateSchoolGroup(SchoolGroup schoolGroup);
        public Task<List<SchoolGroup>> GetSchoolGroupList();
        public Task<SchoolGroup?> GetSchoolGroup(string name);
    }
}
