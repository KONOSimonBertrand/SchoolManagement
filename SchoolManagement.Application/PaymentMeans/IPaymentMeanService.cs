

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.PaymentMeans
{
    public interface IPaymentMeanService
    {
        public Task<bool> CreatePaymentMean(PaymentMean paymentMean);
        public Task<bool> UpdatePaymentMean(PaymentMean paymentMean);
        public Task<PaymentMean?> GetPaymentMean(string name);
        public Task<IList<PaymentMean>> GetPaymentMeanList();
    }
}
