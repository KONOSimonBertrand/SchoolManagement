

using System;
using System.Collections.Generic;
using Telerik.Reporting;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class Subreport1NoteReport : SchoolManagement.UI.Reporting.Subreport1NoteReport
    {
        public Subreport1NoteReport(EvaluationReportCard reportCard ) {
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
