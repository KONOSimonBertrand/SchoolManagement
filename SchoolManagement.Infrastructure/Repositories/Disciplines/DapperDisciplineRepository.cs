

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperDisciplineRepository : IDisciplineRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperDisciplineRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> AddDisciplineAsync(Discipline discipline)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" INSERT INTO Disciplines(Date,SubjectId,Reason,Duration,EvaluationId,StudentId,SchoolYearId)  
                                          VALUES(@date,@subjectId,@reason,@duration,@evaluationId,@studentId,@schoolYearId);";
            var result = connection.Execute(query, new { 
                date=discipline.Date,
                subjectId=discipline.SubjectId,
                reason=discipline.Reason,
                duration=discipline.Duration,
                evaluationId=discipline.EvaluationId,
                studentId=discipline.StudentId,
                schoolYearId=discipline.SchoolYearId,
            });
            await Task.Delay(0);
            return result > 0;
        }
        public async Task<bool> AddDisciplineSubjectAsync(DisciplineSubject subject)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" INSERT INTO DisciplineSubjects(Id,FrenchName,EnglishName,Sequence)  
                                          VALUES(@id,@frenchName,@englishName,@sequence);";
            var result = connection.Execute(query, new
            {
                id = subject.Id,
                frenchName=subject.FrenchName,
                englishName=subject.EnglishName,
                sequence=subject.Sequence,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> DeleteDisciplineAsync(int disciplineId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" DELETE FROM Disciplines WHERE Id=@disciplineId;";
            var result = connection.Execute(query, new{disciplineId});
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<Discipline?> GetDisciplineAsync(int studentId, int subjectId, DateTime date)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Disciplines A 
                            INNER JOIN  DisciplineSubjects B ON A.SubjectId=B.Id
                            INNER JOIN  EvaluationSessions C ON A.EvaluationId=C.Id
                            INNER JOIN  Students D ON A.StudentId=D.Id
                            INNER JOIN  SchoolYears E ON A.SchoolYearId=E.Id
                            WHERE A.StudentId=@studentId AND A.SubjectId=@subjectId AND DATE(A.Date)=@date ;";
            var result = connection.Query<Discipline, DisciplineSubject, EvaluationSession, Student,SchoolYear, Discipline>(query
                , (discipline, subject, evaluation, student,schoolYear) =>
                {
                    discipline.Subject = subject;
                    discipline.Evaluation = evaluation;
                    discipline.Student= student;
                    discipline.SchoolYear = schoolYear;
                    return discipline;
                }
                ,
                new { studentId, subjectId, date.Date }).FirstOrDefault() ;
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Discipline>> GetDisciplineListByStudentAsync(int studentId,int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Disciplines A 
                            INNER JOIN  DisciplineSubjects B ON A.SubjectId=B.Id
                            INNER JOIN  EvaluationSessions C ON A.EvaluationId=C.Id
                            INNER JOIN  Students D ON A.StudentId=D.Id
                            INNER JOIN  SchoolYears E ON A.SchoolYearId=E.Id
                            WHERE  A.SchoolYearId=@schoolYearId  AND A.StudentId=@studentId ORDER BY A.Date DESC;";
            var result = connection.Query<Discipline, DisciplineSubject, EvaluationSession, Student,SchoolYear, Discipline>(query
                , (discipline, subject, evaluation, student,schoolYear) =>
                {
                    discipline.Subject = subject;
                    discipline.Evaluation = evaluation;
                    discipline.Student = student;
                    discipline.SchoolYear= schoolYear;
                    return discipline;
                }
                , new { studentId,schoolYearId}).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<IList<Discipline>> GetDisciplineListByClassAsync(int classId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Disciplines A 
                            INNER JOIN  DisciplineSubjects B ON A.SubjectId=B.Id
                            INNER JOIN  EvaluationSessions C ON A.EvaluationId=C.Id
                            INNER JOIN  Students D ON A.StudentId=D.Id
                            INNER JOIN  SchoolYears E ON A.SchoolYearId=E.Id
                            WHERE A.SchoolYearId=@schoolYearId  
                            AND A.StudentId IN(SELECT StudentId FROM StudentsEnrollings WHERE SchoolYearId=@schoolYearId AND ClassId=@classId) 
                            ORDER BY A.Date DESC ;";
            var result = connection.Query<Discipline, DisciplineSubject, EvaluationSession, Student, SchoolYear, Discipline>(query
                , (discipline, subject, evaluation, student, schoolYear) =>
                {
                    discipline.Subject = subject;
                    discipline.Evaluation = evaluation;
                    discipline.Student = student;
                    discipline.SchoolYear = schoolYear;
                    return discipline;
                }
                , new { classId, schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<IList<Discipline>> GetDisciplineListBySchoolYearAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Disciplines A 
                            INNER JOIN  DisciplineSubjects B ON A.SubjectId=B.Id
                            INNER JOIN  EvaluationSessions C ON A.EvaluationId=C.Id
                            INNER JOIN  Students D ON A.StudentId=D.Id
                            INNER JOIN  SchoolYears E ON A.SchoolYearId=E.Id
                            WHERE A.SchoolYearId =@schoolYearId  ORDER BY A.Date DESC;";
            var result = connection.Query<Discipline, DisciplineSubject, EvaluationSession,Student,SchoolYear, Discipline>(query
                , (discipline, subject, evaluation,student,schooyear) =>
                {
                    discipline.Subject = subject;
                    discipline.Evaluation = evaluation;
                    discipline.Student = student;
                    discipline.SchoolYear=schooyear;
                    return discipline;
                }
                , new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }
        public async Task<DisciplineSubject?> GetDisciplineSubjectAsync(int subjectId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM DisciplineSubjects WHERE Id=@subjectId ;";
            var result = connection.QueryFirstOrDefault<DisciplineSubject>(query, new { subjectId});
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<DisciplineSubject>> GetDisciplineSubjectListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM DisciplineSubjects ORDER BY Sequence ;";
            var result = connection.Query<DisciplineSubject>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateDisciplineAsync(Discipline discipline)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE Disciplines SET Date=@date,SubjectId=@subjectId,Reason=@reason,
                                                 Duration=@duration,EvaluationId=@evaluationId WHERE Id=@Id;";
            var result = connection.Execute(query, new
            {
                date = discipline.Date,
                subjectId = discipline.SubjectId,
                reason = discipline.Reason,
                duration = discipline.Duration,
                evaluationId = discipline.EvaluationId,
                id = discipline.Id,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateDisciplineSubjectAsync(DisciplineSubject subject)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE DisciplineSubjects SET FrenchName=@frenchName,EnglishName=@englishName,Sequence=@sequence  
                                     WHERE Id=@id;";
            var result = connection.Execute(query, new
            {
              
                frenchName = subject.FrenchName,
                englishName = subject.EnglishName,
                sequence = subject.Sequence,
                id = subject.Id,
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
