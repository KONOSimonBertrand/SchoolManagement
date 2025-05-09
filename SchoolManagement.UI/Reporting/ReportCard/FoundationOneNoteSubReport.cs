
namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for FoundationOneNoteSubReport.
    /// </summary>
    public partial class FoundationOneNoteSubReport : Telerik.Reporting.Report
    {
        public Telerik.Reporting.TextBox RatingTextBox { get => ratingTextBox; }
        public Telerik.Reporting.TextBox SubjectTextBox { get => subjectTextBox; }
        public FoundationOneNoteSubReport()
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