

using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IEvaluationSessionWriteRepository
    {
        public Task<bool> AddAsync(EvaluationSession evaluationType);
        public Task<bool> UpdateAsync(EvaluationSession evaluationType);
       

    }
}
