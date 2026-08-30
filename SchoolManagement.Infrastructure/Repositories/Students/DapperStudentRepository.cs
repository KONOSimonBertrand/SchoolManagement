

using Dapper;
using Microsoft.Extensions.Logging;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperStudentRepository : IStudentRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        private readonly ILogger<DapperStudentRepository> logger;
        public DapperStudentRepository(IDbConnectionFactory dbConnectionFactory, ILogger<DapperStudentRepository> logger)
        {
            this.dbConnectionFactory = dbConnectionFactory;
            this.logger = logger;
        }
        public async Task<bool> AddStudentAsync(Student student)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" INSERT INTO Students(IdNumber,FirstName,LastName,Birthdate,BirthPlace,Sex,Phone,Email,Address,IdCard,Nationality,Religion,Health)  
                              VALUES(@idNumber,@firstName,@lastName,@birthdate,@birthPlace,@sex,@phone,@email,@address,@idCard,@nationality,@religion,@health);";
            int result=0;
            try
            {
                result = connection.Execute(query, new
                {
                    idNumber = student.IdNumber,
                    firstName = student.FirstName,
                    lastName = student.LastName,
                    birthdate = student.BirthDate,
                    sex = student.Sex,
                    phone = student.Phone,
                    email = student.Email,
                    address = student.Address,
                    idCard = student.IdCard,
                    nationality = student.Nationality,
                    religion = student.Religion,
                    birthPlace = student.BirthPlace,
                    health = student.Health,
                });

                logger.LogInformation("L'élève {studentName} a été ajouté avec succès dans la base de données.", student.FullName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de l'ajout de l'élève   {studentName} dans la base de données", student.FullName);
            }
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<Student?> GetLastStudentAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM Students ORDER BY Id DESC LIMIT 1;";
            Student? result;
            try
            {
                result = connection.QuerySingleOrDefault<Student>(query);
                logger.LogInformation("Dernier élève récupéré avec succès depuis la base de données.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la récupération du dernier élève depuis la base de données.");
                throw;
            }
            await Task.Delay(0);
            return result;
        }

        public async Task<Student?> GetStudentAsync(string idNumber)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM Students WHERE IdNumber=@idNumber;";
            Student? result=null;
            try
            {
                result = connection.QuerySingleOrDefault<Student>(query, new { idNumber });
                logger.LogInformation("Élève {idNumber} récupéré avec succès depuis la base de données.", idNumber);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la récupération de l'élève {idNumber} depuis la base de données.", idNumber);
            }
            await Task.Delay(0);
            return result;
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM Students ;";
            List<Student> result = new();
            try
            {
                result = (await connection.QueryAsync<Student>(query)).ToList();
                logger.LogInformation("Liste des élèves récupérée avec succès depuis la base de données.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la récupération de la liste des élèves depuis la base de données.");
            }
            return result;
        }

        public async Task<bool> AddStudentPictureAsync(int studentId, string urlPicture)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE Students SET PictureUrl=@urlPicture WHERE Id=@studentId";
            int result=0;
            try { 
                result = connection.Execute(query, new { urlPicture, studentId });
                logger.LogInformation("Photo de l'élève {studentId} ajoutée avec succès dans la base de données.", studentId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de l'ajout de la photo de l'élève {studentId} dans la base de données.", studentId);
            }
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE Students SET IdNumber=@idNumber,FirstName=@firstName,LastName=@lastName,Birthdate=@birthdate,Sex=@sex,Phone=@phone,Email=@email,Address=@address,
                              IdCard=@idCard,Nationality=@nationality,Religion=@religion,BirthPlace=@birthPlace,Health=@health WHERE Id=@id";
            int result=0;
            try
            {
                result = connection.Execute(query, new
                {
                    idNumber = student.IdNumber,
                    firstName = student.FirstName,
                    lastName = student.LastName,
                    birthdate = student.BirthDate,
                    sex = student.Sex,
                    phone = student.Phone,
                    email = student.Email,
                    address = student.Address,
                    idCard = student.IdCard,
                    nationality = student.Nationality,
                    religion = student.Religion,
                    birthPlace = student.BirthPlace,
                    health = student.Health,
                    id = student.Id
                });
                logger.LogInformation("L'élève {studentId} a été mis à jour avec succès dans la base de données.", student.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la mise à jour de l'élève {studentId} dans la base de données.", student.Id);
            }
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<List<Student>> GetStudentListAsync(string searchTerm, CancellationToken token)
        {
            if (token.IsCancellationRequested) return new List<Student>();
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM Students  WHERE FirstName LIKE @pattern OR LastName LIKE @pattern OR IdNumber LIKE @pattern ORDER BY FirstName ";
            IEnumerable<Student> result;
            try
            {
                result = await connection.QueryAsync<Student>(query, new
                {
                    pattern = $"%{searchTerm}%"
                });
                logger.LogInformation("Liste des élèves recherchés récupérée avec succès depuis la base de données.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Une erreur s'est produite lors de la récupération de la liste des élèves recherchés depuis la base de données.");
                result = new List<Student>();
            }
            // await Task.Delay(0, token);
            return result.ToList();
        }
    }
}
