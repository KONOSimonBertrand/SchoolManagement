using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Linq;
using System;

namespace Primary.SchoolApp.UI
{
    public partial class EditSubjectForm : SchoolManagement.UI.EditSubjectForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISubjectService subjectService;
        private string subjectNameTracker;
        Subject subject;
        public EditSubjectForm(ISubjectService subjectService, ILogService logService, ClientApp clientApp)
        {
            InitializeComponent();
            this.subjectService = subjectService;
            this.logService = logService;
            this.clientApp = clientApp;
            subjectNameTracker = string.Empty;
            InitEvents();
            this.Text = "MODIFICATION:.MATIERE";
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
            if (subjectNameTracker == frenchName) return false;
            var item = Program.SubjectList.FirstOrDefault(x => x.FrenchName == frenchName);
            if (item != null) return true;
            return subjectService.GetSubject(frenchName).Result != null;
        }
    }
}
