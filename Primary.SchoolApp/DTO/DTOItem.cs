

using SchoolManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Primary.SchoolApp.DTO
{
    public class DTOItem
    {
        public record AverageRecord(Student Student,double Average,double TotalMark,string Rating,string Position);
        public record EvaluationRecord(int Id,Student Student,Subject Subject, SubjectGroup SubjectGroup,double Note,string NoteAsString,string NoteWithMax,double NoteCoef, double NotedOn,string Rating,string Position);
        public record TermRecord(
            int Id, 
            Student Student, 
            Subject Subject, 
            SubjectGroup SubjectGroup, 
            double FirstNote, 
            string FirstNoteAsString, 
            string FirstNoteWithMax,
            double SecondNote,
            string SecondNoteAsString,
            string SecondNoteWithMax,
            double ThirdNote,
            string ThirdNoteAsString,
            string ThirdNoteWithMax,
            double FinalNote,
            string FinalNoteAsString,
            string FinalNoteWithMax,
            double NoteCoef, 
            double NotedOn, 
            string Rating, 
            string Position);
        public record SubjectGroupRecord(int Id,string Name);
        public record HeadReportCard(string ReportTitle,string SchoolYear,Student Student,string ClassRoom,string Teacher,string Language,string EvaluationCode);
        public record DetailEvaluationReportCard(List<EvaluationRecord> NoteList,List<SubjectGroup> SubjectGroupList);
        public record DetailTermReportCard(List<TermRecord> NoteList, List<SubjectGroup> SubjectGroupList);
        public record EvaluationFooterReportCard(double SumNote,double SumCoef,double SumMaxNote,double StudentAverage,string Position,double ClassAverage,double HighestAverage, double LowestAverage);
        public record EvaluationReportCard(HeadReportCard HeadSection, DetailEvaluationReportCard DetailSection, EvaluationFooterReportCard FooterSection);
        public record TermReportCard(HeadReportCard HeadSection, DetailTermReportCard DetailSection, ReportFooter FooterSection);
        public record StudentDisciplinarySheet(HeadReportCard HeadSection, DisciplineScheetReportDetail DetailSection, ReportFooter FooterSection);
        public record HeadClassroomReport(string ReportTitle, string SchoolYear, string ClassRoom,string ClassroomSize,string TotalCoef);
        public record HeadClassGroupReport(string ReportTitle, string SchoolYear, string ClassGroup);
        public record ClassroomReportDetail(DataTable DataTable);
        public record ClassGroupReportDetail(DataTable DataTable);
        public record ReportItem(string Name,string Value);
        public record ReportHeader(List<ReportItem> Items);
        public record ReportDetail(List<ReportItem> Items);
        public record DisciplineScheetReportDetail(TermDisciplineItem FirstTermItem, TermDisciplineItem SecondTermItem, TermDisciplineItem ThirdTermItem, TermDisciplineItem ResumeItem);
        public record ReportFooter(List<ReportItem> Items);
        public record ClassroomReportHeader(List<ReportItem> Items,List<string>Columns);
        public record ClassGroupReportHeader(List<ReportItem> Items, List<string> Columns);
        public record ClassroomReport(ClassroomReportHeader HeaderSection, ClassroomReportDetail DetailSection, ReportFooter FooterSection);
        public record ClassGroupReport(ClassGroupReportHeader HeaderSection, ClassGroupReportDetail DetailSection, ReportFooter FooterSection);
        public record CertificateReport(StudentEnrollingDTO Enrolling, SchoolGroup SchoolGroup);
        public record PaymentReceiptData(StudentEnrolling Enrolling, bool IsCopy, SchoolGroup SchoolGroup);
        public record TuitionReceiptData(TuitionPayment TuitionPayment, bool IsCopy);
        public record SubscriptionReceiptData(Subscription Subscription, bool IsCopy);

        public record DisciplineItemRecord(
            int Id, 
            DateTime Date,
            string Reason, 
            double Duration,
            DisciplineSubject Subject,
            EvaluationSession Evaluation,
            Student Student,
            SchoolYear SchoolYear
     );

    public record TermDisciplineItem(
        List<DisciplineItemRecord> Disciplines,
        string Average,
        string Position,
        string ClassAverage
        );

        public record AnnualDisciplineItem(
        List<DisciplineItemRecord> Disciplines,
        string Average,
        string Position,
        string ClassAverage
        );
    }
}
