using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Windows.Forms;
namespace Primary.SchoolApp.UI
{
    internal class AddMedicalRecordForm : SchoolManagement.UI.EditMedicalRecordForm
    {
        private readonly IMedicalService medicalService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private Student selectedStudent;
        public AddMedicalRecordForm(IMedicalService medicalService, ILogService logService,ClientApp clientApp)
        {
            this.medicalService = medicalService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
        }
        private void InitEvents()
        {
            this.SaveButton.Click += SaveButton_Click;
            this.Shown += FormOnShown;
        }

        private void FormOnShown(object sender, EventArgs e)
        {
            this.HealthSubjectDropDownList.Focus();
        }

    
        internal void Init(Student student)
        {
            this.selectedStudent = student;
            this.StudentTextBox.Text = student.FullName;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!RecordExist(this.selectedStudent.Id, this.DescriptionTextBox.Text))
                {
                    MedicalRecord medicalRecord = new()
                    {
                        Date = this.DateTimePicker.Value,
                        HealthSubject = this.HealthSubjectDropDownList.SelectedValue.ToString(),
                        Description=this.DescriptionTextBox.Text,
                        Student = selectedStudent,
                        StudentId = selectedStudent.Id,
                    };
                    //add medical record
                    var isDone = medicalService.CreateMedicalRecord(medicalRecord).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log log = new()
                        {
                            UserAction = $"Ajout d'un élément médical  {medicalRecord.HealthSubject} : {medicalRecord.Description} de l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageAddError;
                        ErrorProvider.SetError(this.DescriptionTextBox, Language.messageAddError);
                        this.DescriptionTextBox.Focus();
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageRecordExist;
                    ErrorProvider.SetError(this.DescriptionTextBox, Language.messageRecordExist);
                    this.DescriptionTextBox.Focus();
                }
            }
        }

        private bool RecordExist(int studentId, string description)
        {
            return medicalService.GetMedicalRecord(studentId, description).Result != null;
        }
    }
}
