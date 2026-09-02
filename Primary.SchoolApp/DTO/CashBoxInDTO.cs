using SchoolManagement.Core.Model;
using System;
using System.Threading;

namespace Primary.SchoolApp.DTO
{
    public class CashBoxInDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string IdNumber { get; set; }
        public double Amount { get; set; }
        public int CashFlowTypeId { get; set; }
        public int SchoolYearId { get; set; }
        public string DoneBy { get; set; }
        public string Note { get; set; }
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
        public virtual CashFlowType CashFlowType { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not CashBoxInDTO other) return false;
            return (other.Id == this.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
