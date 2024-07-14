

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.EvaluationTypes
{
    public interface IEvaluationTypeService
    {
        public Task<bool>CreateEvaluationType(EvaluationType evaluationType);
        public Task<bool> UpdateEvaluationType(EvaluationType evaluationType);
        public Task<IList<EvaluationType>> GetEvaluationTypeList();
        public Task<EvaluationType?> GetEvaluationType(string code);


    }
}
