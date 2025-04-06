

using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class EditEvaluationCommentsForm:SchoolManagement.UI.EditEvaluationCommentsForm
    {
        private readonly IStudentNoteService studentNoteService;
        private SchoolRoom selectedRoom;
        private EvaluationSession selectedSession;
        private int selectedBookId;
        private readonly ClientApp clientApp;
        private readonly ILogService logService;
        private readonly IUserService userService;
        private List<Student> students;

        public EditEvaluationCommentsForm(IStudentNoteService studentNoteService, ILogService logService, ClientApp clientApp, IUserService userService)
        {
            this.studentNoteService = studentNoteService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.userService = userService;
           // CreateColumnsDataGridView();

        }
        internal void InitStartup(SchoolRoom room, EvaluationSession session, int bookId)
        {
            selectedRoom = room;
            selectedSession = session;
            selectedBookId = bookId;
            EvaluationLabel.Text = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? session.EnglishName : session.FrenchName;
            ClassroomDropDownList.DataSource = MainForm.GetUserConnectedClassrooms();
            ClassroomDropDownList.ValueMember = "Id";
            ClassroomDropDownList.DisplayMember = "Name";
            ClassroomDropDownList.SelectedValue=room.Id;
            students = Program.StudentRoomList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.RoomId == room.Id).Select(x => x.Student).OrderBy(x => x.FullName).ToList();
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            if (classOfRoom != null)
            {
                if (classGroup.DocumentLanguageId == 2)
                {
                    GroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                    GroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 1));
                }
                else
                {
                    if (classGroup.DocumentLanguageId == 0)
                    {
                        GroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                    }
                    else
                    {
                        GroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 0));
                    }
                }
                GroupDropDownList.SelectedIndex = bookId;
            }
            
            
            InitEvent();

        }

        private void InitEvent()
        {
            //GroupDropDownList.SelectedValueChanged += GroupDropDownList_SelectedValueChanged;
            //DataGridView.CellEndEdit += GridView_CellEndEdit;
            //DataGridView.CellValidating += GridView_CellValidating;
            //DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            //FilterTextBox.TextChanged += (o, ev) => { DataGridView.MasterTemplate.Refresh(); };
            //DataGridView.ContextMenuOpening += DataGridView_ContextMenuOpening;
            ExportToExelButton.Click += (o, ev) => { AppUtilities.ExportGridViewToExcel(DataGridView, Language.labelNotes); };
            PrintButton.Click += (o, ev) => { AppUtilities.PrintGridView(DataGridView, Language.labelNotes); };
        }
    }
}
