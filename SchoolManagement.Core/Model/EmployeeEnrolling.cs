

using System.Xml.Linq;

namespace SchoolManagement.Core.Model
{
    public class EmployeeEnrolling
    {
        public int Id {  get; set; }
        public string IdNumber { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId {  get; set; }
        public int SchoolYearId {  get; set; }
        public int GroupId {  get; set; }
        public int JobId {  get; set; }
        public double Salary { get; set; }
        public string? PictureUrl {  get; set; } 
        public virtual Employee Employee { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public virtual EmployeeGroup? Group { get; set; }
        public virtual string GroupName
        {
            get
            {
                return Group.Name;
            }
        }
        public virtual Job Job { get; set; }
        public virtual IList<EmployeeRoom> Rooms { get; set; } = new List<EmployeeRoom>();
        public virtual IList<EmployeeSubject> Subjects { get; set; } = new List<EmployeeSubject>();
        public virtual IList<EmployeeAttendance> Attendances { get; set; }= new List<EmployeeAttendance>();
        public virtual IList<EmployeeNote> Notes { get; set; }=new List<EmployeeNote>();
        public virtual IList<EmployeeAccountTransaction> AccountTransactions { get; set; }=new List< EmployeeAccountTransaction>();
        public override bool Equals(object? obj)
        {
            if (obj is not EmployeeEnrolling other) return false;
            return (this.Id == other.Id || this.IdNumber == other.IdNumber);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return IdNumber;
        }

    }
}
