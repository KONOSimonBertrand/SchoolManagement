
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class AddEmployeeForm : SchoolManagement.UI.EditEmployeeForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly IJobService jobService;
        private readonly IEmployeeGroupService employeeGroupService;
        private readonly ClientApp clientApp;
        public AddEmployeeForm(IEmployeeService employeeService, IJobService jobService, IEmployeeGroupService employeeGroupService, ClientApp clientApp, ILogService logService)
        {
            this.employeeGroupService = employeeGroupService;
            this.jobService = jobService;
            this.employeeService = employeeService;
            this.clientApp = clientApp;
            this.logService = logService;
            NationalityDropDownList.DataSource = Program.CountryList.Select(x => x.FrenchName);
            NationalityDropDownList.Text = "Cameroun";
            LoadNextIdNumber();
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            IdNumberTextBox.Focus();
        }

        private bool IdNumberExist(string idMumber)
        {
            var item = Program.EmployeeList.FirstOrDefault(x => x.IdNumber == idMumber);
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
                    employee.BirthDate = BirthdayDateTimePicker.Value;
                    employee.Nationality = NationalityDropDownList.Text;
                    employee.Phone = PhoneTextBox.Text;
                    employee.Address = AddressTextBox.Text;
                    employee.HiringDate = HiringDateDateTimePicker.Value;
                    employee.IdCard = IdCardTextBox.Text;
                    employee.Religion = ReligionDropDownList.Text;
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
                        this.ErrorLabel.Text = Language.messageAddError;
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageIdNumberlreadyExist;
                }
            }
        }
        private async void LoadNextIdNumber()
        {
            var idNumber = await employeeService.GenerateEmployeeIdNumber();
            if (IdNumberTextBox.Text.Trim() == string.Empty) IdNumberTextBox.Text = idNumber;

        }

    }
}
