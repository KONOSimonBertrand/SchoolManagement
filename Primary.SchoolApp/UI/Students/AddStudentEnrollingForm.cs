using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Extensions;
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Enum;
using SchoolManagement.Core.Model;
using SchoolManagement.Helper;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.UI.Students
{
    internal class AddStudentEnrollingForm : SchoolManagement.UI.EditStudentEnrollingForm
    {
        private readonly ILogService logService;
        private readonly IStudentService studentService;
        private readonly ICashFlowService cashFlowService;
        private readonly ISchoolClassService classService;
        private readonly ISchoolRoomService roomService;
        private readonly IStudentEnrollingService studentEnrollingService;
        private readonly ISubscriptionService subscriptionService;
        private readonly ISchoolSupplieService supplieService;
        private readonly IPrintService printService;
        private readonly ClientApp clientApp;
        private SchoolYear selectedSchoolYear;
        private readonly IReceiptService receiptService;
        private readonly List<Subscription> subscriptionsToAdd;
        private readonly List<TuitionPayment> tuitionPaymentsToAdd;
        private readonly List<SchoolSupplie> schoolSuppliesToAdd;
        private readonly ILogger<AddStudentEnrollingFullForm> logger;
        public AddStudentEnrollingForm(ILogService logService, IStudentService studentService, ICashFlowService cashFlowService, ClientApp clientApp, IPrintService printService,
                                ISchoolClassService classService, ISchoolRoomService roomService, IStudentEnrollingService studentEnrollingService, IReceiptService receiptService, ILogger<AddStudentEnrollingFullForm> logger,
                                ISubscriptionService subscriptionService, ISchoolSupplieService supplieService)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.cashFlowService = cashFlowService;
            this.classService = classService;
            this.roomService = roomService;
            this.studentEnrollingService = studentEnrollingService;
            this.receiptService = receiptService;
            this.clientApp = clientApp;
            this.printService = printService;
            this.logger = logger;
            selectedSchoolYear = new SchoolYear();
            subscriptionsToAdd = new List<Subscription>();
            tuitionPaymentsToAdd = new List<TuitionPayment>();
            schoolSuppliesToAdd = new List<SchoolSupplie>();
            ClassDropDownList.DataSource = Program.SchoolClassList;
            ClassDropDownList.SelectedIndex = -1;
            InitEvents();
            CheckPermissions();
            this.subscriptionService = subscriptionService;
            this.supplieService = supplieService;
        }


        internal void Init(SchoolYear schoolYear)
        {
            EnrollingDateTimePicker.Value = DateTime.Now;
            selectedSchoolYear = schoolYear;
            AddStudentButton.Enabled = Program.UserConnected.Modules.Any(m => m.ModuleId == 2);
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            AddStudentButton.Click += AddStudentButton_Click;
            AddClassButton.Click += AddClassButton_Click;
            AddRoomButton.Click += AddRoomButton_Click;
            ClassDropDownList.SelectedValueChanged += ClassDropDownList_SelectedValueChanged;
            StudentDropDownList.TextChanged += StudentDropDownList_TextChanged;
            StudentDropDownList.SelectedIndexChanged += StudentDropDownList_SelectedIndexChanged;

        }

        private void StudentDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (StudentDropDownList.SelectedIndex != -1 && StudentDropDownList.SelectedItem != null)
            {
                if (StudentDropDownList.SelectedItem.Tag is Student student)
                {
                    DateTime today = DateTime.Now;
                    int age = today.Year - student.BirthDate.Year;
                    if (student.BirthDate > today.AddYears(-age))
                    {
                        age--;
                    }
                    string info = string.Format("{0} {1} | {2} | {3}", age.ToString(), Language.LabelYearOld.ToLower(), student.Sex == "M" ? Language.LabelMale : Language.LabelFemale, student.BirthDate.ToString("dd/MM/yyyy"));
                    StudentDropDownList.RootElement.ToolTipText = $"{student.FullName}\r {info}\r {Language.labelStudentId}: {student.IdNumber}\r{Language.labelPhone}: {student.Phone}\r {Language.labelAddress}: {student.Address}";
                }
                else
                {
                    StudentDropDownList.RootElement.ToolTipText = string.Empty;
                }
            }
        }

        private CancellationTokenSource searchCancellationTokenSource;

        private async Task SearchStudentsAsync(string searchItem, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(300, cancellationToken);
                var students = await studentService.GetStudentListsync(searchItem, cancellationToken);
                if (cancellationToken.IsCancellationRequested) return;
                StudentDropDownList.BeginUpdate();
                StudentDropDownList.Items.Clear();
                StudentDropDownList.AutoCompleteDataSource = null;
                foreach (var student in students)
                {
                    var item = new RadListDataItem
                    {
                        Text = $"{student.LastName} {student.FirstName} | {student.IdNumber}",
                        Value = student.Id,
                        Image = File.Exists(student.PictureUrl) ? new Bitmap(Image.FromFile(student.PictureUrl), new Size(32, 32)) : new Bitmap(Helper.GetImage(Resources.no_image), new Size(32, 32)),
                        Tag = student
                    };

                    StudentDropDownList.Items.Add(item);
                    StudentDropDownList.ShowDropDown();
                }
                StudentDropDownList.EndUpdate();
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la recherche d'élèves");
            }
        }
        private async void StudentDropDownList_TextChanged(object sender, EventArgs e)
        {
            string searchItem = StudentDropDownList.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchItem) || searchItem.Length < 3)
            {
                if (StudentDropDownList.Items.Count > 0)
                    StudentDropDownList.Items.Clear();
                return;
            }
            if (searchItem.Contains('|'))
            {
                return;
            }

            searchCancellationTokenSource?.Cancel();
            searchCancellationTokenSource = new CancellationTokenSource();
            var token = searchCancellationTokenSource.Token;

            await SearchStudentsAsync(searchItem, token);
        }


        private void OnShown(object sender, EventArgs e)
        {
            this.StudentDropDownList.Focus();
        }
       
        private void ClassDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ClassDropDownList.SelectedItem?.DataBoundItem is SchoolClass selectedRecord)
            {
                ClassDropDownList.RootElement.ToolTipText = selectedRecord.Name;
                RoomDropDownList.DataSource = Program.SchoolRoomList.Where(x => x.ClassId == selectedRecord.Id);
                var payments = GetInitialPaymentList(selectedRecord.Id);
                var amountToPaid = payments.Sum(x => x.Balance);
                // ajout total des frais scolarité
                string totalText = Language.labelTuitionFees;
                if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                {
                    totalText = $"{totalText}: {amountToPaid} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol} ( {amountToPaid.ToLetter(CountryLanguage.French)}) ";
                }
                else
                {
                    totalText = $"{totalText}: {amountToPaid} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol} ( {amountToPaid.ToLetter(CountryLanguage.English)}) ";
                }
                FeesTotalLabel.Text = totalText;
            }
        }

        // Permet l'ajout d'une salle de classe
        private void AddRoomButton_Click(object sender, EventArgs e)
        {
            if (RoomDropDownList.SelectedItem != null)
            {
                if (RoomDropDownList.SelectedItem.DataBoundItem is SchoolRoom record)
                {
                    ShowSchoolRoomEditForm(record);
                }
            }
            else
            {
                ShowSchoolRoomAddForm();
            }
        }
        // Permet l'ajout d'une classe
        private void AddClassButton_Click(object sender, EventArgs e)
        {
            if (ClassDropDownList.SelectedItem != null)
            {
                if (ClassDropDownList.SelectedItem.DataBoundItem is SchoolClass record)
                {
                    ShowSchoolClassEditForm(record);
                }
            }
            else
            {
                ShowSchoolClassAddForm();
            }
        }

        // permet l'ajout d'un élève, si un élève est sélectionné, on ouvre le formulaire d'édition de l'élève, sinon on ouvre le formulaire d'ajout d'un nouvel élève
        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            if (StudentDropDownList.SelectedItem != null)
            {
                if (StudentDropDownList.SelectedItem.Tag is Student student)
                {
                    ShowStudentEditForm(student);
                }
            }
            else
            {
                ShowStudentAddForm();
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                this.SaveButton.Enabled = false;
                var selectedStudent = StudentDropDownList.SelectedItem.Tag as Student;
                var selectedClass = ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass;
                var selectedRoom = RoomDropDownList.SelectedItem.DataBoundItem as SchoolRoom;
                // vérification d'une inscription liée à l'élève
                if (!IsRecordExist(selectedStudent.Id, selectedSchoolYear.Id))
                {
                    //enregistrement de l'inscription
                    var saveEnrollingIsDone = await studentEnrollingService.CreateStudentEnrollingAsync(new StudentEnrolling()
                    {
                        Date = EnrollingDateTimePicker.Value,
                        SchoolYear = selectedSchoolYear,
                        SchoolYearId = selectedSchoolYear.Id,
                        StudentId = selectedStudent.Id,
                        Student = selectedStudent,
                        ClassId = selectedClass.Id,
                        SchoolClass = selectedClass,
                        IsRepeater = (int)RepeaterDropDownList.SelectedValue != 0,
                        OldSchool = OldSchoolTextBox.Text,
                    }
                    );
                    if (saveEnrollingIsDone)
                    {
                        //enregistrement du log
                        await logService.CreateLog(new()
                        {
                            UserAction = $"Ajout de l'inscription de l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        }
                        );
                        logger.LogInformation("Ajout de l'inscription de l'élève {StudentName}  par l'utilisateur {UserName} sur le poste {IpAddress}", selectedStudent.FullName, clientApp.UserConnected.UserName, clientApp.IpAddress);
                        //affectation d'une salle de classe
                        var saveRoomIsDone = await studentEnrollingService.CreateStudentRoomAsync(new StudentRoom()
                        {
                            Room = selectedRoom,
                            RoomId = selectedRoom.Id,
                            StudentId = selectedStudent.Id,
                            Student = selectedStudent,
                            SchoolYear = selectedSchoolYear,
                            SchoolYearId = selectedSchoolYear.Id,
                            Note = Language.labelRegistration
                        }
                        );
                        if (saveRoomIsDone)
                        {
                            Log logRoom = new()
                            {
                                UserAction = $"Affectation de la salle {selectedRoom.Name} à l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}  sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            await logService.CreateLog(logRoom);
                            logger.LogInformation("Affectation de la salle {RoomName} à l'élève {StudentName}  par l'utilisateur {UserName}", selectedRoom.Name, selectedStudent.FullName, clientApp.UserConnected.UserName);
                        }
                        else
                        {
                            logger.LogError("Erreur lors de l'affectation de la salle {RoomName} à l'élève {StudentName}  par l'utilisateur {UserName}", selectedRoom.Name, selectedStudent.FullName, clientApp.UserConnected.UserName);
                        }
                        
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageAddError;
                    }
                }
                else
                {
                    DataErrorProvider.SetError(StudentDropDownList, Language.messageEnrollingExist);
                    ErrorLabel.Text = Language.messageEnrollingExist;
                }
                this.SaveButton.Enabled = true;
            }
        }

        // show student UI for edit
        private void ShowStudentEditForm(Student student)
        {
            if (student != null)
            {
                var form = Program.ServiceProvider.GetService<EditStudentForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelStudent;
                form.Icon = this.Icon;
                form.Init(student);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var item = new RadListDataItem
                    {
                        Text = $"{student.LastName} {student.FirstName} | {student.IdNumber}",
                        Value = student.Id,
                        Image = File.Exists(student.PictureUrl) ? new Bitmap(Image.FromFile(student.PictureUrl), new Size(32, 32)) : new Bitmap(Helper.GetImage(Resources.no_image), new Size(32, 32)),
                        Tag = student
                    };
                    StudentDropDownList.Items.Clear();
                    StudentDropDownList.DataSource = null;
                    StudentDropDownList.Items.Add(item);
                    StudentDropDownList.SelectedValue = student.Id;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show student UI for add new
        private void ShowStudentAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddStudentForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelStudent;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var student = studentService.GetStudentAsync(form.IdNumberTextBox.Text).Result;
                var item = new RadListDataItem
                {
                    Text = $"{student.LastName} {student.FirstName} | {student.IdNumber}",
                    Value = student.Id,
                    Image = File.Exists(student.PictureUrl) ? new Bitmap(Image.FromFile(student.PictureUrl), new Size(32, 32)) : new Bitmap(Helper.GetImage(Resources.no_image), new Size(32, 32)),
                    Tag = student
                };
                StudentDropDownList.Items.Clear();
                StudentDropDownList.DataSource = null;
                StudentDropDownList.Items.Add(item);
                StudentDropDownList.SelectedValue = student.Id;
            }
        }
        // show class UI for edit
        private void ShowSchoolClassEditForm(SchoolClass record)
        {
            if (record != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolClassForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelClass;
                form.Icon = this.Icon;
                form.InitStartup(record);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = classService.GetSchoolClass(form.NameTextBox.Text).Result;
                    ClassDropDownList.DataSource = null;
                    ClassDropDownList.DataSource = Program.SchoolClassList;
                    ClassDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show class UI for add new
        private void ShowSchoolClassAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolClassForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelClass;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = classService.GetSchoolClass(form.NameTextBox.Text).Result;
                Program.SchoolClassList.Add(data);
                ClassDropDownList.DataSource = null;
                ClassDropDownList.DataSource = Program.SchoolClassList;
                ClassDropDownList.SelectedValue = data;
            }
        }
        // show room UI for edit
        private void ShowSchoolRoomEditForm(SchoolRoom record)
        {
            if (record != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolRoomForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelRoom;
                form.Icon = this.Icon;
                form.Init(record);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = roomService.GetSchoolRoom(form.NameTextBox.Text).Result;
                    RoomDropDownList.DataSource = null;
                    RoomDropDownList.DataSource = Program.SchoolRoomList;
                    RoomDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show room UI for add new
        private void ShowSchoolRoomAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolRoomForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelRoom;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = roomService.GetSchoolRoom(form.NameTextBox.Text).Result;
                Program.SchoolRoomList.Add(data);
                RoomDropDownList.DataSource = null;
                RoomDropDownList.DataSource = Program.SchoolRoomList;
                RoomDropDownList.SelectedValue = data;
            }
        }
        //vérifie l'existence
        private bool IsRecordExist(int studentId, int schoolYearId)
        {
            if (Program.StudentEnrollingList.Where(x => x.StudentId == studentId && x.SchoolYearId == schoolYearId).Any())
            {
                return true;
            }
            else
            {
                return studentEnrollingService.GetStudentEnrollingAsync(studentId, schoolYearId).Result != null;
            }
        }

        // Génère une liste de payements pour l'initialisation du payments gridview
        private List<TuitionPayment> GetInitialPaymentList(int classId)
        {
            var recordList = new List<TuitionPayment>();
            //Récupération des frais  scolaires exigibles de l'année en cours.
            var feeList = Program.SchoolingCostList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.IsPayable == true && x.SchoolClassId == classId).OrderBy(x => x.CashFlowType.Sequence).ToList();
            foreach (var fee in feeList)
            {
                recordList.Add(
                    new TuitionPayment()
                    {
                        CashFlowType = fee.CashFlowType,
                        CashFlowTypeId = fee.CashFlowType.Id,
                        Amount = 0,
                        Date = DateTime.Now,
                        TransactionDate = DateTime.Now,
                        PaymentMean = Program.PaymentMeanList.FirstOrDefault(),
                        PaymentMeanId = Program.PaymentMeanList.FirstOrDefault().Id,
                        Balance = feeList.Where(x => x.CashFlowTypeId == fee.CashFlowTypeId).Sum(x => x.Amount)
                    }
                    );
            }
            return recordList;
        }

        // Permet d'afficher ou de masquer le panel des frais à payer selon les permissions de l'utilisateur connecté
        private void CheckPermissions()
        {
            this.AddStudentButton.Visible = Program.UserConnected.CanCreateStudent();
            this.AddClassButton.Visible = Program.UserConnected.HasSettingPagePermission();
            this.AddRoomButton.Visible = Program.UserConnected.HasSettingPagePermission();
        }
    }
}
