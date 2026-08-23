

using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Infrastructure;
namespace SchoolAppUpdate
{
    internal static class DependencyInjection
    {
        public static IServiceCollection AddClientUpdateDependency(this IServiceCollection services)
        {
            services.AddApplicationDependency();
            services.AddInfrastructureDependency();
            services.AddTransient<MainForm>();
            return services;
        }
    }
}
