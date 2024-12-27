using Dapper;
using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DapperMedicalRepository: IMedicalRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public DapperMedicalRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddMedicalRecordAsync(MedicalRecord medicalRecord)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" INSERT INTO MedicalRecords(Date,HealthSubject,Description,StudentId)  
                              VALUES(@date,@subject,@description,@studentId);";
            var result = connection.Execute(query, new
            {
                date=medicalRecord.Date,
                subject=medicalRecord.HealthSubject,
                description=medicalRecord.Description,
                studentId = medicalRecord.StudentId,
            });
            await Task.Delay(0);
            return result > 0;
        }

        public async  Task<bool> DeleteMedicalRecordAsync(int medicalRecordId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" DELETE FROM MedicalRecords WHERE id=@medicalRecordId ;";
            var result = connection.Execute(query, new { medicalRecordId });
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<MedicalRecord?> GetMedicalRecordAsync(int studentId, string description)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM MedicalRecords A      
                              INNER JOIN Students B ON A.StudentId=B.Id  
                              WHERE A.StudentId=@studentId AND A.Description=@description   ;";
            var result = connection.Query<MedicalRecord, Student, MedicalRecord>(query
               ,
               (medicalRecord, student) =>
               {
                   medicalRecord.Student = student;
                   return medicalRecord;
               }
               , new { studentId,description }).FirstOrDefault();
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<MedicalRecord>> GetMedicalRecordListAsync(int studentId)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" SELECT * FROM MedicalRecords A      
                              INNER JOIN Students B ON A.StudentId=B.Id  
                              WHERE A.StudentId=@studentId ;";
            var result = connection.Query<MedicalRecord, Student, MedicalRecord>(query
               ,
               (medicalRecord, student) =>
               {
                   medicalRecord.Student = student;
                   return medicalRecord;
               }
               , new { studentId}).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateMedicalRecordAsync(MedicalRecord medicalRecord)
        {
            var connection = dbConnectionFactory.CreateConnection();
            string query = @" UPDATE MedicalRecords SET Date=@Date,HealthSubject=@subject,Description=@description WHERE Id=@id";
            var result = connection.Execute(query, new
            {
                date = medicalRecord.Date,
                subject = medicalRecord.HealthSubject,
                description = medicalRecord.Description,
                id=medicalRecord.Id
            });
            await Task.Delay(0);
            return result > 0;
        }
    }
}
