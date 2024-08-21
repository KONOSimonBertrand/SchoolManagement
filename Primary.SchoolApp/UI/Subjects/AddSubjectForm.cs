

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Linq;
using System;
using SchoolManagement.UI.Localization;

namespace Primary.SchoolApp.UI
{
    internal class AddSubjectForm : SchoolManagement.UI.EditSubjectForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISubjectService subjectService;
        public AddSubjectForm(ISubjectService subjectService, ILogService logService, ClientApp clientApp)
        {
            this.subjectService = subjectService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                Subject subject = new();
                subject.FrenchName = FrenchNameTextBox.Text;
                subject.EnglishName = EnglishhNameTextBox.Text;
                subject.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                if (!SubjectExist(subject.FrenchName))
                {
                    var isDone = subjectService.CreateSubject(subject).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout  matière' {subject.FrenchName}/{subject.EnglishName} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.ErrorLabel.Text = Language.messageSubjectExist;
                    }
                }
                else
                {
                    this.ErrorLabel.Text = "";
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            FrenchNameTextBox.Focus();
        }
        private bool SubjectExist(string frenchName)
        {
            var item = Program.SubjectList.FirstOrDefault(x => x.FrenchName == frenchName);
            if (item != null) return true;
            return subjectService.GetSubject(frenchName).Result != null;
        }
    }
}
