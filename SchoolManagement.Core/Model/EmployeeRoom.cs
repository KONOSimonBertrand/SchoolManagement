

namespace SchoolManagement.Core.Model
{
    public  class EmployeeRoom
    {
        public int EnrollingId { get; set; }
        public int RoomId { get; set; }
        public bool IsMasterRoom { get; set; }
        public int DefaultSection {  get; set; }  
        public virtual bool IsChecked {  get; set; }
        public virtual EmployeeEnrolling Enrolling { get; set; }
        public virtual SchoolRoom Room { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not EmployeeRoom other) return false;
            return (this.EnrollingId == other.EnrollingId && this.RoomId == other.RoomId);
        }
        public override int GetHashCode()
        {
            return (this.EnrollingId*this.RoomId).GetHashCode(); ;
        }
    }
}
