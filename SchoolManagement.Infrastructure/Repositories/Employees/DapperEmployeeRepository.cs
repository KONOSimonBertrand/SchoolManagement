

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;
using System.Configuration;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperEmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperEmployeeRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" INSERT INTO Employees(IdNumber,FirstName,LastName,Birthday,Sex,Phone,Email,Address,IdCard,Nationality,Religion,HiringDate)  
                              VALUES(@idNumber,@firstName,@lastName,@birthday,@sex,@phone,@email,@address,@idCard,@nationality,@religion,@hiringDate);";
            var result = connection.Execute(query, new
            {
                idNumber = employee.IdNumber,
                firstName = employee.FirstName,
                lastName = employee.LastName,
                birthday = employee.BirthDate,
                sex = employee.Sex,
                phone = employee.Phone,
                email = employee.Email,
                address = employee.Address,
                idCard = employee.IdCard,
                nationality = employee.Nationality,
                religion = employee.Religion,
                hiringDate = employee.HiringDate,              
            });
            await Task.Delay(0);
            return result>0;
        }

        public async  Task<bool> AddEnrollingAsync(EmployeeEnrolling record)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" INSERT INTO EmployeesEnrollings(IdNumber,Date,EmployeeId,SchoolYearId,GroupId,JobId,Salary)  
                              VALUES(@idNumber,@date,@employeeId,@schoolYearId,@groupId,@jobId,@salary);";
            var result = connection.Execute(query, new
            {
                idNumber = record.IdNumber,
                date = record.Date,
                employeeId = record.EmployeeId,
                schoolYearId = record.SchoolYearId,
                groupId = record.GroupId,
                jobId = record.JobId,
                salary=record.Salary,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateEnrollingAsync(EmployeeEnrolling record)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" UPDATE EmployeesEnrollings SET IdNumber=@idNumber,Date=@date,EmployeeId=@employeeId,SchoolYearId=@schoolYearId,GroupId=@groupId,JobId=@jobId,Salary=@salary  
                              WHERE Id=@id;";
            var result = connection.Execute(query, new
            {
                idNumber = record.IdNumber,
                date = record.Date,
                employeeId = record.EmployeeId,
                schoolYearId = record.SchoolYearId,
                groupId = record.GroupId,
                jobId = record.JobId,
                salary = record.Salary,
                id= record.Id,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<Employee?> GetAsync(string idNumber)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" SELECT * FROM Employees 
                              WHERE IdNumber=@idNumber;";
            var result = connection.Query<Employee>(query,new { idNumber }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<EmployeeEnrolling?> GetEnrollingAsync(int employeeId, int schoolYearId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" SELECT * FROM EmployeesEnrollings A 
                              INNER JOIN Employees B ON A.EmployeeId=B.Id
                              INNER JOIN Jobs C ON A.JobId=C.Id
                              INNER JOIN EmployeeGroups D ON A.GroupId=D.Id 
                              INNER JOIN SchoolYears E ON A.SchoolYearId=E.Id 
                               WHERE A.EmployeeId=@employeeId AND A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeEnrolling, Employee, Job, EmployeeGroup,SchoolYear, EmployeeEnrolling>(query,
                (enrolling, employee, job, group,schoolYear) =>
                {
                    enrolling.Employee = employee;
                    enrolling.Job = job;
                    enrolling.Group = group;
                    enrolling.SchoolYear = schoolYear;
                    return enrolling;
                },
                new { employeeId,schoolYearId }
                ).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EmployeeEnrolling>> GetEnrollingListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" SELECT * FROM EmployeesEnrollings A 
                              INNER JOIN Employees B ON A.EmployeeId=B.Id
                              INNER JOIN Jobs C ON A.JobId=C.Id
                              INNER JOIN EmployeeGroups D ON A.GroupId=D.Id 
                               INNER JOIN SchoolYears E ON A.SchoolYearId=E.Id 
                               WHERE A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeEnrolling, Employee, Job, EmployeeGroup,SchoolYear, EmployeeEnrolling>(query,
                (enrolling,employee, job, group,schoolYear) =>
                {
                    enrolling.Employee = employee;
                    enrolling.Job = job;
                    enrolling.Group = group;
                    enrolling.SchoolYear = schoolYear;
                    return enrolling;
                },
                new { schoolYearId }
                ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Employee>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" SELECT * FROM Employees ;";
            var result = connection.Query<Employee>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" UPDATE Employees SET IdNumber=@idNumber,FirstName=@firstName,LastName=@lastName,Birthday=@birthday,Sex=@sex,Phone=@phone,Email=@email,Address=@address,
                              IdCard=@idCard,Nationality=@nationality,Religion=@religion,HiringDate=@hiringDate WHERE Id=@id";
            var result = connection.Execute(query, new
            {
                idNumber = employee.IdNumber,
                firstName = employee.FirstName,
                lastName = employee.LastName,
                birthday = employee.BirthDate,
                sex = employee.Sex,
                phone = employee.Phone,
                email = employee.Email,
                address = employee.Address,
                idCard = employee.IdCard,
                nationality = employee.Nationality,
                religion = employee.Religion,
                hiringDate = employee.HiringDate,
                id= employee.Id
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> AddPictureAsync(int employeeId,string urlPicture)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" UPDATE Employees SET PictureUrl=@urlPicture WHERE Id=@employeeId";
            var result = connection.Execute(query, new
            {              
                urlPicture,
                employeeId
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async Task<bool> AddEnrollingPictureAsync(int enrollingId, string urlPicture)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" UPDATE EmployeesEnrollings SET PictureUrl=@urlPicture WHERE Id=@enrollingId";
            var result = connection.Execute(query, new
            {
                urlPicture,
                enrollingId
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async  Task<bool> AddRoomListAsync(int enrollingId, IList<EmployeeRoom> roomList)
        {
            await DeleteRoomListAsync(enrollingId);
            int recordCount = 0;
            foreach (var room in roomList)
            {
                if (await AddRoomAsync(enrollingId,room) == true)
                {
                    recordCount++;
                }
            }
            return recordCount == roomList.Count;
        }
        private async Task<bool> AddRoomAsync(int enrollingId, EmployeeRoom room)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO EmployeesRooms(EnrollingId,RoomId,IsMasterRoom,DefaultSection) 
                           VALUES(@enrollingId,@roomId,@isMasterRoom,@defaultSection) ;";
            var result = connection.Execute(query, new
            {
                enrollingId,
                roomId = room.RoomId,
                isMasterRoom=room.IsMasterRoom,
                defaultSection=room.DefaultSection
            });
            await Task.Delay(0);
            return result > 0;
        }
        private async Task<bool> DeleteRoomListAsync(int enrollingId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"DELETE FROM EmployeesRooms WHERE EnrollingId=@enrollingId ;";
            var result = connection.Execute(query, new
            {
                enrollingId
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async Task<IList<EmployeeRoom>> GetRoomListAsync(int enrollingId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM EmployeesRooms A 
                           INNER JOIN EmployeesEnrollings B ON A.EnrollingId=B.Id
                           INNER JOIN SchoolRooms C ON A.RoomId=C.Id
                           WHERE A.EnrollingId=@enrollingId  ;";
            var result = connection.Query<EmployeeRoom, EmployeeEnrolling, SchoolRoom, EmployeeRoom>(query,
                (employeeRoom, enrolling, room) =>
                {
                    employeeRoom.Enrolling= enrolling;
                    employeeRoom.Room = room;
                    return employeeRoom;
                }
                , new { enrollingId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EmployeeSubject>> GetSubjectListAsync(int enrollingId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM EmployeesSubjects A 
                           INNER JOIN EmployeesEnrollings B ON A.EnrollingId=B.Id
                           INNER JOIN Subjects C ON A.SubjectId=C.Id
                           INNER JOIN SchoolRooms D ON A.RoomId=D.Id
                           WHERE A.EnrollingId=@enrollingId  ;";
            var result = connection.Query<EmployeeSubject, EmployeeEnrolling,Subject, SchoolRoom, EmployeeSubject>(query,
                (employeeSubject, enrolling,subject, room) =>
                {
                    employeeSubject.Enrolling = enrolling;
                    employeeSubject.Subject = subject;
                    employeeSubject.Room = room;
                    return employeeSubject;
                }
                , new { enrollingId }).ToList();
            await Task.Delay(0);
            return result;
        }
        private async Task<bool> AddSubjectAsync(int enrollingId, EmployeeSubject record)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO EmployeesSubjects(EnrollingId,SubjectId,RoomId) 
                           VALUES(@enrollingId,@subjectId,@roomId) ;";
            var result = connection.Execute(query, new
            {
                enrollingId,
                subjectId=record.SubjectId,
                roomId = record.RoomId
            });
            await Task.Delay(0);
            return result > 0;
        }
        private async Task<bool> DeleteSubjectListAsync(int enrollingId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"DELETE FROM EmployeesSubjects WHERE EnrollingId=@enrollingId ;";
            var result = connection.Execute(query, new
            {
                enrollingId
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async Task<bool> AddSubjectListAsync(int enrollingId, IList<EmployeeSubject> subjectList)
        {
            await DeleteSubjectListAsync(enrollingId);
            int recordCount = 0;
            foreach (var subject in subjectList)
            {
                if (await AddSubjectAsync(enrollingId, subject) == true)
                {
                    recordCount++;
                }
            }
            return recordCount == subjectList.Count;
        }

        public async Task<IList<EmployeeAttendance>> GetAttendanceListAsync(int enrollingId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM EmployeesAttendances A 
                           INNER JOIN EmployeesEnrollings B ON A.EnrollingId=B.Id
                           INNER JOIN Subjects C ON A.SubjectId=C.Id
                           INNER JOIN SchoolRooms D ON A.RoomId=D.Id
                           WHERE A.EnrollingId=@enrollingId  ;";
            var result = connection.Query<EmployeeAttendance, EmployeeEnrolling, Subject, SchoolRoom, EmployeeAttendance>(query,
                (attendance, enrolling, subject, room) =>
                {
                    attendance.Enrolling = enrolling;
                    attendance.Subject = subject;
                    attendance.Room = room;
                    return attendance;
                }
                , new { enrollingId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> AddAttendanceAsync(EmployeeAttendance attendance)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO EmployeesAttendances(EnrollingId,SubjectId,RoomId,StartHour,EndHour,Description) 
                           VALUES(@enrollingId,@subjectId,@roomId,@startHour,@endHour,@description) ;";
            var result = connection.Execute(query, new
            {
                enrollingId=attendance.EnrollingId,
                subjectId=attendance.SubjectId,
                roomId=attendance.RoomId,
                startHour = attendance.StartHour,
                endHour = attendance.EndHour ,
                description=attendance.Description
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async  Task<bool> UpdateAttendanceAsync(EmployeeAttendance attendance)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"UPDATE EmployeesAttendances SET SubjectId=@subjectId,RoomId=@roomId,StartHour=@startHour,EndHour=@endHour, 
                             Description=@description WHERE Id=@attendanceId ;";
            var result = connection.Execute(query, new
            {
                subjectId = attendance.SubjectId,
                roomId = attendance.RoomId,
                startHour = attendance.StartHour,
                endHour = attendance.EndHour,
                description=attendance.Description,
                attendanceId=attendance.Id
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> DeleteAttendanceAsync(int attendanceId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"DELETE FROM EmployeesAttendances WHERE Id=@attendanceId ;";
            var result = connection.Execute(query, new
            {
                attendanceId
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
