
using Microsoft.Extensions.DependencyInjection;
using MySqlX.XDevAPI;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp
{
    public partial class MainForm
    {
        private SchoolRoom selectedRoom;
        private EvaluationSession selectedEvaluation;
        private EvaluationSession selectedFatherEvaluation;
        private int selectedBookId=0;
        private bool updatingStudentNoteToggleState = false;
        private bool eventFireBySelectedRoom = true;
        private void InitStudentNotePage()
        {
            InitStudentNoteGridView();
            InitStudentNoteLeftView();
            InitStudentNoteRoomDropDownList();
            InitEventsStudentNotePage();
            StudentNoteIconViewToggleButton.ToggleState = ToggleState.On;
        }

        private void InitStudentNoteGridView()
        {
            StudentNoteGridView.ReadOnly = true;
            StudentNoteGridView.AllowColumnChooser = false;
            StudentNoteGridView.ShowFilteringRow = false;
            StudentNoteGridView.AllowAddNewRow = false;
            StudentNoteGridView.AutoGenerateColumns = false;
            StudentNoteGridView.AllowDragToGroup = false;
            StudentNoteGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
            StudentNoteGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            StudentNoteGridView.EnableCustomFiltering = true;
            StudentNoteGridView.EnableFiltering = true;
        }

        private void InitStudentNoteLeftView()
        {
            var groups = new BindingList<ListViewDataItemGroup>();
            StudentNoteLeftListView.ShowCheckBoxes = false;
            foreach(var father in Program.EvaluationSessionParentList)
            {
                var group = new ListViewDataItemGroup
                {
                    Text = father.FrenchName,
                    Key = father.Id,
                    Tag = father
                };
                groups.Add(group);
                StudentNoteLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { group });
            }
            foreach (var child in Program.EvaluationSessionChildList)
            {
                var dataItem = new ListViewDataItem
                {
                    Text = child.FrenchName,
                    Key = child.Id,
                    Tag = child,
                    Group=groups.FirstOrDefault(g=> ((EvaluationSession) g.Tag).Code==child.ParentCode)
                };
                StudentNoteLeftListView.Items.Add(dataItem);
            }
            StudentNoteLeftListView.SelectedIndex =-1;
            if(StudentNoteLeftListView.SelectedItem!= null)
            {
                var sessionId= int.Parse(StudentNoteLeftListView.SelectedItem.Key.ToString());
                selectedEvaluation = Program.EvaluationSessionList.FirstOrDefault(x=>x.Id== sessionId);
            }
           
        }
        // create columns to load average list
        private void InitStudentNoteGridViewForAverages()
        {
            StudentNoteGridView.MasterTemplate.Columns.Clear();
            GridViewTextBoxColumn studentIdNumberColumn = new("Student.IdNumber");
            GridViewTextBoxColumn studentNameColumn = new("Student.FullName");
            GridViewDecimalColumn averageColumn = new("Average");
            GridViewTextBoxColumn ratingColumn = new("Rating");
            GridViewTextBoxColumn PositionColumn = new("Position");
            studentIdNumberColumn.Width = 100;
            studentNameColumn.Width = 300;
            averageColumn.Width = 80;
            ratingColumn.Width = 80;
            PositionColumn.Width = 80;
            studentIdNumberColumn.HeaderText = Language.labelStudentId;
            studentNameColumn.HeaderText = Language.labelStudent;
            averageColumn.HeaderText = Language.LabelAverage;
            ratingColumn.HeaderText = Language.LabelGrading;
            PositionColumn.HeaderText = Language.LabelPosition;
           
            this.StudentNoteGridView.Columns.Add(studentIdNumberColumn);
            this.StudentNoteGridView.Columns.Add(studentNameColumn);
            this.StudentNoteGridView.Columns.Add(averageColumn);
            this.StudentNoteGridView.Columns.Add(ratingColumn);
            this.StudentNoteGridView.Columns.Add(PositionColumn);
            foreach (GridViewDataColumn col in this.StudentNoteGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
        }
        // create columns to load evaluation note list
        private void InitStudentNoteGridViewForEvaluation()
        {
            StudentNoteGridView.Columns.Clear();
            GridViewTextBoxColumn studentIdNumberColumn = new("Student.IdNumber");
            GridViewTextBoxColumn studentNameColumn = new("Student.FullName");
            GridViewTextBoxColumn subjectColumn = new($"Subject.{GetSubjectField()}");
            GridViewDecimalColumn noteColumn = new("NoteWithMax");
            GridViewTextBoxColumn ratingColumn = new("Rating");
            GridViewTextBoxColumn PositionColumn = new("Position");
            studentIdNumberColumn.Width = 80;
            studentNameColumn.Width = 250;
            subjectColumn.Width = 250;
            noteColumn.Width = 80;
            ratingColumn.Width = 80;
            PositionColumn.Width = 80;
            studentIdNumberColumn.HeaderText = Language.labelStudentId;
            studentNameColumn.HeaderText = Language.labelStudent;
            subjectColumn.HeaderText = Language.labelSubject;
            noteColumn.HeaderText = Language.labelNote;
            ratingColumn.HeaderText = Language.LabelGrading;
            PositionColumn.HeaderText = Language.LabelPosition;

            this.StudentNoteGridView.Columns.Add(studentIdNumberColumn);
            this.StudentNoteGridView.Columns.Add(studentNameColumn);
            this.StudentNoteGridView.Columns.Add(subjectColumn);
            this.StudentNoteGridView.Columns.Add(noteColumn);
            this.StudentNoteGridView.Columns.Add(ratingColumn);
            this.StudentNoteGridView.Columns.Add(PositionColumn);
            foreach (GridViewDataColumn col in this.StudentNoteGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
        }
        private void InitStudentNoteRoomDropDownList()
        {
            StudentNoteRoomDropDownList.ValueMember = "Id";
            StudentNoteRoomDropDownList.DisplayMember = "Name";
            StudentNoteRoomDropDownList.DataSource = Program.SchoolRoomList;
            StudentNoteRoomDropDownList.SelectedIndex = -1;
            if (StudentNoteRoomDropDownList.SelectedItem != null)
            {
                if (StudentNoteRoomDropDownList.SelectedItem.DataBoundItem is SchoolRoom room)
                {
                    selectedRoom = room;
                }
            }

        }
        private void InitEventsStudentNotePage()
        {
            StudentNoteRoomDropDownList.SelectedValueChanged += StudentNoteRoomDropDownList_SelectedValueChanged;
            StudentNoteAddOneNoteMenu.Click += StudentNoteAddOneNoteMenu_Click;
            StudentNoteAddNotesMenu.Click += StudentNoteAddNotesMenu_Click;
            StudentNoteImportNoteMenu.Click += StudentNoteImportNoteMenu_Click;
            StudentNoteLeftListView.ItemMouseClick += StudentNoteLeftListView_ItemMouseClick;
            StudentNoteIconViewToggleButton.ToggleStateChanged += StudentNoteToggleButton_ToggleStateChanged;
            StudentNoteListViewToggleButton.ToggleStateChanged += StudentNoteToggleButton_ToggleStateChanged;
            StudentNoteIconViewToggleButton.ToggleStateChanging += StudentNoteToggleButton_ToggleStateChanging;
            StudentNoteListViewToggleButton.ToggleStateChanging += StudentNoteToggleButton_ToggleStateChanging;
            StudentNoteSearchTextBox.TextChanged += (o, ev) => { StudentNoteGridView.MasterTemplate.Refresh(); };
            StudentNoteGridView.CustomFiltering += StudentNoteGridView_CustomFiltering;
            StudentNoteGridView.ContextMenuOpening += StudentNoteGridView_ContextMenuOpening;
            StudentNoteGroupDropDownList.SelectedValueChanged += (o, ev) => {
                if (StudentNoteGroupDropDownList.SelectedIndex != -1)
                {
                    if (!eventFireBySelectedRoom)
                    {
                        LoadDataToStudentNoteGridView(); 
                    }
                    eventFireBySelectedRoom = false;
                }
            };
        }

        private void StudentNoteRoomDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (StudentNoteRoomDropDownList.SelectedItem != null)
            {
                if (StudentNoteRoomDropDownList.SelectedItem.DataBoundItem is SchoolRoom room)
                {
                    eventFireBySelectedRoom = true;
                    StudentNoteGroupDropDownList.Items.Clear();
                    StudentNoteSearchTextBox.Text = string.Empty;
                    selectedRoom = room;
                    var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
                    if (classOfRoom != null)
                    {

                        if (classOfRoom.DocumentLanguageId == 2)
                        {
                            StudentNoteGroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                            StudentNoteGroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 1));
                            StudentNoteGroupDropDownList.SelectedIndex = 0;
                        }
                        else
                        {
                            if (classOfRoom.DocumentLanguageId == 0)
                            {
                                StudentNoteGroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                                StudentNoteGroupDropDownList.SelectedIndex = 0;
                            }
                            else
                            {
                                StudentNoteGroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 0));
                                StudentNoteGroupDropDownList.SelectedIndex = 0;
                            }
                        }
                    }
                    //load data to grid view
                    LoadDataToStudentNoteGridView();
                }
            }

        }

        private void StudentNoteGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            //don't add  header's item
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                if (StudentNoteListViewToggleButton.ToggleState == ToggleState.On)
                {
                    Program.UserConnected.Modules = userService.GetUserModuleList(Program.UserConnected.Id).Result;
                    RadMenuItem editMenu = new(Language.labelEdit)
                    {
                        Image = AppUtilities.GetImage("Edit")
                    };
                    editMenu.Click += StudentNoteEditMenu_Click;
                    editMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 6 && x.AllowUpdate == true);
                    RadMenuItem deleteMenu = new(Language.labelDelete)
                    {
                        Image = AppUtilities.GetImage("Delete")
                    };
                    deleteMenu.Click += StudentNoteDeleteMenu_Click;
                    deleteMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 6 && x.AllowDelete == true);
                    e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                    e.ContextMenu.Items.Add(editMenu);
                    e.ContextMenu.Items.Add(deleteMenu);
                }
                else
                {
                    var data = StudentNoteGridView.CurrentRow.DataBoundItem as AverageRecord;
                    var classOfRoom = Program.SchoolClassList.First(x => x.Id == selectedRoom.ClassId);
                    RadMenuItem printStudentReportCardMenu = new($"{Language.LabelReportCard} {data.Student.FullName}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem printRoomReportCardMenu = new($" {Language.LabelReportCards} {selectedRoom.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem printStudentDisciplinarySheetMenu = new($" {Language.labelDisciplinarySheet} {data.Student.FullName}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem printRoomDisciplinarySheetMenu = new($" {Language.LabelDisciplinarySheets} {selectedRoom.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem printRoomReportMenu = new($" {Language.LabelClassroomReport} {selectedRoom.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    printStudentReportCardMenu.Click += PrintStudentReportCardMenu_Click;
                    printRoomReportCardMenu.Click += PrintRoomReportCardMenu_Click;
                    printRoomReportMenu.Click += PrintRoomReportMenu_Click;
                    e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                    e.ContextMenu.Items.Add(printStudentReportCardMenu);
                    e.ContextMenu.Items.Add(printRoomReportCardMenu);
                    e.ContextMenu.Items.Add(printStudentDisciplinarySheetMenu);
                    e.ContextMenu.Items.Add(printRoomDisciplinarySheetMenu);
                    e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                    e.ContextMenu.Items.Add(printRoomReportMenu);
                }
            }
               
        }

        private void PrintRoomReportMenu_Click(object sender, EventArgs e)
        {
            if (StudentNoteGridView.CurrentRow != null)
            {
                if (selectedEvaluation != null)
                {
                    printService.PrintClassroomReportAsync(selectedRoom.Id, selectedEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                }
            }
        }

        private void PrintRoomReportCardMenu_Click(object sender, EventArgs e)
        {
            if (StudentNoteGridView.CurrentRow != null)
            {
                if (selectedEvaluation != null)
                {
                    printService.PrintReportCardByClassroomAsync(selectedRoom.Id, selectedEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                }
            }
        }

        private void PrintStudentReportCardMenu_Click(object sender, EventArgs e)
        {

            if (StudentNoteGridView.CurrentRow != null && StudentNoteGridView.CurrentRow.DataBoundItem is AverageRecord averageRecord) {
                if (selectedEvaluation != null) {
                    printService.PrintReportCardByStudentAsync(averageRecord.Student.Id, selectedRoom.Id, selectedEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                }
            }
            
        }

        private void StudentNoteGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            if (StudentNoteSearchTextBox.Text != null)
            {
                if (StudentNoteIconViewToggleButton.ToggleState == ToggleState.On)
                {
                    e.Visible &= e.Row.Cells["Student.IdNumber"].Value.ToString().ToLower().Contains(StudentNoteSearchTextBox.Text.ToLower()) ||
                    e.Row.Cells["Student.FullName"].Value.ToString().ToLower().Contains(StudentNoteSearchTextBox.Text.ToLower()) ||
                    e.Row.Cells["Rating"].Value.ToString().ToLower().Contains(StudentNoteSearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["Position"].Value.ToString().ToLower().Contains(StudentNoteSearchTextBox.Text.ToLower()) ;
                }
                else
                {
                    if (e.Row.Cells.Count==6)
                    {
                        e.Visible &= e.Row.Cells["Student.IdNumber"].Value.ToString().ToLower().Contains(StudentNoteSearchTextBox.Text.ToLower()) ||
                       e.Row.Cells["Student.FullName"].Value.ToString().ToLower().Contains(StudentNoteSearchTextBox.Text.ToLower()) ||
                       e.Row.Cells["Rating"].Value.ToString().ToLower().Contains(StudentNoteSearchTextBox.Text.ToLower()) ||
                        e.Row.Cells["Position"].Value.ToString().ToLower().Contains(StudentNoteSearchTextBox.Text.ToLower()) ||
                       e.Row.Cells[$"Subject.{GetSubjectField()}"].Value.ToString().ToLower().Contains(StudentNoteSearchTextBox.Text.ToLower());
                    }
                }
                
            }
        }

        //permet de changer de vue:vue list, vue icon
        private void StudentNoteToggleButton_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (updatingStudentNoteToggleState)
            {
                return;
            }

            this.updatingStudentNoteToggleState = true;
            if (StudentNoteIconViewToggleButton != sender)
            {
                StudentNoteIconViewToggleButton.ToggleState = ToggleState.Off;
            }
            if (StudentNoteListViewToggleButton != sender)
            {
                StudentNoteListViewToggleButton.ToggleState = ToggleState.Off;
            }
            LoadDataToStudentNoteGridView();
            this.updatingStudentNoteToggleState = false;

            
        }
        private void StudentNoteToggleButton_ToggleStateChanging(object sender, StateChangingEventArgs args)
        {
            if (!updatingStudentNoteToggleState && args.OldValue == ToggleState.On)
            {
                args.Cancel = true;
            }
        }
        private void StudentNoteLeftListView_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                if(e.Item.Tag is EvaluationSession session)
                {
                    if (Program.EvaluationSessionParentList.Any(x => x.Id == session.Id))
                    {
                        selectedFatherEvaluation = session;
                        selectedEvaluation = null;
                        StudentNoteListViewToggleButton.Enabled=false;
                    }
                    else
                    {
                        selectedEvaluation = session;
                        selectedFatherEvaluation = null;
                        StudentNoteListViewToggleButton.Enabled = true;
                    }
                    LoadDataToStudentNoteGridView();
                }
            }
            
        }
        // select classroom to load note data
        
        // show ui to import notes
        private void StudentNoteImportNoteMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (selectedEvaluation != null)
                {
                    if (selectedRoom != null)
                    {
                       
                    }
                    else
                    {
                        RadMessageBox.Show(this, Language.MessageSelectClassroom, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                }
                else
                {
                    RadMessageBox.Show(this, Language.MessageSelectEvaluation, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        //load note in data grid
        private async void  LoadDataToStudentNoteGridView()
        {
            if (StudentNoteLeftListView.SelectedItem != null) {
                if (StudentNoteRoomDropDownList.SelectedItem != null) {
                    selectedBookId = StudentNoteGroupDropDownList.SelectedItem!=null? int.Parse(StudentNoteGroupDropDownList.SelectedItem.Value.ToString()):0;
                    if (StudentNoteIconViewToggleButton.ToggleState == ToggleState.On)
                    {
                        InitStudentNoteGridViewForAverages();
                        List<DTOItem.AverageRecord> dataSource;
                        if (selectedEvaluation != null) {
                            dataSource = await localStudentNoteService.GetEvaluationAverageListByRoom(selectedRoom.Id, selectedEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                        }
                        else
                        {
                            if (selectedFatherEvaluation.Code == "TERM01")
                            {
                                dataSource = await localStudentNoteService.GetFirstTermAverageListByRoom(selectedRoom.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                            }
                            else
                            {
                                if (selectedFatherEvaluation.Code == "TERM02")
                                {
                                    dataSource = await localStudentNoteService.GetSecondTermAverageListByRoom(selectedRoom.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                                }
                                else
                                {
                                    dataSource = await localStudentNoteService.GetThirdTermAverageListByRoom(selectedRoom.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                                }

                            }
                        }
                        StudentNoteGridView.DataSource = dataSource;
                    }
                    else
                    {
                        InitStudentNoteGridViewForEvaluation();
                        if (selectedEvaluation != null)
                        {
                            var dataSource = await localStudentNoteService.GetEvaluationNoteListByRoom(selectedRoom.Id, selectedEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                            StudentNoteGridView.DataSource = dataSource;
                        }
                        else
                        {
                            StudentNoteGridView.DataSource = null;
                        }
                    }
                }
            }
        }
        // add note list
        private void StudentNoteAddNotesMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if(selectedEvaluation!= null)
                {
                    if(selectedRoom != null)
                    {
                        var evalState = evaluationSessionService.GetEvaluationSessionStateAsync(selectedEvaluation.Id, Program.CurrentSchoolYear.Id).Result;
                        if (evalState != null)
                        {
                            if (!evalState.IsClosed)
                            {
                                selectedBookId = StudentNoteGroupDropDownList.SelectedItem != null ? int.Parse(StudentNoteGroupDropDownList.SelectedItem.Value.ToString()) : 0;
                                var form = Program.ServiceProvider.GetService<AddStudentNotesForm>();
                                var evaluationName= Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? selectedEvaluation.EnglishName : selectedEvaluation.FrenchName;
                                form.Text = $"{Language.labelSchoolYear} {Program.CurrentSchoolYear.Name} {evaluationName}";
                                form.InitStartup(selectedRoom, selectedEvaluation,selectedBookId);
                                form.Icon = this.Icon;
                                form.Show();
                            }
                            else
                            {
                                RadMessageBox.Show(this, Language.MessageClosedEvaluation, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                        }
                    }
                    else
                    {
                        RadMessageBox.Show(this, Language.MessageSelectClassroom, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                }
                else
                {
                    RadMessageBox.Show(this, Language.MessageSelectEvaluation, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        // add one note
        private void StudentNoteAddOneNoteMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (selectedEvaluation != null)
                {
                    if (selectedRoom != null)
                    {

                        var evalState = evaluationSessionService.GetEvaluationSessionStateAsync(selectedEvaluation.Id, Program.CurrentSchoolYear.Id).Result;
                        if (evalState != null)
                        {
                            if (!evalState.IsClosed)
                            {
                                selectedBookId = StudentNoteGroupDropDownList.SelectedItem != null ? int.Parse(StudentNoteGroupDropDownList.SelectedItem.Value.ToString()) : 0;
                                var form = Program.ServiceProvider.GetService<AddStudentNoteForm>();
                                form.Text = Language.labelAdd + ":.." + Language.labelNote;
                                form.InitStartup(selectedRoom, selectedEvaluation,selectedBookId);
                                form.Icon = this.Icon;
                                if (form.ShowDialog(this) == DialogResult.OK)
                                {
                                    LoadDataToStudentNoteGridView();
                                }
                            }
                            else
                            {
                                RadMessageBox.Show(this, Language.MessageClosedEvaluation, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                        }
                    }
                    else
                    {
                        RadMessageBox.Show(this, Language.MessageSelectClassroom, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                }
                else
                {
                    RadMessageBox.Show(this, Language.MessageSelectEvaluation, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            
        }
        // edit selected note
        private void StudentNoteEditMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (selectedEvaluation != null)
                {
                    var evalState = evaluationSessionService.GetEvaluationSessionStateAsync(selectedEvaluation.Id, Program.CurrentSchoolYear.Id).Result;
                    if (evalState != null)
                    {
                        if (!evalState.IsClosed)
                        {
                            if (StudentNoteGridView.CurrentRow.DataBoundItem is EvaluationRecord evaluationRecord)
                            {
                                var form = Program.ServiceProvider.GetService<EditStudentNoteForm>();
                                form.Text = Language.labelEdit + ":.." + Language.labelNote;
                                form.InitStartup(evaluationRecord.Id);
                                form.Icon = this.Icon;
                                if (form.ShowDialog(this) == DialogResult.OK)
                                {
                                    LoadDataToStudentNoteGridView();
                                }
                            }
                        }
                        else
                        {
                            RadMessageBox.Show(this, Language.MessageClosedEvaluation, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                        }
                    }
                }
                else
                {
                    RadMessageBox.Show(this, Language.MessageSelectEvaluation, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }

        // suppression d'une note
        private void StudentNoteDeleteMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (StudentNoteGridView.CurrentRow.DataBoundItem is EvaluationRecord evaluationRecord)
                {
                    DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmDelete, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var isDone = studentNoteService.DeleteStudentNoteAsync(evaluationRecord.Id).Result;
                        if (isDone)
                        {
                            // update data grid view
                            LoadDataToStudentNoteGridView();
                            //enregistrement du log
                            Log logSubscription = new()
                            {
                                UserAction = $"Suppression note de {evaluationRecord.Subject} pour {selectedEvaluation.FrenchName}  de l'élève {evaluationRecord.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
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
        }

        // return French Name or English name of subject
        private string GetSubjectField()
        {
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == selectedRoom.ClassId);

            if (classOfRoom.DocumentLanguageId == 1 || classOfRoom.DocumentLanguageId == 2 && selectedBookId == 1)
            {
                return "EnglishName";
            }
            return "FrenchName";
        }
    }
}
