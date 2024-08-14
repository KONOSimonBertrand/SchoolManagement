using SchoolManagement.UI.Utilities;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.ComponentModel;
using Telerik.WinControls.Data;

namespace SchoolManagement.UI
{
    public partial class MainForm
    {
        public RadDropDownList EmployeeSchoolYearDropDownList { get => employeeSchoolYearDropDownList; }
        public RadButton EmployeeEnrollingAddButton { get => employeeAddButton; }
        public RadButton EmployeeExportToExcelButton { get => employeeExportToExcelButton; }
        public RadToggleButton EmployeeIconViewToggleButton { get => employeeIconViewToggleButton; }
        public RadToggleButton EmployeeListViewToggleButton { get => employeeListViewToggleButton; }
        public CustomControls.SearchTextBox EmployeeSearchTextBox { get => employeeSearchTextBox; }
        public RadListView EmployeeLeftListView { get => employeeLeftListView; }
        public RadListView EmployeeMainListView { get => employeeMainListView; }
        public RadPanel EmployeeInfoRightPanel { get => employeeInfoRightPanel; }
        public RadGridView EmployeeGridView { get => employeeGridView; }
        private void InitEmployeePage()
        {
            InitComponentEmployeePage();

            InitEventsEmployeePage();

        }

        private void InitComponentEmployeePage()
        {
            employeeMainPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            employeeMainPanel.BackgroundImage = Resources.Background;
            employeeMainPanel.BackgroundImageLayout = ImageLayout.Stretch;
            employeeMainPanel.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;

            employeeNavigationPanel.BackgroundImage = Resources.fasha_no_borders;
            employeeNavigationPanel.BackgroundImageLayout = ImageLayout.Stretch;
            employeeNavigationPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            employeeNavigationPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            employeeNavigationPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;

            employeeSearchPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            employeeSearchPanel.BackColor = Color.Transparent;
            employeeSearchPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

            employeeSearchPanel.RootElement.EnableElementShadow = false;
            employeeEmptyPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            employeeEmptyPanel.BackColor = Color.Transparent;
            employeeEmptyPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

            employeeAddButton.ButtonElement.ToolTipText = "Cliquer ici pour inscrire un employé";
            employeeAddButton.TextAlignment = ContentAlignment.MiddleCenter;

            employeeExportToExcelButton.TextAlignment = ContentAlignment.MiddleCenter;
            employeeExportToExcelButton.ButtonElement.ToolTipText = "Cliquer ici pour exporter les données vers excel";

            employeeSearchTextBox.NullText = "Rechercher par Matricule, par Nom,par groupe";
            employeeIconViewToggleButton.ButtonElement.ToolTipText = "Vue grille";
            employeeIconViewToggleButton.RootElement.EnableElementShadow = false;
            employeeIconViewToggleButton.ButtonElement.Padding = new Padding(0);
            employeeIconViewToggleButton.ImageAlignment = ContentAlignment.MiddleCenter;
            employeeIconViewToggleButton.TextAlignment = ContentAlignment.MiddleCenter;
            employeeIconViewToggleButton.RootElement.CustomFont = "TelerikWebUI";
            employeeIconViewToggleButton.Text = "\ue023";
            employeeIconViewToggleButton.RootElement.CustomFontSize = 20;

            employeeListViewToggleButton.ButtonElement.ToolTipText = "Affichage Liste";
            employeeListViewToggleButton.RootElement.EnableElementShadow = false;
            employeeListViewToggleButton.ButtonElement.Padding = new Padding(0);
            employeeListViewToggleButton.ImageAlignment = ContentAlignment.MiddleCenter;
            employeeListViewToggleButton.TextAlignment = ContentAlignment.MiddleCenter;
            employeeListViewToggleButton.RootElement.CustomFont = "TelerikWebUI";
            employeeListViewToggleButton.RootElement.CustomFontSize = 20;
            employeeListViewToggleButton.Text = "\ue024";

            employeeLeftListView.ShowGroups = true;
            employeeLeftListView.EnableGrouping = true;
            employeeLeftListView.EnableCustomGrouping = true;
            employeeLeftListView.ShowCheckBoxes = true;
            employeeLeftListView.AllowEdit = false;
            employeeLeftListView.RootElement.EnableElementShadow = false;
            employeeLeftListView.HotTracking = false;
            employeeLeftListView.ListViewElement.Padding = new Padding(0, 16, 0, 0);

            employeeSchoolYearDropDownList.RootElement.EnableElementShadow = false;
            employeeSchoolYearDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            employeeSchoolYearDropDownList.RootElement.CustomFontSize = 10.5f;
            employeeSchoolYearDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            employeeSchoolYearDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            employeeSchoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            employeeSchoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            employeeSchoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            employeeSchoolYearLabel.TextAlignment = ContentAlignment.BottomCenter;

            employeeGridView.TableElement.CellSpacing = 10;
            employeeGridView.RootElement.EnableElementShadow = false;
            employeeGridView.GridViewElement.DrawFill = false;
            employeeGridView.TableElement.Margin = new Padding(15, 0, 15, 0);
            employeeGridView.BackColor = Color.Transparent;
            employeeGridView.GridViewElement.DrawFill = true;
            employeeGridView.AllowAddNewRow = false;
            employeeGridView.EnableGrouping = false;

            employeeMainListView.ShowGroups = true;
            employeeMainListView.EnableGrouping = true;
            employeeMainListView.ViewType = ListViewType.IconsView;
            employeeMainListView.ItemSize = new Size(200, 120);
            employeeMainListView.ItemSpacing = 10;
            employeeMainListView.AllowEdit = false;
            employeeMainListView.EnableFiltering = true;
            employeeMainListView.HotTracking = false;

            employeeMainListView.RootElement.BackColor = Color.Transparent;
            employeeMainListView.BackColor = Color.Transparent;
            employeeMainListView.ListViewElement.DrawFill = false;
            employeeMainListView.ListViewElement.ViewElement.BackColor = Color.Transparent;
            employeeMainListView.ListViewElement.Padding = new Padding(-9, 0, 0, 0);
            employeeMainListView.RootElement.EnableElementShadow = false;         

            employeeInfoRightPanel.RootElement.EnableElementShadow = false;
            employeeEmptyPanel.RootElement.EnableElementShadow = false;
        }

