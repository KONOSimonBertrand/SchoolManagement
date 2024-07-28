using Primary.SchoolApp.UI;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
namespace Primary.SchoolApp
{
    public partial class MainForm : SchoolManagement.UI.MainForm
    {
        private bool isLogOut;// si true se deconnecter
        private readonly ISchoolYearService schoolYearService;
        private readonly ISchoolGroupService schoolGroupService;
        private readonly ISchoolClassService schoolClassService;
        private readonly ISchoolRoomService schoolRoomService;
        private readonly ICashFlowTypeService cashFlowTypeService;
        private readonly IPaymentMeanService paymentMeanService;
        private readonly ISchoolingCostService schoolingCostService;
        private readonly ISubscriptionFeeService subscriptionFeeService;
        private readonly ISubjectGroupService subjectGroupService;
        private readonly ISubjectService subjectService;
        private readonly IEvaluationSessionService evaluationSessionService;
        private readonly ClientApp clientApp;
        private readonly ILogService logService;
        private readonly IRatingSystemService ratingSystemService;
        private readonly IJobService jobService;
        private readonly IEmployeeGroupService employeeGroupService;
        private readonly IUserService userService;
        private readonly IEmployeeService employeeService;
        private readonly IModuleService moduleService;
        private readonly ICountryService countryService;
        public MainForm(ISchoolYearService schoolYearService,ISchoolGroupService schoolGroupService,
            ISchoolClassService schoolClassService, ISchoolRoomService schoolRoomService, ICashFlowTypeService cashFlowTypeService
            ,IPaymentMeanService paymentMeanService, ISchoolingCostService schoolingCostService, ISubscriptionFeeService subscriptionFeeService
            , ISubjectGroupService subjectGroupService, ISubjectService subjectService, IEvaluationSessionService evaluationSessionService, 
            ClientApp clientApp, ILogService logService, IRatingSystemService ratingSystemService,IJobService jobService,IEmployeeGroupService employeeGroupService,
            IUserService userService, IEmployeeService employeeService,IModuleService moduleService, ICountryService countryService
            ) 
        {
            InitializeComponent();
            this.schoolYearService = schoolYearService;
            this.schoolGroupService=schoolGroupService;
            this.schoolClassService = schoolClassService;
            this.schoolRoomService = schoolRoomService;
            this.cashFlowTypeService = cashFlowTypeService;
            this.paymentMeanService = paymentMeanService;
            this.schoolingCostService = schoolingCostService;
            this.subscriptionFeeService = subscriptionFeeService;
            this.subjectGroupService = subjectGroupService;
            this.subjectService = subjectService;
            this.evaluationSessionService = evaluationSessionService;
            this.ratingSystemService = ratingSystemService;
            this.jobService = jobService;
            this.clientApp = clientApp;
            this.logService = logService;
            this.employeeGroupService = employeeGroupService;
            this.userService = userService;
            this.employeeService = employeeService;
            this.moduleService = moduleService;
            this.countryService = countryService;
            LoadBasicData();
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
        private void PopulateSchoolYearOnDropDownList()
        {
            HomeSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            HomeSchoolYearDropDownList.DisplayMember = "Name";
            HomeSchoolYearDropDownList.ValueMember = "Id";

            CashFlowSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            CashFlowSchoolYearDropDownList.DisplayMember = "Name";
            CashFlowSchoolYearDropDownList.ValueMember = "Id";

            TimeTableSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            TimeTableSchoolYearDropDownList.DisplayMember = "Name";
            TimeTableSchoolYearDropDownList.ValueMember = "Id";

            DisciplineSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            DisciplineSchoolYearDropDownList.DisplayMember = "Name";
           DisciplineSchoolYearDropDownList.ValueMember = "Id";

            StudentNoteSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            StudentNoteSchoolYearDropDownList.DisplayMember = "Name";
            StudentNoteSchoolYearDropDownList.ValueMember = "Id";

            ReportSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            ReportSchoolYearDropDownList.DisplayMember = "Name";
            ReportSchoolYearDropDownList.ValueMember = "Id";

            EmployeeSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            EmployeeSchoolYearDropDownList.DisplayMember = "Name";
            EmployeeSchoolYearDropDownList.ValueMember = "Id";

            if (Program.SchoolYearList.Any())
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
            var openYearList = Program.SchoolYearList.Where(y => y.IsClosed == false);
            return openYearList.Any() ? openYearList.FirstOrDefault() : new SchoolYear();
        }
        #endregion

    }
}
