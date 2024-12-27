

using System.Collections.Generic;
using System.Data;
using System.Linq;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;
using Telerik.WinControls.UI;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class ClassNoteReport:SchoolManagement.UI.Reporting.ClassNoteReport
    {
        public ClassNoteReport(ClassroomReport report) {
            HeaderPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
           this.ReportTitleTextBox.Value=report.HeaderSection.Items.FirstOrDefault(x=>x.Name== "ReportTitle").Value;
           this.SchoolYearTextBox.Value = report.HeaderSection.Items.FirstOrDefault(x => x.Name == "SchoolYear").Value;
           this.RoomTextBox.Value = report.HeaderSection.Items.FirstOrDefault(x => x.Name == "ClassRoom").Value;
           this.ClassroomSizeTextBox.Value = report.HeaderSection.Items.FirstOrDefault(x => x.Name == "ClassRoomSize").Value;
           this.TotalCoefTextBox.Value = report.HeaderSection.Items.FirstOrDefault(x => x.Name == "SumMaxOrCoef").Value;
           
            this.ReportTable.ColumnGroups.Clear();
            this.ReportTable.Body.Columns.Clear();
            this.ReportTable.Body.Rows.Clear();

            for (int i = 0; i < report.HeaderSection.Columns.Count; i++) {
                TableGroup tableGroupColumn = new();
                this.ReportTable.ColumnGroups.Add(tableGroupColumn);
                tableGroupColumn.Name = i.ToString();
                var textboxGroup = new TextBox();
                textboxGroup.StyleName = "BlueOpal.TableHeader";
                textboxGroup.Value = report.HeaderSection.Columns[i];
                var textBoxTable = new TextBox();
                textBoxTable.Value = "=Fields."+ report.DetailSection.DataTable.Columns[i].ColumnName; 
                textBoxTable.StyleName = "BlueOpal.TableBody";               
                ReportTable.Body.SetCellContent(0, i, textBoxTable);

                switch (i)
                {
                    case 0:
                        textboxGroup.Size = new SizeU(Unit.Inch(0.308D), Unit.Inch(1.943D));
                        textBoxTable.Size = new SizeU(Unit.Inch(0.308D), Unit.Inch(0.2D));
                        break;
                    case 1:
                        textboxGroup.Size = new SizeU(Unit.Inch(2.842D), Unit.Inch(0.943D));
                        textBoxTable.Size = new SizeU(Unit.Inch(2.842D), Unit.Inch(0.2D));
                        break;
                    case 2:
                        textboxGroup.Size = new SizeU(Unit.Inch(0.418D), Unit.Inch(0.943D));
                        textBoxTable.Size = new SizeU(Unit.Inch(0.418D), Unit.Inch(0.2D));
                        break;
                    default:
                        textBoxTable.Size = new SizeU(Unit.Inch(0.450D), Unit.Inch(0.2D));
                        break;
                }
                if (i > 2)
                {
                    textboxGroup.Angle = 270D;
                    textboxGroup.Size = new SizeU(Unit.Inch(0.181D), Unit.Inch(0.943D));
                }
                if (i == report.HeaderSection.Columns.Count - 1)
                {
                    textBoxTable.Size = new SizeU(Unit.Inch(0.900D), Unit.Inch(0.2D));
                }
                tableGroupColumn.ReportItem = textboxGroup;

                ReportTable.Items.AddRange(new ReportItemBase[] { textBoxTable, textboxGroup });
            }
            ReportTable.DataSource = report.DetailSection.DataTable;           
            if (report.HeaderSection.Items.FirstOrDefault(x => x.Name == "Language").Value == "FR")
            {
                ClassroomSizeSectionLabel.Value = "EFFECTIF";
                PresentSectionLabel.Value = "PRESENT";
                AverageSectionLabel.Value = "MOYENNE>=10";
                PassedSectionLabel.Value = "% DE REUSSITE";
                DeanStudiesTextBox.Value = "Le Prefet des Etudes";
                HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("head_paper_fr.png");
                ReportTitleStatisticTextBox.Value = "STATISTIQUES";
            }
            else
            {
                ClassroomSizeSectionLabel.Value = "CLASSROOM SIZE";
                PresentSectionLabel.Value = "PRESENT";
                AverageSectionLabel.Value = "AVERAGE>=10";
                PassedSectionLabel.Value = "% PASSED";
                DeanStudiesTextBox.Value = "The Dean of Studies";
                ReportTitleStatisticTextBox.Value = "STATISTICS";
                HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("head_paper_en.png");
            }

            this.ClassroomSizeSectionFemalTextBox.Value= report.FooterSection.Items.FirstOrDefault(x => x.Name == "ClassroomSizeFemale").Value;
            this.ClassroomSizeSectionMalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "ClassroomSizeMale").Value;
            this.ClassroomSizeSectionTotalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "ClassroomSizeTotal").Value;
            this.PresentSectionMalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "EvaluatedMale").Value;
            this.PresentSectionFemalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "EvaluatedFemale").Value;
            this.PresentSectionTotalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "EvaluatedTotal").Value;
            this.AverageSectionMalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "AverageMale").Value;
            this.AverageSectionFemalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "AverageFemale").Value;
            this.AverageSectionTotalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "AverageTotal").Value;
            this.PassedSectionMalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "PassedMale").Value;
            this.PassedSectionFemalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "PassedFemale").Value;
            this.PassedSectionTotalTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "PassedTotal").Value;
            this.ClassroomSizeSectionDescriptionTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "ClassroomSizeDescription").Value;
            this.GeneralAverageTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "GeneralAverage").Value;
            this.LowestAverageTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "LowestAverage").Value;
            this.HighestAverageTextBox.Value = report.FooterSection.Items.FirstOrDefault(x => x.Name == "HighestAverage").Value;
        }
    }
}
