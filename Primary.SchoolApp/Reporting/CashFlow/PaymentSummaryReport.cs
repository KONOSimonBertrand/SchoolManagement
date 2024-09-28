

using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Threading;

namespace Primary.SchoolApp.Reporting.CashFlow
{
    internal class PaymentSummaryReport : SchoolManagement.UI.Reporting.PaymentSummaryReport
    {
        public PaymentSummaryReport(){
            InitComponents();
    }

        private void InitComponents()
        {
            this.HeaderPicture.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? Resources.head_paper_fr : Resources.head_paper_en;
           this.RePortTitleTextBox.Value=Language.titleSummarySchoolFee.ToUpper();
            this.StudentLabel.Value=Language.labelStudent;
            this.StudentIdNumberLabel.Value=Language.labelStudentId;
            this.ClassLabel.Value=Language.labelClass;
            
            this.DateLabel.Value = "DATE";
            this.AmountLabel.Value=Language.labelAmount.ToUpper();
            this.ReasonLabel.Value = Language.labelReason.ToUpper();
        }
        public PaymentSummaryReport(StudentEnrolling enrolling,ClientApp clientApp)
        {
            InitComponents();
            this.SchoolYearTextBox.Value=Language.labelSchoolYear+": "+ enrolling.SchoolYear.Name;
            this.StudentTextBox.Value=enrolling.Student.FullName;
            this.StudentIdNumberTextBox.Value=enrolling.Student.IdNumber;
            this.ClassTextBox.Value=enrolling.SchoolClass.Name;
            this.DateTextBox.Value = "=Date.ToShortDateString()";
            this.AmountTextBox.Value = "=Amount";
            this.ReasonTextBox.Value = "=CashFlowType.Name";
            this.DataSource = enrolling.PaymentList;
            this.PrintDateTextBox.Value = DateTime.Now.ToString();
            this.TotalTextBox.Value = enrolling.PaymentList.Sum(c => c.Amount).ToString() + " CFA";
            if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
            {
                this.TotalInLetterTextBox.Value = "(" + enrolling.PaymentList.Sum(a => a.Amount).ToLetter(CountryLanguage.French, Currency.CFA) + ")";
            }
            else
            {
                this.TotalInLetterTextBox.Value = "(" + enrolling.PaymentList.Sum(a => a.Amount).ToLetter(CountryLanguage.English, Currency.CFA) + ")";
            }
            this.ContactTextBox.Value = clientApp.Contact;
            this.WebSiteTextBox.Value = clientApp.WebSite;
            this.SchoolNameTextBox.Value = clientApp.Name;
            this.AddressTextBox.Value = clientApp.Address;

        }
    }
}
