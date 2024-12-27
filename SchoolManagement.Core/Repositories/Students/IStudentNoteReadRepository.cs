using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IStudentNoteReadRepository
    {
        public Task<StudentNote?> GetNoteAsync(int subjectId,int studentId,int evaluationId,int schoolYearId,int bookId);
        public Task<StudentNote?> GetNoteAsync(int studentNoteId);
        public Task<List<StudentNote>> GetNotesBySchoolYearAsync(int schoolYearId);
        public Task<List<StudentNote>> GetNotesByStudentAsync(int studentId, int schoolYearId);
        public Task<List<StudentNote>> GetNotesByClassAsync(int classId, int schoolYearId);
        public Task<List<StudentNote>> GetNotesByRoomAsync(int roomId, int schoolYearId);
        public Task<List<StudentNote>> GetNotesByEvaluationAsync(int evaluationId, int schoolYearId);
        public Task<List<StudentNote>> GetNotesBySubjectAsync(int subjectId, int schoolYearId);
        public Task<List<StudentNote>> GetNotesBySubjectAsync(int subjectId, int evaluationId, int roomId, int schoolYearId);
        public Task<EvaluationComment?> GetCommentAsync( int evaluationId, int studentId, int schoolYearId, int bookId);
        public Task<List<EvaluationComment>> GetCommentsBySchoolYearAsync(int schoolYearId);
        public Task<List<EvaluationComment>> GetCommentsByStudentAsync(int studentId, int schoolYearId);
        public Task<List<EvaluationComment>> GetCommentsByEvaluationAsync(int evaluationId, int schoolYearId);
        Task<List<StudentNote>> GetNotesByClassAsync(int classId, int evaluationId, int schoolYearId);
        Task<List<StudentNote>> GetNotesByRoomAsync(int roomId, int evaluationId, int schoolYearId);
    }
}