using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.CashFlowTypes;
using SchoolManagement.Application.Logs;
using SchoolManagement.Application.PaymentMeans;
using SchoolManagement.Application.SchoolClasses;
using SchoolManagement.Application.SchoolGroups;
using SchoolManagement.Application.SchoolingCosts;
using SchoolManagement.Application.SchoolRooms;
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Application.SubjectGroups;
using SchoolManagement.Application.Subjects;
using SchoolManagement.Application.SubscriptionFees;
using SchoolManagement.Application.Users;
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
            services.AddSingleton<ClientApp>();
            return services;
        }
    }
}
