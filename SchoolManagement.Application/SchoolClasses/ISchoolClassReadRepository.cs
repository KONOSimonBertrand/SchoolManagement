
using SchoolManagement.Core.Model;
namespace SchoolManagement.Application.SchoolClasses
{
    public interface ISchoolClassReadRepository
    {
        public Task<IList<SchoolClass>>GetListAsync();
        public Task<SchoolClass?> GetAsync(string name);
    }
}
