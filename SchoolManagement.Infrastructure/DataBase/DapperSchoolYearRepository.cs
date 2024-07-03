using Dapper;
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class DapperSchoolYearRepository : ISchoolYearRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactory;
       
        public DapperSchoolYearRepository(IDbConnectionFactoty dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public  async Task<List<SchoolYear>> GetAllAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string sqlText = "SELECT * FROM SchoolYears ";
            var result= connection.Query<SchoolYear>(sqlText).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> AddAsync(SchoolYear schoolYear)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string sqlText = @"INSERT INTO SchoolYears(Name, StartFirstQuarter, EndFirstQuarter, StartSecondQuarter, EndSecondQuarter, StartThirdQuarter, EndThirdQuarter ) 
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
            await Task.Delay(0);
            return (result > 0);
        }

        public async Task<bool> UpdateAsync(SchoolYear schoolYear)
        {
            using var connection = dbConnectionFactory.CreateConnection();
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
            await Task.Delay(0);
            return (result > 0);
        }

        public async Task<SchoolYear?> GetAsync(string name)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string sqlText = "SELECT * FROM SchoolYears Where Name=@name ";
            var result = connection.Query<SchoolYear>(sqlText, new {Name=name}).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }
    }
}
