using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IStudentWriteRepository
    {
        /// <summary>
        /// Permet d'ajouter un étudiant à la base de données de manière asynchrone.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<bool> AddStudentAsync(Student student);
        /// <summary>
        /// Permet d'ajouter ou de mettre à jour l'URL de la photo d'un étudiant dans la base de données de manière asynchrone.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="urlPicture"></param>
        /// <returns></returns>
        Task<bool> AddStudentPictureAsync(int studentId, string urlPicture);
        /// <summary>
        /// Permet de mettre à jour les informations d'un étudiant dans la base de données de manière asynchrone.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<bool> UpdateStudentAsync(Student student);
    }
}