using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Linq;
using Telerik.WinControls.UI;


namespace Primary.SchoolApp.UI
{
    internal class EditBadgeForm : SchoolManagement.UI.EditBadgeForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IPrintService printService;
        private readonly IStudentEnrollingService enrollingService;
        private StudentEnrollingDTO selectedEnrolling;
        private SchoolRoom selectedRoom;
        public EditBadgeForm(ILogService logService, ClientApp clientApp, IPrintService printService, IStudentEnrollingService studentEnrollingService)
        {
            this.logService = logService;
            this.clientApp = clientApp;
            this.printService = printService;
            this.enrollingService = studentEnrollingService;
            InitEvents();
           StartDateTimePicker.CustomFormat = "yyyy";
           EndDateTimePicker.CustomFormat = "yyyy";
        }

        internal void Init(StudentEnrollingDTO enrolling)
        {
            selectedEnrolling=enrolling;
            var studentRoom = enrollingService.GetStudentRoomAsync(enrolling.StudentId, enrolling.SchoolYearId).Result;
            selectedRoom = Program.SchoolRoomList.Where(x=>x.Id==studentRoom.RoomId).FirstOrDefault();
            RadListDataItem studentItem = new(enrolling.Student.FullName, 0);
            RadListDataItem roomItem = new(selectedRoom.Name, 1);
            RadListDataItem classItem = new(selectedRoom.SchoolClass.Name, 2);
            ForDropDownList.Items.Add(studentItem);
            ForDropDownList.Items.Add(roomItem);
            ForDropDownList.Items.Add(classItem);
            ForDropDownList.SelectedValue = 0;
        }
        private void InitEvents()
        {
            GenerateButton.Click += GenerateButton_Click;
        }

        private void GenerateButton_Click(object sender, System.EventArgs e)
        {
            if (IsValidData())
            {
                string expirationDate;
                if (FormatDropDownList.SelectedIndex == 0)
                {
                    expirationDate = StartDateTimePicker.Value.Year + "-" + EndDateTimePicker.Value.Year;
                }
                else
                {
                    if (FormatDropDownList.SelectedIndex == 1)
                    {
                        expirationDate = StartDateTimePicker.Value.Month + "/" + StartDateTimePicker.Value.Year + "-" + EndDateTimePicker.Value.Month + "/" + EndDateTimePicker.Value.Year;
                    }
                    else
                    {
                        expirationDate = StartDateTimePicker.Value.Day + "/" + StartDateTimePicker.Value.Month + "/" + StartDateTimePicker.Value.Year + "-" + EndDateTimePicker.Value.Day + "/" + EndDateTimePicker.Value.Month + "/" + EndDateTimePicker.Value.Year;
                    }
                }
                if (ForDropDownList.SelectedValue.ToString() != "0")
                {
                    var enrollingList=Program.StudentEnrollingList.Where(x => x.ClassId==selectedRoom.ClassId).ToList();
                    if (ForDropDownList.SelectedValue.ToString() == "1")
                    {
                        var students = enrollingService.GetStudentRoomListAsync(selectedRoom.Id, selectedEnrolling.SchoolYearId).Result.Select(x=>x.Student);
                        enrollingList= Program.StudentEnrollingList.Where(x=> students.Contains(x.Student)).ToList();
                    }

                    printService.PrintClassBadgeAsync(enrollingList, expirationDate);
                }
                else
                {
                    printService.PrintStudentBadgeAsync(selectedEnrolling, expirationDate);
                }
                this.Close();
            }
            
        }
    }
    
}
