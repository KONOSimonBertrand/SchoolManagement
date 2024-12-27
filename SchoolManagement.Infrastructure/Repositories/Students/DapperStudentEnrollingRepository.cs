

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperStudentEnrollingRepository : IStudentEnrollingRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperStudentEnrollingRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public  async Task<bool> AddEnrollingAsync(StudentEnrolling enrolling)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" INSERT INTO StudentsEnrollings(Date,StudentId,ClassId,SchoolYearId,OldSchool,IsRepeater,DoneBy)  
                              VALUES(@date,@studentId,@classId,@schoolYearId,@oldSchool,@isRepeater,@doneBy);";
            var result = connection.Execute(query, new
            {
                date = enrolling.Date,
                studentId=enrolling.StudentId,
                classId=enrolling.ClassId,
                schoolYearId=enrolling.SchoolYearId,
                oldSchool =enrolling.OldSchool,
                isRepeater=enrolling.IsRepeater,
                doneBy = enrolling.DoneBy,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> AddStudentRoomAsync(StudentRoom room)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" INSERT INTO StudentsRooms(StudentId,RoomId,SchoolYearId,Note)  
                              VALUES(@studentId,@roomId,@schoolYearId,@note);";
            var result = connection.Execute(query, new
            {
                studentId = room.StudentId,
                roomId = room.RoomId,
                schoolYearId = room.SchoolYearId,
                note = room.Note,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> DeleteStudentRoomAsync(int studentId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" DELETE FROM StudentsRooms  WHERE StudentId=@studentId AND SchoolYearId=@schoolYearId ;";  
            var result = connection.Execute(query, new
            {
                studentId ,
                schoolYearId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<StudentEnrolling?> GetStudentEnrollingAsyn(int studentId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM StudentsEnrollings AS A   
                             INNER JOIN Students AS B ON A.StudentId=B.Id 
                             INNER JOIN  SchoolClasses AS C ON A.ClassId=C.Id
                             WHERE StudentId=@studentId AND SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<StudentEnrolling, Student, SchoolClass, StudentEnrolling>(query,
                (enrolling, student, schoolclass) =>
                {
                    enrolling.Student = student;
                    enrolling.SchoolClass = schoolclass;
                    return enrolling;
                }
                , new { studentId,schoolYearId}).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<StudentEnrolling>> GetStudentEnrollingLIstAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM StudentsEnrollings  AS A  
                            INNER JOIN Students AS B ON A.StudentId=B.Id 
                            INNER JOIN  SchoolClasses AS C ON A.ClassId=C.Id
                                WHERE A.SchoolYearId=@schoolYearId;";
            var result = connection.Query<StudentEnrolling,Student, SchoolClass, StudentEnrolling>(query,
                (enrolling,student, schoolclass) =>
                {
                    enrolling.Student = student;
                    enrolling.SchoolClass = schoolclass;
                    return enrolling;
                },
                new { schoolYearId }
                ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<StudentRoom?> GetStudentRoomAsync(int studentId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM StudentsRooms   AS A
                             INNER JOIN SchoolRooms AS B ON A.RoomId=B.Id
                             INNER JOIN Students AS C ON A.StudentId=C.Id
                             INNER JOIN SchoolYears AS D ON A.SchoolYearId=D.Id
                             WHERE StudentId=@studentId AND SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<StudentRoom,SchoolRoom,Student,SchoolYear, StudentRoom>(query, 
                (studentRoom, schoolroom, student, schoolYear) =>
                {
                    studentRoom.Room=schoolroom;
                    studentRoom.Student=student;
                    studentRoom.SchoolYear=schoolYear;
                    return studentRoom;
                },
                new { studentId,schoolYearId }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<StudentRoom>> GetStudentRoomListAsync(int roomId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM StudentsRooms  AS A  
                             INNER JOIN SchoolRooms AS B ON A.RoomId=B.Id
                             INNER JOIN Students AS C ON A.StudentId=C.Id
                             INNER JOIN SchoolYears AS D ON A.SchoolYearId=D.Id
                             WHERE A.RoomId=@roomId AND A.SchoolYearId=@schoolYearId  ;";                              
            var result = connection.Query<StudentRoom,SchoolRoom, Student,SchoolYear, StudentRoom>(query,
                (studentRoom,room, student,schoolYear) =>
                {
                    studentRoom.Room=room;
                    studentRoom.Student = student;
                    studentRoom.SchoolYear = schoolYear;
                    return studentRoom;
                },
                new {roomId,schoolYearId}
                ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<StudentRoom>> GetStudentRoomListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM StudentsRooms  AS A  
                             INNER JOIN SchoolRooms AS B ON A.RoomId=B.Id
                             INNER JOIN Students AS C ON A.StudentId=C.Id
                             INNER JOIN SchoolYears AS D ON A.SchoolYearId=D.Id
                             WHERE A.SchoolYearId=@schoolYearId ;";
            var result = connection.Query<StudentRoom,SchoolRoom, Student,SchoolYear, StudentRoom>(query,
                (studentRoom,room, student, schoolYear) =>
                {
                    studentRoom.Room=room;
                    studentRoom.Student = student;
                    studentRoom.SchoolYear=schoolYear;
                    return studentRoom;
                }, new
                {
                    schoolYearId
                }
                ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> AddEnrollingPictureAsync(int enrollingId, string urlPicture)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE StudentsEnrollings SET PictureUrl=@urlPicture WHERE Id=@enrollingId";
            var result = connection.Execute(query, new
            {
                urlPicture,
                enrollingId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async  Task<bool> UpdateEnrollingAsync(StudentEnrolling enrolling)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE StudentsEnrollings SET Date=@date,StudentId=@studentId,ClassId=@classId,
                                     OldSchool=@oldSchool,IsRepeater=@isRepeater,DoneBy=@doneBy WHERE Id=@enrollingId ;";
            var result = connection.Execute(query, new
            {
                date = enrolling.Date,
                studentId = enrolling.StudentId,
                classId = enrolling.ClassId,
                oldSchool = enrolling.OldSchool,
                isRepeater = enrolling.IsRepeater,
                enrollingId=enrolling.Id,
                doneBy=enrolling.DoneBy,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> ChangeEnrollingStatus(int enrollingId, bool status, string reason)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE StudentsEnrollings SET IsActive=@status,ReasonLeft=@reason WHERE Id=@enrollingId;";
            var result = connection.Execute(query, new
            {
                status,
                reason,
                enrollingId
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
