
using SchoolManagement.Core.Model;
namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISchoolClassReadRepository
    {
        public Task<IList<SchoolClass>>GetListAsync();
        public Task<SchoolClass?> GetAsync(string name);
        public Task<IList<ClassSubject>> GetSubjectListAsync(int classId);
    }
}
