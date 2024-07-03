using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.SchoolGroups;
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Application.Users;
using SchoolManagement.Core.Model;


namespace SchoolManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
        {
            services.AddTransient<ISchoolYearService, SchoolYearService>();
            services.AddTransient<ISchoolGroupService, SchoolGroupService>();
            services.AddTransient<IUserReadService, UserReadService>();
            services.AddSingleton<ClientApp>();
            return services;
        }
    }
}
