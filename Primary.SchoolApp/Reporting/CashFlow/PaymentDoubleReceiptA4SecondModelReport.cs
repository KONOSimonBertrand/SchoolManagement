
using SchoolManagement.Application.Extensions;
using SchoolManagement.UI.Localization;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Telerik.Reporting.Drawing;

namespace Primary.SchoolApp.Reporting
{
    public class PaymentDoubleReceiptA4SecondModelReport : SchoolManagement.UI.Reporting.PaymentDoubleReceiptA4FirstModelReport
    {
        public PaymentDoubleReceiptA4SecondModelReport(DTO.DTOItem.PaymentReceipt paymentReceipt, bool isCopy)
        {
            InitComponents();
            ChangeLanguage();
            this.PaymentsTableAmountCopyTextBox.Value = "=Total";
            this.PaymentsTableAmountTextBox.Value = "=Total";
            this.PaymentsTableItemCopyTextBox.Value = "=ItemName";
            this.PaymentsTableItemTextBox.Value = "=ItemName";
            this.EnrollmentInfoTextBox.Value = paymentReceipt.HeaderSection.StudentId+" | "+paymentReceipt.HeaderSection.StudentRoom;
            this.StudentNameTextBox.Value = paymentReceipt.HeaderSection.StudentName;
            this.ReceiptNumberTextBox.Value = paymentReceipt.HeaderSection.ReceiptNumber;
            this.SchoolYearTextBox.Value= paymentReceipt.HeaderSection.SchoolYear;
            this.PaymentDateTextBox.Value =paymentReceipt.HeaderSection.ReceiptDate.Date.ToShortDateString()+":"+ paymentReceipt.HeaderSection.ReceiptDate.Date.ToShortTimeString();

            this.EnrollmentInfoCopyTextBox.Value = this.EnrollmentInfoTextBox.Value;
            this.StudentNameCopyTextBox.Value = this.StudentNameTextBox.Value;
            this.ReceiptNumberCopyTextBox.Value = this.ReceiptNumberTextBox.Value;
            this.SchoolYearCopyTextBox.Value = this.SchoolYearTextBox.Value;
            this.PaymentDateCopyTextBox.Value = this.PaymentDateTextBox.Value;
            var items= paymentReceipt.DetailSection.Items;
            this.PaymentsTable.DataSource = items;
            this.PaymentsCopyTable.DataSource = this.PaymentsTable.DataSource;
            var totalAmount = items.Sum(x => x.Total);
            this.TotalAmountTextBox.Value = totalAmount.ToString();
            this.TotalAmountCopyTextBox.Value = TotalAmountTextBox.Value;
            this.PaymentAmountLeterTextBox.Value = "TOTAL: "+ totalAmount.ToString() +" "+ CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + " ("+totalAmount.ToLetter(Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? CountryLanguage.French : CountryLanguage.English).ToUpper()+")";
            this.PaymentAmountLeterCopyTextBox.Value = this.PaymentAmountLeterTextBox.Value;
            if (items.Count > 3)
            {
                this.SignatureDoneByPanel.Location = new PointU(this.SignatureDoneByPanel.Location.X, Unit.Inch(3.543D) - Unit.Inch(0.07D) * items.Count);
                this.SignatureDoneByCopyPanel.Location = new PointU(this.SignatureDoneByCopyPanel.Location.X, Unit.Inch(3.543D) - Unit.Inch(0.07D) * items.Count);
                this.SignatureSchoolPanel.Location = new PointU(this.SignatureSchoolPanel.Location.X, Unit.Inch(3.543D) - Unit.Inch(0.07D) * items.Count);
                this.SignatureSchoolCopyPanel.Location = new PointU(this.SignatureSchoolCopyPanel.Location.X, Unit.Inch(3.543D) - Unit.Inch(0.07D) * items.Count);

                this.PrintDateTextBox.Location = new PointU(this.PrintDateTextBox.Location.X, Unit.Inch(4.134D) - Unit.Inch(0.07D) * items.Count);
                this.PrintDateCopyTextBox.Location = new PointU(this.PrintDateCopyTextBox.Location.X, Unit.Inch(4.134D) - Unit.Inch(0.07D) * items.Count);

                this.FootherInformationsTextBox.Location = new PointU(this.FootherInformationsTextBox.Location.X, Unit.Inch(4.764D) - Unit.Inch(0.18D) * items.Count);
                this.FootherInformationsCopyTextBox.Location = new PointU(this.FootherInformationsCopyTextBox.Location.X, Unit.Inch(4.764D) - Unit.Inch(0.18D) * items.Count);
            }
            this.FirstCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
            this.SecondCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
            this.FirstCopyLabel.Visible=isCopy;
            this.SecondCopyLabel.Visible=isCopy;
            this.FootherInformationsCopyTextBox.Value = "Other information";
            this.FootherInformationsTextBox.Value = "Other information";
        }

