

using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class GardenTermReportCardReport:SchoolManagement.UI.Reporting.GardenTermReport
    {
        public GardenTermReportCardReport(TermReportCard reportCard)
        {
            string img = reportCard.HeadSection.Language == "FR" ? "head_paper_fr.png" : "head_paper_en.png";
            var headTerms = GetHeadTerm(reportCard.HeadSection.EvaluationCode, reportCard.HeadSection.Language);
            HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl(img);
            ReportTitleTextBox.Value = headTerms.GetValueOrDefault("Title");
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
            FirstNoteLabel.Value = headTerms.GetValueOrDefault("FirstMonth");
            SecondNoteLabel.Value = headTerms.GetValueOrDefault("SecondMonth");
            ThirdNoteLabel.Value = headTerms.GetValueOrDefault("ThirdMonth");
            FinalNoteLabel.Value = reportCard.HeadSection.Language == "FR" ? "TRIM" : "TERM";
            var footerTermAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermAverage");
            double termAverage = 0;

            if (reportCard.HeadSection.Language == "FR")
            {
                string bornLabel = reportCard.HeadSection.Student.Sex == "M" ? "Né le " : "Née le ";
                BornTextBox.Value = bornLabel + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " à " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "ACTIVITES".ToUpper();
                ObservationLabel.Value = "APPRECIATION";
                SubjectGroupTextBox.Value = "=FrenchName";

                AverageLabel.Value = "Moyenne";
                PositionLabel.Value = "Rang";
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
                DecisionTextBox.Value = double.TryParse(footerTermAverageItem.Value, out termAverage) && termAverage >= 10 ? decisionMessagePassed : decisionMessageFailed;
            }
            else
            {
                BornTextBox.Value = "Born on " + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " in " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "ACTIVITIES".ToUpper();
                ObservationLabel.Value = "APPRECIATION";
                SubjectGroupTextBox.Value = "=EnglishName";

                AverageLabel.Value = "Average";
                PositionLabel.Value = "Position";
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
                DecisionTextBox.Value = double.TryParse(footerTermAverageItem.Value, out termAverage) && termAverage >= 10 ? "PASSED" : "FAILED";

            }

            this.TotalDayAttendanceTextBox.Value = reportCard.HeadSection.DisciplinarySheet.Count(x => x.Subject.Id == 0).ToString();
            this.TotalLateTextBox.Value = reportCard.HeadSection.DisciplinarySheet.Count(x => x.Subject.Id == 1).ToString();
            this.TotalAbsentTextBox.Value = reportCard.HeadSection.DisciplinarySheet.Where(x => x.Subject.Id == 3 || x.Subject.Id == 4).Sum(x => x.Duration).ToString();
            this.TotalLeftEarlyTextBox.Value = reportCard.HeadSection.DisciplinarySheet.Count(x => x.Subject.Id == 2).ToString();

            //load data on sub report
            var noteReport = new InstanceReportSource
            {
                ReportDocument = new GardenThreeNoteSubReport(reportCard)
            };

            NotesSubReport.ReportSource = noteReport;
            NotesSubReport.ReportSource.Parameters.Add(new Parameter("GroupID", "=Id"));
            this.DataSource = reportCard.DetailSection.SubjectGroupList;

            this.TotalFirstNoteTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SumFirstNote").Value;
            this.TotalSecondNoteTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SumSecondNote").Value;
            this.TotalThirdNoteTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SumThirdNote").Value;
            this.TotalFinalNoteTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SumFinalNote").Value;

            var footerFirstMonthAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstMonthAverage");
            var footerSecondMonthAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondMonthAverage");
            var footerThirdMonthAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdMonthAverage");
            if (double.TryParse(footerFirstMonthAverageItem.Value, out double av1) && av1 < 10) AverageFirstMonthTextBox.Style.Color = System.Drawing.Color.Red;
            if (double.TryParse(footerSecondMonthAverageItem.Value, out double av2) && av2 < 10) AverageSecondMonthTextBox.Style.Color = System.Drawing.Color.Red;
            if (double.TryParse(footerThirdMonthAverageItem.Value, out double av3) && av3 < 10) AverageThirdMonthTextBox.Style.Color = System.Drawing.Color.Red;
            if (double.TryParse(footerTermAverageItem.Value, out termAverage) && termAverage < 10) AverageTermTextBox.Style.Color = System.Drawing.Color.Red;
            AverageFirstMonthTextBox.Value = footerFirstMonthAverageItem.Value;
            AverageSecondMonthTextBox.Value = footerSecondMonthAverageItem.Value;
            AverageThirdMonthTextBox.Value = footerThirdMonthAverageItem.Value;
            AverageTermTextBox.Value = footerTermAverageItem.Value;
            this.GeneralAverageFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstMonthClassAverage").Value + "/20";
            this.GeneralAverageSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondMonthClassAverage").Value + "/20";
            this.GeneralAverageThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdMonthClassAverage").Value + "/20";
            this.GeneralAverageTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermClassAverage").Value + "/20";

            this.HighestAverageFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstMonthHighestAverage").Value + "/20";
            this.HighestAverageSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondMonthHighestAverage").Value + "/20";
            this.HighestAverageThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdMonthHighestAverage").Value + "/20";
            this.HighestAverageTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermHighestAverage").Value + "/20";

            this.LowestAverageFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstMonthLowestAverage").Value + "/20";
            this.LowestAverageSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondMonthLowestAverage").Value + "/20";
            this.LowestAverageThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdMonthLowestAverage").Value + "/20";
            this.LowestAverageTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermLowestAverage").Value + "/20";

            this.PositionFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstMonthPositionWithStudentCount").Value;
            this.PositionSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondMonthPositionWithStudentCount").Value;
            this.PositionThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdMonthPositionWithStudentCount").Value;
            this.PositionTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermPositionWithStudentCount").Value;

            this.TeacherCommentTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "Comment").Value;

            FacebookAddressLabel.Value = Program.CurrentSchool.Name;
            ContactTextBox.Value = $"Tel:{Program.CurrentSchool.Phone}";
            AddressTextBox.Value = Program.CurrentSchool.Address;
            WebSiteTextBox.Value = Program.CurrentSchool.WebSite;
            FaceBookPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Center;
            WebSitePictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Center;
            WebSitePictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("website.png");
            FaceBookPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("facebook.png");
        }

        // recupere les entetes selon langue
        private Dictionary<string, string> GetHeadTerm(string termCode, string language)
        {
            Dictionary<string, string> terms = new();
            switch (termCode)
            {
                case "TERM01":
                    terms.Add("Title", language == "FR" ? "BULLETIN DU PREMIER TRIMESTRE" : "FIRST TERM SUMMARY MARK");
                    terms.Add("FirstMonth", language == "FR" ? "1ʳᵉ EVAL" : "1ˢᵗ EVAL");
                    terms.Add("SecondMonth", language == "FR" ? "2ᵉ EVAL" : "2ⁿᵈ EVAL");
                    terms.Add("ThirdMonth", language == "FR" ? "3ᵉ  EVAL" : "3ʳᵈ EVAL");
                    break;
                case "TERM02":
                    terms.Add("Title", language == "FR" ? "BULLETIN DU DEUXIEME TRIMESTRE" : "SECOND TERM SUMMARY MARK");
                    terms.Add("FirstMonth", language == "FR" ? "4ᵉ  EVAL" : "4ᵗʰ EVAL");
                    terms.Add("SecondMonth", language == "FR" ? "5ᵉ EVAL" : "5ᵗʰ EVAL");
                    terms.Add("ThirdMonth", language == "FR" ? "6ᵉ  EVAL" : "6ᵗʰ EVAL");
                    break;
                case "TERM03":
                    terms.Add("Title", language == "FR" ? "BULLETIN DU TROISIEME TRIMESTRE" : "THIRD TERM SUMMARY MARK");
                    terms.Add("FirstMonth", language == "FR" ? "7ᵉ  EVAL" : "7ᵗʰ EVAL");
                    terms.Add("SecondMonth", language == "FR" ? "8ᵉ EVAL" : "8ᵗʰ EVAL");
                    terms.Add("ThirdMonth", language == "FR" ? "9ᵉ  EVAL" : "9ᵗʰ EVAL");
                    break;
            }
            return terms;
        }
    }
}
