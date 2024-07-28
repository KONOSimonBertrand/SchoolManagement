

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Linq;
using System;

namespace Primary.SchoolApp.UI
{
    public partial class AddEmployeeGroupForm : SchoolManagement.UI.EditEmployeeGroupForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IEmployeeGroupService employeeGroupService;
        public AddEmployeeGroupForm(IEmployeeGroupService employeeGroupService, ILogService logService, ClientApp clientApp)
        {
            InitializeComponent();
            this.employeeGroupService = employeeGroupService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.Text = "AJOUT:.GROUPE";
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(546, 182);
            NameTextBox.Focus();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!EmployeeGroupExist(NameTextBox.Text))
                {
                    EmployeeGroup group = new();
                    group.Name = NameTextBox.Text;
                    var isDone = employeeGroupService.CreateEmployeeGroup(group).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout groupe employé {group.Name} ",
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
                    this.ErrorLabel.Text = "Ce groupe existe déjà";
                }
            }
        }
        private bool EmployeeGroupExist(string name)
        {
            var item = Program.EmployeeGroupList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return employeeGroupService.GetEmployeeGroup(name).Result != null;
        }
    }
}
