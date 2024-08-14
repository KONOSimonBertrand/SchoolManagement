using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System.Threading;
using System.Windows.Forms;
using System;
using Telerik.WinControls.UI;
using Telerik.WinControls;
namespace Primary.SchoolApp.UI
{
    public partial class ClassSubjectsForm : SchoolManagement.UI.ClassSubjectsForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolClassService schoolClassService;
        private readonly ISubjectService subjectService;
        private SchoolClass selectedClass;

        public ClassSubjectsForm(ISchoolClassService schoolClassService, ISubjectService subjectService, ILogService logService, ClientApp clientApp)
        {
            this.logService = logService;
            this.clientApp = clientApp;
            this.subjectService = subjectService;
            this.schoolClassService = schoolClassService;
            InitEvents();
            InitCommandButton();
        }
        private void InitCommandButton()
        {

            this.PrintButton.Image = AppUtilities.GetImage("Printer");
            this.ExportToExcelButton.Image = AppUtilities.GetImage("Excel");
            this.AddSubjectButton.Image = AppUtilities.GetImage("Add");

        }
        private void InitEvents()
        {
            PrintButton.Click += PrintButton_Click;
            DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            DataGridView.ContextMenuOpening += DataGridView_ContextMenuOpening;
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            this.AddSubjectButton.Click += AddSubjectButton_Click;
            DataGridView.ToolTipTextNeeded += DataGridView_ToolTipTextNeeded;
            ExportToExcelButton.Click += ExportCommandBarButton_Click;
            PrintButton.Click += PrintCommandBarButton_Click;
        }

        private void PrintCommandBarButton_Click(object sender, EventArgs e)
        {
            AppUtilities.PrintGridView(DataGridView, Language.titleSubjectList);
        }

