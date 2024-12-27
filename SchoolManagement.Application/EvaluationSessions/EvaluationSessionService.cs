

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class EvaluationSessionService : IEvaluationSessionService
    {
        private readonly IEvaluationSessionWriteRepository evaluationSessionWriteRepository;
        private readonly IEvaluationSessionReadRepository evaluationSessionReadRepository;
        public EvaluationSessionService(IEvaluationSessionRepository evaluationSessionRepository)
        {
            this.evaluationSessionWriteRepository = evaluationSessionRepository;
            this.evaluationSessionReadRepository = evaluationSessionRepository;
        }

        public async Task<bool> CreateEvaluationSessionAsync(EvaluationSession evaluationType)
        {
            return await evaluationSessionWriteRepository.AddAsync(evaluationType);
        }

        public async Task<bool> CreateEvaluationSessionStateAsync(EvaluationSessionState evaluationSate)
        {
            return await this.evaluationSessionWriteRepository.AddStateAsync(evaluationSate);
        }
        public async Task<EvaluationSession?> GetEvaluationSessionAsync(string code)
        {
            return await evaluationSessionReadRepository.GetAsync(code); 
        }

        public async Task<IList<EvaluationSession>> GetEvaluationSessionListAsync()
        {
            return await evaluationSessionReadRepository.GetListAsync();
        }

        public async Task<EvaluationSessionState> GetEvaluationSessionStateAsync(int evaluationId, int schoolYearId)
        {
            return await evaluationSessionReadRepository.GetStateAsync(evaluationId,schoolYearId);
        }

        public async Task<IList<EvaluationSessionState>> GetEvaluationSessionStateListByEvaluationAsync(int evaluationId)
        {
            return await evaluationSessionReadRepository.GetStateListByEvaluationAsync(evaluationId);
        }

        public async Task<IList<EvaluationSessionState>> GetEvaluationSessionStateListBySchoolYearAsync(int schoolYearId)
        {
            return await evaluationSessionReadRepository.GetStateListBySchoolYearAsync(schoolYearId);
        }

        public async Task<bool> UpdateEvaluationSessionAsync(EvaluationSession evaluationType)
        {
            return await evaluationSessionWriteRepository.UpdateAsync(evaluationType);
        }

        public async Task<bool> UpdateEvaluationSessionStateAsync(EvaluationSessionState evaluationSate)
        {
            return await evaluationSessionWriteRepository.UpdateStateAsync(evaluationSate);
        }
    }
}
