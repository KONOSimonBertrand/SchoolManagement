

using SchoolManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Primary.SchoolApp.DTO
{
    public class ReceiptDTO
    {

        public int Id { get; set; }
        public string? IdNumber { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
        public string? OpFor { get; set; }
        public string? OpDoneBy { get; set; }
        public DateTime Date { get; set; }
        public int SchoolYearId { get; set; }
        public SchoolYear? SchoolYear { get; set; }
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
        public virtual List<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();
    }
}
