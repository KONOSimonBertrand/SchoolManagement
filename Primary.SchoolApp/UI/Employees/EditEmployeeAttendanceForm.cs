

using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    internal class EditEmployeeAttendanceForm : SchoolManagement.UI.EditEmployeeAttendanceForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly ISchoolClassService schoolClassService;
        private readonly ISchoolRoomService schoolRoomService;
        private readonly ISubjectService subjectService;
        private readonly ClientApp clientApp;
        private EmployeeAttendance selectedAttendance;
        private EmployeeEnrolling selectedEnrolling;
        public EditEmployeeAttendanceForm(ILogService logService, IEmployeeService employeeService, ClientApp clientApp, 
            ISchoolClassService schoolClassService, ISchoolRoomService schoolRoomService, ISubjectService subjectService)
        {
            this.logService = logService;
            this.employeeService = employeeService;
            this.clientApp = clientApp;        
            this.schoolClassService = schoolClassService;
            this.subjectService = subjectService;
            this.schoolRoomService = schoolRoomService;
            RoomDropDownList.DataSource = Program.SchoolRoomList;
            InitEvents();

        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            AttendanceDateTimePicker.ValueChanged += AttendanceDateTimePicker_ValueChanged;
            SubjectDropDownList.ToolTipTextNeeded += SubjectDropDownList_ToolTipTextNeeded;
            RoomDropDownList.SelectedValueChanged += RoomDropDownList_SelectedValueChanged;
            SubjectAddButton.Click += SubjectAddButton_Click;
            RoomAddButton.Click += RoomAddButton_Click;
        }

        private void RoomAddButton_Click(object sender, EventArgs e)
        {
            if (RoomDropDownList.SelectedItem == null)
            {
                ShowSchoolRoomAddForm();
            }
            else
            {
                ShowSchoolRoomEditForm(RoomDropDownList.SelectedItem.DataBoundItem as SchoolRoom);
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
                ShowSubjectEditForm(SubjectDropDownList.SelectedItem.DataBoundItem as Subject);
            }
        }

        private void RoomDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (RoomDropDownList.SelectedItem != null)
            {
                if (RoomDropDownList.SelectedItem.DataBoundItem is SchoolRoom room)
                {
                    LoadSubjects(room.ClassId);
                }
            }

        }

        private void SubjectDropDownList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            if (SubjectDropDownList.SelectedItem != null)
            {
                if (SubjectDropDownList.SelectedItem.DataBoundItem is Subject subject)
                {
                    SubjectDropDownList.RootElement.ToolTipText = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Version anglaise: " + subject.EnglishName : "French version: " + subject.FrenchName;
                }
            }
        }

        private void AttendanceDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            StartDateTimePicker.Value = AttendanceDateTimePicker.Value;
            EndDateTimePicker.Value = AttendanceDateTimePicker.Value;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var subject = SubjectDropDownList.SelectedItem.DataBoundItem as Subject;
                var room = RoomDropDownList.SelectedItem.DataBoundItem as SchoolRoom;
                var startHour = StartDateTimePicker.Value;
                var endHour = EndDateTimePicker.Value;
                if (!RecordExist(subject.Id, room.Id, startHour))
                {

                    selectedAttendance.RoomId = room.Id;
                    selectedAttendance.SubjectId = subject.Id;
                    selectedAttendance.StartHour = startHour;
                    selectedAttendance.EndHour = endHour;
                    selectedAttendance.Description = DescriptionTextBox.Text;
                    selectedAttendance.Subject = subject;
                    selectedAttendance.Room = room;
                    var isDone = employeeService.UpdateAttendance(selectedAttendance).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Mise à jour d'un pointage de l'employé {selectedEnrolling.Employee.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageAddError;
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageRecordExist;
                }
            }
        }

        internal void Init(EmployeeEnrolling enrolling, EmployeeAttendance attendance)
        {
            this.selectedAttendance = attendance;
            this.selectedEnrolling = enrolling;
            RoomDropDownList.SelectedValue = attendance.RoomId;
            SubjectDropDownList.SelectedValue = attendance.SubjectId;
            AttendanceDateTimePicker.Value = attendance.StartHour;
            StartDateTimePicker.Value = attendance.StartHour;
            EndDateTimePicker.Value = attendance.EndHour;
            DescriptionTextBox.Text = attendance.Description;
        }
        private async void LoadSubjects(int classId)
        {
            var subjectList = schoolClassService.GetClassSubjectList(classId).Result.Select(x => x.Subject).ToList();
            SubjectDropDownList.DataSource = subjectList;
            await Task.Delay(0);
            Console.WriteLine("ksb");
        }
        
        private bool RecordExist(int subjectId, int roomId, DateTime start)
        {
            if (selectedEnrolling.Attendances.Where(
                x => x.SubjectId == subjectId && x.RoomId == roomId &&
                x.StartHour.Date == start.Date && x.StartHour.Hour == start.Hour
                ).Count() > 1)
            {
                return true;
            }
            return false;
        }
        // show school room UI for edit
        private void ShowSchoolRoomEditForm(SchoolRoom item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolRoomForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelRoom;
                form.Init(item);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = schoolRoomService.GetSchoolRoom(form.NameTextBox.Text).Result;
                    RoomDropDownList.DataSource = null;
                    RoomDropDownList.DataSource = Program.SchoolRoomList;
                    RoomDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowClass);
            }
        }
        // show school room UI to add new 
        private void ShowSchoolRoomAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolRoomForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelRoom;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = schoolRoomService.GetSchoolRoom(form.NameTextBox.Text).Result;
                Program.SchoolRoomList.Add(data);
                RoomDropDownList.DataSource = null;
                RoomDropDownList.DataSource = Program.SchoolRoomList;
                RoomDropDownList.SelectedValue = data;
            }
        }
        // show subject UI for edit
        private void ShowSubjectEditForm(Subject subject)
        {
            if (subject != null)
            {
                var form = Program.ServiceProvider.GetService<EditSubjectForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelSubject;
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
    }
}
