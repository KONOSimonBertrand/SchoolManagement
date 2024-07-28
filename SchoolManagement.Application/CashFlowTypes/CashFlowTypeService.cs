
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public class CashFlowTypeService : ICashFlowTypeService
    {
        private readonly ICashFlowTypeReadRepository cashFlowTypeReadRepository;
        private readonly ICashFlowTypeWriteRepository cashFlowTypeWriteRepository;
        public  CashFlowTypeService(ICashFlowTypeRepository cashFlowTypeRepository)
        {
            cashFlowTypeReadRepository = cashFlowTypeRepository;
            cashFlowTypeWriteRepository = cashFlowTypeRepository;
        }
        public async Task<bool> CreateCashFlowType(CashFlowType cashFlowType)
        {
           return await cashFlowTypeWriteRepository.AddAsync(cashFlowType);
        }

        public async Task<CashFlowType> GetCashFlowType(string name)
        {
           return await cashFlowTypeReadRepository.GetAsyn(name);
        }

        public async Task<IList<CashFlowType>> GetCashFlowTypeList()
        {
            return await cashFlowTypeReadRepository.GetAsynList();
        }

        public async Task<bool> UpdateCashFlowType(CashFlowType cashFlowType)
        {
            return await cashFlowTypeWriteRepository.UpdateAsync(cashFlowType);
        }
    }
}
