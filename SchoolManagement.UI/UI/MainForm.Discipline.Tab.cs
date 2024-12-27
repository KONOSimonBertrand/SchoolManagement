using SchoolManagement.UI.CustomControls;
using SchoolManagement.UI.Localization;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class MainForm
    {
        public RadDropDownList DisciplineSchoolYearDropDownList { get => disciplineSchoolYearDropDownList; }
        public SearchTextBox DisciplineSearchTextBox { get => disciplineSearchTextBox; }
        public RadDropDownList DisciplineSearchDropDownList { get => disciplineSearchDropDownList; }
        public RadButton DisciplineAddButton { get => disciplineAddButton; }
        public RadButton DisciplineExportToExcelButton { get=> disciplineExportToExcelButton; }
        public RadGridView DisciplineGridView { get => disciplineGridView; }
        public RadListView DisciplineLeftListView {  get => disciplineLeftListView; }
        private void InitDisciplinePage()
        {

            disciplineMainPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            disciplineNavigationPanel.BackgroundImage = Resources.fasha_no_borders;
            disciplineNavigationPanel.BackgroundImageLayout = ImageLayout.Stretch;
            disciplineNavigationPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            disciplineSearchPanel.RootElement.EnableElementShadow = false;
            disciplineNavigationPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            disciplineNavigationPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            disciplineSearchPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            disciplineSearchPanel.BackColor = Color.Transparent;
            disciplineSearchPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            disciplineEmptyPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            disciplineEmptyPanel.BackColor = Color.Transparent;
            disciplineEmptyPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            disciplineEmptyPanel.RootElement.EnableElementShadow = false;

            disciplineLeftListView.ShowGroups = true;
            disciplineLeftListView.EnableGrouping = true;
            disciplineLeftListView.EnableCustomGrouping = true;
            disciplineLeftListView.ShowCheckBoxes = true;
            disciplineLeftListView.AllowEdit = false;
            disciplineLeftListView.RootElement.EnableElementShadow = false;
            disciplineLeftListView.HotTracking = false;
            disciplineLeftListView.ListViewElement.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);

            disciplineSchoolYearDropDownList.RootElement.EnableElementShadow = false;
            disciplineSchoolYearDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            disciplineSchoolYearDropDownList.RootElement.CustomFontSize = 10.5f;
            disciplineSchoolYearDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            disciplineSchoolYearDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            disciplineSchoolYearLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            disciplineSchoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            disciplineSchoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);

            disciplineGridView.TableElement.CellSpacing = 10;
            disciplineGridView.RootElement.EnableElementShadow = false;
            disciplineGridView.GridViewElement.DrawFill = false;
            disciplineGridView.TableElement.Margin = new Padding(15, 0, 15, 0);
            disciplineGridView.BackColor = Color.Transparent;
            disciplineGridView.GridViewElement.DrawFill = true;
            disciplineGridView.AllowAddNewRow = false;
            disciplineGridView.EnableGrouping = false;

            disciplineMainPanel.BackgroundImage = Resources.Background;
            disciplineMainPanel.BackgroundImageLayout = ImageLayout.Stretch;
            disciplineMainPanel.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;

            disciplineExportToExcelButton.ImageAlignment = ContentAlignment.MiddleCenter;
            disciplineExportToExcelButton.TextAlignment = ContentAlignment.MiddleCenter;

            disciplineSearchTextBox.NullText = $"{Language.MessageSearchBy}";
            disciplineAddButton.ButtonElement.ToolTipText = Language.messageClickToAdd;
            disciplineExportToExcelButton.ButtonElement.ToolTipText = Language.messageClickToExport;
            disciplineSearchDropDownList.RootElement.ToolTipText=Language.MessageFindClass;
            disciplineSearchDropDownList.NullText = Language.MessageFindClass;
        }
    }
}
