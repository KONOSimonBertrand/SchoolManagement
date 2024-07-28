

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IRatingSystemWriteRepository
    {
        public Task<bool> AddAsync(RatingSystem ratingSystem);
        public Task<bool> UpdateAsync(RatingSystem ratingSystem);
       
    }
}
