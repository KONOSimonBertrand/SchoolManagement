

using SchoolManagement.Core.Enum;

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
        public FlowCategory FlowCategory { get; set; }
        public FlowDomain FlowDomain { get; set; }
       public FlowType FlowType { get; set; }
        public string? Description { get; set; }
        public int Sequence { get; set; }
        public TransactionType TransactionType { get; set; }
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
            return Name ?? string.Empty;
        }
    }
}
