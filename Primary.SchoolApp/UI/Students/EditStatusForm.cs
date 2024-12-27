

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;

namespace Primary.SchoolApp.UI
{
    internal class EditStatusForm: SchoolManagement.UI.EditStatusForm
    {
        private readonly IStudentEnrollingService enrollingService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedInrolling;
        public EditStatusForm(IStudentEnrollingService enrollingService, ILogService logService, ClientApp clientApp)
        {
            this.enrollingService = enrollingService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
        }
        private void InitEvents()
        {
            this.SaveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData()) { 
             var isDone=enrollingService.ChangeStudentEnrollingStatusAsync(selectedInrolling.Id,!selectedInrolling.IsActive,ReasonDropDownList.Text).Result;
                if (isDone) {
                    selectedInrolling.IsActive = !selectedInrolling.IsActive;
                    //enregistrement du log
                    Log log = new()
                    {
                        UserAction = $"Changement de statut  {ReasonDropDownList.Text} de l'élève {selectedInrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        internal void Init(StudentEnrolling enrolling)
        {
            this.selectedInrolling = enrolling;
        }
    }
}
