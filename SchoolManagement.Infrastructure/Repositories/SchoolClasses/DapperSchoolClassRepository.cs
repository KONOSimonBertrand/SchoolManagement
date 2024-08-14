

using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperSchoolClassRepository : ISchoolClassRepository
    {
        private readonly IDbConnectionFactoty dbConnectionFactoty;
        public DapperSchoolClassRepository(IDbConnectionFactoty dbConnectionFactoty)
        {
            this.dbConnectionFactoty = dbConnectionFactoty;
        }

        public async Task<bool> AddAsync(SchoolClass schoolClass)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO SchoolClasses(Name,GroupId,BookTypeId,Sequence) VALUES(@name,@groupId,@bookTypeId,@sequence);";
            var result = connection.Execute(query, new
            {
                schoolClass.Name,
                schoolClass.GroupId,
                schoolClass.BookTypeId,
                schoolClass.Sequence
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> AddSubjectAsync(ClassSubject classSubject)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"INSERT INTO ClassSubjects(ClassId,SubjectId,BookId,GroupId,NotedOn,Coefficient,Sequence) 
                                                  VALUES(@classId,@subjectId,@bookId,@groupId,@notedOn,@coefficient,@sequence);";
            var result = connection.Execute(query, new
            {
                classSubject.ClassId,
                classSubject.SubjectId,
                classSubject.BookId,
                classSubject.GroupId,
                classSubject.NotedOn,
                classSubject.Coefficient,
                classSubject.Sequence
            });
            await Task.Delay(0);
            return result>0;
        }

        public async Task<bool> DeleteSubjectAsync(int classId, int subjectId,int bookId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"DELETE FROM ClassSubjects WHERE ClassId=@classId AND SubjectId=@subjectId AND BookId=@bookId ;";
            var result = connection.Execute(query, new
            {
                classId,
                subjectId,
                bookId
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SchoolClass?> GetAsync(string name)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM SchoolClasses AS A 
                             INNER JOIN SchoolGroups AS B ON A.GroupId=B.Id
                             WHERE A.Name=@name; ";
            var result = connection.Query<SchoolClass, SchoolGroup, SchoolClass>(query,
                (schoolClass, schoolGroup) =>
                {
                    schoolClass.Group = schoolGroup;
                    return schoolClass;
                }
                , new { name }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolClass>> GetListAsync()
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM SchoolClasses AS A  
                           INNER JOIN SchoolGroups AS B ON A.GroupId=B.Id;";
            var result = connection.Query<SchoolClass, SchoolGroup, SchoolClass>(query,
                (schoolClass, schoolGroup) =>
                {
                    schoolClass.Group = schoolGroup;
                    return schoolClass;
                }
                ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<ClassSubject> GetSubjectAsync(int classId, int subjectId, int bookId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM ClassSubjects AS A  
                           INNER JOIN Subjects AS B ON A.subjectId=B.Id  
                           INNER JOIN SubjectGroups AS C ON A.GroupId=C.Id  
                           INNER JOIN SchoolClasses AS D ON A.ClassId=D.Id
                           WHERE A.ClassId=@classId AND A.subjectId=@subjectId AND BookId=@bookId;";
            var result = connection.Query<ClassSubject, Subject, SubjectGroup,SchoolClass, ClassSubject>(query,
                (classSubject, subject, subjectGroup,schoolClass) =>
                {
                    classSubject.Subject = subject;
                    classSubject.Group = subjectGroup;
                    classSubject.Class = schoolClass;
                    return classSubject;
                }, new { classId,subjectId,bookId }
                ).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<ClassSubject>> GetSubjectListAsync(int classId)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"SELECT * FROM ClassSubjects AS A  
                           INNER JOIN Subjects AS B ON A.subjectId=B.Id  
                           INNER JOIN SubjectGroups AS C ON A.GroupId=C.Id
                           INNER JOIN SchoolClasses AS D ON A.ClassId=D.Id
                           WHERE A.ClassId=@classId;";
            var result = connection.Query<ClassSubject, Subject, SubjectGroup, SchoolClass, ClassSubject>(query,
                (classSubject,subject, subjectGroup, schoolClass) =>
                {
                    classSubject.Subject=subject;
                    classSubject.Group=subjectGroup;
                    classSubject.Class = schoolClass;
                    return classSubject;
                }, new {classId}
                ).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SchoolClass schoolClass)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"UPDATE SchoolClasses SET Name=@name,GroupId=@groupId,BookTypeId=@bookTypeId,Sequence=@sequence WHERE Id=@id ;";
            var result = connection.Execute(query, new
            {
                schoolClass.Name,
                schoolClass.GroupId,
                schoolClass.BookTypeId,
                schoolClass.Sequence,
                schoolClass.Id
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<bool> UpdateSubjectAsync(ClassSubject classSubject)
        {
            var connection = dbConnectionFactoty.CreateConnection();
            string query = @"UPDATE ClassSubjects SET GroupId=@groupId,NotedOn=@notedOn,Coefficient=@coefficient,Sequence=@sequence  
                                                  WHERE ClassId=@classId AND SubjectId=@subjectId";
            var result = connection.Execute(query, new
            {              
                classSubject.GroupId,
                classSubject.NotedOn,
                classSubject.Coefficient,
                classSubject.Sequence,
                classSubject.ClassId,
                classSubject.SubjectId
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
