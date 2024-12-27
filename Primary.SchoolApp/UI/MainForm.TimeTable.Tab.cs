

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp
{
    public partial class MainForm
    {
        string timeTableLeftViewForToolTipText = "";
        SchedulerBindingDataSource scheduleSource = new();
        private void InitTimeTablePage()
        {          
            LoadRoomListToTimeTableLeftListView();           
            InitEventsTimeTablePage();
            InitTimeTableScheduler();
            AjustColorTimeTablePage();

        }
        //initialisation de l'object Scheduler de page time table 
        private void InitTimeTableScheduler() {
            TimeTableScheduler.SchedulerElement.SetResourceHeaderAngleTransform(SchedulerViewType.Timeline, 0);
            AppointmentMappingInfo appointmentMappingInfo = new AppointmentMappingInfo();
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("Id", "Id"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("TeacherId", "TeacherId"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("SubjectId", "SubjectId"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("RoomId", "RoomId"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("SchoolYearId", "SchoolYearId"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("SchoolYear", "SchoolYear"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("DayId", "DayId"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("Teacher", "Teacher"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("Course", "Course"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("Room", "Room"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("Day", "Day"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("TeacherIn", "TeacherIn"));
            appointmentMappingInfo.Mappings.Add(new SchedulerMapping("TeacherOut", "TeacherOut"));
            appointmentMappingInfo.Start = "Start";
            appointmentMappingInfo.End = "End";
            appointmentMappingInfo.Summary = "Name";
            appointmentMappingInfo.Description = "Description";
            appointmentMappingInfo.ResourceId = "ResourceId";
            appointmentMappingInfo.BackgroundId = "State";
            appointmentMappingInfo.Location = "Location";
            TimeTableScheduler.AppointmentFactory = new  DTO.TimeTableAppointmentFactory();
            scheduleSource.EventProvider.AppointmentFactory = TimeTableScheduler.AppointmentFactory;
            scheduleSource.EventProvider.Mapping = appointmentMappingInfo;
            ResourceMappingInfo resourceMappingInfo = new()
            {
                Id = "Id",
                Name = "Name"
            };
            scheduleSource.ResourceProvider.Mapping = resourceMappingInfo;
            //TimeTableScheduler.DataSource = scheduleSource;
            
            InitAppointmentBackground();

            TimeTableScheduler.ShowAppointmentStatus = false;
            foreach (Resource r in TimeTableScheduler.Resources)
            {
                r.Color = Color.White;
            }
            TimeTableScheduler.SchedulerElement.RefreshViewElement();
            TimeTableScheduler.ActiveView.ResourcesPerView = 5;
            SchedulerDayViewBase view = TimeTableScheduler.ActiveView as SchedulerDayViewBase;
            if (view != null)
            {
                view.RulerStartScale = 7;
                view.RulerEndScale = 19;
            }
        }
        //initialisation des évements de la page time table
        private void InitEventsTimeTablePage()
        {
            TimeTableScheduler.AppointmentEditDialogShowing += TimeTableScheduler_AppointmentEditDialogShowing;
            TimeTableSearchDropDownList.SelectedIndexChanged += TimeTableSearchDropDownList_SelectedIndexChanged;
            TimeTableLeftListView.SelectedItemChanged += TimeTableLeftListView_SelectedItemChanged;
            TimeTableScheduler.ActiveViewChanged += TimeTableScheduler_ActiveViewChanged;
            TimeTableDateNavigator.DateTimePicker.ValueChanged += DateTimePicker_ValueChanged;
            TimeTableScheduler.AppointmentFormatting += TimeTableScheduler_AppointmentFormatting;
            TimeTableSchoolYearDropDownList.SelectedValueChanged += TimeTableSchoolYearDropDownList_SelectedValueChanged;
            TimeTableScheduler.ContextMenuOpening += TimeTableScheduler_ContextMenuOpening;
            TimeTableScheduler.AppointmentDropped += TimeTableScheduler_AppointmentDropped;
        }
        // déplacement d'une programmation via Drap et drop
        private void TimeTableScheduler_AppointmentDropped(object sender, AppointmentMovedEventArgs e)
        {
            if (e.Appointment is TimeTableAppointment appointment)
            {
                var timeTable = appointment.AsTimeTable();
                var isDone = timeTableService.UpdateTimeTableAsync(timeTable).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $" Mise à jour de la programmation du cours {timeTable.Course.FrenchName} le {timeTable.StartHour} par l'utilisateur {clientApp.UserConnected.Name} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show(Language.messageUpdateError);
                }
            }
        }

        private void TimeTableScheduler_ContextMenuOpening(object sender, SchedulerContextMenuOpeningEventArgs e)
        {
            e.Menu.Items.Remove(e.Menu.Items[2]);
        }

        private void TimeTableSchoolYearDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void TimeTableScheduler_AppointmentFormatting(object sender, SchedulerAppointmentEventArgs e)
        {
            e.AppointmentElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            e.AppointmentElement.NumberOfColors = 4;
            e.AppointmentElement.BorderColor = Color.FromArgb(209, 209, 209);
            e.AppointmentElement.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.OuterInnerBorders;
            e.AppointmentElement.ForeColor = Color.Black;
            Appointment p = e.Appointment.DataItem as Appointment;
            if (p != null)
            {
                e.AppointmentElement.DisableHTMLRendering = true;
                e.AppointmentElement.CustomFont = AppUtilities.MainFont;
                e.AppointmentElement.CustomFontSize = 9f;
                e.AppointmentElement.TextAlignment = ContentAlignment.MiddleCenter;
            }
        }

        private void AjustColorTimeTablePage()
        {
           
            switch (AppUtilities.MainThemeColor.Name)
            {
                //teal
                case "ff009688":
                    foreach (var item in TimeTableLeftListView.Items)
                    {
                        item.Image = Resources.users_teal;
                    }
                    break;
                //blue
                case "ff3f51b5":
                    foreach (var item in TimeTableLeftListView.Items)
                    {
                        item.Image = Resources.users_blue;
                    }
                    break;
                //pink
                case "ffe91e63":
                    foreach (var item in TimeTableLeftListView.Items)
                    {
                        item.Image = Resources.users_pink;
                    }
                    break;
                case "ff607d8b":
                    foreach (var item in TimeTableLeftListView.Items)
                    {
                        item.Image = Resources.users_blue_grey;
                    }
                    break;
                default:
                    foreach (var item in TimeTableLeftListView.Items)
                    {
                        item.Image = Resources.users_blue;
                    }
                    break;                   
            }
        }
        //permet de naviguer dans l'objet Scheduler pour consulter les différente programmations des cours
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TimeTableScheduler.FocusedDate = TimeTableDateNavigator.CurrentDate;         
            Program.ScheduleDate = TimeTableDateNavigator.DateTimePicker.Value;
        }

        private void TimeTableScheduler_ActiveViewChanged(object sender, SchedulerViewChangedEventArgs e)
        {
            TimeTableDateNavigator.DateTimePicker.Value = e.NewView.StartDate;

        }
        //initialisation des backgrounds qui représentent les statuts: A faire, Annulé, En cours, etc.
        private void InitAppointmentBackground()
        {
            //load state list
            if (TimeTableScheduler.Backgrounds.Count > 6) {
                TimeTableScheduler.Backgrounds.Clear();
                AppointmentBackgroundInfo toDoBackgroundInfo = new(1, Language.labelStateToDo, Color.LightGray)
                {
                    ShadowWidth = 0
                };
                TimeTableScheduler.Backgrounds.Add(toDoBackgroundInfo);
                AppointmentBackgroundInfo inProgressBackgroundInfo = new(2, Language.labelStateOngoing, Color.Orange)
                {
                    ShadowWidth = 0
                };
                TimeTableScheduler.Backgrounds.Add(inProgressBackgroundInfo);
                AppointmentBackgroundInfo courseDoneBackgroundInfo = new(3, Language.labelSateDone, Color.LightGreen)
                {
                    ShadowWidth = 0
                };
                TimeTableScheduler.Backgrounds.Add(courseDoneBackgroundInfo);
                AppointmentBackgroundInfo courseNoDoneBackgroundInfo = new(4, Language.labelSateNoDone, Color.LightPink)
                {
                    ShadowWidth = 0
                };
                TimeTableScheduler.Backgrounds.Add(courseNoDoneBackgroundInfo);
                AppointmentBackgroundInfo canceledBackgroundInfo = new(5, Language.labelStateCancel, Color.Red)
                {
                    ShadowWidth = 0
                };
                TimeTableScheduler.Backgrounds.Add(canceledBackgroundInfo);
            }
            
        }
        private void TimeTableLeftListView_SelectedItemChanged(object sender, System.EventArgs e)
        {
            //chargement des programmations
            LoadDataForTimeTableScheduler();
        }
        /// <summary>
        ///  charge les programmations des cours d'une classe pour l'anneé scolaire en cours
        /// </summary>
        private async  void LoadDataForTimeTableScheduler()
        {
            if (TimeTableLeftListView.SelectedItem != null)
            {
                if (TimeTableLeftListView.SelectedItem.Tag is SchoolRoom room)
                {
                    InitAppointmentBackground();
                    TimeTableScheduler.Appointments.Clear();
                    //fetch data
                    var getTimeTableTask = timeTableService.GetTimeTableListAsync(room.Id,Program.CurrentSchoolYear.Id);
                    var appointmentList = new List<TimeTableAppointment>();
                    var timeTableList = await getTimeTableTask;
                    //convertion en object TimeTableDTO
                    foreach (var timeTable in timeTableList)
                    {
                        appointmentList.Add(timeTable.AsTimeTableAppointment());
                    }
                    scheduleSource.EventProvider.DataSource = appointmentList;
                    TimeTableScheduler.DataSource = scheduleSource;
                }
            }                        
        }

        private void TimeTableSearchDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (TimeTableSearchDropDownList.SelectedIndex > -1)
            {
                foreach (var item in TimeTableLeftListView.Items)
                {
                    if (item.Text.Trim() == TimeTableSearchDropDownList.Text)
                    {
                        TimeTableLeftListView.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void TimeTableScheduler_AppointmentEditDialogShowing(object sender, AppointmentEditDialogShowingEventArgs e)
        {
            
            if (TimeTableLeftListView.SelectedItem.Tag is SchoolRoom room)
            {
                var form = Program.ServiceProvider.GetService<EditTimeTableForm>();
                form.Icon = this.Icon;
                var appointment = e.Appointment as TimeTableAppointment;
                if (appointment.Id==0) {
                    appointment.Room = room;
                    appointment.RoomId = room.Id;
                    appointment.SchoolYear=Program.CurrentSchoolYear;
                    appointment.SchoolYearId = appointment.SchoolYear.Id;
                }
                if (!Program.CurrentSchoolYear.IsClosed || appointment.Id!=0)
                {
                    form.Init(room);
                    e.AppointmentEditDialog = form;
                }
                else
                {
                    e.AppointmentEditDialog = null;
                    RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }            
        }
        //load room list to left listview of timetable page
        private void LoadRoomListToTimeTableLeftListView()
        {
            //TimeTableLeftListView

            ListViewDataItemGroup classGroup = new()
            {
                Text = Language.labelClasss,
                Visible = false
            };
            TimeTableLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { classGroup });
            TimeTableLeftListView.ShowCheckBoxes = false;
            var rooms = new List<SchoolRoom>();
            if (clientApp.UserConnected.UserName != "root")
            {
               rooms=clientApp.UserConnected.Rooms.Select(x=>x.Room).ToList();
            }
            else
            {
                rooms = Program.SchoolRoomList.ToList();
            }
            foreach (var room in rooms)
            {
                ListViewDataItem dataItem = new();
                dataItem.Key = room.Id;
                dataItem.Value = room.Name;
                dataItem.Tag = room;
                dataItem.Image=Resources.tripple_users;
                TimeTableSearchDropDownList.Items.Add(room.Name);
                if (room.Name.Trim().Length > 22)
                {
                    dataItem.Text = room.Name.ToUpper().Substring(0, 22) + "...";
                }
                else
                {
                    dataItem.Text = room.Name.ToUpper();
                }
                dataItem.Group = classGroup;
                TimeTableLeftListView.Items.Add(dataItem);
               
            }
            TimeTableLeftListView.SelectedIndex = -1;
        }
    }
}
