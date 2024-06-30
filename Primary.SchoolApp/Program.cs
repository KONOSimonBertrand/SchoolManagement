using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolManagement.Application;
using SchoolManagement.Infrastructure;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Primary.SchoolApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static IServiceProvider ServiceProvider { get; private set; }
        public static  string ConnectionString {  get; private set; }
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

            Application.Run(ServiceProvider.GetRequiredService<LoginForm>());
            //Application.Run(new MainForm());
        }


       
    }
}