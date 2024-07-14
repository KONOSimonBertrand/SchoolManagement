
using Dapper;
using SchoolManagement.Application.Logs;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class DapperLogRepository : ILogRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperLogRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<bool> AddAsync(Log log)
        {
            var connection=dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO Logs(Id,UserAction,UserId,CreateDate) 
                           VALUES(@id,@action,@user,@date);";
            var result=connection.Execute(query, new
            {
                id=Guid.NewGuid(),
                action=log.UserAction,
                user=log.UserId,
                date=DateTime.Now
            });
            await Task.Delay(0);
            return result>1;
        }

        public async Task<IEnumerable<Log>> GetListAsync(DateTime date)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM Logs WHERE DATE(CreateDate)=@date ;";
            var result=connection.Query<Log>(query, new { date = date.Date }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IEnumerable<Log>> GetListAsync(int userId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM Logs WHERE UserId=@userId ;";
            var result = connection.Query<Log>(query, new { userId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IEnumerable<Log>> GetListAsync(DateTime start, DateTime end)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM Logs WHERE DATE(CreateDate)>=@startDate AND DATE(CreateDate)<=@endDate  ;";
            var result = connection.Query<Log>(query, new { startDate = start.Date, endDate = end.Date }).ToList();
            await Task.Delay(0);
            return result;
        }
    }
}
