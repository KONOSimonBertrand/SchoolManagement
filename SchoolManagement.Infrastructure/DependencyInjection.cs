using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Infrastructure.DataBase;
namespace SchoolManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services)
        {
            services.AddTransient<Application.SchoolYears.ISchoolYearRepository, DbContextSchoolYearRepository>();
            services.AddTransient<Application.SchoolGroups.ISchoolGroupRepository, DapperSchoolGroupRepository>();
            services.AddTransient<Application.Users.IUserRepository, DbContextUserRepository>();
            services.AddTransient<IDbConnectionFactoty, MySqlConnectionFactory>();
            services.AddDbContext<AppDbContext>();
            return services;
        }
    }
}
