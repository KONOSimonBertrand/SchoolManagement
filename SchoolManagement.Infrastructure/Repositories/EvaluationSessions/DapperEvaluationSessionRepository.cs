

using Dapper;
using MySqlX.XDevAPI;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperEvaluationSessionRepository : IEvaluationSessionRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperEvaluationSessionRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddAsync(EvaluationSession session)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO EvaluationSessions(Code,FrenchName,EnglishName,Sequence)  
                             VALUES(@code,@frenchName,@englishName,@sequence);";
            var result = connection.Execute(query, new
            {
                code = session.Code,
                frenchName = session.FrenchName,
                englishName = session.EnglishName,
                sequence = session.Sequence
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> AddStateAsync(EvaluationSessionState evaluationSate)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO EvaluationSessionStates(EvaluationId,SchoolYearId,IsClosed)  
                             VALUES(@evaluationId,@schoolYearId,@isClosed);";
            var result = connection.Execute(query, new
            {
                evaluationId = evaluationSate.EvaluationId,
                @schoolYearId=evaluationSate.SchoolYearId,
                isClosed=evaluationSate.IsClosed
            });
            await Task.Delay(0);
            return result > 0;
        }


        public async Task<EvaluationSession?> GetAsync(string code)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EvaluationSessions WHERE Code=@code ;";
            var result = connection.Query<EvaluationSession>(query, new { code }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EvaluationSession>> GetListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EvaluationSessions ;";
            var result = connection.Query<EvaluationSession>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<EvaluationSessionState?> GetStateAsync(int evaluationId, int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EvaluationSessionStates AS A
                           INNER JOIN EvaluationSessions B ON A.EvaluationId=B.Id
                           INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                           WHERE A.EvaluationId=@evaluationId AND A.SchoolYearId=@schoolYearId ;";
            var result = connection.Query<EvaluationSessionState, EvaluationSession,SchoolYear, EvaluationSessionState>(query,
                (state, evaluation, schoolYear) =>
                {
                    state.EvaluationSession = evaluation;
                    state.SchoolYear = schoolYear;
                    return state;
                },
                new { evaluationId, schoolYearId }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EvaluationSessionState>> GetStateListByEvaluationAsync(int evaluationId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EvaluationSessionStates  AS A
                               INNER JOIN EvaluationSessions B ON A.EvaluationId=B.Id
                               INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                               WHERE EvaluationId=@evaluationId ;";
            var result = connection.Query<EvaluationSessionState, EvaluationSession, SchoolYear, EvaluationSessionState>(query,
                (state, evaluation, schoolYear) =>
                {
                    state.EvaluationSession = evaluation;
                    state.SchoolYear = schoolYear;
                    return state;
                }, new { evaluationId}).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EvaluationSessionState>> GetStateListBySchoolYearAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EvaluationSessionStates  AS A
                               INNER JOIN EvaluationSessions B ON A.EvaluationId=B.Id
                               INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id
                               WHERE SchoolYearId=@schoolYearId ;";
            var result = connection.Query<EvaluationSessionState, EvaluationSession, SchoolYear, EvaluationSessionState>(query,
                (state, evaluation, schoolYear) =>
                {
                    state.EvaluationSession = evaluation;
                    state.SchoolYear = schoolYear;
                    return state;
                }, new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(EvaluationSession session)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE EvaluationSessions SET FrenchName=@frenchName,EnglishName=@englishName
                             WHERE Id=@id;";
            var result = connection.Execute(query, new
            {
                frenchName = session.FrenchName,
                englishName = session.EnglishName,
                id = session.Id
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateStateAsync(EvaluationSessionState evaluationSate)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE EvaluationSessionStates SET IsClosed=@isClosed
                             WHERE EvaluationId=@evaluationId AND SchoolYearId=@schoolYearId ;";
            var result = connection.Execute(query, new
            {
                isClosed=evaluationSate.IsClosed,
                evaluationId=evaluationSate.EvaluationId,
                schoolYearId=evaluationSate.SchoolYearId,
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
