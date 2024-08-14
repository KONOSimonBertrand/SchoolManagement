

namespace SchoolManagement.Core.Model
{
    public class EmployeeSubject
    {
        public int EnrollingId {  get; set; }   
        public int SubjectId { get; set; }
        public int RoomId { get; set; }
        public virtual EmployeeEnrolling Enrolling { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual SchoolRoom Room { get; set; }
        public virtual bool IsChecked { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not EmployeeSubject other) return false;
            return (this.EnrollingId == other.EnrollingId && this.RoomId == other.RoomId && this.SubjectId==other.SubjectId);
        }
        public override int GetHashCode()
        {
            return (this.EnrollingId * this.RoomId*this.SubjectId).GetHashCode(); ;
        }
    }
}
