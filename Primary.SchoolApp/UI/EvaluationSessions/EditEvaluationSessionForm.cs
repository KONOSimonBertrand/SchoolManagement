using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class EditEvaluationSessionForm : SchoolManagement.UI.EditEvaluationSessionForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IEvaluationSessionService evaluationTypeService;
        private string evaluationTypeNameTracker;
        private EvaluationSession evaluationType;
        public EditEvaluationSessionForm(IEvaluationSessionService evaluationTypeService, ILogService logService, ClientApp clientApp)
        {
            this.evaluationTypeService = evaluationTypeService;
            this.logService = logService;
            this.clientApp = clientApp;
            evaluationTypeNameTracker = string.Empty;
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
        internal void InitStartup(EvaluationSession session)
        {
            this.evaluationType = session;
            FrenchNameTextBox.Text = session.FrenchName;
            evaluationTypeNameTracker = session.FrenchName;
            EnglishNameTextBox.Text = session.EnglishName;
            SequenceSpinEditor.Value = session.Sequence;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (EvaluationTypeExist(FrenchNameTextBox.Text) == false)
                {
                    evaluationType.FrenchName = FrenchNameTextBox.Text;
                    evaluationType.EnglishName = EnglishNameTextBox.Text;
                    evaluationType.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    var isDone = evaluationTypeService.UpdateEvaluationSessionAsync(evaluationType).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Mise à jour du  type d'évaluation {evaluationType.FrenchName}/{evaluationType.EnglishName} ",
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
                    this.ErrorLabel.Text = Language.messageEvaluationExist;
                }

            }
        }
        private bool EvaluationTypeExist(string frenchName)
        {
            if (evaluationTypeNameTracker == frenchName) return false;
            var item = Program.EvaluationSessionList.FirstOrDefault(x => x.FrenchName == frenchName);
            if (item != null) return true;
            return evaluationTypeService.GetEvaluationSessionAsync(frenchName).Result != null;
        }
    }
}
