
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class TuitionOrderService : ITuitionOrderService
    {
        private readonly ITuitionOrderWriteRepository tuitionOrderWriteRepository;
        private readonly ITuitionOrderReadRepository tuitionOrderReadRepository;
        public TuitionOrderService(ITuitionOrderRepository tuitionOrderRepository)
        {
            this.tuitionOrderWriteRepository = tuitionOrderRepository;
            this.tuitionOrderReadRepository = tuitionOrderRepository;
        }

        public async Task<bool> CreateTuitionOrderAsync(TuitionOrder order)
        {
            return await tuitionOrderWriteRepository.SaveTuitionOrderAsync(order);
        }

        public async Task<List<TuitionOrderItem>> GetTuitionOrderItemsAsync(int orderId)
        {
           return await tuitionOrderReadRepository.GetTuitionOrderItemsAsync(orderId);
        }

        public async Task<List<TuitionOrder>> GetTuitionOrdersByEnrollingAsync(int enrollingId)
        {
            return await tuitionOrderReadRepository.GetTuitionOrdersByEnrollingAsync(enrollingId);
        }

        public async Task<List<TuitionOrder>> GetTuitionOrdersBySchoolYearAsync(int schoolYearId)
        {
           return await tuitionOrderReadRepository.GetTuitionOrdersBySchoolYearAsync (schoolYearId);
        }
    }
}
