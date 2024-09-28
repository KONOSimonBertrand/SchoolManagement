using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Reporting;
using Primary.SchoolApp.Reporting.CashFlow;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Reporting;

namespace Primary.SchoolApp
{
    public partial class ReportViewerForm : Telerik.WinControls.UI.RadForm
    {
        private readonly ISchoolClassService schoolClassService;
        private readonly ClientApp clientApp;
        public ReportViewerForm(ISchoolClassService schoolClassService, ClientApp clientApp)
        {
            InitializeComponent();
            this.schoolClassService = schoolClassService;
            this.clientApp = clientApp;
            this.Text = Language.labelReportViewer;
        }
        // génère un procès verbal vide
        internal async  void GenerateEmptyReportClassNote(SchoolRoom selectedRoom, SchoolYear selectedYear, string language)
        {
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = GetEmptyReportClassNote(selectedRoom, selectedYear, language);
            reportViewer.RefreshReport();
            await Task.Delay(0);
        }
        //affiche l'apperçu d'un reçu d'inscription
        internal void LoadStudentEnrollingReceipt(StudentEnrolling enrolling, bool isCopy)
        {
            InstanceReportSource reportSource = new();
            reportSource.ReportDocument = new PaymentReceiptA4Report(enrolling, isCopy,clientApp);
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        internal void LoadTuitionPaymentReceipt(TuitionPayment payment, bool isCopy)
        {
            InstanceReportSource reportSource = new();
            reportSource.ReportDocument = new PaymentReceiptA4Report(payment, isCopy, clientApp);
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }

        internal void LoadSubscriptionReceipt(Subscription subscription, bool isCopy)
        {
            InstanceReportSource reportSource = new();
            reportSource.ReportDocument = new PaymentReceiptA4Report(subscription, isCopy, clientApp);
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }

        internal void LoadPaymentSummary(StudentEnrolling enrolling)
        {
            InstanceReportSource reportSource = new();
            reportSource.ReportDocument = new PaymentSummaryReport(enrolling,clientApp);
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        // extraction un procès verbal sans note
        private ReportSource GetEmptyReportClassNote(SchoolRoom selectedRoom,SchoolYear selectedYear, string language)
        {
            List<Subject> subjectList = new();//liste des matières
            // extraction de la liste des matières de la classe
            var classSubjectList = (schoolClassService.GetClassSubjectList(selectedRoom.ClassId).Result).OrderBy(x=>x.Sequence);
            //extraction de la liste des groupes de matière
            var subjectGroupList = classSubjectList.Select(x => x.Group).Distinct();
            //extraction de la liste des matières
            foreach (var item in classSubjectList) { 
                item.Subject.Group=item.Group;
                item.Subject.GroupId=item.GroupId;
                subjectList.Add(item.Subject);
            }
            //création de l'object exam report qui servira de source de données de l'objet reporting
            ExamReport dataSource = new()
            {
                Room=selectedRoom,
                SchoolYear=selectedYear,
                EvaluationSession=new EvaluationSession(),
                LabelReport = new System.Data.DataTable(),
                DataReport = new System.Data.DataTable()
            };
            //création des entêtes
            string labelStudent= language != "EN"? "ELEVE": "STUDENT";
            string labelId = language != "EN" ? "MATRICULE":"ID";          
            dataSource.DataReport.Columns.Add("Id", typeof(string));
            dataSource.DataReport.Columns.Add("Student", typeof(string));
            dataSource.LabelReport.Columns.Add(labelId, typeof(string));
            dataSource.LabelReport.Columns.Add(labelStudent, typeof(string));
            int k = 1;
            foreach (var group in subjectGroupList)
            {
                foreach (var subject in subjectList.Where(s => s.Group.Id == group.Id))
                {
                    var subjectName = language == "EN"? subject.EnglishName: subject.FrenchName;
                    if (dataSource.LabelReport.Columns.Contains(subjectName.Trim()) == false)
                    {
                        dataSource.DataReport.Columns.Add("subject" + k, typeof(string));
                        dataSource.LabelReport.Columns.Add(subjectName.Trim());
                        k++;
                    }
                }
            }
            //ajout des élèves
            List<Student> studentList = new();
            foreach (var student in studentList) {
                object[] row = new object[2];
                row[0] = student.IdNumber;
                row[1] = student.FullName;
                dataSource.DataReport.Rows.Add(row);
            }
            // create report object to return
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new ClassNoteReportEmpty(dataSource)
            };
            return reportSource;
        }
    }
}
