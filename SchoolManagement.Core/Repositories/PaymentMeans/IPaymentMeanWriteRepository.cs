
using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public  interface IPaymentMeanWriteRepository
    {
        public Task<bool> UpdateAsync(PaymentMean mean);
        public Task<bool> AddAsync(PaymentMean mean);
    }
}
