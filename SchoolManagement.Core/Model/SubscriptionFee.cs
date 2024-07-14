

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe représente le coût d'abonnement
    /// Exemple 70000 la danse pour l'année 2021-2022
    /// </summary>
    public class SubscriptionFee
    {
        public int Id {  get; set; }
        public double Amount {  get; set; }
        public int Duration {  get; set; }
        public int CashFlowTypeId {  get; set; }
        public int SchoolYearId {  get; set; }
        public virtual CashFlowType? CashFlowType{get; set; }
        public virtual SchoolYear? SchoolYear { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not SubscriptionFee other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override string ToString()
        {
            string stringToReturn=string.Empty;
            if (CashFlowType != null) {
                if (SchoolYear != null) {
                    stringToReturn = CashFlowType.Name + ": frais " + Amount + " année scolaire " + SchoolYear.Name;
                }
            }
            return stringToReturn;
        }
    }
}
