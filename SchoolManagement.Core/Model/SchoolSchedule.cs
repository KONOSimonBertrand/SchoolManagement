

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Représente la programmation d'un cours ou d'un évènement.
    /// </summary>
    public class SchoolSchedule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int SubjectId { get; set; }
        public int RoomId { get; set; }
        public int SchoolYearId {  get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual SchoolRoom Room { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not SchoolSchedule other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
    }
}
