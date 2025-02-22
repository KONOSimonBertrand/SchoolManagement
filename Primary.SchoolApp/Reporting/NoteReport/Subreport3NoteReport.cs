

using Telerik.Reporting;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class Subreport3NoteReport : SchoolManagement.UI.Reporting.Subreport3NoteReport
    {
        public Subreport3NoteReport(TermReportCard reportCard)
        {
            this.Filters.Clear();
            this.Filters.Add(new Filter("=Fields.SubjectGroup.Id", FilterOperator.Equal, "= Parameters.GroupID.Value"));
            FirstNoteTextBox.Value = "=FirstNoteAsString";
            SecondNoteTextBox.Value = "=SecondNoteAsString";
            ThirdNoteTextBox.Value = "=ThirdNoteAsString";
            FinalNoteTextBox.Value = "=FinalNoteAsString";
            NotedOnTextBox.Value = "=NotedOn";
            RatingTextBox.Value = "=Rating";
            PositionTextBox.Value = "=Position";
            SubjectTextBox.Value = reportCard.HeadSection.Language == "FR" ? "=Subject.FrenchName" : "=Subject.EnglishName";
            DataSource = reportCard.DetailSection.NoteList;
        }
    }
}
