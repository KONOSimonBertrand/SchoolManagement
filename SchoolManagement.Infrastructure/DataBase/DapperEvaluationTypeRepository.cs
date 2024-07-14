

using Dapper;
using SchoolManagement.Application.EvaluationTypes;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class DapperEvaluationTypeRepository : IEvaluationTypeRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperEvaluationTypeRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<bool> AddAsync(EvaluationType evaluationType)
        {
            var connection=dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO EvaluationTypes(Code,FrenchName,EnglishName,Sequence)  
                             VALUES(@code,@frenchName,@englishName,@sequence);";
            var result=connection.Execute(query, new {
                code= evaluationType.Code,
                frenchName= evaluationType.FrenchName,
                englishName= evaluationType.EnglishName,
                sequence= evaluationType.Sequence
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<EvaluationType?> GetAsync(string code)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM EvaluationTypes WHERE Code=@code ;";
            var result = connection.Query<EvaluationType>(query, new{code}).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EvaluationType>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM EvaluationTypes ;";
            var result = connection.Query<EvaluationType>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(EvaluationType evaluationType)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"UPDATE EvaluationTypes SET Code=@code,FrenchName=@frenchName
                           ,EnglishName=@englishName,Sequence=@sequence WHERE Id=@id;";
            var result = connection.Execute(query, new
            {
                code = evaluationType.Code,
                frenchName = evaluationType.FrenchName,
                englishName = evaluationType.EnglishName,
                sequence = evaluationType.Sequence
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
