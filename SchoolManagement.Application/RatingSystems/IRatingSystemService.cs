

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IRatingSystemService
    {
        public Task<bool> CreateRatingSystem(RatingSystem ratingSystem);
        public Task<bool> UpdateRatingSystem(RatingSystem ratingSystem);
        public Task<IList<RatingSystem>> GetRatingSystemList();
        public Task<RatingSystem> GetRatingSystem(string name);
    }
}
