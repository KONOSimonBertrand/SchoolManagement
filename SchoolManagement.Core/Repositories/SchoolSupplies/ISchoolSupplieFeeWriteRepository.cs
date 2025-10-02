using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolSupplieFeeWriteRepository
    {
        public Task<bool> AddAsync(SchoolSupplieFee schoolSupplieFee);
        public Task<bool> UpdateAsync(SchoolSupplieFee schoolSupplieFee);
    }
}