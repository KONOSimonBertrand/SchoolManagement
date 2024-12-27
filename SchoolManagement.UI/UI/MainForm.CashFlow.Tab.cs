using SchoolManagement.UI.CustomControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class MainForm
    {
        public RadDropDownList CashFlowSchoolYearDropDownList { get => cashFlowSchoolYearDropDownList; }
        public RadListView CashFlowLeftListView { get => cashFlowLeftListView; }
        public RadGridView CashFlowGridView {  get => cashFlowGridView; }
        public RadButton CashFlowExportToExcelButton { get => cashFlowExportToExcelButton; }
        public SearchTextBox CashFlowSearchTextBox {  get => cashFlowSearchTextBox; }
        public RadButton CashFlowAddButton {  get => cashFlowAddButton; }
        private void InitCashFlowPage()
        {
           
            cashFlowMainPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            cashFlowNavigationPanel.BackgroundImage = Resources.fasha_no_borders;
            cashFlowNavigationPanel.BackgroundImageLayout = ImageLayout.Stretch;
            cashFlowNavigationPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            cashFlowSearchPanel.RootElement.EnableElementShadow = false;
            cashFlowNavigationPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            cashFlowNavigationPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            cashFlowSearchPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            cashFlowSearchPanel.BackColor = Color.Transparent;
            cashFlowSearchPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            cashFlowEmptyPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            cashFlowEmptyPanel.BackColor = Color.Transparent;
            cashFlowEmptyPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            cashFlowEmptyPanel.RootElement.EnableElementShadow = false;

            cashFlowLeftListView.ShowGroups = true;
            cashFlowLeftListView.EnableGrouping = true;
            cashFlowLeftListView.EnableCustomGrouping = true;
            cashFlowLeftListView.ShowCheckBoxes = true;
            cashFlowLeftListView.AllowEdit = false;
            cashFlowLeftListView.RootElement.EnableElementShadow = false;
            cashFlowLeftListView.HotTracking = false;
            cashFlowLeftListView.ListViewElement.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);

            cashFlowSchoolYearDropDownList.RootElement.EnableElementShadow = false;
            cashFlowSchoolYearDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            cashFlowSchoolYearDropDownList.RootElement.CustomFontSize = 10.5f;
            cashFlowSchoolYearDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            cashFlowSchoolYearDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            cashFlowSchoolYearLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            cashFlowSchoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            cashFlowSchoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);

            cashFlowGridView.TableElement.CellSpacing = 10;
            cashFlowGridView.RootElement.EnableElementShadow = false;
            cashFlowGridView.GridViewElement.DrawFill = false;
            cashFlowGridView.TableElement.Margin = new Padding(15, 0, 15, 0);
            cashFlowGridView.BackColor = Color.Transparent;
            cashFlowGridView.GridViewElement.DrawFill = true;
            cashFlowGridView.AllowAddNewRow = false;
            cashFlowGridView.EnableGrouping = false;

            cashFlowMainPanel.BackgroundImage = Resources.Background;
            cashFlowMainPanel.BackgroundImageLayout = ImageLayout.Stretch;
            cashFlowMainPanel.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;
            cashFlowInfoRightPanel.RootElement.EnableElementShadow = false;
            cashFlowInfoRightPanel.Visible = false;

            cashFlowExportToExcelButton.ImageAlignment = ContentAlignment.MiddleCenter;
            cashFlowExportToExcelButton.TextAlignment = ContentAlignment.MiddleCenter;

            cashFlowSearchTextBox.NullText = "Rechercher par Référence, par Motif, par Ordonateur,par Type";
            cashFlowAddButton.ButtonElement.ToolTipText = "Cliquer ici pour ajouter un flux de trésorerie";
            cashFlowExportToExcelButton.ButtonElement.ToolTipText = "Cliquer ici pour exporter les données vers excel";
        }
    }
}
