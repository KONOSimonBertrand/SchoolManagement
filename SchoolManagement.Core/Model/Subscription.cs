

namespace SchoolManagement.Core.Model
{
    public class Subscription
    {
        public int Id { get; set; }
        public string? IdNumber { get; set; }
        public DateTime StartDate { get; set; }
        public double Amount { get; set; }
        public double Discount {  get; set; }
        public DateTime EndDate { get; set; }
        public string DoneBy { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int StudentId { get; set; }
        public int SchoolYearId { get; set; }
        public int CashFlowTypeId { get; set; }  
        public int PaymentMeanId { get; set; }
        public bool IsValidated { get; set; }
        public string ValidattionState
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-GB")
                {
                    return IsValidated ? "OK" : "Pending";
                }
                else
                {
                    return IsValidated ? "OK" : "En attente";
                }
            }
        }
        virtual public string State
        {
            get
            {
               
                if(EndDate.Date> DateTime.Now.Date)
                {
                    return Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "Ongoing" : "En cours";
                }
                if (EndDate.Date < DateTime.Now.Date)
                {
                    return Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "Expired" : "Expiré";
                }
               return string.Empty;
            }
        }
        public virtual Student Student{ get; set; }
        public virtual SchoolYear SchoolYear{ get; set; }
        public virtual CashFlowType CashFlowType { get; set; }
        public virtual PaymentMean PaymentMean { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Student other) return false;
            return (this.Id == other.Id );
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }

    }
}
