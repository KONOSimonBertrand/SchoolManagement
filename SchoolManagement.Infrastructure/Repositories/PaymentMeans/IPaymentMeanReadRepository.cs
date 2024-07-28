

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public  interface IPaymentMeanReadRepository
    {
        public Task<PaymentMean?> GetAsync(string name);
        public Task<IList<PaymentMean>> GetAsyncList();
    }
}
