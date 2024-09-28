

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public  interface ISchoolingCostService
    {
        public Task<bool> CreateSchoolingCost(SchoolingCost cost);
        public Task<bool> UpdateSchoolingCost(SchoolingCost cost);
        public Task<SchoolingCost> GetSchoolingCost(int classId, int cashFlowTypeId, int schoolYearId);
        public Task<IList<SchoolingCost>> GetSchoolingCostList();
        public Task<IList<SchoolingCostItem>> GetSchoolingCostItems(int schoolingCostId);
        public Task<IList<SchoolingCostItem>> GetSchoolingCostItemsBySchoolYear(int schoolYearId);
    }
}
