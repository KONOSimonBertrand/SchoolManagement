﻿

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class DapperSubjectRepository : ISubjectRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperSubjectRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddAsync(Subject subject)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO Subjects(FrenchName,EnglishName,Sequence) 
                                         VALUES(@frenchName,@englishName,@sequence);";
            var result = connection.Execute(query, new
            {
                frenchName = subject.FrenchName,
                englishName = subject.EnglishName,
                sequence = subject.Sequence
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<Subject?> GetAsync(string name)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subjects WHERE FrenchName=@name ;";
            var result = connection.Query<Subject>(query, new { name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Subject>> GetListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Subjects ORDER BY Sequence ;";
            var result = connection.Query<Subject>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(Subject subject)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Subjects SET FrenchName=@frenchName,EnglishName=@englishName,
                                     Sequence=@sequence  WHERE Id=@id";
            var result = connection.Execute(query, new
            {
                frenchName = subject.FrenchName,
                englishName = subject.EnglishName,
                sequence = subject.Sequence,
                id = subject.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
