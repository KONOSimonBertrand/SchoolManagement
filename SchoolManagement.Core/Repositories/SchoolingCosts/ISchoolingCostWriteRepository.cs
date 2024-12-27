

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolingCostWriteRepository
    {
        public Task<bool> AddAsync(SchoolingCost cost);
        public Task<bool> UpdateAsync(SchoolingCost cost);
    }
}
