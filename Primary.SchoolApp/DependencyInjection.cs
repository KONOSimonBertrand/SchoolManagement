﻿using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.UI;

namespace Primary.SchoolApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClientDependency(this IServiceCollection services)
        {
            services.AddTransient<MainForm>();
            services.AddTransient<LoginForm>();
            services.AddTransient<AddSchoolYearForm>();
            services.AddTransient<EditSchoolYearForm>();
            services.AddTransient<AddSchoolGroupForm>();
            services.AddTransient<EditSchoolGroupForm>();
            services.AddTransient<AddSchoolClassForm>();
            services.AddTransient<EditSchoolClassForm>();
            services.AddTransient<AddSchoolRoomForm>();
            services.AddTransient<EditSchoolRoomForm>();
            services.AddTransient<AddCashFlowTypeForm>();
            services.AddTransient<EditCashFlowTypeForm>();
            services.AddTransient<AddPaymentMeanForm>();
            services.AddTransient<EditPaymentMeanForm>();
            services.AddTransient<AddSchoolingCostForm>();
            services.AddTransient<EditSchoolingCostForm>();
            services.AddTransient<AddSubscriptionFeeForm>();
            services.AddTransient<EditSubscriptionFeeForm>();
            services.AddTransient<AddSubjectGroupForm>();
            services.AddTransient<EditSubjectGroupForm>();
            services.AddTransient<AddSubjectForm>();
            services.AddTransient<EditSubjectForm>();
            services.AddTransient<EditEvaluationSessionForm>();
            services.AddTransient<AddRatingSystemForm>();
            services.AddTransient<EditRatingSystemForm>();
            services.AddTransient<AddJobForm>();
            services.AddTransient<EditJobForm>();
            services.AddTransient<AddEmployeeGroupForm>();
            services.AddTransient<EditEmployeeGroupForm>();
            services.AddTransient<AddUserForm>();
            services.AddTransient<EditUserForm>();
            services.AddTransient<AddEmployeeForm>();
            services.AddTransient<EditEmployeeForm>();
            services.AddTransient<ClassSubjectsForm>();
            services.AddTransient<EditClassSubjectForm>();
            services.AddTransient<AddClassSubjectForm>();
            services.AddTransient<ReportViewerForm>();
            services.AddTransient<UserModulesForm>();
            services.AddTransient<UserRoomsForm>();
            services.AddTransient<EditUserPasswordForm>();
            services.AddTransient<EditEmployeeEnrollingForm>();
            services.AddTransient<AddEmployeeEnrollingForm>();
            services.AddTransient<UploadEmployeePictureForm>();
            services.AddTransient<EmployeeRoomsForm>();
            services.AddTransient<EmployeeSubjectsForm>();
            services.AddTransient<EmployeeAttendancesForm>();
            services.AddTransient<AddEmployeeAttendanceForm>();
            services.AddTransient<EditEmployeeAttendanceForm>();
            services.AddTransient<EmployeeNotesForm>();
            services.AddTransient<AddEmployeeNoteForm>();
            services.AddTransient<EditEmployeeNoteForm>();
            services.AddTransient<EmployeeAccountTransactionsForm>();
            services.AddTransient<AddEmployeeAccountTransactionForm>();
            services.AddTransient<EditTimeTableForm>();

            return services;
        }
    }
}
