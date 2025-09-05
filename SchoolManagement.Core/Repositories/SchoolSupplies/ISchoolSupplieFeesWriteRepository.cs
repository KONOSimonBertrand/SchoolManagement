using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ISchoolSupplieFeesWriteRepository
    {
        public Task<bool> AddAsync(SchoolSupplieFee schoolSupplieFee);
        public Task<bool> Updatesync(SchoolSupplieFee schoolSupplieFee);
    }
}