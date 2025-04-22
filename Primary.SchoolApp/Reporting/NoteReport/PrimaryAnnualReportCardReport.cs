

using static Primary.SchoolApp.DTO.DTOItem;
using Telerik.Reporting;
using System.Linq;
using System.Collections.Generic;

namespace Primary.SchoolApp.Reporting
{
    internal class PrimaryAnnualReportCardReport : SchoolManagement.UI.Reporting.PrimaryTermReport
    {
        public PrimaryAnnualReportCardReport(TermReportCard reportCard)
        {
            string img = reportCard.HeadSection.Language == "FR" ? "head_paper_fr.png" : "head_paper_en.png";
            HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl(img);
            ReportTitleTextBox.Value = reportCard.HeadSection.Language == "FR" ? "BULLETIN ANNUEL" : "ANNUAL SUMMARY MARK";
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
            FirstNoteLabel.Value = reportCard.HeadSection.Language == "FR" ?"TRIM 1":"TERM 1";
            SecondNoteLabel.Value = reportCard.HeadSection.Language == "FR" ? "TRIM 2" : "TERM 2";
            ThirdNoteLabel.Value = reportCard.HeadSection.Language == "FR" ? "TRIM 3" : "TERM 3";
            this.AverageFirstTermLabel.Value = reportCard.HeadSection.Language == "FR" ? "TRIM 1" : "TERM 1";
            this.AverageSecondTermLabel.Value = reportCard.HeadSection.Language == "FR" ? "TRIM 2" : "TERM 2";
            this.AverageThirdTermLabel.Value = reportCard.HeadSection.Language == "FR" ? "TRIM 3" : "TERM 3";
            var footerTermAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "AnnualAverage");
            double termAverage = 0;
            if (reportCard.HeadSection.Language == "FR")
            {
                string bornLabel = reportCard.HeadSection.Student.Sex == "M" ? "Né le " : "Née le ";
                BornTextBox.Value = bornLabel + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " à " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "Discipline".ToUpper();
                NotedOnLabel.Value = "Max";
                FinalNoteLabel.Value = "TRIM";
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
                AverageResumeLabel.Value =  "RESULTAT ANNUEL";
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
                DecisionTextBox.Value = double.TryParse(footerTermAverageItem.Value, out termAverage) && termAverage >= 10 ? "PASSED" : "FAILED";
                TermStartTextBox.Value = "Next term starts on the ";
                AverageResumeLabel.Value = "ANNUAL RESULT";
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
            
            var footerFirstMonthAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstTermAverage");
            var footerSecondMonthAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondTermAverage");
            var footerThirdMonthAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdTermAverage");
            
            if (double.TryParse(footerFirstMonthAverageItem.Value, out double av1) && av1 < 10) AverageFirstMonthTextBox.Style.Color = System.Drawing.Color.Red;
            if (double.TryParse(footerSecondMonthAverageItem.Value, out double av2) && av2 < 10) AverageSecondMonthTextBox.Style.Color = System.Drawing.Color.Red;
            if (double.TryParse(footerThirdMonthAverageItem.Value, out double av3) && av3 < 10) AverageThirdMonthTextBox.Style.Color = System.Drawing.Color.Red;
            if (double.TryParse(footerTermAverageItem.Value, out termAverage) && termAverage < 10) AverageTermTextBox.Style.Color = System.Drawing.Color.Red;
           
            AverageFirstMonthTextBox.Value = footerFirstMonthAverageItem.Value;
            AverageSecondMonthTextBox.Value = footerSecondMonthAverageItem.Value;
            AverageThirdMonthTextBox.Value = footerThirdMonthAverageItem.Value;
            AverageTermTextBox.Value = footerTermAverageItem.Value;
            
            this.GeneralAverageFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstTermClassAverage").Value;
            this.GeneralAverageSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondTermClassAverage").Value;
            this.GeneralAverageThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdTermClassAverage").Value;
            this.GeneralAverageTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "AnnualClassAverage").Value;

            this.HighestAverageFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstTermHighestAverage").Value;
            this.HighestAverageSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondTermHighestAverage").Value;
            this.HighestAverageThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdTermHighestAverage").Value;
            this.HighestAverageTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "AnnualHighestAverage").Value;

            this.LowestAverageFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstTermLowestAverage").Value;
            this.LowestAverageSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondTermLowestAverage").Value;
            this.LowestAverageThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdTermLowestAverage").Value;
            this.LowestAverageTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "AnnualLowestAverage").Value;

            this.PositionFirstMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstTermPosition").Value;
            this.PositionSecondMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondTermPosition").Value;
            this.PositionThirdMonthTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdTermPosition").Value;
            this.PositionTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "AnnualPosition").Value;
            AverageResumePanel.Visible = true;
            this.AverageFirstTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "FirstTermAverage").Value;
            this.AverageSecondTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "SecondTermAverage").Value;
            this.AverageThirdTermTextBox.Value = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "ThirdTermAverage").Value;
            this.AverageAnnualTextBox.Value= reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "AnnualAverage").Value;
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
