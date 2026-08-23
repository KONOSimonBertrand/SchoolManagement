using Dapper;
using Microsoft.Extensions.Logging;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class DapperSchoolRepository : ISchoolRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        private readonly ILogger<DapperSchoolRepository> logger;
        public DapperSchoolRepository(IDbConnectionFactory dbConnectionFactory, ILogger<DapperSchoolRepository> logger)
        {
            this.dbConnectionFactory = dbConnectionFactory;
            this.logger = logger;
        }

        public async Task<bool> AddSchoolAsync(School school)
        {
            int result = 0;
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO Schools(Name,Motto,Phone,Address,City,EMail,WebSite,FaceBook,PostBox,HeadMasterTYpe,HeadMasterName,HeadMasterSex,EvaluationModel,StudentPictureDirectory,EmployeePictureDirectory,ReceiptModel) 
                                    VALUES(@name,@motto,@phone,@address,@city,@email, @webSite,@facebook,@postBox,@headMasterTYpe,@headMasterName,@headMasterSex,@evaluationModel,@studentPictureDirectory,@employeePictureDirectory,@receiptModel) ;";
            try
            {
                result = connection.Execute(query,
                             new
                             {
                                 school.Name,
                                 school.Motto,
                                 school.Phone,
                                 school.Address,
                                 school.City,
                                 school.Email,
                                 school.WebSite,
                                 school.FaceBook,
                                 school.PostBox,
                                 school.HeadMasterType,
                                 school.HeadMasterName,
                                 school.HeadMasterSex,
                                 school.EvaluationModel,
                                 school.StudentPictureDirectory,
                                 school.EmployeePictureDirectory,
                                 school.ReceiptModel
                             }
                );
            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenue lors de l'ajout de l'école : {Message}", ex.Message);
            }
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<School?> GetLastSchooAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            School? result = null;
            string query = "SELECT * FROM Schools  ";
            try
            {
                result = await connection.QueryFirstOrDefaultAsync<School>(query);
            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenue lors de la récupération de la dernière école : {Message}", ex.Message);
            }
            return result;
        }

        public async Task<School?> GetSchoolAsync(string name)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM Schools Where Name=@name ";
            School? result = null;
            try
            {
                result = await connection.QueryFirstOrDefaultAsync<School>(query, new { Name = name });
            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenue lors de la récupération de l'école {name} : {Message}", name, ex.Message);
            }
            return result;
        }

        public async Task<List<School>> GetSchoolsAsync()
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM Schools ORDER BY Name";
            List<School> result = new();
            try
            {
                result = (await connection.QueryAsync<School>(query)).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenue lors de la récupération des écoles : {Message}", ex.Message);
            }
            return result;
        }

        public async Task<bool> UpdateCodeAsync(int schoolId, string code)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Schools SET Code=@code WHERE Id=@schoolId;";
            int result = 0;
            try
            {
                result = connection.Execute(
                    query,
                    new
                    {
                        code,
                        schoolId
                    }
                );
            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenue lors de la mise à jour du code de l'école {schoolId} : {Message}", schoolId, ex.Message);
            }
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateSchoolAsync(School school)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Schools SET Name=@name,Motto=@motto,Phone=@phone,Address=@address,City=@city,EMail=@email,WebSite=@webSite,FaceBook=@faceBook,PostBox=@postBox,HeadMasterTYpe=@headMasterType,HeadMasterName=@headMasterName,
                                                HeadMasterSex=@headMasterSex,EvaluationModel=@evaluationModel,StudentPictureDirectory=@studentPictureDirectory,EmployeePictureDirectory=@employeePictureDirectory,ReceiptModel=@receiptModel 
                                                WHERE Id=@id;";
            int result = 0;
            try
            {
                result = connection.Execute(
                        query,
                        new
                        {
                            school.Name,
                            school.Motto,
                            school.Phone,
                            school.Address,
                            school.City,
                            school.Email,
                            school.WebSite,
                            school.FaceBook,
                            school.PostBox,
                            school.HeadMasterType,
                            school.HeadMasterName,
                            school.HeadMasterSex,
                            school.EvaluationModel,
                            school.StudentPictureDirectory,
                            school.EmployeePictureDirectory,
                            school.ReceiptModel,
                            school.Id,
                        }
                    );

            }
            catch (Exception ex)
            {
                logger.LogError("Une erreur est survenue lors de la mise à jour de l'école {schoolId} : {Message}", school.Id, ex.Message);
            }
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateSerialKeyAsync(int schoolId, string serialKey)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Schools SET SerialKey=@serialKey WHERE Id=@schoolId;";
            var result = connection.Execute(query,
             new
             {
                 serialKey,
                 schoolId
             });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
