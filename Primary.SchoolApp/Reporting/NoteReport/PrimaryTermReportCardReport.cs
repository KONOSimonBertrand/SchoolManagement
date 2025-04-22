

using static Primary.SchoolApp.DTO.DTOItem;
using Telerik.Reporting;
using System.Linq;
using System.Collections.Generic;

namespace Primary.SchoolApp.Reporting
{
    internal class PrimaryTermReportCardReport : SchoolManagement.UI.Reporting.PrimaryTermReport
    {
        public PrimaryTermReportCardReport(TermReportCard reportCard)
        {
            var headTerms = GetHeadTerm( reportCard.HeadSection.EvaluationCode, reportCard.HeadSection.Language);
            string img = reportCard.HeadSection.Language == "FR" ? "head_paper_fr.png" : "head_paper_en.png";

            HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl(img);
            ReportTitleTextBox.Value = headTerms.GetValueOrDefault("Title");
            string schoolYearLabel = reportCard.HeadSection.Language == "FR" ? "Année scolaire" : "School year";
            SchoolYearTextBox.Value = $"{schoolYearLabel}: {reportCard.HeadSection.SchoolYear}";
            StudentLabel.Value = reportCard.HeadSection.Language == "FR" ? "Nom et prénoms:" : "Names of pupil:";
            StudentTextBox.Value = reportCard.HeadSection.Student.FullName;
            StudentIdLabel.Value = reportCard.HeadSection.Language == "FR" ? "Matricule:" : "ID:";
            StudentIdTextBox.Value = reportCard.HeadSection.Student.IdNumber;
            ClassLabel.Value = reportCard.HeadSection.Language == "FR" ? "Classe:" : "Class:";
            ClassTextBox.Value = reportCard.HeadSection.ClassRoom.Name;
            TeacherLabel.Value = reportCard.HeadSection.Language == "FR" ? "Titulaire:" : "Teacher:";
            TeacherTexBox.Value = reportCard.HeadSection.Teacher;
            TotalLabel.Value = "Total".ToUpper();
            FirstNoteLabel.Value = headTerms.GetValueOrDefault("FirstMonth");
            SecondNoteLabel.Value = headTerms.GetValueOrDefault("SecondMonth");
            ThirdNoteLabel.Value = headTerms.GetValueOrDefault("ThirdMonth");
            FinalNoteLabel.Value = reportCard.HeadSection.Language == "FR" ? "TRIM" : "TERM";
            this.AverageFirstTermLabel.Value = reportCard.HeadSection.Language == "FR" ? "TRIM 1" : "TERM 1";
            this.AverageSecondTermLabel.Value = reportCard.HeadSection.Language == "FR" ? "TRIM 2" : "TERM 2";
            this.AverageThirdTermLabel.Value = reportCard.HeadSection.Language == "FR" ? "TRIM 3" : "TERM 3";
            var footerTermAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermAverage");
            double termAverage = 0;
            if (reportCard.HeadSection.Language == "FR")
            {
                string bornLabel = reportCard.HeadSection.Student.Sex == "M" ? "Né le " : "Née le ";
                BornTextBox.Value = bornLabel + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " à " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "Discipline".ToUpper();
                NotedOnLabel.Value = "Max";
               
                CotationLabel.Value = "Cotation";
                ObservationLabel.Value = "Observation";
                SubjectGroupTextBox.Value = "=FrenchName";

                AverageLabel.Value = "Moyenne";
                PositionLabel.Value = "Rang";
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
                TermStartTextBox.Value = "NB : Reprise des cours le :";
                DecisionTextBox.Value = double.TryParse(footerTermAverageItem.Value, out termAverage) && termAverage >= 10 ? decisionMessagePassed : decisionMessageFailed;
                AverageResumeLabel.Value = reportCard.HeadSection.EvaluationCode != "TERM03" ? "RAPPEL" : "RESULTAT ANNUEL";
            }
            else
            {
                BornTextBox.Value = "Born on" + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " in " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "Subject".ToUpper();
                NotedOnLabel.Value = "Max";
                FinalNoteLabel.Value = "TERM";
                CotationLabel.Value = "Grading";
                ObservationLabel.Value = "Remark";
                SubjectGroupTextBox.Value = "=EnglishName";

                AverageLabel.Value = "Average";
                PositionLabel.Value = "Position";
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
                DecisionTextBox.Value = double.TryParse(footerTermAverageItem.Value,out termAverage) && termAverage >= 10 ? "PASSED" : "FAILED";
                TermStartTextBox.Value = "Next term starts on the ";
                AverageResumeLabel.Value= reportCard.HeadSection.EvaluationCode!="TERM03"?"REMINDER":"ANNUAL RESULT";
            }


            //load data on sub report
            var noteReport = new InstanceReportSource
            {
                ReportDocument = new PrimaryThreeNoteSubreport(reportCard)
            };

            NotesSubReport.ReportSource = noteReport;
            NotesSubReport.ReportSource.Parameters.Add(new Parameter("GroupID", "=Id"));
            this.DataSource = reportCard.DetailSection.SubjectGroupList;

            this.TotalNotedOnTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SumNotedOn").Value;
            this.TotalFirstNoteTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SumFirstNote").Value;
            this.TotalSecondNoteTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SumSecondNote").Value;
            this.TotalThirdNoteTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SumThirdNote").Value;
            this.TotalFinalNoteTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SumFinalNote").Value;
            var footerFirstMonthAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstMonthAverage");
            var footerSecondMonthAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondMonthAverage");
            var footerThirdMonthAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdMonthAverage");
            if (double.TryParse(footerFirstMonthAverageItem.Value,out double av1) && av1 < 10) AverageFirstMonthTextBox.Style.Color = System.Drawing.Color.Red;
            if (double.TryParse(footerSecondMonthAverageItem.Value, out double av2) && av2< 10) AverageSecondMonthTextBox.Style.Color = System.Drawing.Color.Red;
            if (double.TryParse(footerThirdMonthAverageItem.Value, out double av3) && av3 < 10) AverageThirdMonthTextBox.Style.Color = System.Drawing.Color.Red;
            if (double.TryParse(footerTermAverageItem.Value, out termAverage) && termAverage < 10) AverageTermTextBox.Style.Color = System.Drawing.Color.Red;
            AverageFirstMonthTextBox.Value = footerFirstMonthAverageItem.Value;
            AverageSecondMonthTextBox.Value = footerSecondMonthAverageItem.Value;
            AverageThirdMonthTextBox.Value = footerThirdMonthAverageItem.Value; 
            AverageTermTextBox.Value = footerTermAverageItem.Value;
            this.GeneralAverageFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstMonthClassAverage").Value;
            this.GeneralAverageSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondMonthClassAverage").Value;
            this.GeneralAverageThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdMonthClassAverage").Value;
            this.GeneralAverageTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermClassAverage").Value;

            this.HighestAverageFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstMonthHighestAverage").Value; 
            this.HighestAverageSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondMonthHighestAverage").Value;
            this.HighestAverageThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdMonthHighestAverage").Value;
            this.HighestAverageTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermHighestAverage").Value;

            this.LowestAverageFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstMonthLowestAverage").Value; 
            this.LowestAverageSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondMonthLowestAverage").Value;
            this.LowestAverageThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdMonthLowestAverage").Value;
            this.LowestAverageTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermLowestAverage").Value;

            this.PositionFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstMonthPosition").Value;
            this.PositionSecondMonthTextBox.Value= reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondMonthPosition").Value;
            this.PositionThirdMonthTextBox.Value= reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdMonthPosition").Value;
            this.PositionTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermPosition").Value;

            if (reportCard.HeadSection.EvaluationCode != "TERM01")
            {
                AverageResumePanel.Visible = true;
                this.AverageFirstTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstTermAverage").Value;
                if (reportCard.HeadSection.EvaluationCode == "TERM02")
                {
                    this.AverageSecondTermLabel.Value = string.Empty;
                    this.AverageThirdTermLabel.Value = string.Empty;

                    this.AverageSecondTermTextBox.Value = string.Empty;
                    this.AverageThirdTermTextBox.Value = string.Empty;
                    this.AverageAnnualTextBox.Value = string.Empty;
                }
                else
                {
                    this.AverageSecondTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondTermAverage").Value;
                    this.AverageThirdTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdTermAverage").Value;
                   this.AverageAnnualTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "AnnualAverage").Value;
                }

            }
            else
            {
                AverageResumePanel.Visible = false;
            }

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
        private Dictionary<string, string> GetHeadTerm(string termCode,string language)
        {
            Dictionary<string,string> terms = new();
            switch (termCode)
            {
                case "TERM01":
                    terms.Add("Title", language == "FR" ? "BULLETIN DU PREMIER TRIMESTRE" : "FIRST TERM SUMMARY MARK");
                    terms.Add("FirstMonth", language == "FR" ? "1ʳᵉ  MENS" : "1ˢᵗ MONTH");
                    terms.Add("SecondMonth", language == "FR" ? "2ᵉ   MENS" : "2ⁿᵈ MONTH");
                    terms.Add("ThirdMonth", language == "FR" ? "3ᵉ    MENS" : "3ʳᵈ MONTH");
                    break;
                case "TERM02":
                    terms.Add("Title", language == "FR" ? "BULLETIN DU DEUXIEME TRIMESTRE" : "SECOND TERM SUMMARY MARK");
                    terms.Add("FirstMonth", language == "FR" ? "4ᵉ    MENS" : "4ᵗʰ MONTH");
                    terms.Add("SecondMonth", language == "FR" ? "5ᵉ   MENS" : "5ᵗʰ MONTH");
                    terms.Add("ThirdMonth", language == "FR" ? "6ᵉ    MENS" : "6ᵗʰ MONTH");
                    break;
                case "TERM03":
                    terms.Add("Title", language == "FR" ? "BULLETIN DU TROISIEME TRIMESTRE" : "THIRD TERM SUMMARY MARK");
                    terms.Add("FirstMonth", language == "FR" ? "7ᵉ    MENS" : "7ᵗʰ MONTH");
                    terms.Add("SecondMonth", language == "FR" ? "8ᵉ   MENS" : "8ᵗʰ MONTH");
                    terms.Add("ThirdMonth", language == "FR" ? "9ᵉ    MENS" : "9ᵗʰ MONTH");
                    break;
            }
            return terms;
        }
    }
}
