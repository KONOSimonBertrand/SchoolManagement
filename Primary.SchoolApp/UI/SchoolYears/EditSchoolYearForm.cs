using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;



namespace Primary.SchoolApp.UI
{
    internal class EditSchoolYearForm : SchoolManagement.UI.EditSchoolYearForm
    {
        private readonly ISchoolYearService schoolYearService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private SchoolYear schoolYear;
        private string schoolYearNameTracker;//permet de vérifier si le nom a changé
        public EditSchoolYearForm(ISchoolYearService schoolYearReadService, ILogService logService, ClientApp clientApp)
        {
            InitEvents();
            this.schoolYearService = schoolYearReadService;
            this.logService = logService;
            this.clientApp = clientApp;
            schoolYearNameTracker = string.Empty;
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            NameTextBox.Focus();
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            if (IsValidData())
            {

                if (!SchoolYearExist(NameTextBox.Text))
                {
                    schoolYearNameTracker = NameTextBox.Text;
                    schoolYear.Name = NameTextBox.Text;
                    schoolYear.StartFirstQuarter = StartFirstQuarter.Value;
                    schoolYear.EndFirstQuarter = EndFirstQuarter.Value;
                    schoolYear.StartSecondQuarter = StartSecondQuarter.Value;
                    schoolYear.EndSecondQuarter = EndSecondQuarter.Value;
                    schoolYear.StartThirdQuarter = StartThirdQuarter.Value;
                    schoolYear.EndThirdQuarter = EndThirdQuarter.Value;
                    bool isDone = schoolYearService.UpdateSchoolYear(schoolYear).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Modification des informations de l'année scolaire {schoolYear.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            User = clientApp.UserConnected,
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
                    ErrorLabel.Text = Language.messageSchoolYearExist;
                }
            }
        }

        internal void Init(SchoolYear schoolYear)
        {

            if (schoolYear != null)
            {
                this.schoolYear = schoolYear;
                NameTextBox.Text = schoolYear.Name;
                schoolYearNameTracker = schoolYear.Name;
                if (schoolYear.StartFirstQuarter != null)
                {
                    StartFirstQuarter.Value = schoolYear.StartFirstQuarter.Value;
                }
                else
                {
                    StartFirstQuarter.SetToNullValue();
                }
                if (schoolYear.EndFirstQuarter != null)
                {
                    EndFirstQuarter.Value = schoolYear.EndFirstQuarter.Value;
                }
                else
                {
                    EndFirstQuarter.SetToNullValue();
                }
                if (schoolYear.StartSecondQuarter != null)
                {
                    StartSecondQuarter.Value = schoolYear.StartSecondQuarter.Value;
                }
                else
                {
                    StartSecondQuarter.SetToNullValue();
                }
                if (schoolYear.EndSecondQuarter != null)
                {
                    EndSecondQuarter.Value = schoolYear.EndSecondQuarter.Value;
                }
                else
                {
                    EndSecondQuarter.SetToNullValue();
                }
                if (schoolYear.StartThirdQuarter != null)
                {
                    StartThirdQuarter.Value = schoolYear.StartThirdQuarter.Value;
                }
                else
                {
                    StartThirdQuarter.SetToNullValue();
                }
                if (schoolYear.EndThirdQuarter != null)
                {
                    EndThirdQuarter.Value = schoolYear.EndThirdQuarter.Value;
                }
                else
                {
                    EndThirdQuarter.SetToNullValue();
                }

            }
        }

        private bool SchoolYearExist(string name)
        {
            if (schoolYearNameTracker == name) return false;
            var item = Program.SchoolYearList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return schoolYearService.GetSchoolYear(name).Result != null;
        }
    }
}
