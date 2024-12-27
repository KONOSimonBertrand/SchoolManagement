

using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class EditDisciplineForm:SchoolManagement.UI.EditDisciplineForm
    {
        private readonly IDisciplineService disciplineService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IPrintService printService;
        private Discipline selectedDiscipline;
        public EditDisciplineForm(IDisciplineService disciplineService, ILogService logService, ClientApp clientApp, IPrintService printService)
        {
            this.disciplineService = disciplineService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.printService = printService;
            this.SubjectDropDownList.DataSource = Program.DisciplineSubjectList;
            this.EvaluationDropDownList.DataSource = Program.EvaluationSessionChildList;
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
        }

        internal void Init(Discipline discipline)
        {
            selectedDiscipline = discipline;
            if (selectedDiscipline != null) {
                this.StudentDropDownList.DataSource = new List<Student>() {
                discipline.Student
            };
                var room = Program.StudentRoomList.FirstOrDefault(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.StudentId == selectedDiscipline.StudentId).Room;
                this.ClassTextBox.Text = room.Name;
                this.DurationTextBox.Text=discipline.Duration.ToString();
                this.SubjectDropDownList.SelectedValue = discipline.SubjectId;
                this.ReasonDropDownList.Text = discipline.Reason;
                this.EvaluationDropDownList.SelectedValue=discipline.EvaluationId;
                this.StudentDropDownList.ReadOnly = true;
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var subject = this.SubjectDropDownList.SelectedItem.DataBoundItem as DisciplineSubject;
            var evaluation = this.EvaluationDropDownList.SelectedItem.DataBoundItem as EvaluationSession;
            selectedDiscipline.Date = this.DateTimePicker.Value;
            selectedDiscipline.Subject = subject;
            selectedDiscipline.SubjectId = subject.Id;
            selectedDiscipline.Duration = double.Parse(this.DurationTextBox.Text);
            selectedDiscipline.Reason = this.ReasonDropDownList.Text;
            selectedDiscipline.Evaluation = evaluation;
            selectedDiscipline.EvaluationId = evaluation.Id;
            var isDone=disciplineService.UpdateDiscipline(selectedDiscipline).Result;
            if (isDone)
            {
                //enregistrement du log
                Log logSubscription = new()
                {
                    UserAction = $"Mise à jour de l'objet disciplinaire  {selectedDiscipline.Subject.DefaultName} de l'élève {selectedDiscipline.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                    UserId = clientApp.UserConnected.Id
                };
                logService.CreateLog(logSubscription);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                ErrorLabel.Text = Language.messageAddError;
                ErrorProvider.SetError(this.SubjectDropDownList, Language.messageUpdateError);
                this.SubjectDropDownList.Focus();
            }
        }
    }
}
