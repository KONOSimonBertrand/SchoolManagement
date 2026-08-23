

namespace SchoolManagement.UI.Reporting
{
    public partial class PaymentDoubleReceiptA4SecondModelReport: Telerik.Reporting.Report
    {
        #region Properties
        public Telerik.Reporting.PictureBox SchoolLogoPictureBox { get => logoPictureBox; }
        public Telerik.Reporting.TextBox SchoolNameTextBox { get => schoolNameTextBox; }
        public Telerik.Reporting.TextBox ReceiptNumberLabel { get => referenceLabel; }
        public Telerik.Reporting.TextBox ReceiptNumberTextBox { get => paymentIdTextBox; }
        public Telerik.Reporting.TextBox PaymentDateLabel { get => paymentDateLabel; }
        public Telerik.Reporting.TextBox PaymentDateTextBox { get => paymentDateTextBox; }
        public Telerik.Reporting.TextBox StudentLabelFR { get => studentLabelFR; }
        public Telerik.Reporting.TextBox StudentLabelEN { get => studentLabelEN; }
        public Telerik.Reporting.TextBox StudentTextBox { get => studentTextBox; }
        public Telerik.Reporting.TextBox StudentIdNumberLabel { get => studentIdLabel; }
        public Telerik.Reporting.TextBox StudentIdNumberTextBox { get => studentIdTextBox; }
        public Telerik.Reporting.TextBox StudentClassLabelEN { get => studentClassLabelEN; }
        public Telerik.Reporting.TextBox StudentClassLabelFR { get => studentClassLabelFR; }
        public Telerik.Reporting.TextBox StudentClassTextBox { get => studentClassTextBox; }
        public Telerik.Reporting.TextBox SchoolYearLabelFR { get => schoolYearLabelFR; }
        public Telerik.Reporting.TextBox SchoolYearLabelEN { get => schoolYearLabelEN; }
        public Telerik.Reporting.TextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public Telerik.Reporting.TextBox PaymentAmountLabelEN { get => paymentAmountLabelEN; }
        public Telerik.Reporting.TextBox PaymentAmountLabelFR { get => paymentAmountLabelFR; }
        public Telerik.Reporting.TextBox PaymentAmountTextBox { get => paymentAmountTextBox; }
        public Telerik.Reporting.TextBox PaymentAmountLeterTextBox { get => paymentAmountLeterTextBox; }
        public Telerik.Reporting.TextBox PaymentReasonLabelFR { get => paymentCostTypeLabelFR; }
        public Telerik.Reporting.TextBox PaymentReasonLabelEN { get => paymentCostTypeLabelEN; }
        public Telerik.Reporting.TextBox PaymentReasonTextBox { get => paymentCostTypeTextBox; }
        public Telerik.Reporting.TextBox PaymentBalanceLabelEN { get => restToPayLabelEN; }
        public Telerik.Reporting.TextBox PaymentBalanceLabelFR { get => restToPayLabelFR; }
        public Telerik.Reporting.TextBox PaymentBalanceTextBox { get => restToPayTextBox; }
        public Telerik.Reporting.TextBox PaymentMeanLabelFR { get => paymentPlaceLabelFR; }
        public Telerik.Reporting.TextBox PaymentMeanLabelEN { get => paymentPlaceLabelEN; }
        public Telerik.Reporting.TextBox PaymentMeanTextBox { get => paymentPlaceTextBox; }
        public Telerik.Reporting.TextBox TransactionLabelEN { get => transactionLabelEN; }
        public Telerik.Reporting.TextBox TransactionLabelFR { get => transactionLabelFR; }
        public Telerik.Reporting.TextBox TransactionIdTextBox { get => transactionTextBox; }
        public Telerik.Reporting.Table PaymentsTable { get => paymentTable; }
        public Telerik.Reporting.TextBox PaymentsTableReasonLabel { get => paymentsTableReasonLabel; }
        public Telerik.Reporting.TextBox PaymentsTableReasonTextBox { get => paymentsTableReasonTextBox; }
        public Telerik.Reporting.TextBox PaymentsTableAmountLabel { get => paymentsTableAmountLabel; }
        public Telerik.Reporting.TextBox PaymentsTableAmountTextBox { get => paymentsTableAmountTextBox; }
        public Telerik.Reporting.TextBox PaymentsTableBalanceLabel { get => paymentsTableRestToPayLabel; }
        public Telerik.Reporting.TextBox PaymentsTableBalanceTextBox { get => paymentsTableRestToPayTextBox; }
        public Telerik.Reporting.TextBox NoteTextBox { get => noteTextBox; }
        public Telerik.Reporting.TextBox SignatureDoneByLabel { get => signatureDoneByLabel; }
        public Telerik.Reporting.TextBox SignatureSchoolLabel { get => signatureSchoolLabel; }
        public Telerik.Reporting.TextBox SchoolWebSiteTexTBox { get => webSiteTextBox; }
        public Telerik.Reporting.TextBox SchoolAdressTextBox { get => adressTextBox; }
        public Telerik.Reporting.TextBox SchoolWebSiteTextBox { get => webSiteTextBox; }
        public Telerik.Reporting.TextBox SchoolPhoneTextBox { get => phoneTextBox; }
        public Telerik.Reporting.TextBox PrintDateTexBox { get => printDateTextBox; }

