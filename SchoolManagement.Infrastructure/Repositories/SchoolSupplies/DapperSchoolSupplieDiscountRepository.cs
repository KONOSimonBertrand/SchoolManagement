

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSchoolSupplieDiscountRepository : ISchoolSupplieDiscountRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperSchoolSupplieDiscountRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> AddSchoolSupplieDiscountAsync(SchoolSupplieDiscount discount)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO SchoolSupplieDiscount(Date,Discount,DiscountType,EnrollingId,CashFlowTypeId,OrderedBy,Reason,IsActive) 
                              VALUES(@date,@discount,@discountType,@enrollingId,@cashFlowTypeId,@orderedBy,@reason,@state);";
            var result = connection.Execute(query, new
            {
                date = discount.Date,
                discount = discount.Discount,
                discountType = discount.DiscountType,
                enrollingId = discount.EnrollingId,
                cashFlowTypeId = discount.CashFlowTypeId,
                orderedBy = discount.OrderedBy,
                reason = discount.Reason,
                state=discount.IsActive
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async  Task<bool> ChangeStateSchoolSupplieDiscountAsync(SchoolSupplieDiscount discount)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE SchoolSupplieDiscount SET IsActive=@state 
                              WHERE Id = @id  ;";
            var result = connection.Execute(query, new
            {
                state = discount.IsActive,
                id = discount.Id,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<List<SchoolSupplieDiscount>> GetSchoolSupplieDiscountByEnrollingListAsync(int enrollingId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplieDiscount AS A 
                             INNER JOIN CashFlowTypes AS C ON A.CashFlowTypeId=C.Id
                             WHERE A.EnrollingId=@enrollingId ";
            var result = connection.Query<SchoolSupplieDiscount, CashFlowType, SchoolSupplieDiscount>(query,
                (discount, cashFlowType) =>
                {
                    discount.CashFlowType = cashFlowType;
                    return discount;
                }, new { enrollingId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<SchoolSupplieDiscount>> GetSchoolSupplieDiscountBySchoolYearListAsync(int schoolYearId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM SchoolSupplieDiscount AS A 
                            INNER JOIN CashFlowTypes AS C ON A.CashFlowTypeId=C.Id
                            WHERE A.EnrollingId IN (SELECT Id FROM StudentsEnrollings WHERE SchoolYearId=@schoolYearId);";
            var result = connection.Query<SchoolSupplieDiscount, CashFlowType, SchoolSupplieDiscount>(query,
                (discount, cashFlowType) =>
                {
                    discount.CashFlowType = cashFlowType;
                    return discount;
                },
                new { schoolYearId }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateSchoolSupplieDiscountAsync(SchoolSupplieDiscount discount)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE SchoolSupplieDiscount SET Date=@date,Discount=@discount,OrderedBy=@orderedBy,Reason=@reason 
                              WHERE Id=@id  ;";
            var result = connection.Execute(query, new
            {
                date = discount.Date,
                discount = discount.Discount,
                discountType = discount.DiscountType,
                orderedBy = discount.OrderedBy,
                reason = discount.Reason,
                enrollingId = discount.EnrollingId,
                cashFlowTypeId = discount.CashFlowTypeId,
                id=discount.Id

            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
