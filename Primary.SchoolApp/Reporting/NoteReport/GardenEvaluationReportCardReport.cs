

using static Primary.SchoolApp.DTO.DTOItem;
using Telerik.Reporting;
using System.Linq;

namespace Primary.SchoolApp.Reporting
{
    internal class GardenEvaluationReportCardReport:SchoolManagement.UI.Reporting.GardenEvaluationReport
    {
        public GardenEvaluationReportCardReport(EvaluationReportCard reportCard)
        {
            string img = reportCard.HeadSection.Language == "FR" ? "head_paper_fr.png" : "head_paper_en.png";
            HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl(img);
            RePortTitleTextBox.Value = reportCard.HeadSection.ReportTitle;
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
            TotalLabel.Value = "Total".ToUpper();
            if (reportCard.HeadSection.Language == "FR")
            {
                string bornLabel = reportCard.HeadSection.Student.Sex == "M" ? "Né le " : "Née le ";
                BornTextBox.Value = bornLabel + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " à " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "ACTIVITES".ToUpper();
                NoteLabel.Value = "NOTE";
                ObservationLabel.Value = "APPRECIATION";
                SubjectGroupTextBox.Value = "=FrenchName";

                AverageLabel.Value = "Moyenne";
                RankLabel.Value = "Rang";
                GeneralAverageLabel.Value = "Moyenne Générale";
                HighestAverageLabel.Value = "Plus Forte Moyenne";
                LowestAverageLabel.Value = "Plus Faible Moyenne";
                ExplanationCompetenceLabel.Value = "APPRECIATIONS";
                ExpertCompetenceLabel.Value = "A+   :  Expert [18 - 20 ]";
                AcquiredCompetenceLabel.Value = "A     :  Acquis [15 – 18 [";
                EcaCompetenceLabel.Value = "ECA : En Cours d’Acquisition [10 – 15 [";
                NaCompetenceLabel.Value = "NA  : Non Acquis [ 00 – 09 ]";
                ParentSignatureLabel.Value = "Visa Parent";
                TeacherSignatureLabel.Value = "Visa Enseignant(e)";
                DeanSignatureLabel.Value = "Visa Responsable";
                DirectorSignatureLabel.Value = "Visa Directeur";
                var decisionMessagePassed = reportCard.HeadSection.Student.Sex == "M" ? "ADMIS" : "ADMISE";
                var decisionMessageFailed = reportCard.HeadSection.Student.Sex == "M" ? "REFUSE" : "REFUSEE";
                TeacherCommentLabel.Value = "OBSERVATIONS DE L'ENSEIGNANTE";
            }
            else
            {
                BornTextBox.Value = "Born on " + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " in " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "ACTIVITIES".ToUpper();
                NoteLabel.Value = "MARK";
                ObservationLabel.Value = "APPRECIATION";
                SubjectGroupTextBox.Value = "=EnglishName";

                AverageLabel.Value = "Average";
                RankLabel.Value = "Position";
                GeneralAverageLabel.Value = "Class Average";
                HighestAverageLabel.Value = "Highest Average";
                LowestAverageLabel.Value = "Lowest Average";
                ExplanationCompetenceLabel.Value = "Grading on compétences";
                ExpertCompetenceLabel.Value = "A+   :  Expert [18 - 20 ]";
                AcquiredCompetenceLabel.Value = "A     :  Skills Acquired [15 – 18 [";
                EcaCompetenceLabel.Value = "IPA :Skills In The Process Of Acquiring  [10 – 15 [";
                NaCompetenceLabel.Value = "NA  : Skills Non Acquired [ 00 – 09 ]";
                ParentSignatureLabel.Value = "Parent's Visa";
                TeacherSignatureLabel.Value = "Teacher's Visa";
                DeanSignatureLabel.Value = "Head of Nursery visa";
                DirectorSignatureLabel.Value = "Head Master's Visa";
                TeacherCommentLabel.Value = "TEACHER’S COMMENT";
            }

            this.TotalDayAttendanceTextBox.Value=reportCard.HeadSection.DisciplinarySheet.Count(x=>x.Subject.Id==0).ToString();
            this.TotalLateTextBox.Value= reportCard.HeadSection.DisciplinarySheet.Count(x => x.Subject.Id == 1).ToString();
            this.TotalAbsentTextBox.Value= reportCard.HeadSection.DisciplinarySheet.Where(x => x.Subject.Id == 3 || x.Subject.Id == 4).Sum(x=>x.Duration).ToString();
            this.TotalLeftEarlyTextBox.Value = reportCard.HeadSection.DisciplinarySheet.Count(x => x.Subject.Id == 2).ToString();

            //load data on sub report
            var noteReport = new InstanceReportSource
            {
                ReportDocument = new GardenOneNoteSubReport(reportCard)
            };

            NotesSubReport.ReportSource = noteReport;
            NotesSubReport.ReportSource.Parameters.Add(new Parameter("GroupID", "=Id"));
            this.DataSource = reportCard.DetailSection.SubjectGroupList;

            this.TotalNoteTextBox.Value = reportCard.FooterSection.SumNote.ToString()+"/"+ reportCard.FooterSection.SumMaxNote.ToString();
            if (reportCard.FooterSection.StudentAverage < 10) this.AverageTextBox.Style.Color = System.Drawing.Color.Red;
            this.AverageTextBox.Value = reportCard.FooterSection.StudentAverage.ToString() + "/20";
            this.GeneralAverageTextBox.Value = reportCard.FooterSection.ClassAverage.ToString() + "/20";
            this.HighestAverageTextBox.Value = reportCard.FooterSection.HighestAverage.ToString() + "/20";
            this.LowestAverageTextBox.Value = reportCard.FooterSection.LowestAverage.ToString() + "/20";
            this.TeacherCommentTextBox.Value = reportCard.FooterSection.Comment;
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
