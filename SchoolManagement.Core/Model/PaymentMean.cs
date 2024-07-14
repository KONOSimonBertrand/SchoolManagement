

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente un moyen de paiement
    /// Exemple Orange money, banque...
    /// </summary>
    public class PaymentMean
    {
        public int Id {  get; set; }    
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Account {  get; set; }
        public int Sequence {  get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not PaymentMean other) return false;
            return (this.Id == other.Id || this.Name == other.Name);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return Name+"-"+Type;
        }

    }
}
