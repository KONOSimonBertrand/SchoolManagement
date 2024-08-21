using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Primary.SchoolApp.DTO;
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
        public static IList<PaymentMean> PaymentMeanList;
        public static IList<SchoolingCost> SchoolingCostList;
        public static IList<SubscriptionFee> SubscriptionFeeList;
        public static IList<SubjectGroup> SubjectGroupList;
        public static IList<Subject> SubjectList;
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
        public static User UserConnected;
        public static IServiceProvider ServiceProvider { get; private set; }
        public static string ConnectionString { get; private set; }
        public static DateTime ScheduleDate { get; internal set; }

        public static SchoolYear CurrentSchoolYear;
        [STAThread]
        static void Main()
        {
          
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
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

            Application.Run(ServiceProvider.GetRequiredService<LoginForm>());
            //Application.Run(new MainForm());
        }



    }
}