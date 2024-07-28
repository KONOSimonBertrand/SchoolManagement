

using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public class EvaluationSessionService : IEvaluationSessionService
    {
        private readonly IEvaluationSessionWriteRepository evaluationTypeWriteRepository;
        private readonly IEvaluationSessionReadRepository evaluationTypeReadRepository;
        public EvaluationSessionService(IEvaluationSessionRepository evaluationTypeRepository)
        {
            this.evaluationTypeWriteRepository = evaluationTypeRepository;
            this.evaluationTypeReadRepository = evaluationTypeRepository;
        }

        public async Task<bool> CreateEvaluationSession(EvaluationSession evaluationType)
        {
            return await evaluationTypeWriteRepository.AddAsync(evaluationType);
        }

        public async Task<EvaluationSession?> GetEvaluationSession(string code)
        {
            return await evaluationTypeReadRepository.GetAsync(code); 
        }

        public async Task<IList<EvaluationSession>> GetEvaluationSessionList()
        {
            return await evaluationTypeReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateEvaluationSession(EvaluationSession evaluationType)
        {
            return await evaluationTypeWriteRepository.UpdateAsync(evaluationType);
        }
    }
}
