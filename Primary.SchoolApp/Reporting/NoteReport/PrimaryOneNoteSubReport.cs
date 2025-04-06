
using Telerik.Reporting;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class PrimaryOneNoteSubReport : SchoolManagement.UI.Reporting.PrimayOneNoteSubreport
    {
        public PrimaryOneNoteSubReport(EvaluationReportCard reportCard ) {
            this.Filters.Clear();
            this.Filters.Add(new Filter("=Fields.SubjectGroup.Id", FilterOperator.Equal, "= Parameters.GroupID.Value"));
            FinalNoteTextBox.Value = "=NoteAsString";
            NoteMaxTextBox.Value = "=NotedOn";
            RatingTextBox.Value = "=Rating";
            PositionTextBox.Value = "=Position";
            SubjectTextBox.Value = reportCard.HeadSection.Language == "FR"?"=Subject.FrenchName": "=Subject.EnglishName";
            DataSource = reportCard.DetailSection.NoteList;
        }
    }
}
