

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ISchoolingCostReadRepository
    {
        public Task<SchoolingCost> GetAsync(int classId, int costTypeId, int schoolYearId);
        public Task<IList<SchoolingCost>> GetListAsync();
        /// <summary>
        /// extraction des lignes d'un SchoolingCost
        /// </summary>
        public Task<IList<SchoolingCostItem>> GetItemsAsync(int schoolingCostId);

    }
}
