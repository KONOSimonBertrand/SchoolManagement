using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class DapperSchoolRepository : ISchoolRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperSchoolRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddSchoolAsync(School school)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"INSERT INTO Schools(Name,Motto,Phone,Address,City,EMail,WebSite,FaceBook,PostBox,HeadMasterTYpe,HeadMasterName,HeadMasterSex,EvaluationModel,SudentPictureDirectory,EmployeePictureDirectory ) 
                              VALUES(@name,@motto,@phone,@address,@city,@email, @webSite,@facebook,@postBox,@headMasterTYpe,@headMasterName,@headMasterSex,@evaluationModel,@studentPictureDirectory,@employeePictureDirectory) ;";
            var result = connection.Execute(query,
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
             });

            await Task.Delay(0);
            return result > 0;
        }

        public async Task<School?> GetLastSchooAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM Schools  ";
            var result = connection.Query<School>(query, new {}).LastOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<School?> GetSchoolAsync(string name)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM Schools Where Name=@name ";
            var result = connection.Query<School>(query, new { Name = name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<List<School>> GetSchoolsAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = "SELECT * FROM Schools ORDER BY Name";
            var result = connection.Query<School>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateCodeAsync(int schoolId, string code)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Schools SET Code=@code WHERE Id=@schoolId;";
            var result = connection.Execute(query,
             new
             {
                 code,
                 schoolId
             });

            await Task.Delay(0);
            return result > 0;
        }

        public  async Task<bool> UpdateSchoolAsync(School school)
        {
            using var connection = dbConnectionFactory.CreateConnection();
            string query = @"UPDATE Schools SET Name=@name,Motto=@motto,Phone=@phone,Address=@address,City=@city,EMail=@email,WebSite=@webSite,FaceBook=@faceBook,PostBox=@postBox,HeadMasterTYpe=@headMasterType,
                                               HeadMasterName=@headMasterName,HeadMasterSex=@headMasterSex,EvaluationModel=@evaluationModel,SudentPictureDirectory=@studentPictureDirectory,EmployeePictureDirectory=@employeePictureDirectory 
                                               WHERE Id=@id;";
            var result = connection.Execute(query,
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
                 school.Id,
             });

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
