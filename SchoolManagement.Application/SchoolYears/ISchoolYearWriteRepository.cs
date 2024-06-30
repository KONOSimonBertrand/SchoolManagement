using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolYears
{
    public  interface ISchoolYearWriteRepository
    {
        public Task<bool> AddAsync(SchoolYear schoolYear);
        public Task<bool> UpdateAsync(SchoolYear schoolYear);
    }
}
