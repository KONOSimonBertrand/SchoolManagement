using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class EditStudentClassForm : SchoolManagement.UI.EditStudentClassForm
    {
        private readonly IStudentEnrollingService enrollingService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedInrolling;
        public EditStudentClassForm(IStudentEnrollingService enrollingService, ILogService logService, ClientApp clientApp)
        {
            this.enrollingService = enrollingService;
            this.logService = logService;
            this.clientApp = clientApp;
            ClassDropDownList.DataSource = Program.SchoolClassList;
            InitEvents();
        }
        private void InitEvents()
        {
            this.SaveButton.Click += SaveButton_Click;
        }

        private void ClassDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if(ClassDropDownList.SelectedItem.DataBoundItem is SchoolClass selectedClass)
            {
                RoomDropDownList.DataSource = Program.SchoolRoomList.Where(x => x.ClassId == selectedClass.Id);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var room= RoomDropDownList.SelectedItem.DataBoundItem as SchoolRoom;
                var studentRoom = new StudentRoom()
                {
                    Student=selectedInrolling.Student,
                    StudentId=selectedInrolling.StudentId,
                    SchoolYear=selectedInrolling.SchoolYear,
                    SchoolYearId=selectedInrolling.SchoolYearId,
                    Room=room,
                    RoomId=room.Id,
                    Note="Changement de salle de classe"
                    
                };
                if (enrollingService.DeleteStudentRoomAsync(selectedInrolling.StudentId, selectedInrolling.SchoolYearId).Result==true) {
                    var isDone = enrollingService.CreateStudentRoomAsync(studentRoom).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log log = new()
                        {
                            UserAction = $"Changement de salle de classe  {room.Name} de l'élève {selectedInrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorProvider.SetError(this, Language.messageAddError);
                        ErrorLabel.Text = Language.messageAddError;
                    }
                }
                
            }
        }
        internal void Init(StudentEnrolling enrolling)
        {
            this.StudentTextBox.Text = enrolling.Student.FullName;
            this.selectedInrolling = enrolling;
            var currentRoom = enrollingService.GetStudentRoomAsync(enrolling.StudentId, enrolling.SchoolYearId).Result;
            if (Program.SchoolRoomList.Any(x => x.ClassId == enrolling.ClassId && x.Id == currentRoom.RoomId)) {
                RoomDropDownList.DataSource = Program.SchoolRoomList.Where(x => x.ClassId == enrolling.ClassId);               
            }
            else
            {
                RoomDropDownList.DataSource = Program.SchoolRoomList.Where(x => x.Id == currentRoom.RoomId);

            }
            ClassDropDownList.SelectedValue = enrolling.ClassId;
            RoomDropDownList.SelectedValue = currentRoom.RoomId;
            ClassDropDownList.SelectedValueChanged += ClassDropDownList_SelectedValueChanged;

        }
    }
}
