using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperStudentNoteRepository : IStudentNoteRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperStudentNoteRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddCommentAsync(EvaluationComment evaluationComment)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" INSERT INTO EvaluationComments(Comment,BookId,StudentId,EvaluationId,SchoolYearId)  
                              VALUES(@comment,@bookId,@studentId,@evaluationId,@schoolYearId);";
            var result = connection.Execute(query, new
            {
                comment = evaluationComment.Comment,
                bookId = evaluationComment.BookId,
                studentId = evaluationComment.StudentId,
                evaluationId = evaluationComment.EvaluationId,
                schoolYearId = evaluationComment.SchoolYearId,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> AddNoteAsync(StudentNote studentNote)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" INSERT INTO StudentNotes(Note,NoteCoef,NotedOn,Comment,SubjectId,StudentId,EvaluationId,SchoolYearId,BookId,Date)  
                              VALUES(@note,@noteCoef,@notedOn,@comment,@subjectId,@studentId,@evaluationId,@schoolYearId,@bookId,@date);";
            var result = connection.Execute(query, new
            {
                note = studentNote.Note,
                noteCoef = studentNote.NoteCoef,
                notedOn = studentNote.NotedOn,
                comment = studentNote.Comment,
                subjectId=studentNote.SubjectId,
                studentId = studentNote.StudentId,
                evaluationId = studentNote.EvaluationId,
                schoolYearId = studentNote.SchoolYearId,
                bookId= studentNote.BookId,
                date = studentNote.Date,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" DELETE FROM EvaluationComments WHERE id=@id ;";
            var result = connection.Execute(query, new { id });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" DELETE FROM StudentNotes WHERE id=@id ;";
            var result = connection.Execute(query, new { id });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<EvaluationComment?> GetCommentAsync(int evaluationId, int studentId, int schoolYearId, int bookId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM EvaluationComments A  
                              INNER JOIN EvaluationSessions B ON A.EvaluationId=B.Id
                              INNER JOIN Students C ON A.StudentId=C.Id  
                              INNER JOIN SchoolYears D ON A.SchoolYearId=D.Id
                              WHERE A.EvaluationId=@evaluationId AND A.StudentId=@studentId AND A.SchoolYearId=@schoolYearId AND A.BookId=@bookId   ;";
            var result = connection.Query<EvaluationComment,EvaluationSession, Student,SchoolYear, EvaluationComment>(query
               ,
               (comment,evaluation, student,schoolYear) =>
               {
                 comment.Evaluation=evaluation;
                 comment.Student=student;
                 comment.SchoolYear=schoolYear;
                   return comment;
               }
               , new {evaluationId, studentId, schoolYearId,bookId }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<EvaluationComment>> GetCommentsByEvaluationAsync(int evaluationId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM EvaluationComments A  
                              INNER JOIN EvaluationSessions B ON A.EvaluationId=B.Id
                              INNER JOIN Students C ON A.StudentId=C.Id  
                              INNER JOIN SchoolYears D ON A.SchoolYearId=D.Id
                              WHERE A.EvaluationId=@evaluationId AND A.SchoolYearId=@schoolYearId   ;";
            var result = connection.Query<EvaluationComment, EvaluationSession, Student, SchoolYear, EvaluationComment>(query
               ,
               (comment, evaluation, student, schoolYear) =>
               {
                   comment.Evaluation = evaluation;
                   comment.Student = student;
                   comment.SchoolYear = schoolYear;
                   return comment;
               }
               , new { evaluationId, schoolYearId}).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<EvaluationComment>> GetCommentsBySchoolYearAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM EvaluationComments A  
                              INNER JOIN EvaluationSessions B ON A.EvaluationId=B.Id
                              INNER JOIN Students C ON A.StudentId=C.Id  
                              INNER JOIN SchoolYears D ON A.SchoolYearId=D.Id
                              WHERE A.SchoolYearId=@schoolYearId   ;";
            var result = connection.Query<EvaluationComment, EvaluationSession, Student, SchoolYear, EvaluationComment>(query
               ,
               (comment, evaluation, student, schoolYear) =>
               {
                   comment.Evaluation = evaluation;
                   comment.Student = student;
                   comment.SchoolYear = schoolYear;
                   return comment;
               }
               , new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<EvaluationComment>> GetCommentsByStudentAsync(int studentId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM EvaluationComments A  
                              INNER JOIN EvaluationSessions B ON A.EvaluationId=B.Id
                              INNER JOIN Students C ON A.StudentId=C.Id  
                              INNER JOIN SchoolYears D ON A.SchoolYearId=D.Id
                              WHERE A.StudentId=@studentId AND A.SchoolYearId=@schoolYearId   ;";
            var result = connection.Query<EvaluationComment, EvaluationSession, Student, SchoolYear, EvaluationComment>(query
               ,
               (comment, evaluation, student, schoolYear) =>
               {
                   comment.Evaluation = evaluation;
                   comment.Student = student;
                   comment.SchoolYear = schoolYear;
                   return comment;
               }
               , new { studentId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<StudentNote?> GetNoteAsync(int subjectId, int studentId, int evaluationId, int schoolYearId, int bookId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes A  
                              INNER JOIN Subjects B ON A.SubjectId=B.Id
                              INNER JOIN EvaluationSessions C ON A.EvaluationId=C.Id
                              INNER JOIN Students D ON A.StudentId=D.Id  
                              INNER JOIN SchoolYears E ON A.SchoolYearId=E.Id
                              WHERE  A.SubjectId=@subjectId AND A.StudentId=@studentId AND A.EvaluationId=@evaluationId AND A.SchoolYearId=@schoolYearId AND A.BookId=@bookId   ;";
            var result = connection.Query<StudentNote,Subject, EvaluationSession, Student, SchoolYear, StudentNote>(query
               ,
               (studentNote,subject, evaluation, student, schoolYear) =>
               {
                   studentNote.Subject = subject;
                   studentNote.Evaluation = evaluation;
                   studentNote.Student = student;
                   studentNote.SchoolYear = schoolYear;
                   return studentNote;
               }
               , new {subjectId, studentId, evaluationId, schoolYearId, bookId }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<StudentNote?> GetNoteAsync(int studentNoteId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes A  
                              INNER JOIN Subjects B ON A.SubjectId=B.Id
                              INNER JOIN EvaluationSessions C ON A.EvaluationId=C.Id
                              INNER JOIN Students D ON A.StudentId=D.Id  
                              INNER JOIN SchoolYears E ON A.SchoolYearId=E.Id
                              WHERE  A.Id=@studentNoteId   ;";
            var result = connection.Query<StudentNote, Subject, EvaluationSession, Student, SchoolYear, StudentNote>(query
               ,
               (studentNote, subject, evaluation, student, schoolYear) =>
               {
                   studentNote.Subject = subject;
                   studentNote.Evaluation = evaluation;
                   studentNote.Student = student;
                   studentNote.SchoolYear = schoolYear;
                   return studentNote;
               }
               , new { studentNoteId }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<StudentNote>> GetNotesByEvaluationAsync(int evaluationId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes  WHERE EvaluationId=@evaluationId AND SchoolYearId=@schoolYearId   ;";
            var result = connection.Query<StudentNote, Subject, EvaluationSession, Student, SchoolYear, StudentNote>(query
               ,
               (studentNote, subject, evaluation, student, schoolYear) =>
               {
                   studentNote.Subject = subject;
                   studentNote.Evaluation = evaluation;
                   studentNote.Student = student;
                   studentNote.SchoolYear = schoolYear;
                   return studentNote;
               }
               , new { evaluationId, schoolYearId}).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<StudentNote>> GetNotesBySchoolYearAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes WHERE  SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<StudentNote>(query,new {schoolYearId}).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<StudentNote>> GetNotesBySchoolYearAsyncOld(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes A  
                              INNER JOIN Subjects B ON A.SubjectId=B.Id
                              INNER JOIN EvaluationSessions C ON A.EvaluationId=C.Id
                              INNER JOIN Students D ON A.StudentId=D.Id  
                              INNER JOIN SchoolYears E ON A.SchoolYearId=E.Id
                              WHERE  A.SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<StudentNote, Subject, EvaluationSession, Student, SchoolYear, StudentNote>(query
               ,
               (studentNote, subject, evaluation, student, schoolYear) =>
               {
                   studentNote.Subject = subject;
                   studentNote.Evaluation = evaluation;
                   studentNote.Student = student;
                   studentNote.SchoolYear = schoolYear;
                   return studentNote;
               }
               , new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<StudentNote>> GetNotesByClassAsync(int classId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes WHERE StudentId 
                               IN (SELECT StudentId FROM StudentsEnrollings WHERE classId=@classId AND SchoolYearId=@schoolYearId)
                               AND SchoolYearId=@schoolYearId;";
            var result = connection.Query<StudentNote>(query, new { classId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<StudentNote>> GetNotesByClassAsync(int classId,int evaluationId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes WHERE StudentId 
                               IN (SELECT StudentId FROM StudentsEnrollings WHERE classId=@classId AND SchoolYearId=@schoolYearId)
                               AND SchoolYearId=@schoolYearId AND EvaluationId=@evaluationId ;";
            var result = connection.Query<StudentNote>(query, new { classId,evaluationId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<StudentNote>> GetNotesByRoomAsync(int roomId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes WHERE StudentId 
                               IN (SELECT StudentId FROM StudentsRooms WHERE RoomId=@roomId AND SchoolYearId=@schoolYearId)
                               AND SchoolYearId=@schoolYearId;";
            var result = connection.Query<StudentNote>(query, new { roomId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<StudentNote>> GetNotesByRoomAsync(int roomId,int evaluationId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes WHERE StudentId 
                               IN (SELECT StudentId FROM StudentsRooms WHERE RoomId=@roomId AND SchoolYearId=@schoolYearId)
                               AND SchoolYearId=@schoolYearId  AND EvaluationId=@evaluationId;";
            var result = connection.Query<StudentNote>(query, new { roomId,evaluationId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<StudentNote>> GetNotesByStudentAsync(int studentId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes  WHERE StudentId=@studentId AND SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<StudentNote>(query,new { studentId, schoolYearId}).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<List<StudentNote>> GetNotesBySubjectAsync(int subjectId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes WHERE  SubjectId=@subjectId AND SchoolYearId=@schoolYearId  ;";
            var result = connection.Query<StudentNote>(query, new { subjectId,schoolYearId}).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<bool> UpdateCommentAsync(EvaluationComment evaluationComment)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE EvaluationComments SET Comment=@comment WHERE Id=@id;";
            var result = connection.Execute(query, new
            {
                comment = evaluationComment.Comment,
                id=evaluationComment.Id
            });
            await Task.Delay(0);
            return result > 0;
        }

        public  async Task<bool> UpdateNoteAsync(StudentNote studentNote)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE StudentNotes SET Note=@note,NoteCoef=@noteCoef,NotedOn=@notedOn,Comment=@comment WHERE Id=@id;";
            var result = connection.Execute(query, new
            {
                note = studentNote.Note,
                noteCoef = studentNote.NoteCoef,
                notedOn = studentNote.NotedOn,
                comment = studentNote.Comment,
                id=studentNote.Id
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<List<StudentNote>> GetNotesBySubjectAsync(int subjectId, int evaluationId, int roomId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM StudentNotes WHERE StudentId 
                               IN (SELECT StudentId FROM StudentsRooms WHERE RoomId=@roomId AND SchoolYearId=@schoolYearId)
                               AND SchoolYearId=@schoolYearId  AND EvaluationId=@evaluationId AND SubjectId=@subjectId ;";
            var result = connection.Query<StudentNote>(query, new { subjectId, evaluationId, roomId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
    }
}
