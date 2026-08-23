namespace Primary.SchoolApp.DTO
{
    public class ReceiptItem
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public double Total { get => (Quantity * UnitPrice) - Discount; }
        public double Balance { get; set; }
        public int ReceiptId { get; set; }
        public object LinkedItem { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not ReceiptItem other) return false;
            return (this.Id == other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
