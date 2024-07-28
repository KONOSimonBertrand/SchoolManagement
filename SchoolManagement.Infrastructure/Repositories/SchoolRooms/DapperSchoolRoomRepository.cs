using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSchoolRoomRepository : ISchoolRoomRepository
    {

        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperSchoolRoomRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<bool> AddAsync(SchoolRoom room)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO SchoolRooms(Name,ClassId,Sequence) VALUES(@name,@classId,@sequence) ;";
            var result = connection.Execute(query, new
            {
                name = room.Name,
                classId = room.ClassId,
                sequence = room.Sequence

            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SchoolRoom?> GetAsync(string name)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM SchoolRooms AS A 
                            INNER JOIN SchoolClasses B ON A.ClassId=B.Id 
                            WHERE A.Name=@name";
            var result = connection.Query<SchoolRoom, SchoolClass, SchoolRoom>(query,
                (schoolRoom, schoolClass) =>
                {
                    schoolRoom.SchoolClass = schoolClass;
                    return schoolRoom;
                },
                new { name }
                ).FirstOrDefault(); ;
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolRoom>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM SchoolRooms AS A 
                            INNER JOIN SchoolClasses B ON A.ClassId=B.Id  ;";
            var result = connection.Query<SchoolRoom, SchoolClass, SchoolRoom>(query,
                (schoolRoom, schoolClass) =>
                {
                    schoolRoom.SchoolClass = schoolClass;
                    return schoolRoom;
                }
                ).ToList();

            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SchoolRoom room)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" UPDATE SchoolRooms SET Name=@name,ClassId=@classId,Sequence=@sequence
                              WHERE Id=@id";
            var result = connection.Execute(query, new
            {
                name = room.Name,
                classId = room.ClassId,
                sequence = room.Sequence,
                id = room.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
