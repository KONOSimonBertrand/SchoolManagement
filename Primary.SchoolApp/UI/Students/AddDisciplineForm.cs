
using Primary.SchoolApp.Utilities;
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
        private Student selectedStudent;
        private int selectedInitMethod = 0;
        public AddDisciplineForm(IDisciplineService disciplineService, ILogService logService, ClientApp clientApp)
        {
            this.disciplineService = disciplineService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.SubjectDropDownList.DataSource=Program.DisciplineSubjectList;
            this.EvaluationDropDownList.DataSource=Program.EvaluationSessionChildList;
            DateTimePicker.Value = DateTime.Now;
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            StudentDropDownList.SelectedIndexChanged += StudentDropDownList_SelectedIndexChanged;
        }

        private void StudentDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (this.StudentDropDownList.SelectedItem != null)
            {
                if (this.StudentDropDownList.SelectedItem.DataBoundItem is Student student)
                {
                    if (selectedInitMethod == 1)// if Init(List<Student>)
                    {
                        selectedStudent = student;
                        var room = Program.StudentRoomList.FirstOrDefault(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.StudentId == selectedStudent.Id).Room;
                        this.ClassTextBox.Text = room.Name;
                    }
                }
            }
               
        }

        internal void Init(Student student)
        {
            this.selectedStudent = student;
            this.StudentDropDownList.DataSource = new List<Student>() {
                student
            };
            var room = Program.StudentRoomList.FirstOrDefault(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.StudentId == student.Id).Room;
            this.ClassTextBox.Text = room.Name;
            this.StudentDropDownList.ReadOnly = true;
        }
        internal void Init(List<Student> students)
        {
            selectedInitMethod = 1;
            this.StudentDropDownList.DataSource = students;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var subject = this.SubjectDropDownList.SelectedItem.DataBoundItem as DisciplineSubject;
                var evaluation = this.EvaluationDropDownList.SelectedItem.DataBoundItem as EvaluationSession;
                if (!RecordExist(selectedStudent.Id, subject.Id, this.DateTimePicker.Value))
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
                        Student= selectedStudent,
                        StudentId = selectedStudent.Id,
                        SchoolYear=Program.CurrentSchoolYear,
                        SchoolYearId=Program.CurrentSchoolYear.Id,
                    };
                    
                    //add discipline
                    var isDone = disciplineService.CreateDiscipline(discipline).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log log = new()
                        {
                            UserAction = $"Ajout d'un objet disciplinaire  {discipline.Subject.DefaultName} de l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
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
        private bool RecordExist(int studentId, int subjectId, DateTime date)
        {
            return disciplineService.GetDiscipline(studentId, subjectId, date).Result != null;
        }
    }
}
