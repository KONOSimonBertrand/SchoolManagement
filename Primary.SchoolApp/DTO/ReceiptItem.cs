
namespace Primary.SchoolApp.DTO
{
    internal class ReceiptItem
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public double Total { get => (Quantity * UnitPrice) - Discount; }
        public double Balance { get; set; }
        public string For { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is not ReceiptItem other) return false;
            return (this.Id == other.Id);
        }
    }
}
