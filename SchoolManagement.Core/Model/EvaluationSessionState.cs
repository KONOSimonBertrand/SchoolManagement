

namespace SchoolManagement.Core.Model
{
    public class EvaluationSessionState
    {
        public int EvaluationId { get; set; }
        public int SchoolYearId { get; set; }
        public bool IsClosed { get; set; }
        public string State
        {
            get
            {
                if (IsClosed)
                {
                    return Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "Close" : "Clôturée";
                }
                else
                {
                   
                    return Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "Open" : "Activée";
                }
            }
        }
        public EvaluationSession? EvaluationSession { get; set; }
        public SchoolYear? SchoolYear { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not EvaluationSessionState other) return false;
            return (other.EvaluationId == this.EvaluationId && other.SchoolYearId == this.SchoolYearId);
        }

        public override int GetHashCode()
        {
            return this.EvaluationId.GetHashCode() * this.SchoolYearId.GetHashCode();
        }
    }
}
