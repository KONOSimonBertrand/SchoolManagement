

using Dapper;
using SchoolManagement.Application.SchoolClasses;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    internal class DapperSchoolClassRepository : ISchoolClassRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperSchoolClassRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<bool> AddAsync(SchoolClass schoolClass)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO SchoolClasses(Name,GroupId,BookTypeId,Sequence) VALUES(@name,@groupId,@bookTypeId,@sequence);";
            var result = connection.Execute(query, new
            {
                schoolClass.Name,
                schoolClass.GroupId,
                schoolClass.BookTypeId,
                schoolClass.Sequence
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SchoolClass?> GetAsync(string name)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM SchoolClasses AS A 
                             INNER JOIN SchoolGroups AS B ON A.GroupId=B.Id
                             WHERE A.Name=@name; ";
            var result = connection.Query<SchoolClass, SchoolGroup, SchoolClass>(query,
                (schoolClass, schoolGroup) =>
                {
                    schoolClass.Group = schoolGroup;
                    return schoolClass;
                }
                , new { name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolClass>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM SchoolClasses AS A  
                           INNER JOIN SchoolGroups AS B ON A.GroupId=B.Id;";
            var result = connection.Query<SchoolClass,SchoolGroup,SchoolClass>(query,
                (schoolClass, schoolGroup) =>
                {
                    schoolClass.Group = schoolGroup;
                    return schoolClass;
                }                
                ).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<bool> UpdateAsync(SchoolClass schoolClass)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"UPDATE SchoolClasses SET Name=@name,GroupId=@groupId,BookTypeId=@bookTypeId,Sequence=@sequence WHERE Id=@id ;";
            var result = connection.Execute(query, new
            {
                schoolClass.Name,
                schoolClass.GroupId,
                schoolClass.BookTypeId,
                schoolClass.Sequence,
                schoolClass.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
