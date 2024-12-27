

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperContactRepository : IContactRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperContactRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddContactAsync(Contact contact)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" INSERT INTO Contacts(Name,Sex,Phone,Email,Address,IdCard,Job,Relationship,StudentId)  
                              VALUES(@name,@sex,@phone,@email,@address,@idCard,@job,@relationship,@studentId);";
            var result = connection.Execute(query, new
            {
                name = contact.Name,
                sex=contact.Sex,
                phone=contact.Phone,
                email=contact.Email,
                address=contact.Address,
                idCard=contact.IdCard,
                job=contact.Job,
                relationship=contact.Relationship,
                studentId=contact.StudentId,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" DELETE FROM Contacts WHERE id=@contactId ;";
            var result = connection.Execute(query, new{ contactId });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<Contact> GetContactAsync(string contactName, string contactPhone)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Contacts WHERE name=@contactName AND Phone=@contactPhone ;";
            var result = connection.QueryFirstOrDefault<Contact>(query, new { contactName, contactPhone });
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Contact>> GetContactListAsync(int studentId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Contacts A
                            INNER JOIN Students C ON A.StudentId=C.Id
                            WHERE studentId=@studentId ;";
            var result = connection.Query<Contact,Student,Contact>(query
                ,
                (contact, student) =>
                {
                    contact.Student=student;
                    return contact;
                }
                , new { studentId}).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<Contact>> GetContactListAsync()
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @"SELECT * FROM Contacts  A
                             INNER JOIN Students C ON A.StudentId=C.Id ;";
            var result = connection.Query<Contact, Student, Contact>(query
                ,
                (contact, student) =>
                {
                    contact.Student = student;
                    return contact;
                }).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateContactAsync(Contact contact)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE Contacts SET Name=@name,Sex=@sex,Phone=@phone,Email=@email,Address=@address,IdCard=@idCard,
                                                  Job=@job,Relationship=@relationship  WHERE id=@id ;";
            var result = connection.Execute(query, new
            {
                name = contact.Name,
                sex = contact.Sex,
                phone = contact.Phone,
                email = contact.Email,
                address = contact.Address,
                idCard = contact.IdCard,
                job = contact.Job,
                relationship = contact.Relationship,
                id = contact.Id,
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
