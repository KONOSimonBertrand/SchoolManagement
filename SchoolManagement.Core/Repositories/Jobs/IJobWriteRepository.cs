using SchoolManagement.Core.Model;


namespace SchoolManagement.Core.Repositories
{
    public  interface IJobWriteRepository
    {
        public Task<bool> AddAsync(Job job);
        public Task<bool> UpdateAsync(Job job);
    }
}
