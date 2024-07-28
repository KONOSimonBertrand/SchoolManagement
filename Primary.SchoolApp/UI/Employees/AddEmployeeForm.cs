﻿
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Linq;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    public partial class AddEmployeeForm  :SchoolManagement.UI.EditEmployeeForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly IJobService jobService;
        private readonly IEmployeeGroupService employeeGroupService;
        private readonly ClientApp clientApp;
        public AddEmployeeForm(IEmployeeService employeeService, IJobService jobService, IEmployeeGroupService employeeGroupService, ClientApp clientApp, ILogService logService)
        {
            InitializeComponent();
            this.employeeGroupService = employeeGroupService;
            this.jobService = jobService;
            this.employeeService = employeeService;
            this.clientApp = clientApp;
            this.logService = logService;
            GroupDropDownList.DataSource = Program.EmployeeGroupList;
            JobDropDownList.DataSource=Program.JobList;
            GroupDropDownList.SelectedIndex = -1;
            JobDropDownList.SelectedIndex = -1;
            NationalityDropDownList.DataSource=Program.CountryList.Select(x=>x.FrenchName);
            NationalityDropDownList.Text = "Cameroun";
            LoadNextIdNumber();
            InitEvents();
            this.Text = "AJOUT:.EMPLOYE";
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            AddJobButton.Click += AddJobButton_Click;
            AddGroupButton.Click += AddGroupButton_Click;
            this.Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            IdNumberTextBox.Focus();
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
                form.Init(item);
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
                RadMessageBox.Show("Fonction inconnue");
            }
        }
        // show employee group UI for edit
        private void ShowEmployeeGroupEditForm(EmployeeGroup item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditEmployeeGroupForm>();
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
                RadMessageBox.Show("Groupe d'employés inconnu");
            }
        }

        private bool IdNumberExist(string idMumber)
        {
            var item = Program.EmployeeList.FirstOrDefault(x => x.IdNumber== idMumber);
            if (item != null) return true;
            return employeeService.GetEmployee(idMumber).Result != null;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (IsValidData())
            {
                if (!IdNumberExist(IdNumberTextBox.Text))
                {
                    Employee employee = new();
                    employee.IdNumber = IdNumberTextBox.Text;
                    employee.FirstName = FirstNameTextBox.Text;
                    employee.LastName = LastNameTextBox.Text;
                    employee.Sex = SexDropDownList.SelectedValue.ToString();
                    employee.Birthday = BirthdayDateTimePicker.Value;
                    employee.Nationality = NationalityDropDownList.Text;
                    employee.Phone = PhoneTextBox.Text;
                    employee.Address=AddressTextBox.Text;
                    employee.HiringDate = HiringDateDateTimePicker.Value;
                    employee.IdCard = IdCardTextBox.Text;
                    employee.Religion = ReligionDropDownList.Text;
                    employee.Job = JobDropDownList.SelectedItem.DataBoundItem as Job;
                    employee.JobId = employee.Job.Id;
                    employee.Group = GroupDropDownList.SelectedItem.DataBoundItem as EmployeeGroup;
                    employee.GroupId= employee.Group.Id;
                    employee.Salary = SalaryTextBox.Text.Trim()!=string.Empty?double.Parse(SalaryTextBox.Text):0;
                    var isDone = employeeService.CreateEmploye(employee).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Mise à jour fonction employé {employee.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}",
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
                    ErrorLabel.Text = "Ce matricule est déjà attibué ";
                }
            }
        }
    
        private async void LoadNextIdNumber()
        {
            var idNumber= await employeeService.GenerateEmployeeIdNumber();
            if(IdNumberTextBox.Text.Trim()==string.Empty)IdNumberTextBox.Text = idNumber;

        }

    }
}
