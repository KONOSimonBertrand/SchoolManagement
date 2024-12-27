using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IStudentNoteWriteRepository
    {
        public Task<bool> AddNoteAsync(StudentNote studentNote);
        public Task<bool> AddCommentAsync(EvaluationComment evaluationComment);
        public Task<bool> UpdateNoteAsync(StudentNote studentNote);
        public Task<bool> UpdateCommentAsync(EvaluationComment evaluationComment);
        public Task<bool> DeleteNoteAsync(int id);
        public Task<bool> DeleteCommentAsync(int id);
    }
}