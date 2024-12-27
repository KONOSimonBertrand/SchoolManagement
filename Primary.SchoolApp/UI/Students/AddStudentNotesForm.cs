
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class AddStudentNotesForm : SchoolManagement.UI.EditStudentNotesForm
    {
        private readonly IStudentNoteService studentNoteService;
        private SchoolRoom selectedRoom;
        private EvaluationSession selectedSession;
        private int selectedBookId;
        private readonly ClientApp clientApp;
        private readonly ILogService logService;
        private readonly IUserService userService;
        private List<Student> students;
        public AddStudentNotesForm(IStudentNoteService studentNoteService, ILogService logService, ClientApp clientApp, IUserService userService)
        {
            this.studentNoteService = studentNoteService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.userService = userService;
            CreateColumnsDataGridView();
            
        }

        private void InitEvent()
        {
            SubjectDropDownList.SelectedValueChanged += SubjectDropDownList_SelectedValueChanged;
            GroupDropDownList.SelectedValueChanged += GroupDropDownList_SelectedValueChanged;
            DataGridView.CellEndEdit += GridView_CellEndEdit;
            DataGridView.CellValidating += GridView_CellValidating;
            DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            FilterTextBox.TextChanged += (o, ev) => { DataGridView.MasterTemplate.Refresh(); };
            DataGridView.ContextMenuOpening += DataGridView_ContextMenuOpening;
            ExportToExelButton.Click += (o, ev) => { AppUtilities.ExportGridViewToExcel(DataGridView,Language.labelNotes); };
            PrintButton.Click += (o, ev) => { AppUtilities.PrintGridView(DataGridView, Language.labelNotes); };
        }
        // show context menu of data grid 
        private void DataGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            //don't add  header's item
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                if(DataGridView.CurrentRow.DataBoundItem is StudentNote note)
                {
                    if (note.Id != 0)
                    {
                        Program.UserConnected.Modules = userService.GetUserModuleList(Program.UserConnected.Id).Result;
                        RadMenuItem deleteMenu = new(Language.labelDelete)
                        {
                            Image = AppUtilities.GetImage("Delete")
                        };
                        deleteMenu.Click += DeleteMenu_Click;
                        deleteMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 6 && x.AllowDelete == true);
                        e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                        e.ContextMenu.Items.Add(deleteMenu);
                    }
                }
            }
            }
        // suppression d'une note
        private void DeleteMenu_Click(object sender, EventArgs e)
        {
            if (DataGridView.CurrentRow.DataBoundItem is StudentNote note)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmDelete, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var isDone = studentNoteService.DeleteStudentNoteAsync(note.Id).Result;
                    if (isDone)
                    {
                        // update data grid view
                        LoadNotes(note.SubjectId, note.EvaluationId, selectedRoom.Id, Program.CurrentSchoolYear.Id);
                        //enregistrement du log
                        Log logSubscription = new()
                        {
                            UserAction = $"Suppression note de {note.Subject.FrenchName} pour {note.Evaluation.FrenchName}  de l'élève {note.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(logSubscription);
                    }
                    else
                    {
                        RadMessageBox.Show(Language.messageDeleteError, Language.labelDiscipline, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
            }
        }
        // validation d'une note controle des erreurs
        private void GridView_CellValidating(object sender, CellValidatingEventArgs e)
        {
            if (DataGridView.IsInEditMode)
            {
                if (e.Column.Name == "Note")
                {
                    var studentNote = e.Row.DataBoundItem as StudentNote;

                    if (Convert.ToDouble(e.Value) > studentNote.NotedOn)
                    {
                        e.Cancel = true;
                        e.Row.ErrorText = Language.MessageNoteHigherThanMaxNote;
                    }
                    else
                    {
                        e.Row.ErrorText = string.Empty;
                    }
                }
            }
        }

        // save new student note update student note
        private void GridView_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            var studentNote = e.Row.DataBoundItem as StudentNote;
            if (Convert.ToDouble(NoteMaxTextBox.Text) == studentNote.NotedOn)
            {
                if (studentNote.Id == 0)// c'est une nouvelle note
                {
                    if (!NoteExist(studentNote))
                    {
                        //enregistrement de la nouvelle note
                        var isDone = studentNoteService.CreateStudentNoteAsync(studentNote).Result;
                        if (isDone)
                        {
                            studentNote.Id = studentNoteService.GetNoteAsync(studentNote.SubjectId, studentNote.StudentId, studentNote.EvaluationId, studentNote.SchoolYearId, studentNote.BookId).Result.Id;
                            //enregistrement du log
                            Log log = new()
                            {
                                UserAction = $"Ajout d'une note de {studentNote.Subject.FrenchName} pour {studentNote.Evaluation.FrenchName}  de l'élève {studentNote.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logService.CreateLog(log);
                        }
                        else
                        {
                            RadMessageBox.Show(Language.messageAddError, Language.labelNotes, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                    }
                }
                else
                {
                    var isDone = studentNoteService.UpdateStudentNoteAsync(studentNote).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log log = new()
                        {
                            UserAction = $"Mise à jour de la note de {studentNote.Subject.FrenchName} pour {studentNote.Evaluation.FrenchName}  de l'élève {studentNote.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                    }
                    else
                    {
                        RadMessageBox.Show(Language.messageUpdateError, Language.labelNotes, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
                DataGridView.TableElement.Update(GridUINotifyAction.DataChanged, null);
                DataGridView.Refresh();
            }
            else
            {
                RadMessageBox.Show(Language.MessageEvaluationBadNoteMax,Language.labelNotes,MessageBoxButtons.OK,RadMessageIcon.Error);
            }
                
        }
        //filtre le datagridview en fonction des données de searchTextBox
        private void DataGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            if (FilterTextBox.Text != null)
            {
                e.Visible &= e.Row.Cells["Student.IdNumber"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower()) ||
                     e.Row.Cells["Student.FullName"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
            }
        }
        // évènement relatif à la sélection d'une matère
        private void SubjectDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SubjectDropDownList.SelectedItem != null)
            {
                if (SubjectDropDownList.SelectedItem.DataBoundItem is Subject subject)
                {
                    var data = Program.ClassSubjectList.FirstOrDefault(x => x.ClassId == selectedRoom.ClassId && x.BookId == selectedBookId && x.SubjectId == subject.Id);
                    if (data != null)
                    {
                        NoteMaxTextBox.Text = data.NotedOn.ToString();
                        NoteCoefTextBox.Text = data.Coefficient.ToString();
                    }
                    LoadNotes(subject.Id, selectedSession.Id, selectedRoom.Id, Program.CurrentSchoolYear.Id);
                    DataGridView.Enabled = IsValidData();
                }
            }
        }
        // évènement relatif à la sélection d'une section
        private void GroupDropDownList_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (GroupDropDownList.SelectedItem != null)
            {
                selectedBookId = int.Parse(GroupDropDownList.SelectedValue.ToString());
                var subjects = Program.ClassSubjectList.Where(x => x.ClassId == selectedRoom.ClassId && x.BookId == selectedBookId).Select(x => x.Subject);
                SubjectDropDownList.DataSource = subjects.OrderBy(x => x.FrenchName);
            }
        }

        internal void InitStartup(SchoolRoom room, EvaluationSession session,int bookId)
        {
            selectedRoom = room;
            selectedSession = session;
            selectedBookId=bookId;
            EvaluationLabel.Text = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? session.EnglishName : session.FrenchName;
            ClassroomLabel.Text = room.Name;
            students = Program.StudentRoomList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.RoomId == room.Id).Select(x => x.Student).OrderBy(x=>x.FullName).ToList();
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            if (classOfRoom != null)
            {
                if (classOfRoom.DocumentLanguageId == 2)
                {
                    GroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                    GroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 1));
                }
                else
                {
                    if (classOfRoom.DocumentLanguageId == 0)
                    {
                        GroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                    }
                    else
                    {
                        GroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 0));
                    }
                }
                GroupDropDownList.SelectedIndex =bookId;
            }
            var subjects = Program.ClassSubjectList.Where(x => x.ClassId == room.ClassId && x.BookId == selectedBookId).Select(x => x.Subject);
            SubjectDropDownList.DataSource = subjects.OrderBy(x=>x.FrenchName);
            SubjectDropDownList.SelectedIndex = -1;
            InitEvent();

        }
        // création des colonnes du data grid view
        private void CreateColumnsDataGridView()
        {
            DataGridView.EnableGrouping = false;
            DataGridView.EnableHotTracking = true;
            DataGridView.ShowFilteringRow = false;
            DataGridView.EnableFiltering = true;
            DataGridView.AllowAddNewRow = false;
            DataGridView.EnableCustomFiltering = true;
            DataGridView.AllowDeleteRow = false;
            DataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
            DataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            DataGridView.EnableCustomFiltering = true;
            DataGridView.EnableFiltering = true;
            GridViewDecimalColumn idColumn = new("Id");
            GridViewTextBoxColumn studentIdNumberColumn = new("Student.IdNumber");
            GridViewTextBoxColumn studentNameColumn = new("Student.FullName");
            GridViewDecimalColumn noteColumn = new("Note");
            GridViewTextBoxColumn commentColumn = new("Comment");
            idColumn.IsVisible = false;
            studentIdNumberColumn.ReadOnly = true;
            studentNameColumn.ReadOnly = true;
            studentIdNumberColumn.HeaderText = Language.labelStudentId;
            studentNameColumn.HeaderText = Language.labelStudent;
            noteColumn.HeaderText = Language.labelNote;
            commentColumn.HeaderText = Language.LabelComment;
            studentIdNumberColumn.Width = 80;
            studentNameColumn.Width = 250;
            noteColumn.Width = 80;
            commentColumn.Width = 250;
            DataGridView.Columns.Add(idColumn);
            DataGridView.Columns.Add(studentIdNumberColumn);
            DataGridView.Columns.Add(studentNameColumn);
            DataGridView.Columns.Add(noteColumn);
            DataGridView.Columns.Add(commentColumn);

            ConditionalFormattingObject c1 = new("Orange, applied to entire row", ConditionTypes.Equal, "0", "", true)
            {
                RowBackColor = Color.FromArgb(255, 209, 140),
                CellBackColor = Color.FromArgb(255, 209, 140),
                RowForeColor = Color.Black,
                CellForeColor = Color.Black
            };
            idColumn.ConditionalFormattingObjectList.Add(c1);
            foreach (GridViewDataColumn col in this.DataGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
        }
        // chargement des données dans le grid view
        private async void LoadNotes(int subjectId, int evaluationId, int roomId, int schoolYearId)
        {
            var notesToLoad = new List<StudentNote>();
            var data = await studentNoteService.GetNotesBySubjectAsync(subjectId, evaluationId, roomId, schoolYearId);
            var notes=data.Where(x=>x.BookId==selectedBookId).ToList();
            var subject = SubjectDropDownList.SelectedItem.DataBoundItem as Subject;
            foreach (var student in students)
            {
                var studentNote = notes.FirstOrDefault(x => x.StudentId == student.Id);
                if (studentNote != null)
                {
                    studentNote.Student = student;
                    studentNote.Evaluation = selectedSession;
                    studentNote.Subject = subject;
                }
                else
                {
                    studentNote = new StudentNote()
                    {
                        Id = 0,
                        Note = 0,
                        NoteCoef = double.Parse(NoteCoefTextBox.Text),
                        NotedOn = double.Parse(NoteMaxTextBox.Text),
                        SubjectId = subjectId,
                        StudentId = student.Id,
                        Student = student,
                        Subject = subject,
                        Evaluation = selectedSession,
                        SchoolYearId = Program.CurrentSchoolYear.Id,
                        BookId = selectedBookId,
                        Date = DateTime.Now,
                        EvaluationId = selectedSession.Id,

                    };
                }
                notesToLoad.Add(studentNote);
            }
            DataGridView.DataSource = notesToLoad;

        }

        private bool NoteExist(StudentNote note)
        {
            return studentNoteService.GetNoteAsync(note.SubjectId, note.StudentId, note.EvaluationId, note.SchoolYearId, note.BookId).Result != null;
        }
        

    }
}
