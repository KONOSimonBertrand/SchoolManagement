

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.PaymentMeans
{
    public  interface IPaymentMeanReadRepository
    {
        public Task<PaymentMean?> GetAsync(string name);
        public Task<IList<PaymentMean>> GetAsyncList();
    }
}
