

using Dapper;
using SchoolManagement.Core.Model;
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
    }
}
