

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IEvaluationSessionService
    {
        public Task<bool>CreateEvaluationSessionAsync(EvaluationSession evaluationType);
        public Task<bool> UpdateEvaluationSessionAsync(EvaluationSession evaluationType);
        public Task<IList<EvaluationSession>> GetEvaluationSessionListAsync();
        public Task<EvaluationSession?> GetEvaluationSessionAsync(string code);

        public Task<bool> CreateEvaluationSessionStateAsync(EvaluationSessionState evaluationSate);
        public Task<bool> UpdateEvaluationSessionStateAsync(EvaluationSessionState evaluationSate);
        public Task<EvaluationSessionState> GetEvaluationSessionStateAsync(int evaluationId, int schoolYearId);
        public Task<IList<EvaluationSessionState>> GetEvaluationSessionStateListByEvaluationAsync(int evaluationId);
        public Task<IList<EvaluationSessionState>> GetEvaluationSessionStateListBySchoolYearAsync(int schoolYearId);

    }
}
