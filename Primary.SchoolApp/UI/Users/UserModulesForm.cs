
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    public partial class UserModulesForm : SchoolManagement.UI.UserModulesForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IUserService userService;
        private User selectedUser;
        public UserModulesForm(IUserService userService, ILogService logService, ClientApp clientApp)
        {
            this.userService = userService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.Text = Language.labelUserModule;
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
        //export gridview data to Excel
        private void ExportButton_Click(object sender, EventArgs e)
        {
            AppUtilities.ExportGridViewToExcel(DataGridView, Language.labelModules);
        }
        //print gridview data
        private void PrintButton_Click(object sender, EventArgs e)
        {
            AppUtilities.PrintGridView(DataGridView, Language.labelModules);
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

                if (row.DataBoundItem is UserModule module)
                {
                    for (int i = 1; i < row.Cells.Count; i++)
                    {
                        row.Cells[i].Value = false;
                    }
                }
            }
        }

        private void CheckAllMenu_Click(object sender, EventArgs e)
        {
            foreach (var row in DataGridView.Rows)
            {

                if (row.DataBoundItem is UserModule module)
                {
                    for (int i = 1; i < row.Cells.Count; i++)
                    {
                        row.Cells[i].Value = true;
                    }
                }
            }
        }

        internal void Init(User user)
        {
            selectedUser = user;
            LoadModules();
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
       //load modules in datagridview
        private async void LoadModules()
        {
            selectedUser.Modules = userService.GetUserModuleList(selectedUser.Id).Result;
            var userModulList = selectedUser.Modules.Select(x => x.Module).ToList();
            //find module to complete user module list
            foreach (var module in Program.ModuleList)
            {
                if (!userModulList.Contains(module))
                {
                    selectedUser.Modules.Add(
                        new UserModule()
                        {
                            Module = module,
                            ModuleId = module.Id,
                            AllowCreate = false,
                            AllowDelete = false,
                            AllowMail = false,
                            AllowPrint = false,
                            AllowRead = false,
                            AllowUpdate = false,
                            IsDefault = false,
                            User = selectedUser,
                            UserId = selectedUser.Id,
                        }
                        );
                }
            }
            DataGridView.DataSource = selectedUser.Modules;

            await Task.Delay(0);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            selectedUser.Modules.Clear();
            foreach (var row in DataGridView.Rows)
            {
                if (row.DataBoundItem is UserModule module)
                {
                    if (module.HasOneChecked) selectedUser.Modules.Add(module);
                }
            }
            var isDone = userService.AddModuleList(selectedUser.Id, selectedUser.Modules.ToList()).Result;
            if (isDone)
            {
                Log log = new()
                {
                    UserAction = $"Mise à jour des modules alloués de l'utilisateur {selectedUser.UserName}  par l'utisateur  {clientApp.UserConnected.Name} ",
                    UserId = clientApp.UserConnected.Id
                };
                logService.CreateLog(log);
                this.Close();
            }
            else RadMessageBox.Show(Language.messageUpdateError);

        }
        //create columns of datagridview
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
            GridViewTextBoxColumn moduleColumn = new("Module.Name");
            GridViewCheckBoxColumn readColumn = new("AllowRead");
            GridViewCheckBoxColumn createColumn = new("AllowCreate");
            GridViewCheckBoxColumn updateColumn = new("AllowUpdate");
            GridViewCheckBoxColumn deleteColumn = new("AllowDelete");
            GridViewCheckBoxColumn printColumn = new("AllowPrint");
            GridViewCheckBoxColumn mailColumn = new("AllowMail");
            GridViewCheckBoxColumn defaultColumn = new("IsDefault");
            moduleColumn.ReadOnly = true;
            moduleColumn.HeaderText = Language.labelModule;
            readColumn.HeaderText = Language.labelRead;
            createColumn.HeaderText = Language.labelAdding;
            updateColumn.HeaderText = Language.labelUpdate;
            deleteColumn.HeaderText = Language.labelDeletion;
            printColumn.HeaderText = Language.labelPrinting;
            mailColumn.HeaderText = Language.labelMail;
            defaultColumn.HeaderText = Language.labelDefaultModule;

            this.DataGridView.Columns.Add(moduleColumn);
            this.DataGridView.Columns.Add(readColumn);
            this.DataGridView.Columns.Add(createColumn);
            this.DataGridView.Columns.Add(updateColumn);
            this.DataGridView.Columns.Add(deleteColumn);
            this.DataGridView.Columns.Add(printColumn);
            this.DataGridView.Columns.Add(mailColumn);
            this.DataGridView.Columns.Add(defaultColumn);
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

                e.Visible &= e.Row.Cells["Module.Name"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
            }
        }
    }

}
