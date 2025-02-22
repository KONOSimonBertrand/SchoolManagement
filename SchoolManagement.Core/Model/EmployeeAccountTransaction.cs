

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente une transaction du compte de l'employé
    /// </summary>
    public class EmployeeAccountTransaction
    {
        public int Id { get; set; }
        public DateTime Date{ get; set; }
        public double Amount { get; set; }
        public string TransactionId { get; set; }
        public string Reason { get; set; }
        public int EmployeeId {  get; set; }
        public int SchoolYearId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not EmployeeAccountTransaction other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
    }
}
