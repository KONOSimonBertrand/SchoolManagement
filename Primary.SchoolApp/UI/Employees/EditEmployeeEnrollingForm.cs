
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    internal class EditEmployeeEnrollingForm : SchoolManagement.UI.EditEmployeeEnrollingForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly IJobService jobService;
        private readonly IEmployeeGroupService employeeGroupService;
        private readonly ClientApp clientApp;
        private EmployeeEnrolling enrolling;
        public EditEmployeeEnrollingForm(IEmployeeService employeeService, IJobService jobService, IEmployeeGroupService employeeGroupService, ClientApp clientApp, ILogService logService)
        {
            this.employeeGroupService = employeeGroupService;
            this.jobService = jobService;
            this.employeeService = employeeService;
            this.clientApp = clientApp;
            this.logService = logService;
            EmployeeDropDownList.DataSource = Program.EmployeeList;
            GroupDropDownList.DataSource = Program.EmployeeGroupList;
            JobDropDownList.DataSource = Program.JobList;
            GroupDropDownList.SelectedIndex = -1;
            JobDropDownList.SelectedIndex = -1;
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            AddEmployeeButton.Click += AddEmployeeButton_Click;
            AddJobButton.Click += AddJobButton_Click;
            AddGroupButton.Click += AddGroupButton_Click;
            this.Shown += OnShown;
        }

        internal void Init(EmployeeEnrolling enrolling)
        {
            if (enrolling != null)
            {
                this.enrolling = enrolling;
                EnrollingDateTimePicker.Value = enrolling.Date;
                SchoolYearTextBox.Text = enrolling.SchoolYear.Name;
                EmployeeDropDownList.SelectedValue = enrolling.EmployeeId;
                JobDropDownList.SelectedValue = enrolling.JobId;
                GroupDropDownList.SelectedValue = enrolling.GroupId;
                SalaryTextBox.Text = enrolling.Salary.ToString();
                EmployeeDropDownList.Enabled = false;
            }
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

        private void OnShown(object sender, EventArgs e)
        {
            EnrollingDateTimePicker.Focus();
        }

        private void AddGroupButton_Click(object sender, EventArgs e)
        {
            if (GroupDropDownList.SelectedItem == null)
            {
                ShowEmployeeGroupAddForm();
            }
            else
            {
                ShowEmployeeGroupEditForm(GroupDropDownList.SelectedItem.DataBoundItem as EmployeeGroup);
            }
        }
        private void AddJobButton_Click(object sender, EventArgs e)
        {
            if (JobDropDownList.SelectedItem == null)
            {
                ShowJobAddForm();
            }
            else
            {
                ShowJobEditForm(JobDropDownList.SelectedItem.DataBoundItem as Job);
            }
        }
        // show job UI to add new 
        private void ShowJobAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddJobForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelJob;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = jobService.GetJob(form.NameTextBox.Text).Result;
                Program.JobList.Add(data);
                JobDropDownList.DataSource = null;
                JobDropDownList.DataSource = Program.SchoolClassList;
                JobDropDownList.SelectedValue = data;
            }
        }
        // show employee group UI to add new 
        private void ShowEmployeeGroupAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddEmployeeGroupForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelEmployeeGroup;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = employeeGroupService.GetEmployeeGroup(form.NameTextBox.Text).Result;
                Program.EmployeeGroupList.Add(data);
                GroupDropDownList.DataSource = null;
                GroupDropDownList.DataSource = Program.EmployeeGroupList;
                GroupDropDownList.SelectedValue = data;
            }
        }
        // show job UI for edit
        private void ShowJobEditForm(Job item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditJobForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelJob;
                form.Init(item);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = jobService.GetJob(form.NameTextBox.Text).Result;
                    JobDropDownList.DataSource = null;
                    JobDropDownList.DataSource = Program.JobList;
                    JobDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowJob);
            }
        }
        // show employee group UI for edit
        private void ShowEmployeeGroupEditForm(EmployeeGroup item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditEmployeeGroupForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelEmployeeGroup;
                form.Init(item);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = employeeGroupService.GetEmployeeGroup(form.NameTextBox.Text).Result;
                    GroupDropDownList.DataSource = null;
                    GroupDropDownList.DataSource = Program.EmployeeGroupList;
                    GroupDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }
        }
        private void ShowEmployeeEditForm(Employee employee)
        {
            if (employee != null)
            {
                var form = Program.ServiceProvider.GetService<EditEmployeeForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelEmployee;
                form.Init(employee);
                form.Icon = this.Icon;
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
            form.Text = Language.labelAdd + ":.. " + Language.labelEmployee;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = employeeService.GetEmployee(form.IdNumberTextBox.Text).Result;
                Program.EmployeeList.Add(data);
                EmployeeDropDownList.DataSource = null;
                EmployeeDropDownList.DataSource = Program.EmployeeList;
                EmployeeDropDownList.SelectedValue = data;
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {

                enrolling.Date = EnrollingDateTimePicker.Value;
                enrolling.Employee = EmployeeDropDownList.SelectedItem.DataBoundItem as Employee;
                enrolling.EmployeeId = enrolling.Employee.Id;
                enrolling.Job = JobDropDownList.SelectedItem.DataBoundItem as Job;
                enrolling.JobId = enrolling.Job.Id;
                enrolling.Group = GroupDropDownList.SelectedItem.DataBoundItem as EmployeeGroup;
                enrolling.GroupId = enrolling.Group.Id;
                enrolling.Salary = SalaryTextBox.Text.Trim() != string.Empty ? double.Parse(SalaryTextBox.Text) : 0;
                var isDone = employeeService.UpdateEmployeeEnrolling(enrolling).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Mise à  de l'inscription de l'employé {enrolling.Employee.FullName} pour l'année {enrolling.SchoolYear.Name}  par l'utilisateur {clientApp.UserConnected.UserName}",
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
        }

    }
}
