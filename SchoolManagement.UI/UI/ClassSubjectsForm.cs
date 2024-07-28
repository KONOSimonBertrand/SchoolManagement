
using SchoolManagement.UI.Languages;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace SchoolManagement.UI
{/// <summary>
 /// Interface utilisateur de la gestion des matières d'une classe
 /// Ajout des matières, des coeficients des notes max
 /// </summary>
    public partial class ClassSubjectsForm : RadForm
    {
        private SaveFileDialog saveFileDialog;
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
            InitEvent();
            InitLanguage();
        }
        private void InitComponent()
        {
            this.addSubjectCommandBarButton.ToolTipText = "Cliquer ici pour ajouter une nouvelle matière";
            saveFileDialog = new SaveFileDialog();
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
        private void InitEvent()
        {
            this.exportCommandBarButton.Click += ExportCommandBarButton_Click;
        }

        private void ExportCommandBarButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel (*.xls;*xlsx)|*.xls;*.xlsx";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.Show("Entrer le nom du fichier.");
                return;
            }
            string fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;
            ExportToExcel(fileName, ref openExportFile, dataGridView);

            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            };
        }
        private void ExportToExcel(string fileName, ref bool openExportFile, RadGridView gridView)
        {
            ExportToExcelML excelExporter = new (gridView);
            excelExporter.SheetName = "DATA";

            excelExporter.SummariesExportOption = SummariesOption.DoNotExport;
            //modification du nombre de lignes 
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            //excelExporter.SheetMaxRows = ExcelMaxRows._65536;
            //modification du visual setting            
            excelExporter.ExportVisualSettings = true;
            try
            {
                excelExporter.RunExport(fileName);
                DialogResult dr = RadMessageBox.Show("Expotation effectuée avec succès", "Exportation", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
            }
            catch (IOException ex)
            {
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
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
