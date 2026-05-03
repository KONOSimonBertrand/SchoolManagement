

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IStudentEnrollingService
    {
        /// <summary>
        /// Permet de créer une inscription d'un étudiant pour une année scolaire donnée. Cette méthode prend en paramètre un objet StudentEnrolling qui contient les informations nécessaires à l'inscription, telles que l'identifiant de l'étudiant, l'identifiant de l'année scolaire, la date d'inscription, etc. La méthode retourne un booléen indiquant si l'inscription a été créée avec succès ou non.
        /// </summary>
        /// <param name="enrolling"></param>
        /// <returns></returns>
        public Task<bool> CreateStudentEnrollingAsync(StudentEnrolling enrolling);
        public Task<bool> UpdateStudentEnrollingAsync(StudentEnrolling enrolling);
        public Task<StudentEnrolling?> GetStudentEnrollingAsync(int studentId, int schoolyearId);
        public Task<List<StudentEnrolling>> GetStudentEnrollingListAsync(int schoolyearId);
        public Task<bool> CreateStudentRoomAsync(StudentRoom room);
        public Task<bool> DeleteStudentRoomAsync(int studentId,int schoolYearId);
        public Task<StudentRoom?> GetStudentRoomAsync(int studentId, int schoolYearId);
        public Task<List<StudentRoom>> GetStudentRoomListAsync(int roomId,int schoolYearId);
        public Task<List<StudentRoom>> GetStudentRoomListAsync(int schoolYearId);
        public Task<bool> SaveStudentEnrollingPictureAsync(int studentId, string urlPicture);
        public Task<bool> ChangeStudentEnrollingStatusAsync(int enrollingId,bool status,string reason);

    }
}
