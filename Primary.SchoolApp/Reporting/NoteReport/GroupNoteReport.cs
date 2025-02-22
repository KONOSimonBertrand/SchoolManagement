using System.Linq;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;
using static Primary.SchoolApp.DTO.DTOItem;
namespace Primary.SchoolApp.Reporting
{
    internal class GroupNoteReport : SchoolManagement.UI.Reporting.GroupNoteReport
    {
        public GroupNoteReport(ClassGroupReport report) {
            this.HeaderPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            this.ReportTitleTextBox.Value = report.HeaderSection.Items.FirstOrDefault(x => x.Name == "ReportTitle").Value;
            this.SchoolYearTextBox.Value = report.HeaderSection.Items.FirstOrDefault(x => x.Name == "SchoolYear").Value;
            this.GroupTextBox.Value = report.HeaderSection.Items.FirstOrDefault(x => x.Name == "ClassGroup").Value;

            this.ReportTable.ColumnGroups.Clear();
            this.ReportTable.Body.Columns.Clear();
            this.ReportTable.Body.Rows.Clear();
            for (int i = 0; i < report.HeaderSection.Columns.Count; i++)
            {
                TableGroup tableGroupColumn = new();
                this.ReportTable.ColumnGroups.Add(tableGroupColumn);
                tableGroupColumn.Name = i.ToString();
                var textboxGroup = new TextBox();
                textboxGroup.StyleName = "BlueOpal.TableHeader";
                textboxGroup.Value = report.HeaderSection.Columns[i];
                var textBoxTable = new TextBox();
                textBoxTable.Value = "=Fields." + report.DetailSection.DataTable.Columns[i].ColumnName;
                textBoxTable.StyleName = "BlueOpal.TableBody";
                Telerik.Reporting.Drawing.FormattingRule formattingRuleTotal = new Telerik.Reporting.Drawing.FormattingRule();
                formattingRuleTotal.Filters.Add(new Telerik.Reporting.Filter("=Fields.Classroom", Telerik.Reporting.FilterOperator.Equal, "TOTAL"));
                formattingRuleTotal.Style.Font.Bold = true;
                textBoxTable.ConditionalFormatting.Add(formattingRuleTotal);
                ReportTable.Body.SetCellContent(0, i, textBoxTable);

                if (i == 0)
                {
                    textboxGroup.Size = new SizeU(Unit.Inch(0.308D), Unit.Inch(1.943D));
                    textBoxTable.Size = new SizeU(Unit.Inch(0.308D), Unit.Inch(0.2D));
                }
                else
                {
                    if (i == 1)
                    {
                        textboxGroup.Size = new SizeU(Unit.Inch(1.200D), Unit.Inch(0.943D));
                        textBoxTable.Size = new SizeU(Unit.Inch(1.200D), Unit.Inch(0.2D));
                    }
                    else
                    {
                        textBoxTable.Size = new SizeU(Unit.Inch(0.450D), Unit.Inch(0.2D));
                        textboxGroup.Angle = 270D;
                        textboxGroup.Size = new SizeU(Unit.Inch(0.181D), Unit.Inch(1.943D));
                    }
                }
              
                tableGroupColumn.ReportItem = textboxGroup;

                ReportTable.Items.AddRange(new ReportItemBase[] { textBoxTable, textboxGroup });
            }
            ReportTable.DataSource = report.DetailSection.DataTable;
            if (report.HeaderSection.Items.FirstOrDefault(x => x.Name == "Language").Value == "FR")
            {
                DeanStudiesTextBox.Value = "Le Prefet des Etudes";
                HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("head_paper_fr.png");
            }
            else
            {
                DeanStudiesTextBox.Value = "The Dean of Studies";
                HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("head_paper_en.png");
            }
        }
    }
}
