
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolClasses
{
    public interface ISchoolClassService
    {
        public Task<bool> CreateSchoolClass(SchoolClass schoolClass);
        public Task<bool> UpdateSchoolClass(SchoolClass schoolClass);
        public Task<IList<SchoolClass>> GetSchoolClassList();
        public Task<SchoolClass?> GetSchoolClass(string name);
    }
}
