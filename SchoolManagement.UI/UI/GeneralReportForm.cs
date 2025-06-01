
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class GeneralReportForm : RadForm
    {
        public CommandBarLabel TitleLabel { get => titleLabel; }
        public CommandBarButton PrintButton { get => printButton; }
        public CommandBarButton ExportButton { get => exportButton; }
        public CommandBarToggleButton IconViewToggleButton { get => iconViewToggleButton; }
        public CommandBarToggleButton ListViewToggleButton {  get => listViewToggleButton; }
        public RadGridView ReportGrid { get => reportGrid; }
        public GeneralReportForm()
        {
            InitializeComponent();
            InitComponent();
            InitLanguage(); 
        }
        private void InitComponent()
        {
            exportButton.DrawText = false;
            printButton.DrawText = false;
            exportButton.Image = ViewUtilities.GetImage("Excel");
            printButton.Image = ViewUtilities.GetImage("Printer");
            iconViewToggleButton.CustomFont = "TelerikWebUI";
            listViewToggleButton.CustomFont = "TelerikWebUI";
            iconViewToggleButton.Text = "\ue025";
            listViewToggleButton.Text= "\ue024";
            this.reportGrid.ReadOnly = true;
            this.reportGrid.EnableFiltering = true;
            this.reportGrid.ShowFilteringRow = true;

        }

        private void InitLanguage()
        {
            exportButton.ToolTipText=Language.messageClickToExport;
            printButton.ToolTipText = Language.messageClickToPrint;
            listViewToggleButton.ToolTipText=Language.LabelDetailView;
            iconViewToggleButton.ToolTipText = Language.LabelGroupView;
        }
    }
}
