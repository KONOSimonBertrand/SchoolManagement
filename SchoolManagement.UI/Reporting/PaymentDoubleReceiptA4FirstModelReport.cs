

namespace SchoolManagement.UI.Reporting
{
    public partial class PaymentDoubleReceiptA4FirstModelReport : Telerik.Reporting.Report
    {
        #region Properties
        public Telerik.Reporting.TextBox FirstCopyLabel { get => copyLabel; }
        public Telerik.Reporting.PictureBox SchoolLogoPictureBox { get => logoPictureBox; }
        public Telerik.Reporting.TextBox SchoolNameTextBox { get => schoolNameTextBox; }
        public Telerik.Reporting.TextBox SchoolAdressTextBox { get => adressTextBox; }
        public Telerik.Reporting.TextBox SchoolPhoneTextBox { get => phoneTextBox; }
        public Telerik.Reporting.TextBox SchoolEmailTextBox { get => emailTextBox; }
        public Telerik.Reporting.TextBox SchoolWebSiteTextBox { get => webSiteTextBox; }

        public Telerik.Reporting.TextBox ReceiptNumberLabel { get => referenceLabel; }
        public Telerik.Reporting.TextBox ReceiptNumberTextBox { get => paymentIdTextBox; }
        public Telerik.Reporting.TextBox PaymentDateLabel { get => paymentDateLabel; }
        public Telerik.Reporting.TextBox PaymentDateTextBox { get => paymentDateTextBox; }
        public Telerik.Reporting.TextBox SchoolYearLabel { get => schoolYearLabel; }
        public Telerik.Reporting.TextBox SchoolYearTextBox { get => schoolYearTextBox; }

        public Telerik.Reporting.TextBox StudentNameTextBox { get => studentTextBox; }
        public Telerik.Reporting.TextBox EnrollmentInfoTextBox { get => enrollmentInfoTextBox; }

        public Telerik.Reporting.Table PaymentsTable { get => paymentTable; }
        public Telerik.Reporting.TextBox PaymentsTableItemLabel { get => paymentsTableReasonLabel; }
        public Telerik.Reporting.TextBox PaymentsTableItemTextBox { get => paymentsTableReasonTextBox; }
        public Telerik.Reporting.TextBox PaymentsTableAmountLabel { get => paymentsTableAmountLabel; }
        public Telerik.Reporting.TextBox PaymentsTableAmountTextBox { get => paymentsTableAmountTextBox; }
        public Telerik.Reporting.TextBox PaymentsTableBalanceLabel { get => paymentsTableBalanceLabel; }
        public Telerik.Reporting.TextBox PaymentsTableBalanceTextBox { get => paymentsTableBalanceTextBox; }

        public Telerik.Reporting.TextBox TotalAmountLabel { get => totalAmountLabel; }
        public Telerik.Reporting.TextBox TotalAmountTextBox { get => totalAmountTextBox; }
        public Telerik.Reporting.TextBox PaymentAmountLeterTextBox { get => paymentAmountLeterTextBox; }
        public Telerik.Reporting.TextBox NoteTextBox { get => noteTextBox; }

        public Telerik.Reporting.TextBox SignatureDoneByLabel { get => signatureDoneByLabel; }
        public Telerik.Reporting.TextBox SignatureSchoolLabel { get => schoolSignatureLabel; }
        public Telerik.Reporting.Panel SignatureDoneByPanel { get => signatureDoneByPanel; }
        public Telerik.Reporting.Panel SignatureSchoolPanel { get => schoolSignaturePanel; }

        public Telerik.Reporting.TextBox PrintDateTextBox { get => printDateTextBox; }
        public Telerik.Reporting.TextBox FootherInformationsTextBox { get => footherInformationsTextBox; }
        public Telerik.Reporting.Shape ReceiptSeparationShape { get => receiptSeparationShape; }

        //Copy section

