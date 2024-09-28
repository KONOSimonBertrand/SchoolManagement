

using Dapper;
using SchoolManagement.Core.Model;
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
            string query = @" INSERT INTO Disciplines(Date,SubjectId,Reason,Duration,EvaluationId,EnrollingId)  
                                          VALUES(@date,@subjectId,@reason,@duration,@evaluationId,@enrollingId);";
            var result = connection.Execute(query, new { 
                date=discipline.Date,
                subjectId=discipline.SubjectId,
                reason=discipline.Reason,
                duration=discipline.Duration,
                evaluationId=discipline.EvaluationId,
                enrollingId=discipline.EnrollingId,
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

        public async Task<Discipline?> GetDisciplineAsync(int enrollingId, int subjectId, DateTime date)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Disciplines A 
                            INNER JOIN  DisciplineSubjects B ON A.SubjectId=B.Id
                            INNER JOIN  EvaluationSessions C ON A.EvaluationId=C.Id
                            INNER JOIN  StudentsEnrollings D ON A.EnrollingId=D.Id
                            WHERE A.EnrollingId=@enrollingId AND A.SubjectId=@subjectId AND DATE(A.Date)=@date ;";
            var result = connection.Query<Discipline, DisciplineSubject, EvaluationSession, StudentEnrolling, Discipline>(query
                , (discipline, subject, evaluation, enrolling) =>
                {
                    discipline.Subject = subject;
                    discipline.Evaluation = evaluation;
                    discipline.Enrolling = enrolling;
                    return discipline;
                }
                ,
                new { enrollingId, subjectId, date.Date }).FirstOrDefault() ;
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Discipline>> GetDisciplineListByEnrollingAsync(int enrollingId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Disciplines A 
                            INNER JOIN  DisciplineSubjects B ON A.SubjectId=B.Id
                            INNER JOIN  EvaluationSessions C ON A.EvaluationId=C.Id
                            INNER JOIN  StudentsEnrollings D ON A.EnrollingId=D.Id
                            WHERE A.EnrollingId=@enrollingId ;";
            var result = connection.Query<Discipline, DisciplineSubject, EvaluationSession, StudentEnrolling, Discipline>(query
                , (discipline, subject, evaluation, enrolling) =>
                {
                    discipline.Subject = subject;
                    discipline.Evaluation = evaluation;
                    discipline.Enrolling = enrolling;
                    return discipline;
                }
                , new { enrollingId}).ToList();
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
            string query = "SELECT * FROM DisciplineSubjects ;";
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
