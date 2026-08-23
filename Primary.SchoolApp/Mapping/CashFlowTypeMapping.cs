

using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using SchoolManagement.Helper;

namespace Primary.SchoolApp.Mapping
{
    static class CashFlowTypeMapping
    {
        public static CashFlowTypeDTO AsCashFlowTypeDTO(this CashFlowType cashFlowType)
        {
            return new CashFlowTypeDTO
            {
                Id = cashFlowType.Id,
                Name = cashFlowType.Name,
                FlowCategory = cashFlowType.FlowCategory,
                FlowDomain = cashFlowType.FlowDomain,
                FlowType = cashFlowType.FlowType,
                Description = cashFlowType.Description,
                Sequence = cashFlowType.Sequence,
                TransactionType = cashFlowType.TransactionType,
                CategoryName = Helper.GetFlowCategoryName(cashFlowType.FlowCategory),
                TypeName=Helper.GetFlowTypeName(cashFlowType.FlowType)
            };
        }

        public static CashFlowType AsCashFlowType(this CashFlowTypeDTO dto)
        {
            return new CashFlowType
            {
                Id = dto.Id,
                Name = dto.Name,
                FlowCategory = dto.FlowCategory,
                FlowDomain = dto.FlowDomain,
                FlowType= dto.FlowType,
                Description = dto.Description,
                TransactionType= dto.TransactionType,
                Sequence = dto.Sequence,
            };
        }
    }
}
