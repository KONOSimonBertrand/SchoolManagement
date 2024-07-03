

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolGroups
{
    public  interface ISchoolGroupWriteRepository
    {
        public Task<bool> AddAsync(SchoolGroup schoolGroup);
        public Task<bool> UpdateAsync(SchoolGroup schoolGroup);
    }
}
