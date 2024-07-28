

using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class DbContextSchoolingCostRepository : ISchoolingCostRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextSchoolingCostRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(SchoolingCost cost)
        {
            appDbContext.ChangeTracker.Clear();
            cost.SchoolClass = appDbContext.SchoolClasses.FirstOrDefault(x => x.Id == cost.SchoolClassId);
            cost.CashFlowType = appDbContext.CashFlowTypes.FirstOrDefault(x => x.Id == cost.CashFlowTypeId);
            cost.SchoolYear = appDbContext.SchoolYears.FirstOrDefault(x => x.Id == cost.SchoolYearId);
            appDbContext.SchoolingCosts.Add(cost);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SchoolingCost> GetAsync(int classId, int costTypeId, int schoolYearId)
        {
            var result = appDbContext.SchoolingCosts
                .Include(x => x.SchoolClass)
                .Include(x => x.CashFlowType)
                .Include(x => x.SchoolYear)
                .FirstOrDefault(x => x.SchoolClassId == classId && x.CashFlowTypeId == costTypeId && x.SchoolYearId == schoolYearId);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolingCostItem>> GetItemsAsync(int schoolingCostId)
        {
            var result = appDbContext.SchoolingCostItems.Where(x => x.SchoolingCostId == schoolingCostId).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolingCost>> GetListAsync()
        {
            var result = appDbContext.SchoolingCosts
                .Include(x => x.SchoolClass)
                .Include(x => x.CashFlowType)
                .Include(x => x.SchoolYear)
                .OrderByDescending(x => x.SchoolYearId)
                .ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SchoolingCost cost)
        {
            appDbContext.ChangeTracker.Clear();
            bool isDone = false;
            var item = appDbContext.SchoolingCosts.Include(x => x.SchoolingCostItems).FirstOrDefault(x => x.Id == cost.Id);
            if (item != null)
            {
                item.SchoolClassId = cost.SchoolClassId;
                item.CashFlowTypeId = cost.CashFlowTypeId;
                item.SchoolYearId = cost.SchoolYearId;
                item.Amount = cost.Amount;
                item.TrancheNumber = cost.TrancheNumber;
                item.IsPayable = cost.IsPayable;
                item.SchoolClass = appDbContext.SchoolClasses.FirstOrDefault(x => x.Id == cost.SchoolClassId);
                item.CashFlowType = appDbContext.CashFlowTypes.FirstOrDefault(x => x.Id == cost.CashFlowTypeId);
                appDbContext.SchoolingCostItems.RemoveRange(item.SchoolingCostItems);
                item.SchoolingCostItems = cost.SchoolingCostItems;
                item.SchoolYear = appDbContext.SchoolYears.FirstOrDefault(x => x.Id == cost.SchoolYearId);
                appDbContext.Update(item);
                if (appDbContext.SaveChanges() > 0) isDone = true;
            }
            await Task.Delay(0);
            return isDone;
        }
    }
}
