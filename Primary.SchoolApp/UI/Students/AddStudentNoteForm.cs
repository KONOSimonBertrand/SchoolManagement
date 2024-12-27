
using MySqlX.XDevAPI;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Threading;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class AddStudentNoteForm:SchoolManagement.UI.EditStudentNoteForm
    {
        private readonly IStudentNoteService studentNoteService;
        private SchoolRoom selectedRoom;
        private EvaluationSession selectedSession;
        private int selectedBookId;
        private readonly ClientApp clientApp;
        private readonly ILogService logService;
        public AddStudentNoteForm(IStudentNoteService studentNoteService, ClientApp clientApp, ILogService logService)
        {
            this.studentNoteService = studentNoteService;
            this.clientApp = clientApp;
            this.logService = logService;
            StudentDropDownList.ValueMember = "Id";
            StudentDropDownList.DisplayMember = "FullName";
            SubjectDropDownList.ValueMember = "Id";
            SubjectDropDownList.DisplayMember = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "FrenchName" : "EnglishName";
            
            
        }

        private void InitEvent()
        {
            StudentDropDownList.SelectedValueChanged += StudentDropDownList_SelectedValueChanged;
            SubjectDropDownList.SelectedIndexChanged += SubjectDropDownList_SelectedValueChanged;
            GroupDropDownList.SelectedValueChanged += GroupDropDownList_SelectedValueChanged;
            SaveButton.Click += SaveButton_Click;
        }

        // évènement relatif à la sélection d'une section
        private void GroupDropDownList_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (GroupDropDownList.SelectedItem != null)
            {
                selectedBookId =  int.Parse( GroupDropDownList.SelectedValue.ToString());
            }
        }
        // évènement relatif à la sélection d'une matière
        private void SubjectDropDownList_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (SubjectDropDownList.SelectedItem != null) {
                if (SubjectDropDownList.SelectedItem.DataBoundItem is Subject subject) { 
                    var data= Program.ClassSubjectList.FirstOrDefault(x => x.ClassId==selectedRoom.ClassId && x.BookId==selectedBookId && x.SubjectId==subject.Id);
                    if (data != null)
                    {
                        NoteCoefTextBox.Text = data.Coefficient.ToString();
                        NoteMaxTextBox.Text=data.NotedOn.ToString();
                    }
                }
            }
        }
        // évènement relatif à la sélection d'un élève
        private void StudentDropDownList_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (StudentDropDownList.SelectedItem != null ) {
                if (StudentDropDownList.SelectedItem.DataBoundItem is Student student) {
                    ClassTextBox.Text = selectedRoom.Name;
                    SchoolYearTextBox.Text=Program.CurrentSchoolYear.Name;
                }
            }
        }
         
        internal void InitStartup(SchoolRoom room, EvaluationSession session,int bookId) {
            selectedRoom=room;
            selectedSession=session;
            selectedBookId=bookId;
            EvaluationTextBox.Text = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? session.EnglishName : session.FrenchName;
            var students = Program.StudentRoomList.Where(x=> x.SchoolYearId == Program.CurrentSchoolYear.Id && x.RoomId==room.Id ).Select(x => x.Student);
            StudentDropDownList.DataSource = students.OrderBy(x=>x.FullName);
            StudentDropDownList.SelectedIndex = -1;
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            if (classOfRoom != null) {
                if (classOfRoom.DocumentLanguageId == 2)
                {
                    GroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                    GroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 1));
                }
                else
                {
                    if (classOfRoom.DocumentLanguageId == 0) {
                        GroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                    }
                    else
                    {
                        GroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 0));
                    }
                }
            }
            GroupDropDownList.SelectedIndex = selectedBookId;
            var subjects = Program.ClassSubjectList.Where(x => x.ClassId == room.ClassId  && x.BookId==selectedBookId).Select(x => x.Subject);
            SubjectDropDownList.DataSource = subjects;
            SubjectDropDownList.SelectedIndex = -1;
            InitEvent();
        }
        // évènement relatif à l'enregistrement d'une note dans le système
        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            if (IsValidData())
            {
                if (IsCorrectNote())
                {
                    var student = StudentDropDownList.SelectedItem.DataBoundItem as Student;
                    var subject = SubjectDropDownList.SelectedItem.DataBoundItem as Subject;
                    if (!NoteExist(subject.Id, student.Id, selectedSession.Id, Program.CurrentSchoolYear.Id, selectedBookId))
                    {
                        var studentNote = new StudentNote()
                        {
                            Date = DateTime.Now,
                            BookId = selectedBookId,
                            Comment = CommentTextBox.Text,
                            Evaluation = selectedSession,
                            EvaluationId = selectedSession.Id,
                            StudentId = student.Id,
                            Student = student,
                            SchoolYear = Program.CurrentSchoolYear,
                            SchoolYearId = Program.CurrentSchoolYear.Id,
                            Note = double.Parse(NoteTextBox.Text),
                            NoteCoef = double.Parse(NoteCoefTextBox.Text),
                            NotedOn = double.Parse(NoteMaxTextBox.Text),
                            Subject = subject,
                            SubjectId = subject.Id,
                        };
                        var isDone = studentNoteService.CreateStudentNoteAsync(studentNote).Result;
                        if (isDone)
                        {
                            //enregistrement du log
                            Log log = new()
                            {
                                UserAction = $"Ajout d'une note de {studentNote.Subject.FrenchName} pour {studentNote.Evaluation.FrenchName}  de l'élève {studentNote.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logService.CreateLog(log);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            ErrorProvider.SetError(NoteTextBox, Language.messageAddError);
                            ErrorLabel.Text = Language.messageAddError;
                        }
                    }
                    else
                    {
                        ErrorProvider.SetError(NoteTextBox, Language.messageNoteExist);
                        ErrorLabel.Text = Language.messageNoteExist;    
                    }
                }
                else
                {
                    ErrorProvider.SetError(NoteTextBox, Language.MessageNoteHigherThanMaxNote);
                    ErrorLabel.Text = Language.MessageNoteHigherThanMaxNote;
                }
            }
        }
        // vérie si la note existe déjà dans la système
        private bool NoteExist(int subjectId, int studentId, int evaluationId, int schoolYearId, int bookId)
        {
            return studentNoteService.GetNoteAsync(subjectId, studentId, evaluationId,schoolYearId, bookId).Result!=null;
        }
        //vérifie si la note n'est pas supérieur à la note max
        private bool IsCorrectNote() {

            return double.Parse(NoteTextBox.Text) <= double.Parse(NoteMaxTextBox.Text);
        }
    }
}
