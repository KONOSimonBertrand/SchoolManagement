using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Application.Users;
using SchoolManagement.Infrastructure.DataBase;
namespace SchoolManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services)
        {
            services.AddTransient<ISchoolYearRepository,DbContextSchoolYearRepository>();
            services.AddTransient<IUserRepository, DbContextUserRepository>();
            services.AddTransient<IDbConnectionFactoty, MySqlConnectionFactory>();
            services.AddDbContext<AppDbContext>();
            return services;
        }
    }
}
