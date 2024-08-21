

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.CustomControls;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class EmployeeAttendancesForm : SchoolManagement.UI.EmployeeItemsForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly ClientApp clientApp;
        private EmployeeEnrolling selectedEnrolling;
        public EmployeeAttendancesForm(ILogService logService, IEmployeeService employeeService, ClientApp clientApp)
        {
            this.logService = logService;
            this.employeeService = employeeService;
            this.clientApp = clientApp;
            CreateGridViewColumn();
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            FilterTextBox.TextChanged += FilterTextBox_TextChanged;
            CloseButton.Click += CloseButton_Click;
            PrintButton.Click += PrintButton_Click;
            ExportButton.Click += ExportButton_Click;
            DataGridView.ContextMenuOpening += DataGridView_ContextMenuOpening;
            DataGridView.CustomFiltering += DataGridView_CustomFiltering; 
            SaveButton.Text=Language.labelAdd;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            AppUtilities.ExportGridViewToExcel(DataGridView, Language.titleRoomList);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            AppUtilities.PrintGridView(DataGridView, Language.titleRoomList);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //filtre le datagridview en fonction des données de searchTextBox
        private void DataGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            if (FilterTextBox.Text != null)
            {

                e.Visible &= e.Row.Cells["StartHour"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower())||
                     e.Row.Cells["Room.Name"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower()) ||
                     e.Row.Cells[Language.fieldSubjectName].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
            }
        }
        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridView.MasterTemplate.Refresh();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                ShowAddEmployeeAttendanceForm();
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        // initialise certains éléments. chargement de la photo,
        // affichage des informations personnelles de l'employé etc.
        internal void Init(EmployeeEnrolling enrolling)
        {           
            selectedEnrolling = enrolling;
            if (enrolling.Employee.FullName.Length >= 20)
            {
                NameLabel.Text = enrolling.Employee.FullName.Substring(0, 20) + "...";
            }
            else
            {
                this.NameLabel.Text = enrolling.Employee.FullName;
            }
            NameLabel.LabelElement.ToolTipText = enrolling.Employee.FullName;
            DateTime today = DateTime.Now;
            int age = today.Year - enrolling.Employee.BirthDate.Year;
            if (enrolling.Employee.BirthDate > today.AddYears(-age))
            {
                age--;
            }
            int workAge = today.Year - enrolling.Employee.HiringDate.Year;
            if (enrolling.Employee.HiringDate > today.AddYears(-workAge))
            {
                workAge--;
            }
            PersonalInformationLabel.Text = string.Format("{0} ans | {1} | {2}", age.ToString(), enrolling.Employee.Sex == "M" ? "Masculin" : "Feminin", enrolling.Employee.BirthDate.ToString("dd/MM/yyyy"));
            string schoolInfo = Language.labelHiredOn + " " + enrolling.Employee.HiringDate.ToString("dd/MM/yyyy") + " | " + workAge + " " + Language.labelYearOfService + " | " + enrolling.Job.Name + " | " + enrolling.GroupName + " | " + enrolling.SchoolYear;
            SchoolInformationLabel.LabelElement.ToolTipText = schoolInfo;
            if (schoolInfo.Length <= 121)
            {
                SchoolInformationLabel.Text = schoolInfo;
            }
            else
            {
                SchoolInformationLabel.Text = schoolInfo.Substring(0, 121) + "..."; ; ;
            }

            AddressLabel.Text = enrolling.Employee.Address;
            EmailLabel.Text = enrolling.Employee.Email;
            PhoneLabel.Text = enrolling.Employee.Phone;
            //affichage de la photo
            if (File.Exists(enrolling.PictureUrl))
            {

                PictureLabel.Image = new Bitmap(Image.FromFile(enrolling.PictureUrl), new Size(114, 114));
            }
            else
            {
                //on cherche un photo par defaut
                if (File.Exists(enrolling.Employee.PictureUrl))
                {
                    PictureLabel.Image = new Bitmap(Image.FromFile(enrolling.Employee.PictureUrl), new Size(114, 114));
                }
                else
                {
                    using var ms = new MemoryStream(Resources.no_image);
                    PictureLabel.Image = Image.FromStream(ms);
                }
            }

            //load attendances
            LoadAttendances(enrolling.Id);
        }
        // chargement de la liste des présences dans le datagridview
        private async void LoadAttendances(int enrollingId)
        {
            selectedEnrolling.Attendances = employeeService.GetAttendanceList(enrollingId).Result;
            DataGridView.DataSource = selectedEnrolling.Attendances;
            await Task.Delay(0);      
         }
        //Création des colonnes du datqgridview
        private void CreateGridViewColumn()
        {
            DataGridView.ReadOnly = true;
            DataGridView.AllowColumnChooser = false;
            DataGridView.ShowFilteringRow = false;
            DataGridView.AllowAddNewRow = false;
            DataGridView.AllowDragToGroup = false;
            DataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
            DataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            DataGridView.EnableCustomFiltering = true;
            DataGridView.EnableFiltering = true;
            GridViewTextBoxColumn roomColumn = new("Room.Name");
            GridViewTextBoxColumn subjectColumn = new(Language.fieldSubjectName);
            GridViewDateTimeColumn dateColumn = new("StartHour");
            GridViewDateTimeColumn startColumn = new("StartHour");
            GridViewDateTimeColumn endColumn = new("EndHour");
            GridViewTextBoxColumn durationColumn = new("Duration");
            roomColumn.HeaderText = Language.labelRoom;
            subjectColumn.HeaderText = Language.labelSubject;
            dateColumn.HeaderText = "Date";
            startColumn.HeaderText = Language.labelStart;
            endColumn.HeaderText = Language.labelEnd;
            durationColumn.HeaderText = Language.labelDuration;

            dateColumn.Format = DateTimePickerFormat.Custom;
            dateColumn.CustomFormat = "dd/MM/yyyy";
            dateColumn.FormatString = "{0:dd/MM/yyyy}";
            startColumn.Format = DateTimePickerFormat.Custom;
            startColumn.CustomFormat = "H:mm";
            startColumn.FormatString = "{0:H:mm}";

            endColumn.Format = DateTimePickerFormat.Custom;
            endColumn.CustomFormat = "H:mm";
            endColumn.FormatString = "{0:H:mm}";

            this.DataGridView.Columns.Add(dateColumn);
            this.DataGridView.Columns.Add(subjectColumn);
            this.DataGridView.Columns.Add(roomColumn);
            this.DataGridView.Columns.Add(startColumn);
            this.DataGridView.Columns.Add(endColumn);
            this.DataGridView.Columns.Add(durationColumn);
            foreach (GridViewDataColumn col in this.DataGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
        }
        //fait appel au menu contextuel du grid view
        private void DataGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            //don't add  header's item
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                RadMenuItem editMenu = new(Language.labelEdit);
                RadMenuItem deleteMenu = new(Language.labelDelete);
                editMenu.Image = AppUtilities.GetImage("Edit");
                deleteMenu.Image = AppUtilities.GetImage("Delete");
                e.ContextMenu.Items.Clear();
                e.ContextMenu.Items.Add(editMenu);
                e.ContextMenu.Items.Add(deleteMenu);
                editMenu.Click += EditMenu_Click;
                deleteMenu.Click += DeleteMenu_Click;
                
            }
        }
        // supression d'une présence
        private void DeleteMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is EmployeeAttendance record)
                {
                    if (record != null)
                    {
                        DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmDelete, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var isDone = employeeService.DeleteAttendance(record.Id).Result;
                            if (isDone)
                            {
                                LoadAttendances(selectedEnrolling.Id);
                                Log log = new()
                                {
                                    UserAction = $"Suppression d'un pointage de l'employé {selectedEnrolling.Employee.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}",
                                    UserId = clientApp.UserConnected.Id
                                };
                                logService.CreateLog(log);
                            }
                            else
                            {
                                RadMessageBox.Show(Language.messageDeleteError);
                            }
                        }
                    }
                }

            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        //Modification d'une présence
        private void EditMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is EmployeeAttendance record)
                {
                    if (record != null)
                    {
                        ShowEditEmployeeAttendanceForm(record);
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            
        }
        //affichage de UI pour l'ajout d'une présence
        private void ShowAddEmployeeAttendanceForm()
        {
            var form = Program.ServiceProvider.GetService<AddEmployeeAttendanceForm>();
            form.Text = selectedEnrolling.Employee.FullName + ":.." + Language.labelAdd + " " + Language.labelAttendance;
            form.Init(selectedEnrolling);
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadAttendances(selectedEnrolling.Id);
            }
        }
        //affichage de UI pour la modification d'une présence
        private void ShowEditEmployeeAttendanceForm(EmployeeAttendance attendance)
        {
            var form = Program.ServiceProvider.GetService<EditEmployeeAttendanceForm>();
            form.Text = selectedEnrolling.Employee.FullName + ":.." + Language.labelUpdate + " " + Language.labelAttendance;
            form.Init(selectedEnrolling,attendance);
            form.Icon = this.Icon;
            form.ShowDialog(this);
            
        }
    }

}
