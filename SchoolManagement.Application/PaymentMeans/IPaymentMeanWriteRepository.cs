
using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.PaymentMeans
{
    public  interface IPaymentMeanWriteRepository
    {
        public Task<bool> UpdateAsync(PaymentMean mean);
        public Task<bool> AddAsync(PaymentMean mean);
    }
}
