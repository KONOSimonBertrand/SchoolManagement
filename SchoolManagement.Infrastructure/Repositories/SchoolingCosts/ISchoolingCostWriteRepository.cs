

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISchoolingCostWriteRepository
    {
        public Task<bool> AddAsync(SchoolingCost cost);
        public Task<bool> UpdateAsync(SchoolingCost cost);
    }
}
