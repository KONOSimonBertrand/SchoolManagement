using Telerik.WinControls.Primitives;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using SchoolManagement.UI.Utilities;

namespace SchoolManagement.UI
{
    public partial class MainForm : RadForm
    {
        RadButtonElement aboutButton = new();
        RadSplitButtonElement userSplitButtonElement = new();
        RadMenuItem logoutMenuItem = new("Déconnexion");
        RadMenuItem changePasswordMenuItem = new("Changer votre mot de passe");

        #region Properties
        public RadButtonElement AboutButton { get => aboutButton; }
        public RadMenuItem LogOutMenu { get => logoutMenuItem; }
        public RadMenuItem ChangePasswordMenu{ get => changePasswordMenuItem; }
        public RadDropDownList HomeSchoolYearDropDownList { get=>homeSchoolYearDropDownList; }
        public RadDropDownList CashFlowSchoolYearDropDownList { get => cashFlowSchoolYearDropDownList; }
        public RadDropDownList TimeTableSchoolYearDropDownList {  get => timeTableSchoolYearDropDownList; }
        public RadDropDownList DisciplineSchoolYearDropDownList { get=>disciplineSchoolYearDropDownList;}
        public RadDropDownList StudentNoteSchoolYearDropDownList { get=>studentNoteSchoolYearDropDownList; }
        public RadDropDownList ReportSchoolYearDropDownList { get => reportSchoolYearDropDownList; }
        public RadDropDownList EmployeeSchoolYearDropDownList { get => employeeSchoolYearDropDownList;}
        #endregion

        public MainForm()
        {
            InitializeComponent();
            InitCommonComponents();
            InitHomePage();
            InitCashFlowPage();
            InitTimeTablePage();
            InitDisciplinePage();
            InitStudentNotePage();  
            InitReportsPage();
            InitEmployeePage();
            InitSettingPage();
            AdjustMainColor();
        }

        private void InitCommonComponents()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;

            RadPageViewStripElement stripElement = mainPageView.ViewElement as RadPageViewStripElement;
            RadDropDownListElement themesDropDown = new RadDropDownListElement();

