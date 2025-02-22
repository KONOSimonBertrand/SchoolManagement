

namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for PrimaryEvaluationReport.
    /// </summary>
    public partial class TermPrimaryReportCardReport : Telerik.Reporting.Report
    {
        public Telerik.Reporting.PictureBox HeaderPictureBox { get => headerPictureBox; }
        public Telerik.Reporting.TextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public Telerik.Reporting.TextBox RePortTitleTextBox { get => reportTitleTextBox; }
        public Telerik.Reporting.TextBox StudentLabel { get => studentLabel; }
        public Telerik.Reporting.TextBox StudentTextBox { get => studentTextBox; }
        public Telerik.Reporting.TextBox StudentIdLabel { get => studentIdLabel; }
        public Telerik.Reporting.TextBox StudentIdTextBox { get => studentIdTextBox; }
        public Telerik.Reporting.TextBox BornTextBox { get => bornTextBox; }
        public Telerik.Reporting.TextBox TeacherLabel { get => teacherLabel; }
        public Telerik.Reporting.TextBox TeacherTexBox { get => teacherTextBox; }
        public Telerik.Reporting.TextBox ClassLabel { get => classLabel; }
        public Telerik.Reporting.TextBox ClassTextBox { get => classTextBox; }
        public Telerik.Reporting.TextBox SubjectLabel { get => subjectLabel; }
        public Telerik.Reporting.TextBox NotedOnLabel { get => notedOnLabel; }
        public Telerik.Reporting.TextBox FirstNoteLabel { get => firstNoteLabel; }
        public Telerik.Reporting.TextBox SecondNoteLabel { get => secondNoteLabel; }
        public Telerik.Reporting.TextBox ThirdNoteLabel { get => thirdNoteLabel; }
        public Telerik.Reporting.TextBox FinalNoteLabel { get => finalNoteLabel; }
        public Telerik.Reporting.TextBox CotationLabel { get => cotationLabel; }
        public Telerik.Reporting.TextBox ObservationLabel { get => observationLabel; }
        public Telerik.Reporting.TextBox SubjectGroupTextBox { get => subjectGroupTextBox; }
        public Telerik.Reporting.SubReport NotesSubReport { get => notesSubReport; }
        public Telerik.Reporting.TextBox TotalLabel { get => totalLabel; }
        public Telerik.Reporting.TextBox TotalNotedOnTextBox { get => totalNotedOnTextBox; }
        public Telerik.Reporting.TextBox TotalFirstNoteTextBox { get => totalFirstNoteTextBox; }
        public Telerik.Reporting.TextBox TotalSecondNoteTextBox { get => totalSecondNoteTextBox; }
        public Telerik.Reporting.TextBox TotalThirdNoteTextBox { get => totalThirdNoteTextBox; }
        public Telerik.Reporting.TextBox AverageLabel { get => averageLabel; }
        public Telerik.Reporting.TextBox AverageFirstMonthTextBox { get => averageFirstMonthTextBox; }
        public Telerik.Reporting.TextBox AverageSecondMonthTextBox { get => averageSecondMonthTextBox; }
        public Telerik.Reporting.TextBox AverageThirdMonthTextBox { get => averageThirdMonthTextBox; }
        public Telerik.Reporting.TextBox AverageTermTextBox { get => averageTermTextBox; }
        public Telerik.Reporting.TextBox PositionLabel {  get => rankLabel; }
        public Telerik.Reporting.TextBox PositionFirstMonthTextBox { get => positionFirstMonthTextBox; }
        public Telerik.Reporting.TextBox PositionSecondMonthTextBox { get => positionSecondMonthTextBox; }
        public Telerik.Reporting.TextBox PositionThirdMonthTextBox { get => positionThirdMonthTextBox; }
        public Telerik.Reporting.TextBox PositionTermTextBox { get => positionTermTextBox; }
        public Telerik.Reporting.TextBox GeneralAverageLabel { get => generalAverageLabel; }
        public Telerik.Reporting.TextBox GeneralAverageFirstMonthTextBox { get => generalAverageFirstMonthTextBox; }
        public Telerik.Reporting.TextBox GeneralAverageSecondMonthTextBox { get => generalAverageSecondMonthTextBox; }
        public Telerik.Reporting.TextBox GeneralAverageThirdMonthTextBox { get => generalAverageThirdMonthTextBox; }
        public Telerik.Reporting.TextBox GeneralAverageTermTextBox { get => generalAverageTermTextBox; }
        public Telerik.Reporting.TextBox HighestAverageLabel { get => highestAverageLabel; }
        public Telerik.Reporting.TextBox HighestAverageFirstMonthTextBox { get => bestAverageFirstMonthTextBox; }
        public Telerik.Reporting.TextBox HighestAverageSecondMonthTextBox { get => bestAverageSecondMonthTextBox; }
        public Telerik.Reporting.TextBox HighestAverageThirdMonthTextBox { get => bestAverageThirdMonthTextBox; }
        public Telerik.Reporting.TextBox HighestAverageTermTextBox { get => bestAverageTermTextBox; }
        public Telerik.Reporting.TextBox LowestAverageLabel {  get => lowestAverageLabel; }
        public Telerik.Reporting.TextBox LowestAverageFirstMonthTextBox { get => lowestAverageFirstMonthTextBox; }
        public Telerik.Reporting.TextBox LowestAverageSecondMonthTextBox { get => lowestAverageSecondMonthTextBox; }
        public Telerik.Reporting.TextBox LowestAverageThirdMonthTextBox { get => lowestAverageThirdMonthTextBox; }
        public Telerik.Reporting.TextBox LowestAverageTermTextBox { get => lowestAverageTermTextBox; }
        public Telerik.Reporting.TextBox DecisionTextBox { get => decisionTextBox; }
        public Telerik.Reporting.TextBox ExplanationCompetenceLabel {  get => explanationCompetenceLabel; }
        public Telerik.Reporting.TextBox ExpertCompetenceLabel { get => expertCompetenceLabel; }
        public Telerik.Reporting.TextBox AcquiredCompetenceLabel { get=>acquiredCompetenceLabel;}
        public Telerik.Reporting.TextBox EcaCompetenceLabel{ get => ecaCompetenceLabel;}
        public Telerik.Reporting.TextBox NaCompetenceLabel { get=>naCompetenceLabel;}
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
        public TermPrimaryReportCardReport()
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