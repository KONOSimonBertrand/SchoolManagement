using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Enum;
using SchoolManagement.Core.Model;
using SchoolManagement.Helper;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;

namespace Primary.SchoolApp.Services
{
    public class ListingService
    {

        private readonly IEmployeeService employeeService;
        private readonly ISchoolClassService schoolClassService;
        private readonly IStudentEnrollingService studentEnrollingService;
        private readonly IContactService contactService;
        private readonly IMedicalService medicalService;
        private readonly IDisciplineService disciplineService;
        private readonly ISubscriptionService subscriptionService;
        private readonly ITimeTableService timeTableService;
        private readonly ILogService logService;
        private readonly ISchoolSupplieService schoolSupplieService;
        public ListingService(IEmployeeService employeeService, ISchoolClassService schoolClassService,
            IStudentEnrollingService studentEnrollingService, IContactService contactService, IMedicalService medicalService,
            IDisciplineService disciplineService, ISubscriptionService subscriptionService, ITimeTableService timeTableService,
            ILogService logService, ISchoolSupplieService schoolSupplieService)
        {
            this.employeeService = employeeService;
            this.schoolClassService = schoolClassService;
            this.studentEnrollingService = studentEnrollingService;
            this.contactService = contactService;
            this.medicalService = medicalService;
            this.disciplineService = disciplineService;
            this.subscriptionService = subscriptionService;
            this.timeTableService = timeTableService;
            this.logService = logService;
            this.schoolSupplieService = schoolSupplieService;
        }

        public static List<ListingItem> GetListingItems()
        {
            List<ListingItem> items = new()
            {
                new()
                {
                    Id = 1,
                    FrenchName = "LISTE DES CLASSES",
                    EnglishName = "CLASS LIST",
                    FrenchDescription = "Double-cliquer ici pour consulter la liste des classes ",
                    EnglishDescription = "Double-click here to view the class list",
                    ModuleId = 9,
                },
                new()
                {
                    Id = 2,
                    FrenchName = "LISTE DES SALLES DE CLASSE",
                    EnglishName = "CLASS ROOM LIST",
                    FrenchDescription = "Double-cliquer ici pour consulter la liste des salles de  classe ",
                    EnglishDescription = "Double-click here to view the classroom list",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 3,
                    FrenchName = "LISTE DES MATIERES ENSEIGNEES",
                    EnglishName = "LIST OF SUBJECTS",
                    FrenchDescription = "Double-cliquer ici pour consulter la liste des matières ",
                    EnglishDescription = "Double-click here to view the list of subjects",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 4,
                    FrenchName = "LISTE DES FRAIS SCOLAIRES",
                    EnglishName = "LIST OF SCHOOL FEES",
                    FrenchDescription = "Double-cliquer ici pour consulter la liste des frais scolaires ",
                    EnglishDescription = "Double-click here to view the list of school fees",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 5,
                    FrenchName = "LISTE DES FRAIS D'ABONNEMENT",
                    EnglishName = "LIST OF SUBSCRIPTION FEES",
                    FrenchDescription = "Double-cliquer ici pour consulter la liste des frais d'abonnement ",
                    EnglishDescription = "Double-click here to view the list of subscription fees",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 6,
                    FrenchName = "LISTE DES ELEVES",
                    EnglishName = "LIST OF STUDENTS",
                    FrenchDescription = "Double-cliquer ici pour consulter les listes des élèves ",
                    EnglishDescription = "Double-click here to view list of student ",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 7,
                    FrenchName = "LISTE DES EMEMPLOYES",
                    EnglishName = "LIST OF EMPLOYEES",
                    FrenchDescription = "Double-cliquer ici pour consulter les listes des employés ",
                    EnglishDescription = "Double-click here to view list of employee ",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 8,
                    FrenchName = "RAPPORT GLOBAL DES INSCRIPTIONS",
                    EnglishName = "GLOBAL REPORT OF REGISTRATIONS",
                    FrenchDescription = "Double-cliquer ici pour consulter le rapport d'inscription ",
                    EnglishDescription = "Double-click here to view the registration report ",
                    ModuleId = 10,
                },
                 new()
                {
                    Id = 9,
                    FrenchName = "RAPPORT GLOBAL RELATIF AUX FRAIS SCOLAIRES",
                    EnglishName = "GLOBAL REPORT ON SCHOOL FEES",
                    FrenchDescription = "Double-cliquer ici pour consulter les versements relatifs aux frais scolaires ",
                    EnglishDescription = "Double-click here to view school fee payments ",
                    ModuleId = 10,
                },
                 new()
                {
                    Id = 10,
                    FrenchName = "RAPPORT GLOBAL RELATIF AUX FLUX DE TRESORERIE",
                    EnglishName = "GLOBAL REPORT ON CASH FLOW",
                    FrenchDescription = "Double-cliquer ici pour consulter tous les flux de trésorerie ",
                    EnglishDescription = "Double-click here to view all cash flows ",
                    ModuleId = 10,
                },
                 new()
                {
                    Id = 11,
                    FrenchName = "RAPPORT GLOBAL RELATIF AUX ABONNEMENTS",
                    EnglishName = "GLOBAL SUBSCRIPTIONS REPORT",
                    FrenchDescription = "Double-cliquer ici pour consulter tous les abonnements ",
                    EnglishDescription = "Double-click here to view all subscriptions ",
                    ModuleId = 10,
                },
                 new()
                {
                    Id = 12,
                    FrenchName = "RAPPORT GLOBAL DES DEPENSES",
                    EnglishName = "GLOBAL EXPENSES REPORT",
                    FrenchDescription = "Double-cliquer ici pour consulter les dépenses ",
                    EnglishDescription = "Double-click here to view expenses ",
                    ModuleId = 10,
                },
                 new()
                {
                    Id = 13,
                    FrenchName = "LISTE DES CONTACTS DES ELEVES",
                    EnglishName = "STUDENT CONTACT LIST",
                    FrenchDescription = "Double-cliquer ici pour consulter la liste des contacts des élèves ",
                    EnglishDescription = "Double-click here to view the student contact list ",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 14,
                    FrenchName = "FICHE MEDICAL DES ELEVES",
                    EnglishName = "STUDENT MEDICAL RECORDS",
                    FrenchDescription = "Double-cliquer ici pour consulter la fiche médical des élèves ",
                    EnglishDescription = "Double-click here to view the students' medical records ",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 15,
                    FrenchName = "RAPPORT DISCIPLINE DES ELEVES",
                    EnglishName = "STUDENT DISCIPLINE REPORT",
                    FrenchDescription = "Double-cliquer ici pour consulter les absences des élèves ",
                    EnglishDescription = "Double-click here to view student absences ",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 16,
                    FrenchName = "RAPPORT DE PRESENCE DES EMPLOYES",
                    EnglishName = "EMPLOYEE ATTENDANCE REPORT",
                    FrenchDescription = "Double-cliquer ici pour consulter les présences des employés ",
                    EnglishDescription = "Double-click here to view employee attendance ",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 17,
                    FrenchName = "RAPPORT ABONNEMENT TRANSPORT",
                    EnglishName = "TRANSPORT SUBSCRIPTION REPORT",
                    FrenchDescription = "Double-cliquer ici pour consulter abonnements relatifs au transport ",
                    EnglishDescription = "Double-click here to view transport subscriptions ",
                    ModuleId = 10,
                },
                 new()
                {
                    Id = 18,
                    FrenchName = "RAPPORT ABONNEMENT TAPS",
                    EnglishName = "TAPS SUBSCRIPTION REPORT",
                    FrenchDescription = "Double-cliquer ici pour consulter abonnements relatifs aux activités périscolaires ",
                    EnglishDescription = "Double-click here to view subscriptions for extracurricular activities ",
                    ModuleId = 10,
                },
                 new()
                {
                    Id = 19,
                    FrenchName = "RAPPORT ABONNEMENT CANTINE",
                    EnglishName = "CANTEEN SUBSCRIPTION REPORT",
                    FrenchDescription = "Double-cliquer ici pour consulter abonnements relatifs à la cantine ",
                    EnglishDescription = "Double-click here to view canteen subscriptions ",
                    ModuleId = 10,
                },
                 new()
                {
                    Id = 20,
                    FrenchName = "RAPPORT POINTAGE DES COURS",
                    EnglishName = "COURSE SCORING REPORT",
                    FrenchDescription = "Double-cliquer ici pour consulter les pointages des cours ",
                    EnglishDescription = "Double-click here to view course scores ",
                    ModuleId = 9,
                },
                 new()
                {
                    Id = 21,
                    FrenchName = "RAPPORT GLOBAL DES APPROVISIONNEMENTS",
                    EnglishName = "GLOBAL SUPPLY REPORT",
                    FrenchDescription = "Double-cliquer ici pour consulter les approvisionnements ",
                    EnglishDescription = "Double-click here to view supplies ",
                    ModuleId = 10,
                },
                 new()
                {
                    Id = 22,
                    FrenchName = "HISTORIQUE DES ACTIONS DES UTILISATEURS SUR LE SYSTEME",
                    EnglishName = "HISTORY OF USER ACTIONS IN THE SYSTEM",
                    FrenchDescription = "Double-cliquer ici pour consulter l'historique des actions des  utilisateurs sur le système ",
                    EnglishDescription = "Double-click here to view the history of user actions on the system ",
                    ModuleId = 17,
                },
                 new()
                {
                    Id = 23,
                    FrenchName = "RAPPORT FOURNITURE SCOLAIRE",
                    EnglishName = "SCHOOL SUPPLY REPORT",
                    FrenchDescription = "Double-cliquer ici pour consulter le repport relatif aux fournitures scolaires ",
                    EnglishDescription = "Double-click here to view school supply report ",
                    ModuleId = 10,
                }
            };

            return items;
        }
        // Retourne la liste des classes
        public async Task<Dictionary<int, DataTable>> GetClassList()
        {
            var getClassSubjectsTask = schoolClassService.GetClassSubjectList();
            var getEmployeeClassroomsTask = employeeService.GetRoomListBySchoolYear(Program.CurrentSchoolYear.Id);
            var getStudentClassroomTask = studentEnrollingService.GetStudentRoomListAsync(Program.CurrentSchoolYear.Id);
            DataTable dataTable = new();
            string designationColumn = Language.LanguageName == "EN" ? "DESIGNATION" : "DESIGNATION";
            string groupColumn = Language.LanguageName == "EN" ? "GROUP" : "GROUPE";
            string subjectColumn = Language.LanguageName == "EN" ? "SUBJECTS" : "MATIERES";
            string studentColumn = Language.LanguageName == "EN" ? "STUDENTS" : "ELEVES";
            string teacherColumn = Language.LanguageName == "EN" ? "TEACHERS" : "ENSEIGNANTS";
            string roomColumn = Language.LanguageName == "EN" ? "CLASSROOMS" : "SALLES DE CLASSE";
            dataTable.Columns.Add(designationColumn, typeof(string));
            dataTable.Columns.Add(groupColumn, typeof(string));
            dataTable.Columns.Add(subjectColumn, typeof(int));
            dataTable.Columns.Add(studentColumn, typeof(int));
            dataTable.Columns.Add(teacherColumn, typeof(int));
            dataTable.Columns.Add(roomColumn, typeof(int));
            var classSubjectList = await getClassSubjectsTask;
            var employeeClassroomList = await getEmployeeClassroomsTask;
            var studentClassroomList = await getStudentClassroomTask;
            foreach (var item in Program.SchoolClassList)
            {
                object[] row = new object[6];
                row[0] = item.Name;
                row[1] = item.Group.Name;
                row[2] = classSubjectList.Count(x => x.ClassId == item.Id);
                row[3] = studentClassroomList.Count(x => x.Room.ClassId == item.Id);
                row[4] = employeeClassroomList.Count(x => x.Room.ClassId == item.Id);
                row[5] = Program.SchoolRoomList.Count(x => x.ClassId == item.Id);
                dataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }

        //retourne la liste des salles de classe
        public async Task<Dictionary<int, DataTable>> GetRoomList()
        {
            var getClassSubjectsTask = schoolClassService.GetClassSubjectList();
            var getEmployeeClassroomsTask = employeeService.GetRoomListBySchoolYear(Program.CurrentSchoolYear.Id);
            var getStudentClassroomTask = studentEnrollingService.GetStudentRoomListAsync(Program.CurrentSchoolYear.Id);
            DataTable dataTable = new();
            string designationColumn = Language.LanguageName == "EN" ? "DESIGNATION" : "DESIGNATION";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";
            string groupColumn = Language.LanguageName == "EN" ? "GROUP" : "GROUPE";
            string subjectColumn = Language.LanguageName == "EN" ? "SUBJECTS" : "MATIERES";
            string studentColumn = Language.LanguageName == "EN" ? "STUDENTS" : "ELEVES";
            string teacherColumn = Language.LanguageName == "EN" ? "TEACHERS" : "ENSEIGNANTS";
            dataTable.Columns.Add(designationColumn, typeof(string));
            dataTable.Columns.Add(classColumn, typeof(string));
            dataTable.Columns.Add(groupColumn, typeof(string));
            dataTable.Columns.Add(subjectColumn, typeof(int));
            dataTable.Columns.Add(studentColumn, typeof(int));
            dataTable.Columns.Add(teacherColumn, typeof(int));
            var classSubjectList = await getClassSubjectsTask;
            var employeeClassroomList = await getEmployeeClassroomsTask;
            var studentClassroomList = await getStudentClassroomTask;
            foreach (var item in Program.SchoolRoomList)
            {
                object[] row = new object[6];
                row[0] = item.Name;
                row[1] = item.SchoolClass.Name;
                row[2] = item.SchoolClass.Group?.Name;
                row[3] = classSubjectList.Count(x => x.ClassId == item.ClassId);
                row[4] = studentClassroomList.Count(x => x.RoomId == item.Id);
                row[5] = employeeClassroomList.Count(x => x.RoomId == item.Id);
                dataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }

        //retourne la liste des matières
        public async Task<Dictionary<int, DataTable>> GetSubjectList()
        {
            DataTable dataTable = new();
            string designationColumn = Language.LanguageName == "EN" ? "DESIGNATION" : "DESIGNATION";
            string groupColumn = Language.LanguageName == "EN" ? "GROUP" : "GROUPE";
            string maxMarkColumn = Language.LanguageName == "EN" ? "MAX RATING" : "NOTE MAX";
            string coefColumn = Language.LanguageName == "EN" ? "COEFFICIENT" : "COEFFICIENT";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";
            string sectionColumn = Language.LanguageName == "EN" ? "SECTION" : "SECTION";
            dataTable.Columns.Add(designationColumn, typeof(string));
            dataTable.Columns.Add(groupColumn, typeof(string));
            dataTable.Columns.Add(maxMarkColumn, typeof(double));
            dataTable.Columns.Add(coefColumn, typeof(double));
            dataTable.Columns.Add(classColumn, typeof(string));
            dataTable.Columns.Add(sectionColumn, typeof(string));
            foreach (var item in Program.ClassSubjectList.OrderBy(x => x.Class?.Name))
            {
                object[] row = new object[6];
                row[0] = Language.LanguageName == "EN" ? item.Subject.EnglishName : item.Subject.FrenchName;
                row[1] = Language.LanguageName == "EN" ? item.Group.EnglishName : item.Group.FrenchName;
                row[2] = item.NotedOn;
                row[3] = item.Coefficient;
                row[4] = item.Class.Name;
                row[5] = item.BookName;
                dataTable.Rows.Add(row);
            }
            await Task.Delay(0);
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }

        //retourne la liste des frais scolaire
        public async Task<Dictionary<int, DataTable>> GetFeeSchoolList()
        {
            DataTable dataTable = new();
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";
            string feeTypeColumn = Language.LanguageName == "EN" ? "TYPE OF FEES" : "TYPE DE FRAIS";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            string trancheCountColumn = Language.LanguageName == "EN" ? "TOTAL OF TRANCHE" : "NOMBRE DE TRANCHES";
            string trancheAmountColumn = Language.LanguageName == "EN" ? "TRANCHE AMOUNT" : "MONTANT TRANCHE";
            string deadlineColumn = Language.LanguageName == "EN" ? "DEADLINE" : "DATE LIMITE";
            dataTable.Columns.Add(classColumn, typeof(string));
            dataTable.Columns.Add(feeTypeColumn, typeof(string));
            dataTable.Columns.Add(amountColumn, typeof(double));
            dataTable.Columns.Add(trancheCountColumn, typeof(int));
            dataTable.Columns.Add(trancheAmountColumn, typeof(string));
            dataTable.Columns.Add(deadlineColumn, typeof(string));
            foreach (var item in Program.SchoolingCostList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id))
            {
                object[] row = new object[6];
                row[0] = item.SchoolClass.Name;
                row[1] = item.CashFlowType.Name;
                row[2] = item.Amount;
                row[3] = item.TrancheNumber;
                row[4] = string.Join("-", item.SchoolingCostItems.Select(x => x.Amount));
                row[5] = string.Join("-", item.SchoolingCostItems.Select(x => x.DeadLine.ToShortDateString()));
                dataTable.Rows.Add(row);
            }
            await Task.Delay(0);
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }


        //retourne la liste des frais scolaire
        public async Task<Dictionary<int, DataTable>> GetFeeSubscriptionList()
        {
            DataTable dataTable = new();
            string subscriptionColumn = Language.LanguageName == "EN" ? "SUBSCRIPTION" : "ABONNEMENT";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            string durationColumn = Language.LanguageName == "EN" ? "DURATION" : "DUREE";
            string domainColumn = Language.LanguageName == "EN" ? "DOMAIN" : "DOMAINE";
            string descriptionColumn = Language.LanguageName == "EN" ? "DESCRIPTION" : "DESCRIPTION";
            dataTable.Columns.Add(subscriptionColumn, typeof(string));
            dataTable.Columns.Add(amountColumn, typeof(double));
            dataTable.Columns.Add(durationColumn, typeof(int));
            dataTable.Columns.Add(domainColumn, typeof(string));
            dataTable.Columns.Add(descriptionColumn, typeof(string));
            foreach (var item in Program.SubscriptionFeeList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id))
            {
                object[] row = new object[5];
                row[0] = item.CashFlowType.Name;
                row[1] = item.Amount;
                row[2] = item.Duration;
                row[3] = item.CashFlowType.FlowDomain;
                row[4] = item.CashFlowType.Description;
                dataTable.Rows.Add(row);
            }
            await Task.Delay(0);
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }

