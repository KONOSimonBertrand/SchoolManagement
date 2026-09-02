

using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using SchoolManagement.Helper;

namespace Primary.SchoolApp.Mapping
{
    static class CashFlowTypeMapping
    {
        public static CashFlowTypeDTO ToCashFlowTypeDTO(this CashFlowType entity)
        {
            return new CashFlowTypeDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                FlowCategory = entity.FlowCategory,
                FlowDomain = entity.FlowDomain,
                FlowType = entity.FlowType,
                Description = entity.Description,
                Sequence = entity.Sequence,
                TransactionType = entity.TransactionType,
                CategoryName = Helper.GetFlowCategoryName(entity.FlowCategory),
                TypeName=Helper.GetFlowTypeName(entity.FlowType)
            };
        }

        public static CashFlowType ToCashFlowType(this CashFlowTypeDTO dto)
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
