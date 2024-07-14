using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SchoolManagement.Infrastructure.DataBase;
namespace SchoolManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services)
        {
            services.AddTransient<Application.SchoolYears.ISchoolYearRepository, DapperSchoolYearRepository>();
            services.AddTransient<Application.SchoolGroups.ISchoolGroupRepository, DapperSchoolGroupRepository>();
            services.AddTransient<Application.Users.IUserRepository, DapperUserRepository>();
            services.AddTransient<Application.Logs.ILogRepository,DapperLogRepository>();
            services.AddTransient<Application.SchoolClasses.ISchoolClassRepository, DapperSchoolClassRepository>();
            services.AddTransient <Application.SchoolRooms.ISchoolRoomRepository, DapperSchoolRoomRepository>();
            services.AddTransient<Application.CashFlowTypes.ICashFlowTypeRepository, DapperCashFlowTypeRepository>();
            services.AddTransient<Application.PaymentMeans.IPaymentMeanRepository, DapperPaymentMeanRepository>();
            services.AddTransient<Application.SchoolingCosts.ISchoolingCostRepository, DapperSchoolingCostRepository>();
            services.AddTransient<Application.SubscriptionFees.ISubscriptionFeeRepository, DapperSubscriptionFeeRepository>();
            services.AddTransient<Application.SubjectGroups.ISubjectGroupRepository, DapperSubjectGroupRepository>();
            services.AddTransient<Application.Subjects.ISubjectRepository, DapperSubjectRepository>();
            services.AddTransient<Application.EvaluationTypes.IEvaluationTypeRepository, DbContextEvaluationTypeRepository>();
            services.AddTransient<IDbConnectionFactoty, MySqlConnectionFactory>();
            services.AddDbContext<AppDbContext>();
            services.AddLogging(builder => builder.AddConsole());
            return services;
        }
    }
}
