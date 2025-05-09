

using Telerik.WinControls.UI;

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for FoundationEvaluationReport.
    /// </summary>
    public partial class FoundationEvaluationReport : Telerik.Reporting.Report
    {
        public Telerik.Reporting.PictureBox HeaderPictureBox { get => headerPictureBox; }
        public Telerik.Reporting.TextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public Telerik.Reporting.TextBox ReportTitleTextBox { get => reportTitleTextBox; }
        public Telerik.Reporting.TextBox StudentLabel { get => studentLabel; }
        public Telerik.Reporting.TextBox StudentTextBox { get => studentTextBox; }
        public Telerik.Reporting.TextBox StudentIdLabel { get => studentIdLabel; }
        public Telerik.Reporting.TextBox StudentIdTextBox { get => studentIdTextBox; }
        public Telerik.Reporting.TextBox BornTextBox { get => bornTextBox; }
        public Telerik.Reporting.TextBox TeacherLabel { get => teacherLabel; }
        public Telerik.Reporting.TextBox TeacherTexBox { get => teacherTextBox; }
        public Telerik.Reporting.TextBox ClassTextBox { get => classTextBox; }
        public Telerik.Reporting.TextBox SubjectLabel { get => subjectLabel; }
        public Telerik.Reporting.TextBox ObservationLabel { get => observationLabel; }
        public Telerik.Reporting.TextBox SubjectGroupTextBox { get => subjectGroupTextBox; }
        public Telerik.Reporting.SubReport NotesSubReport { get => notesSubReport; }
        
      
        public Telerik.Reporting.TextBox TeacherCommentLabel { get => teacherCommentLabel; }
        public Telerik.Reporting.TextBox TeacherCommentTextBox { get => teacherCommentTextBox; }
        public Telerik.Reporting.TextBox TotalDayAttendanceLabel { get => totalDayAttendanceLabel; }
        public Telerik.Reporting.TextBox TotalDayAttendanceTextBox { get => totalDayAttendanceTextBox; }
        public Telerik.Reporting.TextBox TotalAbsentLabel { get => totalAbsentLabel; }
        public Telerik.Reporting.TextBox TotalAbsentTextBox { get => totalAbsentTextBox; }
        public Telerik.Reporting.TextBox TotalLateLabel { get => totalLateLabel; }
        public Telerik.Reporting.TextBox TotalLateTextBox { get => totalLateTextBox; }
        public Telerik.Reporting.TextBox TotalLeftEarlyLabel { get => totalLeftEarlyLabel; }
        public Telerik.Reporting.TextBox TotalLeftEarlyTextBox { get => totalLeftEarlyTextBox; }
        public Telerik.Reporting.TextBox ExplanationCompetenceLabel { get => explanationCompetenceLabel; }
        public Telerik.Reporting.TextBox ExpertCompetenceLabel { get => expertCompetenceLabel; }
        public Telerik.Reporting.TextBox ExpertCompetenceDescriptionLabel { get => expertCompetenceDescriptionLabel; }
        public Telerik.Reporting.TextBox AcquiredCompetenceLabel { get => acquiredCompetenceLabel; }
        public Telerik.Reporting.TextBox AcquiredCompetenceDescriptionLabel { get => acquiredCompetenceDescriptionLabel; }
        public Telerik.Reporting.TextBox EcaCompetenceLabel { get => ecaCompetenceLabel; }
        public Telerik.Reporting.TextBox EcaCompetenceDescriptionLabel { get => ecaCompetenceDescriptionLabel; }
        public Telerik.Reporting.TextBox NaCompetenceLabel { get => naCompetenceLabel; }
        public Telerik.Reporting.TextBox NaCompetenceDescriptionLabel { get => naCompetenceDescriptionLabel; }
        public Telerik.Reporting.TextBox ParentSignatureLabel { get => parentSignatureLabel; }
        public Telerik.Reporting.TextBox TeacherSignatureLabel { get => teacherSignatureLabel; }
        public Telerik.Reporting.TextBox DeanSignatureLabel { get => deanSignatureLabel; }
        public Telerik.Reporting.TextBox DirectorSignatureLabel { get => directorSignatureLabel; }
        public Telerik.Reporting.TextBox AddressTextBox { get => addressTextBox; }
        public Telerik.Reporting.TextBox ContactTextBox { get => contactTextBox; }
        public Telerik.Reporting.TextBox WebSiteTextBox { get => webSiteTextBox; }
        public Telerik.Reporting.TextBox SchoolStatement { get => schoolStatement; }
        public Telerik.Reporting.TextBox FacebookAddressLabel { get => facebookAddressLabel; }
        public Telerik.Reporting.PictureBox WebSitePictureBox { get => webSitePictureBox; }
        public Telerik.Reporting.PictureBox FaceBookPictureBox { get => facebookPictureBox; }
        public FoundationEvaluationReport()
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