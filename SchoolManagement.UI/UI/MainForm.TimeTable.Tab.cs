using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;

namespace SchoolManagement.UI
{

    public partial class MainForm
    {
        public RadDropDownList TimeTableSchoolYearDropDownList { get => timeTableSchoolYearDropDownList; }
        public RadButton TimeTablePrintButtton { get => timeTablePrintButton; }
        public CustomControls.DateNavigator TimeTableDateNavigator { get => timeTableDateNavigator; }
        public RadListView TimeTableLeftListView {  get => timeTableLeftListView; }
        public RadScheduler TimeTableScheduler {  get => timeTableScheduler; }
       public RadDropDownList TimeTableSearchDropDownList {  get => timeTableSearchDropDownList; }  
        private void InitTimeTablePage()
        {

            InitComponentTimeTablePage();
        }
      
        private void InitComponentTimeTablePage()
        {
            timeTableMainContainer.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            timeTableNavigationPanel.BackgroundImage = Resources.fasha_no_borders;
            timeTableNavigationPanel.BackgroundImageLayout = ImageLayout.Stretch;
            timeTableNavigationPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            timeTableNavigationPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            timeTableNavigationPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;

            timeTableSearchPanel.RootElement.EnableElementShadow = false;
            timeTableSearchPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            timeTableSearchPanel.BackColor = Color.Transparent;
            timeTableSearchPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

            timeTableEmptyPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            timeTableEmptyPanel.BackColor = Color.Transparent;
            timeTableEmptyPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            timeTableEmptyPanel.RootElement.EnableElementShadow = false;

            timeTableLeftListView.ShowGroups = true;
            timeTableLeftListView.EnableGrouping = true;
            timeTableLeftListView.EnableCustomGrouping = true;
            timeTableLeftListView.ShowCheckBoxes = true;
            timeTableLeftListView.AllowEdit = false;
            timeTableLeftListView.RootElement.EnableElementShadow = false;
            timeTableLeftListView.HotTracking = false;
            timeTableLeftListView.ListViewElement.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);

            timeTableSchoolYearDropDownList.RootElement.EnableElementShadow = false;
            timeTableSchoolYearDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            timeTableSchoolYearDropDownList.RootElement.CustomFontSize = 10.5f;
            timeTableSchoolYearDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            timeTableSchoolYearDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            timeTableSchoolYearLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            timeTableSchoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            timeTableSchoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);

            timeTableMainContainer.BackgroundImage = Resources.Background;
            timeTableMainContainer.BackgroundImageLayout = ImageLayout.Stretch;
            timeTableMainContainer.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;

            timeTablePrintButton.ImageAlignment = ContentAlignment.MiddleCenter;
            timeTablePrintButton.TextAlignment = ContentAlignment.MiddleCenter;

            timeTablePrintButton.ButtonElement.ToolTipText = Language.messageClickToPrint;

            timeTableScheduler.Backgrounds.Clear();

            //ScheduleRadScheduler.GroupType = GroupType.Resource;
            timeTableScheduler.ShowAppointmentStatus = false;
            foreach (Resource r in timeTableScheduler.Resources)
            {
                r.Color = Color.White;
            }

            timeTableScheduler.SchedulerElement.RefreshViewElement();
            timeTableScheduler.ActiveView.ResourcesPerView = 5;
            timeTableScheduler.ActiveViewType = SchedulerViewType.Week;
            //ScheduleRadScheduler.PrintStyle = new SchedulerDailyPrintStyle(ScheduleRadScheduler.ActiveView.StartDate, ScheduleRadScheduler.ActiveView.EndDate);
            SchedulerDayViewBase view = timeTableScheduler.ActiveView as SchedulerDayViewBase;
            if (view != null)
            {
                view.RulerStartScale = 7;
                view.RulerEndScale = 19;
            }
            timeTableSearchDropDownList.RootElement.ToolTipText = Language.MessageFindClassroom;
            timeTableSearchDropDownList.NullText = Language.MessageFindClassroom;
        }

    }
}
