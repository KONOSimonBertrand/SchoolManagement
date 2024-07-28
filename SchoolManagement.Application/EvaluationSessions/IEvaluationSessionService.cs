

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IEvaluationSessionService
    {
        public Task<bool>CreateEvaluationSession(EvaluationSession evaluationType);
        public Task<bool> UpdateEvaluationSession(EvaluationSession evaluationType);
        public Task<IList<EvaluationSession>> GetEvaluationSessionList();
        public Task<EvaluationSession?> GetEvaluationSession(string code);


    }
}
