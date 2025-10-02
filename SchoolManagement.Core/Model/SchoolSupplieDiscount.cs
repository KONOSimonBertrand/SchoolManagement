

namespace SchoolManagement.Core.Model
{
    public  class SchoolSupplieDiscount
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Discount {  get; set; }
        public int DiscountType {  get; set; }
        public int EnrollingId {  get; set; }
        public int CashFlowTypeId {  get; set; }
        public string? OrderedBy {  get; set; }
        public string? Reason { get; set; }
        public virtual StudentEnrolling? Enrolling { get; set; }
        public virtual CashFlowType? CashFlowType { get; set; }
        public bool IsActive { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not SchoolSupplieDiscount other) return false;
            return (other.Id == this.Id);
        }
        public override int GetHashCode()
        {
            return (this.EnrollingId*this.CashFlowTypeId).GetHashCode();
        }


    }
}
