
namespace SchoolManagement.UI.Reporting
{
    /// <summary>
    /// Summary description for ClassReport.
    /// </summary>
    public partial class ClassNoteReport : Telerik.Reporting.Report
    {
        public Telerik.Reporting.PictureBox HeaderPictureBox { get => headerPictureBox; }
        public Telerik.Reporting.TextBox ReportTitleTextBox { get => reportTitleTextBox; }
        public Telerik.Reporting.TextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public Telerik.Reporting.TextBox RoomTextBox { get => roomTextBox; }
        public Telerik.Reporting.TextBox ClassroomSizeTextBox { get => classroomSizeTextBox; }
        public Telerik.Reporting.TextBox TotalCoefTextBox { get => totalCoefTextBox; }
        public Telerik.Reporting.TextBox StudentLabel {  get => studentLabel; }
        public Telerik.Reporting.TextBox StudentTextLabel { get=>studentTextBox; }
        public Telerik.Reporting.TextBox SexLabel { get=>sexLabel; }
        public Telerik.Reporting.TextBox SexTextBox { get=>sexTextBox; }
        public Telerik.Reporting.TextBox RatingLabel { get => ratingLabel; }
        public Telerik.Reporting.TextBox RatingTextBox { get => ratingTextBox; }
        public Telerik.Reporting.TextBox ReportTitleStatisticTextBox { get => reportTitleStatisticTextBox; }
        public Telerik.Reporting.TextBox ClassroomSizeSectionLabel { get=>classroomSizeSectionLabel; }
        public Telerik.Reporting.TextBox ClassroomSizeSectionFemalLabel { get => classroomSizeSectionFemalLabel; }
        public Telerik.Reporting.TextBox ClassroomSizeSectionFemalTextBox { get => classroomSizeSectionFemalTextBox; }
        public Telerik.Reporting.TextBox ClassroomSizeSectionMalLabel {  get => classroomSizeSectionMalLabel; }
        public Telerik.Reporting.TextBox ClassroomSizeSectionMalTextBox {  get => classroomSizeSectionMalTextBox; }
        public Telerik.Reporting.TextBox OnRllSectionTotalLabel {  get => classroomSizeSectionTotalLabel; }
        public Telerik.Reporting.TextBox ClassroomSizeSectionTotalTextBox {  get => classroomSizeSectionTotalTextBox; }
        public Telerik.Reporting.TextBox ClassroomSizeSectionDescriptionTextBox { get => classroomSizeSectionDescriptionTextBox; }
        public Telerik.Reporting.TextBox PresentSectionLabel { get => presentSectionLabel; }
        public Telerik.Reporting.TextBox PresentSectionFemalLabel { get => presentSectionFemalLabel; }
        public Telerik.Reporting.TextBox PresentSectionFemalTextBox { get => presentSectionFemalTextBox; }
        public Telerik.Reporting.TextBox PresentSectionMalLabel { get => presentSectionMalLabel; }
        public Telerik.Reporting.TextBox PresentSectionMalTextBox { get => presentSectionMalTextBox; }
        public Telerik.Reporting.TextBox PresentSectionTotalLabel { get => presentSectionTotalLabel; }
        public Telerik.Reporting.TextBox PresentSectionTotalTextBox { get => presentSectionTotalTextBox; }
        public Telerik.Reporting.TextBox GeneralAverageTextBox { get => generalAverageTextBox; }
        public Telerik.Reporting.TextBox AverageSectionLabel { get => averageSectionLabel; }
        public Telerik.Reporting.TextBox AverageSectionFemalLabel { get => averageSectionFemalLabel; }
        public Telerik.Reporting.TextBox AverageSectionFemalTextBox { get => averageSectionFemalTextBox; }
        public Telerik.Reporting.TextBox AverageSectionMalLabel { get => averageSectionMalLabel; }
        public Telerik.Reporting.TextBox AverageSectionMalTextBox { get => averageSectionMalTextBox; }
        public Telerik.Reporting.TextBox AverageSectionTotalLabel { get => averageSectionTotalLabel; }
        public Telerik.Reporting.TextBox AverageSectionTotalTextBox { get => averageSectionTotalTextBox; }
        public Telerik.Reporting.TextBox LowestAverageTextBox { get => lowestAverageTextBox; }
        public Telerik.Reporting.TextBox PassedSectionLabel { get => passedSectionLabel; }
        public Telerik.Reporting.TextBox PassedSectionFemalLabel { get => passedSectionFemalLabel; }
        public Telerik.Reporting.TextBox PassedSectionFemalTextBox { get => passedSectionFemalTextBox; }
        public Telerik.Reporting.TextBox PassedSectionMalLabel { get => passedSectionMalLabel; }
        public Telerik.Reporting.TextBox PassedSectionMalTextBox { get => passedSectionMalTextBox; }
        public Telerik.Reporting.TextBox PassedSectionTotalLabel { get => passedSectionTotalLabel; }
        public Telerik.Reporting.TextBox PassedSectionTotalTextBox { get => passedSectionTotalTextBox; }
        public Telerik.Reporting.TextBox HighestAverageTextBox { get => highestAverageTextBox; }
        public Telerik.Reporting.TextBox DeanStudiesTextBox {  get => deanStudiesTextBox; }
        public Telerik.Reporting.Table ReportTable { get => reportTable; }
        public ClassNoteReport()
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