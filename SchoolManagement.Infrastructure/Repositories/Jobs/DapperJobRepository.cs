﻿
using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperJobRepository : IJobRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperJobRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddAsync(Job job)
        {
            var connection=dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO Jobs(Name) VALUES(@name) ;";
            var result = connection.Execute(query, new {name=job.Name});
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<Job?> GetAsync(string name)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Jobs WHERE Name=@name ;";
            var result = connection.Query<Job>(query, new {name}).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Job>> GetListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Jobs ;";
            var result = connection.Query<Job>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async  Task<bool> UpdateAsync(Job job)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Jobs SET Name=@name WHERE Id=@id  ;";
            var result = connection.Execute(query, new { name = job.Name, id = job.Id });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
