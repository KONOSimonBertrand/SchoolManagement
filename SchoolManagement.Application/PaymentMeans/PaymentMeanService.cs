


using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    internal class PaymentMeanService : IPaymentMeanService
    {
        private readonly IPaymentMeanReadRepository paymentMeanReadRepository;
        private readonly IPaymentMeanWriteRepository paymentMeanWriteRepository;
        public PaymentMeanService(IPaymentMeanRepository paymentMeanRepository)
        {
            this.paymentMeanReadRepository = paymentMeanRepository;
            this.paymentMeanWriteRepository = paymentMeanRepository;
        }

        public async Task<bool> CreatePaymentMean(PaymentMean paymentMean)
        {
            return await paymentMeanWriteRepository.AddAsync(paymentMean);
        }

        public async Task<PaymentMean?> GetPaymentMean(string name)
        {
            return await paymentMeanReadRepository.GetAsync(name);
        }

        public async Task<IList<PaymentMean>> GetPaymentMeanList()
        {
            return await paymentMeanReadRepository.GetAsyncList();
        }

        public async Task<bool> UpdatePaymentMean(PaymentMean paymentMean)
        {
            return await paymentMeanWriteRepository.UpdateAsync(paymentMean);
        }
    }
}
