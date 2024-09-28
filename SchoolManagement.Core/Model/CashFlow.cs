

namespace SchoolManagement.Core.Model
{

    /// <summary>
    /// Cette classe représente un flux de trésorerie
    /// </summary>
    public class CashFlow
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string IdNumber { get; set; }
        public double Amount {  get; set; }
        public int CashFlowTypeId {  get; set; }
        public int SchoolYearId {  get; set; }
        public string DoneBy {  get; set; }
        public string Note {  get; set; }
        public virtual CashFlowType CashFlowType { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not CashFlow other) return false;
            return (other.Id == this.Id );
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
