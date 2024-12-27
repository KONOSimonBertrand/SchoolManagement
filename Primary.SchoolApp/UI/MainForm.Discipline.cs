

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp
{
    public partial class MainForm
    {

        private void InitDisciplinePage()
        {
            LoadClassListToDisciplineLeftListView();
            InitEventsDisciplinePage();
            AjustColorDiciplinePage();
            CreateDisciplineGridViewColumn();

        }
        //Création des colonnes du datagridview
        private void CreateDisciplineGridViewColumn()
        {
            DisciplineGridView.ReadOnly = true;
            DisciplineGridView.AllowColumnChooser = false;
            DisciplineGridView.ShowFilteringRow = false;
            DisciplineGridView.AllowAddNewRow = false;
            DisciplineGridView.AutoGenerateColumns = false;
            DisciplineGridView.AllowDragToGroup = false;
            DisciplineGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
            DisciplineGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            DisciplineGridView.EnableCustomFiltering = true;
            DisciplineGridView.EnableFiltering = true;
            GridViewDateTimeColumn dateColumn = new("Date");
            GridViewTextBoxColumn studentIdNumberColumn = new("Student.IdNumber");
            GridViewTextBoxColumn studentNameColumn = new("Student.FullName");
            GridViewDecimalColumn durationColumn = new("Duration");
            GridViewTextBoxColumn subjectColumn = new("Subject.DefaultName");
            GridViewTextBoxColumn reasonColumn = new("Reason");
            GridViewTextBoxColumn evaluationColumn = new("Evaluation.DefaultName");
            dateColumn.Width = 80;
            studentIdNumberColumn.Width = 100;
            studentNameColumn.Width = 300;
            durationColumn.Width = 100;
            subjectColumn.Width = 150;
            reasonColumn.Width = 150;
            evaluationColumn.Width = 150;
            dateColumn.HeaderText = "Date";
            studentIdNumberColumn.HeaderText = Language.labelStudentId;
            studentNameColumn.HeaderText = Language.labelStudent;
            durationColumn.HeaderText = Language.labelDuration;
            subjectColumn.HeaderText = Language.labelDisciplineSubject;
            reasonColumn.HeaderText = Language.labelReason;
            evaluationColumn.HeaderText = Language.labelEvaluationSession;
            dateColumn.Format = DateTimePickerFormat.Custom;
            dateColumn.CustomFormat = "dd/MM/yyyy";
            dateColumn.FormatString = "{0:dd/MM/yyyy}";
            this.DisciplineGridView.Columns.Add(dateColumn);
            this.DisciplineGridView.Columns.Add(studentIdNumberColumn);
            this.DisciplineGridView.Columns.Add(studentNameColumn);
            this.DisciplineGridView.Columns.Add(subjectColumn);
            this.DisciplineGridView.Columns.Add(reasonColumn);
            this.DisciplineGridView.Columns.Add(durationColumn);
            this.DisciplineGridView.Columns.Add(evaluationColumn);
            foreach (GridViewDataColumn col in this.DisciplineGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
            
        }
        private async void LoadDataForDisciplineGridView()
        {
            if (DisciplineLeftListView.SelectedItem != null)
            {
                if (DisciplineLeftListView.SelectedItem.Tag is SchoolClass selectedClass)
                {
                    var dataList = await disciplineService.GetDisciplineListByClass(selectedClass.Id,Program.CurrentSchoolYear.Id);
                    DisciplineGridView.DataSource =dataList;
                }
            }
           
        }

        private void AjustColorDiciplinePage()
        {

            switch (AppUtilities.MainThemeColor.Name)
            {
                //teal
                case "ff009688":
                    foreach (var item in DisciplineLeftListView.Items)
                    {
                        item.Image = Resources.users_teal;
                    }
                    break;
                //blue
                case "ff3f51b5":
                    foreach (var item in DisciplineLeftListView.Items)
                    {
                        item.Image = Resources.users_blue;
                    }
                    break;
                //pink
                case "ffe91e63":
                    foreach (var item in DisciplineLeftListView.Items)
                    {
                        item.Image = Resources.users_pink;
                    }
                    break;
                case "ff607d8b":
                    foreach (var item in DisciplineLeftListView.Items)
                    {
                        item.Image = Resources.users_blue_grey;
                    }
                    break;
                default:
                    foreach (var item in DisciplineLeftListView.Items)
                    {
                        item.Image = Resources.users_blue;
                    }
                    break;
            }
        }
        private void InitEventsDisciplinePage()
        {
            DisciplineSearchDropDownList.SelectedIndexChanged += DisciplineSearchDropDownList_SelectedIndexChanged;
            DisciplineExportToExcelButton.Click += (o, ev) => {
                AppUtilities.ExportGridViewToExcel(DisciplineGridView, Language.labelDisciplines);
            };
            DisciplineLeftListView.SelectedIndexChanged += (o, ev) => { LoadDataForDisciplineGridView(); };
            DisciplineAddButton.Click += DisciplineAddButton_Click;
            DisciplineGridView.ContextMenuOpening += DisciplineGridView_ContextMenuOpening;
            DisciplineGridView.CustomFiltering += DisciplineGridView_CustomFiltering;
            DisciplineSearchTextBox.TextChanged += (o, ev) => { DisciplineGridView.MasterTemplate.Refresh(); };
        }
        // filter data in discipline grid view
        private void DisciplineGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            if (DisciplineSearchTextBox.Text != null)
            {
                e.Visible &= e.Row.Cells["Student.FullName"].Value.ToString().ToLower().Contains(DisciplineSearchTextBox.Text.ToLower()) ||
                    e.Row.Cells["Student.IdNumber"].Value.ToString().ToLower().Contains(DisciplineSearchTextBox.Text.ToLower()) ||
                    e.Row.Cells["Subject.DefaultName"].Value.ToString().ToLower().Contains(DisciplineSearchTextBox.Text.ToLower())||
                     e.Row.Cells["Reason"].Value.ToString().ToLower().Contains(DisciplineSearchTextBox.Text.ToLower()) ||
                e.Row.Cells["Evaluation.DefaultName"].Value.ToString().ToLower().Contains(DisciplineSearchTextBox.Text.ToLower());
            }
        }
        // add new discipline
        private void DisciplineAddButton_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (!Program.CurrentSchoolYear.IsClosed)
                {
                    var form = Program.ServiceProvider.GetService<AddDisciplineForm>();
                    form.Text = Language.labelAdd + ":.." + Language.labelDiscipline;
                    form.Icon = this.Icon;
                    form.Init(Program.StudentEnrollingList.Select(x => x.Student).ToList());
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadDataForDisciplineGridView();
                    }
                }
                else
                {
                    RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        // show context menu of dicipline grid view
        private void DisciplineGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            //don't add  header's item
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                Program.UserConnected.Modules = userService.GetUserModuleList(Program.UserConnected.Id).Result;
                RadMenuItem editMenu = new(Language.labelEdit);
                RadMenuItem deleteMenu = new(Language.labelDelete);
                RadMenuItem showFolder = new(Language.labelShowDiscipline);
                editMenu.Image = AppUtilities.GetImage("Edit");
                deleteMenu.Image = AppUtilities.GetImage("Delete");
                showFolder.Image = AppUtilities.GetImage("View");
                editMenu.Enabled = Program.UserConnected.Modules.Any(x=>x.ModuleId==7 && x.AllowUpdate==true);
                deleteMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 7 && x.AllowDelete == true);
                DisciplineAddButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 7 && x.AllowCreate == true);
                e.ContextMenu.Items.Add(editMenu);
                e.ContextMenu.Items.Add(deleteMenu);
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(showFolder);
                editMenu.Click += EditDisciplineMenu_Click;
                deleteMenu.Click += DeleteDisciplineMenu_Click;
            }
        }
        // delete selected discipline
        private void DeleteDisciplineMenu_Click(object sender, EventArgs e)
        {
            if (DisciplineGridView.CurrentRow.DataBoundItem is Discipline discipline)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmDelete, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var isDone = disciplineService.DeleteDiscipline(discipline.Id).Result;
                    if (isDone)
                    {
                        LoadDataForDisciplineGridView();
                        //enregistrement du log
                        Log logSubscription = new()
                        {
                            UserAction = $"Suppression l'objet disciplinaire  {discipline.Subject.DefaultName} de l'élève {discipline.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(logSubscription);

                    }
                    else
                    {
                        RadMessageBox.Show(Language.messageDeleteError, Language.labelDiscipline, MessageBoxButtons.OK,RadMessageIcon.Error);
                    }
                }
            }
        }
        // edit selected discipline
        private void EditDisciplineMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DisciplineGridView.CurrentRow.DataBoundItem is Discipline discipline)
                {
                    if (!Program.CurrentSchoolYear.IsClosed)
                    {
                        var form = Program.ServiceProvider.GetService<EditDisciplineForm>();
                        form.Text = Language.labelUpdate + ":.." + Language.labelDiscipline;
                        form.Icon = this.Icon;
                        form.Init(discipline);
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                          
                        }
                    }
                    else
                    {
                        RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        //load room list to left listview of discipline page
        private void LoadClassListToDisciplineLeftListView()
        {
            ListViewDataItemGroup classGroup = new()
            {
                Text = Language.labelClasss,
                Visible = false
            };
            DisciplineLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { classGroup });
            DisciplineLeftListView.ShowCheckBoxes = false;
            var classIdList = new List<int>();
            var classList=new List<SchoolClass>();

            if (clientApp.UserConnected.UserName != "root")
            {
                var roomIdList = clientApp.UserConnected.Rooms.Select(x => x.RoomId);
                classIdList = Program.SchoolRoomList.Where(x=>roomIdList.Contains(x.Id)).Select(x=>x.ClassId).ToList();  
            }
            else
            {
                classIdList = Program.SchoolRoomList.Select(x => x.Id).ToList();
            }
            classList=Program.SchoolClassList.Where(x=>classIdList.Contains(x.Id)).ToList();
            foreach (var itemClass in classList)
            {
                ListViewDataItem dataItem = new();
                dataItem.Key = itemClass.Id;
                dataItem.Value = itemClass.Name;
                dataItem.Tag = itemClass;
                dataItem.Image = Resources.tripple_users;
                DisciplineSearchDropDownList.Items.Add(itemClass.Name);
                if (itemClass.Name.Trim().Length > 22)
                {
                    dataItem.Text = itemClass.Name.ToUpper().Substring(0, 22) + "...";
                }
                else
                {
                    dataItem.Text = itemClass.Name.ToUpper();
                }
                dataItem.Group = classGroup;
                DisciplineLeftListView.Items.Add(dataItem);

            }
            DisciplineLeftListView.SelectedIndex = -1;
        }
        // search discipline
        private void DisciplineSearchDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (DisciplineSearchDropDownList.SelectedIndex > -1)
            {
                foreach (var item in DisciplineLeftListView.Items)
                {
                    if (item.Text.Trim() == DisciplineSearchDropDownList.Text)
                    {
                        DisciplineLeftListView.SelectedItem = item;
                        DisciplineLeftListView.SelectedItem.Tag=item.Tag;
                        break;
                    }
                }
            }
        }
    }
}
