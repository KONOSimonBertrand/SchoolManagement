using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.UI;

namespace Primary.SchoolApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClientDependency(this IServiceCollection services)
        {
            services.AddTransient<MainForm>();
            services.AddTransient<LoginForm>();
            services.AddTransient<EditSchoolYearForm>();
            return services;
        }
    }
}
