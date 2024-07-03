using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class MainForm
    {
        private void InitReportsPage()
        {
            reportMainPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            reportMainPanel.BackgroundImage = Resources.Background;
            reportMainPanel.BackgroundImageLayout = ImageLayout.Stretch;
            reportMainPanel.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;

            reportNavigationPanel.BackgroundImage = Resources.fasha_no_borders;
            reportNavigationPanel.BackgroundImageLayout = ImageLayout.Stretch;
            reportNavigationPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            reportNavigationPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            reportNavigationPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            reportSearchPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            reportSearchPanel.BackColor = Color.Transparent;
            reportSearchPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            reportSearchPanel.RootElement.EnableElementShadow = false;
            reportEmptyPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            reportEmptyPanel.BackColor = Color.Transparent;
            reportEmptyPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            reportEmptyPanel.RootElement.EnableElementShadow = false;

            reportMainListView.ShowGroups = true;
            reportMainListView.EnableGrouping = true;          
            reportMainListView.ViewType = ListViewType.IconsView;
            reportMainListView.ItemSize = new Size(200, 120);
            reportMainListView.ItemSpacing = 10;
            reportMainListView.AllowEdit = false;
            reportMainListView.EnableFiltering = true;
            reportMainListView.HotTracking = false;
            reportMainListView.EnableColumnSort = true;
            reportMainListView.EnableSorting = true;
            reportMainListView.FullRowSelect = false;
            reportMainListView.AllowArbitraryItemHeight = true;
            reportMainListView.AllowEdit = false;

            reportMainListView.AllowRemove = false;
            reportMainListView.ViewType = ListViewType.IconsView;
            reportMainListView.RootElement.BackColor = Color.Transparent;
            reportMainListView.BackColor = Color.Transparent;
            reportMainListView.ListViewElement.DrawFill = false;
            reportMainListView.ListViewElement.ViewElement.BackColor = Color.Transparent;
            reportMainListView.ListViewElement.Padding = new Padding(-9, 0, 0, 0);
            reportMainListView.RootElement.EnableElementShadow = false;

            reportLeftListView.ShowGroups = true;
            reportLeftListView.EnableGrouping = true;
            reportLeftListView.EnableCustomGrouping = true;
            reportLeftListView.AllowEdit = false;
            reportLeftListView.RootElement.EnableElementShadow = false;
            reportLeftListView.HotTracking = false;
            reportLeftListView.ListViewElement.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);

            reportSchoolYearDropDownList.RootElement.EnableElementShadow = false;
            reportSchoolYearDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            reportSchoolYearDropDownList.RootElement.CustomFontSize = 10.5f;
            reportSchoolYearDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            reportSchoolYearDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            reportSchoolYearLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            reportSchoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            reportSchoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);

            reportSearchTextBox.NullText = "Rechercher par Nom, par Domaine par Description.";

    }
}
}
