using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionWriteRepository subscriptionWriteRepository;
        private readonly ISubscriptionReadRepository subscriptionReadRepository;
        private readonly IGenerateIdNumberService generateIdNumberService;
        private readonly ISchoolYearRepository schoolYeaRepository;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IGenerateIdNumberService generateIdNumberService, ISchoolYearRepository schoolYearRepository)
        {
            this.subscriptionWriteRepository = subscriptionRepository;
            this.subscriptionReadRepository = subscriptionRepository;
            this.generateIdNumberService = generateIdNumberService;
            this.schoolYeaRepository = schoolYearRepository;
        }

        public async Task<bool> ReturnSubscriptionAsync(Subscription subscription)
        {
            subscription.IdNumber = subscription.IdNumber + "-R";
            subscription.Amount = (-1) * subscription.Amount;
            return await subscriptionWriteRepository.AddSubscriptionAsync(subscription);
        }

        public async Task<bool> CreateSubscriptionAsync(Subscription subscription)
        {
            subscription.IdNumber=await GenerateSubscriptionIdNumber();
            subscription.TransactionId = subscription?.TransactionId?.Trim() == string.Empty ? subscription.IdNumber : subscription.TransactionId;
            return await subscriptionWriteRepository.AddSubscriptionAsync(subscription);
        }
        public async Task<string> GenerateSubscriptionIdNumber()
        {
            string idNumber;
            var lastRecord = await subscriptionReadRepository.GetLastSubscriptionAsync();
            SchoolYear? lastSchoolYear = await schoolYeaRepository.GetLastSchoolYearAsync();
            int lastNumber = 0;
            int year = DateTime.Now.Year;
            if (lastRecord != null)
            {
                lastNumber = int.Parse(lastRecord.IdNumber.Substring(3, 5));
            }
            if (lastSchoolYear != null)
            {
                year = int.Parse(lastSchoolYear.Name.Substring(0, 4));
            }
            lastNumber++;
            idNumber = generateIdNumberService.GenerateNextIdNumberWithFiveDigit('A', lastNumber, year);
            await Task.Delay(0);
            return idNumber;
        }
        public async Task<Subscription?> GetSubscriptionAsync(int enrollingId, int cashFlowTypeId, DateTime subscriptionDate)
        {
            return await subscriptionReadRepository.GetSubscriptionAsync(enrollingId, cashFlowTypeId,subscriptionDate);
        }

        public async Task<Subscription?> GetSubscriptionAsync(string idNumber)
        {
            return await subscriptionReadRepository.GetSubscriptionAsync(idNumber);
        }

        public async Task<List<Subscription>> GetSubscriptionListByEnrollingAsync(int enrollingId)
        {
            return await subscriptionReadRepository.GetSubscriptionListByEnrollingAsync(enrollingId);
        }

        public  async Task<List<Subscription>> GetSubscriptionListBySchoolYearAsync(int schoolyearId)
        {
            return await subscriptionReadRepository.GetSubscriptionListBySchoolYearAsync(schoolyearId);
        }

        public async Task<bool> ValidateSubscriptionAsync(int subscriptionId)
        {
            return await subscriptionWriteRepository.ValidateSubscriptionAsync(subscriptionId);
        }
    }
}
