

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class StudentEnrollingService : IStudentEnrollingService
    {
        private readonly IStudentEnrollingReadRepository enrollingReadRepository;
        private readonly IStudentEnrollingWriteRepository enrollingWriteRepository;

        public StudentEnrollingService(IStudentEnrollingRepository enrollingRepository)
        {
            this.enrollingReadRepository = enrollingRepository;
            this.enrollingWriteRepository = enrollingRepository;
        }

        public async Task<bool> ChangeStudentEnrollingStatusAsync(int enrollingId, bool status,string reason)
        {
            return await enrollingWriteRepository.ChangeEnrollingStatus(enrollingId,status,reason);
        }

        public async Task<bool> CreateStudentEnrollingAsync(StudentEnrolling enrolling)
        {
            return await enrollingWriteRepository.AddEnrollingAsync(enrolling);
        }

        public async Task<bool> CreateStudentRoomAsync(StudentRoom room)
        {
            return await enrollingWriteRepository.AddStudentRoomAsync(room);  
        }

        public async Task<bool> DeleteStudentRoomAsync(int StudentId, int schoolYearId)
        {
            return await enrollingWriteRepository.DeleteStudentRoomAsync(StudentId, schoolYearId);
        }

        public async Task<StudentEnrolling?> GetStudentEnrollingAsync(int studentId, int schoolyearId)
        {
            return await enrollingReadRepository.GetStudentEnrollingAsyn(studentId,schoolyearId);
        }

        public async Task<List<StudentEnrolling>> GetStudentEnrollingListAsync(int schoolyearId)
        {
            return await enrollingReadRepository.GetStudentEnrollingLIstAsync(schoolyearId);
        }

        public async Task<StudentRoom?> GetStudentRoomAsync(int studentId, int schoolYearId)
        {
            return await enrollingReadRepository.GetStudentRoomAsync(studentId,schoolYearId);
        }

        public async  Task<List<StudentRoom>> GetStudentRoomListAsync(int roomId, int schoolYearId)
        {
            return await enrollingReadRepository.GetStudentRoomListAsync(roomId,schoolYearId);
        }
        public async Task<List<StudentRoom>> GetStudentRoomListAsync(int schoolYearId)
        {
            return await enrollingReadRepository.GetStudentRoomListAsync(schoolYearId);
        }

        public async Task<bool> SaveStudentEnrollingPictureAsync(int studentId, string urlPicture)
        {
           return  await enrollingWriteRepository.AddEnrollingPictureAsync(studentId, urlPicture);
        }

        public async Task<bool> UpdateStudentEnrollingAsync(StudentEnrolling enrolling)
        {
            return await enrollingWriteRepository.UpdateEnrollingAsync(enrolling);
        }
    }
}
