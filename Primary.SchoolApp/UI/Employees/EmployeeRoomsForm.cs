

using Microsoft.VisualBasic.ApplicationServices;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.CustomControls;
using SchoolManagement.UI.Localization;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class EmployeeRoomsForm : SchoolManagement.UI.EmployeeItemsForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly ClientApp clientApp;
        private EmployeeEnrolling selectedEnrolling;
        public EmployeeRoomsForm(ILogService logService, IEmployeeService employeeService, ClientApp clientApp)
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
            DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            DataGridView.CellValidating += DataGridView_CellValidating;
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

        private void DataGridView_CellValidating(object sender, CellValidatingEventArgs e)
        {
            if (DataGridView.IsInEditMode)
            {
                if (e.Column.Name == "DefaultSection")
                {
                    //vérifie si c'est la bonne section. pour une classe bilingue
                    //  0=section francophone, 1=section anglophone. sinon section=0
                    if (e.Row.DataBoundItem is EmployeeRoom record)
                    {
                        var section = Convert.ToDouble(e.Value);
                        record.Room.SchoolClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == record.Room.ClassId);
                        //si classe pas bilingue
                        if (record.Room.SchoolClass.BookTypeId != 2)
                        {
                            if (section != 0)
                            {
                                e.Cancel = true;
                                e.Row.ErrorText = Language.messageBadSection;
                            }
                            else
                            {
                                e.Row.ErrorText = string.Empty;
                            }
                        }
                        else
                        {
                            //si classe bilingue
                            if (section != 1 && section != 0)
                            {
                                e.Cancel = true;
                                e.Row.ErrorText = Language.messageBadSection;
                            }
                            else
                            {
                                e.Row.ErrorText = string.Empty;
                            }
                        }
                    }

                }
            }
        }

        //filtre le datagridview en fonction des données de searchTextBox
        private void DataGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            if (FilterTextBox.Text != null)
            {

                e.Visible &= e.Row.Cells["Room.Name"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
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
                selectedEnrolling.Rooms.Clear();
                foreach (var row in DataGridView.Rows)
                {
                    if (row.DataBoundItem is EmployeeRoom room)
                    {
                        if (room.IsChecked)
                        {
                            selectedEnrolling.Rooms.Add(room);
                        }
                    }
                }
                var isDone = employeeService.AddRoomList(selectedEnrolling.Id, selectedEnrolling.Rooms.ToList()).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Mise à jour des classes allouées de l'employé {selectedEnrolling.Employee.FullName}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
            //load rooms 
            LoadRooms(enrolling.Id);


        }
        private async void LoadRooms(int enrollingId)
        {
            selectedEnrolling.Rooms= employeeService.GetRoomList(enrollingId).Result;           
            foreach (var room in selectedEnrolling.Rooms)
            {
                room.IsChecked = true;
            }
            var roomlList = selectedEnrolling.Rooms.Select(x => x.Room).ToList();
            //find room to complete employee room list
            foreach (var room in Program.SchoolRoomList)
            {
                if (!roomlList.Contains(room))
                {
                    selectedEnrolling.Rooms.Add(
                        new EmployeeRoom()
                        {
                            Room = room,
                            RoomId = room.Id,
                            Enrolling = selectedEnrolling,
                            EnrollingId = selectedEnrolling.Id,
                            DefaultSection = 0,
                        }
                        );
                }
            }
            DataGridView.DataSource = selectedEnrolling.Rooms;
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
            GridViewCheckBoxColumn isMasterRoomColumn = new("IsMasterRoom");
            GridViewDecimalColumn defaultSectionColumn = new("DefaultSection");
            GridViewCheckBoxColumn stateColumn = new("IsChecked");
            roomColumn.HeaderText = Language.labelRoom;
            defaultSectionColumn.HeaderText = Language.labelSection;
            stateColumn.HeaderText = Language.labelAssign;
            isMasterRoomColumn.HeaderText = Language.labelMasterTeacher;
            roomColumn.ReadOnly = true;
            this.DataGridView.Columns.Add(roomColumn);
            this.DataGridView.Columns.Add(isMasterRoomColumn);
            this.DataGridView.Columns.Add(defaultSectionColumn);
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

                if (row.DataBoundItem is EmployeeRoom room)
                {
                    row.Cells[3].Value = false;
                }
            }
        }

        private void CheckAllMenu_Click(object sender, EventArgs e)
        {
            foreach (var row in DataGridView.Rows)
            {

                if (row.DataBoundItem is EmployeeRoom room)
                {
                    row.Cells[3].Value = true;
                }
            }
        }
    }

}
