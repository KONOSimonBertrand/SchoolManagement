

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    /// <summary>
    ///permet de gérer les opérations liées aux étudiants, telles que la création, la mise à jour, la récupération et la recherche d'étudiants dans la base de données.
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Permet de générer un numéro d'identification unique pour un nouvel étudiant en utilisant le service de génération de numéros d'identification et les informations sur le dernier étudiant et la dernière année scolaire.
        /// </summary>
        /// <returns></returns>
        public Task<string> GenerateStudentIdNumberAsync();
        /// <summary>
        /// permet de créer un nouvel étudiant dans la base de données.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Task<bool> CreateStudentAsync(Student student);
        /// <summary>
        /// Permet de mettre à jour les informations d'un étudiant.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Task<bool> UpdateStudentAsync(Student student);
        /// <summary>
        /// Retourne les informations d'un étudiant à partir de son numéro d'identification.
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        public Task<Student> GetStudentAsync(string idNumber);
        /// <summary>
        /// Permet de récupérer le dernier étudiant ajouté à la base de données.
        /// </summary>
        /// <returns></returns>
        public Task<Student> GetLastStudentAsync();
        /// <summary>
        /// Permet de récupérer la liste de tous les étudiants de la base de données.
        /// </summary>
        /// <returns></returns>
        public Task<List<Student>> GetStudentListsync();
        /// <summary>
        /// Permet de rechercher les étudiants par nom, prénom ou numéro d'identification
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public Task<List<Student>> GetStudentListsync(string searchTerm, CancellationToken token);
        /// <summary>
        /// Permet d'ajouter ou de mettre à jour l'URL de la photo d'un étudiant dans la base de données.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="urlPicture"></param>
        /// <returns></returns>
        public Task<bool> SaveStudentPictureAsync(int studentId, string urlPicture);

    }
}
