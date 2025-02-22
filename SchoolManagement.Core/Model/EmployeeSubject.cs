

namespace SchoolManagement.Core.Model
{
    public class EmployeeSubject
    {
        public int EmployeeId {  get; set; }
        public int SchoolYearId { get; set; }
        public int SubjectId { get; set; }
        public int RoomId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual SchoolRoom Room { get; set; }
        public virtual bool IsChecked { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not EmployeeSubject other) return false;
            return (this.EmployeeId == other.EmployeeId && this.RoomId == other.RoomId && this.SubjectId==other.SubjectId && this.SchoolYearId == other.SchoolYearId);
        }
        public override int GetHashCode()
        {
            return (this.EmployeeId * this.RoomId*this.SubjectId*this.SchoolYearId).GetHashCode(); ;
        }
    }
}
