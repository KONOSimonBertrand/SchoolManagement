

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ITimeTableServiceReadRepository
    {
        public Task<TimeTable?> GetTimeTableAsync(int subjectId, int roomId, DateTime start, DateTime end);
        public Task<IList<TimeTable>> GetTimeTableListAsync(int schoolYearId);
        public Task<IList<TimeTable>> GetTimeTableListAsync(int roomId, int schoolYearId);
        public Task<IList<TimeTable>> GetTimeTableListAsync(int roomId, int schoolYearId, DateTime start, DateTime end);
    }
}
