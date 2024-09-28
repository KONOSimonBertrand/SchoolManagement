using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;


namespace Primary.SchoolApp.UI { 
    internal class EditDisciplineSubjectForm : SchoolManagement.UI.EditDisciplineSubjectForm {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IDisciplineService disciplineService;
        private DisciplineSubject selectedSubject;
        public EditDisciplineSubjectForm(ILogService logService, ClientApp clientApp, IDisciplineService disciplineService)
        {
            this.logService = logService;
            this.clientApp = clientApp;
            this.disciplineService = disciplineService;
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            FrenchNameTextBox.Focus();
        }
        internal void Init(DisciplineSubject subject)
        {
            this.selectedSubject = subject;
            this.FrenchNameTextBox.Text=subject.FrenchName;
            this.EnglishNameTextBox.Text=subject.EnglishName;
            this.SequenceSpinEditor.Value = subject.Sequence;   
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                selectedSubject.FrenchName=this.FrenchNameTextBox.Text;
                selectedSubject.EnglishName=this.EnglishNameTextBox.Text;
                selectedSubject.Sequence = int.Parse(this.SequenceSpinEditor.Value.ToString());
                var isDone = disciplineService.UpdateDisciplineSubject(selectedSubject).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Mise à jour d'un objet de discipline {selectedSubject.FrenchName} par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.ErrorProvider.SetError(this, Language.messageUpdateError);
                    this.ErrorLabel.Text = Language.messageUpdateError;
                }
            }
        }
    }
}
