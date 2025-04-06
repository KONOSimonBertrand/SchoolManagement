

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for GardenSubReportThreeNote.
    /// </summary>
    public partial class GardenThreeNoteSubReport : Telerik.Reporting.Report
    {
        public Telerik.Reporting.TextBox FirstNoteTextBox { get => firstNoteTextBox; }
        public Telerik.Reporting.TextBox SecondNoteTextBox { get => secondNoteTextBox; }
        public Telerik.Reporting.TextBox ThirdNoteTextBox { get => thirdNoteTextBox; }
        public Telerik.Reporting.TextBox FinalNoteTextBox { get => finalNoteTextBox; }
        public Telerik.Reporting.TextBox RatingTextBox { get => ratingTextBox; }
        public Telerik.Reporting.TextBox SubjectTextBox { get => subjectTextBox; }

        public GardenThreeNoteSubReport()
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