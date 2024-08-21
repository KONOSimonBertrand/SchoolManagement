

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories.Students
{
    public class DapperStudentRepository : IStudentRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperStudentRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> AddStudentAsync(Student student)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" INSERT INTO Students(IdNumber,FirstName,LastName,Birthday,BirthPlace,Sex,Phone,Email,Address,IdCard,Nationality,Religion)  
                              VALUES(@idNumber,@firstName,@lastName,@birthday,@birthPlace,@sex,@phone,@email,@address,@idCard,@nationality,@religion);";
            var result = connection.Execute(query, new
            {
                idNumber = student.IdNumber,
                firstName = student.FirstName,
                lastName = student.LastName,
                birthday = student.BirthDate,
                sex = student.Sex,
                phone = student.Phone,
                email = student.Email,
                address = student.Address,
                idCard = student.IdCard,
                nationality = student.Nationality,
                religion = student.Religion,
                birthPlace = student.BirthPlace,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<Student?> GetLastStudentAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM Students ORDER BY Id DESC LIMIT 1;";
            var result = connection.QuerySingleOrDefault<Student>(query);
            await Task.Delay(0);
            return result;
        }

        public async Task<Student?> GetStudentAsync(string idNumber)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM Students WHERE IdNumber=@idNumber;";
            var result = connection.QuerySingleOrDefault<Student>(query, new {idNumber});
            await Task.Delay(0);
            return result;
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM Students ;";
            var result = connection.Query<Student>(query).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE Students SET IdNumber=@idNumber,FirstName=@firstName,LastName=@lastName,Birthday=@birthday,Sex=@sex,Phone=@phone,Email=@email,Address=@address,
                              IdCard=@idCard,Nationality=@nationality,Religion=@religion,BirthPlace=@birthPlace WHERE Id=@id";
            var result = connection.Execute(query, new
            {
                idNumber = student.IdNumber,
                firstName = student.FirstName,
                lastName = student.LastName,
                birthday = student.BirthDate,
                sex = student.Sex,
                phone = student.Phone,
                email = student.Email,
                address = student.Address,
                idCard = student.IdCard,
                nationality = student.Nationality,
                religion = student.Religion,
                birthPlace = student.BirthPlace,
                id = student.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
