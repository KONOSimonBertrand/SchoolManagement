

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ITimeTableService
    {
        public Task<bool> CreateTimeTableAsync(TimeTable timeTable);
        public Task<bool> UpdateTimeTableAsync(TimeTable timeTable);
        public Task<bool> DeleteTimeTableAsync(int timeTableId);    
        public Task<TimeTable?> GetTimeTableAsync(int subjectId,int roomId,DateTime start,DateTime end);
        public Task<IList<TimeTable>> GetTimeTableListAsync(int schoolYearId);
        public Task<IList<TimeTable>> GetTimeTableListAsync(int roomId,int schoolYearId);
        public Task<IList<TimeTable>> GetTimeTableListAsync(int roomId,int schoolYearId, DateTime start, DateTime end);
    }
}