        private void ExportCommandBarButton_Click(object sender, EventArgs e)
        {
            AppUtilities.ExportGridViewToExcel(DataGridView, Language.titleSubjectList);
        }
        private void DataGridView_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            GridDataCellElement cell = sender as GridDataCellElement;
            if (cell != null)
            {
                if (cell.RowElement.Data.DataBoundItem is ClassSubject record)
                {
                    if (cell.ColumnInfo.Name == Language.fieldSubjectName)
                    {
                        e.ToolTipText = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Version anglaise: " + record.Subject.EnglishName : "French version: " + record.Subject.FrenchName; ;
                    }
                    else
                    {
                        if (cell.ColumnInfo.Name == Language.fieldGroupName)
                        {
                            e.ToolTipText = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Version anglaise: " + record.Group.EnglishName : "French version: " + record.Group.FrenchName; ;
                        }
                    }
                }

            }

        }

        private void DataGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            RadMenuItem menuDelete = new(Language.labelDelete);
            RadMenuItem menuEdit = new(Language.labelEdit);
            menuDelete.Image = AppUtilities.GetImage("Delete");
            menuEdit.Image = AppUtilities.GetImage("Edit");
            menuEdit.Click += MenuEdit_Click;
            menuDelete.Click += MenuDelete_Click;
            e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
            e.ContextMenu.Items.Add(menuEdit);
            e.ContextMenu.Items.Add(menuDelete);

        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            var record = DataGridView.CurrentRow.DataBoundItem as ClassSubject;
            if (record != null)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmDelete, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var isDone = schoolClassService.DeleteClassSubject(record.ClassId, record.SubjectId, record.BookId).Result;
                    if (isDone)
                    {
                        LoadDataToGridView();
                    }
                    else
                    {
                        RadMessageBox.Show(Language.messageDeleteError);
                    }
                }

            }

        }

        private void MenuEdit_Click(object sender, EventArgs e)
        {
            var record = DataGridView.CurrentRow.DataBoundItem as ClassSubject;
            if (record != null)
            {
                var form = Program.ServiceProvider.GetService<EditClassSubjectForm>();
                form.Icon = this.Icon;
                form.Init(selectedClass, record);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    LoadDataToGridView();
                }
            }
        }

        private void AddSubjectButton_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetService<AddClassSubjectForm>();
            form.Icon = this.Icon;
            form.Init(selectedClass);
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                LoadDataToGridView();
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridView.MasterTemplate.Refresh();
        }

        private void DataGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;

            if (SearchTextBox.Text != null)
            {

                e.Visible &= e.Row.Cells[Language.fieldSubjectName].Value.ToString().ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                    e.Row.Cells[Language.fieldGroupName].Value.ToString().ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["Coefficient"].Value.ToString().ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["NotedOn"].Value.ToString().ToLower().Contains(SearchTextBox.Text.ToLower());
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(ClientSize);
            RadPrintDocument printer = new();
            printer.Landscape = true;
            printer.Margins.Right = 50;
            printer.Margins.Left = 50;
            printer.Margins.Top = 50;
            printer.Margins.Bottom = 50;
            printer.LeftHeader = "";
            printer.MiddleHeader = ClassLabel.Text.ToUpper() + ":. LISTE DES MATIERES ENSEIGNEES";
            printer.RightFooter = "Date d'impression: [Date Printed]" + " [Time Printed]";
            printer.LeftFooter = "Page [Page #] sur [Total Pages]";

            RadPrintPreviewDialog dialog = new();
            printer.AssociatedObject = DataGridView;
            dialog.ThemeName = this.Text;
            dialog.Document = printer;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
        }

        internal void Init(SchoolClass selectedClass)
        {
            this.selectedClass = selectedClass;
            CreateGridViewColumn();
            if (selectedClass != null)
            {
                ClassLabel.Text = selectedClass.Name;
                this.Text = selectedClass.Name + $":. {this.Text = Language.titleSubjectList.ToUpper()}";
                LoadDataToGridView();
            }
        }
        private async void LoadDataToGridView()
        {
            var dataList = await schoolClassService.GetClassSubjectList(selectedClass.Id);
            DataGridView.DataSource = dataList;
        }
        private void CreateGridViewColumn()
        {
            GridViewTextBoxColumn subjectColumn = new GridViewTextBoxColumn(Language.fieldSubjectName);
            GridViewTextBoxColumn fullNameColumn = new GridViewTextBoxColumn("Subject.FullName");
            GridViewTextBoxColumn groupColumn = new GridViewTextBoxColumn(Language.fieldGroupName);
            GridViewDecimalColumn coefColumn = new GridViewDecimalColumn("Coefficient");
            GridViewDecimalColumn noteOnColumn = new GridViewDecimalColumn("NotedOn");
            GridViewDecimalColumn sequenceColumn = new GridViewDecimalColumn("Sequence");
            GridViewTextBoxColumn sectionColumn = new GridViewTextBoxColumn("BookName");
            subjectColumn.HeaderText = Language.labelSubject; //= "Matière";
            coefColumn.HeaderText = "Coef";
            sequenceColumn.HeaderText = Language.labelSequence;
            noteOnColumn.HeaderText = Language.labelMaxNote;
            groupColumn.HeaderText = Language.labelGroup;
            fullNameColumn.HeaderText = Language.labelFullName;
            sectionColumn.HeaderText = (Language.labelSection);
            coefColumn.Width = 80;
            subjectColumn.Width = 200;
            groupColumn.Width = 250;
            noteOnColumn.Width = 90;
            sectionColumn.Width = 120;
            fullNameColumn.Width = 200;
            this.DataGridView.Columns.Add(subjectColumn);
            this.DataGridView.Columns.Add(fullNameColumn);
            this.DataGridView.Columns.Add(groupColumn);
            this.DataGridView.Columns.Add(coefColumn);
            this.DataGridView.Columns.Add(noteOnColumn);
            this.DataGridView.Columns.Add(sequenceColumn);
            if (selectedClass.BookTypeId == 2)
                this.DataGridView.Columns.Add(sectionColumn);
        }

    }
}