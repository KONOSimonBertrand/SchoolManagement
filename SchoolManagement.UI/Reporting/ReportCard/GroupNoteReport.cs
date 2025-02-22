

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for GroupNoteReport.
    /// </summary>
    public partial class GroupNoteReport : Telerik.Reporting.Report
    {
        public Telerik.Reporting.PictureBox HeaderPictureBox { get => headerPictureBox; }
        public Telerik.Reporting.TextBox ReportTitleTextBox { get => reportTitleTextBox; }
        public Telerik.Reporting.TextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public Telerik.Reporting.TextBox GroupTextBox { get => groupTextBox; }
        public Telerik.Reporting.Table ReportTable { get => reportTable; }
        public Telerik.Reporting.TextBox DeanStudiesTextBox { get => deanStudiesTextBox; }
        public GroupNoteReport()
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