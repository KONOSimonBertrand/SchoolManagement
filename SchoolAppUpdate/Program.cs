using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Configuration;
namespace SchoolAppUpdate
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static string OldDataBaseConnectionString { get; private set; }
        public static string NewDataBaseConnectionString { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            OldDataBaseConnectionString = ConfigurationManager.ConnectionStrings["old_school_data_base"].ConnectionString;
            NewDataBaseConnectionString = ConfigurationManager.ConnectionStrings["new_school_data_base"].ConnectionString;
            var hostBuilder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddLogging(configure => configure.AddConsole());
                services.AddClientUpdateDependency();
                // Register other services here
            });
            var host = hostBuilder.Build();
            ServiceProvider = host.Services;
            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
            
        }
    }
}