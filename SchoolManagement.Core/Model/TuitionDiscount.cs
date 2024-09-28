

namespace SchoolManagement.Core.Model
{
    public  class TuitionDiscount
    {
        public DateTime Date { get; set; }
        public double Amount {  get; set; }
        public int EnrollingId {  get; set; }
        public int CashFlowTypeId {  get; set; }
        public string OrderedBy {  get; set; }
        public string Reason { get; set; }
        public virtual StudentEnrolling Enrolling { get; set; }
        public virtual CashFlowType CashFlowType { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not TuitionDiscount other) return false;
            return (other.EnrollingId == this.EnrollingId && other.CashFlowTypeId==this.CashFlowTypeId);
        }
        public override int GetHashCode()
        {
            return (this.EnrollingId*this.CashFlowTypeId).GetHashCode();
        }


    }
}
