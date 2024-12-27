

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for BadgeReport.
    /// </summary>
    public partial class BadgeReport : Telerik.Reporting.Report
    {
        public Telerik.Reporting.PictureBox BadgePictureBox { get => badgePictureBox; }
        public Telerik.Reporting.PictureBox StudentPictureBox { get => studentPictureBox; }
        public Telerik.Reporting.PictureBox LogoPictureBox { get => logoPictureBox; }
        public Telerik.Reporting.PictureBox SignaturePictureBox { get => signaturePictureBox; }
        public Telerik.Reporting.TextBox StudentLastNameTextBox { get => studentLastNameTextBox; }  
        public Telerik.Reporting.TextBox StudentFirstNameTextBox { get => studentFirstNameTextBox; }
        public Telerik.Reporting.TextBox StudentBirthDayTextBox { get => studentBirthDayTexBox; }
        public Telerik.Reporting.TextBox StudentBirthDayFRLabel { get => studentBirthDayFRLabel; }
        public Telerik.Reporting.TextBox StudentBirthDayENLabel { get => studentBirthDayENLabel; }
        public Telerik.Reporting.TextBox StudentMatriculeLabel { get => studentMatriculeLabel; }
        public Telerik.Reporting.TextBox StudentMatriculeTextBox { get => studentMatriculeTextBox; }
        public Telerik.Reporting.TextBox StudentClassFRLabel { get => studentClassFRLabel; }
        public Telerik.Reporting.TextBox StudentClassENLabel { get => studentClassENLabel; }
        public Telerik.Reporting.TextBox StudentClassTextBox { get => studentClassTextBox; }
        public Telerik.Reporting.TextBox SchoolNameTextBox { get => schoolNameTextBox; }
        public Telerik.Reporting.Barcode IdCardBarcode {  get => idCardBarcode; }
        public Telerik.Reporting.TextBox ExpirationDateTextBox { get => expirationDateTextBox; }
        public Telerik.Reporting.TextBox StudentPhoneTextBox { get => studentPhoneTextBox; }
        public Telerik.Reporting.TextBox SchoolContactTextBox { get => schoolContactTextBox; }
        public BadgeReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}