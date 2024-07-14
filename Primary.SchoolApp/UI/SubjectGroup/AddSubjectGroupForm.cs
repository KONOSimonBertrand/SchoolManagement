

using SchoolManagement.Application.Logs;
using SchoolManagement.Application.SubjectGroups;
using SchoolManagement.Core.Model;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    public partial class AddSubjectGroupForm : SchoolManagement.UI.EditSubjectGroupForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISubjectGroupService subjectGroupService;
        public AddSubjectGroupForm(ISubjectGroupService subjectGroupService, ILogService logService, ClientApp clientApp)
        {
            InitializeComponent();
            this.subjectGroupService = subjectGroupService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
            this.Text = "AJOUT:.GROUPE DE MATIERES";
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
                SubjectGroup subjectGroup = new();
                subjectGroup.FrenchName=FrenchNameTextBox.Text;
                subjectGroup.EnglishName = EnglishhNameTextBox.Text;
                subjectGroup.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                if (!SubjectGroupExist(subjectGroup.FrenchName))
                {
                    var isDone = subjectGroupService.CreateSubjectGroup(subjectGroup).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout  d'un groupe de matières' {subjectGroup.FrenchName}/{subjectGroup.EnglishName} ",
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
                    this.ErrorLabel.Text = "Ce groupe exist déjà";
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(854, 355);
            FrenchNameTextBox.Focus() ;
        }
        private bool SubjectGroupExist(string frenchName)
        {
            var item = Program.SubjectGroupList.FirstOrDefault(x => x.FrenchName==frenchName);
            if (item != null) return true;
            return subjectGroupService.GetSubjectGroup(frenchName).Result != null;
        }
    }
}
