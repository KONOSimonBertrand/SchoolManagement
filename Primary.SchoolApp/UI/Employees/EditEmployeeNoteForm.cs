

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Threading;

namespace Primary.SchoolApp.UI
{
    internal class EditEmployeeNoteForm : SchoolManagement.UI.EditEmployeeNoteForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly ClientApp clientApp;
        private EmployeeEnrolling selectedEnrolling;
        private EmployeeNote selectedNote;
        public EditEmployeeNoteForm(ILogService logService, IEmployeeService employeeService, ClientApp clientApp)
        {
            this.logService = logService;
            this.employeeService = employeeService;
            this.clientApp = clientApp;
            InitEvents();
            this.NoteDateTimePicker.Value = DateTime.Now;
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            SubjectDropDownList.ToolTipTextNeeded += SubjectDropDownList_ToolTipTextNeeded;
        }

        private void SubjectDropDownList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            if (SubjectDropDownList.SelectedItem != null)
            {
                if (SubjectDropDownList.SelectedItem.DataBoundItem is Subject subject)
                {
                    SubjectDropDownList.RootElement.ToolTipText = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Version anglaise: " + subject.EnglishName : "French version: " + subject.FrenchName;
                }
            }
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var date = NoteDateTimePicker.Value;
                var subject = SubjectDropDownList.Text;
                if (!RecordExist(date, subject))
                {
                    selectedNote.Title = subject;
                    selectedNote.Date = date;
                        selectedNote.Description = DescriptionTextBox.Text;
       
                    var isDone = employeeService.UpdateNote(selectedNote).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Mise à jour d'une note de l'employé {selectedEnrolling.Employee.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageAddError;
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageRecordExist;
                }
            }
        }

        internal void Init(EmployeeEnrolling enrolling,EmployeeNote note)
        {
            this.selectedEnrolling = enrolling;
            selectedNote= note;
            DescriptionTextBox.Text = note.Description;
            SubjectDropDownList.Text=note.Title;
            NoteDateTimePicker.Value=note.Date;
        }

        private bool RecordExist(DateTime date, string title)
        {
            if (selectedEnrolling.Notes.Where(
                x => x.Date.Date == date.Date && x.Title == title).Count() > 1)
            {
                return true;
            }
            return false;
        }
    }
}
