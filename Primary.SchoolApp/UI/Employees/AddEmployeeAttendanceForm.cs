

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Primary.SchoolApp.UI
{
    internal class AddEmployeeAttendanceForm:SchoolManagement.UI.EditEmployeeAttendanceForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly ISchoolClassService schoolClassService;
        private readonly ClientApp clientApp;
        private EmployeeEnrolling selectedEnrolling;
        public AddEmployeeAttendanceForm(ILogService logService, IEmployeeService employeeService, ClientApp clientApp, ISchoolClassService schoolClassService)
        {
            this.logService = logService;
            this.employeeService = employeeService;
            this.schoolClassService = schoolClassService;
            this.clientApp = clientApp;
            RoomDropDownList.DataSource = Program.SchoolRoomList;
            RoomDropDownList.SelectedIndex = -1;
            InitEvents();  
            this.AttendanceDateTimePicker.Value = DateTime.Now;
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            AttendanceDateTimePicker.ValueChanged += AttendanceDateTimePicker_ValueChanged;
            SubjectDropDownList.ToolTipTextNeeded += SubjectDropDownList_ToolTipTextNeeded;
            RoomDropDownList.SelectedValueChanged += RoomDropDownList_SelectedValueChanged;
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
            if (IsValidData()) {
                var subject= SubjectDropDownList.SelectedItem.DataBoundItem as Subject;
                var room=RoomDropDownList.SelectedItem.DataBoundItem as SchoolRoom;
                var startHour = StartDateTimePicker.Value;
                var endHour = EndDateTimePicker.Value;
                if (!RecordExist(subject.Id, room.Id, startHour)) {
                    EmployeeAttendance attendance = new()
                    {
                        EnrollingId = selectedEnrolling.Id,
                        RoomId = room.Id,
                        SubjectId = subject.Id,
                        StartHour = startHour,
                        EndHour = endHour,
                        Description =DescriptionTextBox.Text,
                        Enrolling = selectedEnrolling,
                        Subject = subject,
                        Room = room
                    };
                    var isDone=employeeService.AddAttendance(attendance).Result;
                    if (isDone) {
                        Log log = new()
                        {
                            UserAction = $"Ajout d'un pointage de l'employé {selectedEnrolling.Employee.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text=Language.messageAddError;
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageRecordExist;
                }               
            }
        }

        internal void Init(EmployeeEnrolling enrolling)
        {
            this.selectedEnrolling = enrolling;           
        }
        private async void LoadSubjects(int classId)
        {
            var subjectList = schoolClassService.GetClassSubjectList(classId).Result.Select(x => x.Subject).ToList();
            SubjectDropDownList.DataSource = subjectList;
            await Task.Delay(0);
        }
        private bool RecordExist(int subjectId,int roomId,DateTime start)
        {
            if (selectedEnrolling.Attendances.Where(
                x => x.SubjectId == subjectId && x.RoomId == roomId &&
                x.StartHour.Date==start.Date && x.StartHour.Hour==start.Hour
                ).Count()>0)
            {
                return true;
            }
            return false;
        }
    }
}
