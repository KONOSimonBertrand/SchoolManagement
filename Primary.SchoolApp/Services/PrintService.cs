

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Reporting;
using Primary.SchoolApp.Reporting.CashFlow;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
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
        public PrintService(ClientApp clientApp, IUserService userService)
        {
            this.clientApp = clientApp;
            this.userService = userService;
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
                var report = new PaymentSummaryReport(enrolling);
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
                var classGroup=Program.SchoolGroupList.FirstOrDefault(x=>x.Id==enrolling.SchoolClass.GroupId);
                var report = new PaymentReceiptA4Report(new PaymentReceiptData(enrolling, isCopy, classGroup));
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
                var report = new PaymentReceiptA4Report( new TuitionReceiptData(payment, isCopy));
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
            subscription.SchoolYear??=Program.SchoolYearList.FirstOrDefault(x=>x.Id== subscription.SchoolYearId);
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
                var report = new PaymentReceiptA4Report( new SubscriptionReceiptData(subscription, isCopy));
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

        public async Task PrintPaymentReceiptAsync(PaymentReceipt paymentReceipt, bool isCopy)
        {
            var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
            reportViewer.LoadPaymentReceipt(paymentReceipt,isCopy);
            reportViewer.Show();
            await Task.Delay(0);
        }
    }
}
