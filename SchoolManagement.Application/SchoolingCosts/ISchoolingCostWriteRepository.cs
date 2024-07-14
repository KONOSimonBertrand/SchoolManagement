

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SchoolingCosts
{
    public interface ISchoolingCostWriteRepository
    {
        public Task<bool> AddAsync(SchoolingCost cost);
        public Task<bool> UpdateAsync(SchoolingCost cost);
    }
}