        //retourne la liste des élèves
        public async Task<Dictionary<int, DataTable>> GetStudentList()
        {
            var getContactTask = contactService.GetContactList();
            DataTable dataTable = new();
            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string lastNameColumn = Language.LanguageName == "EN" ? "LAST NAME" : "NOM";
            string firstNameColumn = Language.LanguageName == "EN" ? "FIRST NAME" : "PRENOM";
            string sexColumn = Language.LanguageName == "EN" ? "SEX" : "SEXE";
            string birthDateColumn = Language.LanguageName == "EN" ? "BIRTH DATE" : "DATE DE NAISSANCE";
            string birthPlaceColumn = Language.LanguageName == "EN" ? "BIRTH PLACE" : "LIEU DE NAISSANCE";
            string nationalityColumn = Language.LanguageName == "EN" ? "NATIONALITY" : "NATIONALITE";
            string phoneColumn = Language.LanguageName == "EN" ? "PHONE" : "TELEPNONE";
            string emailColumn = Language.LanguageName == "EN" ? "EMAIL" : "EMAIL";
            string addressColumn = Language.LanguageName == "EN" ? "ADDRESS" : "ADRESSE";
            string fatherlaceColumn = Language.LanguageName == "EN" ? "FATHER" : "PERE";
            string motherColumn = Language.LanguageName == "EN" ? "MOTHER" : "MERE";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";

            dataTable.Columns.Add(idColumn, typeof(string));
            dataTable.Columns.Add(lastNameColumn, typeof(string));
            dataTable.Columns.Add(firstNameColumn, typeof(string));
            dataTable.Columns.Add(sexColumn, typeof(string));
            dataTable.Columns.Add(birthDateColumn, typeof(DateTime));
            dataTable.Columns.Add(birthPlaceColumn, typeof(string));
            dataTable.Columns.Add(nationalityColumn, typeof(string));
            dataTable.Columns.Add(phoneColumn, typeof(string));
            dataTable.Columns.Add(emailColumn, typeof(string));
            dataTable.Columns.Add(addressColumn, typeof(string));
            dataTable.Columns.Add(fatherlaceColumn, typeof(string));
            dataTable.Columns.Add(motherColumn, typeof(string));
            dataTable.Columns.Add(classColumn, typeof(string));
            var contactList = await getContactTask;
            foreach (var item in Program.StudentEnrollingList)
            {
                object[] row = new object[13];
                row[0] = item.Student.IdNumber;
                row[1] = item.Student.LastName;
                row[2] = item.Student.FirstName;
                row[3] = item.Student.Sex;
                row[4] = item.Student.BirthDate;
                row[5] = item.Student.BirthPlace;
                row[6] = item.Student.Nationality;
                row[7] = item.Student.Phone;
                row[8] = item.Student.Email;
                row[9] = item.Student.Address;
                row[10] = contactList.FirstOrDefault(x => x.StudentId == item.StudentId && x.Relationship == 0)?.Name;
                row[11] = contactList.FirstOrDefault(x => x.StudentId == item.StudentId && x.Relationship == 1)?.Name;
                row[12] = item.ClassName;
                dataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }

        //retourne la liste des employés
        public async Task<Dictionary<int, DataTable>> GetEmployeeList()
        {
            var getEmployeeSubjectTask = employeeService.GetSubjectListBySchoolYear(Program.CurrentSchoolYear.Id);
            var getEmsployeeRoomTask = employeeService.GetRoomListBySchoolYear(Program.CurrentSchoolYear.Id);
            DataTable dataTable = new();
            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string lastNameColumn = Language.LanguageName == "EN" ? "LAST NAME" : "NOM";
            string firstNameColumn = Language.LanguageName == "EN" ? "FIRST NAME" : "PRENOM";
            string sexColumn = Language.LanguageName == "EN" ? "SEX" : "SEXE";
            string birthDateColumn = Language.LanguageName == "EN" ? "BIRTH DATE" : "DATE DE NAISSANCE";
            string nationalityColumn = Language.LanguageName == "EN" ? "NATIONALITY" : "NATIONALITE";
            string phoneColumn = Language.LanguageName == "EN" ? "PHONE" : "TELEPNONE";
            string emailColumn = Language.LanguageName == "EN" ? "EMAIL" : "EMAIL";
            string addressColumn = Language.LanguageName == "EN" ? "ADDRESS" : "ADRESSE";
            string idcardColumn = Language.LanguageName == "EN" ? "ID CARD" : "CNI";
            string hiringDateColumn = Language.LanguageName == "EN" ? "HIRING DATE" : "DATE EMBAUCHE";
            string jobColumn = Language.LanguageName == "EN" ? "JOB" : "FONCTION";
            string subjectColumn = Language.LanguageName == "EN" ? "SUBJECTS" : "MATIERES";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSES";

            dataTable.Columns.Add(idColumn, typeof(string));
            dataTable.Columns.Add(lastNameColumn, typeof(string));
            dataTable.Columns.Add(firstNameColumn, typeof(string));
            dataTable.Columns.Add(sexColumn, typeof(string));
            dataTable.Columns.Add(birthDateColumn, typeof(DateTime));
            dataTable.Columns.Add(nationalityColumn, typeof(string));
            dataTable.Columns.Add(phoneColumn, typeof(string));
            dataTable.Columns.Add(emailColumn, typeof(string));
            dataTable.Columns.Add(addressColumn, typeof(string));
            dataTable.Columns.Add(idcardColumn, typeof(string));
            dataTable.Columns.Add(hiringDateColumn, typeof(DateTime));
            dataTable.Columns.Add(jobColumn, typeof(string));
            dataTable.Columns.Add(subjectColumn, typeof(int));
            dataTable.Columns.Add(classColumn, typeof(int));
            var employeeSubjectList = await getEmployeeSubjectTask;
            var employeeRoomList = await getEmsployeeRoomTask;
            foreach (var item in Program.EmployeeEnrollingList)
            {
                object[] row = new object[14];
                row[0] = item.Employee.IdNumber;
                row[1] = item.Employee.LastName;
                row[2] = item.Employee.FirstName;
                row[3] = item.Employee.Sex;
                row[4] = item.Employee.BirthDate;
                row[5] = item.Employee.Nationality;
                row[6] = item.Employee.Phone;
                row[7] = item.Employee.Email;
                row[8] = item.Employee.Address;
                row[9] = item.Employee.IdCard;
                row[10] = item.Employee.HiringDate;
                row[11] = item.Job.Name;
                row[12] = employeeSubjectList.Count(x => x.EmployeeId == item.EmployeeId);
                row[13] = employeeRoomList.Count(x => x.EmployeeId == item.EmployeeId);
                dataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }

        //retourne la liste des inscription
        public async Task<Dictionary<int, DataTable>> GetInscriptioList()
        {
            DataTable dataTable = new();
            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";
            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string lastNameColumn = Language.LanguageName == "EN" ? "LAST NAME" : "NOM";
            string firstNameColumn = Language.LanguageName == "EN" ? "FIRST NAME" : "PRENOM";
            string sexColumn = Language.LanguageName == "EN" ? "SEX" : "SEXE";
            string birthDateColumn = Language.LanguageName == "EN" ? "BIRTH DATE" : "DATE DE NAISSANCE";
            string oldSchoolColumn = Language.LanguageName == "EN" ? "OLD SCHOOL" : "DERNIER ÉTABLISEMENT FRÉQUENTÉ";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";
            string unpaidColumn = Language.LanguageName == "EN" ? "UNPAID" : "IMPAYÉ";
            dataTable.Columns.Add(dateColumn, typeof(DateTime));
            dataTable.Columns.Add(idColumn, typeof(string));
            dataTable.Columns.Add(lastNameColumn, typeof(string));
            dataTable.Columns.Add(firstNameColumn, typeof(string));
            dataTable.Columns.Add(sexColumn, typeof(string));
            dataTable.Columns.Add(birthDateColumn, typeof(DateTime));
            dataTable.Columns.Add(oldSchoolColumn, typeof(string));
            dataTable.Columns.Add(classColumn, typeof(string));
            dataTable.Columns.Add(unpaidColumn, typeof(double));
            foreach (var item in Program.StudentEnrollingList)
            {
                object[] row = new object[9];
                row[0] = item.Date;
                row[1] = item.Student.IdNumber;
                row[2] = item.Student.LastName;
                row[3] = item.Student.FirstName;
                row[4] = item.Student.Sex;
                row[5] = item.Student.BirthDate;
                row[6] = item.OldSchool;
                row[7] = item.ClassName;
                row[8] = item.Balance;
                dataTable.Rows.Add(row);
            }
            await Task.Delay(0);
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }

        //retourne la liste des paiements relatifs aux inscriptions
        public async Task<Dictionary<int, DataTable>> GetInscriptionPaymentList()
        {
            DataTable globalDataTable = new();
            DataTable detailDataTable = new();
            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string studentColumn = Language.LanguageName == "EN" ? "STUDENT" : "ELEVE";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSES";

            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";
            string refColumn = Language.LanguageName == "EN" ? "REF" : "REF";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            string reasonColumn = Language.LanguageName == "EN" ? "REASON" : "MOTIF";
            string methodColumn = Language.LanguageName == "EN" ? "PAYMENT METHOD" : "MODE DE PAIEMENT";
            string stateColumn = Language.LanguageName == "EN" ? "VALIDATION" : "VALIDATION";

            var types = Program.CashFlowTypeList.Where(x => x.FlowCategory == FlowCategory.TuitionFee).OrderBy(x => x.Sequence);
            var payments = Program.TuitionPaymentList;
            var enrollings = Program.StudentEnrollingList;
            globalDataTable.Columns.Add(idColumn, typeof(string));
            globalDataTable.Columns.Add(studentColumn, typeof(string));
            globalDataTable.Columns.Add(classColumn, typeof(string));
            // populate global datatable
            foreach (var item in types)
            {
                globalDataTable.Columns.Add(item.Name, typeof(double));
            }
            globalDataTable.Columns.Add("TOTAL", typeof(double));
            int position = 3;
            foreach (var enrolling in enrollings)
            {
                object[] row = new object[globalDataTable.Columns.Count];
                row[0] = enrolling.Student.IdNumber;
                row[1] = enrolling.Student.FullName;
                row[2] = enrolling.ClassName;
                foreach (var type in types)
                {
                    row[position] = payments.Where(x => x.EnrollingId == enrolling.Id && x.CashFlowTypeId == type.Id).Sum(x => x.Amount);
                    position++;
                }
                row[position] = payments.Where(x => x.EnrollingId == enrolling.Id).Sum(x => x.Amount);
                position = 3;
                globalDataTable.Rows.Add(row);
            }
            // populate detail datatable
            detailDataTable.Columns.Add(dateColumn, typeof(DateTime));
            detailDataTable.Columns.Add(refColumn, typeof(string));
            detailDataTable.Columns.Add(amountColumn, typeof(double));
            detailDataTable.Columns.Add(reasonColumn, typeof(string));
            detailDataTable.Columns.Add(methodColumn, typeof(string));
            detailDataTable.Columns.Add(studentColumn, typeof(string));
            detailDataTable.Columns.Add(classColumn, typeof(string));
            detailDataTable.Columns.Add(stateColumn, typeof(string));

            foreach (var payment in payments)
            {
                object[] row = new object[detailDataTable.Columns.Count];
                row[0] = payment.Date;
                row[1] = payment.IdNumber;
                row[2] = payment.Amount;
                row[3] = payment.CashFlowType.Name;
                row[4] = payment.PaymentMean.FullName;
                row[5] = enrollings.FirstOrDefault(x => x.Id == payment.EnrollingId)?.Student.FullName;
                row[6] = enrollings.FirstOrDefault(x => x.Id == payment.EnrollingId)?.ClassName;
                row[7] = payment.IsValidated ? "OK" : Language.LabelPending;
                detailDataTable.Rows.Add(row);

            }
            await Task.Delay(0);

            return new Dictionary<int, DataTable>{
                {1, globalDataTable},
                {2, detailDataTable}
            };
        }

        //retourne la liste des paiements relatifs aux inscriptions
        public async Task<Dictionary<int, DataTable>> GetCashFlowList()
        {
            var cashFlowList = Program.CashFlowList;
            var monthList = cashFlowList.DistinctBy(x => x.Date.Month).Select(x => x.Date.Month).Order();
            var typeList = cashFlowList.Select(x => x.CashFlowType).DistinctBy(x => x.Id).OrderByDescending(x => x.FlowCategory);
            DataTable globalDataTable = new();
            DataTable detailDataTable = new();

            // build globalDataTable column 
            string cashFlowColumn = Language.LanguageName == "EN" ? "CASH FLOW" : "FLUX DE TRESORERIE";
            globalDataTable.Columns.Add(cashFlowColumn, typeof(string));
            foreach (var m in monthList)
            {
                globalDataTable.Columns.Add(AppUtilities.MonthToShortName(m).ToUpper(), typeof(string));
            }
            globalDataTable.Columns.Add("TOTAL", typeof(string));
            // polulate globalDataTable
            foreach (var type in typeList)
            {
                object[] row = new object[globalDataTable.Columns.Count];
                row[0] = type.Name;
                int position = 0;
                foreach (var m in monthList)
                {
                    row[++position] = cashFlowList.Where(x => x.Date.Month == m && x.CashFlowTypeId == type.Id).Sum(x => x.Amount);
                }
                row[++position] = cashFlowList.Where(x => x.CashFlowTypeId == type.Id).Sum(x => x.Amount);
                globalDataTable.Rows.Add(row);
            }

            // Build detail datatable column
            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";
            string refColumn = Language.LanguageName == "EN" ? "REF" : "REF";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            string reasonColumn = Language.LanguageName == "EN" ? "REASON" : "MOTIF";
            string doneByColumn = Language.LanguageName == "EN" ? "DONE BY" : "FAIT PAR";
            string categoryColumn = Language.LanguageName == "EN" ? "CATEGORY" : "CATEGORIE";
            string typeColumn = Language.LanguageName == "EN" ? "TYPE" : "TYPE";

            detailDataTable.Columns.Add(dateColumn, typeof(DateTime));
            detailDataTable.Columns.Add(refColumn, typeof(string));
            detailDataTable.Columns.Add(amountColumn, typeof(double));
            detailDataTable.Columns.Add(reasonColumn, typeof(string));
            detailDataTable.Columns.Add(doneByColumn, typeof(string));
            detailDataTable.Columns.Add(categoryColumn, typeof(string));
            detailDataTable.Columns.Add(typeColumn, typeof(string));

            // populate detail datatable
            foreach (var c in cashFlowList)
            {
                object[] row = new object[detailDataTable.Columns.Count];
                row[0] = c.Date;
                row[1] = c.IdNumber;
                row[2] = c.Amount;
                row[3] = c.CashFlowType.Name;
                row[4] = c.DoneBy;
                row[5] = Helper.GetFlowCategoryName(c.CashFlowType.FlowCategory);
                row[6] = Helper.GetFlowTypeName(c.CashFlowType.FlowType);
                detailDataTable.Rows.Add(row);

            }
            await Task.Delay(0);

            return new Dictionary<int, DataTable>{
                {1, globalDataTable},
                {2, detailDataTable}
            };
        }

        //retourne la liste des paiements relatifs aux abonnements
        public async Task<Dictionary<int, DataTable>> GetSubscriptionList()
        {
            var inscriptionList = Program.StudentEnrollingList;
            var subscriptionList = Program.SubscriptionList;
            var typeList = subscriptionList.Select(x => x.CashFlowType).DistinctBy(x => x.Id).OrderBy(x => x.Sequence);
            DataTable globalDataTable = new();
            DataTable detailDataTable = new();

            // build globalDataTable column 
            string subscriptionColumn = Language.LanguageName == "EN" ? "SUBSCRIPTION" : "ABONNEMENT";
            string domainColumn = Language.LanguageName == "EN" ? "DOMAIN" : "DOMAINE";
            string descriptionColumn = Language.LanguageName == "EN" ? "DESCRIPTION" : "DESCRIPTION";
            string subscriberCountColumn = Language.LanguageName == "EN" ? "SUBSCRIBERS" : "ABONNES";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";

            globalDataTable.Columns.Add(subscriptionColumn, typeof(string));
            globalDataTable.Columns.Add(domainColumn, typeof(string));
            globalDataTable.Columns.Add(descriptionColumn, typeof(string));
            globalDataTable.Columns.Add(subscriberCountColumn, typeof(int));
            globalDataTable.Columns.Add(amountColumn, typeof(double));

            // polulate globalDataTable
            foreach (var type in typeList)
            {
                object[] row = new object[globalDataTable.Columns.Count];
                row[0] = type.Name;
                row[1] = type.FlowDomain;
                row[2] = type.Description;
                row[3] = subscriptionList.Count(x => x.CashFlowTypeId == type.Id);
                row[4] = subscriptionList.Where(x => x.CashFlowTypeId == type.Id).Sum(x => x.Amount);
                globalDataTable.Rows.Add(row);
            }

            // Build detail datatable column
            string paymentDateColumn = Language.LanguageName == "EN" ? "PAYMENT DATE" : "DATE PAYEMENT";
            string paymentRefColumn = Language.LanguageName == "EN" ? "REF" : "REF";
            string endDateColumn = Language.LanguageName == "EN" ? "END DATE" : "DATE FIN";
            string stateColumn = Language.LanguageName == "EN" ? "STATE" : "ETAT";
            string validationColumn = Language.LanguageName == "EN" ? "VALIDATION" : "VALIDATION";

            string studentColumn = Language.LanguageName == "EN" ? "STUDENT" : "ELEVE";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";
            string addressColumn = Language.LanguageName == "EN" ? "ADDRESS" : "ADRESSE";
            string phoneColumn = Language.LanguageName == "EN" ? "PHONE" : "TELEPHONE";

            detailDataTable.Columns.Add(paymentDateColumn, typeof(DateTime));
            detailDataTable.Columns.Add(paymentRefColumn, typeof(string));
            detailDataTable.Columns.Add(amountColumn, typeof(double));
            detailDataTable.Columns.Add(subscriptionColumn, typeof(string));
            detailDataTable.Columns.Add(endDateColumn, typeof(DateTime));
            detailDataTable.Columns.Add(stateColumn, typeof(string));
            detailDataTable.Columns.Add(validationColumn, typeof(string));
            detailDataTable.Columns.Add(studentColumn, typeof(string));
            detailDataTable.Columns.Add(classColumn, typeof(string));
            detailDataTable.Columns.Add(addressColumn, typeof(string));
            detailDataTable.Columns.Add(phoneColumn, typeof(string));

            // populate detail datatable
            foreach (var c in subscriptionList)
            {
                object[] row = new object[detailDataTable.Columns.Count];
                var student= inscriptionList.FirstOrDefault(x => x.Id == c.EnrollingId)?.Student;
                row[0] = c.TransactionDate;
                row[1] = c.IdNumber;
                row[2] = c.Amount;
                row[3] = c.CashFlowType.Name;
                row[4] = c.EndDate;
                row[5] = c.State;
                row[6] = c.IsValidated ? "OK" : Language.LabelPending;
                row[7] = student.FullName;
                row[8] = inscriptionList.FirstOrDefault(x => x.Id == c.EnrollingId)?.ClassName;
                row[9] = student.Address;
                row[10] = student.Phone;
                detailDataTable.Rows.Add(row);

            }
            await Task.Delay(0);

            return new Dictionary<int, DataTable>{
                {1, globalDataTable},
                {2, detailDataTable}
            };
        }
        //retourne la liste des paiements relatifs aux  dépenses
        public async Task<Dictionary<int, DataTable>> GetExpenseList()
        {
            var expenseList = Program.CashBoxOutList;
            var monthList = expenseList.DistinctBy(x => x.Date.Month).Select(x => x.Date.Month).Order();
            var typeList = expenseList.Select(x => x.CashFlowType).DistinctBy(x => x.Id).OrderByDescending(x => x.Sequence);
            DataTable globalDataTable = new();
            DataTable detailDataTable = new();

            // build globalDataTable column 
            string cashFlowColumn = Language.LanguageName == "EN" ? "EXPENSES" : "DEPENSES";
            globalDataTable.Columns.Add(cashFlowColumn, typeof(string));
            foreach (var m in monthList)
            {
                globalDataTable.Columns.Add(AppUtilities.MonthToShortName(m).ToUpper(), typeof(string));
            }
            globalDataTable.Columns.Add("TOTAL", typeof(string));
            // polulate globalDataTable
            foreach (var type in typeList)
            {
                object[] row = new object[globalDataTable.Columns.Count];
                row[0] = type.Name;
                int position = 0;
                foreach (var m in monthList)
                {
                    row[++position] = expenseList.Where(x => x.Date.Month == m && x.CashFlowTypeId == type.Id).Sum(x => x.Amount);
                }
                row[++position] = expenseList.Where(x => x.CashFlowTypeId == type.Id).Sum(x => x.Amount);
                globalDataTable.Rows.Add(row);
            }

            // Build detail datatable column
            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";
            string refColumn = Language.LanguageName == "EN" ? "REF" : "REF";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            string reasonColumn = Language.LanguageName == "EN" ? "REASON" : "MOTIF";
            string doneByColumn = Language.LanguageName == "EN" ? "DONE BY" : "FAIT PAR";
            string categoryColumn = Language.LanguageName == "EN" ? "EXPENSE TYPE" : "TYPE DE DEPENSE";
            string validationColumn = Language.LanguageName == "EN" ? "VALIDATION" : "VALIDATION";

            detailDataTable.Columns.Add(dateColumn, typeof(DateTime));
            detailDataTable.Columns.Add(refColumn, typeof(string));
            detailDataTable.Columns.Add(amountColumn, typeof(double));
            detailDataTable.Columns.Add(reasonColumn, typeof(string));
            detailDataTable.Columns.Add(doneByColumn, typeof(string));
            detailDataTable.Columns.Add(categoryColumn, typeof(string));
            detailDataTable.Columns.Add(validationColumn, typeof(string));
            // populate detail datatable
            foreach (var c in expenseList)
            {
                object[] row = new object[detailDataTable.Columns.Count];
                row[0] = c.Date;
                row[1] = c.IdNumber;
                row[2] = c.Amount;
                row[3] = c.Note;
                row[4] = c.DoneBy;
                row[5] = c.CashFlowType.Name;
                row[6] = c.IsValidated? "OK":Language.LabelPending;
                detailDataTable.Rows.Add(row);

            }
            await Task.Delay(0);

            return new Dictionary<int, DataTable>{
                {1, globalDataTable},
                {2, detailDataTable}
            };
        }
        //retourne la liste des paiements relatifs aux  approvisionnements
        public async Task<Dictionary<int, DataTable>> GetSupplyList()
        {
            var expenseList = Program.CashBoxInList;
            var monthList = expenseList.DistinctBy(x => x.Date.Month).Select(x => x.Date.Month).Order();
            var typeList = expenseList.Select(x => x.CashFlowType).DistinctBy(x => x.Id).OrderByDescending(x => x.Sequence);
            DataTable globalDataTable = new();
            DataTable detailDataTable = new();

            // build globalDataTable column 
            string cashFlowColumn = Language.LanguageName == "EN" ? "SUPPLY" : "APPROVISIONNEMENT";
            globalDataTable.Columns.Add(cashFlowColumn, typeof(string));
            foreach (var m in monthList)
            {
                globalDataTable.Columns.Add(AppUtilities.MonthToShortName(m).ToUpper(), typeof(string));
            }
            globalDataTable.Columns.Add("TOTAL", typeof(string));
            // polulate globalDataTable
            foreach (var type in typeList)
            {
                object[] row = new object[globalDataTable.Columns.Count];
                row[0] = type.Name;
                int position = 0;
                foreach (var m in monthList)
                {
                    row[++position] = expenseList.Where(x => x.Date.Month == m && x.CashFlowTypeId == type.Id).Sum(x => x.Amount);
                }
                row[++position] = expenseList.Where(x => x.CashFlowTypeId == type.Id).Sum(x => x.Amount);
                globalDataTable.Rows.Add(row);
            }

            // Build detail datatable column
            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";
            string refColumn = Language.LanguageName == "EN" ? "REF" : "REF";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            string reasonColumn = Language.LanguageName == "EN" ? "REASON" : "MOTIF";
            string doneByColumn = Language.LanguageName == "EN" ? "DONE BY" : "FAIT PAR";
            string categoryColumn = Language.LanguageName == "EN" ? "TYPE" : "TYPE";
            string validationColumn = Language.LanguageName == "EN" ? "VALIDATION" : "VALIDATION";

            detailDataTable.Columns.Add(dateColumn, typeof(DateTime));
            detailDataTable.Columns.Add(refColumn, typeof(string));
            detailDataTable.Columns.Add(amountColumn, typeof(double));
            detailDataTable.Columns.Add(reasonColumn, typeof(string));
            detailDataTable.Columns.Add(doneByColumn, typeof(string));
            detailDataTable.Columns.Add(categoryColumn, typeof(string));
            detailDataTable.Columns.Add(validationColumn, typeof(string));
            // populate detail datatable
            foreach (var c in expenseList)
            {
                object[] row = new object[detailDataTable.Columns.Count];
                row[0] = c.Date;
                row[1] = c.IdNumber;
                row[2] = c.Amount;
                row[3] = c.Note;
                row[4] = c.DoneBy;
                row[5] = c.CashFlowType.Name;
                row[6] = c.IsValidated ? "OK" : Language.LabelPending;
                detailDataTable.Rows.Add(row);

            }
            await Task.Delay(0);

            return new Dictionary<int, DataTable>{
                {1, globalDataTable},
                {2, detailDataTable}
            };
        }

        //retourne la liste des paiements relatifs aux fournitures scolaires
        public async Task<Dictionary<int, DataTable>> GetSchoolSupplieList()
        {
            DataTable globalDataTable = new();
            DataTable detailDataTable = new();
            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string studentColumn = Language.LanguageName == "EN" ? "STUDENT" : "ELEVE";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSES";

            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";
            string refColumn = Language.LanguageName == "EN" ? "REF" : "REF";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            string quantityColumn = Language.LanguageName == "EN" ? "QUANTITY" : "QUANTITE";
            string reasonColumn = Language.LanguageName == "EN" ? "REASON" : "MOTIF";
            string methodColumn = Language.LanguageName == "EN" ? "PAYMENT METHOD" : "MODE DE PAIEMENT";
            string stateColumn = Language.LanguageName == "EN" ? "VALIDATION" : "VALIDATION";
            var types = Program.CashFlowTypeList.Where(x => x.FlowCategory == FlowCategory.SchoolSupplie);
            var  supplies = await schoolSupplieService.GetSchoolSupplieBySchoolYearList(Program.CurrentSchoolYear.Id    );
            var enrollings = Program.StudentEnrollingList;
            globalDataTable.Columns.Add(idColumn, typeof(string));
            globalDataTable.Columns.Add(studentColumn, typeof(string));
            globalDataTable.Columns.Add(classColumn, typeof(string));
            // populate global datatable
            foreach (var item in types)
            {
                globalDataTable.Columns.Add(item.Name, typeof(double));
            }
            var totalColumn = Language.LanguageName == "EN" ? "TOTAL AMOUNT" : "MONTANT TOTAL";
            globalDataTable.Columns.Add(totalColumn, typeof(double));
            int position = 3;
            foreach (var enrolling in enrollings)
            {
                object[] row = new object[globalDataTable.Columns.Count];
                row[0] = enrolling.Student.IdNumber;
                row[1] = enrolling.Student.FullName;
                row[2] = enrolling.ClassName;
                foreach (var type in types)
                {
                    row[position] = supplies.Where(x => x.EnrollingId == enrolling.Id && x.CashFlowTypeId == type.Id).Sum(x => x.Quantity);
                    position++;
                }
                row[position] = supplies.Where(x => x.EnrollingId == enrolling.Id).Sum(x => x.Amount);
                position = 3;
                globalDataTable.Rows.Add(row);
            }
            // populate detail datatable
            detailDataTable.Columns.Add(dateColumn, typeof(DateTime));
            detailDataTable.Columns.Add(refColumn, typeof(string));
            detailDataTable.Columns.Add(amountColumn, typeof(double));
            detailDataTable.Columns.Add(quantityColumn, typeof(double));
            detailDataTable.Columns.Add(reasonColumn, typeof(string));
            detailDataTable.Columns.Add(methodColumn, typeof(string));
            detailDataTable.Columns.Add(studentColumn, typeof(string));
            detailDataTable.Columns.Add(classColumn, typeof(string));
            detailDataTable.Columns.Add(stateColumn, typeof(string));

            foreach (var supply in supplies)
            {
                object[] row = new object[detailDataTable.Columns.Count];
                row[0] = supply.Date;
                row[1] = supply.IdNumber;
                row[2] = supply.Amount;
                row[3] = supply.Quantity;
                row[4] = supply.CashFlowType.Name;
                row[5] = supply.PaymentMean.FullName;
                row[6] = enrollings.FirstOrDefault(x => x.Id == supply.EnrollingId)?.Student.FullName;
                row[7] = enrollings.FirstOrDefault(x => x.Id == supply.EnrollingId)?.ClassName;
                row[8] = supply.IsValidated ? "OK" : Language.LabelPending;
                detailDataTable.Rows.Add(row);

            }
            await Task.Delay(0);

            return new Dictionary<int, DataTable>{
                {1, globalDataTable},
                {2, detailDataTable}
            };
        }

        //retourne la liste des salles de classe
        public async Task<Dictionary<int, DataTable>> GetContactList()
        {
            var getContactListTask = contactService.GetContactList();
            var studentsId = Program.StudentEnrollingList.Select(x => x.Student.Id);
            DataTable dataTable = new();
            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string studentColumn = Language.LanguageName == "EN" ? "STUDENT" : "ELEVE";
            string contactColumn = Language.LanguageName == "EN" ? "CONTACT" : "CONTACT";
            string relationshipColumn = Language.LanguageName == "EN" ? "RELATION SHIP" : "RELATION";
            string sexColumn = Language.LanguageName == "EN" ? "SEX" : "SEXE";
            string phoneColumn = Language.LanguageName == "EN" ? "PHONE" : "TELEPHONE";
            string emailColumn = Language.LanguageName == "EN" ? "EMAIL" : "EMAIL";
            string addressColumn = Language.LanguageName == "EN" ? "ADDRESS" : "ADRESSE";
            string jobColumn = Language.LanguageName == "EN" ? "JOB" : "PROFESSION";

            dataTable.Columns.Add(idColumn, typeof(string));
            dataTable.Columns.Add(studentColumn, typeof(string));
            dataTable.Columns.Add(contactColumn, typeof(string));
            dataTable.Columns.Add(relationshipColumn, typeof(string));
            dataTable.Columns.Add(sexColumn, typeof(string));
            dataTable.Columns.Add(phoneColumn, typeof(string));
            dataTable.Columns.Add(emailColumn, typeof(string));
            dataTable.Columns.Add(addressColumn, typeof(string));
            dataTable.Columns.Add(jobColumn, typeof(string));
            var mother = Language.LanguageName == "EN" ? "Mother" : "Mère";
            var father = Language.LanguageName == "EN" ? "Father" : "Père";
            var contactList = (await getContactListTask).Where(x => studentsId.Contains(x.StudentId));
            foreach (var contact in contactList)
            {
                object[] row = new object[dataTable.Columns.Count];
                row[0] = contact.Student.IdNumber;
                row[1] = contact.Student.FullName;
                row[2] = contact.Name;
                row[3] = contact.Relationship == 0 ? father : mother;
                row[4] = contact.Sex;
                row[5] = contact.Phone;
                row[6] = contact.Email;
                row[7] = contact.Address;
                row[8] = contact.Job;
                dataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }
        //retourne la liste des éléments médicaux des elèves
        public async Task<Dictionary<int, DataTable>> GetMedicalRecordList()
        {
            var getMedicalRecordListTask = medicalService.GetMedicalRecordListBySchoolYearAsync(Program.CurrentSchoolYear.Id);
            DataTable dataTable = new();
            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string studentColumn = Language.LanguageName == "EN" ? "STUDENT" : "ELEVE";
            string objectColumn = Language.LanguageName == "EN" ? "SUBJECT" : "OBJET";
            string descriptionColumn = Language.LanguageName == "EN" ? "DESCRIPTION" : "DESCRIPTION";
            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";

            dataTable.Columns.Add(idColumn, typeof(string));
            dataTable.Columns.Add(studentColumn, typeof(string));
            dataTable.Columns.Add(objectColumn, typeof(string));
            dataTable.Columns.Add(descriptionColumn, typeof(string));
            dataTable.Columns.Add(dateColumn, typeof(DateTime));
            var recordList = (await getMedicalRecordListTask).OrderBy(x => x.Student.FullName);
            foreach (var item in recordList)
            {
                object[] row = new object[dataTable.Columns.Count];
                row[0] = item.Student.IdNumber;
                row[1] = item.Student.FullName;
                row[2] = item.HealthSubject;
                row[3] = item.Description;
                row[4] = item.Date;
                dataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }

        //retourne la liste des éléments de discipline des elèves
        public async Task<Dictionary<int, DataTable>> GetDisciplineRecordList()
        {
            var getDisciplineRecordListTask = disciplineService.GetDisciplineListBySchoolYear(Program.CurrentSchoolYear.Id);
            var getStudentClassroomTask = studentEnrollingService.GetStudentRoomListAsync(Program.CurrentSchoolYear.Id);
            DataTable dataTable = new();
            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";
            string objectColumn = Language.LanguageName == "EN" ? "DISCIPLINE SUBJECT" : "OBJET DISCIPLINE";
            string reasonColumn = Language.LanguageName == "EN" ? "REASON" : "MOTIF";
            string countColumn = Language.LanguageName == "EN" ? "QUANTITY" : "NOMBRE";
            string evalColumn = Language.LanguageName == "EN" ? "EVALUATION" : "EVALUATION";
            string studentColumn = Language.LanguageName == "EN" ? "STUDENT" : "ELEVE";
            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";

            dataTable.Columns.Add(dateColumn, typeof(DateTime));
            dataTable.Columns.Add(objectColumn, typeof(string));
            dataTable.Columns.Add(reasonColumn, typeof(string));
            dataTable.Columns.Add(countColumn, typeof(string));
            dataTable.Columns.Add(evalColumn, typeof(string));
            dataTable.Columns.Add(studentColumn, typeof(string));
            dataTable.Columns.Add(idColumn, typeof(string));
            dataTable.Columns.Add(classColumn, typeof(string));
            var disciplineRecordList = (await getDisciplineRecordListTask).OrderByDescending(x => x.Date);
            var studentRoomList = await getStudentClassroomTask;
            foreach (var item in disciplineRecordList)
            {
                object[] row = new object[dataTable.Columns.Count];
                row[0] = item.Date;
                row[1] = Language.LanguageName == "EN" ? item.Subject.EnglishName : item.Subject.FrenchName;
                row[2] = item.Reason;
                row[3] = item.Duration;
                row[4] = Language.LanguageName == "EN" ? item.Evaluation.EnglishName : item.Evaluation.FrenchName;
                row[5] = item.Student.FullName;
                row[6] = item.Student.IdNumber;
                row[7] = studentRoomList.FirstOrDefault(x => x.StudentId == item.StudentId)?.Room.Name;
                dataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }

        //retourne la liste des éléments de discipline des elèves
        public async Task<Dictionary<int, DataTable>> GetEmployeeAttendanceList()
        {
            var getAttendanceListTask = employeeService.GetAttendanceListBySchoolYear(Program.CurrentSchoolYear.Id);
            DataTable dataTable = new();
            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";
            string inColumn = Language.LanguageName == "EN" ? "ENTRY" : "ENTREE";
            string outColumn = Language.LanguageName == "EN" ? "EXIT" : "SORTIE";
            string durationColumn = Language.LanguageName == "EN" ? "DURATION" : "DUREE";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";
            string subjectColumn = Language.LanguageName == "EN" ? "SUBJECT" : "MATIERRE";
            string teacherColumn = Language.LanguageName == "EN" ? "TEACHER" : "ENSEIGNANT";
            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";

            dataTable.Columns.Add(dateColumn, typeof(DateTime));
            dataTable.Columns.Add(inColumn, typeof(DateTime));
            dataTable.Columns.Add(outColumn, typeof(DateTime));
            dataTable.Columns.Add(durationColumn, typeof(TimeSpan));
            dataTable.Columns.Add(subjectColumn, typeof(string));
            dataTable.Columns.Add(classColumn, typeof(string));
            dataTable.Columns.Add(teacherColumn, typeof(string));
            dataTable.Columns.Add(idColumn, typeof(string));

            var attendanceList = (await getAttendanceListTask).OrderByDescending(x => x.StartHour);
            foreach (var item in attendanceList)
            {
                object[] row = new object[dataTable.Columns.Count];
                row[0] = item.StartHour;
                row[1] = item.StartHour.ToLocalTime();
                row[2] = item.EndHour.ToLocalTime();
                row[3] = item.Duration;
                row[4] = Language.LanguageName == "EN" ? item.Subject.EnglishName : item.Subject.FrenchName;
                row[5] = item.Room.Name;
                row[6] = item.Employee.FullName;
                row[7] = item.Employee.IdNumber;
                dataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }

        //retourne la liste des abonnements de type transport
        public async Task<Dictionary<int, DataTable>> GetTransportSubscriptionList()
        {
            var getSubscriptionListTask = subscriptionService.GetSubscriptionListBySchoolYearAsync(Program.CurrentSchoolYear.Id);
            var getStudentClassroomTask = studentEnrollingService.GetStudentRoomListAsync(Program.CurrentSchoolYear.Id);
            DataTable globalDataTable = new();
            DataTable detailDataTable = new();

            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string studentColumn = Language.LanguageName == "EN" ? "STUDENT" : "ELEVE";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";
            string addressColumn = Language.LanguageName == "EN" ? "ADDRESS" : "ADRESSE";
            string phoneColumn = Language.LanguageName == "EN" ? "PHONE" : "TELEPHONE";
            string subscriptionColumn = Language.LanguageName == "EN" ? "SUBSCRIPTIONS" : "ABONNEMENTS";
            string firstTermColumn = Language.LanguageName == "EN" ? "1ˢᵗ TERM" : "1ᵉʳ TRIMESTRE";
            string secondTermColumn = Language.LanguageName == "EN" ? "2ⁿᵈ TERM" : "2ᵉ TRIMESTRE";
            string thirdTermColumn = Language.LanguageName == "EN" ? "3ʳᵈ TERM" : "3ᵉ TRIMESTRE";
            string totalColumn = Language.LanguageName == "EN" ? "TOTAL" : "TOTAL";

            string stateColumn = Language.LanguageName == "EN" ? "STATE" : "ETAT";
            string validationColumn = Language.LanguageName == "EN" ? "VALIDATION" : "VALIDATION";
            string paymentDateColumn = Language.LanguageName == "EN" ? "PAYMENT DATE" : "DATE PAIEMENT";
            string refColumn = Language.LanguageName == "EN" ? "REF" : "REF";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            string endColumn = Language.LanguageName == "EN" ? "END DATE" : "DATE FIN";

            // build global datatable
            globalDataTable.Columns.Add(idColumn, typeof(string));
            globalDataTable.Columns.Add(studentColumn, typeof(string));
            globalDataTable.Columns.Add(classColumn, typeof(string));
            globalDataTable.Columns.Add(subscriptionColumn, typeof(string));
            globalDataTable.Columns.Add(firstTermColumn, typeof(double));
            globalDataTable.Columns.Add(secondTermColumn, typeof(double));
            globalDataTable.Columns.Add(thirdTermColumn, typeof(double));
            globalDataTable.Columns.Add(totalColumn, typeof(double));

            var subscriptionList = (await getSubscriptionListTask)
                .Where(x => x.CashFlowType?.FlowDomain == FlowDomain.Transport)
                .OrderByDescending(x => x.StartDate);
            var subsctiptionTypeList = subscriptionList.Select(x => x.CashFlowType);
            var studentClassList = await getStudentClassroomTask;
            var studentList = subscriptionList.Select(x => x.Enrolling.Student).DistinctBy(x => x.Id);
            foreach (var student in studentList)
            {
                object[] row = new object[globalDataTable.Columns.Count];
                row[0] = student.IdNumber;
                row[1] = student.FullName;
                row[2] = studentClassList.FirstOrDefault(x => x.StudentId == student.Id)?.Room.Name;
                var subscriptionValues = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id)
                                         .DistinctBy(x => x.CashFlowTypeId).Select(x => x.CashFlowType.Name);
                row[3] = string.Join("-", subscriptionValues);
                row[4] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id && x.EndDate.Date <= Program.CurrentSchoolYear?.EndFirstQuarter.Value.Date).Sum(x => x.Amount);
                row[5] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id && x.EndDate.Date <= Program.CurrentSchoolYear?.EndSecondQuarter.Value.Date && x.EndDate.Date > Program.CurrentSchoolYear?.EndFirstQuarter.Value.Date).Sum(x => x.Amount);
                row[6] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id && x.EndDate.Date <= Program.CurrentSchoolYear?.EndThirdQuarter.Value.Date && x.EndDate.Date > Program.CurrentSchoolYear?.EndSecondQuarter.Value.Date).Sum(x => x.Amount);
                row[7] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id).Sum(x => x.Amount);
                globalDataTable.Rows.Add(row);
            }

            // build detail datatable
            detailDataTable.Columns.Add(subscriptionColumn, typeof(string));
            detailDataTable.Columns.Add(stateColumn, typeof(string));
            detailDataTable.Columns.Add(paymentDateColumn, typeof(DateTime));
            detailDataTable.Columns.Add(refColumn, typeof(string));
            detailDataTable.Columns.Add(amountColumn, typeof(double));
            detailDataTable.Columns.Add(endColumn, typeof(DateTime));
            detailDataTable.Columns.Add(validationColumn, typeof(string));
            detailDataTable.Columns.Add(studentColumn, typeof(string));
            detailDataTable.Columns.Add(idColumn, typeof(string));
            detailDataTable.Columns.Add(classColumn, typeof(string));
            detailDataTable.Columns.Add(addressColumn, typeof(string));
            detailDataTable.Columns.Add(phoneColumn, typeof(string));
            foreach (var subscription in subscriptionList)
            {
                object[] row = new object[detailDataTable.Columns.Count];
                row[0] = subscription.CashFlowType.Name;
                row[1] = subscription.State;
                row[2] = subscription.TransactionDate;
                row[3] = subscription.IdNumber;
                row[4] = subscription.Amount;
                row[5] = subscription.EndDate;
                row[6] = subscription.IsValidated? "OK":Language.LabelPending;
                row[7] = subscription.Enrolling.Student.FullName;
                row[8] = subscription.Enrolling.Student.IdNumber;
                row[9] = studentClassList.FirstOrDefault(x => x.StudentId == subscription.Enrolling.StudentId)?.Room.Name;
                row[10] = subscription.Enrolling.Student.Address;
                row[11] = subscription.Enrolling.Student.Phone;
                detailDataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, globalDataTable},
                {2, detailDataTable}
            };
        }

