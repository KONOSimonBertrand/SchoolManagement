using Primary.SchoolApp.DTO;
using System;
using System.Linq;


namespace Primary.SchoolApp.Services
{
    internal class LocalEnrollingService 
    {
        internal double GetInsolvencyAmount(StudentEnrollingDTO enrolling, int cashFlowTypeId)
        {
            double sum = 0;
            if (enrolling != null)
            {
                //extraction des frais liés au type de flux de trésorerie
                var fee = Program.SchoolingCostList.FirstOrDefault(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.IsPayable == true && x.SchoolClassId == enrolling.ClassId && x.CashFlowTypeId == cashFlowTypeId);
                if (fee != null)
                {   //extraction des tranches de payement liées
                    fee.SchoolingCostItems = Program.SchoolingCostItemList.Where(x => x.SchoolingCostId == fee.Id).ToList();
                    if (fee.SchoolingCostItems.Count != 0)
                    {
                        for (int i = 1; i <= fee.SchoolingCostItems.Count; i++)
                        {
                            if (DateTime.Now.Date >= fee.SchoolingCostItems.FirstOrDefault(x => x.Rank == i).DeadLine.Date)
                            {
                                var amountToPay = fee.SchoolingCostItems.Where(x => x.Rank <= i).Sum(x => x.Amount);
                                var amountPaid = enrolling.PaymentPayableList.Where(x=>x.CashFlowTypeId== cashFlowTypeId).Sum(x => x.Amount);
                                var discount = enrolling.DiscountList.Where(x => x.CashFlowTypeId == cashFlowTypeId).Sum(x => x.Amount);
                                var balance = amountToPay - (amountPaid + discount);
                                if (balance > 0)
                                {
                                    sum = balance;
                                }
                            }
                        }
                    }
                }
            }
            return sum;
        }
    }
}
