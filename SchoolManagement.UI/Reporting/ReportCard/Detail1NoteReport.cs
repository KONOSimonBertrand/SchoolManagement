using Telerik.Reporting;

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for Detail1NoteReport.
    /// </summary>
    public partial class Detail1NoteReport : Report
    {
        public Telerik.Reporting.TextBox FinalNoteTextBox { get => noteTextBox; } 
        public Telerik.Reporting.TextBox RatingTextBox { get => ratingTextBox; }
        public Telerik.Reporting.TextBox SubjectTextBox {  get => subjectTextBox; }
        public Telerik.Reporting.TextBox NoteMaxTextBox { get=>notedOnTextBox; }
        public Telerik.Reporting.TextBox PositionTextBox { get => positionTextBox; }
        public Detail1NoteReport()
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