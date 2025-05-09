

using Telerik.Reporting;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class FoundationOneNoteSubReport:SchoolManagement.UI.Reporting.FoundationOneNoteSubReport
    {
        public FoundationOneNoteSubReport(EvaluationReportCard reportCard)
        {
            this.Filters.Clear();
            this.Filters.Add(new Filter("=Fields.SubjectGroup.Id", FilterOperator.Equal, "= Parameters.GroupID.Value"));
            RatingTextBox.Value = "=Rating";
            SubjectTextBox.Value = reportCard.HeadSection.Language == "FR" ? "=Subject.FrenchName" : "=Subject.EnglishName";
            DataSource = reportCard.DetailSection.NoteList;
        }
        public FoundationOneNoteSubReport(TermReportCard reportCard)
        {
            this.Filters.Clear();
            this.Filters.Add(new Filter("=Fields.SubjectGroup.Id", FilterOperator.Equal, "= Parameters.GroupID.Value"));
            RatingTextBox.Value = "=Rating";
            SubjectTextBox.Value = reportCard.HeadSection.Language == "FR" ? "=Subject.FrenchName" : "=Subject.EnglishName";
            DataSource = reportCard.DetailSection.NoteList;
        }
    }
}
