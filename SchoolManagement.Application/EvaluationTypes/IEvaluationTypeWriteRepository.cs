

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.EvaluationTypes
{
    public interface IEvaluationTypeWriteRepository
    {
        public Task<bool> AddAsync(EvaluationType evaluationType);
        public Task<bool> UpdateAsync(EvaluationType evaluationType);
       

    }
}
