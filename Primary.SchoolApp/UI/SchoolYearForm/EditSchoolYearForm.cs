
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Core.Model;



namespace Primary.SchoolApp.UI
{
    public partial class EditSchoolYearForm : SchoolManagement.UI.EditSchoolYearForm
    {
        private readonly ISchoolYearService schoolYearService;
        private SchoolYear schoolYear;
        public EditSchoolYearForm( ISchoolYearService schoolYearReadService)
        {
            InitializeComponent();
            InitEvents();
            this.schoolYearService = schoolYearReadService;

        }
        private void InitEvents() {
            SaveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {

            schoolYear.Name=NameTextBox.Text;
            schoolYear.StartFirstQuarter = StartFirstQuarter.Value;
            schoolYear.EndFirstQuarter = EndFirstQuarter.Value; 
            schoolYear.StartSecondQuarter = StartSecondQuarter.Value;
            schoolYear.EndSecondQuarter = EndSecondQuarter.Value;
            schoolYear.StartThirdQuarter = StartThirdQuarter.Value;
            schoolYear.EndThirdQuarter = EndThirdQuarter.Value;
            if (IsValidData()) {
                var isDone= schoolYearService.UpdateSchoolYear(schoolYear).Result;
                if (isDone) {
                    this.DialogResult=System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {                   
                   this.ErrorLabel.Text = "Erreur d'enregistrement";
                }
                
            }
        }

        internal void Init(SchoolYear schoolYear) {
            if (schoolYear != null) { 
                this.schoolYear=schoolYear;
                NameTextBox.Text=schoolYear.Name;
                if (schoolYear.StartFirstQuarter != null) {
                    StartFirstQuarter.Value = schoolYear.StartFirstQuarter.Value;
                }
                else
                {
                    StartFirstQuarter.SetToNullValue();
                }
                if (schoolYear.EndFirstQuarter != null) {
                    EndFirstQuarter.Value = schoolYear.EndFirstQuarter.Value;
                }
                else
                {
                    EndFirstQuarter.SetToNullValue();
                }
                if(schoolYear.StartSecondQuarter != null) { 
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
                if (schoolYear.StartThirdQuarter != null) {
                    StartThirdQuarter.Value = schoolYear.StartThirdQuarter.Value; 
                }
                else
                {
                    StartThirdQuarter.SetToNullValue();
                }
                if(schoolYear.EndThirdQuarter != null) { 
                    EndThirdQuarter.Value = schoolYear.EndThirdQuarter.Value; 
                }
                else
                {
                    EndThirdQuarter.SetToNullValue();
                }
               
            }
        }
    }
}
