using Telerik.Reporting;

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for Detail1NoteReport.
    /// </summary>
    public partial class Subreport3NoteReport : Report
    {
        public Telerik.Reporting.TextBox NotedOnTextBox { get => noteMaxTextBox; }
        public Telerik.Reporting.TextBox FirstNoteTextBox { get => firstNoteTextBox; }
        public Telerik.Reporting.TextBox SecondNoteTextBox { get => secondNoteTextBox; }
        public Telerik.Reporting.TextBox ThirdNoteTextBox { get => thirdNoteTextBox; }
        public Telerik.Reporting.TextBox FinalNoteTextBox { get => finalNoteTextBox; } 
        public Telerik.Reporting.TextBox RatingTextBox { get => ratingTextBox; }
        public Telerik.Reporting.TextBox SubjectTextBox {  get => subjectTextBox; }
      
        public Telerik.Reporting.TextBox PositionTextBox { get => positionTextBox; }
        public Subreport3NoteReport()
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