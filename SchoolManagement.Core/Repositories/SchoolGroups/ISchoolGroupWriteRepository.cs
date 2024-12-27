

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public  interface ISchoolGroupWriteRepository
    {
        public Task<bool> AddAsync(SchoolGroup schoolGroup);
        public Task<bool> UpdateAsync(SchoolGroup schoolGroup);
    }
}
