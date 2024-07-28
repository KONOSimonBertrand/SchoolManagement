

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IJobService
    {
        public Task<bool> CreateJob(Job job);
        public Task<bool> UpdateJob(Job job);
        public Task<Job> GetJob(string name);
        public Task<IList<Job>> GetJobList();
    }
}
