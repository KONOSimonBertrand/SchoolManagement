

using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public class StudentEnrollingService : IStudentEnrollingService
    {
        private readonly IStudentEnrollingReadRepository studentEnrollingReadRepository;
        private readonly IStudentEnrollingWriteRepository studentEnrollingWriteRepository;

        public StudentEnrollingService(IStudentEnrollingRepository studentEnrollingRepository)
        {
            this.studentEnrollingReadRepository = studentEnrollingRepository;
            this.studentEnrollingWriteRepository = studentEnrollingRepository;
        }

        public async Task<bool> CreateStudentEnrollingAsync(StudentEnrolling enrolling)
        {
            return await studentEnrollingWriteRepository.AddStudentEnrollingAsync(enrolling);
        }

        public async Task<bool> CreateStudentRoomAsync(StudentRoom room)
        {
            return await studentEnrollingWriteRepository.AddStudentRoomAsync(room);  
        }

        public async Task<bool> DeleteStudentRoomAsync(int StudentId, int RoomId, int schoolYearId)
        {
            return await studentEnrollingWriteRepository.DeleteStudentRoomAsync(StudentId,RoomId, schoolYearId);
        }

        public async Task<StudentEnrolling?> GetStudentEnrollingAsync(int studentId, int schoolyearId)
        {
            return await studentEnrollingReadRepository.GetStudentEnrollingAsyn(studentId,schoolyearId);
        }

        public async Task<List<StudentEnrolling>> GetStudentEnrollingListAsync(int schoolyearId)
        {
            return await studentEnrollingReadRepository.GetStudentEnrollingLIstAsync(schoolyearId);
        }

        public async Task<StudentRoom?> GetStudentRoomAsync(int studentId, int schoolYearId)
        {
            return await studentEnrollingReadRepository.GetStudentRoomAsync(studentId,schoolYearId);
        }

        public async  Task<List<StudentRoom>> GetStudentRoomListAsync(int roomId, int schoolYearId)
        {
            return await studentEnrollingReadRepository.GetStudentRoomListAsync(roomId,schoolYearId);
        }
        public async Task<List<StudentRoom>> GetStudentRoomListAsync(int schoolYearId)
        {
            return await studentEnrollingReadRepository.GetStudentRoomListAsync(schoolYearId);
        }

        public async Task<bool> UpdateStudentEnrollingAsync(StudentEnrolling enrolling)
        {
            return await studentEnrollingWriteRepository.UpdateStudentEnrollingAsync(enrolling);
        }
    }
}
