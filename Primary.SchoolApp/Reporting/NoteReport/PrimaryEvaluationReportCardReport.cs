

using Telerik.Reporting;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class PrimaryEvaluationReportCardReport:SchoolManagement.UI.Reporting.PrimaryEvaluationReport
    {
        public PrimaryEvaluationReportCardReport(EvaluationReportCard reportCard) { 
            string img= reportCard.HeadSection.Language=="FR"? "head_paper_fr.png" : "head_paper_en.png"; 
            HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl(img);
            RePortTitleTextBox.Value= reportCard.HeadSection.ReportTitle;
            string schoolYearLabel= reportCard.HeadSection.Language == "FR"?"Année scolaire":"School year";
            SchoolYearTextBox.Value= $"{schoolYearLabel}: {reportCard.HeadSection.SchoolYear}";
            StudentLabel.Value = reportCard.HeadSection.Language == "FR" ? "Nom et prénoms:" : "Names of pupil:";
            StudentTextBox.Value= reportCard.HeadSection.Student.FullName;
            StudentIdLabel.Value = reportCard.HeadSection.Language == "FR" ? "Matricule:" : "ID:";
            StudentIdTextBox.Value= reportCard.HeadSection.Student.IdNumber;
            ClassLabel.Value = reportCard.HeadSection.Language == "FR" ? "Classe:" : "Class:";
            ClassTextBox.Value = reportCard.HeadSection.ClassRoom.Name;
            TeacherLabel.Value = reportCard.HeadSection.Language == "FR" ? "Titulaire:" : "Teacher:";
            TeacherTexBox.Value = reportCard.HeadSection.Teacher;
            TotalLabel.Value = "Total".ToUpper();
            if (reportCard.HeadSection.Language == "FR")
            {
                string bornLabel = reportCard.HeadSection.Student.Sex == "M" ? "Né le " : "Née le ";
                BornTextBox.Value = bornLabel + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " à " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value="Discipline".ToUpper();
                NotedOnLabel.Value = "Max";
                NoteLabel.Value = "Note";
                ObservationLabel.Value = "Observation";
                SubjectGroupTextBox.Value = "=FrenchName";
                
                AverageLabel.Value = "Moyenne";
                RankLabel.Value = "Rang";
                GeneralAverageLabel.Value = "Moyenne Générale";
                HighestAverageLabel.Value = "Plus Forte Moyenne";
                LowestAverageLabel.Value = "Plus Faible Moyenne";
                ExplanationCompetenceLabel.Value = "Cotation des compétences";
                ExpertCompetenceLabel.Value = "A+ : Expert";
                AcquiredCompetenceLabel.Value = "A : Acquis";
                EcaCompetenceLabel.Value = "ECA : En Cours d'Acquisition";
                NaCompetenceLabel.Value = "NA : Non Acquis";
                ParentSignatureLabel.Value = "Parent(s)";
                TeacherSignatureLabel.Value = "Enseignant(e)";
                DeanSignatureLabel.Value = "Préfet  des Etudes";
                DirectorSignatureLabel.Value = "Directeur";
                var decisionMessagePassed = reportCard.HeadSection.Student.Sex == "M" ? "ADMIS" : "ADMISE";
                var decisionMessageFailed = reportCard.HeadSection.Student.Sex == "M" ? "REFUSE" : "REFUSEE";
                DecisionTextBox.Value = reportCard.FooterSection.StudentAverage >= 10 ? decisionMessagePassed : decisionMessageFailed;
            }
            else
            {
                BornTextBox.Value = "Born on" + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " in " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "Subject".ToUpper();
                NotedOnLabel.Value = "Max";
                NoteLabel.Value = "Mark";
                ObservationLabel.Value = "Remark";
                SubjectGroupTextBox.Value = "=EnglishName";

                AverageLabel.Value = "Average";
                RankLabel.Value = "Position";
                GeneralAverageLabel.Value = "Class Average";
                HighestAverageLabel.Value = "Highest Average";
                LowestAverageLabel.Value = "Lowest Average";
                ExplanationCompetenceLabel.Value = "Grading on compétences";
                ExpertCompetenceLabel.Value = "A+ : Expert";
                AcquiredCompetenceLabel.Value = "A : Acquired";
                EcaCompetenceLabel.Value = "ICA : In the Course  of  Acquisition";
                NaCompetenceLabel.Value = "NA : Not Acquired";
                ParentSignatureLabel.Value = "Parent(s)";
                TeacherSignatureLabel.Value = "Teacher";
                DeanSignatureLabel.Value = "Dean of Studies";
                DirectorSignatureLabel.Value = "Head Master";
                DecisionTextBox.Value = reportCard.FooterSection.StudentAverage >= 10 ? "PASSED" : "FAILED";
            }
            
            
            //load data on sub report
            var noteReport = new InstanceReportSource
            {
                ReportDocument = new PrimaryOneNoteSubReport(reportCard)
            };

            NotesSubReport.ReportSource = noteReport;
            NotesSubReport.ReportSource.Parameters.Add(new Parameter("GroupID", "=Id"));
            this.DataSource=reportCard.DetailSection.SubjectGroupList;

            this.TotalMaxNoteTextBox.Value =reportCard.FooterSection.SumMaxNote.ToString();
            this.TotalNoteTextBox.Value =reportCard.FooterSection.SumNote.ToString();
            if (reportCard.FooterSection.StudentAverage < 10) this.AverageTextBox.Style.Color = System.Drawing.Color.Red;
            this.AverageTextBox.Value =reportCard.FooterSection.StudentAverage.ToString();
            this.GeneralAverageTextBox.Value =reportCard.FooterSection.ClassAverage.ToString();
            this.HighestAverageTextBox.Value=reportCard.FooterSection.HighestAverage.ToString();
            this.LowestAverageTextBox.Value=reportCard.FooterSection.LowestAverage.ToString();
            this.RankTextBox.Value = reportCard.FooterSection.Position;
            FacebookAddressLabel.Value = Program.CurrentSchool.Name;
            ContactTextBox.Value = $"Tel:{Program.CurrentSchool.Phone}";
            AddressTextBox.Value = Program.CurrentSchool.Address;
            WebSiteTextBox.Value = Program.CurrentSchool.WebSite;
            FaceBookPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Center;
            WebSitePictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Center;
            WebSitePictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("website.png");
            FaceBookPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("facebook.png");



        }
    }
}
