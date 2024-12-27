using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace Primary.SchoolApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static IList<SchoolYear> SchoolYearList;
        public static IList<SchoolGroup> SchoolGroupList;
        public static IList<SchoolClass> SchoolClassList;
        public static IList<SchoolRoom> SchoolRoomList;
        public static IList<CashFlowType> CashFlowTypeList;
        public static IList<CashFlow> CashFlowList;
        public static IList<PaymentMean> PaymentMeanList;
        public static IList<SchoolingCost> SchoolingCostList;
        public static IList<SchoolingCostItem> SchoolingCostItemList;
        public static IList<SubscriptionFee> SubscriptionFeeList;
        public static IList<Subscription> SubscriptionList;
        public static IList<SubjectGroup> SubjectGroupList;
        public static IList<Subject> SubjectList;
        public static IList<ClassSubject> ClassSubjectList;
        public static IList<EvaluationSessionState> EvaluationSessionStateList;
        public static IList<EvaluationSession> EvaluationSessionList;
        public static IList<EvaluationSession> EvaluationSessionParentList;
        public static IList<EvaluationSessionChild> EvaluationSessionChildList;
        public static IList<RatingSystem> RatingSystemList;
        public static IList<Job> JobList;
        public static IList<EmployeeGroup> EmployeeGroupList;
        public static IList<User> UserList;
        public static IList<Employee> EmployeeList;
        public static IList<Module> ModuleList;
        public static IList<Country> CountryList;
        public static IList<EmployeeEnrolling> EmployeeEnrollingList;
        public static IList<StudentEnrollingDTO> StudentEnrollingList;
        public static IList<Student> StudentList;
        public static IList<TuitionPayment> TuitionPaymentList;
        public static IList<TuitionDiscount> TuitionDiscountList;
        public static IList<DisciplineSubject> DisciplineSubjectList;
        public static IList<CashBoxIn> CashBoxInList;
        public static IList<CashBoxOut> CashBoxOutList;
        public static IList<StudentRoom> StudentRoomList;
        //public static IList<StudentNoteDTO> StudentNoteList;
        public static User UserConnected;
        public static IServiceProvider ServiceProvider { get; private set; }
        public static string ConnectionString { get; private set; }
        public static DateTime ScheduleDate { get; internal set; }

        public static SchoolYear CurrentSchoolYear;
        [STAThread]
        static void Main()
        {
          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConnectionString = ConfigurationManager.ConnectionStrings["school_data_base"].ConnectionString;
            
            #region Définition des dépendances
                var hostBuilder = new HostBuilder()
               .ConfigureServices(services =>
               {
                   services.AddApplicationDependency();
                   services.AddClientDependency();
                   services.AddInfrastructureDependency();
               })
               ;
            
            var host = hostBuilder.Build();
            ServiceProvider = host.Services;
            #endregion
            //définition des indépendances 
            var clientName = ConfigurationManager.AppSettings["ClientName"];
            var clientCode = ConfigurationManager.AppSettings["ClientCode"];
            if (AppUtilities.ToHex(clientName) == clientCode) {
               Application.Run(ServiceProvider.GetRequiredService<StartForm>());
            }
            else
            {
                Telerik.WinControls.RadMessageBox.Show("Merci de bien vouloir contacter SuiTtech au +237 679 72 83 44 ou +33 06 01 24 89 20  pour obtenir une licence ");
            }            
        }     
    }
}