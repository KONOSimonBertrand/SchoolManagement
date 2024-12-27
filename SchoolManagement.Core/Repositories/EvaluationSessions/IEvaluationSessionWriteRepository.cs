

using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IEvaluationSessionWriteRepository
    {
       Task<bool> AddAsync(EvaluationSession evaluationType);
        Task<bool> AddStateAsync(EvaluationSessionState evaluationSate);
        Task<bool> UpdateAsync(EvaluationSession evaluationType);
        Task<bool> UpdateStateAsync(EvaluationSessionState evaluationSate);
    }
}
