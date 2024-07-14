

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolClasses
{
    public interface ISchoolClassWriteRepository
    {
        public Task<bool> AddAsync(SchoolClass schoolClass);
        public Task<bool> UpdateAsync(SchoolClass schoolClass);
    }
}
