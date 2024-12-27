

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IEvaluationSessionReadRepository
    {
        public Task<EvaluationSession?> GetAsync(string code);
        public Task<IList<EvaluationSession>> GetListAsync();
        Task<EvaluationSessionState?> GetStateAsync(int evaluationId, int schoolYearId);
        Task<IList<EvaluationSessionState>> GetStateListByEvaluationAsync(int evaluationId);
        Task<IList<EvaluationSessionState>> GetStateListBySchoolYearAsync(int schoolYearId);
    }
}
