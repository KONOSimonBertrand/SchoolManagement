
using SchoolManagement.UI.Localization;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{/// <summary>
 /// Interface utilisateur de la gestion des matières d'une classe
 /// Ajout des matières, avec coeficient et note max
 /// </summary>
    public partial class ClassSubjectsForm : RadForm
    {
        public CommandBarLabel ClassLabel { get => classLabel; }
        public CommandBarButton PrintButton { get => printCommandBarButton; }
        public CommandBarButton ExportToExcelButton { get => exportCommandBarButton; }
        public CommandBarButton AddSubjectButton { get => addSubjectCommandBarButton; }
        public CommandBarTextBox SearchTextBox { get => searchCommandBarTextBox; }

        public RadGridView DataGridView { get => dataGridView; }
        public ClassSubjectsForm()
        {
            InitializeComponent();
            InitComponent();
            InitLanguage();
        }
        private void InitComponent()
        {
            this.addSubjectCommandBarButton.ToolTipText = "Cliquer ici pour ajouter une nouvelle matière";
            this.dataPanel.RootElement.EnableElementShadow = false;

            printCommandBarButton.Image = Resources.print;
            addSubjectCommandBarButton.Image = Resources.plus;
            exportCommandBarButton.Image=Resources.excel;
            foreach (RadControl c in this.dataPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.dataGridView.MasterTemplate.EnableFiltering = true;
            this.dataGridView.EnableCustomFiltering = true;
            this.dataGridView.ReadOnly = true;
            this.dataGridView.AllowColumnReorder = false;
            this.dataGridView.AllowRowReorder = true;
            this.dataGridView.ShowGroupPanel = false;
            this.dataGridView.AllowAddNewRow = false;
            this.dataGridView.AllowDragToGroup = false;
            this.dataGridView.ShowFilteringRow = false;
            this.dataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoGenerateColumns = false;
            foreach (GridViewDataColumn col in this.dataGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
        }
        private void InitLanguage()
        {
            addSubjectCommandBarButton.ToolTipText = Language.messageClickToAddSubject;
            printCommandBarButton.ToolTipText = Language.messageClickToPrint;
            exportCommandBarButton.ToolTipText= Language.messageClickToExport;
            searchCommandBarTextBox.ToolTipText = Language.messageResearch;
            searchCommandBarTextBox.NullText = Language.messageResearch;
        }


    }
}
