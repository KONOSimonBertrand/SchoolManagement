

using SchoolManagement.Core.Model;
using System.Reflection.Metadata.Ecma335;

namespace SchoolManagement.Application.EvaluationTypes
{
    public class EvaluationTypeService : IEvaluationTypeService
    {
        private readonly IEvaluationTypeWriteRepository evaluationTypeWriteRepository;
        private readonly IEvaluationTypeReadRepository evaluationTypeReadRepository;
        public EvaluationTypeService(IEvaluationTypeRepository evaluationTypeRepository)
        {
            this.evaluationTypeWriteRepository = evaluationTypeRepository;
            this.evaluationTypeReadRepository = evaluationTypeRepository;
        }

        public async Task<bool> CreateEvaluationType(EvaluationType evaluationType)
        {
            return await evaluationTypeWriteRepository.AddAsync(evaluationType);
        }

        public async Task<EvaluationType?> GetEvaluationType(string code)
        {
            return await evaluationTypeReadRepository.GetAsync(code); 
        }

        public async Task<IList<EvaluationType>> GetEvaluationTypeList()
        {
            return await evaluationTypeReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateEvaluationType(EvaluationType evaluationType)
        {
            return await evaluationTypeWriteRepository.UpdateAsync(evaluationType);
        }
    }
}
