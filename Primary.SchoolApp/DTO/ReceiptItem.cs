

namespace Primary.SchoolApp.DTO
{
    /// <summary>
    /// ligne d'un reçu
    /// </summary>
    internal class ReceiptItem
    {
        public int Id { get; set; }
        public double Quantity {  get; set; }
        public double UnitPrice {  get; set; }
        public double Discount{  get; set; }
        public double Total{  get; set; }
        public string Description { get; set; }
        public string CashFlowTypeName { get; set; }
        public bool IsSelected { get; set; }
        public string CashFlowCategory { get; internal set; }
        public double AmountToPay { get; internal set; }
    }
}
