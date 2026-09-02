

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Reporting;
using Primary.SchoolApp.Reporting.CashFlow;
using Primary.SchoolApp.Utilities;
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
        private readonly ILogger<PrintService> logger;
        public PrintService(ClientApp clientApp, IUserService userService, ILogger<PrintService> logger)
        {
            this.clientApp = clientApp;
            this.userService = userService;
            this.logger = logger;
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
                var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == enrolling.SchoolClass.GroupId);
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
                var report = new PaymentReceiptA4Report(new TuitionReceiptData(payment, isCopy));
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

        public async Task PrintReceiptAsync(ReceiptDTO receipt, bool isCopy)
        {
            if (receipt == null || receipt.ReceiptItems.Count == 0)
            {
                logger.LogError("Le reçu à générer n'a pas de ligne");
                return;
            }
            string studentName = string.Empty;
            string studentClass = string.Empty;
            string studentIdNumber = string.Empty;
            List<string> transactionIdList = new();
            List<string> PaymentModeList = new();
            StudentEnrollingDTO enrolling = null;
            var linkedItems = receipt.ReceiptItems.Select(x => x.LinkedItem);
            List<ReceiptItem> receiptItems = new();
            foreach (var item in linkedItems)
            {
                if (item is TuitionPaymentDTO payment)
                {
                    enrolling ??= payment.Enrolling.AsStudentEnrollingDTO();
                    if (studentName == string.Empty) studentName = enrolling?.Student?.FullName;
                    if (studentIdNumber == string.Empty) studentIdNumber = enrolling?.Student?.IdNumber;
                    if (studentClass == string.Empty) studentClass =  enrolling?.SchoolClass?.Name;
                    transactionIdList.Add(payment.TransactionId);
                    PaymentModeList.Add(payment?.PaymentMean?.Name);
                }
                if (item is SubscriptionDTO subscription)
                {
                    enrolling ??= subscription.Enrolling.AsStudentEnrollingDTO();
                    if (studentName == string.Empty) studentName = enrolling?.Student?.FullName;
                    if (studentIdNumber == string.Empty) studentIdNumber= enrolling?.Student?.IdNumber;
                    if (studentClass == string.Empty) studentClass = enrolling?.SchoolClass?.Name;
                    transactionIdList.Add(subscription.TransactionId);
                    PaymentModeList.Add(subscription?.PaymentMean?.Name);
                }
                if (item is SchoolSupplieDTO supplie)
                {
                    enrolling ??= supplie.Enrolling.AsStudentEnrollingDTO();
                    if (studentName == string.Empty) studentName = enrolling?.Student?.FullName;
                    if (studentIdNumber == string.Empty) studentIdNumber = enrolling?.Student?.IdNumber;
                    if (studentClass == string.Empty) studentClass = enrolling?.SchoolClass?.Name;
                    transactionIdList.Add(supplie.TransactionId);
                    PaymentModeList.Add(supplie?.PaymentMean?.Name);
                }
            }
            var receiptHeaderSection = new ReceiptHeaderSection(
                ReceiptNumber: receipt.IdNumber,
                ReceiptDate: DateTime.Now,
                ReceiptTitle: receipt.OpFor,
                StudentName: studentName,
                StudentId: studentIdNumber,
                StudentRoom: studentClass,
                TransactionId: string.Join(", ", transactionIdList.Distinct()),
                PaymentMode: string.Join(", ", PaymentModeList.Distinct()),
                SchoolYear: Program.CurrentSchoolYear.Name
            );
           foreach(var item in receipt.ReceiptItems)
            {
                if(item.LinkedItem is SchoolSupplieDTO )
                {
                    receiptItems.Add(
                        new ReceiptItem()
                        {
                           Balance=item.Balance,
                           Discount=item.Discount,
                           Id=item.Id,
                           ItemName = item.ItemName,
                           LinkedItem = item.LinkedItem,
                           Quantity = item.Quantity,
                           ReceiptId = item.ReceiptId,
                           Reference = item.Reference,
                           UnitPrice = item.UnitPrice/item.Quantity

                        }
                        );
                }
                else
                {
                    receiptItems.Add(item);
                }
            }
            var receiptDetailSection = new ReceiptDetailSection(receiptItems);
            var receiptFooterSection = new ReceiptFooterSection(string.Empty);
            var paymentReceipt=new PaymentReceipt(receiptHeaderSection, receiptDetailSection, receiptFooterSection);
            var reportViewer = Program.ServiceProvider.GetService<ReportViewerForm>();
            reportViewer.LoadPaymentReceipt(paymentReceipt, isCopy);
            reportViewer.Show();
            await Task.Delay(0);
        }
    }
}
