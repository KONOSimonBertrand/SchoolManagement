using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class DbContextCashFlowTypeRepository : ICashFlowTypeRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextCashFlowTypeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<bool> AddAsync(CashFlowType cashFlowType)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.CashFlowTypes.Add(cashFlowType);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;

        }

        public async Task<CashFlowType?> GetAsyn(string name)
        {
            var result = appDbContext.CashFlowTypes.FirstOrDefault(x => x.Name == name);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<CashFlowType>> GetAsynList()
        {
            var result = appDbContext.CashFlowTypes.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(CashFlowType cashFlowType)
        {
            bool isDone = false;
            appDbContext.ChangeTracker.Clear();
            var item = appDbContext.CashFlowTypes.FirstOrDefault(x => x.Id == cashFlowType.Id);
            if (item != null)
            {
                item.Id = cashFlowType.Id;
                item.Name = cashFlowType.Name;
                item.Sequence = cashFlowType.Sequence;
                item.Description = cashFlowType.Description;
                item.Domain = cashFlowType.Domain;
                if (appDbContext.SaveChanges() > 0) isDone = true;
            }
            await Task.Delay(0);
            return isDone;
        }
    }
}
