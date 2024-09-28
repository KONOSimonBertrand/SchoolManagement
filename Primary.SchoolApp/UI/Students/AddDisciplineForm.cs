
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class AddDisciplineForm : SchoolManagement.UI.EditDisciplineForm
    {
        private readonly IDisciplineService disciplineService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
       public AddDisciplineForm(IDisciplineService disciplineService, ILogService logService, ClientApp clientApp)
        {
            this.disciplineService = disciplineService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.SubjectDropDownList.DataSource=Program.DisciplineSubjectList;
            this.EvaluationDropDownList.DataSource=Program.EvaluationSessionChildList;
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
        }
        internal void Init(StudentEnrolling enrolling)
        {
            enrolling.SchoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == enrolling.SchoolYearId);
            this.selectedEnrolling = enrolling;
            this.StudentDropDownList.DataSource = new List<Student>() {
                enrolling.Student
            };
            this.ClassTextBox.Text=enrolling.SchoolClass.Name;
            this.StudentDropDownList.ReadOnly = true;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var subject = this.SubjectDropDownList.SelectedItem.DataBoundItem as DisciplineSubject;
                var evaluation = this.EvaluationDropDownList.SelectedItem.DataBoundItem as EvaluationSession;
                if (!RecordExist(selectedEnrolling.Id, subject.Id, this.DateTimePicker.Value))
                {
                    Discipline discipline = new()
                    {
                        Date = this.DateTimePicker.Value,
                        Subject = subject,
                        SubjectId = subject.Id,
                        Duration = double.Parse(this.DurationTextBox.Text),
                        Reason= this.ReasonDropDownList.Text,
                        Evaluation = evaluation,
                        EvaluationId = evaluation.Id,
                        Enrolling = selectedEnrolling,
                        EnrollingId = selectedEnrolling.Id,
                    };
                    //add discipline
                    var isDone = disciplineService.CreateDiscipline(discipline).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log log = new()
                        {
                            UserAction = $"Ajout d'un objet disciplinaire  {discipline.Subject.DefaultName} de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageAddError;
                        ErrorProvider.SetError(this.SubjectDropDownList, Language.messageAddError);
                        this.SubjectDropDownList.Focus();
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageRecordExist;
                    ErrorProvider.SetError(this.SubjectDropDownList, Language.messageRecordExist);
                    this.SubjectDropDownList.Focus();
                }
            }
        }
        private bool RecordExist(int enrollingId, int subjectId, DateTime date)
        {
            return disciplineService.GetDiscipline(enrollingId, subjectId, date).Result != null;
        }
    }
}
