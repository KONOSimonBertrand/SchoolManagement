

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Linq;
using System;
using SchoolManagement.UI.Localization;

namespace Primary.SchoolApp.UI
{
    internal class EditEmployeeGroupForm : SchoolManagement.UI.EditEmployeeGroupForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IEmployeeGroupService employeeGroupService;
        private EmployeeGroup employeeGroup;
        private string employeeGroupNameTracker;
        public EditEmployeeGroupForm(IEmployeeGroupService employeeGroupService, ILogService logService, ClientApp clientApp)
        {
            this.employeeGroupService = employeeGroupService;
            this.logService = logService;
            this.clientApp = clientApp;
            employeeGroupNameTracker = string.Empty;
            this.Text = Language.titleGroupUpdate;
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            NameTextBox.Focus();
        }
        internal void Init(EmployeeGroup group)
        {
            this.employeeGroup = group;
            employeeGroupNameTracker = group.Name;
            NameTextBox.Text = group.Name;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!EmployeeGroupExist(NameTextBox.Text))
                {
                    employeeGroup.Name = NameTextBox.Text;
                    var isDone = employeeGroupService.UpdateEmployeeGroup(employeeGroup).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Mise à jour groupe employé {employeeGroup.Name} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.ErrorLabel.Text = Language.messageUpdateError;
                    }
                }
                else
                {
                    this.ErrorLabel.Text = Language.messageGroupExist;
                }
            }
        }
        private bool EmployeeGroupExist(string name)
        {
            if (employeeGroupNameTracker == name) return false;
            var item = Program.EmployeeGroupList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return employeeGroupService.GetEmployeeGroup(name).Result != null;
        }
    }
}
