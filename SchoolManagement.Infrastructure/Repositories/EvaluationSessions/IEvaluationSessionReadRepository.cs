

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IEvaluationSessionReadRepository
    {
        public Task<EvaluationSession?> GetAsync(string code);
        public Task<IList<EvaluationSession>> GetListAsync();
    }
}
