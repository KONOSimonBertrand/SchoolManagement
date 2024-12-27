using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IStudentEnrollingWriteRepository
    {
        Task<bool> AddEnrollingAsync(StudentEnrolling enrolling);
        Task<bool> AddStudentRoomAsync(StudentRoom room);
        Task<bool> DeleteStudentRoomAsync(int studentId,  int schoolYearId);
        Task<bool> AddEnrollingPictureAsync(int enrollingId, string urlPicture);
        Task<bool> UpdateEnrollingAsync(StudentEnrolling enrolling);
        Task<bool> ChangeEnrollingStatus(int enrollingId,bool status,string reason);
    }
}