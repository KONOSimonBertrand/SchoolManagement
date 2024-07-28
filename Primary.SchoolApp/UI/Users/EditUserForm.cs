

using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Linq;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    public partial class EditUserForm : SchoolManagement.UI.EditUserForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IUserService userService;
        private readonly IEmployeeService employeeService;
        private User user;
        private string userLoginTracker;
        public EditUserForm(IUserService userService, ILogService logService, IEmployeeService employeeService, ClientApp clientApp)
        {
            InitializeComponent();
            InitEvents();
            this.userService = userService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.employeeService = employeeService;
            this.Text = "MODIFICATION:.UTILISATEUR";
            this.userService = userService;
            EmployeeDropDownList.DataSource=Program.EmployeeList;
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            AddEmployeeButton.Click += AddEmployeeButton_Click;
            this.Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(957, 390);
            EmployeeDropDownList.Focus();
        }

        internal void Init(User user)
        {
            this.user = user;
            NameTextBox.Text = user.Name;
            LoginTextBox.Text = user.UserName;
            EmailTextBox.Text = user.Email;
            PasswordTextBox.Text = user.Password;
            if (user.Employee != null) EmployeeDropDownList.SelectedValue = user.EmployeeId;
            EmployeeDropDownList.SelectedValue = user.EmployeeId;
            userLoginTracker=user.UserName;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if ( IsValidData()) {
                if (!UserExist(LoginTextBox.Text))
                {
                    if(EmployeeDropDownList.SelectedItem!=null)
                    {
                        user.Employee = EmployeeDropDownList.SelectedItem. DataBoundItem as Employee;
                        user.EmployeeId= user.Employee.Id;
                    }
                    else
                    {
                        user.Employee = null;
                        user.EmployeeId = null;
                    }
                    user.UserName= LoginTextBox.Text;
                    user.Name = NameTextBox.Text;
                    user.Email = EmailTextBox.Text;
                    user.Password = PasswordTextBox.Text;
                    var isDone=userService.UpdateUser(user).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Mise à jour de l'utilisateur {user.UserName}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
            if (userLoginTracker == userName) return false;
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
