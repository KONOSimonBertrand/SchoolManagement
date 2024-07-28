using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public  interface ISchoolYearWriteRepository
    {
        public Task<bool> AddAsync(SchoolYear schoolYear);
        public Task<bool> UpdateAsync(SchoolYear schoolYear);
        public Task<bool> ChangeStatusAsync(SchoolYear schoolYear); //close or open
    }
}
