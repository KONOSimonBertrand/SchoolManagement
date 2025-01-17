﻿using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;


namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSchoolYearRepository : ISchoolYearRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public DapperSchoolYearRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<List<SchoolYear>> GetSchoolYearListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM SchoolYears ORDER BY Id DESC ";
            var result = connection.Query<SchoolYear>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> AddSchoolYearAsync(SchoolYear schoolYear)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO SchoolYears(Name, StartFirstQuarter, EndFirstQuarter, StartSecondQuarter, EndSecondQuarter, StartThirdQuarter, EndThirdQuarter ) 
                              VALUES(@name, @startFirstQuarter, @endFirstQuarter, @startsecondQuarter, @endSecondQuarter, @startThirdQuarter, @endThirdQuarter) ;";
            var result = connection.Execute(query,
            new
            {
                schoolYear.Name,
                schoolYear.StartFirstQuarter,
                schoolYear.EndFirstQuarter,
                schoolYear.StartSecondQuarter,
                schoolYear.EndSecondQuarter,
                schoolYear.StartThirdQuarter,
                schoolYear.EndThirdQuarter
            }
                );
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateSchoolYearAsync(SchoolYear schoolYear)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE SchoolYears 
                               SET Name=@name,StartFirstQuarter=@startFirstQuarter,EndFirstQuarter=@endFirstQuarter,StartSecondQuarter=@startsecondQuarter, EndSecondQuarter=@endSecondQuarter,StartThirdQuarter=@startThirdQuarter,EndThirdQuarter=@endThirdQuarter 
                               WHERE Id=@Id";
            var result = connection.Execute(query,
            new
            {
                schoolYear.Name,
                schoolYear.StartFirstQuarter,
                schoolYear.EndFirstQuarter,
                schoolYear.StartSecondQuarter,
                schoolYear.EndSecondQuarter,
                schoolYear.StartThirdQuarter,
                schoolYear.EndThirdQuarter,
                schoolYear.Id
            }
                );
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SchoolYear?> GetSchoolYearAsync(string name)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM SchoolYears Where Name=@name ";
            var result = connection.Query<SchoolYear>(query, new { Name = name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> ChangeSchoolYearStatusAsync(SchoolYear schoolYear)
        {
            schoolYear.IsClosed = !schoolYear.IsClosed;
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE SchoolYears 
                               SET IsClosed=@isClosed
                               WHERE Id=@Id";
            var result = connection.Execute(query,
            new
            {
                
                schoolYear.IsClosed,
                schoolYear.Id
            }
                );
            await Task.Delay(0);
            return result > 0;
        }

        public async  Task<SchoolYear?> GetLastSchoolYearAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM SchoolYears ORDER BY Id DESC LIMIT 1 ";
            var result = connection.QuerySingleOrDefault<SchoolYear>(query);
            await Task.Delay(0);
            return result;
        }

        public async Task<int> GetTotalSchoolYearAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT COUNT(*) FROM SchoolYears  ";
            var result = connection.ExecuteScalar<int>(query);
            await Task.Delay(0);
            return result;
        }
    }
}
