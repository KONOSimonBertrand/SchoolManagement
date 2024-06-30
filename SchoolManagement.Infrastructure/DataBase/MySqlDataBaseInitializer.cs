using Dapper;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class MySqlDataBaseInitializer
    {
        private readonly IDbConnectionFactoty _connectionFactory;
        public MySqlDataBaseInitializer( IDbConnectionFactoty connectionFactoty)
        {
            _connectionFactory = connectionFactoty;
        }
        public async Task InitializeAsync()
        {
            using var connection =await  _connectionFactory.CreateConnectionAsync();

            var schoolYearTable = await connection.ExecuteAsync(@"CREATE TABLE  IF NOT EXISTS SchoolYear(
                            Id INT(11) NOT NULL AUTO_INCREMENT,
                            Name varchar(10) NOT NULL,
                            StartFirstQuarter DATE NULL,
                            EndFirstQuarter DATE NULL,
                            StartSecondQuarter DATE NULL,
                            EndSecondQuarter DATE NULL,
                            StartThirdQuarter DATE NULL,
                            EndThirdQuarter DATE NULL,
                            IsClosed TINYINT(1) DEFAULT 0,
                            CreateDate DATETIME NULL,
                            CreateUserId INT(11) NULL,
                            WriteDate DATETIME NULL,
                            WriteUserId INT(11) NULL,
                            PRIMARY KEY (Id)
                           );");

        }
    }
}
