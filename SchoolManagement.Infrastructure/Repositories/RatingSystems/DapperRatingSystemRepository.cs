
using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperRatingSystemRepository : IRatingSystemRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperRatingSystemRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<bool> AddAsync(RatingSystem ratingSystem)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO RatingSystems(FrenchName,EnglishName,FrenchDescription,EnglishDescription,MinNote,MaxNote,Domain)  
                                                VALUES(@frenchName,@englishName,@frenchDescription,@englishDescription,@minNote,@maxNote,@domain) ;";
            var result = connection.Execute(query, new
            {
                frenchName = ratingSystem.FrenchName,
                englishName = ratingSystem.EnglishName,
                frenchDescription = ratingSystem.FrenchDescription,
                englishDescription = ratingSystem.EnglishDescription,
                minNote = ratingSystem.MinNote,
                maxNote = ratingSystem.MinNote,
                domain = ratingSystem.Domain
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<RatingSystem?> GetAsync(string name)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM RatingSystems WHERE FrenchName=@name ;";
            var result = connection.Query<RatingSystem>(query, new { name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<RatingSystem>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM RatingSystems ;";
            var result = connection.Query<RatingSystem>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(RatingSystem ratingSystem)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"UPDATE RatingSystems SET FrenchName=@frenchName,EnglishName=@englishName,FrenchDescription=@frenchDescription,
                                                 EnglishDescription=@englishDescription,MinNote=@minNote,MaxNote=@maxNote,Domain=@domain  WHERE Id=@id ;";
            var result = connection.Execute(query, new
            {
                frenchName = ratingSystem.FrenchName,
                englishName = ratingSystem.EnglishName,
                frenchDescription = ratingSystem.FrenchDescription,
                englishDescription = ratingSystem.EnglishDescription,
                minNote = ratingSystem.MinNote,
                maxNote = ratingSystem.MinNote,
                domain = ratingSystem.Domain,
                id = ratingSystem.Id,
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
