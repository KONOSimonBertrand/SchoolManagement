using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IStudentReadRepository
    {
        /// <summary>
        /// Retourne le dernier étudiant ajouté à la base de données.
        /// </summary>
        /// <returns></returns>
        Task<Student?> GetLastStudentAsync();
        /// <summary>
        /// Retourne un étudiant dont le numéro d'identification correspond au numéro fourni en paramètre.
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        Task<Student?> GetStudentAsync(string idNumber);
        /// <summary>
        /// Retourne une liste de tous les étudiants.
        /// </summary>
        /// <returns></returns>
        Task<List<Student>> GetStudentListAsync();
        /// <summary>
        /// Permet de rechercher les étudiants par nom, prénom ou numéro d'identification
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        Task<List<Student>> GetStudentListAsync(string searchTerm, CancellationToken token);
    }
}