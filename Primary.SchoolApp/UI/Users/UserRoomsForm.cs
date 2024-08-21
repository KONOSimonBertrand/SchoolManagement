

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System.Linq;
using System;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Primary.SchoolApp.Utilities;
using System.Threading.Tasks;

namespace Primary.SchoolApp.UI
{
    public partial class UserRoomsForm : SchoolManagement.UI.UserRoomsForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IUserService userService;
        private User selectedUser;
        public UserRoomsForm(IUserService userService, ILogService logService, ClientApp clientApp)
        {
            this.userService = userService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.Text = Language.labelUserRoom;
            this.userService = userService;
            CreateGridViewColumn();
            InitEvents();

        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            DataGridView.ContextMenuOpening += DataGridView_ContextMenuOpening;
            FilterTextBox.TextChanged += FilterTextBox_TextChanged;
            PrintButton.Click += PrintButton_Click; ;
           ExportButton.Click += ExportButton_Click;
            CloseButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            AppUtilities.ExportGridViewToExcel(DataGridView, Language.titleRoomList);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            AppUtilities.PrintGridView(DataGridView, Language.titleRoomList);
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

                if (row.DataBoundItem is UserRoom room)
                {
                    row.Cells[1].Value = false;
                }
            }
        }

        private void CheckAllMenu_Click(object sender, EventArgs e)
        {
            foreach (var row in DataGridView.Rows)
            {

                if (row.DataBoundItem is UserRoom room)
                {
                    row.Cells[1].Value = true;
                }
            }
        }

        internal void Init(User user)
        {
            selectedUser = user;
            LoadRooms();
            foreach (var item in selectedUser.Rooms)
            {
                item.IsChecked = true;
            }
            LoginLabel.Text = user.UserName;
            if (user.Name.Length >= 17)
            {
                NameLabel.Text = user.Name.Substring(0, 17) + "..."; ;
            }
            else
            {
                NameLabel.Text = user.Name;
            }
            NameLabel.LabelElement.ToolTipText = user.UserName;
            if (user.Employee != null)
            {
                EmployeeInformationLabel.Text = user.Employee.FullName;
                AddressLabel.Text = user.Employee.Address;
                EmailLabel.Text = user.Employee.Email;
                PhoneLabel.Text = user.Employee.Phone;
            }
            else
            {
                EmployeeInformationLabel.Text = string.Empty;
                AddressLabel.Text = string.Empty;
                EmailLabel.Text = string.Empty;
                PhoneLabel.Text = string.Empty;
            }
            
        }
        //load user'rooms
        private async void LoadRooms()
        {
            selectedUser.Rooms = userService.GetUserRoomList(selectedUser.Id).Result;

            var userRoomlList = selectedUser.Rooms.Select(x => x.Room).ToList();
            //find room to complete user room list
            foreach (var room in Program.SchoolRoomList)
            {
                if (!userRoomlList.Contains(room))
                {
                    selectedUser.Rooms.Add(
                        new UserRoom()
                        {
                            Room = room,
                            RoomId = room.Id,
                            User = selectedUser,
                            UserId = selectedUser.Id,
                        }
                        );
                }
            }
            DataGridView.DataSource = selectedUser.Rooms;
            await Task.Delay(0);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            selectedUser.Rooms.Clear();
            foreach (var row in DataGridView.Rows)
            {
                if (row.DataBoundItem is UserRoom room)
                {
                    if (room.IsChecked) selectedUser.Rooms.Add(room);
                }
            }
            var isDone = userService.AddRoomList(selectedUser.Id, selectedUser.Rooms.ToList()).Result;
            if (isDone)
            {
                Log log = new()
                {
                    UserAction = $"Mise à jour des classes allouées de l'utilisateur {selectedUser.UserName}  par l'utisateur  {clientApp.UserConnected.Name} ",
                    UserId = clientApp.UserConnected.Id
                };
                logService.CreateLog(log);
                this.Close();
            }
            else RadMessageBox.Show(Language.messageUpdateError);

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
            GridViewCheckBoxColumn stateColumn = new("IsChecked");
            roomColumn.HeaderText = Language.labelClass;
            stateColumn.HeaderText = Language.labelAssign;
            roomColumn.ReadOnly = true;
            this.DataGridView.Columns.Add(roomColumn);
            this.DataGridView.Columns.Add(stateColumn);
        }
        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridView.MasterTemplate.Refresh();
        }
        private void DataGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            if (FilterTextBox.Text != null)
            {

                e.Visible &= e.Row.Cells["Room.Name"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
            }
        }
    }
}
