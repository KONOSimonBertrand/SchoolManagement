using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Windows.Forms;

namespace Primary.SchoolApp.UI
{
    internal class EditMedicalRecordForm : SchoolManagement.UI.EditMedicalRecordForm
    {
        private readonly IMedicalService medicalService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private MedicalRecord selectedMedicalRecord;
        public EditMedicalRecordForm(IMedicalService medicalService, ILogService logService, ClientApp clientApp)
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


        internal void Init(MedicalRecord medicalRecord)
        {
            this.selectedMedicalRecord = medicalRecord;
            this.StudentTextBox.Text = medicalRecord.Student.FullName;
            this.DateTimePicker.Value = medicalRecord.Date;
            this.HealthSubjectDropDownList.SelectedValue = medicalRecord.HealthSubject;
            this.DescriptionTextBox.Text = medicalRecord.Description;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                
                    selectedMedicalRecord.Date = this.DateTimePicker.Value;
                    selectedMedicalRecord.HealthSubject = this.HealthSubjectDropDownList.SelectedValue.ToString();
                    selectedMedicalRecord.Description = this.DescriptionTextBox.Text;

                    //update medical record
                    var isDone = medicalService.UpdateMedicalRecord(selectedMedicalRecord).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log log = new()
                        {
                            UserAction = $"Mise à jour d'un élément médical  {selectedMedicalRecord.HealthSubject} : {selectedMedicalRecord.Description} de l'élève {selectedMedicalRecord.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageUpdateError;
                        ErrorProvider.SetError(this.DescriptionTextBox, Language.messageAddError);
                        this.DescriptionTextBox.Focus();
                    }                               
            }
        }
    }
}
