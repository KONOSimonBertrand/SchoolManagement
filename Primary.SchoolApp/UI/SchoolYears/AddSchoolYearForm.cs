using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class AddSchoolYearForm : SchoolManagement.UI.EditSchoolYearForm
    {
        private readonly ISchoolYearService schoolYearService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private SchoolYear schoolYear;
        public AddSchoolYearForm(ISchoolYearService schoolYearReadService, ILogService logService, ClientApp clientApp)
        {
            InitEvents();
            this.schoolYearService = schoolYearReadService;
            this.logService = logService;
            this.clientApp = clientApp;
            ClearData();
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
                    schoolYear ??= new SchoolYear();
                    schoolYear.Name = NameTextBox.Text;
                    schoolYear.StartFirstQuarter = StartFirstQuarter.Value;
                    schoolYear.EndFirstQuarter = EndFirstQuarter.Value;
                    schoolYear.StartSecondQuarter = StartSecondQuarter.Value;
                    schoolYear.EndSecondQuarter = EndSecondQuarter.Value;
                    schoolYear.StartThirdQuarter = StartThirdQuarter.Value;
                    schoolYear.EndThirdQuarter = EndThirdQuarter.Value;
                    bool isDone = schoolYearService.CreateSchoolYear(schoolYear).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout de l'année scolaire {schoolYear.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            User = clientApp.UserConnected,
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {

                        this.ErrorLabel.Text = Language.messageAddError;
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageSchoolYearExist;
                }

            }
        }

        private void ClearData()
        {
            this.NameTextBox.Text = string.Empty;
            this.StartFirstQuarter.SetToNullValue();
            this.EndFirstQuarter.SetToNullValue();
            this.StartSecondQuarter.SetToNullValue();
            this.EndSecondQuarter.SetToNullValue();
            this.StartThirdQuarter.SetToNullValue();
            this.EndThirdQuarter.SetToNullValue();

        }
        private bool SchoolYearExist(string name)
        {
            var item = Program.SchoolYearList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return schoolYearService.GetSchoolYear(name).Result != null;
        }
    }
}
