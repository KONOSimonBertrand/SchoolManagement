
namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe représente des élèves par salle de classe
    /// </summary>
    public class StudentRoom
    {
        public int StudentId {  get; set; }
        public int RoomId {  get; set; }
        public int SchoolYearId {  get; set; }
        public  string Note {  get; set; }
        public virtual Student Student { get; set; }
        public virtual SchoolRoom Room { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not StudentRoom other) return false;
            return (this.StudentId == other.StudentId && this.SchoolYearId==other.SchoolYearId);
        }
        public override int GetHashCode()
        {
            return (this.StudentId*this.RoomId*this.SchoolYearId).GetHashCode(); ;
        }
    }
}
