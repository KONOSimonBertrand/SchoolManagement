

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SubscriptionFees
{
    public class SubscriptionFeeService : ISubscriptionFeeService
    {
        private readonly ISubscriptionFeeWriteRepository subscriptionFeeWriteRepository;
        private readonly ISubscriptionFeeReadRepository subscriptionFeeReadRepository;
        public SubscriptionFeeService(ISubscriptionFeeRepository subscriptionFeeRepository)
        {
            subscriptionFeeReadRepository= subscriptionFeeRepository;
            subscriptionFeeWriteRepository= subscriptionFeeRepository;
        }
        public async Task<bool> CreateSubscriptionFee(SubscriptionFee subscriptionFee)
        {
            return await subscriptionFeeWriteRepository.AddAsync(subscriptionFee);
        }

        public async Task<SubscriptionFee> GetSubscriptionFee(int cashFlowTypeId, int schoolYearId)
        {
            return await subscriptionFeeReadRepository.GetAsync(cashFlowTypeId, schoolYearId);  
        }

        public async Task<IList<SubscriptionFee>> GetSubscriptionFeeList()
        {
            return await subscriptionFeeReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateSubscriptionFee(SubscriptionFee subscriptionFee)
        {
            return await subscriptionFeeWriteRepository.Updatesync(subscriptionFee);
        }
    }
}
