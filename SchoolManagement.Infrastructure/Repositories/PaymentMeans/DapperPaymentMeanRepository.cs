

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class DapperPaymentMeanRepository : IPaymentMeanRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperPaymentMeanRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }
        public async Task<bool> AddAsync(PaymentMean mean)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO PaymentMeans( Name,Account,Type,Sequence) 
                                                 VALUES(@name,@account,@type,@sequence);";
            var result = connection.Execute(query, new
            {
                name = mean.Name,
                account = mean.Account,
                type = mean.Type,
                sequence = mean.Sequence
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<PaymentMean?> GetAsync(string name)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = "SELECT * FROM PaymentMeans WHERE Name=@name ;";
            var result = connection.Query<PaymentMean>(query, new { name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<PaymentMean>> GetAsyncList()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = "SELECT * FROM PaymentMeans ;";
            var result = connection.Query<PaymentMean>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(PaymentMean mean)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"UPDATE PaymentMeans SET Name=@name,Account=@account,Type=@type,Sequence=@sequence 
                           WHERE Id=@id;";
            var result = connection.Execute(query, new
            {
                name = mean.Name,
                account = mean.Account,
                type = mean.Type,
                sequence = mean.Sequence,
                id = mean.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