        public Telerik.Reporting.PictureBox SchoolLogoCopyPictureBox { get => logo2PictureBox; }
        public Telerik.Reporting.TextBox SchoolNameCopyTextBox { get => schoolName2TextBox; }
        public Telerik.Reporting.TextBox ReceiptNumberCopyLabel { get => reference2Label; }
        public Telerik.Reporting.TextBox ReceiptNumberCopyTextBox { get => paymentId2TextBox; }
        public Telerik.Reporting.TextBox PaymentDateCopyLabel { get => paymentDate2Label; }
        public Telerik.Reporting.TextBox PaymentDateCopyTextBox { get => paymentDate2TextBox; }
        public Telerik.Reporting.TextBox StudentCopyLabelFR { get => student2LabelFR; }
        public Telerik.Reporting.TextBox StudentCopyLabelEN { get => student2LabelEN; }
        public Telerik.Reporting.TextBox StudentCopyTextBox { get => student2TextBox; }
        public Telerik.Reporting.TextBox StudentIdNumberCopyLabel { get => studentId2Label; }
        public Telerik.Reporting.TextBox StudentIdNumberCopyTextBox { get => studentId2TextBox; }
        public Telerik.Reporting.TextBox StudentClassCopyLabelEN { get => studentClass2LabelEN; }
        public Telerik.Reporting.TextBox StudentClassCopyLabelFR { get => studentClass2LabelFR; }
        public Telerik.Reporting.TextBox StudentClassCopyTextBox { get => studentClass2TextBox; }
        public Telerik.Reporting.TextBox SchoolYearCopyLabelFR { get => schoolYear2LabelFR; }
        public Telerik.Reporting.TextBox SchoolYearCopyLabelEN { get => schoolYear2LabelEN; }
        public Telerik.Reporting.TextBox SchoolYearCopyTextBox { get => schoolYear2TextBox; }
        public Telerik.Reporting.TextBox PaymentAmountCopyLabelEN { get => paymentAmount2LabelEN; }
        public Telerik.Reporting.TextBox PaymentAmountCopyLabelFR { get => paymentAmount2LabelFR; }
        public Telerik.Reporting.TextBox PaymentAmountCopyTextBox { get => paymentAmount2TextBox; }
        public Telerik.Reporting.TextBox PaymentAmountLeterCopyTextBox { get => paymentAmountLeter2TextBox; }
        public Telerik.Reporting.TextBox PaymentReasonCopyLabelFR { get => paymentCostType2LabelFR; }
        public Telerik.Reporting.TextBox PaymentReasonCopyLabelEN { get => paymentCostType2LabelEN; }
        public Telerik.Reporting.TextBox PaymentReasonCopyTextBox { get => paymentCostType2TextBox; }
        public Telerik.Reporting.TextBox PaymentBalanceCopyLabelEN { get => restToPay2LabelEN; }
        public Telerik.Reporting.TextBox PaymentBalanceCopyLabelFR { get => restToPay2LabelFR; }
        public Telerik.Reporting.TextBox PaymentBalanceCopyTextBox { get => restToPay2TextBox; }
        public Telerik.Reporting.TextBox PaymentMeanCopyLabelFR { get => paymentPlace2LabelFR; }
        public Telerik.Reporting.TextBox PaymentMeanCopyLabelEN { get => paymentPlace2LabelEN; }
        public Telerik.Reporting.TextBox PaymentMeanCopyTextBox { get => paymentPlace2TextBox; }
        public Telerik.Reporting.TextBox TransactionCopyLabelEN { get => transaction2LabelEN; }
        public Telerik.Reporting.TextBox TransactionCopyLabelFR { get => transaction2LabelFR; }
        public Telerik.Reporting.TextBox TransactionIdCopyTextBox { get => transaction2TextBox; }
        public Telerik.Reporting.Table PaymentsCopyTable { get => payment2Table; }
        public Telerik.Reporting.TextBox PaymentsTableReasonCopyLabel { get => paymentsTableReason2Label; }
        public Telerik.Reporting.TextBox PaymentsTableReasonCopyTextBox { get => paymentsTableReason2TextBox; }
        public Telerik.Reporting.TextBox PaymentsTableAmountCopyLabel { get => paymentsTableAmount2Label; }
        public Telerik.Reporting.TextBox PaymentsTableAmountCopyTextBox { get => paymentsTableAmount2TextBox; }
        public Telerik.Reporting.TextBox PaymentsTableBalanceCopyLabel { get => paymentsTableRestToPay2Label; }
        public Telerik.Reporting.TextBox PaymentsTableBalanceCopyTextBox { get => paymentsTableRestToPay2TextBox; }
        public Telerik.Reporting.TextBox NoteCopyTextBox { get => note2TextBox; }
        public Telerik.Reporting.TextBox SignatureDoneByCopyLabel { get => signatureDoneBy2Label; }
        public Telerik.Reporting.TextBox SignatureSchoolCopyLabel { get => signatureSchool2Label; }
        public Telerik.Reporting.TextBox SchoolWebSiteCopyTexTBox { get => webSite2TextBox; }
        public Telerik.Reporting.TextBox SchoolAdressCopyTextBox { get => adress2TextBox; }
        public Telerik.Reporting.TextBox SchoolWebSiteCopyTextBox { get => webSite2TextBox; }
        public Telerik.Reporting.TextBox SchoolPhoneCopyTextBox { get => phone2TextBox; }
        public Telerik.Reporting.TextBox PrintDateCopyTexBox { get => printDate2TextBox; }

        #endregion
        public PaymentDoubleReceiptA4SecondModelReport()
        {
            InitializeComponent();
        }
    }
}