            stripElement.StripButtons = ~StripViewButtons.All;
            stripElement.ItemContainer.ButtonsPanel.Children.Add(themesDropDown);
            stripElement.ItemContainer.ButtonsPanel.Children.Add(aboutButton);
            stripElement.ItemContainer.ButtonsPanel.Children.Add(userSplitButtonElement);
            themesDropDown.MinSize = new Size(200, 24);
            themesDropDown.EnableElementShadow = false;
            themesDropDown.FindDescendant<FillPrimitive>().BackColor = Color.Transparent;
            themesDropDown.DropDownStyle = RadDropDownStyle.DropDownList;
            stripElement.ItemContainer.ButtonsPanel.Margin = new Padding(0, 0, 40, 0);
            themesDropDown.Items.AddRange(new RadListDataItem[]
            {
                new RadListDataItem("Material") { Image = Resources.default_small }, new RadListDataItem("MaterialPink") { Image = Resources.pink_blue_small },
                new RadListDataItem("MaterialTeal") { Image = Resources.teal_red_small }, new RadListDataItem("MaterialBlueGrey") { Image = Resources.blue_grey_green_small }
            });
            themesDropDown.SelectedValue = "Material";
            ThemeResolutionService.ApplicationThemeName = "Material"; ;
            themesDropDown.SelectedIndexChanged += delegate (object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
            {
                if (e.Position > -1)
                {
                    ThemeResolutionService.ApplicationThemeName = themesDropDown.Items[e.Position].Text;
                    AdjustMainColor();

                }
            };
            aboutButton.FindDescendant<FillPrimitive>().BackColor = Color.Transparent;
            aboutButton.EnableElementShadow = false;
            aboutButton.Padding = new Padding(0);
            aboutButton.MinSize = new Size(24, 16);
            aboutButton.ImageAlignment = ContentAlignment.MiddleCenter;
            aboutButton.DisplayStyle = DisplayStyle.Image;
            aboutButton.Image = Resources.about;
            aboutButton.ToolTipText = "A propos de School app";
            userSplitButtonElement.FindDescendant<FillPrimitive>().BackColor = Color.Transparent;
            userSplitButtonElement.ButtonSeparator.BackColor = Color.Transparent;
            userSplitButtonElement.ActionButton.BackColor = Color.Transparent;
            userSplitButtonElement.ArrowButton.BackColor = Color.Transparent;
            userSplitButtonElement.EnableElementShadow = false;
            userSplitButtonElement.ArrowButton.EnableElementShadow = false;
            userSplitButtonElement.ActionButton.EnableElementShadow = false;
            userSplitButtonElement.ButtonSeparator.EnableElementShadow = false;
            userSplitButtonElement.ActionButton.ButtonFillElement.Visibility = ElementVisibility.Collapsed;
            userSplitButtonElement.ShowArrow = false;
            userSplitButtonElement.BackColor = Color.Transparent;
            userSplitButtonElement.Items.AddRange(new RadItem[] {
            logoutMenuItem,
            changePasswordMenuItem});
            userSplitButtonElement.ImageAlignment = ContentAlignment.MiddleCenter;
            userSplitButtonElement.DisplayStyle = DisplayStyle.Image;
            userSplitButtonElement.Padding = new Padding(0);
            userSplitButtonElement.MinSize = new Size(24, 16);
            userSplitButtonElement.Image = Resources.user_blue;
            userSplitButtonElement.ToolTipText = "Utilisateur";

            stripElement.DrawBorder = false;
            stripElement.ContentArea.DrawBorder = true;
            stripElement.ContentArea.BorderBoxStyle = BorderBoxStyle.FourBorders;
            stripElement.ContentArea.BorderLeftColor = Color.FromArgb(232, 232, 232);
            stripElement.ContentArea.BorderTopWidth = 0;
            stripElement.ContentArea.BorderBottomWidth = 0;
            stripElement.ContentArea.BorderRightWidth = 0;
            stripElement.ContentArea.Padding = new Padding(0);
        }
        private void InitHomePage()
        {
            homeMainPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            homeMainPanel.BackgroundImage = Resources.Background;
            homeMainPanel.BackgroundImageLayout = ImageLayout.Stretch;
            homeMainPanel.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;

            homeNavigationPanel.BackgroundImage = Resources.fasha_no_borders;
            homeNavigationPanel.BackgroundImageLayout = ImageLayout.Stretch;
            homeNavigationPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            homeNavigationPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            homeNavigationPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;

            homeSearchPanel.RootElement.EnableElementShadow = false;
            homeSearchPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            homeSearchPanel.BackColor = Color.Transparent;
            homeSearchPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
           
            homeEmptyPanel.RootElement.EnableElementShadow = false;
            homeEmptyPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            homeEmptyPanel.BackColor = Color.Transparent;
            homeEmptyPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

            homeAddButton.ButtonElement.ToolTipText = "Cliquer ici pour inscrire un élève";
            homeAddButton.TextAlignment = ContentAlignment.MiddleCenter;

            homeExportToExcelButton.TextAlignment = ContentAlignment.MiddleCenter;
            homeExportToExcelButton.ButtonElement.ToolTipText = "Cliquer ici pour exporter les données vers excel";

            homeSearchTextBox.NullText = "Rechercher par Matricule, par Nom, par classe,par groupe";
            homeIconViewToggleButton.ButtonElement.ToolTipText = "Vue grille";
            homeIconViewToggleButton.RootElement.EnableElementShadow = false;
            homeIconViewToggleButton.ButtonElement.Padding = new Padding(0);
            homeIconViewToggleButton.ImageAlignment = ContentAlignment.MiddleCenter;
            homeIconViewToggleButton.TextAlignment = ContentAlignment.MiddleCenter;
            homeIconViewToggleButton.RootElement.CustomFont = "TelerikWebUI";
            homeIconViewToggleButton.Text = "\ue023";
            homeIconViewToggleButton.RootElement.CustomFontSize = 20;

            homeListViewToggleButton.ButtonElement.ToolTipText = "Affichage Liste";
            homeListViewToggleButton.RootElement.EnableElementShadow = false;
            homeListViewToggleButton.ButtonElement.Padding = new Padding(0);
            homeListViewToggleButton.ImageAlignment = ContentAlignment.MiddleCenter;
            homeListViewToggleButton.TextAlignment = ContentAlignment.MiddleCenter;
            homeListViewToggleButton.RootElement.CustomFont = "TelerikWebUI";
            homeListViewToggleButton.RootElement.CustomFontSize = 20;
            homeListViewToggleButton.Text = "\ue024";

            homeLeftListView.ShowGroups = true;
            homeLeftListView.EnableGrouping = true;
            homeLeftListView.EnableCustomGrouping = true;
            homeLeftListView.ShowCheckBoxes = true;
            homeLeftListView.AllowEdit = false;
            homeLeftListView.RootElement.EnableElementShadow = false;
            homeLeftListView.HotTracking = false;
            homeLeftListView.ListViewElement.Padding = new Padding(0, 16, 0, 0);

            homeSchoolYearDropDownList.RootElement.EnableElementShadow = false;
            homeSchoolYearDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            homeSchoolYearDropDownList.RootElement.CustomFontSize = 10.5f;
            homeSchoolYearDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            homeSchoolYearDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            homeSchoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            homeSchoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            homeSchoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            homeSchoolYearLabel.TextAlignment = ContentAlignment.BottomCenter;

            homeGridView.TableElement.CellSpacing = 10;
            homeGridView.RootElement.EnableElementShadow = false;
            homeGridView.GridViewElement.DrawFill = false;
            homeGridView.TableElement.Margin = new Padding(15, 0, 15, 0);
            homeGridView.BackColor = Color.Transparent;
            homeGridView.GridViewElement.DrawFill = true;
            homeGridView.AllowAddNewRow = false;
            homeGridView.EnableGrouping = false;

            homeMainListView.ShowGroups = true;
            homeMainListView.EnableGrouping = true;
            homeMainListView.ViewType = ListViewType.IconsView;
            homeMainListView.ItemSize = new Size(200, 120);
            homeMainListView.ItemSpacing = 10;
            homeMainListView.AllowEdit = false;
            homeMainListView.EnableFiltering = true;
            homeMainListView.HotTracking = false;
            homeMainListView.RootElement.BackColor = Color.Transparent;
            homeMainListView.BackColor = Color.Transparent;
            homeMainListView.ListViewElement.DrawFill = false;
            homeMainListView.ListViewElement.ViewElement.BackColor = Color.Transparent;
            homeMainListView.ListViewElement.Padding = new Padding(-9, 0, 0, 0);
            homeMainListView.RootElement.EnableElementShadow = false;

            homeInfoRightPanel.RootElement.EnableElementShadow = false;
         
        }
        private void AdjustMainColor()
        {
            ViewUtilities.MainThemeColor = FormElement.TitleBar.FillPrimitive.BackColor;
            switch (ThemeResolutionService.ApplicationThemeName)
            {
                case "Material":
                    aboutButton.Image = Resources.about;
                    userSplitButtonElement.Image = Resources.user_blue;
                    Icon = Resources.icon_orange;
                    break;
                case "MaterialBlueGrey":
                    aboutButton.Image = Resources.about_blue_grey;
                    userSplitButtonElement.Image = Resources.user_blue_grey;
                    Icon = Resources.icon_green;
                    break;
                case "MaterialPink":
                    aboutButton.Image = Resources.about_pink;
                    userSplitButtonElement.Image = Resources.user_pink;
                    Icon = Resources.icon_blue;
                    break;
                case "MaterialTeal":
                    aboutButton.Image = Resources.about_teal;
                    userSplitButtonElement.Image = Resources.user_teal;
                    Icon = Resources.icon_red;
                    break;

                default:
                    Icon = Resources.icon_pink;
                    break;
            }
            timeTablePrintButton.ForeColor = ViewUtilities.MainThemeColor;
            homeAddButton.ForeColor = ViewUtilities.MainThemeColor;
            homeExportToExcelButton.ForeColor = ViewUtilities.MainThemeColor;
            cashFlowAddButton.ForeColor = ViewUtilities.MainThemeColor;
            cashFlowExportToExcelButton.ForeColor = ViewUtilities.MainThemeColor;
            disciplineExportToExcelButton.ForeColor = ViewUtilities.MainThemeColor;
            disciplineAddButton.ForeColor = ViewUtilities.MainThemeColor;
            studentNoteExportToExcelButton.ForeColor = ViewUtilities.MainThemeColor;
            studentNoteAddButton.ForeColor = ViewUtilities.MainThemeColor;
            settingExportToExcelButton.ForeColor = ViewUtilities.MainThemeColor;
            settingAddButton.ForeColor = ViewUtilities.MainThemeColor;
            employeeExportToExcelButton.ForeColor = ViewUtilities.MainThemeColor;
            employeeAddButton.ForeColor = ViewUtilities.MainThemeColor;
            homeMainListView.ListViewElement.SynchronizeVisualItems();

        }

        
    }
}
