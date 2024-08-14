
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    public partial class AddUserForm : SchoolManagement.UI.EditUserForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IUserService userService;
        private readonly IEmployeeService employeeService;
        public AddUserForm(IUserService userService, ILogService logService, IEmployeeService employeeService, ClientApp clientApp)
        {
            InitEvents();
            this.userService = userService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.employeeService = employeeService;
            this.Text = Language.titleUserAdd;
            this.userService = userService;
            EmployeeDropDownList.DataSource = Program.EmployeeList;
            EmployeeDropDownList.SelectedIndex = -1;
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            AddEmployeeButton.Click += AddEmployeeButton_Click;
            this.Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            EmployeeDropDownList.Focus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!UserExist(LoginTextBox.Text))
                {
                    User user = new();
                    if (EmployeeDropDownList.SelectedItem != null)
                    {

                        user.Employee = EmployeeDropDownList.SelectedItem.DataBoundItem as Employee;
                        user.EmployeeId = user.Employee.Id;
                    }
                    else
                    {
                        user.Employee = null;
                        user.EmployeeId = null;
                    }
                    user.UserName = LoginTextBox.Text;
                    user.Name = NameTextBox.Text;
                    user.Email = EmailTextBox.Text;
                    user.Password = PasswordTextBox.Text;
                    var isDone = userService.CreateUser(user).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout de l'utilisateur {user.UserName}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.ErrorLabel.Text = "Erreur d'enregistrement";
                    }
                }
                else
                {
                    ErrorLabel.Text = "Ce compte utilisateur existe déjà";
                }
            }
        }
        private bool UserExist(string userName)
        {
            var item = Program.UserList.FirstOrDefault(x => x.UserName == userName);
            if (item != null) return true;
            return userService.GetUser(userName).Result != null;
        }
        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            if (EmployeeDropDownList.SelectedItem == null)
            {
                ShowEmployeeAddForm();
            }
            else
            {
                ShowEmployeeEditForm(EmployeeDropDownList.SelectedItem.DataBoundItem as Employee);

            }
        }
        private void ShowEmployeeEditForm(Employee employee)
        {
            if (employee != null)
            {
                var form = Program.ServiceProvider.GetService<EditEmployeeForm>();
                form.Init(employee);
                form.Icon = this.Icon;
                form.ClientSize = new System.Drawing.Size(800, 450);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = employeeService.GetEmployee(form.IdNumberTextBox.Text).Result;
                    EmployeeDropDownList.DataSource = null;
                    EmployeeDropDownList.DataSource = Program.EmployeeList;
                    EmployeeDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show("Employé inconnue");
            }
        }
        private void ShowEmployeeAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddEmployeeForm>();
            form.Icon = this.Icon;
            form.ClientSize = new System.Drawing.Size(800, 450);
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = employeeService.GetEmployee(form.IdNumberTextBox.Text).Result;
                Program.EmployeeList.Add(data);
                EmployeeDropDownList.DataSource = null;
                EmployeeDropDownList.DataSource = Program.EmployeeList;
                EmployeeDropDownList.SelectedValue = data;
            }
        }
    }
}
