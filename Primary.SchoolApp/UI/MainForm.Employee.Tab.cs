

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.CustomElements;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp
{
    public partial class MainForm
    {
        private bool updatingEmployeeToggleState = false;
        private string employeeLeftViewForToolTipText;
        private EmployeeEnrollingInfo employeeEnrollingInfo;
        private void InitEmployeePage()
        {
            this.EmployeeIconViewToggleButton.ToggleState = ToggleState.On;
            InitEmployeeLeftView();
            InitGridViewEmployeePage();
            InitEmployeeMainListView();
            LoadEnrollingEmployee();
            InitEmployeePageEvents();
            InitEmployeePageCustomControls();
            InitContextMenuEmployeePage();
        }
        //create Employee context menu for Employee main list view
        private void InitContextMenuEmployeePage()
        {
            RadContextMenuManager contextMenuManager = new RadContextMenuManager();
            RadContextMenu contextMenu=new RadContextMenu();
            RadMenuItem menuEdit = new(Language.labelEdit);
            RadMenuItem menuDuplicateEnrolling = new(Language.labelDuplicateForCurrentYear);
            RadMenuItem menuAddPicture = new RadMenuItem(Language.labelAddPicture);
            RadMenuItem menuShowRooms = new RadMenuItem(Language.labelRooms);
            RadMenuItem menuShowSubjects = new RadMenuItem(Language.labelSubjects);
            RadMenuItem menuShowTimesheet = new RadMenuItem(Language.labelTimesheet);
            RadMenuItem menuShowAccount = new RadMenuItem(Language.labelEmployeeAccount);
            RadMenuItem menuShowNotes = new RadMenuItem(Language.labelNotes);
            menuEdit.Image = AppUtilities.GetImage("Edit");
            menuDuplicateEnrolling.Image = AppUtilities.GetImage("Duplicate");
            menuAddPicture.Image = AppUtilities.GetImage("Add");
            menuShowSubjects.Image = AppUtilities.GetImage("Eye");
            menuShowRooms.Image = AppUtilities.GetImage("Eye");
            menuShowAccount.Image = AppUtilities.GetImage("Eye");
            menuShowTimesheet.Image = AppUtilities.GetImage("Eye");
            menuShowNotes.Image = AppUtilities.GetImage("Eye");
            menuEdit.Click+= EmployeeEditButton_Click;
            menuAddPicture.Click += MenuAddPicture_Click;
            menuShowRooms.Click += MenuShowRooms_Click;
            menuShowSubjects.Click += MenuShowSubjects_Click;
            menuShowTimesheet.Click += MenuShowTimesheet_Click;
            menuShowNotes.Click += MenuShowNotes_Click;
            menuShowAccount.Click += MenuShowAccount_Click;
            contextMenu.Items.Add(menuEdit);
            contextMenu.Items.Add(menuDuplicateEnrolling);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(menuAddPicture);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(menuShowRooms);
            contextMenu.Items.Add(menuShowSubjects);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(menuShowTimesheet);
            contextMenu.Items.Add(menuShowNotes);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(menuShowAccount);
            contextMenuManager.SetRadContextMenu(EmployeeMainListView, contextMenu);
        }
        private void InitEmployeeMainListView()
        {
            GroupDescriptor groupByValue = new GroupDescriptor(new SortDescriptor[]
        {
                new SortDescriptor("GroupName", ListSortDirection.Ascending)
        });

            EmployeeMainListView.GroupDescriptors.Add(groupByValue);
        }

        private void InitEmployeeLeftView()
        {
            ListViewDataItemGroup employeeGroup = new();
            employeeGroup.Text = Language.labelPopulationByGroup.ToUpper();
            EmployeeLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { employeeGroup });
            foreach (var item in Program.EmployeeGroupList)
            {
                ListViewDataItem dataItem = new();

                dataItem.Key = item.Id;
                dataItem.Value = item.Name;
                dataItem.Tag = item.Name;
                if (item.Name.Trim().Length > 22)
                {
                    dataItem.Text = item.Name.ToUpper().Substring(0, 22) + "...";
                }
                else
                {
                    dataItem.Text = item.Name.ToUpper();
                }
                dataItem.CheckState = ToggleState.On;
                this.EmployeeLeftListView.Items.Add(dataItem);
                dataItem.Group = employeeGroup;
            }
        }
        private void InitEmployeePageEvents()
        {
            EmployeeSchoolYearDropDownList.SelectedValueChanged += EmployeeSchoolYearDropDownList_SelectedValueChanged;
            EmployeeIconViewToggleButton.ToggleStateChanged += EmployeeToggleButton_ToggleStateChanged;
            EmployeeListViewToggleButton.ToggleStateChanged += EmployeeToggleButton_ToggleStateChanged;
            EmployeeIconViewToggleButton.ToggleStateChanging += EmployeeToggleButton_ToggleStateChanging;
            EmployeeListViewToggleButton.ToggleStateChanging += EmployeeToggleButton_ToggleStateChanging;
            EmployeeMainListView.VisualItemCreating += EmployeeMainListView_VisualItemCreating;
            EmployeeMainListView.GroupExpanding += EmployeeMainListView_GroupExpanding;
            EmployeeMainListView.ItemMouseClick += EmployeeMainListView_ItemMouseClick;
            EmployeeLeftListView.VisualItemCreating += EmployeeLeftListView_VisualItemCreating;
            EmployeeLeftListView.ToolTipTextNeeded += EmployeeLeftListView_ToolTipTextNeeded;
            EmployeeLeftListView.ItemMouseHover += EmployeeLeftListView_ItemMouseHover;
            EmployeeGridView.CustomFiltering += EmployeeGridView_CustomFiltering;
            EmployeeSearchTextBox.TextChanged += EmployeeSearchTextBox_TextChanged;
            EmployeeLeftListView.ItemCheckedChanged += EmployeeLeftListView_ItemCheckedChanged;
            EmployeeMainListView.CurrentItemChanged += EmployeeMainListView_CurrentItemChanged;
            EmployeeGridView.CurrentRowChanged += EmployeeGridView_CurrentRowChanged;
            EmployeeEnrollingAddButton.Click += EmployeeEnrollingAddButton_Click;
            EmployeeGridView.ContextMenuOpening += EmployeeGridView_ContextMenuOpening;
        }

        private void UpdateEmployeeMainListView()
        {
            foreach (ListViewDataItem item in EmployeeMainListView.Items)
            {
                var record = item.DataBoundItem as EmployeeEnrolling;
                bool isRecordItemVisible = true;
                foreach (ListViewDataItem leftViewItem in EmployeeLeftListView.Items)
                {

                    if (leftViewItem.Group.Text == Language.labelPopulationByGroup.ToUpper())
                    {

                        if (record.GroupName == leftViewItem.Text && leftViewItem.CheckState == ToggleState.Off)

                        {
                            isRecordItemVisible = false;
                            break;
                        }
                    }


                }
                if (isRecordItemVisible == false)
                {
                    item.Visible = false;
                }
                else
                {
                    item.Visible = true;
                }
            }
        }

        private void ShowAddEnployeeEnrollingForm()
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<AddEmployeeEnrollingForm>();
                form.Text = Language.labelAdd + ":.. " + Language.labelEnroll;
                form.Icon = this.Icon;
                form.Init(Program.CurrentSchoolYear);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var data = employeeService.GetEmployeeEnrolling((form.EmployeeDropDownList.SelectedItem.DataBoundItem as Employee).Id, Program.CurrentSchoolYear.Id).Result;
                    Program.EmployeeEnrollingList.Add(data);
                    EmployeeGridView.DataSource = new List<EmployeeEnrolling>();
                    EmployeeMainListView.DataSource = new List<EmployeeEnrolling>();
                    EmployeeGridView.DataSource = Program.EmployeeEnrollingList;
                    EmployeeMainListView.DataSource = Program.EmployeeEnrollingList;
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);

                
            }
            
        }
        private void ShowEditEnployeeEnrollingForm(EmployeeEnrolling enrolling)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<EditEmployeeEnrollingForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelEnroll;
                form.Icon = this.Icon;
                form.Init(enrolling);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    EmployeeGridView.DataSource = new List<EmployeeEnrolling>();
                    EmployeeGridView.DataSource = Program.EmployeeEnrollingList;
                    EmployeeMainListView.DataSource = Program.EmployeeEnrollingList;
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        private void ShowEmployeeRoomsForm(EmployeeEnrolling enrolling)
        {
            var form = Program.ServiceProvider.GetService<EmployeeRoomsForm>();
            form.Icon = this.Icon;
            form.Text=enrolling.Employee.FullName+":.."+Language.labelRooms;
            form.Init(enrolling);
            form.Show();
        }
        private void ShowEmployeeSubjectsForm(EmployeeEnrolling enrolling)
        {
            var form = Program.ServiceProvider.GetService<EmployeeSubjectsForm>();
            form.Icon = this.Icon;
            form.Text = enrolling.Employee.FullName + ":.." + Language.labelSubjects;
            form.Init(enrolling);
            form.Show();
        }
        private void ShowEmployeeAttendancesForm(EmployeeEnrolling enrolling)
        {
            var form = Program.ServiceProvider.GetService<EmployeeAttendancesForm>();
            form.Icon = this.Icon;
            form.Text = enrolling.Employee.FullName + ":.." + Language.labelAttendances;
            form.Init(enrolling);
            form.Show();
        }
        private void ShowEmployeeNotesForm(EmployeeEnrolling enrolling)
        {
            var form = Program.ServiceProvider.GetService<EmployeeNotesForm>();
            form.Icon = this.Icon;
            form.Text = enrolling.Employee.FullName + ":.." + Language.labelNotes;
            form.Init(enrolling);
            form.Show();
        }
        private void ShowEmployeeAccountTransactionForm(EmployeeEnrolling enrolling)
        {
            var form = Program.ServiceProvider.GetService<EmployeeAccountTransactionsForm>();
            form.Icon = this.Icon;
            form.Text = enrolling.Employee.FullName + ":.." + Language.labelAccount;
            form.Init(enrolling);
            form.Show();
        }
        //initialisation des contrôles utilisateurs personnalisés 
        private void InitEmployeePageCustomControls()
        {
            EmployeeInfoRightPanel.Visible=false;
            employeeEnrollingInfo = new EmployeeEnrollingInfo()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };

            employeeEnrollingInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                EmployeeInfoRightPanel.Visible = false;
            };
            employeeEnrollingInfo.EditButton.Click += EmployeeEditButton_Click;
            employeeEnrollingInfo.RoomsLabel.DoubleClick += MenuShowRooms_Click;
            employeeEnrollingInfo.SubjectsLabel.DoubleClick += MenuShowSubjects_Click;
            employeeEnrollingInfo.AttendancesLabel.DoubleClick += MenuShowTimesheet_Click;
            employeeEnrollingInfo.NotesLabel.DoubleClick += MenuShowNotes_Click;
            EmployeeInfoRightPanel.Controls.Add(employeeEnrollingInfo);
        }

        #region Events
        private void MenuAddPicture_Click(object sender, EventArgs e)
        {
            if (EmployeeGridView.CurrentRow != null)
            {
                if (EmployeeGridView.CurrentRow.DataBoundItem is EmployeeEnrolling record)
                {
                    ShowUploadEmployeePictureForm(record);
                }
            }
        }

        private void EmployeeGridView_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e.CurrentRow != null)
            {
                if (e.CurrentRow.DataBoundItem is EmployeeEnrolling record)
                {
                    LoadSelectedEmployeeEnrollingDetail(record);
                }
            }
        }

        private void EmployeeMainListView_CurrentItemChanged(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.DataBoundItem is EmployeeEnrolling record)
            {
                foreach (var row in EmployeeGridView.Rows)
                {
                    var item = row.DataBoundItem as EmployeeEnrolling;
                    if (item.Id == record.Id)
                    {
                        EmployeeGridView.CurrentRow = row;
                        break;
                    }
                }
            }
        }

        private void EmployeeLeftListView_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            UpdateEmployeeMainListView();
            EmployeeGridView.MasterTemplate.Refresh();
            EmployeeMainListView.ListViewElement.SynchronizeVisualItems();
        }

        //recherche des données correspondantes
        private void EmployeeSearchTextBox_TextChanged(object sender, System.EventArgs e)
        {
            EmployeeGridView.MasterTemplate.Refresh();
            if (EmployeeSearchTextBox.Text == string.Empty)
            {
                EmployeeMainListView.FilterPredicate = null;
            }
            else
            {
                EmployeeMainListView.FilterPredicate = null;
                EmployeeMainListView.FilterPredicate = FilterEmployeePredicate;
            }
            EmployeeLeftListView.ListViewElement.SynchronizeVisualItems();
            UpdateEmployeeMainListView();
        }

        // filtre la liste des données présente dans le data grid view
        private void EmployeeGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            var record = e.Row.DataBoundItem as EmployeeEnrolling;
            e.Visible = IsEmployeeByGroupChecked(e.Row.Cells["GroupName"].Value.ToString());
            if (this.EmployeeSearchTextBox.Text != null)
            {
                e.Visible &= e.Row.Cells["Employee.IdNumber"].Value.ToString().Contains(EmployeeSearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["Employee.FullName"].Value.ToString().ToLower().Contains(EmployeeSearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["GroupName"].Value.ToString().ToLower().Contains(EmployeeSearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["Job.Name"].Value.ToString().ToLower().Contains(EmployeeSearchTextBox.Text.ToLower());
            }
        }

        private void EmployeeLeftListView_ItemMouseHover(object sender, ListViewItemEventArgs e)
        {
            employeeLeftViewForToolTipText = "" + e.Item.Tag;
        }

        //affiche info bul pour 
        private void EmployeeLeftListView_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            try
            {
                e.Offset = new Size(e.Offset.Width + 20, e.Offset.Height + 20);
                e.ToolTipText = employeeLeftViewForToolTipText;



            }
            catch
            {
            }
        }

        private void EmployeeLeftListView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is SimpleListViewVisualItem)
            {
                e.VisualItem = new EmployeeSimpleListViewVisualItem();
            }
        }

        private void EmployeeMainListView_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            e.ListViewElement.SelectedItem = e.Item;
        }

        private void EmployeeMainListView_GroupExpanding(object sender, ListViewGroupCancelEventArgs e)
        {
            e.Cancel = e.Group.Expanded;
        }
        private void EmployeeEditButton_Click(object sender, EventArgs e)
        {
            if (EmployeeGridView.CurrentRow != null)
            {
                if (EmployeeGridView.CurrentRow.DataBoundItem is EmployeeEnrolling record)
                {
                    ShowEditEnployeeEnrollingForm(record);
                }
            }
        }
        private void MenuShowSubjects_Click(object sender, EventArgs e)
        {
            if (EmployeeGridView.CurrentRow != null)
            {
                if (EmployeeGridView.CurrentRow.DataBoundItem is EmployeeEnrolling record)
                {
                    ShowEmployeeSubjectsForm(record);
                }
            }
            
        }
        private void MenuShowRooms_Click(object sender, EventArgs e)
        {
            if (EmployeeGridView.CurrentRow != null)
            {
                if (EmployeeGridView.CurrentRow.DataBoundItem is EmployeeEnrolling record)
                {
                    ShowEmployeeRoomsForm(record);
                }
            }
        }
        private void MenuShowTimesheet_Click(object sender, EventArgs e)
        {
            if (EmployeeGridView.CurrentRow != null)
            {
                if (EmployeeGridView.CurrentRow.DataBoundItem is EmployeeEnrolling enrolling)
                {
                    ShowEmployeeAttendancesForm(enrolling);
                }
            }
        }
        private void MenuShowNotes_Click(object sender, EventArgs e)
        {
            if (EmployeeGridView.CurrentRow != null)
            {
                if (EmployeeGridView.CurrentRow.DataBoundItem is EmployeeEnrolling enrolling)
                {
                    ShowEmployeeNotesForm(enrolling);
                }
            }
        }
        private void MenuShowAccount_Click(object sender, EventArgs e)
        {
            if (EmployeeGridView.CurrentRow != null)
            {
                if (EmployeeGridView.CurrentRow.DataBoundItem is EmployeeEnrolling enrolling)
                {
                    ShowEmployeeAccountTransactionForm(enrolling);
                }
            }
        }

        private void EmployeeSchoolYearDropDownList_SelectedValueChanged(object sender, System.EventArgs e)
        {
            LoadEnrollingEmployee();
        }
        private void EmployeeToggleButton_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (updatingEmployeeToggleState)
            {
                return;
            }

            this.updatingEmployeeToggleState = true;
            if (EmployeeIconViewToggleButton != sender)
            {
                EmployeeIconViewToggleButton.ToggleState = ToggleState.Off;
            }
            if (EmployeeListViewToggleButton != sender)
            {
                EmployeeListViewToggleButton.ToggleState = ToggleState.Off;
            }
            this.updatingEmployeeToggleState = false;

            if (EmployeeIconViewToggleButton.ToggleState == ToggleState.On)
            {
                EmployeeGridView.Visible = false;
                EmployeeMainListView.Visible = true;
            }

            if (EmployeeListViewToggleButton.ToggleState == ToggleState.On)
            {

                EmployeeGridView.Visible = true;
                EmployeeMainListView.Visible = false;

            }
        }
        private void EmployeeToggleButton_ToggleStateChanging(object sender, StateChangingEventArgs args)
        {
            if (!updatingEmployeeToggleState && args.OldValue == ToggleState.On)
            {
                args.Cancel = true;
            }
        }
        private void EmployeeMainListView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is IconListViewVisualItem)
            {

                e.VisualItem = new EmployeeIconListViewVisualItem();
            }
        }

        private void EmployeeGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                RadMenuItem menuEdit = new(Language.labelEdit);
                RadMenuItem menuDuplicateEnrolling = new(Language.labelDuplicateForCurrentYear);
                RadMenuItem menuAddPicture = new RadMenuItem(Language.labelAddPicture);
                RadMenuItem menuShowRooms = new RadMenuItem(Language.labelRooms);
                RadMenuItem menuShowSubjects = new RadMenuItem(Language.labelSubjects);
                RadMenuItem menuShowTimesheet = new RadMenuItem(Language.labelTimesheet);
                RadMenuItem menuShowAccount = new RadMenuItem(Language.labelEmployeeAccount);
                RadMenuItem menuShowNotes = new RadMenuItem(Language.labelNotes);
                menuEdit.Image = AppUtilities.GetImage("Edit");
                menuDuplicateEnrolling.Image = AppUtilities.GetImage("Duplicate");
                menuAddPicture.Image = AppUtilities.GetImage("Add");
                menuShowSubjects.Image = AppUtilities.GetImage("Eye");
                menuShowRooms.Image = AppUtilities.GetImage("Eye");
                menuShowAccount.Image = AppUtilities.GetImage("Eye");
                menuShowTimesheet.Image = AppUtilities.GetImage("Eye");
                menuShowNotes.Image = AppUtilities.GetImage("Eye");
                menuEdit.Click += EmployeeEditButton_Click;
                menuAddPicture.Click += MenuAddPicture_Click;
                menuShowRooms.Click += MenuShowRooms_Click;
                menuShowSubjects.Click += MenuShowSubjects_Click;
                menuShowTimesheet.Click += MenuShowTimesheet_Click;
                menuShowNotes.Click += MenuShowNotes_Click;
                menuShowAccount.Click += MenuShowAccount_Click;
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuEdit);
                e.ContextMenu.Items.Add(menuDuplicateEnrolling);
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuAddPicture);
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuShowRooms);
                e.ContextMenu.Items.Add(menuShowSubjects);
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuShowTimesheet);
                e.ContextMenu.Items.Add(menuShowNotes);
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuShowAccount);
            }
                

        }
        
        private void EmployeeEnrollingAddButton_Click(object sender, EventArgs e)
        {
            ShowAddEnployeeEnrollingForm();
        }
        #endregion
        #region Methods
        private bool FilterEmployeePredicate(ListViewDataItem item)
        {
            if (EmployeeSearchTextBox.Text != string.Empty)
            {
                var record = item.DataBoundItem as EmployeeEnrolling;
                if (record.Employee.FullName.ToLower().Contains(EmployeeSearchTextBox.Text.ToLower()))
                {
                    return true;
                }
                if (record.GroupName.ToLower().Contains(EmployeeSearchTextBox.Text.ToLower()))
                {
                    return true;
                }
                if (record.Employee.IdNumber.ToLower().Contains(EmployeeSearchTextBox.Text.ToLower()))
                {
                    return true;
                }
                return false;
            }

            return true;
        }
        // initialisation du grid view employé
        private void InitGridViewEmployeePage()
        {
            EmployeeGridView.ReadOnly = true;
            EmployeeGridView.MasterTemplate.EnableFiltering = true;
            EmployeeGridView.EnableFiltering = true;
            EmployeeGridView.EnableCustomFiltering = true;
            EmployeeGridView.ShowFilteringRow = false;
            EmployeeGridView.AllowAddNewRow = false;
            EmployeeGridView.AutoGenerateColumns = false;
            EmployeeGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            GridViewTextBoxColumn idNumberColumn = new("Employee.IdNumber");
            GridViewTextBoxColumn employeeColumn = new("Employee.FullName");
            GridViewTextBoxColumn jobColumn = new("Job.Name");
            GridViewTextBoxColumn groupColumn = new("GroupName");
            GridViewDateTimeColumn dateColumn = new("Date");
            idNumberColumn.HeaderText = Language.labelEmployeeId;
            employeeColumn.HeaderText = Language.labelEmployee;
            jobColumn.HeaderText = Language.labelJob;
            idNumberColumn.Width = 100;
            employeeColumn.Width = 250;
            jobColumn.Width = 200;
            dateColumn.Width = 100;
            dateColumn.CustomFormat = "dd/MM/yyyy";
            dateColumn.FormatString = "{0:dd/MM/yyyy}";
            groupColumn.IsVisible = false;
            groupColumn.HeaderText= Language.labelGroup;
            EmployeeGridView.Columns.Add(idNumberColumn);
            EmployeeGridView.Columns.Add(employeeColumn);
            EmployeeGridView.Columns.Add(jobColumn);
            EmployeeGridView.Columns.Add(dateColumn);
            EmployeeGridView.Columns.Add(groupColumn);
            GridViewSummaryRowItem total = new()
            {
                new GridViewSummaryItem("Employee.IdNumber", " {0}", GridAggregateFunction.Count)
            };
            EmployeeGridView.MasterTemplate.SummaryRowsBottom.Add(total);
            foreach (GridViewDataColumn col in this.EmployeeGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
        }
        //chargement de la liste des employés inscrits pour une année scolaire
        private async void LoadEnrollingEmployee()
        {
            if (EmployeeSchoolYearDropDownList.SelectedItem != null)
            {
                if (EmployeeSchoolYearDropDownList.SelectedItem.DataBoundItem is SchoolYear record)
                {
                    Program.EmployeeEnrollingList = (await employeeService.GetEmployeeEnrollingList(record.Id));
                    EmployeeGridView.DataSource = Program.EmployeeEnrollingList;
                    EmployeeMainListView.DataSource = Program.EmployeeEnrollingList;
                    EmployeeLeftListView.ListViewElement.SynchronizeVisualItems();
                    EmployeeMainListView.ListViewElement.SynchronizeVisualItems();
                }
            }
        }
        private bool IsEmployeeByGroupChecked(string statusGroup)
        {
            bool status = true;
            foreach (ListViewDataItem item in EmployeeLeftListView.Items)
            {
                if (item.Text == statusGroup && item.Group.Text == Language.labelPopulationByGroup.ToUpper())
                {
                    if (item.CheckState == ToggleState.Off)
                    {
                        status = false;
                        break;
                    }
                }

            }
            return status;
        }
        private void LoadSelectedEmployeeEnrollingDetail(EmployeeEnrolling record)
        {
            var getClassList=employeeService.GetRoomList(record.Id);
            var getSubjectList = employeeService.GetSubjectList(record.Id);
            var getAttendanceList=employeeService.GetAttendanceList(record.Id);
            var getNoteList = employeeService.GetNoteList(record.Id);
            EmployeeInfoRightPanel.Visible = true;
            employeeEnrollingInfo.EmployeeTextBox.Text = record.Employee.FullName;
            employeeEnrollingInfo.BirthDayTextBox.Text=record.Employee.BirthDate.ToString("dd/MM/yyyy");
            employeeEnrollingInfo.HiringDateTextBox.Text = record.Employee.HiringDate.ToString("dd/MM/yyyy");
            employeeEnrollingInfo.IdCardTextBox.Text = record.Employee.IdCard;
            employeeEnrollingInfo.PhoneTextBox.Text = record.Employee.Phone;
            employeeEnrollingInfo.EmailTextBox.Text = record.Employee.Email;
            employeeEnrollingInfo.AddressTextBox.Text=record.Employee.Address;
            employeeEnrollingInfo.NationalityTextBox.Text = record.Employee.Nationality;
            employeeEnrollingInfo.SexTextBox.Text = record.Employee.Sex;
            employeeEnrollingInfo.EditButton.Image=AppUtilities.GetImage("Edit");
            employeeEnrollingInfo.CloseButton.Image = AppUtilities.GetImage("Close");
            //affichage photo 
            if (File.Exists(record.PictureUrl))
            {
                employeeEnrollingInfo.EmployeeLabel.Image = new Bitmap(Image.FromFile(record.PictureUrl), new Size(114, 114));
            }
            else
            {
                if (File.Exists(record.Employee.PictureUrl))
                {
                    employeeEnrollingInfo.EmployeeLabel.Image = new Bitmap(Image.FromFile(record.Employee.PictureUrl), new Size(114, 114));
                }
                else
                {
                    using var ms = new MemoryStream(Resources.no_image);
                    employeeEnrollingInfo.EmployeeLabel.Image = Image.FromStream(ms);
                }
            }
            employeeEnrollingInfo.RoomsLabel.Text=Language.labelRooms+": "+getClassList.Result.Count.ToString();
            employeeEnrollingInfo.SubjectsLabel.Text = Language.labelSubjects + ": " + getSubjectList.Result.Count.ToString();
            employeeEnrollingInfo.AttendancesLabel.Text = Language.labelAttendances + ": " + getAttendanceList.Result.Count.ToString();
            employeeEnrollingInfo.NotesLabel.Text = Language.labelNotes + ": " + getNoteList.Result.Count.ToString();
            employeeEnrollingInfo.Visible = true;
        }
        private void ShowUploadEmployeePictureForm(EmployeeEnrolling enrolling)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<UploadEmployeePictureForm>();
                form.Icon = this.Icon;
                form.Init(enrolling);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    enrolling.PictureUrl=form.UrlPicture;
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        #endregion
    }
}
