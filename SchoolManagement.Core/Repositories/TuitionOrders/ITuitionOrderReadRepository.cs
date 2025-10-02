

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ITuitionOrderReadRepository
    {
        public Task<TuitionOrder?> GetTuitionOrderAsync(string idNumber);
        public Task<List<TuitionOrder>> GetTuitionOrdersBySchoolYearAsync(int schoolYearId);
        public Task<List<TuitionOrder>> GetTuitionOrdersByEnrollingAsync(int enrollingId);
    }
}
