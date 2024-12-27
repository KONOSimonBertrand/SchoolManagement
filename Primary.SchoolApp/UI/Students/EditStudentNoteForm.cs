

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Telerik.Reporting;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class EditStudentNoteForm : SchoolManagement.UI.EditStudentNoteForm
    {
        private readonly IStudentNoteService studentNoteService;
        private readonly ClientApp clientApp;
        private readonly ILogService logService;
        private StudentNote selectedNote;
        public EditStudentNoteForm(IStudentNoteService studentNoteService, ClientApp clientApp, ILogService logService)
        {
            this.studentNoteService = studentNoteService;
            this.clientApp = clientApp;
            this.logService = logService;
            StudentDropDownList.ValueMember = "Id";
            StudentDropDownList.DisplayMember = "FullName";
            SubjectDropDownList.ValueMember = "Id";
            SubjectDropDownList.DisplayMember = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "FrenchName" : "EnglishName";
            GroupDropDownList.ReadOnly = true;
            SubjectDropDownList.ReadOnly= true;
            StudentDropDownList.ReadOnly=true;
            InitEvent();
        }

        private void InitEvent()
        {
            SaveButton.Click += SaveButton_Click;
        }
        internal void InitStartup(int studentNoteId)
        {
            selectedNote=studentNoteService.GetNoteAsync(studentNoteId).Result;
            if (selectedNote != null) { 
                var students=new List<Student>() { selectedNote.Student };
                StudentDropDownList.DataSource = students;
                EvaluationTextBox.Text = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? selectedNote.Evaluation.EnglishName : selectedNote.Evaluation.FrenchName;
                SchoolYearTextBox.Text = Program.CurrentSchoolYear.Name;
                NoteTextBox.Text = selectedNote.Note.ToString();
                CommentTextBox.Text = selectedNote.Comment;
                //get student class
                var studentRoom=Program.StudentRoomList.FirstOrDefault(x=>x.StudentId==selectedNote.StudentId);
                var room=Program.SchoolRoomList.FirstOrDefault(x=>x.Id==studentRoom.RoomId);
                var classOfRoom=Program.SchoolClassList.FirstOrDefault(x=>x.Id==room.ClassId);
                ClassTextBox.Text = room.Name;
                //add class section
                if (classOfRoom.DocumentLanguageId == 2)
                {
                    GroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                    GroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 1));
                    GroupDropDownList.SelectedIndex = 0;
                }
                else
                {
                    if (classOfRoom.DocumentLanguageId == 0)
                    {
                        GroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                        GroupDropDownList.SelectedIndex = 0;
                    }
                    else
                    {
                        GroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 0));
                        GroupDropDownList.SelectedIndex = 0;
                    }
                }
              // add subject
               var subjects=new List<Subject>() {selectedNote.Subject};
                SubjectDropDownList.DataSource = subjects;
                NoteCoefTextBox.Text=selectedNote.NoteCoef.ToString();
                NoteMaxTextBox.Text=selectedNote.NotedOn.ToString();
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (IsCorrectNote())
                {   
                    selectedNote.Note=Convert.ToDouble(NoteTextBox.Text);
                    selectedNote.Comment = CommentTextBox.Text;
                    var isDone = studentNoteService.UpdateStudentNoteAsync(selectedNote).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log log = new()
                        {
                            UserAction = $"Mise à jour de la note de {selectedNote.Subject.FrenchName} pour {selectedNote.Evaluation.FrenchName}  de l'élève {selectedNote.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
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
                    ErrorProvider.SetError(NoteTextBox, Language.MessageNoteHigherThanMaxNote);
                    ErrorLabel.Text = Language.MessageNoteHigherThanMaxNote;
                }
            }
        }
        private bool IsCorrectNote()
        {

            return double.Parse(NoteTextBox.Text) <= double.Parse(NoteMaxTextBox.Text);
        }
    }
}
