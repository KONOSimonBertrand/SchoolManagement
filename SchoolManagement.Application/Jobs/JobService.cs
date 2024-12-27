

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class JobService : IJobService
    {
        private readonly IJobReadRepository jobReadRepository;
        private readonly IJobWriteRepository jobWriteRepository;
        public JobService(IJobRepository jobRepository)
        {
            this.jobReadRepository = jobRepository;
            this.jobWriteRepository = jobRepository;
        }
        public async Task<bool> CreateJob(Job job)
        {
           return await jobWriteRepository.AddAsync(job);
        }

        public async Task<Job> GetJob(string name)
        {
            return  await jobReadRepository.GetAsync(name);
        }

        public async Task<IList<Job>> GetJobList()
        {
            return await jobReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateJob(Job job)
        {
            return await jobWriteRepository.UpdateAsync(job);
        }
    }
}
