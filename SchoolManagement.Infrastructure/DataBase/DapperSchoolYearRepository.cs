using Dapper;
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class DapperSchoolYearRepository : ISchoolYearRepository
    {
        private readonly IDbConnectionFactoty _dbConnectionFactory;
        public DapperSchoolYearRepository(IDbConnectionFactoty dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public  Task<List<SchoolYear>> GetAllAsync()
        {
            var connection = _dbConnectionFactory.CreateConnection();
            string sqlText = "SELECT * FROM SchoolYears ";
            var result= connection.Query<SchoolYear>(sqlText).ToList();
            return Task.FromResult(result);
        }

        public Task<bool> AddAsync(SchoolYear schoolYear)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            string sqlText = @"INSERT INTO SchoolYears(Name, StartFirstQuarter, EndFirstQuarter, StartSecondQuarter, EndSecondQuarter, StartThirdQuarter, EndThirdQuarter, ) 
                              VALUES(@name, @startFirstQuarter, @endFirstQuarter, @startsecondQuarter, @endSecondQuarter, @startThirdQuarter, @endThirdQuarter) ;";
            var result = connection.Execute(sqlText,
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
            return Task.FromResult(result > 0);
        }

        public Task<bool> UpdateAsync(SchoolYear schoolYear)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            string sqlText = @"UPDATE SchoolYears 
                               SET Name=@name,StartFirstQuarter=@startFirstQuarter,EndFirstQuarter=@endFirstQuarter,StartSecondQuarter=@startsecondQuarter, EndSecondQuarter=@endSecondQuarter,StartThirdQuarter=@startThirdQuarter,EndThirdQuarter=@endThirdQuarter 
                               WHERE Id=@Id";  
            var result = connection.Execute(sqlText,
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
            return Task.FromResult(result > 0);
        }
    }
}
