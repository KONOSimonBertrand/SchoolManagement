

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe représente un approvisionnement de caisse
    /// </summary>
    public class CashBoxIn: CashBox
    {
        public override bool Equals(object? obj)
        {
            if (obj is not CashBoxIn other) return false;
            return (other.Id == this.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
