﻿

using System.Diagnostics.SymbolStore;

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
        virtual public string TypeName
        {
            get
            {
                if (Type == "in")
                {
                    return Thread.CurrentThread.CurrentUICulture.Name == "en-GB"?"Input":"Flux d'entrée";
                }
                if (Type == "out")
                {
                    return Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "Out":"Flux de sortie";
                }
                return string.Empty;
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
                
                if (Category == "DE")
                {
                    return "out";
                }
                if (Category == "AP")
                {
                    return "out";
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
