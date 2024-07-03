

using Dapper;
using SchoolManagement.Application.SchoolGroups;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class DapperSchoolGroupRepository : ISchoolGroupRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactory;
        public DapperSchoolGroupRepository(IDbConnectionFactoty dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> AddAsync(SchoolGroup schoolGroup)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string sqlText = @"INSERT INTO SchoolGroups(Name, Sequence ) 
                              VALUES(@name, @sequence) ;";
            var result = connection.Execute(sqlText, 
             new
            {
                schoolGroup.Name,
                schoolGroup.Sequence,
            });

            await Task.Delay(0);
            return (result > 0);
        }

        public async Task<List<SchoolGroup>> GetAllAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string sqlText = "SELECT * FROM SchoolGroups ";
            var result = connection.Query<SchoolGroup>(sqlText).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<SchoolGroup?> GetAsync(string name)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string sqlText = "SELECT * FROM SchoolGroups Where Name=@name ";
            var result = connection.Query<SchoolGroup>(sqlText, new { Name = name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SchoolGroup schoolGroup)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string sqlText = @"UPDATE SchoolGroups SET Name=@name, Sequence=@sequence WHERE Id=@id ;";
            var result = connection.Execute(sqlText,

                new
                {
                    schoolGroup.Name,
                    schoolGroup.Sequence,
                    schoolGroup.Id
                });
            await Task.Delay(0);
            return (result > 0);
        }
    }
}
