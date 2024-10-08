﻿

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IStudentService
    {
        public Task<string> GenerateStudentIdNumberAsync();
        public Task<bool> CreateStudentAsync(Student student);
        public Task<bool> UpdateStudentAsync(Student student);
        public Task<Student> GetStudentAsync(string idNumber);
        public Task<Student> GetLastStudentAsync();
        public Task<List<Student>> GetStudentListsync();
        public Task<bool> SaveStudentPictureAsync(int studentId, string urlPicture);

    }
}
