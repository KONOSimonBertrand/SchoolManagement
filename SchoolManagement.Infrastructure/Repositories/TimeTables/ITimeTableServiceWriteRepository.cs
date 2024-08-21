

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ITimeTableServiceWriteRepository
    {
        public Task<bool> AddTimeTableAsync(TimeTable timeTable);
        public Task<bool> UpdateTimeTableAsync(TimeTable timeTable);
        public Task<bool> DeleteTimeTableAsync(int timeTableId);
    }
}
