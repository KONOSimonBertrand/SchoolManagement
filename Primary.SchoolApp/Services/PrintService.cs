

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Reporting;
using Primary.SchoolApp.Reporting.CashFlow;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Services
{
    internal class PrintService : IPrintService
    {
        private readonly ClientApp clientApp;
        private readonly IUserService userService;
        private readonly ReportCardService reportCardService;
        public PrintService(ClientApp clientApp, IUserService userService, ReportCardService reportCardService)
        {
            this.clientApp = clientApp;
            this.userService = userService;
            this.reportCardService = reportCardService;
        }

        public async Task PrintPaymentSummaryAsync(StudentEnrolling enrolling)
        {
            //si accès au module Inscription des élèves et droit d'impression
            clientApp.UserConnected.Modules = userService.GetUserModuleList(clientApp.UserConnected.Id).Result;
            if (clientApp.UserConnected.Modules.Any(x => x.ModuleId == 1 && x.AllowPrint == true))
            {
                // Obtain the settings of the default printer
                System.Drawing.Printing.PrinterSettings printerSettings = new();
                // The standard print controller comes with no UI
                System.Drawing.Printing.PrintController standardPrintController =
                    new System.Drawing.Printing.StandardPrintController();
                // Print the report using the custom print controller
                Telerik.Reporting.Processing.ReportProcessor reportProcessor = new();
                reportProcessor.PrintController = standardPrintController;
                Telerik.Reporting.TypeReportSource typeReportSource = new();
                //get report to print
                var report = new PaymentSummaryReport(enrolling, clientApp);
                Telerik.Reporting.InstanceReportSource reportSource = new();
                reportSource.ReportDocument = report;
                //print report
                reportProcessor.PrintReport(reportSource, printerSettings);

            }
            else
            {
                //show report in preview from
                var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
                reportViewer.LoadPaymentSummary(enrolling);
                reportViewer.Show();
            }
            await Task.Delay(0);
        }

        public async Task PrintPaymentReceiptAsync(StudentEnrolling enrolling, bool isCopy)
        {
            //si accès au module Inscription des élèves et droit d'impression
            clientApp.UserConnected.Modules = userService.GetUserModuleList(clientApp.UserConnected.Id).Result;
            if (clientApp.UserConnected.Modules.Any(x => x.ModuleId == 1 && x.AllowPrint == true))
            {
                // Obtain the settings of the default printer
                System.Drawing.Printing.PrinterSettings printerSettings = new();
                // The standard print controller comes with no UI
                System.Drawing.Printing.PrintController standardPrintController =
                    new System.Drawing.Printing.StandardPrintController();
                // Print the report using the custom print controller
                Telerik.Reporting.Processing.ReportProcessor reportProcessor = new();
                reportProcessor.PrintController = standardPrintController;
                Telerik.Reporting.TypeReportSource typeReportSource = new();
                //get report to print
                var report = new PaymentReceiptA4Report(enrolling, isCopy, clientApp);
                Telerik.Reporting.InstanceReportSource reportSource = new();
                reportSource.ReportDocument = report;
                //print report
                reportProcessor.PrintReport(reportSource, printerSettings);

            }
            else
            {
                //show report in preview from
                var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
                reportViewer.LoadStudentEnrollingReceipt(enrolling, isCopy);
                reportViewer.Show();
            }
            await Task.Delay(0);
        }

        public async Task PrintPaymentReceiptAsync(TuitionPayment payment, bool isCopy)
        {
            //si accès au module Flux de trésorerie et droit d'impression
            clientApp.UserConnected.Modules = userService.GetUserModuleList(clientApp.UserConnected.Id).Result;
            if (clientApp.UserConnected.Modules.Any(x => x.ModuleId == 3 && x.AllowPrint == true))
            {
                // Obtain the settings of the default printer
                System.Drawing.Printing.PrinterSettings printerSettings = new();
                // The standard print controller comes with no UI
                System.Drawing.Printing.PrintController standardPrintController =
                    new System.Drawing.Printing.StandardPrintController();
                // Print the report using the custom print controller
                Telerik.Reporting.Processing.ReportProcessor reportProcessor = new();
                reportProcessor.PrintController = standardPrintController;
                Telerik.Reporting.TypeReportSource typeReportSource = new();
                //get report to print
                var report = new PaymentReceiptA4Report(payment, isCopy, clientApp);
                Telerik.Reporting.InstanceReportSource reportSource = new();
                reportSource.ReportDocument = report;
                //print report
                reportProcessor.PrintReport(reportSource, printerSettings);
            }
            else
            {
                //show report in preview from
                var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
                reportViewer.LoadTuitionPaymentReceipt(payment, isCopy);
                reportViewer.Show();
            }
            await Task.Delay(0);
        }

        public async Task PrintPaymentReceiptAsync(Subscription subscription, bool isCopy)
        {
            //si  droit d'impression des abonnements
            clientApp.UserConnected.Modules = userService.GetUserModuleList(clientApp.UserConnected.Id).Result;
            if (clientApp.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowPrint == true))
            {
                // Obtain the settings of the default printer
                System.Drawing.Printing.PrinterSettings printerSettings = new();
                // The standard print controller comes with no UI
                System.Drawing.Printing.PrintController standardPrintController =
                    new System.Drawing.Printing.StandardPrintController();
                // Print the report using the custom print controller
                Telerik.Reporting.Processing.ReportProcessor reportProcessor = new();
                reportProcessor.PrintController = standardPrintController;
                Telerik.Reporting.TypeReportSource typeReportSource = new();
                //get report to print
                var report = new PaymentReceiptA4Report(subscription, isCopy, clientApp);
                Telerik.Reporting.InstanceReportSource reportSource = new();
                reportSource.ReportDocument = report;
                //print report
                reportProcessor.PrintReport(reportSource, printerSettings);

            }
            else
            {
                //show report in preview from
                var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
                reportViewer.LoadSubscriptionReceipt(subscription, isCopy);
                reportViewer.Show();
            }
            await Task.Delay(0);
        }

        public async Task PrintSchoolCertificateAsync(StudentEnrollingDTO enrolling)
        {
            //show report in preview from
            var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
            reportViewer.LoadSchoolCertificate(enrolling);
            reportViewer.Show();
            await Task.Delay(0);
        }
        public async Task PrintStudentBadgeAsync(StudentEnrollingDTO enrolling, string expirationDate)
        {
            //show report in preview from
            var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
            reportViewer.LoadStudentBadge(enrolling, expirationDate);
            reportViewer.Show();
            await Task.Delay(0);
        }
        public async Task PrintClassBadgeAsync(IEnumerable<StudentEnrollingDTO> enrollingList, string expirationDate)
        {
            //show report in preview from            
            var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
            reportViewer.LoadClassBadge(enrollingList, expirationDate);
            reportViewer.Show();
            await Task.Delay(0);
        }
        //i,pression du bulletin d'un élève
        public async Task PrintReportCardByStudentAsync(int studentId, int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            var reportCard = await reportCardService.GetEvaluationReportCardByStudentAsync(studentId, roomId, evaluationId, schoolYearId, bookId);
            var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
            reportViewer.LoadEvaluationReportCard(reportCard);
            reportViewer.Show();
            await Task.Delay(0);
        }
        // impression des bulletion d'une salle de classe
        public async Task PrintReportCardByClassroomAsync(int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            var reportCardList = await reportCardService.GetEvaluationReportCardByRoomAsync(roomId, evaluationId, schoolYearId, bookId);
            var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
            reportViewer.LoadEvaluationReportCard(reportCardList);
            reportViewer.Show();
            await Task.Delay(0);
        }
        // impression du procès verbal
        public async Task PrintClassroomReportAsync(int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            ClassroomReport report= await reportCardService.GetClassroomReportAsync(roomId, evaluationId, schoolYearId, bookId);
            var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
            reportViewer.LoadClassroomReport(report);
            reportViewer.Show();
            await Task.Delay(0);
        }
    }
}
