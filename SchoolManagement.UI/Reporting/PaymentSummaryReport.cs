

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for PaymentRecapReport.
    /// </summary>
    public partial class PaymentSummaryReport : Telerik.Reporting.Report
    {
        public Telerik.Reporting.PictureBox HeaderPicture { get=>headerPictureBox;}
        public Telerik.Reporting.PictureBox FaceBookPicture { get => facebookPictureBox; }
        public Telerik.Reporting.TextBox PrintDateTextBox { get => printDateTextBox;}
        public Telerik.Reporting.TextBox SchoolYearTextBox { get => schoolYearTextBox;}
        public Telerik.Reporting.TextBox RePortTitleTextBox { get=>reportTitleTextBox;}
        public Telerik.Reporting.TextBox StudentLabel { get => studentLabel;}
        public Telerik.Reporting.TextBox StudentTextBox { get=>studentTexBox;}
        public Telerik.Reporting.TextBox StudentIdNumberLabel { get => studentIdLabel; }
        public Telerik.Reporting.TextBox ClassLabel { get => classLabel; }
        public Telerik.Reporting.TextBox ClassTextBox { get => classTextBox; }
        public Telerik.Reporting.TextBox StudentIdNumberTextBox { get => studentIdTextBox; }
        public Telerik.Reporting.TextBox DateLabel { get => dateLabel; }
        public Telerik.Reporting.TextBox DateTextBox { get => dateTextBox; }
        public Telerik.Reporting.TextBox AmountLabel { get => amountLabel; }
        public Telerik.Reporting.TextBox AmountTextBox { get => amountTextBox; }
        public Telerik.Reporting.TextBox ReasonLabel { get => reasonLabel; }
        public Telerik.Reporting.TextBox ReasonTextBox { get => reasonTextBox; }

        public Telerik.Reporting.TextBox PrintDateLabel { get => labelPrintDate; }
        public Telerik.Reporting.TextBox TotalTextBox { get => totalTextBox; }
        public Telerik.Reporting.TextBox TotalInLetterTextBox { get => totalInLetterTextBox; }
        public Telerik.Reporting.TextBox AddressTextBox { get => addressTextBox; }
        public Telerik.Reporting.TextBox ContactTextBox { get => contactTextBox; }
        public Telerik.Reporting.TextBox WebSiteTextBox { get => webSiteTextBox; }
        public Telerik.Reporting.TextBox SchoolStatement {  get => schoolStatement; }
        public Telerik.Reporting.TextBox SchoolNameTextBox {  get => schoolNameTextBox; }
        public PaymentSummaryReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            this.Name = "PaymentSummaryReport";
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}