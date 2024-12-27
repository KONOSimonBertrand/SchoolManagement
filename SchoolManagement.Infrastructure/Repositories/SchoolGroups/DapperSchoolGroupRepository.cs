

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSchoolGroupRepository : ISchoolGroupRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperSchoolGroupRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> AddAsync(SchoolGroup schoolGroup)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO SchoolGroups(Name, Sequence ) 
                              VALUES(@name, @sequence) ;";
            var result = connection.Execute(query,
             new
             {
                 schoolGroup.Name,
                 schoolGroup.Sequence,
             });

            await Task.Delay(0);
            return result > 0;
        }

        public async Task<List<SchoolGroup>> GetListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM SchoolGroups ORDER BY Sequence";
            var result = connection.Query<SchoolGroup>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<SchoolGroup?> GetAsync(string name)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM SchoolGroups Where Name=@name ";
            var result = connection.Query<SchoolGroup>(query, new { Name = name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SchoolGroup schoolGroup)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE SchoolGroups SET Name=@name, Sequence=@sequence WHERE Id=@id ;";
            var result = connection.Execute(query,

                new
                {
                    schoolGroup.Name,
                    schoolGroup.Sequence,
                    schoolGroup.Id
                });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
