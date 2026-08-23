

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Représente un reçu de paiement .
    /// </summary>
    public class Receipt
    {
        public int Id { get; set; }
        public string? IdNumber { get; set; }
        public double Amount { get; set; }  
        public double Balance { get; set; }  
        public string? OpFor { get; set; }
        public string? OpDoneBy { get; set; }
        public DateTime Date { get; set; }
        public int SchoolYearId { get; set; }
        public SchoolYear? SchoolYear { get; set; }
        public bool IsValidated { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not Receipt other) return false;
            return (this.Id == other.Id || this.IdNumber == other.IdNumber);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return IdNumber??"";
        }
    }
}
