

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperEmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperEmployeeRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" INSERT INTO Employees(IdNumber,FirstName,LastName,Birthday,Sex,Phone,Email,Address,IdCard,Nationality,Religion,HiringDate,Salary,GroupId,JobId)  
                              VALUES(@idNumber,@firstName,@lastName,@birthday,@sex,@phone,@email,@address,@idCard,@nationality,@religion,@hiringDate,@salary,@groupId,@jobId);";
            var result = connection.Execute(query, new
            {
                idNumber = employee.IdNumber,
                firstName = employee.FirstName,
                lastName = employee.LastName,
                birthday = employee.Birthday,
                sex = employee.Sex,
                phone = employee.Phone,
                email = employee.Email,
                address = employee.Address,
                idCard = employee.IdCard,
                nationality = employee.Nationality,
                religion = employee.Religion,
                hiringDate = employee.HiringDate,
                salary = employee.Salary,
                groupId = employee.GroupId,
                jobId = employee.JobId
            });
            await Task.Delay(0);
            return result>0;
        }

        public async Task<Employee?> GetAsync(string idNumber)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" SELECT * FROM Employees A 
                              INNER JOIN Jobs B ON A.JobId=B.Id
                              INNER JOIN EmployeeGroups C ON A.GroupId=C.Id
                              WHERE A.IdNumber=@idNumber;";
            var result = connection.Query<Employee,Job,EmployeeGroup,Employee>(query,
                (employee, job, group) =>
                {
                    employee.Job = job;
                    employee.Group = group;
                    return employee;
                }
                ,new { idNumber }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Employee>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" SELECT * FROM Employees A 
                              INNER JOIN Jobs B ON A.JobId=B.Id
                              INNER JOIN EmployeeGroups C ON A.GroupId=C.Id ;";
            var result = connection.Query<Employee, Job, EmployeeGroup, Employee>(query,
                (employee, job, group) =>
                {
                    employee.Job = job;
                    employee.Group = group;
                    return employee;
                }
                ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @" UPDATE Employees SET IdNumber=@idNumber,FirstName=@firstName,LastName=@lastName,Birthday=@birthday,Sex=@sex,Phone=@phone,Email=@email,Address=@address,
                              IdCard=@idCard,Nationality=@nationality,Religion=@religion,HiringDate=@hiringDate,Salary=@salary,GroupId=@groupId,JobId=@jobId WHERE Id=@id";
            var result = connection.Execute(query, new
            {
                idNumber = employee.IdNumber,
                firstName = employee.FirstName,
                lastName = employee.LastName,
                birthday = employee.Birthday,
                sex = employee.Sex,
                phone = employee.Phone,
                email = employee.Email,
                address = employee.Address,
                idCard = employee.IdCard,
                nationality = employee.Nationality,
                religion = employee.Religion,
                hiringDate = employee.HiringDate,
                salary = employee.Salary,
                groupId = employee.GroupId,
                jobId = employee.JobId,
                id= employee.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
