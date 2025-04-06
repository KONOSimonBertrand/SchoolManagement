

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for GardenSubReportOneNote.
    /// </summary>
    public partial class GardenOneNoteSubReport : Telerik.Reporting.Report
    {

      
        public Telerik.Reporting.TextBox FinalNoteTextBox { get => noteTextBox; }
        public Telerik.Reporting.TextBox RatingTextBox { get => ratingTextBox; }
        public Telerik.Reporting.TextBox SubjectTextBox { get => subjectTextBox; }
        public GardenOneNoteSubReport()
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