        private void ChangeLanguage()
        {
            this.ReceiptNumberLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Reçu N°" : "Receipt N°";
            this.PaymentDateLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Date" : "Date";
            this.SchoolYearLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Anné scolaire" : "School year";
            
            PaymentsTableAmountLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "MONTANT" : "AMOUNT";
            PaymentsTableItemLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "DESCRIPTION" : "DESCRIPTION";
            PaymentsTableBalanceLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "IMPAYÉ" : "BALANCE";

            this.NoteTextBox.Value = NoteTextBox.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "NB: Un reçu est delivré par élève (Each student is issued one receipt)" : "NB: Each student is issued one receipt (Un reçu est delivré par élève)";
            PrintDateTextBox.Value = Language.labelPrintOn + "  " + DateTime.Now.ToString();

            this.ReceiptNumberCopyLabel.Value = this.ReceiptNumberLabel.Value;
            this.PaymentDateCopyLabel.Value = this.PaymentDateLabel.Value;
            this.SchoolYearCopyLabel.Value = this.SchoolYearLabel.Value;

            PaymentsTableAmountCopyLabel.Value = PaymentsTableAmountLabel.Value;
            PaymentsTableItemCopyLabel.Value = PaymentsTableItemLabel.Value;
            PaymentsTableBalanceCopyLabel.Value = PaymentsTableBalanceLabel.Value;

            this.NoteCopyTextBox.Value = this.NoteTextBox.Value;
            PrintDateCopyTextBox.Value = PrintDateTextBox.Value;
        }

        private void InitComponents()
        {
            ReceiptNumberTextBox.Value = string.Empty;
            PaymentDateTextBox.Value = string.Empty;
            SchoolYearTextBox.Value = string.Empty;

            ReceiptNumberCopyTextBox.Value = string.Empty;
            PaymentDateCopyTextBox.Value = string.Empty;
            SchoolYearCopyTextBox.Value = string.Empty; 

            StudentNameTextBox.Value = string.Empty;
            EnrollmentInfoTextBox.Value = string.Empty;

            StudentNameCopyTextBox.Value = string.Empty;
            EnrollmentInfoCopyTextBox.Value = string.Empty;

            SchoolNameTextBox.Value = string.Empty;
            SchoolAdressTextBox.Value = string.Empty;
            SchoolEmailTextBox.Value = string.Empty;
            SchoolPhoneTextBox.Value = string.Empty; 
            SchoolWebSiteTextBox.Value = string.Empty;

            SchoolNameCopyTextBox.Value = string.Empty;
            SchoolAdressCopyTextBox.Value = string.Empty;
            SchoolEmailCopyTextBox.Value = string.Empty;
            SchoolPhoneCopyTextBox.Value = string.Empty;
            SchoolWebSiteCopyTextBox.Value = string.Empty;

            NoteTextBox.Value = string.Empty;
            NoteCopyTextBox.Value = string.Empty;

            PrintDateTextBox.Value = string.Empty;
            PrintDateCopyTextBox.Value = string.Empty;

            PaymentAmountLeterTextBox.Value = string.Empty;
            PaymentAmountLeterCopyTextBox.Value = string.Empty;
            FootherInformationsTextBox.Value = string.Empty;
            FootherInformationsCopyTextBox.Value = string.Empty;

            SchoolNameTextBox.Value = Program.CurrentSchool.Name;
            SchoolNameCopyTextBox.Value = SchoolNameTextBox.Value;
            SchoolWebSiteTextBox.Value = Program.CurrentSchool.WebSite;
            SchoolWebSiteCopyTextBox.Value = SchoolWebSiteTextBox.Value;
            SchoolEmailTextBox.Value = Program.CurrentSchool.Email;
            SchoolEmailCopyTextBox.Value = SchoolEmailTextBox.Value;
            SchoolPhoneTextBox.Value = Program.CurrentSchool.Phone;
            SchoolPhoneCopyTextBox.Value = SchoolPhoneTextBox.Value;
            SchoolAdressTextBox.Value = Program.CurrentSchool.Address;
            SchoolAdressCopyTextBox.Value = SchoolAdressTextBox.Value;
            SchoolLogoPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("logo.png");
            SchoolLogoCopyPictureBox.Value = SchoolLogoPictureBox.Value;
            SchoolPhoneTextBox.Value = Program.CurrentSchool.Phone;
            SchoolPhoneCopyTextBox.Value = SchoolPhoneTextBox.Value;

        }
    }
}
