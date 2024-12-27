

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public  interface IPaymentMeanReadRepository
    {
        public Task<PaymentMean?> GetAsync(string name);
        public Task<IList<PaymentMean>> GetAsyncList();
    }
}
