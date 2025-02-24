

using static Primary.SchoolApp.DTO.DTOItem;
using Telerik.Reporting;
using System.Linq;

namespace Primary.SchoolApp.Reporting
{
    internal class TermPrimaryReportCardReport : SchoolManagement.UI.Reporting.TermPrimaryReportCardReport
    {
        public TermPrimaryReportCardReport(TermReportCard reportCard)
        {
            string img = reportCard.HeadSection.Language == "FR" ? "head_paper_fr.png" : "head_paper_en.png";
            HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl(img);
            RePortTitleTextBox.Value = reportCard.HeadSection.ReportTitle;
            string schoolYearLabel = reportCard.HeadSection.Language == "FR" ? "Année scolaire" : "School year";
            SchoolYearTextBox.Value = $"{schoolYearLabel}: {reportCard.HeadSection.SchoolYear}";
            StudentLabel.Value = reportCard.HeadSection.Language == "FR" ? "Nom et prénoms:" : "Names of pupil:";
            StudentTextBox.Value = reportCard.HeadSection.Student.FullName;
            StudentIdLabel.Value = reportCard.HeadSection.Language == "FR" ? "Matricule:" : "ID:";
            StudentIdTextBox.Value = reportCard.HeadSection.Student.IdNumber;
            ClassLabel.Value = reportCard.HeadSection.Language == "FR" ? "Classe:" : "Class:";
            ClassTextBox.Value = reportCard.HeadSection.ClassRoom;
            TeacherLabel.Value = reportCard.HeadSection.Language == "FR" ? "Titulaire:" : "Teacher:";
            TeacherTexBox.Value = reportCard.HeadSection.Teacher;
            TotalLabel.Value = "Total".ToUpper();
            var footerTermAverageItem = reportCard.FooterSection.Items.FirstOrDefault(x => x.Name == "TermAverage");
            double termAverage = 0;
            if (reportCard.HeadSection.Language == "FR")
            {
                string bornLabel = reportCard.HeadSection.Student.Sex == "M" ? "Né le " : "Née le ";
                BornTextBox.Value = bornLabel + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " à " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "Discipline".ToUpper();
                NotedOnLabel.Value = "Max";
                FirstNoteLabel.Value = "1ʳᵉ  MENS";
                SecondNoteLabel.Value = "2ᵉ   MENS";
                ThirdNoteLabel.Value = "3ᵉ    MENS";
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
            }
            else
            {
                BornTextBox.Value = "Born on" + reportCard.HeadSection.Student.BirthDate.ToShortDateString() + " in " + reportCard.HeadSection.Student.BirthPlace;
                SubjectLabel.Value = "Subject".ToUpper();
                NotedOnLabel.Value = "Max";
                FirstNoteLabel.Value = "1ˢᵗ MONTH";
                SecondNoteLabel.Value = "2ⁿᵈ MONTH";
                ThirdNoteLabel.Value = "3ʳᵈ MONTH";
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
            }


            //load data on sub report
            var noteReport = new InstanceReportSource
            {
                ReportDocument = new Subreport3NoteReport(reportCard)
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
            AverageThirdMonthTextBox.Value = footerSecondMonthAverageItem.Value; 
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
