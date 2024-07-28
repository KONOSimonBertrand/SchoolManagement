using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Core.Model;


namespace SchoolManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
        {
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<ISchoolYearService, SchoolYearService>();
            services.AddTransient<ISchoolGroupService, SchoolGroupService>();
            services.AddTransient<ISchoolClassService,SchoolClassService>();
            services.AddTransient<ISchoolRoomService, SchoolRoomService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICashFlowTypeService, CashFlowTypeService>();
            services.AddTransient<IPaymentMeanService, PaymentMeanService>();
            services.AddTransient<ISchoolingCostService, SchoolingCostService>();
            services.AddTransient<ISubscriptionFeeService, SubscriptionFeeService>();
            services.AddTransient<ISubjectGroupService, SubjectGroupService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IEvaluationSessionService, EvaluationSessionService>();
            services.AddTransient<IRatingSystemService, RatingSystemService>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IEmployeeGroupService, EmployeeGroupService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddSingleton<ClientApp>();
            return services;
        }
    }
}
