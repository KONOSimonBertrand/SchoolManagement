using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IStudentEnrollingReadRepository
    {
        Task<StudentEnrolling?> GetStudentEnrollingAsyn(int studentId, int schoolyearId);
        Task<List<StudentEnrolling>> GetStudentEnrollingLIstAsync(int schoolyearId);
        Task<StudentRoom?> GetStudentRoomAsync(int studentId, int schoolYearId);
        Task<List<StudentRoom>> GetStudentRoomListAsync(int roomId,int schoolYearId);
        Task<List<StudentRoom>> GetStudentRoomListAsync(int schoolYearId);
    }
}