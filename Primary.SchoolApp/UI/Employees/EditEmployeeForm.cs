
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class EditEmployeeForm : SchoolManagement.UI.EditEmployeeForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly IJobService jobService;
        private readonly IEmployeeGroupService employeeGroupService;
        private readonly ClientApp clientApp;
        private Employee employee;
        private string idNumberTacker;

        public EditEmployeeForm(IEmployeeService employeeService, IJobService jobService, IEmployeeGroupService employeeGroupService, ClientApp clientApp, ILogService logService)
        {
            this.employeeGroupService = employeeGroupService;
            this.jobService = jobService;
            this.employeeService = employeeService;
            this.clientApp = clientApp;
            this.logService = logService;
            NationalityDropDownList.DataSource = Program.CountryList.Select(x => x.FrenchName);
            NationalityDropDownList.Text = "Cameroun";
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }
        internal void Init(Employee employee)
        {
            if (employee != null)
            {
                this.employee = employee;
                idNumberTacker = employee.IdNumber;
                IdNumberTextBox.Text = employee.IdNumber;
                FirstNameTextBox.Text = employee.FirstName;
                LastNameTextBox.Text = employee.LastName;
                SexDropDownList.SelectedValue = employee.Sex;
                BirthdayDateTimePicker.Value = employee.BirthDate;
                NationalityDropDownList.Text = employee.Nationality;
                PhoneTextBox.Text = employee.Phone;
                AddressTextBox.Text = employee.Address;
                HiringDateDateTimePicker.Value = employee.HiringDate;
                IdCardTextBox.Text = employee.IdCard;
                ReligionDropDownList.Text = employee.Religion;
            }
        }
        private void OnShown(object sender, EventArgs e)
        {
            IdNumberTextBox.Focus();
        }


        private bool IdNumberExist(string idNumber)
        {
            if (idNumberTacker == idNumber) return false;
            var item = Program.EmployeeList.FirstOrDefault(x => x.IdNumber == idNumber);
            if (item != null) return true;
            return employeeService.GetEmployee(idNumber).Result != null;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!IdNumberExist(IdNumberTextBox.Text))
                {
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
                    var isDone = employeeService.UpdateEmploye(employee).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Mise à jour employé {employee.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}",
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
                    ErrorLabel.Text = Language.messageIdNumberlreadyExist;
                }
            }
        }
    }
}

