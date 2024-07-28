using SchoolManagement.UI.Languages;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.Windows.Documents.Fixed.Model.Objects;

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
            InitializeComponent();
            this.logService = logService;
            this.clientApp = clientApp;
            this.subjectService = subjectService;
            this.schoolClassService = schoolClassService;
            CreateGridViewColumn();
            InitEvents();
        }

        private void InitEvents()
        {
            PrintButton.Click += PrintButton_Click;
            DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
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
            ClientSize = new System.Drawing.Size(900, 600);
            this.selectedClass = selectedClass;
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
            GridViewTextBoxColumn groupColumn = new GridViewTextBoxColumn(Language.fieldGroupName);
            GridViewDecimalColumn coefColumn = new GridViewDecimalColumn("Coefficient");
            GridViewDecimalColumn noteOnColumn = new GridViewDecimalColumn("NotedOn");
            GridViewDecimalColumn sequenceColumn = new GridViewDecimalColumn("Sequence");
            subjectColumn.HeaderText=Language.labelSubject  ; //= "Matière";
            coefColumn.HeaderText = "Coef";
            sequenceColumn.HeaderText = Language.labelSequence;
            noteOnColumn.HeaderText = Language.labelMaxNote;
            groupColumn.HeaderText = Language.labelGroup;
            coefColumn.Width = 80;
            subjectColumn.Width = 200;
            groupColumn.Width = 250;
            noteOnColumn.Width = 90;

            this.DataGridView.Columns.Add(subjectColumn);
            this.DataGridView.Columns.Add(groupColumn);
            this.DataGridView.Columns.Add(coefColumn);
            this.DataGridView.Columns.Add(noteOnColumn);
            this.DataGridView.Columns.Add(sequenceColumn);
        }
   
     
    }
}
