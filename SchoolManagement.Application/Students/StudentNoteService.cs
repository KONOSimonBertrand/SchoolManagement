

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class StudentNoteService : IStudentNoteService
    {
        private readonly IStudentNoteWriteRepository studentNoteWriteRepository;
        private readonly IStudentNoteReadRepository studentNoteReadRepository;
        public StudentNoteService(IStudentNoteRepository studentNoteRepository)
        {
            this.studentNoteWriteRepository = studentNoteRepository;
            this.studentNoteReadRepository = studentNoteRepository;
        }

        public async Task<bool> CreateEvaluationCommentAsync(EvaluationComment evaluationComment)
        {
            return await studentNoteWriteRepository.AddCommentAsync(evaluationComment);
        }

        public async Task<bool> CreateStudentNoteAsync(StudentNote studentNote)
        {
            return await studentNoteWriteRepository.AddNoteAsync(studentNote);
        }

        public async Task<bool> DeleteEvaluationCommentAsync(int id)
        {
            return await studentNoteWriteRepository.DeleteCommentAsync(id);
        }

        public async Task<bool> DeleteStudentNoteAsync(int id)
        {
            return await studentNoteWriteRepository.DeleteNoteAsync(id);
        }

        public async Task<EvaluationComment?> GetCommentAsync(int evaluationId, int studentId, int schoolYearId, int bookId)
        {
            return await studentNoteReadRepository.GetCommentAsync(evaluationId,studentId,schoolYearId,bookId);
        }

        public async Task<List<EvaluationComment>> GetCommentsByEvaluationAsync(int evaluationId, int schoolYearId)
        {
            return await studentNoteReadRepository.GetCommentsByEvaluationAsync(evaluationId,schoolYearId);
        }

        public async Task<List<EvaluationComment>> GetCommentsBySchoolYearAsync(int schoolYearId)
        {
            return await studentNoteReadRepository.GetCommentsBySchoolYearAsync(schoolYearId);
        }

        public async Task<List<EvaluationComment>> GetCommentsByStudentAsync(int studentId, int schoolYearId)
        {
            return await studentNoteReadRepository.GetCommentsByStudentAsync(studentId,schoolYearId);
        }

        public async Task<StudentNote?> GetNoteAsync(int subjectId, int studentId, int evaluationId, int schoolYearId, int bookId)
        {
            return await studentNoteReadRepository.GetNoteAsync(subjectId,studentId,evaluationId,schoolYearId,bookId);
        }

        public async Task<StudentNote?> GetNoteAsync(int studentNoteId)
        {
            return await studentNoteReadRepository.GetNoteAsync(studentNoteId);
        }

        public async Task<List<StudentNote>> GetNotesByEvaluationAsync(int evaluationId, int schoolYearId)
        {
            return await studentNoteReadRepository.GetNotesByEvaluationAsync(evaluationId,schoolYearId);
        }

        public  async Task<List<StudentNote>> GetNotesBySchoolYearAsync(int schoolYearId)
        {
            return await studentNoteReadRepository.GetNotesBySchoolYearAsync(schoolYearId);
        }

        public async Task<List<StudentNote>> GetNotesByClassAsync(int classId, int schoolYearId)
        {
            return await studentNoteReadRepository.GetNotesByClassAsync(classId, schoolYearId);
        }
        public async Task<List<StudentNote>> GetNotesByClassAsync(int classId,int evaluationId, int schoolYearId)
        {
            return await studentNoteReadRepository.GetNotesByClassAsync(classId,evaluationId, schoolYearId);
        }
        public async Task<List<StudentNote>> GetNotesByRoomAsync(int roomId, int schoolYearId)
        {
            return await studentNoteReadRepository.GetNotesByRoomAsync(roomId,schoolYearId);
        }
        public async Task<List<StudentNote>> GetNotesByRoomAsync(int roomId,int evaluationId, int schoolYearId)
        {
            return await studentNoteReadRepository.GetNotesByRoomAsync(roomId,evaluationId, schoolYearId);
        }
        public async Task<List<StudentNote>> GetNotesByStudentAsync(int studentId, int schoolYearId)
        {
            return await studentNoteReadRepository.GetNotesByStudentAsync(studentId, schoolYearId);
        }

        public async Task<List<StudentNote>> GetNotesBySubjectAsync(int subjectId, int schoolYearId)
        {
            return await studentNoteReadRepository.GetNotesBySubjectAsync(subjectId,schoolYearId);
        }

        public async Task<List<StudentNote>> GetNotesBySubjectAsync(int subjectId, int evaluationId, int roomId, int schoolYearId)
        {
            return await studentNoteReadRepository.GetNotesBySubjectAsync(subjectId, evaluationId,roomId,schoolYearId);
        }

        public async Task<bool> UpdateEvaluationCommentAsync(EvaluationComment evaluationComment)
        {
            return await studentNoteWriteRepository.UpdateCommentAsync(evaluationComment);
        }

        public async  Task<bool> UpdateStudentNoteAsync(StudentNote studentNote)
        {
            return await studentNoteWriteRepository.UpdateNoteAsync(studentNote);   
        }
    }
}
