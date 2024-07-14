

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolingCosts
{
    public class SchoolingCostService : ISchoolingCostService
    {
        private readonly ISchoolingCostWriteRepository schoolingCostWriteRepository;
        private readonly ISchoolingCostReadRepository schoolingCostReadRepository;
        public SchoolingCostService(ISchoolingCostRepository schoolingCostRepository)
        {
            schoolingCostWriteRepository= schoolingCostRepository;
            schoolingCostReadRepository = schoolingCostRepository;
        }
        public async Task<bool> CreateSchoolingCost(SchoolingCost cost)
        {
            return await schoolingCostWriteRepository.AddAsync(cost);   
        }

        public async Task<SchoolingCost> GetSchoolingCost(int classId, int cashFlowTypeId, int schoolYearId)
        {
            return await schoolingCostReadRepository.GetAsync(classId, cashFlowTypeId, schoolYearId);
        }

        public async Task<IList<SchoolingCostItem>> GetSchoolingCostItems(int schoolingCostId)
        {
            return await schoolingCostReadRepository.GetItemsAsync(schoolingCostId);
        }

        public async Task<IList<SchoolingCost>> GetSchoolingCostList()
        {
            return await schoolingCostReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateSchoolingCost(SchoolingCost cost)
        {
            return await schoolingCostWriteRepository.UpdateAsync(cost);
        }
    }
}
