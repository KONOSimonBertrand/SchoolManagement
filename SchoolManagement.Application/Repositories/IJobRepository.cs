
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Repositories
{
    public interface IJobRepository
    {
        public Task<List<Job>> GetAllAsync();
    }
}
