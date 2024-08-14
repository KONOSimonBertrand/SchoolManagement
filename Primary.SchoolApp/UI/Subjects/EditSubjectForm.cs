using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Linq;
using System;
using SchoolManagement.UI.Localization;

namespace Primary.SchoolApp.UI
{
    internal class EditSubjectForm : SchoolManagement.UI.EditSubjectForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISubjectService subjectService;
        private string subjectNameTracker;
        Subject subject;
        public EditSubjectForm(ISubjectService subjectService, ILogService logService, ClientApp clientApp)
        {
            this.subjectService = subjectService;
            this.logService = logService;
            this.clientApp = clientApp;
            subjectNameTracker = string.Empty;
            InitEvents();
            this.Text = Language.titleSubjectUpdate;
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }
        internal void Init(Subject subject)
        {
            this.subject = subject;
            FrenchNameTextBox.Text = subject.FrenchName;
            EnglishhNameTextBox.Text = subject.EnglishName;
            SequenceSpinEditor.Value = subject.Sequence;
            subjectNameTracker = subject.FrenchName;

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {

                if (!SubjectExist(FrenchNameTextBox.Text))
                {
                    subject.FrenchName = FrenchNameTextBox.Text;
                    subject.EnglishName = EnglishhNameTextBox.Text;
                    subject.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    var isDone = subjectService.UpdateSubject(subject).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout  matière {subject.FrenchName}/{subject.EnglishName} ",
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
                    this.ErrorLabel.Text = Language.messageSubjectExist;
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            FrenchNameTextBox.Focus();
        }
        private bool SubjectExist(string frenchName)
        {
            if (subjectNameTracker == frenchName) return false;
            var item = Program.SubjectList.FirstOrDefault(x => x.FrenchName == frenchName);
            if (item != null) return true;
            return subjectService.GetSubject(frenchName).Result != null;
        }
    }
}
