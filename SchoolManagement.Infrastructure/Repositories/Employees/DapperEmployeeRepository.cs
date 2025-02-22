

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperEmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperEmployeeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            var connection = dbConnectionFactory.CreateConnection();
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
            return result > 0;
        }

        public async Task<bool> AddEnrollingAsync(EmployeeEnrolling record)
        {
            var connection = dbConnectionFactory.CreateConnection();
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
                salary = record.Salary,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateEnrollingAsync(EmployeeEnrolling record)
        {
            var connection = dbConnectionFactory.CreateConnection();
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
                id = record.Id,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<Employee?> GetEmployeeAsync(string idNumber)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM Employees 
                              WHERE IdNumber=@idNumber;";
            var result = connection.Query<Employee>(query, new { idNumber }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<EmployeeEnrolling?> GetEnrollingAsync(int employeeId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM EmployeesEnrollings A 
                              INNER JOIN Employees B ON A.EmployeeId=B.Id
                              INNER JOIN Jobs C ON A.JobId=C.Id
                              INNER JOIN EmployeeGroups D ON A.GroupId=D.Id 
                              INNER JOIN SchoolYears E ON A.SchoolYearId=E.Id 
                               WHERE A.EmployeeId=@employeeId AND A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeEnrolling, Employee, Job, EmployeeGroup, SchoolYear, EmployeeEnrolling>(query,
                (enrolling, employee, job, group, schoolYear) =>
                {
                    enrolling.Employee = employee;
                    enrolling.Job = job;
                    enrolling.Group = group;
                    enrolling.SchoolYear = schoolYear;
                    return enrolling;
                },
                new { employeeId, schoolYearId }
                ).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EmployeeEnrolling>> GetEnrollingListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM EmployeesEnrollings A 
                              INNER JOIN Employees B ON A.EmployeeId=B.Id
                              INNER JOIN Jobs C ON A.JobId=C.Id
                              INNER JOIN EmployeeGroups D ON A.GroupId=D.Id 
                              INNER JOIN SchoolYears E ON A.SchoolYearId=E.Id 
                              WHERE A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeEnrolling, Employee, Job, EmployeeGroup, SchoolYear, EmployeeEnrolling>(query,
                (enrolling, employee, job, group, schoolYear) =>
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

        public async Task<IList<Employee>> GetEmployeeListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM Employees ;";
            var result = connection.Query<Employee>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            var connection = dbConnectionFactory.CreateConnection();
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
                id = employee.Id
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<Employee?> GetLastEmployeeAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM Employees ORDER BY Id DESC LIMIT 1;";
            var result = connection.QuerySingleOrDefault<Employee>(query);
            await Task.Delay(0);
            return result;
        }

        public async Task<int> GetTotalEmployeeAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT COUNT(*) FROM Employees ;";
            var result = connection.ExecuteScalar<int>(query);
            await Task.Delay(0);
            return result;
        }
        public async Task<bool> AddEmployeePictureAsync(int employeeId, string urlPicture)
        {
            var connection = dbConnectionFactory.CreateConnection();
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
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE EmployeesEnrollings SET PictureUrl=@urlPicture WHERE Id=@enrollingId";
            var result = connection.Execute(query, new
            {
                urlPicture,
                enrollingId
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async Task<bool> AddRoomListAsync(int employeeId, int schoolYearId, IList<EmployeeRoom> roomList)
        {
            await DeleteRoomListAsync(employeeId, schoolYearId);
            int recordCount = 0;
            foreach (var room in roomList)
            {
                if (await AddRoomAsync(employeeId, schoolYearId, room) == true)
                {
                    recordCount++;
                }
            }
            return recordCount == roomList.Count;
        }
        private async Task<bool> AddRoomAsync(int employeeId, int schoolYearId, EmployeeRoom room)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO EmployeesRooms(EmployeeId,SchoolYearId,RoomId,IsMasterRoom,DefaultSection) 
                           VALUES(@employeeId,@schoolYearId,@roomId,@isMasterRoom,@defaultSection) ;";
            var result = connection.Execute(query, new
            {
                employeeId,
                schoolYearId,
                roomId = room.RoomId,
                isMasterRoom = room.IsMasterRoom,
                defaultSection = room.DefaultSection
            });
            await Task.Delay(0);
            return result > 0;
        }
        private async Task<bool> DeleteRoomListAsync(int employeeId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"DELETE FROM EmployeesRooms WHERE EmployeeId=@employeeId AND SchoolYearId=@schoolYearId ;";
            var result = connection.Execute(query, new
            {
                employeeId,
                schoolYearId
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async Task<IList<EmployeeRoom>> GetRoomListByEmployeeAsync(int employeeId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesRooms A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                           INNER JOIN SchoolRooms D ON A.RoomId=D.Id
                           WHERE A.EmployeeId=@employeeId AND A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeRoom, Employee, SchoolYear, SchoolRoom, EmployeeRoom>(query,
                (employeeRoom, employee, schoolYear, room) =>
                {
                    employeeRoom.Employee = employee;
                    employeeRoom.SchoolYear = schoolYear;
                    employeeRoom.Room = room;
                    return employeeRoom;
                }
                , new { employeeId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<IList<EmployeeRoom>> GetRoomListBySchoolYearAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesRooms A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                           INNER JOIN SchoolRooms D ON A.RoomId=D.Id
                           WHERE A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeRoom, Employee, SchoolYear, SchoolRoom, EmployeeRoom>(query,
                (employeeRoom, employee, schoolYear, room) =>
                {
                    employeeRoom.Employee = employee;
                    employeeRoom.SchoolYear = schoolYear;
                    employeeRoom.Room = room;
                    return employeeRoom;
                }
                , new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<IList<EmployeeSubject>> GetSubjectListByEmployeeAsync(int employeeId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesSubjects A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                           INNER JOIN Subjects D ON A.SubjectId=D.Id
                           INNER JOIN SchoolRooms E ON A.RoomId=E.Id
                           WHERE A.EmployeeId=@employeeId AND A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeSubject, Employee, SchoolYear, Subject, SchoolRoom, EmployeeSubject>(query,
                (employeeSubject, employee, schoolYear, subject, room) =>
                {
                    employeeSubject.Employee = employee;
                    employeeSubject.SchoolYear = schoolYear;
                    employeeSubject.Subject = subject;
                    employeeSubject.Room = room;
                    return employeeSubject;
                }
                , new { employeeId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<IList<EmployeeSubject>> GetSubjectListBySchoolYearAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesSubjects A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                           INNER JOIN Subjects D ON A.SubjectId=D.Id
                           INNER JOIN SchoolRooms E ON A.RoomId=E.Id
                           WHERE A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeSubject, Employee, SchoolYear, Subject, SchoolRoom, EmployeeSubject>(query,
                (employeeSubject, employee, schoolYear, subject, room) =>
                {
                    employeeSubject.Employee = employee;
                    employeeSubject.SchoolYear = schoolYear;
                    employeeSubject.Subject = subject;
                    employeeSubject.Room = room;
                    return employeeSubject;
                }
                , new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        private async Task<bool> AddSubjectAsync(int employeeId, int schoolYearId, EmployeeSubject record)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO EmployeesSubjects(EmployeeId,SchoolYearId,SubjectId,RoomId) 
                           VALUES(@employeeId,@schoolYearId,@subjectId,@roomId) ;";
            var result = connection.Execute(query, new
            {
                employeeId,
                schoolYearId,
                subjectId = record.SubjectId,
                roomId = record.RoomId
            });
            await Task.Delay(0);
            return result > 0;
        }
        private async Task<bool> DeleteSubjectListAsync(int employeeId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"DELETE FROM EmployeesSubjects WHERE EmployeeId=@employeeId AND SchoolYearId=@schoolYearId ;";
            var result = connection.Execute(query, new
            {
                employeeId,
                schoolYearId
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async Task<bool> AddSubjectListAsync(int employeeId, int schoolYearId, IList<EmployeeSubject> subjectList)
        {
            await DeleteSubjectListAsync(employeeId, schoolYearId);
            int recordCount = 0;
            foreach (var subject in subjectList)
            {
                if (await AddSubjectAsync(employeeId, schoolYearId, subject) == true)
                {
                    recordCount++;
                }
            }
            return recordCount == subjectList.Count;
        }

        public async Task<IList<EmployeeAttendance>> GetAttendanceListByEmployeeAsync(int employeeId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesAttendances A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                           INNER JOIN Subjects D ON A.SubjectId=D.Id
                           INNER JOIN SchoolRooms E ON A.RoomId=E.Id
                           WHERE A.EmployeeId=@employeeId AND A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeAttendance, Employee, SchoolYear, Subject, SchoolRoom, EmployeeAttendance>(query,
                (attendance, employee, schoolYear, subject, room) =>
                {
                    attendance.Employee = employee;
                    attendance.SchoolYear = schoolYear;
                    attendance.Subject = subject;
                    attendance.Room = room;
                    return attendance;
                }
                , new { employeeId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<IList<EmployeeAttendance>> GetAttendanceListBySchoolYearAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesAttendances A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                           INNER JOIN Subjects D ON A.SubjectId=D.Id
                           INNER JOIN SchoolRooms E ON A.RoomId=E.Id
                           WHERE A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeAttendance, Employee, SchoolYear, Subject, SchoolRoom, EmployeeAttendance>(query,
                (attendance, employee, schoolYear, subject, room) =>
                {
                    attendance.Employee = employee;
                    attendance.SchoolYear = schoolYear;
                    attendance.Subject = subject;
                    attendance.Room = room;
                    return attendance;
                }
                , new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> AddAttendanceAsync(EmployeeAttendance attendance)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO EmployeesAttendances(EmployeeId,SchoolYearId,SubjectId,RoomId,StartHour,EndHour,Description) 
                           VALUES(@employeeId,@schoolYearId,@subjectId,@roomId,@startHour,@endHour,@description) ;";
            var result = connection.Execute(query, new
            {
                employeeId = attendance.EmployeeId,
                schoolYearId = attendance.SchoolYearId,
                subjectId = attendance.SubjectId,
                roomId = attendance.RoomId,
                startHour = attendance.StartHour,
                endHour = attendance.EndHour,
                description = attendance.Description
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateAttendanceAsync(EmployeeAttendance attendance)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE EmployeesAttendances SET SubjectId=@subjectId,RoomId=@roomId,StartHour=@startHour,EndHour=@endHour, 
                             Description=@description WHERE Id=@attendanceId ;";
            var result = connection.Execute(query, new
            {
                subjectId = attendance.SubjectId,
                roomId = attendance.RoomId,
                startHour = attendance.StartHour,
                endHour = attendance.EndHour,
                description = attendance.Description,
                attendanceId = attendance.Id
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> DeleteAttendanceAsync(int attendanceId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"DELETE FROM EmployeesAttendances WHERE Id=@attendanceId ;";
            var result = connection.Execute(query, new
            {
                attendanceId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> AddNoteAsync(EmployeeNote note)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO EmployeesNotes(EmployeeId,SchoolYearId,Title,Date,Description) 
                           VALUES(@employeeId,@schoolYearId,@title,@date,@description) ;";
            var result = connection.Execute(query, new
            {
                employeeId = note.EmployeeId,
                schoolYearId = note.SchoolYearId,
                title = note.Title,
                date = note.Date,
                description = note.Description
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateNoteAsync(EmployeeNote note)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE EmployeesNotes SET Title=@title,Date=@date,Description=@description 
                             WHERE Id=@noteId;";
            var result = connection.Execute(query, new
            {
                title = note.Title,
                date = note.Date,
                description = note.Description,
                noteId = note.Id
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> DeleteNoteAsync(int noteId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"DELETE FROM EmployeesNotes WHERE Id=@noteId ;";
            var result = connection.Execute(query, new
            {
                noteId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<IList<EmployeeNote>> GetNoteListByEmployeeAsync(int employeeId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesNotes A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id 
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                           WHERE A.EmployeeId=@employeeId AND A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeNote, Employee, SchoolYear, EmployeeNote>(query,
                (note, employee, schoolYear) =>
                {
                    note.Employee = employee;
                    note.SchoolYear = schoolYear;
                    return note;
                }
                , new { employeeId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<IList<EmployeeNote>> GetNoteListBySchoolYearAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesNotes A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id 
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                           WHERE  A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeNote, Employee, SchoolYear, EmployeeNote>(query,
                (note, employee, schoolYear) =>
                {
                    note.Employee = employee;
                    note.SchoolYear = schoolYear;
                    return note;
                }
                , new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EmployeeAccountTransaction>> GetAccountTransactionListByEmployeeAsync(int employeeId,int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesAccountTransactions A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id  
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id                         
                           WHERE A.EmployeeId=@employeeId AND A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeAccountTransaction, Employee,SchoolYear, EmployeeAccountTransaction>(query,
                (transaction, employee,schoolyear) =>
                {
                    transaction.Employee=employee;
                    transaction.SchoolYear = schoolyear;
                    return transaction;
                }
                , new { employeeId,schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<IList<EmployeeAccountTransaction>> GetAccountTransactionListBySchoolYearAsync( int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesAccountTransactions A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id  
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id                         
                           WHERE A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<EmployeeAccountTransaction, Employee, SchoolYear, EmployeeAccountTransaction>(query,
                (transaction, employee, schoolyear) =>
                {
                    transaction.Employee = employee;
                    transaction.SchoolYear = schoolyear;
                    return transaction;
                }
                , new {schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> AddAccountTransactionAsync(EmployeeAccountTransaction transaction)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO EmployeesAccountTransactions(Date,Amount,Reason,TransactionId,EmployeeId,SchoolYearId) 
                           VALUES(@date,@amount,@reason,@transactionId,@employeeId,@schoolYearId) ;";
            var result = connection.Execute(query, new
            {
                date = transaction.Date,
                amount = transaction.Amount,
                reason = transaction.Reason,
                transactionId = transaction.TransactionId,
                employeeId = transaction.EmployeeId,
                schoolYearId= transaction.SchoolYearId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<EmployeeAccountTransaction?> GetLastAccountTransactionAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeesAccountTransactions A 
                           INNER JOIN Employees B ON A.EmployeeId=B.Id  
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                           ORDER BY A.Id DESC LIMIT 1 ;";
            var result = connection.Query<EmployeeAccountTransaction, Employee,SchoolYear, EmployeeAccountTransaction>(query,
                (transaction, employee,schoolYear) =>
                {
                    transaction.Employee = employee;
                    transaction.SchoolYear = schoolYear;
                    return transaction;
                }
                ).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<int> GetTotalAccountTransactionAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT COUNT(*) FROM EmployeesAccountTransactions ;";
            var result = connection.ExecuteScalar<int>(query);
            await Task.Delay(0);
            return result;
        }
    }
}