        public Telerik.Reporting.TextBox SecondCopyLabel { get => copy2Label; }
        public Telerik.Reporting.PictureBox SchoolLogoCopyPictureBox { get => logo2PictureBox; }
        public Telerik.Reporting.TextBox SchoolNameCopyTextBox { get => schoolName2TextBox; }
        public Telerik.Reporting.TextBox SchoolAdressCopyTextBox { get => adress2TextBox; }
        public Telerik.Reporting.TextBox SchoolPhoneCopyTextBox { get => phone2TextBox; }
        public Telerik.Reporting.TextBox SchoolEmailCopyTextBox { get => email2TextBox; }
        public Telerik.Reporting.TextBox SchoolWebSiteCopyTextBox { get => webSite2TextBox; }

        public Telerik.Reporting.TextBox ReceiptNumberCopyLabel { get => reference2Label; }
        public Telerik.Reporting.TextBox ReceiptNumberCopyTextBox { get => paymentId2TextBox; }
        public Telerik.Reporting.TextBox PaymentDateCopyLabel { get => paymentDate2Label; }
        public Telerik.Reporting.TextBox PaymentDateCopyTextBox { get => paymentDate2TextBox; }
        public Telerik.Reporting.TextBox SchoolYearCopyLabel { get => schoolYear2Label; }
        public Telerik.Reporting.TextBox SchoolYearCopyTextBox { get => schoolYear2TextBox; }

        public Telerik.Reporting.TextBox StudentNameCopyTextBox { get => student2TextBox; }
        public Telerik.Reporting.TextBox EnrollmentInfoCopyTextBox { get => enrollmentInfo2TextBox; }

        public Telerik.Reporting.Table PaymentsCopyTable { get => payment2Table; }
        public Telerik.Reporting.TextBox PaymentsTableItemCopyLabel { get => paymentsTableReason2Label; }
        public Telerik.Reporting.TextBox PaymentsTableItemCopyTextBox { get => paymentsTableReason2TextBox; }
        public Telerik.Reporting.TextBox PaymentsTableAmountCopyLabel { get => paymentsTableAmount2Label; }
        public Telerik.Reporting.TextBox PaymentsTableAmountCopyTextBox { get => paymentsTableAmount2TextBox; }
        public Telerik.Reporting.TextBox PaymentsTableBalanceCopyLabel { get => paymentsTableBalance2Label; }
        public Telerik.Reporting.TextBox PaymentsTableBalanceCopyTextBox { get => paymentsTableBalance2TextBox; }

        public Telerik.Reporting.TextBox TotalAmountCopyLabel { get => totalAmount2Label; }
        public Telerik.Reporting.TextBox TotalAmountCopyTextBox { get => totalAmount2TextBox; }
        public Telerik.Reporting.TextBox PaymentAmountLeterCopyTextBox { get => paymentAmountLeter2TextBox; }
        public Telerik.Reporting.TextBox NoteCopyTextBox { get => note2TextBox; }

        public Telerik.Reporting.TextBox SignatureDoneByCopyLabel { get => signatureDoneBy2Label; }
        public Telerik.Reporting.TextBox SignatureSchoolCopyLabel { get => schoolSignature2Label; }
        public Telerik.Reporting.Panel SignatureDoneByCopyPanel { get => signatureDoneBy2Panel; }
        public Telerik.Reporting.Panel SignatureSchoolCopyPanel { get => schoolSignature2Panel; }


        public Telerik.Reporting.Panel FirstCopyPanel { get => firstCopyPanel; }
        public Telerik.Reporting.Panel SecondCopyPanel { get => secondCopyPanel; }

        public Telerik.Reporting.TextBox PrintDateCopyTextBox { get => printDate2TextBox; }
        public Telerik.Reporting.TextBox FootherInformationsCopyTextBox { get => footherInformations2TextBox; }


        #endregion
        public PaymentDoubleReceiptA4FirstModelReport() { InitializeComponent(); }
    }
}
