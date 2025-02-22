

namespace SchoolManagement.Core.Model
{
    public  class EmployeeRoom
    {
        public int EmployeeId { get; set; }
        public int SchoolYearId {  get; set; }
        public int RoomId { get; set; }
        public bool IsMasterRoom { get; set; }
        public int DefaultSection {  get; set; }  
        public virtual bool IsChecked {  get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual SchoolYear? SchoolYear { get; set; }
        public virtual SchoolRoom? Room { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not EmployeeRoom other) return false;
            return (this.EmployeeId == other.EmployeeId && this.RoomId == other.RoomId && this.SchoolYearId==other.SchoolYearId );
        }
        public override int GetHashCode()
        {
            return (this.EmployeeId *this.RoomId*this.SchoolYearId).GetHashCode(); ;
        }
    }
}
