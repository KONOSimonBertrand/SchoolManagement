

using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Core.Model;

namespace Primary.SchoolApp.UI
{
    public partial class AddSchoolYearForm :  SchoolManagement.UI.EditSchoolYearForm
    {
        private readonly ISchoolYearService schoolYearService;
        private SchoolYear schoolYear;
        public AddSchoolYearForm(ISchoolYearService schoolYearReadService)
        {
            InitializeComponent();
            InitEvents();
            this.schoolYearService = schoolYearReadService;
            ClearData();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            if(schoolYear == null) schoolYear = new SchoolYear();
            schoolYear.Name = NameTextBox.Text;
            schoolYear.StartFirstQuarter = StartFirstQuarter.Value;
            schoolYear.EndFirstQuarter = EndFirstQuarter.Value;
            schoolYear.StartSecondQuarter = StartSecondQuarter.Value;
            schoolYear.EndSecondQuarter = EndSecondQuarter.Value;
            schoolYear.StartThirdQuarter = StartThirdQuarter.Value;
            schoolYear.EndThirdQuarter = EndThirdQuarter.Value;
            if (IsValidData())
            {
                var isDone = schoolYearService.CreateSchoolYear(schoolYear).Result;
                if (isDone)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {

                    this.ErrorLabel.Text = "Erreur d'enregistrement";
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
    
    }
}
