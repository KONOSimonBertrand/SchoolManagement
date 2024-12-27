

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class TimeTableService : ITimeTableService
    {
        private readonly ITimeTableServiceReadRepository timeTableServiceReadRepository;
        private readonly ITimeTableServiceWriteRepository timeTableServiceWriteRepository;
        public TimeTableService(ITimeTableServiceRepository timeTableServiceRepository)
        {
            this.timeTableServiceReadRepository = timeTableServiceRepository;
            this.timeTableServiceWriteRepository = timeTableServiceRepository;
        }

        public async Task<bool> CreateTimeTableAsync(TimeTable timeTable)
        {
            return await timeTableServiceWriteRepository.AddTimeTableAsync(timeTable);
        }

        public async Task<bool> DeleteTimeTableAsync(int timeTableId)
        {
            return await timeTableServiceWriteRepository.DeleteTimeTableAsync(timeTableId);
        }

        public async Task<TimeTable?> GetTimeTableAsync(int subjectId, int roomId, DateTime start, DateTime end)
        {
            return await timeTableServiceReadRepository.GetTimeTableAsync(subjectId, roomId, start, end);
        }

        public async Task<IList<TimeTable>> GetTimeTableListAsync(int schoolYearId)
        {
            return await timeTableServiceReadRepository.GetTimeTableListAsync(schoolYearId);
        }

        public async Task<IList<TimeTable>> GetTimeTableListAsync(int roomId, int schoolYearId)
        {
            return await timeTableServiceReadRepository.GetTimeTableListAsync(roomId, schoolYearId);
        }

        public async Task<IList<TimeTable>> GetTimeTableListAsync(int roomId, int schoolYearId, DateTime start, DateTime end)
        {
            return await timeTableServiceReadRepository.GetTimeTableListAsync(roomId, schoolYearId,start,end);

        }

        public async Task<bool> UpdateTimeTableAsync(TimeTable timeTable)
        {
            return await timeTableServiceWriteRepository.UpdateTimeTableAsync(timeTable);
        }
    }
}
