﻿
using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperEmployeeGroupRepository : IEmployeeGroupRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperEmployeeGroupRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddAsync(EmployeeGroup group)
        {
            var connection=dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO EmployeeGroups(Name) VALUES(@name) ;";
            var result = connection.Execute(query, new {name=group.Name});
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<EmployeeGroup?> GetAsync(string name)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeeGroups WHERE Name=@name ;";
            var result = connection.Query<EmployeeGroup>(query, new {name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async  Task<IList<EmployeeGroup>> GetListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM EmployeeGroups ORDER BY Sequence  ;";
            var result = connection.Query<EmployeeGroup>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(EmployeeGroup group)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE EmployeeGroups SET Name=@name WHERE Id=@id ;";
            var result = connection.Execute(query, new { name = group.Name,id=group.Id });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
