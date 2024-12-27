

using SchoolManagement.Core.Model;
using System.Collections.Generic;
using System.Data;
using Telerik.Reporting;

namespace Primary.SchoolApp.DTO
{
    public class DTOItem
    {
        public record AverageRecord(Student Student,double Average,double TotalMark,string Rating,string Position);
        public record EvaluationRecord(int Id,Student Student,Subject Subject, SubjectGroup SubjectGroup,double Note,string NoteAsString,string NoteWithMax,double NoteCoef, double NotedOn,string Rating,string Position);
        public record SubjectGroupRecord(int Id,string Name);
        public record HeadReportCard(string ReportTitle,string SchoolYear,Student Student,string ClassRoom,string Teacher,string Language);
        public record DetailReportCard(List<EvaluationRecord> NoteList,List<SubjectGroup> SubjectGroupList);
        public record FooterReportCard(double SumNote,double SumCoef,double SumMaxNote,double StudentAverage,string Position,double ClassAverage,double HighestAverage, double LowestAverage);
        public record ReportCard(HeadReportCard HeadSection, DetailReportCard DetailSection, FooterReportCard FooterSection);
        public record HeadClassroomReport(string ReportTitle, string SchoolYear, string ClassRoom,string ClassroomSize,string TotalCoef);
        public record ClassroomReportDetail(DataTable DataTable);
        public record ReportItem(string Name,string Value);
        public record ReportFooter(List<ReportItem> Items);
        public record ClassroomReportHeader(List<ReportItem> Items,List<string>Columns);
        public record ClassroomReport(ClassroomReportHeader HeaderSection, ClassroomReportDetail DetailSection, ReportFooter FooterSection);
    }
}
