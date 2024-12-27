

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for SchoolCertificateReport.
    /// </summary>
    public partial class SchoolCertificateReport : Telerik.Reporting.Report
    {
        public Telerik.Reporting.PictureBox HeaderPictureBox { get => headerPictureBox; }
        public Telerik.Reporting.TextBox ReportTitleFRTextBox { get => reportTitleFRTextBox; }
        public Telerik.Reporting.TextBox ReportTitleENTextBox { get => reportTitleENTextBox; }
        public Telerik.Reporting.TextBox HeadSchoolNameFRLabel {  get => headSchoolNameFRLabel; }
        public Telerik.Reporting.TextBox HeadSchoolNameENLabel { get => headSchoolNameENLabel; }
        public Telerik.Reporting.TextBox HeadSchoolTitleFRLabel {  get => headSchoolTitleFRLabel; }
        public Telerik.Reporting.TextBox HeadSchoolTitleENLabel { get => headSchoolTitleENLabel; }
        public Telerik.Reporting.TextBox StudentFRLabel {  get => studentFRLabel; }
        public Telerik.Reporting.TextBox StudentENLabel { get => studentENLabel; }
        public Telerik.Reporting.TextBox StudentTextBox {  get => studentTextBox; }
        public Telerik.Reporting.TextBox BornDateFRLabel {  get => bornDateFRLabel; }
        public Telerik.Reporting.TextBox BornDateENLabel { get => bornDateENLabel; }
        public Telerik.Reporting.TextBox BornDateTextBox { get => bornDateTextBox; }
        public Telerik.Reporting.TextBox BornPlaceFRLabel { get => bornPlaceFRLabel; }
        public Telerik.Reporting.TextBox BornPlaceENLabel { get => bornPlaceENLabel; }
        public Telerik.Reporting.TextBox BornPlaceTextBox { get => bornPlaceTextBox; }
        public Telerik.Reporting.TextBox FatherFRLabel {  get => fatherFRLabel; }
        public Telerik.Reporting.TextBox FatherENLabel { get => fatherENLabel; }
        public Telerik.Reporting.TextBox FatherTextBox { get => fatherTextBox; }
        public Telerik.Reporting.TextBox MotherFRLabel { get => motherFRLabel; }
        public Telerik.Reporting.TextBox MotherENLabel { get => motherENLabel; }
        public Telerik.Reporting.TextBox MotherTextBox { get => motherTextBox; }
        public Telerik.Reporting.TextBox ClassFRLabel { get => classFRLabel; }
        public Telerik.Reporting.TextBox ClassENLabel { get => classENLabel; }
        public Telerik.Reporting.TextBox ClassTextBox { get => classTextBox; }
        public Telerik.Reporting.TextBox SchoolYearFRLabel { get => schoolYearFRLabel; }
        public Telerik.Reporting.TextBox SchoolYearENLabel { get => schoolYearENLabel; }
        public Telerik.Reporting.TextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public Telerik.Reporting.TextBox StudentIdFRLabel { get => studentIdFRLabel; }
        public Telerik.Reporting.TextBox StudentIdENLabel { get => studentIdENLabel; }
        public Telerik.Reporting.TextBox StudentIdTextBox { get => studentIdTextBox; }
        public Telerik.Reporting.TextBox SignaturePlaceLabel { get => signaturePlaceLabel; }
        public Telerik.Reporting.TextBox SignatureHeadSchoolLabel { get => signatureHeadSchoolLabel; }
        public Telerik.Reporting.TextBox AllocationNumberLabel { get => allocationNumberLabel; }
        public Telerik.Reporting.TextBox AddressLabel { get => addressLabel; }
        public Telerik.Reporting.TextBox ContactLabel { get => contactLabel; }
        public Telerik.Reporting.PictureBox WebSitePictureBox { get => webSitePictureBox; }
        public Telerik.Reporting.TextBox WebSiteLabel { get => webSiteLabel; }
        public Telerik.Reporting.PictureBox FaceBookPictureBox { get => facebookPictureBox; }
        public Telerik.Reporting.TextBox FacebookAddressLabel { get => facebookAddressLabel; }
        public SchoolCertificateReport()
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