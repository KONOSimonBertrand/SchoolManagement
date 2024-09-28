

namespace SchoolManagement.Core.Model
{
    public class Discipline
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SubjectId {  get; set; }
        public string Reason { get; set; }
        public double Duration {  get; set; }
        public int EvaluationId {  get; set; }
        public int EnrollingId {  get; set; }
        public virtual DisciplineSubject Subject { get; set; }
        public virtual EvaluationSession Evaluation {  get; set; }
        public virtual StudentEnrolling Enrolling { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Discipline other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return $"{Date} - {Evaluation.DefaultName} - {Reason}";
        }

    }
}
