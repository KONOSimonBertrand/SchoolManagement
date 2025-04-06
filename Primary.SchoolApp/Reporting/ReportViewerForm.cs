using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Reporting;
using Primary.SchoolApp.Reporting.CashFlow;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telerik.Reporting;
using static Primary.SchoolApp.DTO.DTOItem;

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
        internal async  void GenerateEmptyReportClassNote(SchoolRoom selectedRoom, SchoolYear selectedYear)
        {
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = GetEmptyReportClassNote(selectedRoom, selectedYear);
            reportViewer.RefreshReport();
            await Task.Delay(0);
        }
        //affiche l'apperçu d'un reçu d'inscription
        internal void LoadStudentEnrollingReceipt(StudentEnrolling enrolling, bool isCopy)
        {
            var classGroup=Program.SchoolGroupList.FirstOrDefault(x=>x.Id==enrolling.SchoolClass.GroupId);
            InstanceReportSource reportSource = new();
            reportSource.ReportDocument = new PaymentReceiptA4Report(new PaymentReceiptData(enrolling,isCopy,classGroup));
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        internal void LoadTuitionPaymentReceipt(TuitionPayment payment, bool isCopy)
        {
            InstanceReportSource reportSource = new();
            reportSource.ReportDocument = new PaymentReceiptA4Report(new TuitionReceiptData(payment, isCopy));
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }

        internal void LoadSubscriptionReceipt(Subscription subscription, bool isCopy)
        {
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new PaymentReceiptA4Report(new SubscriptionReceiptData(subscription, isCopy))
            };
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        //load payment summary
        internal void LoadPaymentSummary(StudentEnrolling enrolling)
        {
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new PaymentSummaryReport(enrolling)
            };
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        //load student certificate
        internal void LoadSchoolCertificate(StudentEnrollingDTO enrolling)
        {
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x=>x.Id==enrolling.SchoolClass.GroupId);
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new SchoolCertificateReport( new(enrolling, classGroup))
            };
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        //load Student badge
        internal void LoadStudentBadge(StudentEnrollingDTO enrolling,string expirationDate)
        {
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new BadgeReport(enrolling,expirationDate)
            };
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        //load class badge
        internal void LoadClassBadge(IEnumerable<StudentEnrollingDTO> enrollingList, string expirationDate)
        {
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new BadgeReport(enrollingList, expirationDate)
            };
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        // extraction un procès verbal sans note
        private ReportSource GetEmptyReportClassNote(SchoolRoom selectedRoom,SchoolYear selectedYear)
        {
            List<Subject> subjectList = new();//liste des matières

            // get class
            var classOfRoom=Program.SchoolClassList.FirstOrDefault(x=>x.Id==selectedRoom.ClassId);
            //get group 
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var language = "FR";
            if (classOfRoom != null) {
                if (classGroup.DocumentLanguageId >0)
                {
                    if (classGroup.DocumentLanguageId == 1)
                    {
                        language = "EN";
                    }
                    else
                    {
                        language = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "EN" : "FR";
                    }
                }
            }
            // extraction de la liste des matières de la classe
            var classSubjectList = (schoolClassService.GetClassSubjectList(selectedRoom.ClassId).Result).OrderBy(x=>x.Sequence);
            //extraction de la liste des groupes de matière
            var subjectGroupList = classSubjectList.Select(x => x.Group).Distinct();
           
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
                foreach (var subject in classSubjectList.Where(x =>x.Group.Id == group.Id).Select(x=>x.Subject).Distinct())
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
            var students = Program.StudentRoomList.Where(x => x.RoomId == selectedRoom.Id).Select(x=>x.Student);
            foreach (var student in students) {
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

        #region Report Card
        // affiche un bulletin d'une évaluation
        internal void LoadEvaluationReportCard(EvaluationReportCard reportCard)
        {
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new PrimaryEvaluationReportCardReport(reportCard)
            };
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        // affiche un bulletin d'un trimestre
        internal void LoadTermReportCard(TermReportCard reportCard)
        {
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new PrimaryTermReportCardReport(reportCard)
            };
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        internal void LoadEvaluationReportCard(List<EvaluationReportCard> reportCardList)
        {
            var reportBook = new ReportBook();
            foreach (var reportCard in reportCardList) {

                InstanceReportSource reportSource = new();
                switch (reportCard.HeadSection.ClassRoom.SchoolClass.ReportCardModel)
                {
                    case 0:
                        reportSource.ReportDocument = new PrimaryEvaluationReportCardReport(reportCard);
                        break;
                    case 1:
                        reportSource.ReportDocument = new GardenEvaluationReportCardReport(reportCard);
                        break;
                    default:
                        reportSource.ReportDocument = new PrimaryEvaluationReportCardReport(reportCard);
                        break;
                }
                reportBook.ReportSources.Add(reportSource);
            }
            
            reportViewer.AutoSize = true;
            InstanceReportSource reportSourceFinal = new ()
            {
                ReportDocument = reportBook
            };
            reportViewer.ReportSource = reportSourceFinal;
            reportViewer.RefreshReport();
        }

        internal void LoadTermReportCard(List<TermReportCard> reportCardList)
        {
            var reportBook = new ReportBook();
            foreach (var reportCard in reportCardList)
            {
                InstanceReportSource reportSource = new()
                {
                    ReportDocument = new PrimaryTermReportCardReport(reportCard)
                };
                reportBook.ReportSources.Add(reportSource);
            }

            reportViewer.AutoSize = true;
            InstanceReportSource reportSourceFinal = new InstanceReportSource
            {
                ReportDocument = reportBook
            };
            reportViewer.ReportSource = reportSourceFinal;
            reportViewer.RefreshReport();
        }
        internal void LoadAnnualReportCard(List<TermReportCard> reportCardList)
        {
            var reportBook = new ReportBook();
            foreach (var reportCard in reportCardList)
            {
                InstanceReportSource reportSource = new()
                {
                    ReportDocument = new PrimaryAnnualReportCardReport(reportCard)
                };
                reportBook.ReportSources.Add(reportSource);
            }

            reportViewer.AutoSize = true;
            InstanceReportSource reportSourceFinal = new ()
            {
                ReportDocument = reportBook
            };
            reportViewer.ReportSource = reportSourceFinal;
            reportViewer.RefreshReport();
        }
        // Affiche le PV d'une salle de classe
        internal void LoadClassroomReport(ClassroomReport report)
        {
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new ClassNoteReport(report)
            };
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        /// <summary>
        /// Affiche les statistiques d'un groupe de classes par évaluation.
        /// Nombre d'élèves par salle de classe, Nombre d'élèves ayant composé
        /// Nombre d'admis,abstention,recalé, moyenne général, etc
        /// </summary>
        /// <param name="report"></param>
        internal void LoadClassGroupReport(ClassGroupReport report)
        {
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new GroupNoteReport(report)
            };
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        internal void LoadDisciplinarySheet(StudentDisciplinarySheet report)
        {
            InstanceReportSource reportSource = new()
            {
                ReportDocument = new DisciplinarySheetReport(report)
            };
            reportViewer.AutoSize = true;
            reportViewer.ReportSource = reportSource;
            reportViewer.RefreshReport();
        }
        internal void LoadDisciplinarySheet(List<StudentDisciplinarySheet> reports)
        {

            var reportBook = new ReportBook();
            foreach (var report in reports)
            {
                InstanceReportSource reportSource = new()
                {
                    ReportDocument = new DisciplinarySheetReport(report)
                };
                reportBook.ReportSources.Add(reportSource);
            }

            reportViewer.AutoSize = true;
            InstanceReportSource reportSourceFinal = new ()
            {
                ReportDocument = reportBook
            };
            reportViewer.ReportSource = reportSourceFinal;
            reportViewer.RefreshReport();
        }

        #endregion

    }
}
