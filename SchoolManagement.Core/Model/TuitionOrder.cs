

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Transaction relative à un paiement des frais scolaire
    /// </summary>
    public class TuitionOrder
    {
        public int Id { get; set; }
        public string? IdNumber { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double Balance { get; set; }
        public int PaymentMeanId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? TransactionId { get; set; }
        public string? Note { get; set; }
        public int EnrollingId { get; set; }
        public string? DoneBy { get; set; }
        public bool IsValidated { get; set; }
        public string ValidattionState
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-GB")
                {
                    return IsValidated ? "OK" : "Pending";
                }
                else
                {
                    return IsValidated ? "OK" : "En attente";
                }
            }
        }
        public virtual StudentEnrolling? Enrolling { get; set; }
        public virtual PaymentMean? PaymentMean { get; set; }
        public virtual required List<TuitionOrderItem> TuitionOrderItems { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not TuitionOrder other) return false;
            return (other.Id == this.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
