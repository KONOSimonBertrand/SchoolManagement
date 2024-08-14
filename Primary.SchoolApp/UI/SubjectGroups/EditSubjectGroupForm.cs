

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Linq;
using System;
using SchoolManagement.UI.Localization;

namespace Primary.SchoolApp.UI
{
    internal class EditSubjectGroupForm : SchoolManagement.UI.EditSubjectGroupForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISubjectGroupService subjectGroupService;
        private string subjectGroupNameTracker;
        SubjectGroup subjectGroup;
        public EditSubjectGroupForm(ISubjectGroupService subjectGroupService, ILogService logService, ClientApp clientApp)
        {
            this.subjectGroupService = subjectGroupService;
            this.logService = logService;
            this.clientApp = clientApp;
            subjectGroupNameTracker = string.Empty;
            InitEvents();
            this.Text = Language.titleGroupUpdate.ToUpper();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }
        internal void Init(SubjectGroup subjectGroup)
        {
            this.subjectGroup = subjectGroup;
            FrenchNameTextBox.Text = subjectGroup.FrenchName;
            EnglishhNameTextBox.Text = subjectGroup.EnglishName;
            SequenceSpinEditor.Value = subjectGroup.Sequence;
            subjectGroupNameTracker = subjectGroup.FrenchName;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {

                if (!SubjectGroupExist(FrenchNameTextBox.Text))
                {
                    subjectGroup.FrenchName = FrenchNameTextBox.Text;
                    subjectGroup.EnglishName = EnglishhNameTextBox.Text;
                    subjectGroup.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    var isDone = subjectGroupService.UpdateSubjectGroup(subjectGroup).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout  d'un groupe de matières  {subjectGroup.FrenchName}/{subjectGroup.EnglishName} ",
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
                    this.ErrorLabel.Text = Language.messageGroupExist;
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            FrenchNameTextBox.Focus();
        }
        private bool SubjectGroupExist(string frenchName)
        {
            if (subjectGroupNameTracker == frenchName) return false;
            var item = Program.SubjectGroupList.FirstOrDefault(x => x.FrenchName == frenchName);
            if (item != null) return true;
            return subjectGroupService.GetSubjectGroup(frenchName).Result != null;
        }
    }
}
