

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente une type de frais de trésorerie
    /// Exemple Inscription, Pension
    /// </summary>
    public class CashFlowType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string TypeName
        {
            get
            {
                if (Type == "in")
                {
                    return "Flux d'entrée";
                }
                if (Type == "out")
                {
                    return "Flux de sortie";
                }
                return "Inconnu";
            }
        }
        public string? Category { get; set; }
        public string Type
        {
            get
            {
                if (Category == "FS")
                {
                    return "in";
                }
                if (Category == "AB")
                {
                    return "in";
                }
                if (Category == "SA")
                {
                    return "out";
                }
                if (Category == "DE")
                {
                    return "out";
                }
                if (Category == "in")
                {
                    return "APPROVISIONNEMENT";
                }
                return "RAS";
            }
        }
        public string CategoryName
        {
            get
            {
                if (Category == "AB")
                {
                    return "ABONNEMENT";
                }
                if (Category == "FS")
                {
                    return "FRAIS DE SCOLAIRE";
                }
                if (Category == "SA")
                {
                    return "SALAIRE";
                }
                if (Category == "DE")
                {
                    return "DEPENSE";
                }
                if (Category == "AP")
                {
                    return "APPROVISIONNEMENT";
                }
                return "RAS";
            }
        }
        public string? Domain { get; set; }
        public string? Description { get; set; }
        public int Sequence { get; set; }
        public virtual ICollection<SchoolingCost> SchoolingCosts { get; set; } 
        public virtual ICollection<SubscriptionFee> SubscriptionFees { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not CashFlowType other) return false;
            return (this.Id == other.Id || this.Name == other.Name);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
