

using SchoolManagement.Core.Model;
using Dapper;
using SchoolManagement.Infrastructure.DataBase;
using SchoolManagement.Core.Repositories;
namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperTimeTableServiceRepository : ITimeTableServiceRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperTimeTableServiceRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddTimeTableAsync(TimeTable timeTable)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO TimeTables(SubjectId,RoomId,TeacherId,StartHour,EndHour,Description,State,TeacherIn,TeacherOut,SchoolYearId)  
                                          VALUES(@subjectId,@roomId,@teacherId,@startHour,@endHour,@description,@state,@teacherIn,@teacherOut,@schoolYearId);";
            var result = connection.Execute(query, new
            {
                subjectId = timeTable.SubjectId,
                roomId= timeTable.RoomId,
                teacherId = timeTable.TeacherId,
                startHour= timeTable.StartHour,
                endHour= timeTable.EndHour,
                description=timeTable.Description,
                state=timeTable.State,
                teacherIn=timeTable.TeacherIn,
                teacherOut=timeTable.TeacherOut,
                schoolYearId = timeTable.SchoolYearId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> DeleteTimeTableAsync(int timeTableId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"DELETE FROM TimeTables WHERE Id=@timeTableId";
            var result = connection.Execute(query, new{ timeTableId });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<TimeTable?> GetTimeTableAsync(int subjectId, int roomId, DateTime startHour, DateTime endHour)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TimeTables WHERE SubjectId=@subjectId  AND RoomId=@roomId AND StartHour=@startHour AND EndHour=@endHour";
            var result = connection.Query<TimeTable>(query, new 
            {
                subjectId,
                roomId, 
                startHour, 
                endHour
            }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<TimeTable>> GetTimeTableListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TimeTables AS A
                             INNER JOIN Subjects AS B ON A.SubjectId=B.Id 
                             INNER JOIN SchoolRooms AS C ON A.RoomId=C.Id
                             INNER JOIN Employees AS D ON A.TeacherId=D.Id
                             INNER JOIN SchoolYears AS E ON A.SchoolYearId=E.Id
                             WHERE A.SchoolYearId=@schoolYearId ;";
            var result = connection.Query<TimeTable, Subject, SchoolRoom, Employee, SchoolYear, TimeTable>(query,
                (timeTable, subject, room, employee, schoolYear) => {
                    timeTable.Course = subject;
                    timeTable.Room = room;
                    timeTable.Teacher = employee;
                    timeTable.SchoolYear = schoolYear;
                    return timeTable;
                }, new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<IList<TimeTable>> GetTimeTableListAsync(int roomId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TimeTables AS A
                             INNER JOIN Subjects AS B ON A.SubjectId=B.Id 
                             INNER JOIN SchoolRooms AS C ON A.RoomId=C.Id
                             INNER JOIN Employees AS D ON A.TeacherId=D.Id
                             INNER JOIN SchoolYears AS E ON A.SchoolYearId=E.Id
                             WHERE A.RoomId=@roomId AND A.SchoolYearId=@schoolYearId ;";
            var result = connection.Query<TimeTable, Subject, SchoolRoom, Employee, SchoolYear, TimeTable>(query, 
                (timeTable,subject,room,employee,schoolYear) => { 
                     timeTable.Course=subject;
                    timeTable.Room=room;
                    timeTable.Teacher=employee;
                    timeTable.SchoolYear=schoolYear;
                    return timeTable;
                }, 
                new {roomId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<TimeTable>> GetTimeTableListAsync(int roomId, int schoolYearId, DateTime start, DateTime end)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM TimeTables AS A
                             INNER JOIN Subjects AS B ON A.SubjectId=B.Id 
                             INNER JOIN SchoolRooms AS C ON A.RoomId=C.Id
                             INNER JOIN Employees AS D ON A.TeacherId=D.Id
                             INNER JOIN SchoolYears AS E ON A.SchoolYearId=E.Id
                             WHERE A.RoomId=@roomId AND A.SchoolYearId=@schoolYearId 
                             AND Date(StartHour)>=@start And Date(EndHour)<=@end;";
            var result = connection.Query<TimeTable, Subject, SchoolRoom, Employee, SchoolYear, TimeTable>(query,
                (timeTable, subject, room, employee, schoolYear) => {
                    timeTable.Course = subject;
                    timeTable.Room = room;
                    timeTable.Teacher = employee;
                    timeTable.SchoolYear = schoolYear;
                    return timeTable;
                },
                new { roomId, schoolYearId,start,end }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateTimeTableAsync(TimeTable timeTable)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE TimeTables SET SubjectId=@subjectId,RoomId=@roomId,TeacherId=@teacherId,StartHour=@startHour,EndHour=@endHour,
                            Description=@description,State=@state,TeacherIn=@teacherIn,TeacherOut=@teacherOut,SchoolYearId=@schoolYearId WHERE Id=@timeTableId ;";
            var result = connection.Execute(query, new
            {
                subjectId = timeTable.SubjectId,
                roomId = timeTable.RoomId,
                teacherId = timeTable.TeacherId,
                startHour = timeTable.StartHour,
                endHour = timeTable.EndHour,
                description = timeTable.Description,
                state = timeTable.State,
                teacherIn = timeTable.TeacherIn,
                teacherOut = timeTable.TeacherOut,
                schoolYearId = timeTable.SchoolYearId,
                timeTableId=timeTable.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
