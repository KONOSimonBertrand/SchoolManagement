using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Threading;

namespace Primary.SchoolApp.UI
{
    internal class EditStudentForm : SchoolManagement.UI.EditStudentForm
    {
        private readonly ILogService logService;
        private readonly IStudentService studentService;
        private readonly ClientApp clientApp;
        private Student selectedStudent;
        public EditStudentForm(ILogService logService, IStudentService studentService, ClientApp clientApp)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.clientApp = clientApp;
            if(Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
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
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
        }
        //affiches les info du student 
        internal void Init(Student student)
        {
            selectedStudent = student;
            if (student != null) {
                selectedStudent=student;
                IdNumberTextBox.Text = student.IdNumber;
                FirstNameTextBox.Text = student.FirstName;
                LastNameTextBox.Text = student.LastName;
                BirthDayDateTimePicker.Value = student.BirthDate;
                BirthPlaceTextBox.Text = student.BirthPlace;
                SexDropDownList.SelectedValue = student.Sex;
                PhoneTextBox.Text = student.Phone;
                AddressTextBox.Text = student.Address;
                EmailTextBox.Text = student.Email;
                ReligionDropDownList.Text = student.Religion;
                NationalityDropDownList.Text= student.Nationality;
                IdCardTextBox.Text = student.IdCard;
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData()) {
                selectedStudent.FirstName=FirstNameTextBox.Text;
                selectedStudent.LastName=LastNameTextBox.Text;
                selectedStudent.Sex=SexDropDownList.SelectedValue.ToString();
                selectedStudent.BirthDate=BirthDayDateTimePicker.Value;
                selectedStudent.BirthPlace=BirthPlaceTextBox.Text;
                selectedStudent.Phone=PhoneTextBox.Text;
                selectedStudent.Email=EmailTextBox.Text;
                selectedStudent.Address=AddressTextBox.Text;
                selectedStudent.Nationality=NationalityDropDownList.Text;
                selectedStudent.Religion=ReligionDropDownList.Text;
                selectedStudent.IdCard=IdCardTextBox.Text;
                var isDone=studentService.UpdateStudentAsync(selectedStudent).Result;
                if (isDone == true)
                {
                    Log log = new()
                    {
                        UserAction = $"Modification des informations de l'élève {selectedStudent.IdNumber}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
        }

       
    }
}
