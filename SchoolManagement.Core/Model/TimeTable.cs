

namespace SchoolManagement.Core.Model
{
    public class TimeTable
    {
        public int Id {  get; set; }
        public string Description { get; set; }
        public int SubjectId {  get; set; }
        public int TeacherId {  get; set; }
        public int RoomId {  get; set; }
        public int SchoolYearId { get; set; }
        public TimeTableState State {  get; set; }
        public bool IsClosed {  get; set; }
        public virtual int DayId { get; set; }
        public virtual DayOfWeek Day{ get; set; }
        public DateTime TeacherIn { get; set; }
        public DateTime TeacherOut { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public virtual Subject Course { get; set; } 
        public virtual Employee Teacher { get; set; }
        public virtual SchoolRoom Room { get; set; }    
        public virtual SchoolYear SchoolYear { get; set; }
        public enum TimeTableState
        {
            ToDo = 1,
            InProgress = 2,
            Done = 3,
            NoDone = 4,
            Canceled = 5,
        }

        public override bool Equals(object? obj)
        {
            if (obj is not TimeTable other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }


    }
}
