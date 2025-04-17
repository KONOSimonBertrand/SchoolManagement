

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
            CreateColumnsDataGridView();

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
            LoadClassGroup(room);
            LoadComments(session.Id, room.Id, Program.CurrentSchoolYear.Id);
            InitEvent();

        }
        private void LoadClassGroup(SchoolRoom classroom) {
            var selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == selectedClass.GroupId);
            GroupDropDownList.Items.Clear();
            if (selectedClass != null)
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
                GroupDropDownList.SelectedIndex = selectedBookId;
            }

        }
        private void InitEvent()
        {
            GroupDropDownList.SelectedValueChanged += GroupDropDownList_SelectedValueChanged;
            ClassroomDropDownList.SelectedValueChanged += ClassroomDropDownList_SelectedValueChanged;
            DataGridView.CellEndEdit += GridView_CellEndEdit;
            DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            FilterTextBox.TextChanged += (o, ev) => { DataGridView.MasterTemplate.Refresh(); };
            DataGridView.ContextMenuOpening += DataGridView_ContextMenuOpening;
            ExportToExelButton.Click += (o, ev) => { AppUtilities.ExportGridViewToExcel(DataGridView, Language.labelNotes); };
            PrintButton.Click += (o, ev) => { AppUtilities.PrintGridView(DataGridView, Language.labelNotes); };
        }

        private void ClassroomDropDownList_SelectedValueChanged(object sender, Telerik.WinControls.UI.Data.ValueChangedEventArgs e)
        {
            if (ClassroomDropDownList.SelectedItem != null)
            {
                if(ClassroomDropDownList.SelectedItem.DataBoundItem is SchoolRoom room)
                {
                    selectedRoom = room;
                    students = Program.StudentRoomList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.RoomId == room.Id).Select(x => x.Student).OrderBy(x => x.FullName).ToList();
                    LoadClassGroup(room);
                }
            }
        }

        private void GroupDropDownList_SelectedValueChanged(object sender, Telerik.WinControls.UI.Data.ValueChangedEventArgs e)
        {
            if (GroupDropDownList.SelectedIndex>=0) { 
                if(int.TryParse(GroupDropDownList.SelectedValue.ToString(),out int result))
                {
                    selectedBookId =result;
                    LoadComments(selectedSession.Id, selectedRoom.Id, Program.CurrentSchoolYear.Id);
                }
                
            }
        }

        // show context menu of data grid 
        private void DataGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            //don't add  header's item
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                if (DataGridView.CurrentRow.DataBoundItem is EvaluationComment comment)
                {
                    if (comment.Id != 0)
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
        // suppression d'une comment
        private void DeleteMenu_Click(object sender, EventArgs e)
        {
            if (DataGridView.CurrentRow.DataBoundItem is EvaluationComment comment)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmDelete, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var isDone = studentNoteService.DeleteEvaluationCommentAsync(comment.Id).Result;
                    if (isDone)
                    {
                        // update data grid view
                          LoadComments(comment.EvaluationId, selectedRoom.Id, Program.CurrentSchoolYear.Id);
                        //enregistrement du log
                        Log logSubscription = new()
                        {
                            UserAction = $"Suppression  du commentaire  pour {comment.Evaluation.FrenchName}  de l'élève {comment.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
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
        // save new student comment update student comment
        private void GridView_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            var comment = e.Row.DataBoundItem as EvaluationComment;
            if (comment.Id == 0)// c'est une nouveau commentaire
            {
                if (!CommentExist(comment))
                {
                    //enregistrement de la nouvelle comment
                    var isDone = studentNoteService.CreateEvaluationCommentAsync(comment).Result;
                    if (isDone)
                    {
                        comment.Id = studentNoteService.GetCommentAsync(comment.EvaluationId, comment.StudentId,  comment.SchoolYearId, comment.BookId).Result.Id;
                        //enregistrement du log
                        Log log = new()
                        {
                            UserAction = $"Ajout d'un commentaire  pour {comment.Evaluation.FrenchName}  de l'élève {comment.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
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
                var isDone = studentNoteService.UpdateEvaluationCommentAsync(comment).Result;
                if (isDone)
                {
                    //enregistrement du log
                    Log log = new()
                    {
                        UserAction = $"Mise à jour du commetaire pour {comment.Evaluation.FrenchName}  de l'élève {comment.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
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

        // création des colonnes du comments grid view
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
            GridViewTextBoxColumn commentColumn = new("Comment");
            idColumn.IsVisible = false;
            studentIdNumberColumn.ReadOnly = true;
            studentNameColumn.ReadOnly = true;
            studentIdNumberColumn.HeaderText = Language.labelStudentId;
            studentNameColumn.HeaderText = Language.labelStudent;
            commentColumn.HeaderText = Language.LabelComment;
            studentIdNumberColumn.Width = 80;
            studentNameColumn.Width = 250;
            commentColumn.Width = 250;
            DataGridView.Columns.Add(idColumn);
            DataGridView.Columns.Add(studentIdNumberColumn);
            DataGridView.Columns.Add(studentNameColumn);
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
        private async void LoadComments(int evaluationId, int roomId, int schoolYearId)
        {
            var comments = await studentNoteService.GetCommentsByClassroomAsync(roomId,evaluationId, schoolYearId);
            var selectedComments = comments.Where(x => x.BookId == selectedBookId).ToList();
            foreach (var student in students)
            {
                
                var comment = selectedComments.FirstOrDefault(x => x.StudentId == student.Id);
                if (comment == null)
                {
                    comment =new EvaluationComment()
                    {
                        Id = 0,
                        Comment = string.Empty,
                        StudentId = student.Id,
                        Student = student,
                        Evaluation = selectedSession,
                        SchoolYear = Program.CurrentSchoolYear,
                        SchoolYearId = Program.CurrentSchoolYear.Id,
                        BookId = selectedBookId,
                        Date = DateTime.Now,
                        EvaluationId = selectedSession.Id,
                    };
                    selectedComments.Add(comment);
                } 
            }
            DataGridView.DataSource = selectedComments;

        }

        private bool CommentExist(EvaluationComment comment)
        {
            return studentNoteService.GetCommentAsync(comment.EvaluationId,comment.StudentId, comment.SchoolYearId, comment.BookId).Result != null;
        }

    }
}
