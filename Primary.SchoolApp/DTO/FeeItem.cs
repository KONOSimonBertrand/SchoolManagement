

namespace Primary.SchoolApp.DTO
{
    /// <summary>
    /// ligne d'un reçu
    /// </summary>
    internal class FeeItem
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public double Quantity {  get; set; }
        public double UnitPrice {  get; set; }
        public double Total{get=> Quantity * UnitPrice; }
        public string Description { get; set; }
        public string Category { get; internal set; }
        public object Tag { get; internal set; }
        public override bool Equals(object obj)
        {
            if (obj is not FeeItem other) return false;
            return (this.Id == other.Id);
        }
    }
}
