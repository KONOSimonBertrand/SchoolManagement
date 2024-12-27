using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Services;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    public partial class StartForm :  ShapedForm
    {
         RadWaitingBar waitingBar;
        private readonly ClientApp clientApp;
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
        private readonly IRatingSystemService ratingSystemService;
        private readonly IJobService jobService;
        private readonly IEmployeeGroupService employeeGroupService;
        private readonly IUserService userService;
        private readonly IEmployeeService employeeService;
        private readonly IModuleService moduleService;
        private readonly ICountryService countryService;
        private readonly IDisciplineService disciplineService;
        private readonly ICashFlowService cashFlowService;
        private readonly IStudentEnrollingService studentEnrollingService;
        private readonly LocalEnrollingService localEnrollingService;
        private readonly ISubscriptionService subscriptionService;
        public StartForm(ClientApp clientApp, ISchoolYearService schoolYearService, IDisciplineService disciplineService, ICountryService countryService,
            IModuleService moduleService, IEmployeeService employeeService, IUserService userService, IEmployeeGroupService employeeGroupService,
            IRatingSystemService ratingSystemService, IEvaluationSessionService evaluationSessionService, ISubjectService subjectService,
            ISubjectGroupService subjectGroupService, ISubscriptionFeeService subscriptionFeeService, ISchoolingCostService schoolingCostService,
            IPaymentMeanService paymentMeanService, ICashFlowTypeService cashFlowTypeService, ISchoolRoomService schoolRoomService,
            ISchoolClassService schoolClassService, ISchoolGroupService schoolGroupService, IJobService jobService, ICashFlowService cashFlowService,
            IStudentEnrollingService studentEnrollingService,ISubscriptionService subscriptionService
            )
        {
            InitializeComponent();
            this.BackgroundImage = Resources.Background_load;
            this.clientApp= clientApp;
            this.schoolYearService = schoolYearService;
            this.disciplineService = disciplineService;
            this.countryService = countryService;
            this.moduleService = moduleService;
            this.employeeService = employeeService;
            this.userService = userService;
            this.employeeGroupService = employeeGroupService;
            this.ratingSystemService = ratingSystemService;
            this.evaluationSessionService = evaluationSessionService;
            this.subjectService = subjectService;
            this.subjectGroupService = subjectGroupService;
            this.subscriptionFeeService = subscriptionFeeService;
            this.schoolingCostService = schoolingCostService;
            this.paymentMeanService = paymentMeanService;
            this.cashFlowTypeService = cashFlowTypeService;
            this.schoolRoomService = schoolRoomService;
            this.schoolClassService = schoolClassService;
            this.schoolGroupService = schoolGroupService;
            this.jobService = jobService;
            this.cashFlowService = cashFlowService;
            this.studentEnrollingService= studentEnrollingService;
            this.subscriptionService = subscriptionService;
            localEnrollingService = new LocalEnrollingService();
            InitializeWaitingBar();
            StartWaiting();
            this.Icon = Resources.icon_pink;
            clientApp.ConnectionString = Program.ConnectionString;
            //create thread for loading initial data
            this.Shown += (o, s) =>
            {
                Thread thread = new(InitProgram);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            };
          
        }

        //loading initial data
        private void InitProgram()
        {
            LoadInitialData();
            this.Invoke(new Action(this.Close));
            //load login form
            System.Windows.Forms.Application.Run(Program.ServiceProvider.GetRequiredService<LoginForm>());
           
        }
        // extraction des données de base : année scolaire,classe, salle de classe, ....
        private async void LoadInitialData()
        {
            var getSchoolYearListTask = schoolYearService.GetSchoolYearList();
            var getSchoolGroupListTask = schoolGroupService.GetSchoolGroupList();
            var getClassListTask = schoolClassService.GetSchoolClassList();
            var getClassSubjectListTask=schoolClassService.GetClassSubjectList();
            var getRoomListTask = schoolRoomService.GetSchoolRoomList();
            var getCashflowTypeListTask = cashFlowTypeService.GetCashFlowTypeList();
            var getPaymenMeantListTask = paymentMeanService.GetPaymentMeanList();
            var getSchoolingCostListTask = schoolingCostService.GetSchoolingCostList();
            var getSubscripFeetionListTask = subscriptionFeeService.GetSubscriptionFeeList();
            var getSubjectGroupListTask = subjectGroupService.GetSubjectGroupList();
            var getSubjectListTask = subjectService.GetSubjectList();
            var getEvaluationSessionListTask = evaluationSessionService.GetEvaluationSessionListAsync();
            var getRatingSystemListTask = ratingSystemService.GetRatingSystemList();
            var getJobListTask = jobService.GetJobList();
            var getEmployeeGroupListTask = employeeGroupService.GetEmployeeGroupList();
            var getModuleListTask = moduleService.GetModuleList();
            var getUserListTask = userService.GetUserList();
            var getEmployeeListTask = employeeService.GetEmployeeList();
            var getCountryListTask = countryService.GetCountryList();
            var getDisciplineSubjectListTask = disciplineService.GetDisciplineSubjectList();
           
            Program.SchoolYearList = await getSchoolYearListTask;
            Program.SchoolGroupList = await getSchoolGroupListTask;
            Program.SchoolClassList = await getClassListTask;
            Program.ClassSubjectList= await getClassSubjectListTask;
            Program.SchoolRoomList = await getRoomListTask;
            Program.CashFlowTypeList = await getCashflowTypeListTask;
            Program.PaymentMeanList = await getPaymenMeantListTask;
            Program.SchoolingCostList = await getSchoolingCostListTask;
            Program.SubscriptionFeeList = await getSubscripFeetionListTask;
            Program.SubjectGroupList = await getSubjectGroupListTask;
            Program.SubjectList = await getSubjectListTask;
            Program.EvaluationSessionList = await getEvaluationSessionListTask;
            Program.RatingSystemList = await getRatingSystemListTask;
            Program.JobList = await getJobListTask;
            Program.EmployeeGroupList = await getEmployeeGroupListTask;
            Program.UserList = await getUserListTask;
            Program.EmployeeList = await getEmployeeListTask;
            Program.ModuleList = await getModuleListTask;
            Program.CountryList = await getCountryListTask;
            Program.DisciplineSubjectList = await getDisciplineSubjectListTask;
            LoadDataForDefaultSchoolYear();
        }
        // chargement des données pour l'année en cours
        private async void LoadDataForDefaultSchoolYear()
        {
            var schoolYear = Program.SchoolYearList.FirstOrDefault();
            Program.CurrentSchoolYear = schoolYear;
            if (schoolYear != null)
            {
                //lancement des tâches d'extraction des données
                var getPaymentListTask = cashFlowService.GetTuitionPaymentBySchoolYearList(schoolYear.Id);
                var getEnrollingListTask = studentEnrollingService.GetStudentEnrollingListAsync(schoolYear.Id);
                var getDiscountListTask = cashFlowService.GetTuitionDiscountBySchoolYearList(schoolYear.Id);
                var getSchoolingCostItemTask = schoolingCostService.GetSchoolingCostItemsBySchoolYear(schoolYear.Id);
                var getSubscriptionTask = subscriptionService.GetSubscriptionLisAsync(schoolYear.Id);
                var getCashFlowTask = cashFlowService.GetCashFlowList(schoolYear.Id);
                var getCashBoxInTask=cashFlowService.GetCashBoxInList(schoolYear.Id);
                var getCashBoxOutTask = cashFlowService.GetCashBoxOutList(schoolYear.Id);
                var getStudentRoomTask=studentEnrollingService.GetStudentRoomListAsync(schoolYear.Id);
                var getEvaluationStateTask=evaluationSessionService.GetEvaluationSessionStateListBySchoolYearAsync(schoolYear.Id);
                
                //on s'assure que toutes soient terminées
                await System.Threading.Tasks.Task.WhenAll(getPaymentListTask, getEnrollingListTask, getDiscountListTask);
                //chargement des données dans les listes principales
                Program.TuitionDiscountList = await getDiscountListTask;
                Program.TuitionPaymentList = await getPaymentListTask;
                Program.SchoolingCostItemList = await getSchoolingCostItemTask;
                var enrollingList = await getEnrollingListTask;
                Program.SubscriptionList=await getSubscriptionTask;
                Program.CashFlowList = await getCashFlowTask;
                Program.StudentRoomList = await getStudentRoomTask;
                //Création de la liste des inscriptions à afficher
                Program.StudentEnrollingList = new List<StudentEnrollingDTO>();
                foreach (var enrolling in enrollingList)
                {
                    enrolling.SchoolClass.Group = Program.SchoolClassList.Where(x => x.Id == enrolling.ClassId).Select(x => x.Group).FirstOrDefault();
                    //convertion du l'inscription extraite à l'inscription à afficher
                    var enrollingDTO = enrolling.AsStudentEnrollingDTO();
                    //extraction de la liste des frais exigibles
                    var feeIdList = Program.SchoolingCostList.Where(x => x.SchoolYearId == schoolYear.Id && x.IsPayable == true && x.SchoolClassId == enrolling.ClassId).Select(x => x.CashFlowTypeId).ToList();
                    //extraction des réductions et des versements de l'élève
                    enrollingDTO.PaymentList = Program.TuitionPaymentList.Where(x => x.EnrollingId == enrolling.Id).ToList();
                    enrollingDTO.PaymentPayableList = Program.TuitionPaymentList.Where(x => x.EnrollingId == enrolling.Id && feeIdList.Contains(x.CashFlowTypeId)).ToList();
                    enrollingDTO.DiscountList = Program.TuitionDiscountList.Where(x => x.EnrollingId == enrolling.Id && feeIdList.Contains(x.CashFlowTypeId)).ToList();
                    //extraction de la somme des frais exigibles
                    var amountFee = Program.SchoolingCostList.Where(x => x.SchoolYearId == schoolYear.Id && x.IsPayable == true && x.SchoolClassId == enrolling.ClassId).Sum(x => x.Amount);
                    //calcul des impayés de l'élève
                    enrollingDTO.Balance = amountFee - (enrollingDTO.DiscountList.Sum(x => x.Amount) + enrollingDTO.PaymentPayableList.Sum(x => x.Amount));
                    //récupération de l'état des insolvabilités
                    foreach (int feeId in feeIdList)
                    {
                        InsolvencyState state = new()
                        {
                            Id = feeId,
                            Amount = localEnrollingService.GetInsolvencyAmount(enrollingDTO, feeId, schoolYear),
                        };
                        state.Value = state.Amount > 0;
                        enrollingDTO.InsolvencyStateList.Add(state);
                    }

                    // Ajout de l'inscription dans la liste à afficher
                    Program.StudentEnrollingList.Add(enrollingDTO);
                }
                Program.CashBoxInList = await getCashBoxInTask;
                Program.CashBoxOutList = await getCashBoxOutTask;
                Program.EvaluationSessionStateList = await getEvaluationStateTask;


            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            StartWaiting();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            StopWaiting();
        }
        void InitializeWaitingBar()
        {
            waitingBar = new() {
                Size=new Size(300, 8),
                Visible = false
            };
            this.Controls.Add(waitingBar);

            waitingBar.WaitingBarElement.WaitingIndicators[0].GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            waitingBar.WaitingBarElement.WaitingIndicators[0].BackColor = Color.FromArgb(217, 71, 0);
            waitingBar.WaitingBarElement.WaitingIndicators[1].GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            waitingBar.WaitingBarElement.WaitingIndicators[1].BackColor = Color.FromArgb(217, 71, 0);

            waitingBar.WaitingBarElement.BorderWidth = 0;
            waitingBar.WaitingBarElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            waitingBar.WaitingBarElement.BackColor = Color.White;
            waitingBar.BackColor = Color.White;

            waitingBar.WaitingSpeed = 70;
        }
        public void StartWaiting()
        {
            waitingBar.Location = new Point((this.Width - waitingBar.Width) / 2, (this.Height - waitingBar.Height) / 2);
            waitingBar.Visible = true;
            waitingBar.BringToFront();
            waitingBar.StartWaiting();
           
        }
        public void StopWaiting()
        {

            waitingBar.StopWaiting();
            waitingBar.Visible = false;

        }
    }
}
