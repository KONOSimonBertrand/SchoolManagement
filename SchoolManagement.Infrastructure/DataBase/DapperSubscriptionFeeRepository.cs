

using Dapper;
using SchoolManagement.Application.SubscriptionFees;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class DapperSubscriptionFeeRepository : ISubscriptionFeeRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperSubscriptionFeeRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<bool> AddAsync(SubscriptionFee subscriptionFee)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO SubscriptionFees(Amount,Duration,CashFlowTypeId,SchoolYearId)  
                                          VALUES(@amount,@duration,@cashFlowTypeId,@schoolYearId);";
            var result = connection.Execute(query, new
            {
                amount = subscriptionFee.Amount,
                duration = subscriptionFee.Duration,
                cashFlowTypeId = subscriptionFee.CashFlowTypeId,
                schoolYearId = subscriptionFee.SchoolYearId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SubscriptionFee> GetAsync(int cashFlowTypeId, int schoolYearId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM SubscriptionFees   A   
                             INNER JOIN CashFlowTypes B ON A.CashFlowTypeId=B.Id  
                             INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id 
                             WHERE CashFlowTypeId=@cashFlowTypeId AND SchoolYearId=@schoolYearId";
            var result = connection.Query<SubscriptionFee, CashFlowType, SchoolYear, SubscriptionFee>(query,
                 (subscriptionFee, cashFlowType, schoolYear) =>
                 {
                     subscriptionFee.CashFlowType = cashFlowType;
                     subscriptionFee.SchoolYear = schoolYear;
                     return subscriptionFee;
                 }
                , new
                {
                    cashFlowTypeId,
                    schoolYearId
                }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SubscriptionFee>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM SubscriptionFees A   
                             INNER JOIN CashFlowTypes B ON A.CashFlowTypeId=B.Id  
                             INNER JOIN SchoolYears C ON A.SchoolYearId=C.Id  ORDER BY A.SchoolYearId DESC;";
            var result = connection.Query<SubscriptionFee, CashFlowType, SchoolYear, SubscriptionFee>(query,
                (subscriptionFee, cashFlowType, schoolYear) =>
            {
                subscriptionFee.CashFlowType = cashFlowType;
                subscriptionFee.SchoolYear = schoolYear;
                return subscriptionFee;
            }
            ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> Updatesync(SubscriptionFee subscriptionFee)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"UPDATE SubscriptionFees SET Amount=@amount,Duration=@duration,CashFlowTypeId=@cashFlowTypeId,SchoolYearId=@schoolYearId  
                                          WHERE id=@id  ;";
            var result = connection.Execute(query, new
            {
                amount = subscriptionFee.Amount,
                duration = subscriptionFee.Duration,
                cashFlowTypeId = subscriptionFee.CashFlowTypeId,
                schoolYearId = subscriptionFee.SchoolYearId,
                id = subscriptionFee.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
