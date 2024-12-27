

using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextSubscriptionFeeRepository : ISubscriptionFeeRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextSubscriptionFeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<bool> AddAsync(SubscriptionFee subscriptionFee)
        {
            appDbContext.ChangeTracker.Clear();
            subscriptionFee.CashFlowType = appDbContext.CashFlowTypes.FirstOrDefault(x => x.Id == subscriptionFee.CashFlowTypeId);
            subscriptionFee.SchoolYear = appDbContext.SchoolYears.FirstOrDefault(x => x.Id == subscriptionFee.SchoolYearId);
            appDbContext.SubscriptionFees.Add(subscriptionFee);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SubscriptionFee> GetAsync(int cashFlowTypeId, int schoolYearId)
        {
            var result = appDbContext.SubscriptionFees
                .Include(x => x.CashFlowType)
                .Include(x => x.SchoolYear)
                .FirstOrDefault(x => x.CashFlowTypeId == cashFlowTypeId && x.SchoolYearId == schoolYearId);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SubscriptionFee>> GetListAsync()
        {
            var result = appDbContext.SubscriptionFees
                .Include(x => x.CashFlowType)
                .Include(x => x.SchoolYear)
                .OrderByDescending(x => x.SchoolYearId)
                .ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> Updatesync(SubscriptionFee subscriptionFee)
        {
            appDbContext.ChangeTracker.Clear();
            subscriptionFee.CashFlowType = appDbContext.CashFlowTypes.FirstOrDefault(x => x.Id == subscriptionFee.CashFlowTypeId);
            subscriptionFee.SchoolYear = appDbContext.SchoolYears.FirstOrDefault(x => x.Id == subscriptionFee.SchoolYearId);
            appDbContext.SubscriptionFees.Update(subscriptionFee);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }
    }
}
