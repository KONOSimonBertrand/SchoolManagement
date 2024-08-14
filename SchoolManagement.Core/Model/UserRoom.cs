

namespace SchoolManagement.Core.Model
{
    public class UserRoom
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public User User { get; set; }
        public SchoolRoom Room { get; set; }
        public virtual bool IsChecked{get;set;}//is true if room is allocated
        public override bool Equals(object? obj)
        {
            if (obj is not UserRoom other) return false;
            return (this.UserId == other.UserId && this.RoomId == other.RoomId);
        }
        public override int GetHashCode()
        {
            return (this.UserId * this.RoomId).GetHashCode();
        }
    }
}
