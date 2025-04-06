

using Telerik.Reporting;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class GardenOneNoteSubReport:SchoolManagement.UI.Reporting.GardenOneNoteSubReport
    {
        public GardenOneNoteSubReport(EvaluationReportCard reportCard)
        {
            this.Filters.Clear();
            this.Filters.Add(new Filter("=Fields.SubjectGroup.Id", FilterOperator.Equal, "= Parameters.GroupID.Value"));
            FinalNoteTextBox.Value = "=NoteWithMax";
            RatingTextBox.Value = "=Rating";
            SubjectTextBox.Value = reportCard.HeadSection.Language == "FR" ? "=Subject.FrenchName" : "=Subject.EnglishName";
            DataSource = reportCard.DetailSection.NoteList;
        }
    }
}
