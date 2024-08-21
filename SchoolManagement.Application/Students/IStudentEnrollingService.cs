﻿

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IStudentEnrollingService
    {
        public Task<bool> CreateStudentEnrollingAsync(StudentEnrolling enrolling);
        public Task<bool> UpdateStudentEnrollingAsync(StudentEnrolling enrolling);
        public Task<StudentEnrolling?> GetStudentEnrollingAsync(int studentId, int schoolyearId);
        public Task<List<StudentEnrolling>> GetStudentEnrollingListAsync(int schoolyearId);
        public Task<bool> CreateStudentRoomAsync(StudentRoom room);
        public Task<bool> DeleteStudentRoomAsync(int studentId,int roomId,int schoolYearId);
        public Task<StudentRoom?> GetStudentRoomAsync(int studentId, int schoolYearId);
        public Task<List<StudentRoom>> GetStudentRoomListAsync(int roomId,int schoolYearId);
        public Task<List<StudentRoom>> GetStudentRoomListAsync(int schoolYearId);
    }
}