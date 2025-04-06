
using Telerik.Reporting;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class GardenThreeNoteSubReport:SchoolManagement.UI.Reporting.GardenThreeNoteSubReport
    {
        public GardenThreeNoteSubReport(TermReportCard reportCard)
        {
            this.Filters.Clear();
            this.Filters.Add(new Filter("=Fields.SubjectGroup.Id", FilterOperator.Equal, "= Parameters.GroupID.Value"));
            FirstNoteTextBox.Value = "=FirstNoteAsString";
            SecondNoteTextBox.Value = "=SecondNoteAsString";
            ThirdNoteTextBox.Value = "=ThirdNoteAsString";
            FinalNoteTextBox.Value = "=FinalNoteAsString";
            RatingTextBox.Value = "=Rating";
            SubjectTextBox.Value = reportCard.HeadSection.Language == "FR" ? "=Subject.FrenchName" : "=Subject.EnglishName";
            DataSource = reportCard.DetailSection.NoteList;
        }
    }
}
