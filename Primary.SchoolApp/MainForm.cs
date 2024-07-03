using Primary.SchoolApp.UI;
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Core.Model;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using SchoolManagement.Application.SchoolGroups;

namespace Primary.SchoolApp
{
    public partial class MainForm : SchoolManagement.UI.MainForm
    {
        private bool isLogOut;// si true se deconnecter
        private readonly ISchoolYearService schoolYearService;
        private readonly ISchoolGroupService schoolGroupService;
        public MainForm(ISchoolYearService schoolYearService,ISchoolGroupService schoolGroupService)
        {
            InitializeComponent();
            this.schoolYearService = schoolYearService;
            this.schoolGroupService=schoolGroupService;
            PopulateSchoolYearOnDropDownList();
            InitSettingPage();
            InitMainEvents();
        }
       
   
        private void InitMainEvents()
        {
            AboutButton.Click += AboutButton_Click;
            ChangePasswordMenu.Click += ChangePasswordMenu_Click;
            LogOutMenu.Click += LogOutMenu_Click;
            FormClosing += MainForm_FormClosing;
        }

        #region Events
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLogOut)
            {
                LogOut();
            }
        }

        private void LogOutMenu_Click(object sender, System.EventArgs e)
        {
            LogOut();
        }

        private void ChangePasswordMenu_Click(object sender, System.EventArgs e)
        {
            RadMessageBox.Show("Implementation en cours....");
        }

        private void AboutButton_Click(object sender, System.EventArgs e)
        {
            var form = new AboutAppForm();
            form.ShowDialog();
        }
        #endregion

        #region Methodes
        // se deconnecter du système
        private void LogOut()
        {

            DialogResult dialogResult = RadMessageBox.Show("Voulez-vous vous déconnecter de l'application ?", "Déconnexion de l'application", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                isLogOut = true;
                this.Close();
                Application.OpenForms["LoginForm"].Show();

            }

        }
        //load school year on dropDownList
        private async void PopulateSchoolYearOnDropDownList()
        {
            schoolYearList=await schoolYearService.GetAllSchoolYears();
            HomeSchoolYearDropDownList.DataSource = schoolYearList;
            HomeSchoolYearDropDownList.DisplayMember = "Name";
            HomeSchoolYearDropDownList.ValueMember = "Id";

            CashFlowSchoolYearDropDownList.DataSource = schoolYearList;
            CashFlowSchoolYearDropDownList.DisplayMember = "Name";
            CashFlowSchoolYearDropDownList.ValueMember = "Id";

            TimeTableSchoolYearDropDownList.DataSource = schoolYearList;
            TimeTableSchoolYearDropDownList.DisplayMember = "Name";
            TimeTableSchoolYearDropDownList.ValueMember = "Id";

            DisciplineSchoolYearDropDownList.DataSource = schoolYearList;
            DisciplineSchoolYearDropDownList.DisplayMember = "Name";
           DisciplineSchoolYearDropDownList.ValueMember = "Id";

            StudentNoteSchoolYearDropDownList.DataSource = schoolYearList;
            StudentNoteSchoolYearDropDownList.DisplayMember = "Name";
            StudentNoteSchoolYearDropDownList.ValueMember = "Id";

            ReportSchoolYearDropDownList.DataSource = schoolYearList;
            ReportSchoolYearDropDownList.DisplayMember = "Name";
            ReportSchoolYearDropDownList.ValueMember = "Id";

            EmployeeSchoolYearDropDownList.DataSource = schoolYearList;
            EmployeeSchoolYearDropDownList.DisplayMember = "Name";
            EmployeeSchoolYearDropDownList.ValueMember = "Id";

            if (schoolYearList.Any())
            {
                var openYear = GetOpenSchoolYear();
                if (openYear.Id != 0)
                {
                    HomeSchoolYearDropDownList.SelectedValue = openYear.Id;
                    CashFlowSchoolYearDropDownList.SelectedValue = openYear.Id;
                    TimeTableSchoolYearDropDownList.SelectedValue = openYear.Id;
                    DisciplineSchoolYearDropDownList.SelectedValue = openYear.Id;
                    StudentNoteSchoolYearDropDownList.SelectedValue = openYear.Id;
                    ReportSchoolYearDropDownList.SelectedValue = openYear.Id;
                    EmployeeSchoolYearDropDownList.SelectedValue = openYear.Id;
                }
            }

        }
        //return open year 
        private SchoolYear GetOpenSchoolYear()
        {            
            var openYearList = schoolYearList.Where(y => y.IsClosed == false);
            return openYearList.Any() ? openYearList.FirstOrDefault() : new SchoolYear();
        }
        #endregion

    }
}
