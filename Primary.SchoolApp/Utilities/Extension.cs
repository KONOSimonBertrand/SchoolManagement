
using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.Utilities
{
    static class Extension
    {
        public static EvaluationSessionChild ToEvaluationSessionChild(this EvaluationSession session)
        {
            EvaluationSessionChild dto = new();
            dto.Code = session.Code;
            dto.Id = session.Id;
            dto.FrenchName = session.FrenchName;
            dto.EnglishName = session.EnglishName;
            dto.Sequence=session.Sequence;
            return dto;
        }
    }
}
