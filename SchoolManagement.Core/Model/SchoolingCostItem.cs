

namespace SchoolManagement.Core.Model
{
    public class SchoolingCostItem
    {
        public int Id {  get; set; }
        public double Amount { get; set; }
        public DateTime DeadLine { get; set; }
        public int Rank {  get; set; }
        public int SchoolingCostId {  get; set; }
        public virtual SchoolingCost? SchoolingCost { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not SchoolingCost other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); 
        }
    }
}
