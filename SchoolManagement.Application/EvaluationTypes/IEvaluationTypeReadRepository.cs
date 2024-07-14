

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.EvaluationTypes
{
    public interface IEvaluationTypeReadRepository
    {
        public Task<EvaluationType?> GetAsync(string code);
        public Task<IList<EvaluationType>> GetListAsync();
    }
}
