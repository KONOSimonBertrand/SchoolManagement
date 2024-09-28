

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Reporting;
using Primary.SchoolApp.Reporting.CashFlow;
using SchoolManagement.Core.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Primary.SchoolApp.Services
{
    internal class PrintService:IPrintService
    {
        private readonly ClientApp clientApp;
        public PrintService(ClientApp clientApp)
        {
            this.clientApp = clientApp;
        }

        public async Task PrintPaymentSummary(StudentEnrolling enrolling)
        {
            //si accès au module Inscription des élèves et droit d'impression
            var module = clientApp.UserConnected.Modules.Where(x => x.ModuleId == 1).FirstOrDefault();
            if (module != null && module.AllowPrint == true)
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
                var report = new PaymentSummaryReport(enrolling,clientApp);
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

        public async Task PrintPaymentReceipt(StudentEnrolling enrolling,bool isCopy)
        {
            //si accès au module Inscription des élèves et droit d'impression
            var module= clientApp.UserConnected.Modules.Where(x=>x.ModuleId==1 ).FirstOrDefault();
            if (module != null && module.AllowPrint == true)
            {
                // Obtain the settings of the default printer
                System.Drawing.Printing.PrinterSettings printerSettings = new();
                // The standard print controller comes with no UI
                System.Drawing.Printing.PrintController standardPrintController =
                    new System.Drawing.Printing.StandardPrintController();
                // Print the report using the custom print controller
                Telerik.Reporting.Processing.ReportProcessor reportProcessor=new ();
                reportProcessor.PrintController = standardPrintController;
                Telerik.Reporting.TypeReportSource typeReportSource =new();
                //get report to print
                var report= new PaymentReceiptA4Report(enrolling, isCopy,clientApp);
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

        public async Task PrintPaymentReceipt(TuitionPayment payment, bool isCopy)
        {
            //si accès au module Inscription des élèves et droit d'impression
            var module = clientApp.UserConnected.Modules.Where(x => x.ModuleId == 1).FirstOrDefault();
            if (module != null && module.AllowPrint == true)
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

        public async Task PrintPaymentReceipt(Subscription subscription, bool isCopy)
        {
            //si  droit d'impression des abonnements
            var module = clientApp.UserConnected.Modules.Where(x => x.ModuleId == 4).FirstOrDefault();
            if (module != null && module.AllowPrint == true)
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
    }
}
