﻿using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IStudentWriteRepository
    {
        Task<bool> AddStudentAsync(Student student);
        Task<bool> AddStudentPictureAsync(int studentId, string urlPicture);      
        Task<bool> UpdateStudentAsync(Student student);
    }
}