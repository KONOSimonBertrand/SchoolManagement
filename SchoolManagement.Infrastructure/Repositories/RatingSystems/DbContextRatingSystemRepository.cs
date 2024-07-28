using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextRatingSystemRepository : IRatingSystemRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextRatingSystemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(RatingSystem ratingSystem)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.RatingSystems.Add(ratingSystem);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;

        }

        public async Task<RatingSystem?> GetAsync(string name)
        {
            var result = appDbContext.RatingSystems.FirstOrDefault(x => x.FrenchName == name);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<RatingSystem>> GetListAsync()
        {
            var result = appDbContext.RatingSystems.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(RatingSystem ratingSystem)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.RatingSystems.Update(ratingSystem);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
    }
}
