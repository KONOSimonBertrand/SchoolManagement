

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IJobReadRepository
    {
        public Task<Job?> GetAsync(string name);
        public Task<IList<Job>> GetListAsync();

    }
}
