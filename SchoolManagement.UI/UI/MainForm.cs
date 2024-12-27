using Telerik.WinControls.Primitives;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;

namespace SchoolManagement.UI
{
    public partial class MainForm : RadForm
    {
        readonly RadButtonElement aboutButton = new();
        readonly RadSplitButtonElement userSplitButtonElement = new();
        readonly RadMenuItem logoutMenuItem = new(Language.labelLogOut);
        readonly RadMenuItem changePasswordMenuItem = new(Language.messageChangePassword);
        readonly RadDropDownListElement themesDropDown = new ();
        readonly RadWaitingBarElement taskWaitingBar = new ();
        readonly RadLabelElement waitingLabel = new();
        #region Properties
        public RadPageView MainPageView { get => mainPageView; }
        public RadWaitingBarElement TaskWaitingBar { get => taskWaitingBar; }
        public RadButtonElement AboutButton { get => aboutButton; }
        public RadMenuItem LogOutMenu { get => logoutMenuItem; }
        public RadMenuItem ChangePasswordMenu{ get => changePasswordMenuItem; }
        public RadDropDownList HomeSchoolYearDropDownList { get=>homeSchoolYearDropDownList; }
        public RadListView HomeLeftListView { get => homeLeftListView; }
        public RadListView HomeMainListView { get => homeMainListView; }
        public RadGridView HomeGridView { get=>homeGridView; }
        public RadPanel HomeInfoRightPanel { get=>homeInfoRightPanel; }
        public CustomControls.SearchTextBox HomeSearchTextBox {  get => homeSearchTextBox; }
        public RadButton HomeAddButton { get => homeAddButton; }
        public RadButton HomeExportToExcelButton {  get => homeExportToExcelButton; }
        public RadDropDownListElement ThemesDropDownList { get => themesDropDown; }
        public RadSplitButtonElement UserSplitButtonElement { get => userSplitButtonElement; }
        public RadToggleButton HomeIconViewToggleButton { get=>homeIconViewToggleButton; }
        public RadToggleButton HomeListViewToggleButton {  get => homeListViewToggleButton; }
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
            InitLanguage();
        }

        private void InitCommonComponents()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;

            RadPageViewStripElement stripElement = mainPageView.ViewElement as RadPageViewStripElement;
           
            stripElement.StripButtons = ~StripViewButtons.All;
            stripElement.ItemContainer.ButtonsPanel.Children.Add(taskWaitingBar);
            stripElement.ItemContainer.ButtonsPanel.Children.Add(waitingLabel);
            stripElement.ItemContainer.ButtonsPanel.Children.Add(themesDropDown);
            stripElement.ItemContainer.ButtonsPanel.Children.Add(aboutButton);
            stripElement.ItemContainer.ButtonsPanel.Children.Add(userSplitButtonElement);

            taskWaitingBar.Padding = new Padding(0);
            taskWaitingBar.MinSize = new Size(150, 8);
            //taskWaitingBar.WaitingIndicatorSize = new System.Drawing.Size(15, 16);
            taskWaitingBar.EnableElementShadow = false;
            taskWaitingBar.Visibility=ElementVisibility.Hidden;
            waitingLabel.Padding = new Padding(0);
            waitingLabel.MinSize = new Size(24, 8);
            waitingLabel.EnableElementShadow = false;

            themesDropDown.MinSize = new Size(200, 24);
            themesDropDown.EnableElementShadow = false;
            themesDropDown.FindDescendant<FillPrimitive>().BackColor = Color.Transparent;
            themesDropDown.DropDownStyle = RadDropDownStyle.DropDownList;
            stripElement.ItemContainer.ButtonsPanel.Margin = new Padding(0, 0, 40, 0);
            themesDropDown.Items.AddRange(new RadListDataItem[]
            {
                new ("Material") { Image = Resources.default_small }, new("MaterialPink") { Image = Resources.pink_blue_small },
                new ("MaterialTeal") { Image = Resources.teal_red_small }, new("MaterialBlueGrey") { Image = Resources.blue_grey_green_small }
            });
            themesDropDown.SelectedValue = "Material";
            ThemeResolutionService.ApplicationThemeName = "Material";
            themesDropDown.SelectedIndexChanged += delegate (object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
            {
                if (e.Position > -1)
                {
                    ThemeResolutionService.ApplicationThemeName = themesDropDown.Items[e.Position].Text;
                    AdjustMainColor();
                }
            };
            aboutButton.Image = Resources.about;
            userSplitButtonElement.Image = Resources.user_blue;
            Icon = Resources.icon_orange;
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
            InitComponentsHomePage();
            InitEventsHomePage();
            
        }
        private void InitComponentsHomePage() {
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
            ViewUtilities.MainThemeColor = this.FormElement.TitleBar.FillPrimitive.BackColor;
            switch (ThemeResolutionService.ApplicationThemeName)
            {
                case "Material":
                    aboutButton.Image = Resources.about;
                    userSplitButtonElement.Image = Resources.user_blue;
                    this.Icon = Resources.icon_orange;
                    break;
                case "MaterialBlueGrey":
                    aboutButton.Image = Resources.about_blue_grey;
                    userSplitButtonElement.Image = Resources.user_blue_grey;
                    this.Icon = Resources.icon_green;
                    break;
                case "MaterialPink":
                    aboutButton.Image = Resources.about_pink;
                    userSplitButtonElement.Image = Resources.user_pink;
                    this.Icon = Resources.icon_blue;
                    break;
                case "MaterialTeal":
                    aboutButton.Image = Resources.about_teal;
                    userSplitButtonElement.Image = Resources.user_teal;
                    this.Icon = Resources.icon_red;
                    break;

                default:
                    this.Icon = Resources.icon_pink;
                    break;
            }
        }
        private void InitEventsHomePage()
        {
            homeMainListView.VisualItemFormatting += HomeMainListView_VisualItemFormatting;
        }
        private void HomeMainListView_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
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
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
