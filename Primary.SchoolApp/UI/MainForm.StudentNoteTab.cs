
using Microsoft.Extensions.DependencyInjection;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.Reporting.Processing;
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
        private int selectedBookId = 0;
        private bool updatingStudentNoteToggleState = false;
        private bool eventFireBySelectedRoom = true;
        private readonly Dictionary<int?, List<RecapNoteItem>> recapNotesTaskResult = new();
        private readonly Dictionary<int?, List<StudentDisciplinarySheet>> disciplinarySheetTaskResult = new();
        private readonly Dictionary<int?, ClassroomReport> classroomReportTaskResult = new();
        private readonly Dictionary<int?, ClassGroupReport> classGroupReportTaskResult = new();
        private readonly Dictionary<int?, List<TermReportCard>> annualReportCardTaskResult = new();
        private readonly Dictionary<int?, List<TermReportCard>> termReportCardTaskResult = new();
        private readonly Dictionary<int?, List<EvaluationReportCard>> evaluationReportCardTaskResult = new();
        private string selectedArea = "room";
        private int runningTaskCount = 0;
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
            foreach (var father in Program.EvaluationSessionParentList.OrderBy(e => e.Sequence))
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
            foreach (var child in Program.EvaluationSessionChildList.OrderBy(e => e.Sequence))
            {
                var dataItem = new ListViewDataItem
                {
                    Text = child.FrenchName,
                    Key = child.Id,
                    Tag = child,
                    Group = groups.FirstOrDefault(g => ((EvaluationSession)g.Tag).Id == child.Mother)
                };
                StudentNoteLeftListView.Items.Add(dataItem);
            }
            StudentNoteLeftListView.SelectedIndex = -1;
            if (StudentNoteLeftListView.SelectedItem != null)
            {
                var sessionId = int.Parse(StudentNoteLeftListView.SelectedItem.Key.ToString());
                selectedEvaluation = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == sessionId);
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

            StudentNoteRoomDropDownList.DataSource = GetUserConnectedClassrooms();
            StudentNoteRoomDropDownList.SelectedIndex = -1;
            if (StudentNoteRoomDropDownList.SelectedItem != null)
            {
                if (StudentNoteRoomDropDownList.SelectedItem.DataBoundItem is SchoolRoom room)
                {
                    selectedRoom = room;
                }
            }

        }

        // Extraction des salles de classe alloués à la personne connectée
        internal static IList<SchoolRoom> GetUserConnectedClassrooms()
        {
            if (Program.UserConnected.UserName == "root") return Program.SchoolRoomList;
            var rooms = new List<SchoolRoom>();
            if (Program.UserConnected.EmployeeId.HasValue)
            {
                rooms = Program.EmployeeRoomList.Where(x => x.EmployeeId == Program.UserConnected.EmployeeId.Value).Select(x => x.Room).ToList();
            }
            return rooms;
        }
        //init event of page
        private void InitEventsStudentNotePage()
        {
            StudentNoteRoomDropDownList.SelectedValueChanged += StudentNoteRoomDropDownList_SelectedValueChanged;
            StudentNoteAddOneNoteMenu.Click += StudentNoteAddOneNoteMenu_Click;
            StudentNoteAddNotesMenu.Click += StudentNoteAddNotesMenu_Click;
            StudentNoteImportNoteMenu.Click += StudentNoteImportNoteMenu_Click;
            StudentNoteAddCommentMenu.Click += StudentNoteAddCommentMenu_Click;
            StudentNoteLeftListView.ItemMouseClick += StudentNoteLeftListView_ItemMouseClick;
            StudentNoteIconViewToggleButton.ToggleStateChanged += StudentNoteToggleButton_ToggleStateChanged;
            StudentNoteListViewToggleButton.ToggleStateChanged += StudentNoteToggleButton_ToggleStateChanged;
            StudentNoteIconViewToggleButton.ToggleStateChanging += StudentNoteToggleButton_ToggleStateChanging;
            StudentNoteListViewToggleButton.ToggleStateChanging += StudentNoteToggleButton_ToggleStateChanging;
            StudentNoteSearchTextBox.TextChanged += (o, ev) => { StudentNoteGridView.MasterTemplate.Refresh(); };
            StudentNoteGridView.CustomFiltering += StudentNoteGridView_CustomFiltering;
            StudentNoteGridView.ContextMenuOpening += StudentNoteGridView_ContextMenuOpening;
            StudentNoteGroupDropDownList.SelectedValueChanged += (o, ev) =>
            {
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

        // Ajout des observations des enseignants 
        private void StudentNoteAddCommentMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (selectedEvaluation != null || selectedFatherEvaluation!=null)
                {
                    if (selectedRoom != null)
                    {
                        int evalId= selectedEvaluation!=null? selectedEvaluation.Id:selectedFatherEvaluation.Id;
                        // Si c'est un trimestre,on vérifie si toutes les évaluations sont clôturées
                        // Si c'est une évaluation on véririe si elle est cloturée
                        var evaluationStates = evaluationSessionService.GetEvaluationSessionStateListBySchoolYearAsync(Program.CurrentSchoolYear.Id).Result;
                        var closedList = evaluationStates.Where(x => x.IsClosed).Select(x => x.EvaluationId);
                        bool isClosed = true;
                        if (selectedEvaluation != null)
                        {
                            isClosed = closedList.Contains(selectedEvaluation.Id);
                        }
                        else
                        {
                            var childEvaluations = Program.EvaluationSessionList.Where(x => x.Mother == selectedFatherEvaluation.Id).Select(x=>x.Id);
                            var childClosed = closedList.Join(childEvaluations, x => x ,y=>y,(x,y)=>new { x = y });
                            isClosed = childEvaluations.Count() == childClosed.Count();
                        }

                        if (!isClosed)
                        {
                            selectedBookId = StudentNoteGroupDropDownList.SelectedItem != null ? int.Parse(StudentNoteGroupDropDownList.SelectedItem.Value.ToString()) : 0;
                            var eval = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evalId);
                            var form = Program.ServiceProvider.GetService<EditEvaluationCommentsForm>();
                            var evaluationName = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? eval.EnglishName : eval.FrenchName;
                            form.Text = $"{Language.labelSchoolYear} {Program.CurrentSchoolYear.Name} {evaluationName}";
                            form.InitStartup(selectedRoom, eval, selectedBookId);
                            form.Icon = this.Icon;
                            form.StartPosition = FormStartPosition.CenterScreen;
                            form.WindowState = FormWindowState.Maximized;
                            form.Show();
                        }
                        else
                        {
                            RadMessageBox.Show(this, Language.MessageClosedEvaluation, "", MessageBoxButtons.OK, RadMessageIcon.Info);
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
                    var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
                    if (classOfRoom != null)
                    {

                        if (classGroup.DocumentLanguageId == 2)
                        {
                            StudentNoteGroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                            StudentNoteGroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 1));
                            StudentNoteGroupDropDownList.SelectedIndex = 0;
                        }
                        else
                        {
                            if (classGroup.DocumentLanguageId == 0)
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
                    RadMenuItem showStudentReportCardMenu = new($"{Language.LabelReportCard} {data.Student.FullName}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem showRoomReportCardMenu = new($" {Language.LabelReportCards} {selectedRoom.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem showRoomAnnualReportCardMenu = new($" {Language.LabelAnnualReportCard} {selectedRoom.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem showStudentDisciplinarySheetMenu = new($" {Language.labelDisciplinarySheet} {data.Student.FullName}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem showRoomDisciplinarySheetMenu = new($" {Language.LabelDisciplinarySheets} {selectedRoom.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem showRoomReportMenu = new($" {Language.LabelClassroomReport} {selectedRoom.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    var group = Program.SchoolGroupList.FirstOrDefault(s => s.Id == classOfRoom.GroupId);
                    var statisticTitle = selectedFatherEvaluation != null ? Language.LabelQuarterlyStatistic : Language.LabelEvaluationStatistic;
                    RadMenuItem showGroupStatisticReportMenu = new($" {statisticTitle} {group.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem showGroupAnnualStatisticReportMenu = new($" {Language.LabelAnnualStatistic} {group.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem showRoomAnnualRecapMenu = new($" {Language.LabelAnnualSummaryNotes} {selectedRoom.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem showClassAnnualRecapMenu = new($" {Language.LabelAnnualSummaryNotes} {classOfRoom.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    RadMenuItem showGroupAnnualRecapMenu = new($" {Language.LabelAnnualSummaryNotes} {group.Name}")
                    {
                        Image = AppUtilities.GetImage("View")
                    };
                    showStudentReportCardMenu.Click += async (sender, e) => await ShowStudentReportCardMenu_Click(sender, e);
                    showRoomReportCardMenu.Click += async (sender, e) => await ShowRoomReportCardMenu_Click(sender, e);
                    showRoomAnnualReportCardMenu.Click += async (sender, e) => await ShowRoomAnnualReportCardMenu_Click(sender, e);
                    showRoomReportMenu.Click += async (sender, e) => await ShowClassRoomReportMenu_Click(sender, e);
                    showGroupStatisticReportMenu.Click += async (sender, e) => await ShowGroupStatisticReportMenu_Click(sender, e);
                    showGroupAnnualStatisticReportMenu.Click += async (sender, e) => await ShowAnnualStatisticReportMenu_Click(sender, e);
                    showStudentDisciplinarySheetMenu.Click += async (sender, e) => await ShowStudentDisciplinarySheetMenu_Click(sender, e);
                    showRoomDisciplinarySheetMenu.Click += async (sender, e) => await ShowRoomDisciplinarySheetMenu_Click(sender, e);
                    showRoomAnnualRecapMenu.Click += async (sender, e) => await ShowRoomAnnualRecapMenu_Click(sender, e);
                    showClassAnnualRecapMenu.Click += async (sender, e) => await ShowClassAnnualRecapMenu_Click(sender, e);
                    showGroupAnnualRecapMenu.Click += async (sender, e) => await ShowGroupAnnualRecapMenu_Click(sender, e);
                    e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                    e.ContextMenu.Items.Add(showStudentReportCardMenu);
                    e.ContextMenu.Items.Add(showRoomReportCardMenu);


                    if (selectedFatherEvaluation != null)
                    {
                        e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                        e.ContextMenu.Items.Add(showStudentDisciplinarySheetMenu);
                        e.ContextMenu.Items.Add(showRoomDisciplinarySheetMenu);
                    }
                    e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                    e.ContextMenu.Items.Add(showRoomReportMenu);
                    e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                    e.ContextMenu.Items.Add(showGroupStatisticReportMenu);
                    if (selectedFatherEvaluation != null)
                    {
                        e.ContextMenu.Items.Add(showGroupAnnualStatisticReportMenu);
                        e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                        e.ContextMenu.Items.Add(showRoomAnnualReportCardMenu);
                        e.ContextMenu.Items.Add(showRoomAnnualRecapMenu);
                        e.ContextMenu.Items.Add(showClassAnnualRecapMenu);
                        e.ContextMenu.Items.Add(showGroupAnnualRecapMenu);

                    }
                }
            }

        }
        private async Task ShowRoomReportCardMenu_Click(object sender, EventArgs e)
        {
            Task task;
            selectedArea = "room";
            if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
            {
                this.TaskWaitingBar.StartWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
            }

            task = selectedEvaluation != null ? Task.Run(RunGetEvaluationReportCard) : Task.Run(RunGetTermReportCard);
            runningTaskCount++;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            await task;
            if (selectedEvaluation != null)
            {
                if (evaluationReportCardTaskResult.TryGetValue(task.Id, out var result))
                {
                    var form = Program.ServiceProvider.GetService<ReportViewerForm>();
                    form.Icon = this.Icon;
                    form.LoadEvaluationReportCard(result);
                    form.WindowState = FormWindowState.Maximized;
                    form.Show();
                    evaluationReportCardTaskResult.Remove(task.Id);
                }
            }
            else
            {
                if (termReportCardTaskResult.TryGetValue(task.Id, out var result))
                {
                    var form = Program.ServiceProvider.GetService<ReportViewerForm>();
                    form.Icon = this.Icon;
                    form.LoadTermReportCard(result);
                    form.WindowState = FormWindowState.Maximized;
                    form.Show();
                    termReportCardTaskResult.Remove(task.Id);
                }
            }
        }
        private async Task ShowStudentReportCardMenu_Click(object sender, EventArgs e)
        {
            Task task;
            selectedArea = "student";
            if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
            {
                this.TaskWaitingBar.StartWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
            }

            task = selectedEvaluation != null ? Task.Run(RunGetEvaluationReportCard) : Task.Run(RunGetTermReportCard);
            runningTaskCount++;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            await task;
            if (selectedEvaluation != null)
            {
                if (evaluationReportCardTaskResult.TryGetValue(task.Id, out var result))
                {
                    var form = Program.ServiceProvider.GetService<ReportViewerForm>();
                    form.Icon = this.Icon;
                    form.LoadEvaluationReportCard(result);
                    form.WindowState = FormWindowState.Maximized;
                    form.Show();
                    evaluationReportCardTaskResult.Remove(task.Id);
                }
            }
            else
            {
                if (termReportCardTaskResult.TryGetValue(task.Id, out var result))
                {
                    var form = Program.ServiceProvider.GetService<ReportViewerForm>();
                    form.Icon = this.Icon;
                    form.LoadTermReportCard(result);
                    form.WindowState = FormWindowState.Maximized;
                    form.Show();
                    termReportCardTaskResult.Remove(task.Id);
                }
            }
        }
        // Extraction des bulletins d'une évaluation
        private void RunGetEvaluationReportCard()
        {

            if (StudentNoteGridView.CurrentRow != null && StudentNoteGridView.CurrentRow.DataBoundItem is AverageRecord selectedRecord)
            {
                if (selectedArea == "student")
                {
                    var task = reportCardService.GetEvaluationReportCardByStudentAsync(selectedRecord.Student.Id, selectedRoom.Id, selectedEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                    evaluationReportCardTaskResult.Add(Task.CurrentId, new() { task.Result });
                }
                else
                {
                    var task = reportCardService.GetEvaluationReportCardByClassRoomAsync(selectedRoom.Id, selectedEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                    evaluationReportCardTaskResult.Add(Task.CurrentId, task.Result);
                }
                runningTaskCount--;
                this.TaskWaitingBar.Text = runningTaskCount.ToString();
                if (runningTaskCount == 0)
                {
                    this.TaskWaitingBar.StopWaiting();
                    this.TaskWaitingBar.ResetWaiting();
                    this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
                }
            }
        }

        // Extrqction des bulletins trimestriels
        private void RunGetTermReportCard()
        {

            if (StudentNoteGridView.CurrentRow != null && StudentNoteGridView.CurrentRow.DataBoundItem is AverageRecord selectedRecord)
            {
                if (selectedArea == "student")
                {
                    var task = reportCardService.GetTermReportCardByStudentAsync(selectedRecord.Student.Id, selectedRoom.Id, selectedFatherEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                    termReportCardTaskResult.Add(Task.CurrentId, new() { task.Result });
                }
                else
                {
                    var task = reportCardService.GetTermReportCardByClassRoomAsync(selectedRoom.Id, selectedFatherEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                    termReportCardTaskResult.Add(Task.CurrentId, task.Result);
                }
                runningTaskCount--;
                this.TaskWaitingBar.Text = runningTaskCount.ToString();
                if (runningTaskCount == 0)
                {
                    this.TaskWaitingBar.StopWaiting();
                    this.TaskWaitingBar.ResetWaiting();
                    this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
                }
            }
        }
        private async Task ShowRoomAnnualReportCardMenu_Click(object sender, EventArgs e)
        {
            Task task;
            selectedArea = "room";
            if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
            {
                this.TaskWaitingBar.StartWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
            }

            task = Task.Run(GetRunAnnualReportCard);
            runningTaskCount++;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            await task;
            if (annualReportCardTaskResult.TryGetValue(task.Id, out var result))
            {
                var form = Program.ServiceProvider.GetService<ReportViewerForm>();
                form.Icon = this.Icon;
                form.LoadAnnualReportCard(result);
                form.WindowState = FormWindowState.Maximized;
                form.Show();
                annualReportCardTaskResult.Remove(task.Id);
            }
        }
        // Extraction des bulletins annuels 
        private void GetRunAnnualReportCard()
        {

            if (StudentNoteGridView.CurrentRow != null && StudentNoteGridView.CurrentRow.DataBoundItem is AverageRecord selectedRecord)
            {
                if (selectedArea == "student")
                {
                    var task = reportCardService.GetTermReportCardByStudentAsync(selectedRecord.Student.Id, selectedRoom.Id, selectedFatherEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                    annualReportCardTaskResult.Add(Task.CurrentId, new() { task.Result });
                }
                else
                {
                    var task = reportCardService.GetAnnualReportCardByClassRoomAsync(selectedRoom.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                    annualReportCardTaskResult.Add(Task.CurrentId, task.Result);
                }
                runningTaskCount--;
                this.TaskWaitingBar.Text = runningTaskCount.ToString();
                if (runningTaskCount == 0)
                {
                    this.TaskWaitingBar.StopWaiting();
                    this.TaskWaitingBar.ResetWaiting();
                    this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
                }
            }
        }
        private async Task ShowAnnualStatisticReportMenu_Click(object sender, EventArgs e)
        {
            if (StudentNoteGridView.CurrentRow != null)
            {
                selectedArea = "annual";
                if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
                {
                    this.TaskWaitingBar.StartWaiting();
                    this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
                }
                var task = Task.Run(RunGetStatisticReport);
                runningTaskCount++;
                this.TaskWaitingBar.Text = runningTaskCount.ToString();
                await task;
                if (classGroupReportTaskResult.TryGetValue(task.Id, out var result))
                {
                    var form = Program.ServiceProvider.GetService<ReportViewerForm>();
                    form.Icon = this.Icon;
                    form.LoadClassGroupReport(result);
                    form.WindowState = FormWindowState.Maximized;
                    form.Show();
                    disciplinarySheetTaskResult.Remove(task.Id);
                }
            }

        }
        // Extraction des statistique d'un groupe
        private void RunGetStatisticReport()
        {
            Task<ClassGroupReport> getDataTask = null;
            var selectedClass = Program.SchoolClassList.FirstOrDefault(c => c.Id == selectedRoom.ClassId);

            if (selectedArea == "annual")
            {
                getDataTask = reportCardService.GetAnnualReportByClassGroupAsync(selectedClass.GroupId, Program.CurrentSchoolYear.Id, selectedBookId);
            }
            else
            {
                int evalId = selectedEvaluation != null ? selectedEvaluation.Id : selectedFatherEvaluation.Id;
                var eval = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evalId);

                if (eval.Code.Contains("TERM"))
                {
                    getDataTask = reportCardService.GetTermReportByClassGroupAsync(selectedClass.GroupId, evalId, Program.CurrentSchoolYear.Id, selectedBookId);
                }
                else
                {
                    getDataTask = reportCardService.GetEvaluationReportByClassGroupAsync(selectedClass.GroupId, evalId, Program.CurrentSchoolYear.Id, selectedBookId);
                }
            }

            classGroupReportTaskResult.Add(Task.CurrentId, getDataTask.Result);
            runningTaskCount--;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            if (runningTaskCount == 0)
            {
                this.TaskWaitingBar.StopWaiting();
                this.TaskWaitingBar.ResetWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
            }
        }
        private async Task ShowRoomAnnualRecapMenu_Click(object sender, EventArgs e)
        {
            if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
            {
                this.TaskWaitingBar.StartWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
            }
            selectedArea = "room";
            var task = Task.Run(RunGetRecapNotes);
            runningTaskCount++;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            await task;
            if (recapNotesTaskResult.TryGetValue(task.Id, out var result))
            {
                var form = Program.ServiceProvider.GetService<RecapNotesForm>();
                form.Text = Language.LabelAnnualSummaryNotes + ": " + Program.CurrentSchoolYear.Name;
                form.Icon = this.Icon;
                form.WindowState = FormWindowState.Maximized;
                form.InitStartUp(result, selectedRoom, "room");
                form.Show();
                recapNotesTaskResult.Remove(task.Id);
            }
        }
        private async Task ShowClassAnnualRecapMenu_Click(object sender, EventArgs e)
        {
            if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
            {
                this.TaskWaitingBar.StartWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
            }
            selectedArea = "class";
            var task = Task.Run(RunGetRecapNotes);
            runningTaskCount++;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            await task;
            if (recapNotesTaskResult.TryGetValue(task.Id, out var result))
            {
                var form = Program.ServiceProvider.GetService<RecapNotesForm>();
                form.Text = Language.LabelAnnualSummaryNotes + ": " + Program.CurrentSchoolYear.Name;
                form.Icon = this.Icon;
                form.WindowState = FormWindowState.Maximized;
                form.InitStartUp(result, selectedRoom, "class");
                form.Show();
                recapNotesTaskResult.Remove(task.Id);
            }
        }
        private async Task ShowGroupAnnualRecapMenu_Click(object sender, EventArgs e)
        {

            if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
            {
                this.TaskWaitingBar.StartWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
            }
            selectedArea = "group";
            var task = Task.Run(RunGetRecapNotes);
            runningTaskCount++;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            await task;
            if (recapNotesTaskResult.TryGetValue(task.Id, out var result))
            {
                var form = Program.ServiceProvider.GetService<RecapNotesForm>();
                form.Text = Language.LabelAnnualSummaryNotes + ": " + Program.CurrentSchoolYear.Name;
                form.Icon = this.Icon;
                form.WindowState = FormWindowState.Maximized;
                form.InitStartUp(result, selectedRoom, "group");
                form.Show();
                recapNotesTaskResult.Remove(task.Id);
            }
        }

        // Extraction du récapitulatif des notes
        private void RunGetRecapNotes()
        {
            Task<List<RecapNoteItem>> getDataTask = null;
            switch (selectedArea)
            {
                case "room":
                    getDataTask = localStudentNoteService.GetRecapNotesByRoom(selectedRoom.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                    break;
                case "class":
                    getDataTask = localStudentNoteService.GetRecapNotesByClass(selectedRoom.ClassId, Program.CurrentSchoolYear.Id, selectedBookId);
                    break;
                case "group":
                    var selectedClass = Program.SchoolClassList.FirstOrDefault(c => c.Id == selectedRoom.ClassId);
                    getDataTask = localStudentNoteService.GetRecapNotesByGroup(selectedClass.GroupId, Program.CurrentSchoolYear.Id, selectedBookId);
                    break;
                default:
                    getDataTask = localStudentNoteService.GetRecapNotesByRoom(selectedRoom.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                    break;
            }
            recapNotesTaskResult.Add(Task.CurrentId, getDataTask.Result);
            runningTaskCount--;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            if (runningTaskCount == 0)
            {
                this.TaskWaitingBar.StopWaiting();
                this.TaskWaitingBar.ResetWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
            }
        }
        // Extraction des fiches de discipline d'un élève
        private void RunGetStudentDisciplinarySheet()
        {
            if (StudentNoteGridView.CurrentRow != null && StudentNoteGridView.CurrentRow.DataBoundItem is AverageRecord selectedRecord)
            {
                var getDataTask = reportCardService.GetDisciplinarySheetByStudent(selectedRecord.Student.Id, selectedRoom.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                disciplinarySheetTaskResult.Add(Task.CurrentId, new() { getDataTask.Result });
                runningTaskCount--;
                this.TaskWaitingBar.Text = runningTaskCount.ToString();
                if (runningTaskCount == 0)
                {
                    this.TaskWaitingBar.StopWaiting();
                    this.TaskWaitingBar.ResetWaiting();
                    this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
                }
            }

        }
        // Extraction des fiches de discipline d'une salle de classe
        private void RunGetClassroomDisciplinarySheet()
        {
            var getDataTask = reportCardService.GetDisciplinarySheetByClassRoom(selectedRoom.Id, Program.CurrentSchoolYear.Id, selectedBookId);
            disciplinarySheetTaskResult.Add(Task.CurrentId, getDataTask.Result);
            runningTaskCount--;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            if (runningTaskCount == 0)
            {
                this.TaskWaitingBar.StopWaiting();
                this.TaskWaitingBar.ResetWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
            }
        }
        // Affiche les fiches de disciplines des élèves d'une salle de classe
        private async Task ShowRoomDisciplinarySheetMenu_Click(object sender, EventArgs e)
        {
            if (StudentNoteGridView.CurrentRow != null)
            {
                if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
                {
                    this.TaskWaitingBar.StartWaiting();
                    this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
                }
                selectedArea = "room";

                var task = Task.Run(RunGetClassroomDisciplinarySheet);
                runningTaskCount++;
                this.TaskWaitingBar.Text = runningTaskCount.ToString();
                await task;
                if (disciplinarySheetTaskResult.TryGetValue(task.Id, out var result))
                {
                    var form = Program.ServiceProvider.GetService<ReportViewerForm>();
                    form.Icon = this.Icon;
                    form.WindowState = FormWindowState.Maximized;
                    form.LoadDisciplinarySheet(result);
                    form.Show();
                    disciplinarySheetTaskResult.Remove(task.Id);
                }
            }
        }

        // Affiche la fiche de discipline d'un élève
        private async Task ShowStudentDisciplinarySheetMenu_Click(object sender, EventArgs e)
        {
            if (StudentNoteGridView.CurrentRow != null)
            {
                if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
                {
                    this.TaskWaitingBar.StartWaiting();
                    this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
                }
                selectedArea = "room";

                var task = Task.Run(RunGetStudentDisciplinarySheet);
                runningTaskCount++;
                this.TaskWaitingBar.Text = runningTaskCount.ToString();
                await task;
                if (disciplinarySheetTaskResult.TryGetValue(task.Id, out var result))
                {
                    var form = Program.ServiceProvider.GetService<ReportViewerForm>();
                    form.Icon = this.Icon;
                    form.WindowState = FormWindowState.Maximized;
                    form.LoadDisciplinarySheet(result);
                    form.Show();
                    disciplinarySheetTaskResult.Remove(task.Id);
                }
            }
        }

        private async Task ShowClassRoomReportMenu_Click(object sender, EventArgs e)
        {

            if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
            {
                this.TaskWaitingBar.StartWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
            }
            var task = Task.Run(RunGetClassroomReport);
            runningTaskCount++;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            await task;
            if (classroomReportTaskResult.TryGetValue(task.Id, out var result))
            {
                var form = Program.ServiceProvider.GetService<ReportViewerForm>();
                form.Icon = this.Icon;
                form.LoadClassroomReport(result);
                form.WindowState = FormWindowState.Maximized;
                form.Show();
                disciplinarySheetTaskResult.Remove(task.Id);
            }
        }
        // Extraction du procès verbale d'une évaluation ou d'un trimestre
        private void RunGetClassroomReport()
        {
            Task<ClassroomReport> getDataTask = null;
            int evalId = selectedEvaluation != null ? selectedEvaluation.Id : selectedFatherEvaluation.Id;
            var eval = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evalId);
            if (eval.Code.Contains("TERM"))
            {
                getDataTask = reportCardService.GetTermReportByClassRoomAsync(selectedRoom.Id, evalId, Program.CurrentSchoolYear.Id, selectedBookId);
            }
            else
            {
                getDataTask = reportCardService.GetEvaluationReportByClassRoomAsync(selectedRoom.Id, evalId, Program.CurrentSchoolYear.Id, selectedBookId);
            }
            classroomReportTaskResult.Add(Task.CurrentId, getDataTask.Result);
            runningTaskCount--;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            if (runningTaskCount == 0)
            {
                this.TaskWaitingBar.StopWaiting();
                this.TaskWaitingBar.ResetWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
            }
        }
        private async Task ShowGroupStatisticReportMenu_Click(object sender, EventArgs e)
        {
            if (StudentNoteGridView.CurrentRow != null)
            {
                selectedArea = "evaluation";
                if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
                {
                    this.TaskWaitingBar.StartWaiting();
                    this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
                }
                var task = Task.Run(RunGetStatisticReport);
                runningTaskCount++;
                this.TaskWaitingBar.Text = runningTaskCount.ToString();
                await task;
                if (classGroupReportTaskResult.TryGetValue(task.Id, out var result))
                {
                    var form = Program.ServiceProvider.GetService<ReportViewerForm>();
                    form.Icon = this.Icon;
                    form.WindowState = FormWindowState.Maximized;
                    form.LoadClassGroupReport(result);
                    form.Show();
                    disciplinarySheetTaskResult.Remove(task.Id);
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
                     e.Row.Cells["Position"].Value.ToString().ToLower().Contains(StudentNoteSearchTextBox.Text.ToLower());
                }
                else
                {
                    if (e.Row.Cells.Count == 6)
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
                if (e.Item.Tag is EvaluationSession session)
                {
                    if (Program.EvaluationSessionParentList.Any(x => x.Id == session.Id))
                    {
                        selectedFatherEvaluation = session;
                        selectedEvaluation = null;
                        StudentNoteListViewToggleButton.Enabled = false;
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
        private async void LoadDataToStudentNoteGridView()
        {
            if (StudentNoteLeftListView.SelectedItem != null)
            {
                if (StudentNoteRoomDropDownList.SelectedItem != null)
                {
                    selectedBookId = StudentNoteGroupDropDownList.SelectedItem != null ? int.Parse(StudentNoteGroupDropDownList.SelectedItem.Value.ToString()) : 0;
                    if (StudentNoteIconViewToggleButton.ToggleState == ToggleState.On)
                    {
                        InitStudentNoteGridViewForAverages();
                        List<DTOItem.AverageRecord> dataSource;
                        if (selectedEvaluation != null)
                        {
                            dataSource = await localStudentNoteService.GetEvaluationAverageListByRoom(selectedRoom.Id, selectedEvaluation.Id, Program.CurrentSchoolYear.Id, selectedBookId);
                        }
                        else
                        {
                            dataSource = await localStudentNoteService.GetTermAverageListByRoom(selectedRoom.Id, selectedFatherEvaluation.Code, Program.CurrentSchoolYear.Id, selectedBookId);

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
                else
                {
                    StudentNoteGridView.DataSource = null;
                }
            }
            else
            {
                StudentNoteGridView.DataSource = null;
            }
        }
        // add note list
        private void StudentNoteAddNotesMenu_Click(object sender, EventArgs e)
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
                                var form = Program.ServiceProvider.GetService<AddStudentNotesForm>();
                                var evaluationName = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? selectedEvaluation.EnglishName : selectedEvaluation.FrenchName;
                                form.Text = $"{Language.labelSchoolYear} {Program.CurrentSchoolYear.Name} {evaluationName}";
                                form.InitStartup(selectedRoom, selectedEvaluation, selectedBookId);
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
                                form.InitStartup(selectedRoom, selectedEvaluation, selectedBookId);
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
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);

            if (classGroup.DocumentLanguageId == 1 || classGroup.DocumentLanguageId == 2 && selectedBookId == 1)
            {
                return "EnglishName";
            }
            return "FrenchName";
        }
    }
}
