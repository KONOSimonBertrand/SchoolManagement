
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Threading;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class AddStudentForm:SchoolManagement.UI.EditStudentForm
    {
        private readonly ILogService logService;
        private readonly IStudentService studentService;
        private readonly ClientApp clientApp;
        private int healthState = 0;
        public AddStudentForm(ILogService logService, IStudentService studentService, ClientApp clientApp)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.clientApp = clientApp;
            if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
            {
                NationalityDropDownList.DataSource = Program.CountryList.Select(x => x.FrenchName);
                NationalityDropDownList.Text = "Cameroun";
            }
            else
            {
                NationalityDropDownList.DataSource = Program.CountryList.Select(x => x.EnglishName);
                NationalityDropDownList.Text = "Cameroon";
            }
            BirthDayDateTimePicker.Value = DateTime.Now;
            GenerateIdNumber();
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            GoodHealthMenuItem.Click += HealthState_Click;
            MediumHealthMenuItem.Click += HealthState_Click;
            BadHealthMenuItem.Click += HealthState_Click;
        }
        private void HealthState_Click(object sender, EventArgs e)
        {
            var state = (RadMenuItem)sender;
            if (state != null)
            {
                healthState = int.Parse(state.Tag.ToString());
                HealthStateSplitButton.Tag = state.Tag;
                HealthStateSplitButton.Image = state.Image;
            }

        }
        private void OnShown(object sender, EventArgs e)
        {
            LastNameTextBox.Focus();
        }

        private async void GenerateIdNumber()
        {
            if (IdCardTextBox.Text == string.Empty)
            {
                IdNumberTextBox.Text = await studentService.GenerateStudentIdNumberAsync();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!RecordExist(IdNumberTextBox.Text))
                {
                    var record = new Student
                    {
                        IdNumber = IdNumberTextBox.Text,
                        FirstName = FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        Sex = SexDropDownList.SelectedValue.ToString(),
                        BirthDate = BirthDayDateTimePicker.Value,
                        BirthPlace = BirthPlaceTextBox.Text,
                        Phone = PhoneTextBox.Text,
                        Email = EmailTextBox.Text,
                        Address = AddressTextBox.Text,
                        Nationality = NationalityDropDownList.Text,
                        Religion = ReligionDropDownList.Text,
                        IdCard = IdCardTextBox.Text,
                        Health = healthState
                    };
                    var isDone = studentService.CreateStudentAsync(record).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout de  l'élève {record.FullName}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageUpdateError;
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageRecordExist;
                    ErrorProvider.SetError(this.IdNumberTextBox, Language.messageRecordExist);
                    this.IdNumberTextBox.Focus();
                }
            }
        }
        private bool RecordExist(string idNumber)
        {
            if (Program.StudentList.Where(x => x.IdNumber == idNumber).Count() > 0)
            {
                return true;
            }
            return studentService.GetStudentAsync(idNumber).Result != null;
        }
    }
}
