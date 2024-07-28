

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
   public interface IRatingSystemReadRepository
    {
        public Task<IList<RatingSystem>> GetListAsync();
        public Task<RatingSystem?> GetAsync(string name);
    }
}
