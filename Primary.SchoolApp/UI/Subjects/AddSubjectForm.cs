

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Linq;
using System;

namespace Primary.SchoolApp.UI
{
    public partial class AddSubjectForm :  SchoolManagement.UI.EditSubjectForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISubjectService subjectService;
        public AddSubjectForm(ISubjectService subjectService, ILogService logService, ClientApp clientApp)
        {
            InitializeComponent();
            this.subjectService = subjectService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
            this.Text = "AJOUT:.MATIERE";
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
                        this.ErrorLabel.Text = "Erreur d'enregistrement";
                    }
                }
                else
                {
                    this.ErrorLabel.Text = "Cette matière exist déjà";
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(854, 355);
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
