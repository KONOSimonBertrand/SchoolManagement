

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe représente les frais de scolarité
    /// </summary>
    public class SchoolingCost
    {
        public int Id {  get; set; }
        public int SchoolClassId { get; set; }

        public int CashFlowTypeId { get; set; }

        public int SchoolYearId { get; set; }

        public double  Amount { get; set; }
        public int? TrancheNumber { get; set; }

        public bool? IsPayable { get; set; }
        public virtual CashFlowType? CashFlowType { get; set; } 

        public virtual SchoolClass? SchoolClass { get; set; } 

        public virtual SchoolYear? SchoolYear { get; set; }
        public virtual ICollection<SchoolingCostItem> SchoolingCostItems { get; set; }=new List<SchoolingCostItem>();   

        public override bool Equals(object? obj)
        {
            if (obj is not SchoolingCost other) return false;
            return (this.Id==other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); 
        }
    }
}
