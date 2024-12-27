

using Primary.SchoolApp.DTO;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using static SchoolManagement.Core.Model.TimeTable;
using Primary.SchoolApp.Utilities;
using Telerik.WinControls;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Primary.SchoolApp.UI
{

    internal class EditTimeTableForm : SchoolManagement.UI.EditTimeTableForm
    {
        private readonly ITimeTableService timeTableService;
        private readonly ILogService logService;
        private readonly ISchoolClassService schoolClassService;
        private readonly ClientApp clientApp;
        private SchoolRoom selectedRoom;
        private TimeTableAppointment currentAppointment;
        private readonly ISubjectService subjectService;
        private readonly IEmployeeService employeeService;
        public EditTimeTableForm(ITimeTableService timeTableService, ILogService logService, ClientApp clientApp,
             ISchoolClassService schoolClassService,ISubjectService subjectService, IEmployeeService employeeService)
        {
            this.timeTableService = timeTableService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.schoolClassService = schoolClassService;
            this.subjectService = subjectService;
            this.employeeService = employeeService;
            InitEvent();
        }

        
        internal void Init(SchoolRoom room)
        {
            selectedRoom = room;
            LoadInitialData(room);
        }
        private async void LoadInitialData(SchoolRoom room)
        {

            var subjects = schoolClassService.GetClassSubjectList(room.ClassId).Result.Select(x => x.Subject).ToList();
            SubjectDropDownList.DataSource = subjects;
            SubjectDropDownList.DisplayMember = Language.fieldName;
            SubjectDropDownList.ValueMember = "Id";
            SubjectDropDownList.SelectedIndex = -1;


            TeacherDropDownList.DataSource = Program.EmployeeList;
            TeacherDropDownList.DisplayMember = "FullName";
            TeacherDropDownList.ValueMember = "Id";
            TeacherDropDownList.SelectedIndex = -1;
            //create liste of days
            var days = new List<SchoolManagement.Core.Model.DayOfWeek>();
            if(Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ){
                days.Add(new(1, "Lundi"));
                days.Add(new(2, "Mardi"));
                days.Add(new(3, "Mercredi"));
                days.Add(new(4, "Jeudi"));
                days.Add(new(5, "Vendredi"));
                days.Add(new(6, "Samedi"));
                days.Add(new(0, "Dimanche"));
            }
            else
            {
                days.Add(new(1, "Monday"));
                days.Add(new(2, "Tuesday"));
                days.Add(new(3, "Wednesday"));
                days.Add(new(4, "Thursday"));
                days.Add(new(5, "Friaday"));
                days.Add(new(6, "Saturday"));
                days.Add(new(0, "Sunday"));
            }
          
            DayDropDownList.ReadOnly = true;
            DayDropDownList.DataSource = days;
            DayDropDownList.DisplayMember = "Name";
            DayDropDownList.ValueMember = "Id";
            await Task.Delay(0);
        }
        protected override IEvent CreateNewEvent()
        {
            return new TimeTableAppointment();
        }
        protected override void LoadSettingsFromEvent(Telerik.WinControls.UI.IEvent sourceEvent)
        {
            base.LoadSettingsFromEvent(sourceEvent);          
            currentAppointment = sourceEvent as TimeTableAppointment;           
            this.errorProvider.Clear();
            DayDropDownList.SelectedValue = (int)TeacherStartHourDateTimePicker.Value.DayOfWeek;
            if (currentAppointment.Id != 0) {
                textBoxDescription.Text = currentAppointment.Description;
                SubjectDropDownList.SelectedValue = currentAppointment.Course.Id;
                SubjectDropDownList.DropDownListElement.TextBox.TextBoxItem.SelectionLength = 0;
                TeacherDropDownList.SelectedValue = currentAppointment.Teacher.Id;
                TeacherDropDownList.DropDownListElement.TextBox.TextBoxItem.SelectionLength = 0;
                DayDropDownList.SelectedValue = currentAppointment.DayId;
                DayDropDownList.DropDownListElement.TextBox.TextBoxItem.SelectionLength = 0;
                TeacherStartHourDateTimePicker.Value = currentAppointment.TeacherIn;
                TeacherEndHourDateTimePicker.Value = currentAppointment.TeacherOut;
                if (currentAppointment.SchoolYear.IsClosed) { 
                    this.buttonOK.Enabled = false;
                    this.SubjectDropDownList.Enabled= false;
                    this.cmbBackground.Enabled = false;
                    this.TeacherDropDownList.Enabled = false;
                    this.DayDropDownList.Enabled= false;
                    this.timeStart.Enabled = false;
                    this.timeEnd.Enabled = false;
                    this.timeStart.ReadOnly=true;
                    this.timeEnd.ReadOnly = true;
                    this.dateStart.Enabled = false;
                    this.dateEnd.Enabled = false;
                    this.TeacherAddButton.Enabled = false;
                    this.SubjectAddButton.Enabled = false;
                    this.TeacherStartHourDateTimePicker.Enabled= false;
                    this.TeacherEndHourDateTimePicker.Enabled = false;
                }
            }
            else
            {
                TeacherStartHourDateTimePicker.Value = timeStart.Value;
                TeacherEndHourDateTimePicker.Value = timeEnd.Value;
                DayDropDownList.SelectedValue = (int)TeacherEndHourDateTimePicker.Value.DayOfWeek;
            }
            
        }
        protected override void ApplySettingsToEvent(Telerik.WinControls.UI.IEvent ev)
        {

            this.currentAppointment.Course= SubjectDropDownList.SelectedItem.DataBoundItem as Subject;
            this.currentAppointment.SubjectId= this.currentAppointment.Course.Id;
            this.currentAppointment.Teacher = TeacherDropDownList.SelectedItem.DataBoundItem as Employee;
            this.currentAppointment.TeacherId= this.currentAppointment.Teacher.Id;
            this.currentAppointment.Day = DayDropDownList.SelectedItem.DataBoundItem as SchoolManagement.Core.Model.DayOfWeek;
            this.currentAppointment.SchoolYear=Program.CurrentSchoolYear;
            this.currentAppointment.SchoolYearId= this.currentAppointment.SchoolYear.Id;
            this.txtSubject.Text = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? this.currentAppointment.Course.FrenchName : this.currentAppointment.Course.EnglishName;
            this.txtLocation.Text = this.currentAppointment.Teacher.FullName;

            this.currentAppointment.TeacherIn = TeacherStartHourDateTimePicker.Value;
            this.currentAppointment.TeacherOut = TeacherEndHourDateTimePicker.Value;
            this.currentAppointment.State = (TimeTableState)this.cmbBackground.SelectedValue;
            ((RadScheduler)this.SchedulerData).Tag = this.currentAppointment;
            base.ApplySettingsToEvent(ev);
            var timeTable = currentAppointment.AsTimeTable();
            if (this.currentAppointment.Id > 0)
            {                
                var updateIsDone = timeTableService.UpdateTimeTableAsync(timeTable).Result;
                if (updateIsDone)
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
            else
            {
                var addIsDone = timeTableService.CreateTimeTableAsync(timeTable).Result;
                if (addIsDone)
                {
                    Log log = new()
                    {
                        UserAction = $" Programmation du cours {timeTable.Course.FrenchName} le {timeTable.StartHour} par l'utilisateur {clientApp.UserConnected.Name} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                    timeTable.Id = timeTableService.GetTimeTableAsync(timeTable.SubjectId, timeTable.RoomId, timeTable.StartHour, timeTable.EndHour).Result.Id;
                    currentAppointment.Id = timeTable.Id;
                }
                else
                {
                    RadMessageBox.Show(Language.messageAddError);
                }
            }
        }
        public bool IsValidData()
        {
            this.errorProvider.Clear();
            if (SubjectDropDownList.SelectedIndex < 0)
            {
                this.errorProvider.SetError(SubjectDropDownList, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                SubjectDropDownList.Focus();
                return false;
            }
            if (TeacherDropDownList.SelectedIndex < 0)
            {
                this.errorProvider.SetError(TeacherDropDownList, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                TeacherDropDownList.Focus();
                return false;
            }
            if (this.cmbBackground.SelectedIndex < 0)
            {

                this.errorProvider.SetError(this.cmbBackground, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                this.cmbBackground.Focus();
                return false;
            }
            return true;
        }
        protected override bool ValidateInput()
        {
            return IsValidData();
        }
        private void InitEvent()
        {
            this.SubjectDropDownList.ToolTipTextNeeded += SubjectDropDownList_ToolTipTextNeeded;
            SubjectAddButton.Click += SubjectAddButton_Click;
            TeacherAddButton.Click += TeacherAddButton_Click;
        }

        private void TeacherAddButton_Click(object sender, EventArgs e)
        {
            if (TeacherDropDownList.SelectedItem == null)
            {
                ShowEmployeeAddForm();
            }
            else
            {
                ShowEmployeeEditForm(TeacherDropDownList.SelectedItem.DataBoundItem as Employee);

            }
        }

        private void SubjectAddButton_Click(object sender, EventArgs e)
        {
            if (SubjectDropDownList.SelectedItem == null)
            {
                ShowSubjectAddForm();
            }
            else
            {
                if (SubjectDropDownList.SelectedItem.DataBoundItem is Subject item)
                {
                    ShowSubjectEditForm(item);
                }
                else
                {

                }
            }
        }

        private void SubjectDropDownList_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            if (SubjectDropDownList.SelectedItem != null)
            {
                if (SubjectDropDownList.SelectedItem.DataBoundItem is Subject subject)
                {
                    SubjectDropDownList.RootElement.ToolTipText = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Version anglaise: " + subject.EnglishName : "French version: " + subject.FrenchName;
                }
            }

        }
        

        // show subject UI for edit
        private void ShowSubjectEditForm(Subject subject)
        {
            if (subject != null)
            {
                var form = Program.ServiceProvider.GetService<EditSubjectForm>();
                form.Text = Language.labelAdd + ":.." + Language.labelSubject;
                form.Icon = this.Icon;
                form.Init(subject);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = subjectService.GetSubject(form.FrenchNameTextBox.Text).Result;
                    SubjectDropDownList.DataSource = null;
                    SubjectDropDownList.DataSource = Program.SubjectList;
                    SubjectDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show subject UI for add new
        private void ShowSubjectAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSubjectForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelSubject;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = subjectService.GetSubject(form.FrenchNameTextBox.Text).Result;
                Program.SubjectList.Add(data);
                SubjectDropDownList.DataSource = null;
                SubjectDropDownList.DataSource = Program.SubjectList;
                SubjectDropDownList.SelectedValue = data;
            }
        }
        
        // show employee UI to add edit
        private void ShowEmployeeEditForm(Employee employee)
        {
            if (employee != null)
            {
                var form = Program.ServiceProvider.GetService<EditEmployeeForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelEmployee;
                form.Init(employee);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = employeeService.GetEmployee(form.IdNumberTextBox.Text).Result;
                    TeacherDropDownList.DataSource = null;
                    TeacherDropDownList.DataSource = Program.EmployeeList;
                    TeacherDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowEmployee);
            }
        }
        // show employee UI to add new 
        private void ShowEmployeeAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddEmployeeForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelEmployee;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = employeeService.GetEmployee(form.IdNumberTextBox.Text).Result;
                Program.EmployeeList.Add(data);
                TeacherDropDownList.DataSource = null;
                TeacherDropDownList.DataSource = Program.EmployeeList;
                TeacherDropDownList.SelectedValue = data;
            }
        }


    }
}
