
namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe représente une sortie de caisse ou une dépense
    /// </summary>
    public class CashBoxOut: CashBox
    {
        public override bool Equals(object? obj)
        {
            if (obj is not CashBoxOut other) return false;
            return (other.Id == this.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
