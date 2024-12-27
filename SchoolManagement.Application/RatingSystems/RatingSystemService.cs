

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class RatingSystemService : IRatingSystemService
    {
        private readonly IRatingSystemReadRepository ratingSystemReadRepository;
        private readonly IRatingSystemWriteRepository ratingSystemWriteRepository;
        public RatingSystemService(IRatingSystemRepository ratingSystemRepository)
        {
            this.ratingSystemReadRepository = ratingSystemRepository;
            this.ratingSystemWriteRepository = ratingSystemRepository;
        }

        public async Task<bool> CreateRatingSystem(RatingSystem ratingSystem)
        {
            return await ratingSystemWriteRepository.AddAsync(ratingSystem);
        }

        public async Task<RatingSystem> GetRatingSystem(string name)
        {
            return await ratingSystemReadRepository.GetAsync(name);
        }

        public async Task<IList<RatingSystem>> GetRatingSystemList()
        {
            return await ratingSystemReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateRatingSystem(RatingSystem ratingSystem)
        {
            return await ratingSystemWriteRepository.UpdateAsync(ratingSystem);
        }
    }
}
