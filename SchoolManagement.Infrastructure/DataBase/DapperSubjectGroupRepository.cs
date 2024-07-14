

using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManagement.Application.SubjectGroups;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class DapperSubjectGroupRepository : ISubjectGroupRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperSubjectGroupRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<bool> AddAsync(SubjectGroup subjectGroup)
        {
            var connection=dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO SubjectGroups(FrenchName,EnglishName,Sequence) 
                                         VALUES(@frenchName,@englishName,@sequence);";
            var result=connection.Execute(query, new {
                frenchName= subjectGroup.FrenchName,
                englishName= subjectGroup.EnglishName,
                sequence= subjectGroup.Sequence
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SubjectGroup?> GetAsync(string name)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM SubjectGroups WHERE FrenchName=@name ;"; 
            var result = connection.Query< SubjectGroup>(query, new { name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SubjectGroup>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM SubjectGroups ;";
            var result = connection.Query<SubjectGroup>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SubjectGroup subjectGroup)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"UPDATE SubjectGroups SET FrenchName=@frenchName,EnglishName=@englishName,Sequence=@sequence 
                                     WHERE Id=@id";
            var result = connection.Execute(query, new {
                frenchName = subjectGroup.FrenchName,
                englishName = subjectGroup.EnglishName,
                sequence = subjectGroup.Sequence,
                id= subjectGroup.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
