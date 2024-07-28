﻿using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    public partial class EditEvaluationSessionForm : SchoolManagement.UI.EditEvaluationSessionForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IEvaluationSessionService evaluationTypeService;
        private string evaluationTypeNameTracker;
        private EvaluationSession evaluationType;
        public EditEvaluationSessionForm(IEvaluationSessionService evaluationTypeService, ILogService logService, ClientApp clientApp)
        {
            InitializeComponent();
            this.evaluationTypeService = evaluationTypeService;
            this.logService = logService;
            this.clientApp = clientApp;
            evaluationTypeNameTracker = string.Empty;
            InitEvents();
            this.Text = "MODIFICATION:.SESSION EVALUATION";
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(730, 275);
            FrenchNameTextBox.Focus();
        }
        internal void Init(EvaluationSession evaluationType)
        {
            this.evaluationType = evaluationType;
            FrenchNameTextBox.Text = evaluationType.FrenchName;
            evaluationTypeNameTracker = evaluationType.FrenchName;
            EnglishNameTextBox.Text = evaluationType.EnglishName;
            CodeTextBox.Text = evaluationType.Code;
            SequenceSpinEditor.Value = evaluationType.Sequence;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (EvaluationTypeExist(FrenchNameTextBox.Text) == false)
                {
                    evaluationType.Code = CodeTextBox.Text;
                    evaluationType.FrenchName = FrenchNameTextBox.Text;
                    evaluationType.EnglishName = EnglishNameTextBox.Text;
                    evaluationType.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    var isDone = evaluationTypeService.UpdateEvaluationSession(evaluationType).Result;
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
                        this.ErrorLabel.Text = "Erreur d'enregistrement";
                    }
                }
                else
                {
                    this.ErrorLabel.Text = "Cette matière existe déjà";
                }

            }
        }
        private bool EvaluationTypeExist(string frenchName)
        {
            if (evaluationTypeNameTracker == frenchName) return false;
            var item = Program.EvaluationSessionList.FirstOrDefault(x => x.FrenchName == frenchName);
            if (item != null) return true;
            return evaluationTypeService.GetEvaluationSession(frenchName).Result != null;
        }
    }
}