using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SchoolManagement.Infrastructure.DataBase;
using SchoolManagement.Infrastructure.Repositories;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services)
        {
            services.AddTransient<IDbConnectionFactory, MySqlConnectionFactory>();
            services.AddTransient<ISchoolYearRepository, DapperSchoolYearRepository>();
            services.AddTransient<ISchoolGroupRepository, DapperSchoolGroupRepository>();
            services.AddTransient<IUserRepository, DapperUserRepository>();
            services.AddTransient<ILogRepository,DapperLogRepository>();
            services.AddTransient<ISchoolClassRepository, DapperSchoolClassRepository>();
            services.AddTransient <ISchoolRoomRepository, DapperSchoolRoomRepository>();
            services.AddTransient<ICashFlowTypeRepository, DapperCashFlowTypeRepository>();
            services.AddTransient<IPaymentMeanRepository, DapperPaymentMeanRepository>();
            services.AddTransient<ISchoolingCostRepository, DapperSchoolingCostRepository>();
            services.AddTransient<ISubscriptionFeeRepository, DapperSubscriptionFeeRepository>();
            services.AddTransient<ISubjectGroupRepository, DapperSubjectGroupRepository>();
            services.AddTransient<ISubjectRepository, DapperSubjectRepository>();
            services.AddTransient<IEvaluationSessionRepository, DapperEvaluationSessionRepository>();
            services.AddTransient<IRatingSystemRepository, DapperRatingSystemRepository>();
            services.AddTransient<IJobRepository, DapperJobRepository>();
            services.AddTransient<IEmployeeGroupRepository, DapperEmployeeGroupRepository>();
            services.AddTransient<IModuleRepository, DapperModuleRepository>();
            services.AddTransient<IUserRepository, DapperUserRepository>();
            services.AddTransient<ICountryRepository, DapperCountryRepository>();
            services.AddTransient<IEmployeeRepository, DapperEmployeeRepository>();
            services.AddTransient<ITimeTableServiceRepository, DapperTimeTableServiceRepository>();
            services.AddTransient<IStudentRepository,DapperStudentRepository>();
            services.AddTransient<IStudentEnrollingRepository, DapperStudentEnrollingRepository>();
            services.AddTransient<ICashFlowRepository, DapperCashFlowRepository>();
            services.AddTransient<ISubscriptionRepository, DapperSubscriptionRepository>();
            services.AddTransient<IDisciplineRepository, DapperDisciplineRepository>();
            services.AddTransient<IContactRepository, DapperContactRepository>();
            services.AddTransient<IMedicalRepository, DapperMedicalRepository>();
            services.AddTransient<IStudentNoteRepository, DapperStudentNoteRepository>();
            services.AddDbContext<AppDbContext>();
            services.AddLogging(builder => builder.AddConsole());
            return services;
        }
    }
}
