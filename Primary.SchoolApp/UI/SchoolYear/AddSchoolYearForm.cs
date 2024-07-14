

using SchoolManagement.Application.Logs;
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Core.Model;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    public partial class AddSchoolYearForm :  SchoolManagement.UI.EditSchoolYearForm
    {
        private readonly ISchoolYearService schoolYearService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private SchoolYear schoolYear;
        public AddSchoolYearForm(ISchoolYearService schoolYearReadService, ILogService logService,ClientApp clientApp)
        {
            InitializeComponent();
            InitEvents();
            this.schoolYearService = schoolYearReadService;
            this.logService = logService;
            this.clientApp = clientApp;
            ClearData();
            this.Text = "AJOUT:.ANNEE SCOLAIRE";
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(549, 453);
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

                        this.ErrorLabel.Text = "Erreur d'enregistrement";
                    }
                }
                else
                {
                    ErrorLabel.Text = "Une année scolaire portant le même nom existe déjà!";
                }

            }
        }
    
        private void ClearData()
        {
            this.NameTextBox.Text=string.Empty;
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
