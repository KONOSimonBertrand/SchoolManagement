using SchoolManagement.Application.PaymentMeans;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class DbContextPaymentMeanRepository: IPaymentMeanRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextPaymentMeanRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<bool> AddAsync(PaymentMean mean)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.PaymentMeans.Add(mean);
            var result=appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<PaymentMean?> GetAsync(string name)
        {
            var result=appDbContext.PaymentMeans.FirstOrDefault(x => x.Name == name);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<PaymentMean>> GetAsyncList()
        {
            var result=appDbContext.PaymentMeans.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(PaymentMean mean)
        {
            appDbContext.ChangeTracker.Clear();
            bool isDone = false;
            var item=appDbContext.PaymentMeans.FirstOrDefault(x => x.Id == mean.Id);
            if (item != null) { 
                item.Id = mean.Id;
                item.Name = mean.Name;
                item.Account = mean.Account;
                item.Sequence = mean.Sequence;
                appDbContext.Update(item);
                if (appDbContext.SaveChanges() > 0) isDone = true; 
            }
            await Task.Delay(0);
            return isDone;
        }
    }
}
