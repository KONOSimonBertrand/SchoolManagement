using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;

namespace Primary.SchoolApp.Mapping
{
    public static class CashBoxOutMapping
    {
        /// <summary>
        /// Converti CashBoxOut
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>CashBoxOutDTO</returns>
        public static CashBoxOutDTO ToCashBoxOutDTO(this CashBoxOut entity)
        {
            return new CashBoxOutDTO()
            {
                Id = entity.Id,
                Amount = entity.Amount,
                CashFlowType = entity.CashFlowType,
                CashFlowTypeId = entity.CashFlowTypeId,
                Date = entity.Date,
                DoneBy = entity.DoneBy,
                IdNumber = entity.IdNumber,
                IsValidated = entity.IsValidated,
                Note = entity.Note,
                SchoolYear = entity.SchoolYear,
                SchoolYearId = entity.SchoolYearId,
            };
        }
        /// <returns>CashBoxOut</returns>
        public static CashBoxOut ToCashBoxOut(this CashBoxOutDTO dto)
        {
            return new CashBoxOut()
            {
                Id = dto.Id,
                Amount = dto.Amount,
                CashFlowType = dto.CashFlowType,
                CashFlowTypeId = dto.CashFlowTypeId,
                Date = dto.Date,
                DoneBy = dto.DoneBy,
                IdNumber = dto.IdNumber,
                SchoolYearId= dto.SchoolYearId,
                SchoolYear =dto.SchoolYear,
                IsValidated=dto.IsValidated,
                Note = dto.Note, 
            };
        }
    }
}
