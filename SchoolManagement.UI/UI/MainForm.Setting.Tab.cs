using SchoolManagement.UI.Utilities;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.CustomControls;
using SchoolManagement.UI.Languages;


namespace SchoolManagement.UI
{
    public partial class MainForm
    {
        public RadGridView SettingGridView {
            get => settingGridView;
        }
        public RadButton SettingAddButton
        {
            get => settingAddButton;
        }
        public RadButton SettingExportToExcelButton
        {
            get => settingExportToExcelButton;
        }       
        public SearchTextBox SettingSearchTextBox
        {
            get=>settingSearchTextBox;
        }
        public RadDropDownList SettingSearchModuleDropDownList
        {
            get=>settingSearchModuleDropDownList;
        }
        public RadListView SettingLeftListView { get => settingLeftListView;  }
        public RadPanel SettingInfoRightPanel { get=>settingInfoRightPanel; }
        public RadPanel SettingMainPanel { get=>settingMainPanel; }
        private void InitSettingPage()
        {
            settingMainPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            settingMainPanel.BackgroundImage = Resources.Background;
            settingMainPanel.BackgroundImageLayout = ImageLayout.Stretch;
            settingMainPanel.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;

            settingNavigationPanel.BackgroundImage = Resources.fasha_no_borders;
            settingNavigationPanel.BackgroundImageLayout = ImageLayout.Stretch;
            settingNavigationPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            settingNavigationPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            settingNavigationPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;

            settingSearchPanel.RootElement.EnableElementShadow = false;
            settingSearchPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            settingSearchPanel.BackColor = Color.Transparent;
            settingSearchPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

            settingEmptyPanel.RootElement.EnableElementShadow = false;
            settingEmptyPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            settingEmptyPanel.BackColor = Color.Transparent;
            settingEmptyPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

            settingAddButton.ButtonElement.ToolTipText = "Cliquer ici pour ...";
            settingAddButton.TextAlignment = ContentAlignment.MiddleCenter;

            settingExportToExcelButton.TextAlignment = ContentAlignment.MiddleCenter;
            settingExportToExcelButton.ButtonElement.ToolTipText = "Cliquer ici pour exporter les données vers excel";

            settingSearchTextBox.NullText = "Rechercher par ...";


            settingLeftListView.ShowGroups = false;
            settingLeftListView.EnableGrouping = true;
            settingLeftListView.EnableCustomGrouping = true;
            settingLeftListView.ShowCheckBoxes = true;
            settingLeftListView.AllowEdit = false;
            settingLeftListView.RootElement.EnableElementShadow = false;
            settingLeftListView.HotTracking = false;
            settingLeftListView.ListViewElement.Padding = new Padding(0, 16, 0, 0);

            settingSearchModuleDropDownList.RootElement.EnableElementShadow = false;
            settingSearchModuleDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            settingSearchModuleDropDownList.RootElement.CustomFontSize = 10.5f;
            settingSearchModuleDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            settingSearchModuleDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);
            settingSearchModuleDropDownList.DropDownListElement.ArrowButton.Visibility = ElementVisibility.Hidden;

            settingGridView.TableElement.CellSpacing = 10;
            settingGridView.RootElement.EnableElementShadow = false;
            settingGridView.GridViewElement.DrawFill = false;
            settingGridView.TableElement.Margin = new Padding(15, 0, 15, 0);
            settingGridView.BackColor = Color.Transparent;
            settingGridView.GridViewElement.DrawFill = true;
            settingGridView.AllowAddNewRow = false;
            settingGridView.EnableGrouping = false;
          
            settingInfoRightPanel.RootElement.EnableElementShadow = false;
        }

        private void InitLanguage()
        {
            
            HomePage.Text=Language.labelHome.ToUpper();
            CashFlowPage.Text = Language.labelCashFlow.ToUpper();
            DisciplinePage.Text = Language.labelDiscipline.ToUpper();
            StudentNotePage.Text=Language.labelStudentNotes.ToUpper();
            DisciplinePage.Text=Language.labelDiscipline.ToUpper();
            EmployeePage.Text=Language.labelAdministration.ToUpper();
            ReportsPage.Text=Language.labelReports.ToUpper();
            SettingPage.Text=Language.labelSettings.ToUpper();
            TimeTablePage.Text=Language.labelTimeTable.ToUpper();
            homeAddButton.Text = Language.labelEnroll;
            homeSchoolYearLabel.Text = Language.labelSchoolYear;
            homeExportToExcelButton.ButtonElement.ToolTipText = Language.labelExport;
            homeExportToExcelButton.Text = Language.labelExport;
            homeSearchTextBox.NullText = Language.messageResearch;
            cashFlowAddButton.Text = Language.labelAdd;
            cashFlowSchoolYearLabel.Text = Language.labelSchoolYear;
            cashFlowExportToExcelButton.ButtonElement.ToolTipText = Language.labelExport;
            cashFlowExportToExcelButton.Text = Language.labelExport;
            cashFlowSearchTextBox.NullText = Language.messageResearch;
            timeTableSchoolYearLabel.Text = Language.labelSchoolYear;
            disciplineAddButton.Text = Language.labelAdd;
            disciplineSchoolYearLabel.Text = Language.labelSchoolYear;
            disciplineExportToExcelButton.ButtonElement.ToolTipText = Language.labelExport;
            disciplineExportToExcelButton.Text = Language.labelExport;
            disciplineSearchTextBox.NullText = Language.messageResearch;
            studentNoteAddButton.Text = Language.labelAdd;
            studentNoteSchoolYearLabel.Text = Language.labelSchoolYear;
            studentNoteExportToExcelButton.ButtonElement.ToolTipText = Language.labelExport;
            studentNoteExportToExcelButton.Text = Language.labelExport;
            studentNoteSearchTextBox.NullText = Language.messageResearch;
            reportSchoolYearLabel.Text = Language.labelSchoolYear;
            reportSearchTextBox.NullText = Language.messageResearch;
            employeeAddButton.Text = Language.labelAdd;
            employeeSchoolYearLabel.Text = Language.labelSchoolYear;
            employeeExportToExcelButton.ButtonElement.ToolTipText = Language.labelExport;
            employeeExportToExcelButton.Text = Language.labelExport;
            employeeSearchTextBox.NullText = Language.messageResearch;
            settingAddButton.Text = Language.labelAdd;
            settingExportToExcelButton.ButtonElement.ToolTipText = Language.labelExport;
            settingExportToExcelButton.Text = Language.labelExport;
            SettingSearchModuleDropDownList.NullText = Language.messageSearchModule;
            settingSearchTextBox.NullText = Language.messageResearch;
        }
    }
}
