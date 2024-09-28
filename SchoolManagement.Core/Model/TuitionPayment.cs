
namespace SchoolManagement.Core.Model
{
    public class TuitionPayment
    {
        public int Id { get; set; }
        public string IdNumber {  get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public int EnrollingId { get; set; }
        public int CashFlowTypeId {  get; set; }
        public int PaymentMeanId {  get; set; }
        public double Balance {  get; set; }
        public string DoneBy {  get; set; }
        public DateTime TransactionDate {  get; set; }
        public string TransactionId {  get; set; }
        public bool IsDuringEnrolling {  get; set; }
        public string Note {  get; set; }
        public virtual StudentEnrolling Enrolling { get; set; }
        public virtual CashFlowType CashFlowType { get; set; }
        public virtual PaymentMean PaymentMean { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not TuitionPayment other) return false;
            return (other.Id == this.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