        //retourne la liste des abonnements de type tap
        public async Task<Dictionary<int, DataTable>> GetTapsSubscriptionList()
        {
            var getSubscriptionListTask = subscriptionService.GetSubscriptionListBySchoolYearAsync(Program.CurrentSchoolYear.Id);
            var getStudentClassroomTask = studentEnrollingService.GetStudentRoomListAsync(Program.CurrentSchoolYear.Id);
            DataTable globalDataTable = new();
            DataTable detailDataTable = new();

            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string studentColumn = Language.LanguageName == "EN" ? "STUDENT" : "ELEVE";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";
            string addressColumn = Language.LanguageName == "EN" ? "ADDRESS" : "ADRESSE";
            string phoneColumn = Language.LanguageName == "EN" ? "PHONE" : "TELEPHONE";
            string subscriptionColumn = Language.LanguageName == "EN" ? "SUBSCRIPTIONS" : "ABONNEMENTS";
            string firstTermColumn = Language.LanguageName == "EN" ? "1ˢᵗ TERM" : "1ᵉʳ TRIMESTRE";
            string secondTermColumn = Language.LanguageName == "EN" ? "2ⁿᵈ TERM" : "2ᵉ TRIMESTRE";
            string thirdTermColumn = Language.LanguageName == "EN" ? "3ʳᵈ TERM" : "3ᵉ TRIMESTRE";
            string totalColumn = Language.LanguageName == "EN" ? "TOTAL" : "TOTAL";

            string stateColumn = Language.LanguageName == "EN" ? "STATE" : "ETAT";
            string validationColumn = Language.LanguageName == "EN" ? "VALIDATION" : "VALIDATION";
            string paymentDateColumn = Language.LanguageName == "EN" ? "PAYMENT DATE" : "DATE PAIEMENT";
            string refColumn = Language.LanguageName == "EN" ? "REF" : "REF";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            string endColumn = Language.LanguageName == "EN" ? "END DATE" : "DATE FIN";

            // build global datatable
            globalDataTable.Columns.Add(idColumn, typeof(string));
            globalDataTable.Columns.Add(studentColumn, typeof(string));
            globalDataTable.Columns.Add(classColumn, typeof(string));
            globalDataTable.Columns.Add(subscriptionColumn, typeof(string));
            globalDataTable.Columns.Add(firstTermColumn, typeof(double));
            globalDataTable.Columns.Add(secondTermColumn, typeof(double));
            globalDataTable.Columns.Add(thirdTermColumn, typeof(double));
            globalDataTable.Columns.Add(totalColumn, typeof(double));

            var subscriptionList = (await getSubscriptionListTask)
                .Where(x => x.CashFlowType?.FlowDomain == FlowDomain.SchoolActivity)
                .OrderByDescending(x => x.StartDate);
            var subsctiptionTypeList = subscriptionList.Select(x => x.CashFlowType);
            var studentClassList = await getStudentClassroomTask;
            var studentList = subscriptionList.Select(x => x.Enrolling.Student).DistinctBy(x => x.Id);
            foreach (var student in studentList)
            {
                object[] row = new object[globalDataTable.Columns.Count];
                row[0] = student.IdNumber;
                row[1] = student.FullName;
                row[2] = studentClassList.FirstOrDefault(x => x.StudentId == student.Id)?.Room.Name;
                var subscriptionValues = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id)
                                         .DistinctBy(x => x.CashFlowTypeId).Select(x => x.CashFlowType.Name);
                row[3] = string.Join("-", subscriptionValues);
                row[4] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id && x.EndDate.Date <= Program.CurrentSchoolYear?.EndFirstQuarter.Value.Date).Sum(x => x.Amount);
                row[5] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id && x.EndDate.Date <= Program.CurrentSchoolYear?.EndSecondQuarter.Value.Date && x.EndDate.Date > Program.CurrentSchoolYear?.EndFirstQuarter.Value.Date).Sum(x => x.Amount);
                row[6] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id && x.EndDate.Date <= Program.CurrentSchoolYear?.EndThirdQuarter.Value.Date && x.EndDate.Date > Program.CurrentSchoolYear?.EndSecondQuarter.Value.Date).Sum(x => x.Amount);
                row[7] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id).Sum(x => x.Amount);
                globalDataTable.Rows.Add(row);
            }

            // build detail datatable
            detailDataTable.Columns.Add(subscriptionColumn, typeof(string));
            detailDataTable.Columns.Add(stateColumn, typeof(string));
            detailDataTable.Columns.Add(paymentDateColumn, typeof(DateTime));
            detailDataTable.Columns.Add(refColumn, typeof(string));
            detailDataTable.Columns.Add(amountColumn, typeof(double));
            detailDataTable.Columns.Add(endColumn, typeof(DateTime));
            detailDataTable.Columns.Add(validationColumn, typeof(string));
            detailDataTable.Columns.Add(studentColumn, typeof(string));
            detailDataTable.Columns.Add(idColumn, typeof(string));
            detailDataTable.Columns.Add(classColumn, typeof(string));
            detailDataTable.Columns.Add(addressColumn, typeof(string));
            detailDataTable.Columns.Add(phoneColumn, typeof(string));
            foreach (var subscription in subscriptionList)
            {
                object[] row = new object[detailDataTable.Columns.Count];
                row[0] = subscription.CashFlowType.Name;
                row[1] = subscription.State;
                row[2] = subscription.TransactionDate;
                row[3] = subscription.IdNumber;
                row[4] = subscription.Amount;
                row[5] = subscription.EndDate;
                row[6] = subscription.IsValidated ? "OK" : Language.LabelPending;
                row[7] = subscription.Enrolling.Student.FullName;
                row[8] = subscription.Enrolling.Student.IdNumber;
                row[9] = studentClassList.FirstOrDefault(x => x.StudentId == subscription.Enrolling.StudentId)?.Room.Name;
                row[10] = subscription.Enrolling.Student.Address;
                row[11] = subscription.Enrolling.Student.Phone;
                detailDataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, globalDataTable},
                {2, detailDataTable}
            };
        }

        //retourne la liste des abonnements de type cantine
        public async Task<Dictionary<int, DataTable>> GetCantineSubscriptionList()
        {
            var getSubscriptionListTask = subscriptionService.GetSubscriptionListBySchoolYearAsync(Program.CurrentSchoolYear.Id);
            var getStudentClassroomTask = studentEnrollingService.GetStudentRoomListAsync(Program.CurrentSchoolYear.Id);
            DataTable globalDataTable = new();
            DataTable detailDataTable = new();

            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string studentColumn = Language.LanguageName == "EN" ? "STUDENT" : "ELEVE";
            string classColumn = Language.LanguageName == "EN" ? "CLASS" : "CLASSE";
            string addressColumn = Language.LanguageName == "EN" ? "ADDRESS" : "ADRESSE";
            string phoneColumn = Language.LanguageName == "EN" ? "PHONE" : "TELEPHONE";
            string subscriptionColumn = Language.LanguageName == "EN" ? "SUBSCRIPTIONS" : "ABONNEMENTS";
            string firstTermColumn = Language.LanguageName == "EN" ? "1ˢᵗ TERM" : "1ᵉʳ TRIMESTRE";
            string secondTermColumn = Language.LanguageName == "EN" ? "2ⁿᵈ TERM" : "2ᵉ TRIMESTRE";
            string thirdTermColumn = Language.LanguageName == "EN" ? "3ʳᵈ TERM" : "3ᵉ TRIMESTRE";
            string totalColumn = Language.LanguageName == "EN" ? "TOTAL" : "TOTAL";

            string stateColumn = Language.LanguageName == "EN" ? "STATE" : "ETAT";
            string validationColumn = Language.LanguageName == "EN" ? "VALIDATION" : "VALIDATION";
            string paymentDateColumn = Language.LanguageName == "EN" ? "PAYMENT DATE" : "DATE PAIEMENT";
            string refColumn = Language.LanguageName == "EN" ? "REF" : "REF";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            string endColumn = Language.LanguageName == "EN" ? "END DATE" : "DATE FIN";

            // build global datatable
            globalDataTable.Columns.Add(idColumn, typeof(string));
            globalDataTable.Columns.Add(studentColumn, typeof(string));
            globalDataTable.Columns.Add(classColumn, typeof(string));
            globalDataTable.Columns.Add(subscriptionColumn, typeof(string));
            globalDataTable.Columns.Add(firstTermColumn, typeof(double));
            globalDataTable.Columns.Add(secondTermColumn, typeof(double));
            globalDataTable.Columns.Add(thirdTermColumn, typeof(double));
            globalDataTable.Columns.Add(totalColumn, typeof(double));

            var subscriptionList = (await getSubscriptionListTask)
                .Where(x => x.CashFlowType?.FlowDomain == FlowDomain.Canteen)
                .OrderByDescending(x => x.StartDate);
            var subsctiptionTypeList = subscriptionList.Select(x => x.CashFlowType);
            var studentClassList = await getStudentClassroomTask;
            var studentList = subscriptionList.Select(x => x.Enrolling.Student).DistinctBy(x => x.Id);
            foreach (var student in studentList)
            {
                object[] row = new object[globalDataTable.Columns.Count];
                row[0] = student.IdNumber;
                row[1] = student.FullName;
                row[2] = studentClassList.FirstOrDefault(x => x.StudentId == student.Id)?.Room.Name;
                var subscriptionValues = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id)
                                         .DistinctBy(x => x.CashFlowTypeId).Select(x => x.CashFlowType.Name);
                row[3] = string.Join("-", subscriptionValues);
                row[4] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id && x.EndDate.Date <= Program.CurrentSchoolYear?.EndFirstQuarter.Value.Date).Sum(x => x.Amount);
                row[5] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id && x.EndDate.Date <= Program.CurrentSchoolYear?.EndSecondQuarter.Value.Date && x.EndDate.Date > Program.CurrentSchoolYear?.EndFirstQuarter.Value.Date).Sum(x => x.Amount);
                row[6] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id && x.EndDate.Date <= Program.CurrentSchoolYear?.EndThirdQuarter.Value.Date && x.EndDate.Date > Program.CurrentSchoolYear?.EndSecondQuarter.Value.Date).Sum(x => x.Amount);
                row[7] = subscriptionList.Where(x => x.Enrolling.StudentId == student.Id).Sum(x => x.Amount);
                globalDataTable.Rows.Add(row);
            }

            // build detail datatable
            detailDataTable.Columns.Add(subscriptionColumn, typeof(string));
            detailDataTable.Columns.Add(stateColumn, typeof(string));
            detailDataTable.Columns.Add(paymentDateColumn, typeof(DateTime));
            detailDataTable.Columns.Add(refColumn, typeof(string));
            detailDataTable.Columns.Add(amountColumn, typeof(double));
            detailDataTable.Columns.Add(endColumn, typeof(DateTime));
            detailDataTable.Columns.Add(validationColumn, typeof(string));
            detailDataTable.Columns.Add(studentColumn, typeof(string));
            detailDataTable.Columns.Add(idColumn, typeof(string));
            detailDataTable.Columns.Add(classColumn, typeof(string));
            detailDataTable.Columns.Add(addressColumn, typeof(string));
            detailDataTable.Columns.Add(phoneColumn, typeof(string));
            foreach (var subscription in subscriptionList)
            {
                object[] row = new object[detailDataTable.Columns.Count];
                row[0] = subscription.CashFlowType.Name;
                row[1] = subscription.State;
                row[2] = subscription.TransactionDate;
                row[3] = subscription.IdNumber;
                row[4] = subscription.Amount;
                row[5] = subscription.EndDate;
                row[6] = subscription.IsValidated ? "OK" : Language.LabelPending;
                row[7] = subscription.Enrolling.Student.FullName;
                row[8] = subscription.Enrolling.Student.IdNumber;
                row[9] = studentClassList.FirstOrDefault(x => x.StudentId == subscription.Enrolling.StudentId)?.Room.Name;
                row[10] = subscription.Enrolling.Student.Address;
                row[11] = subscription.Enrolling.Student.Phone;
                detailDataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, globalDataTable},
                {2, detailDataTable}
            };
        }

        //retourne la liste des pointage
        public async Task<Dictionary<int, DataTable>> GetTeacherTimeTableList()
        {
            var getTimeTableTask = timeTableService.GetTimeTableListAsync(Program.CurrentSchoolYear.Id);
            DataTable globalTable = new();
            DataTable detailTable = new();

            string idColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string teacherColumn = Language.LanguageName == "EN" ? "TEACHER" : "ENSEIGNANT";
            string toDoColumn = Language.LanguageName == "EN" ? "TO DO" : "A FAIRE";
            string doneColumn = Language.LanguageName == "EN" ? "WORKED TIME" : "TEMPS EFFECTUE";
            string noDoneColumn = Language.LanguageName == "EN" ? "NO DONE" : "NON EFFECTUE";
            string cancelColumn = Language.LanguageName == "EN" ? "CANCELED" : "ANNULE";
            string remainingColumn = Language.LanguageName == "EN" ? "REMAINING TIME" : "TEMPS RESTANT";


            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";
            string subjectColumn = Language.LanguageName == "EN" ? "SUBJECT" : "MATIERE";
            string startColumn = Language.LanguageName == "EN" ? "START" : "DEBUT";
            string endColumn = Language.LanguageName == "EN" ? "END" : "FIN";
            string expectedDurationColumn = Language.LanguageName == "EN" ? "EXPECTED DURATION" : "DUREE PREVUE";
            string stateColumn = Language.LanguageName == "EN" ? "STATE" : "STATUT";
            string inColumn = Language.LanguageName == "EN" ? "ENTRY" : "ENTREE";
            string outColumn = Language.LanguageName == "EN" ? "EXIT" : "SORTIE";
            string realDurationColumn = Language.LanguageName == "EN" ? "REAL DURATION" : "DUREE EFFECTIVE";
            // build global table
            globalTable.Columns.Add(idColumn, typeof(string));
            globalTable.Columns.Add(teacherColumn, typeof(string));
            globalTable.Columns.Add(toDoColumn, typeof(int));
            globalTable.Columns.Add(doneColumn, typeof(int));
            globalTable.Columns.Add(noDoneColumn, typeof(int));
            globalTable.Columns.Add(cancelColumn, typeof(int));
            globalTable.Columns.Add(remainingColumn, typeof(int));

            // build detail table
            detailTable.Columns.Add(dateColumn, typeof(DateTime));
            detailTable.Columns.Add(subjectColumn, typeof(string));
            detailTable.Columns.Add(startColumn, typeof(DateTime));
            detailTable.Columns.Add(endColumn, typeof(DateTime));
            detailTable.Columns.Add(expectedDurationColumn, typeof(TimeSpan));
            detailTable.Columns.Add(stateColumn, typeof(string));
            detailTable.Columns.Add(teacherColumn, typeof(string));
            detailTable.Columns.Add(inColumn, typeof(DateTime));
            detailTable.Columns.Add(outColumn, typeof(DateTime));
            detailTable.Columns.Add(realDurationColumn, typeof(TimeSpan));
            detailTable.Columns.Add(remainingColumn, typeof(TimeSpan));

            var timeTableList = (await getTimeTableTask).OrderByDescending(x => x.StartHour);
            var teacherList = timeTableList.Select(x => x.Teacher).DistinctBy(x => x.Id);

            // build global table rows
            foreach (var teacher in teacherList)
            {
                object[] row = new object[globalTable.Columns.Count];
                row[0] = teacher.IdNumber;
                row[1] = teacher.FullName;
                var toDo= timeTableList.Where(x => x.TeacherId == teacher.Id && x.State == TimeTable.TimeTableState.ToDo)
                                    .Select(x => (x.EndHour - x.StartHour)).Sum(x => x.TotalMinutes);
                row[2] = toDo;
                var done= timeTableList.Where(x => x.TeacherId == teacher.Id && x.State == TimeTable.TimeTableState.Done)
                                    .Select(x => (x.TeacherOut - x.TeacherIn)).Sum(x => x.TotalMinutes);
                row[3] = done;
                var noDone= timeTableList.Where(x => x.TeacherId == teacher.Id && x.State == TimeTable.TimeTableState.NoDone)
                                    .Select(x => (x.EndHour - x.StartHour)).Sum(x => x.TotalMinutes);
                row[4] = noDone;
                var canceled= timeTableList.Where(x => x.TeacherId == teacher.Id && x.State == TimeTable.TimeTableState.Canceled)
                                    .Select(x => (x.EndHour - x.StartHour)).Sum(x => x.TotalMinutes);
                row[5] = canceled;
                var remaining= toDo-done+noDone;
                globalTable.Rows.Add(row);
            }

            foreach (var item in timeTableList)
            {
                object[] row = new object[detailTable.Columns.Count];
                row[0] = item.StartHour;
                row[1] = Program.SubjectList.FirstOrDefault(x => x.Id == item.SubjectId);
                row[2] = item.StartHour;
                row[3] = item.EndHour;
                row[4] = item.EndHour - item.StartHour;
                row[5] = item.State;
                row[6] = item.Teacher.FullName;
                row[7] = item.TeacherIn;
                row[8] = item.TeacherOut;
                row[9] = item.TeacherOut - item.TeacherIn;
                row[10] = (item.EndHour - item.StartHour) - (item.TeacherOut - item.TeacherIn);
                detailTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, globalTable},
                {2, detailTable},
            };
        }

        //retourne l'historique des actions des utilisateurs
        public async Task<Dictionary<int, DataTable>> GetUserLogList(DateTime start,DateTime end)
        {
            var getLogListTask=logService.GetLogListAsync(start, end);
            DataTable dataTable = new();
            string dateColumn = Language.LanguageName == "EN" ? "DATE" : "DATE";
            string actionColumn = Language.LanguageName == "EN" ? "ACTION" : "ACTION";
            string userColumn = Language.LanguageName == "EN" ? "USER" : "UTILISATEUR";
            dataTable.Columns.Add(dateColumn, typeof(DateTime));
            dataTable.Columns.Add(actionColumn, typeof(string));
            dataTable.Columns.Add(userColumn, typeof(string));
            var logList = await getLogListTask;
            foreach (var item in logList.OrderBy(x => x.CreateDate))
            {
                object[] row = new object[dataTable.Columns.Count];
                row[0] = item.CreateDate;
                row[1] = item.UserAction;
                row[2] =  $"{item?.User?.UserName}-{item?.User?.Name}";
                dataTable.Rows.Add(row);
            }
            return new Dictionary<int, DataTable>{
                {1, dataTable}
            };
        }
    }
}
