

namespace SchoolManagement.Core.Model
{
    public class TuitionOrderItem
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double Balance { get; set; }
        public int CashFlowTypeId { get; set; }
        public int TuitionOrderId { get; set; }
        public virtual TuitionOrder? TuitionOrder { get; set; }
        public virtual CashFlowType? CashFlowType { get; set; }
    }
}
