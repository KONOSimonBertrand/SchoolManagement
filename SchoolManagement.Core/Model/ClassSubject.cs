



namespace SchoolManagement.Core.Model
{
    public class ClassSubject
    {
        public int SubjectId {  get; set; }
        public int ClassId {  get; set; }
        public int GroupId {  get; set; }
        public double Coefficient {  get; set; }
        public double NotedOn {  get; set; }
        public int Sequence {  get; set; }
        public virtual Subject Subject { get; set; }
        public virtual SchoolClass Class { get; set; }
        public virtual SubjectGroup Group { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not ClassSubject other) return false;
            return (this.ClassId == other.ClassId && this.SubjectId== other.SubjectId);
        }
        public override int GetHashCode()
        {
            return (this.ClassId*this.SubjectId).GetHashCode(); ;
        }
    }
}
