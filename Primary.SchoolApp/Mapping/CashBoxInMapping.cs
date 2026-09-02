using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;

namespace Primary.SchoolApp.Mapping
{
    public static class CashBoxInMapping
    {
        /// <summary>
        /// Convertid CashBoxIn
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>CashBoxInDTO</returns>
        public static CashBoxInDTO ToCashBoxInDTO(this CashBoxIn entity)
        {
            if (entity == null) return null;
            return new CashBoxInDTO
            {
                Id = entity.Id,
                Date = entity.Date,
                IdNumber = entity.IdNumber,
                Amount = entity.Amount,
                CashFlowTypeId = entity.CashFlowTypeId,
                SchoolYearId = entity.SchoolYearId,
                DoneBy = entity.DoneBy,
                Note = entity.Note,
                IsValidated = entity.IsValidated,
                CashFlowType = entity.CashFlowType,
                SchoolYear = entity.SchoolYear,

            };
        }

        /// Cconverti CashBoxInDTO
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>CashBoxIn</returns>
        public static CashBoxIn ToCashBoxIn(this CashBoxInDTO dto)
        {
            if (dto == null) return null;
            return new CashBoxIn
            {
                Id = dto.Id,
                Date = dto.Date,
                IdNumber = dto.IdNumber,
                Amount = dto.Amount,
                CashFlowTypeId = dto.CashFlowTypeId,
                SchoolYearId = dto.SchoolYearId,
                DoneBy = dto.DoneBy,
                Note = dto.Note,
                IsValidated = dto.IsValidated,
                CashFlowType = dto.CashFlowType,
                SchoolYear = dto.SchoolYear,
            };
        }
    }
}