        private void InitEventsEmployeePage()
        {
            employeeMainListView.VisualItemFormatting += EmployeeMainListView_VisualItemFormatting;
        }     
        private void EmployeeMainListView_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {
            IconListViewGroupVisualItem groupItem = e.VisualItem as IconListViewGroupVisualItem;
            try
            {
                if (groupItem != null)
                {
                    if (groupItem.HasVisibleItems())
                    {
                        groupItem.Visibility = ElementVisibility.Visible;
                    }
                    else
                    {
                        groupItem.Visibility = ElementVisibility.Collapsed;
                    }
                    e.VisualItem.CustomFont = ViewUtilities.MainFont;
                    e.VisualItem.CustomFontSize = 15;
                    e.VisualItem.CustomFontStyle = FontStyle.Regular;
                    groupItem.ToggleElement.Visibility = ElementVisibility.Collapsed;
                    e.VisualItem.ShowHorizontalLine = false;
                    e.VisualItem.Padding = new Padding(20, 0, 0, 0);
                    e.VisualItem.TextAlignment = ContentAlignment.BottomLeft;
                    e.VisualItem.EnableElementShadow = false;
                }
                else
                {
                    e.VisualItem.EnableElementShadow = true;
                    e.VisualItem.ShadowDepth = 1;
                    e.VisualItem.Padding = new Padding(0);
                    e.VisualItem.ResetValue(LightVisualElement.TextAlignmentProperty, Telerik.WinControls.ValueResetFlags.Local);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
