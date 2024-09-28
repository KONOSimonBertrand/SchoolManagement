using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IStudentEnrollingWriteRepository
    {
        Task<bool> AddStudentEnrollingAsync(StudentEnrolling enrolling);
        Task<bool> AddStudentRoomAsync(StudentRoom room);
        Task<bool> DeleteStudentRoomAsync(int studentId,  int schoolYearId);
        Task<bool> AddStudentEnrollingPictureAsync(int enrollingId, string urlPicture);
        Task<bool> UpdateStudentEnrollingAsync(StudentEnrolling enrolling);
    }
}