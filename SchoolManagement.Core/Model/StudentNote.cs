

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente une note scolaire sur une matière
    /// Exemple 15
    /// </summary>
    public class StudentNote
    {
        public int Id { get; set; }
        public double Note { get; set; }
        public double NoteCoef { get; set; }
        public double NoteTotal
        {
            get

            { return NoteCoef * Note; }
        }
        public double NotedOn { get; set; }
        public string? Position { get; set; }
        public string? Comment { get; set; }
        public int BookId {  get; set; } // //0=section normal; si classe bilingue 0=section francophone 1= section anglophone
        public DateTime Date { get; set; }
        public int SubjectId {  get; set; }
        public int StudentId {  get; set; }
        public int EvaluationId {  get; set; }
        public int SchoolYearId {  get; set; }
        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
        public EvaluationSession? Evaluation { get; set; }
        public SchoolYear? SchoolYear { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not StudentNote other) return false;
            return this.Id == other.Id;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
