using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;

namespace SchoolManagement.UI
{
    public partial class MainForm
    {

        SchedulerBindingDataSource scheduleSource = new SchedulerBindingDataSource();
        string timeTableLeftViewForToolTipText = "";
        private void InitTimeTablePage()
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
           
            timeTablePrintButton.ButtonElement.ToolTipText = "Cliquer ici pour Imprimer";

            //ScheduleRadScheduler.AppointmentTitleFormat = "{2} ({3})";
            timeTableScheduler.SchedulerElement.SetResourceHeaderAngleTransform(SchedulerViewType.Timeline, 0);

            AppointmentMappingInfo appointmentMappingInfo = new AppointmentMappingInfo();
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("Id", "Id"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("TeacherId", "TeacherId"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("CourseId", "CourseId"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("DayId", "DayId"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("Teacher", "Teacher"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("Course", "Course"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("Day", "Day"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("TeacherIn", "TeacherIn"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("TeacherOut", "TeacherOut"));
            appointmentMappingInfo.Start = "Start";
            appointmentMappingInfo.End = "End";
            appointmentMappingInfo.Summary = "Name";
            appointmentMappingInfo.Description = "Description";
            appointmentMappingInfo.ResourceId = "ResourceId";
            appointmentMappingInfo.BackgroundId = "Status";
            appointmentMappingInfo.Location = "Location";
            timeTableScheduler.AppointmentFactory = new TimeTableFactory();
            scheduleSource.EventProvider.AppointmentFactory = timeTableScheduler.AppointmentFactory;
            scheduleSource.EventProvider.Mapping = appointmentMappingInfo;
            ResourceMappingInfo resourceMappingInfo = new ResourceMappingInfo();
            resourceMappingInfo.Id = "Id";
            resourceMappingInfo.Name = "Name";
            scheduleSource.ResourceProvider.Mapping = resourceMappingInfo;
            timeTableScheduler.DataSource = scheduleSource;

            timeTableScheduler.Backgrounds.Clear();
            AppointmentBackgroundInfo toDoBackgroundInfo = new AppointmentBackgroundInfo(1, "A Faire", Color.LightGray);
            toDoBackgroundInfo.ShadowWidth = 0;
            timeTableScheduler.Backgrounds.Add(toDoBackgroundInfo);
            AppointmentBackgroundInfo inProgressBackgroundInfo = new AppointmentBackgroundInfo(2, "En cours", Color.Orange);
            inProgressBackgroundInfo.ShadowWidth = 0;
            timeTableScheduler.Backgrounds.Add(inProgressBackgroundInfo);
            AppointmentBackgroundInfo courseDoneBackgroundInfo = new AppointmentBackgroundInfo(3, "Fait", Color.LightGreen);
            courseDoneBackgroundInfo.ShadowWidth = 0;
            timeTableScheduler.Backgrounds.Add(courseDoneBackgroundInfo);
            AppointmentBackgroundInfo courseNoDoneBackgroundInfo = new AppointmentBackgroundInfo(4, "Non fait", Color.LightPink);
            courseNoDoneBackgroundInfo.ShadowWidth = 0;
            timeTableScheduler.Backgrounds.Add(courseNoDoneBackgroundInfo);
            AppointmentBackgroundInfo canceledBackgroundInfo = new AppointmentBackgroundInfo(5, "Annulé", Color.Red);
            canceledBackgroundInfo.ShadowWidth = 0;
            timeTableScheduler.Backgrounds.Add(canceledBackgroundInfo);

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
        }
    }
}
