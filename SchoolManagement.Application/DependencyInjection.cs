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
            services.AddTransient<IGenerateIdNumberService, GenerateIdNumberService>();
            services.AddTransient<ITimeTableService, TimeTableService>();
            services.AddSingleton<ClientApp>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IStudentEnrollingService, StudentEnrollingService>();
            services.AddTransient<ICashFlowService, CashFlowService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<IDisciplineService, DisciplineService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IMedicalService, MedicalService>();
            services.AddTransient<IStudentNoteService,StudentNoteService>();
            return services;
        }
    }
}
