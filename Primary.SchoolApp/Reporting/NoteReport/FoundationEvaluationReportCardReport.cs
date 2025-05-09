
using static Primary.SchoolApp.DTO.DTOItem;
using Telerik.Reporting;
using System.Linq;
namespace Primary.SchoolApp.Reporting
{
    internal class FoundationEvaluationReportCardReport:SchoolManagement.UI.Reporting.FoundationEvaluationReport
    {
        public FoundationEvaluationReportCardReport(EvaluationReportCard reportCard)
        {
            string img = reportCard.HeadSection.Language == "FR" ? "head_paper_fr.png" : "head_paper_en.png";
            HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl(img);
            ReportTitleTextBox.Value = reportCard.HeadSection.ReportTitle;
            string schoolYearLabel = reportCard.HeadSection.Language == "FR" ? "Année scolaire" : "School year";
            SchoolYearTextBox.Value = $"{schoolYearLabel}: {reportCard.HeadSection.SchoolYear}";
            StudentLabel.Value = reportCard.HeadSection.Language == "FR" ? "Nom de L'enfant:" : "Name of the Child:";
            StudentTextBox.Value = reportCard.HeadSection.Student.FullName;
            StudentIdLabel.Value = reportCard.HeadSection.Language == "FR" ? "Matricule:" : "ID:";
            StudentIdTextBox.Value = reportCard.HeadSection.Student.IdNumber;
            ClassTextBox.Value = reportCard.HeadSection.Language == "FR" ? $"ClASSE:{reportCard.HeadSection.ClassRoom}".ToUpper() : $"CLASS:{reportCard.HeadSection.ClassRoom}".ToUpper();
            TeacherLabel.Value = reportCard.HeadSection.Language == "FR" ? "L’enseignante:" : "Class Teacher:";
            TeacherTexBox.Value = reportCard.HeadSection.Teacher;
            this.TotalDayAttendanceLabel.Value = reportCard.HeadSection.Language == "FR" ? "Présence effective" : "Total days of attendance";
            this.TotalAbsentLabel.Value = reportCard.HeadSection.Language == "FR" ? "Absence(s)" : "Absent";
            this.TotalLateLabel.Value = reportCard.HeadSection.Language == "FR" ? "Retard(s)" : "Late";
            this.TotalLeftEarlyLabel.Value = reportCard.HeadSection.Language == "FR" ? "Départ précoce" : "Left Early";
            if (reportCard.HeadSection.Language == "FR")
            {
                string bornLabel = reportCard.HeadSection.Student.Sex == "M" ? "Né le " : "Née le ";
                BornTextBox.Value = bornLabel + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " à " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "ACTIVITES".ToUpper();
                ObservationLabel.Value = "APPRECIATION";
                SubjectGroupTextBox.Value = "=FrenchName";

                ExplanationCompetenceLabel.Value = "APPRECIATIONS";
                ExpertCompetenceLabel.Value = "A+";
                ExpertCompetenceDescriptionLabel.Value = "Expert";
                AcquiredCompetenceLabel.Value = "A";
                AcquiredCompetenceDescriptionLabel.Value = "Acquis";
                EcaCompetenceLabel.Value = "ECA ";
                EcaCompetenceDescriptionLabel.Value = "En Cours d’Acquisition";
                NaCompetenceLabel.Value = "NA";
                NaCompetenceDescriptionLabel.Value = "Non Acquis";

                ParentSignatureLabel.Value = "Visa Parent";
                TeacherSignatureLabel.Value = "Visa Enseignant(e)";
                DeanSignatureLabel.Value = "Visa Responsable";
                DirectorSignatureLabel.Value = "Visa Directeur";
                var decisionMessagePassed = reportCard.HeadSection.Student.Sex == "M" ? "ADMIS" : "ADMISE";
                var decisionMessageFailed = reportCard.HeadSection.Student.Sex == "M" ? "REFUSE" : "REFUSEE";
                TeacherCommentLabel.Value = "OBSERVATIONS DE L'ENSEIGNANT(E)";
            }
            else
            {
                BornTextBox.Value = "Born on " + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " in " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "ACTIVITIES".ToUpper();
                ObservationLabel.Value = "APPRECIATION";
                SubjectGroupTextBox.Value = "=EnglishName";

                ExplanationCompetenceLabel.Value = "Grading on compétences";
                ExpertCompetenceLabel.Value = "A+";
                ExpertCompetenceDescriptionLabel.Value = "Expert";
                AcquiredCompetenceLabel.Value = "A";
                AcquiredCompetenceDescriptionLabel.Value = "Skills Acquired";
                EcaCompetenceLabel.Value = "IPA ";
                EcaCompetenceDescriptionLabel.Value = "Skills In The Process Of Acquiring";
                NaCompetenceLabel.Value = "NA";
                NaCompetenceDescriptionLabel.Value = "Skills Not Acquired";
                ParentSignatureLabel.Value = "Parent's Visa";
                TeacherSignatureLabel.Value = "Teacher's Visa";
                DeanSignatureLabel.Value = "Head of Nursery visa";
                DirectorSignatureLabel.Value = "Head Master's Visa";
                TeacherCommentLabel.Value = "TEACHER’S COMMENT";
            }

            this.TotalDayAttendanceTextBox.Value = reportCard.HeadSection.DisciplinarySheet.Count(x => x.Subject.Id == 0).ToString();
            this.TotalLateTextBox.Value = reportCard.HeadSection.DisciplinarySheet.Count(x => x.Subject.Id == 1).ToString();
            this.TotalAbsentTextBox.Value = reportCard.HeadSection.DisciplinarySheet.Where(x => x.Subject.Id == 3 || x.Subject.Id == 4).Sum(x => x.Duration).ToString();
            this.TotalLeftEarlyTextBox.Value = reportCard.HeadSection.DisciplinarySheet.Count(x => x.Subject.Id == 2).ToString();

            //load data on sub report
            var noteReport = new InstanceReportSource
            {
                ReportDocument = new FoundationOneNoteSubReport(reportCard)
            };

            NotesSubReport.ReportSource = noteReport;
            NotesSubReport.ReportSource.Parameters.Add(new Parameter("GroupID", "=Id"));
            this.DataSource = reportCard.DetailSection.SubjectGroupList;

            this.TeacherCommentTextBox.Value = reportCard.FooterSection.Comment;
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
