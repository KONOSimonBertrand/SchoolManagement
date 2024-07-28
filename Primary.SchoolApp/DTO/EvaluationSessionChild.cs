

using SchoolManagement.Core.Model;

namespace Primary.SchoolApp.DTO
{
    internal class EvaluationSessionChild: EvaluationSession
    {
        public string ParentCode {

            get
            {
                if (this.Code == "EVAL01" || this.Code == "EVAL02" || this.Code == "EVAL03")
                {
                    return "TERM01";
                }
                if (this.Code == "EVAL04" || this.Code == "EVAL05" || this.Code == "EVAL06")
                {
                    return "TERM02";
                }
                if (this.Code == "EVAL07" || this.Code == "EVAL08" )
                {
                    return "TERM03";
                }
                return string.Empty;
            }

        }    
    }
}
