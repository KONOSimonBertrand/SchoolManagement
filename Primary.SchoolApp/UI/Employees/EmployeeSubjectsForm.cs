
using Microsoft.VisualBasic.ApplicationServices;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
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
    internal class EmployeeSubjectsForm : SchoolManagement.UI.EmployeeItemsForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly ClientApp clientApp;
        private EmployeeEnrolling selectedEnrolling;
        private readonly ISchoolClassService schoolClassService;
        public EmployeeSubjectsForm(ILogService logService, IEmployeeService employeeService, ClientApp clientApp, ISchoolClassService schoolClassService)
        {
            this.logService = logService;
            this.employeeService = employeeService;
            this.clientApp = clientApp;
            CreateGridViewColumn();
            InitEvents();
            this.schoolClassService = schoolClassService;
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            FilterTextBox.TextChanged += FilterTextBox_TextChanged;
            DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            CloseButton.Click += CloseButton_Click;
            PrintButton.Click += PrintButton_Click;
            ExportButton.Click += ExportButton_Click;
            DataGridView.ContextMenuOpening += DataGridView_ContextMenuOpening;
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

                e.Visible &= e.Row.Cells[Language.fieldSubjectName].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower())||
                     e.Row.Cells["Room.Name"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
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
                selectedEnrolling.Subjects.Clear();
                foreach (var row in DataGridView.Rows)
                {
                    if (row.DataBoundItem is EmployeeSubject subject)
                    {
                        if (subject.IsChecked)
                        {
                            selectedEnrolling.Subjects.Add(subject);
                        }
                    }
                }
                var isDone = employeeService.AddSubjectList(selectedEnrolling.Id, selectedEnrolling.Subjects.ToList()).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Mise à jour des matières allouées de l'employé {selectedEnrolling.Employee.FullName}  par l'utisateur  {clientApp.UserConnected.Name} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                    this.Close();
                }
                else RadMessageBox.Show(Language.messageUpdateError);
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

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
            PersonalInformationLabel.Text = string.Format("{0} {1} | {2} | {3}", age.ToString(), Language.LabelYearOld.ToLower(), enrolling.Employee.Sex == "M" ? Language.LabelMale : Language.LabelFemale, enrolling.Employee.BirthDate.ToString("dd/MM/yyyy"));
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

            LoadSubjects(enrolling.Id);
        }

        private  async void LoadSubjects(int enrollingId)
        {
            selectedEnrolling.Subjects = employeeService.GetSubjectList(enrollingId).Result;
            foreach (var subject in selectedEnrolling.Subjects)
            {
                subject.IsChecked = true;
            }
            //get roomlist
            var roomList = employeeService.GetRoomList(enrollingId).Result.Select(x => x.Room).ToList();
            //get class list
            List<SchoolClass> classList = new();
            foreach(var room in Program.SchoolRoomList)
            {
                if (roomList.Contains(room))
                {
                    if (!classList.Contains(room.SchoolClass))
                    {
                        classList.Add(room.SchoolClass);
                    }
                }
            }

            //get subject list 
            foreach (var record in classList) {
                var subjects=schoolClassService.GetClassSubjectList(record.Id).Result.Select(x=>x.Subject).Distinct();
                var rooms=roomList.Where(x=>x.ClassId== record.Id).ToList();
                foreach (var room in rooms) {
                    foreach (var subject in subjects) {
                        var employeeSubject = new EmployeeSubject
                        {
                            Subject = subject,
                            SubjectId = subject.Id,
                            RoomId = room.Id,
                            Room = room,
                            Enrolling = selectedEnrolling,
                            EnrollingId = selectedEnrolling.Id
                        };
                        if (!selectedEnrolling.Subjects.Contains(employeeSubject))
                        {
                            selectedEnrolling.Subjects.Add(employeeSubject);
                        }
                    }
                }
            }        
            DataGridView.DataSource = selectedEnrolling.Subjects;
            await Task.Delay(0);
        }
        private void CreateGridViewColumn()
        {
            DataGridView.AllowEditRow = true;
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
            GridViewCheckBoxColumn stateColumn = new("IsChecked");
            roomColumn.HeaderText = Language.labelRoom;
            subjectColumn.HeaderText = Language.labelSubject;
            stateColumn.HeaderText = Language.labelAssign;
            roomColumn.ReadOnly = true;
            subjectColumn.ReadOnly = true;
            this.DataGridView.Columns.Add(roomColumn);
            this.DataGridView.Columns.Add(subjectColumn);
            this.DataGridView.Columns.Add(stateColumn);
        }
        private void DataGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            //don't add  header's item
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                RadMenuItem checkAllMenu = new(Language.labelCheckAll);
                RadMenuItem unCheckAllMenu = new(Language.labelUnCheckAll);
                e.ContextMenu.Items.Clear();
                e.ContextMenu.Items.Add(checkAllMenu);
                e.ContextMenu.Items.Add(unCheckAllMenu);
                checkAllMenu.Click += CheckAllMenu_Click;
                unCheckAllMenu.Click += UnCheckAllMenu_Click;
            }
        }

        private void UnCheckAllMenu_Click(object sender, EventArgs e)
        {
            foreach (var row in DataGridView.Rows)
            {

                if (row.DataBoundItem is EmployeeSubject subject)
                {
                    row.Cells[2].Value = false;
                }
            }
        }

        private void CheckAllMenu_Click(object sender, EventArgs e)
        {
            foreach (var row in DataGridView.Rows)
            {

                if (row.DataBoundItem is EmployeeSubject subject)
                {
                    row.Cells[2].Value = true;
                }
            }
        }

    }

}
