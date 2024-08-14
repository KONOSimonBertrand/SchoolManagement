

using Primary.SchoolApp.DTO;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;

namespace Primary.SchoolApp.Reporting
{
    /// <summary>
    /// Summary description for ClassNoteReportEmpty.
    /// </summary>
    public partial class ClassNoteReportEmpty : Report
    {
        public ClassNoteReportEmpty()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public ClassNoteReportEmpty(ExamReport dataSource)
        {
            InitializeComponent();
           TextBox textboxGroup;
            TextBox textBoxTable;
            this.reportTable.ColumnGroups.Clear();
            this.reportTable.Body.Columns.Clear();
            this.reportTable.Body.Rows.Clear();
            int colunmCount = dataSource.DataReport.Columns.Count;
            for (int i = 0; i < colunmCount; i++)
            {
                TableGroup tableGroupColumn = new TableGroup();
                this.reportTable.ColumnGroups.Add(tableGroupColumn);
                tableGroupColumn.Name = i.ToString();
                textboxGroup = new TextBox();
                textboxGroup.StyleName = "BlueOpal.TableHeader";
                textboxGroup.Value = dataSource.LabelReport.Columns[i].ColumnName;

                textBoxTable = new TextBox();
                textBoxTable.Value = "=Fields." + dataSource.DataReport.Columns[i].ColumnName;
                textBoxTable.StyleName = "BlueOpal.TableBody";
                this.reportTable.Body.SetCellContent(0, i, textBoxTable);

                switch (i)
                {

                    case 0:
                        textboxGroup.Size = new SizeU(Unit.Inch(0.808D), Unit.Inch(1.943D));
                        textBoxTable.Size = new SizeU(Unit.Inch(0.808D), Unit.Inch(0.2D));
                        break;
                    case 1:
                        textboxGroup.Size = new SizeU(Unit.Inch(2.942D), Unit.Inch(0.943D));
                        textBoxTable.Size = new SizeU(Unit.Inch(2.942D), Unit.Inch(0.2D));
                        break;
                    default:
                        textBoxTable.Size = new SizeU(Unit.Inch(0.450D), Unit.Inch(0.2D));
                        break;
                }
                if (i > 1)
                {
                    textboxGroup.Angle = 270D;
                    textboxGroup.Size = new SizeU(Unit.Inch(0.181D), Unit.Inch(0.943D));
                }

                tableGroupColumn.ReportItem = textboxGroup;

                this.reportTable.Items.AddRange(new ReportItemBase[] { textBoxTable, textboxGroup });

            }


            this.reportTable.DataSource = dataSource.DataReport;

        }
    }
}