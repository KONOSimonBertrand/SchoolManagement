

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for CashReceiptMidleReport.
    /// </summary>
    public partial class PaymentReceiptA4Report : Telerik.Reporting.Report
    {
        #region Properties
        public Telerik.Reporting.PictureBox LogoPictureBox { get => logoPictureBox; }
        public Telerik.Reporting.TextBox SchoolNameTextBox { get => schoolNameTextBox; }
        public Telerik.Reporting.TextBox PaymentIdNumberLabel { get => referenceLabel; }
        public Telerik.Reporting.TextBox PaymentIdNumberTextBox { get => paymentIdTextBox; }
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
        public Telerik.Reporting.Table PaymentsTable { get => paymentTable; }
        public Telerik.Reporting.TextBox PaymentsTableReasonLabel { get => paymentsTableReasonLabel; }
        public Telerik.Reporting.TextBox PaymentsTableReasonTextBox { get => paymentsTableReasonTextBox; }
        public Telerik.Reporting.TextBox PaymentsTableAmountLabel { get => paymentsTableAmountLabel; }
        public Telerik.Reporting.TextBox PaymentsTableAmountTextBox { get => paymentsTableAmountTextBox; }
        public Telerik.Reporting.TextBox PaymentsTablePaymentPlaceLabel { get => paymentsTablePaymentPlaceLabel; }
        public Telerik.Reporting.TextBox PaymentsTablePaymentPlaceTextBox { get => paymentsTablePaymentPlaceTextBox; }
        public Telerik.Reporting.TextBox PaymentsTableBalanceLabel { get => paymentsTableRestToPayLabel; }
        public Telerik.Reporting.TextBox PaymentsTableBalanceTextBox { get => paymentsTableRestToPayTextBox; }
        public Telerik.Reporting.TextBox NoteTextBox { get => noteTextBox; }
        public Telerik.Reporting.TextBox SignatureDoneByLabel { get => signatureDoneByLabel; }
        public Telerik.Reporting.TextBox SignatureSchoolLabel { get => signatureSchoolLabel; }
        public Telerik.Reporting.TextBox WebSiteTexTBox { get => webSiteTextBox; }
        public Telerik.Reporting.TextBox AdressTextBox { get => adressTextBox; }
        public Telerik.Reporting.TextBox WebSiteTextBox { get => webSiteTextBox; }
        public Telerik.Reporting.TextBox PhoneTextBox { get => phoneTextBox; }
        public Telerik.Reporting.TextBox PrintDateTexBox { get => printDateTextBox; }
        public Telerik.Reporting.TextBox CopyLabel { get => copyLabel; }
        public Telerik.Reporting.TextBox PrintDateTextBox { get => printDateTextBox; }
        public Telerik.Reporting.Panel FirstCopyPanel {  get => firstCopyPanel; }
        public Telerik.Reporting.Panel SignatureDoneByPanel { get => signatureDoneByPanel; }
        public Telerik.Reporting.Panel SignatureSchoolPanel { get => signatureSchoolPanel; }
        public Telerik.Reporting.PictureBox Logo2PictureBox { get => logo2PictureBox; }
        public Telerik.Reporting.TextBox SchoolName2TextBox { get => schoolName2TextBox; }
        public Telerik.Reporting.TextBox PaymentIdNumber2Label { get => reference2Label; }
        public Telerik.Reporting.TextBox PaymentIdNumber2TextBox { get => paymentId2TextBox; }
        public Telerik.Reporting.TextBox PaymentDate2Label { get => paymentDate2Label; }
        public Telerik.Reporting.TextBox PaymentDate2TextBox { get => paymentDate2TextBox; }
        public Telerik.Reporting.TextBox Student2LabelFR { get => student2LabelFR; }
        public Telerik.Reporting.TextBox Student2LabelEN { get => student2LabelEN; }
        public Telerik.Reporting.TextBox Student2TextBox { get => student2TextBox; }
        public Telerik.Reporting.TextBox StudentIdNumber2Label { get => studentId2Label; }
        public Telerik.Reporting.TextBox StudentIdNumber2TextBox { get => studentId2TextBox; }
        public Telerik.Reporting.TextBox StudentClass2LabelEN { get => studentClass2LabelEN; }
        public Telerik.Reporting.TextBox StudentClass2LabelFR { get => studentClass2LabelFR; }
        public Telerik.Reporting.TextBox StudentClass2TextBox { get => studentClass2TextBox; }
        public Telerik.Reporting.TextBox SchoolYear2LabelFR { get => schoolYear2LabelFR; }
        public Telerik.Reporting.TextBox SchoolYear2LabelEN { get => schoolYear2LabelEN; }
        public Telerik.Reporting.TextBox SchoolYear2TextBox { get => schoolYear2TextBox; }
        public Telerik.Reporting.TextBox PaymentAmount2LabelEN { get => paymentAmount2LabelEN; }
        public Telerik.Reporting.TextBox PaymentAmount2LabelFR { get => paymentAmount2LabelFR; }
        public Telerik.Reporting.TextBox PaymentAmount2TextBox { get => paymentAmount2TextBox; }
        public Telerik.Reporting.TextBox PaymentAmountLeter2TextBox { get => paymentAmountLeter2TextBox; }
        public Telerik.Reporting.TextBox PaymentReason2LabelFR { get => paymentCostType2LabelFR; }
        public Telerik.Reporting.TextBox PaymentReason2LabelEN { get => paymentCostType2LabelEN; }
        public Telerik.Reporting.TextBox PaymentReason2TextBox { get => paymentCostType2TextBox; }
        public Telerik.Reporting.TextBox PaymentBalance2LabelEN { get => restToPay2LabelEN; }
        public Telerik.Reporting.TextBox PaymentBalance2LabelFR { get => restToPay2LabelFR; }
        public Telerik.Reporting.TextBox PaymentBalance2TextBox { get => restToPay2TextBox; }
        public Telerik.Reporting.TextBox PaymentMean2LabelFR { get => paymentPlace2LabelFR; }
        public Telerik.Reporting.TextBox PaymentMean2LabelEN { get => paymentPlace2LabelEN; }
        public Telerik.Reporting.TextBox PaymentMean2TextBox { get => paymentPlace2TextBox; }
        public Telerik.Reporting.Table Payments2Table { get => payment2Table; }
        public Telerik.Reporting.TextBox PaymentsTableReason2Label { get => paymentsTableReason2Label; }
        public Telerik.Reporting.TextBox PaymentsTableReason2TextBox { get => paymentsTableReason2TextBox; }
        public Telerik.Reporting.TextBox PaymentsTableAmount2Label { get => paymentsTableAmount2Label; }
        public Telerik.Reporting.TextBox PaymentsTableAmount2TextBox { get => paymentsTableAmount2TextBox; }
        public Telerik.Reporting.TextBox PaymentsTablePaymentPlace2Label { get => paymentsTablePaymentPlace2Label; }
        public Telerik.Reporting.TextBox PaymentsTablePaymentPlace2TextBox { get => paymentsTablePaymentPlace2TextBox; }
        public Telerik.Reporting.TextBox PaymentsTableBalance2Label { get => paymentsTableRestToPay2Label; }
        public Telerik.Reporting.TextBox PaymentsTableBalance2TextBox { get => paymentsTableRestToPay2TextBox; }
        public Telerik.Reporting.TextBox Note2TextBox { get => note2TextBox; }
        public Telerik.Reporting.TextBox SignatureDoneBy2Label { get => signatureDoneBy2Label; }
        public Telerik.Reporting.TextBox SignatureSchool2Label { get => signatureSchool2Label; }
        public Telerik.Reporting.TextBox Adress2TextBox { get => adress2TextBox; }
        public Telerik.Reporting.TextBox WebSite2TextBox { get => webSite2TextBox; }
        public Telerik.Reporting.TextBox Phone2TextBox { get => phone2TextBox; }
        public Telerik.Reporting.TextBox PrintDate2TexBox { get => printDate2TextBox; }
        public Telerik.Reporting.TextBox Copy2Label { get => copy2Label; }
        public Telerik.Reporting.TextBox PrintDate2TextBox { get => printDate2TextBox; }
        public Telerik.Reporting.Panel SecondCopyPanel { get => secondCopyPanel; }
        public Telerik.Reporting.Panel SignatureDoneBy2Panel { get => signatureDoneBy2Panel; }
        public Telerik.Reporting.Panel SignatureSchool2Panel { get => signatureSchool2Panel; }
        #endregion
        public PaymentReceiptA4Report()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            this.Name = "PaymentReceipt";
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}