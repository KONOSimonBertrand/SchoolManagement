

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Représente  la présence effective d'un enseignant à un cours.
    /// Date début et date de fin du cours;
    /// l'unité d'enseignement et lieu du cours
    /// </summary>
    public class EmployeeAttendance
    {
        public int Id { get; set; }
        public int EnrollingId {  get; set; }
        public int SubjectId {  get; set; }
        public int RoomId {  get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public string Description { get; set; }
        public virtual TimeSpan Duration
        {
            get
            {
                return EndHour-StartHour;
            }
        }
        public virtual EmployeeEnrolling Enrolling { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual SchoolRoom Room { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not EmployeeAttendance other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
    }
}
