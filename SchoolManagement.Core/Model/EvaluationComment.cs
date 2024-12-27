

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente un commentaire suite à une évaluation
    /// Exemple Elève très travailleur, mérite une attention
    /// </summary>
    public class EvaluationComment
    {
        public int Id {  get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
        public int BookId { get; set; } // si c'est une classe bilingue la valeur=false
        public int StudentId {  get; set; }
        public int SchoolYearId {  get; set; }
        public int EvaluationId {  get; set; }
        public Student? Student { get; set; }
        public SchoolYear? SchoolYear { get; set; }
        public EvaluationSession? Evaluation {  get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not EvaluationComment other) return false;
            return this.Id == other.Id ;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
    }
}
