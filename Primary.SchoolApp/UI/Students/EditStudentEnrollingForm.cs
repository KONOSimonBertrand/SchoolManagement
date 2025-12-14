

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.DTO;
using SchoolManagement.Application;
using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class EditStudentEnrollingForm:SchoolManagement.UI.EditStudentEnrollingForm
    {

        private readonly ILogService logService;
        private readonly IStudentService studentService;
        private readonly ICashFlowService cashFlowService;
        private readonly ISchoolClassService classService;
        private readonly ISchoolRoomService roomService;
        private readonly IPaymentMeanService paymentMeanService;
        private readonly IStudentEnrollingService studentEnrollingService;
        private readonly ITuitionOrderService tuitionOrderService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        public EditStudentEnrollingForm(ILogService logService, IStudentService studentService, ICashFlowService cashFlowService, ISchoolClassService classService,
             ISchoolRoomService roomService, IPaymentMeanService paymentMeanService, ClientApp clientApp, IStudentEnrollingService studentEnrollingService, ITuitionOrderService tuitionOrderService)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.cashFlowService = cashFlowService;
            this.classService = classService;
            this.roomService = roomService;
            this.paymentMeanService = paymentMeanService;
            this.studentEnrollingService = studentEnrollingService;
            this.clientApp = clientApp;
            LoadStudentList();
            ClassDropDownList.DataSource = Program.SchoolClassList;
            ClassDropDownList.SelectedIndex = -1;
            PaymentMeanDropDownList.DataSource = Program.PaymentMeanList;
            PaymentMeanDropDownList.SelectedIndex = -1;
            InitEvents();
            this.tuitionOrderService = tuitionOrderService;
        }

        private void LoadFeesList(int classId)
        {

            var InfoItemList = new List<ReceiptItem>();
            int i = 0;
            var fsList = Program.CashFlowTypeList.Where(x => x.Category == "FS");
            var abList = Program.CashFlowTypeList.Where(x => x.Category == "AB");
            var ffList = Program.CashFlowTypeList.Where(x => x.Category == "FF");

            foreach (var fs in Program.SchoolingCostList.Where(x => x.SchoolClassId == classId && x.SchoolYearId == selectedEnrolling.SchoolYearId))
            {
                InfoItemList.Add(new()
                {
                    Id = i++,
                    UnitPrice = fs.Amount,
                    Quantity = 1,
                    CashFlowTypeName = fs.CashFlowType.Name,
                    Description = $"{fs.CashFlowType.Name}: {fs.Amount} FCFA, {Language.labelTrancheNumber}: {fs.TrancheNumber}"
                }
                    );
            }

            foreach (var ab in Program.SubscriptionFeeList.Where(x => x.SchoolYearId == selectedEnrolling.SchoolYearId))
            {
                InfoItemList.Add(new()
                {
                    Id = i++,
                    UnitPrice = ab.Amount,
                    Quantity = 1,
                    CashFlowTypeName = ab.CashFlowType.Name,
                    Description = $"{Language.labelSubscription}   {ab.CashFlowType.Name}: {ab.Amount} FCFA, {Language.labelDuration}: {ab.Duration}"
                }
                    );
            }

            foreach (var ff in Program.SchoolSupplieFeeList.Where(x => x.SchoolClassId == classId && x.SchoolYearId == selectedEnrolling.SchoolYearId))
            {
                InfoItemList.Add(new()
                {
                    Id = i++,
                    UnitPrice = ff.Amount,
                    Quantity = ff.RequiredQuantity,
                    CashFlowTypeName = ff.CashFlowType.Name,
                    Description = $"{ff.CashFlowType.Name}  {Language.LabelUnitPrice}: {ff.Amount} FCFA, {Language.LabelRequiredQuantity}: {ff.RequiredQuantity}"
                }
                    );
            }

            FeesDropDownList.DataSource = null;
            FeesDropDownList.ValueMember = "Id";
            FeesDropDownList.DisplayMember = "Description";
            FeesDropDownList.DataSource = InfoItemList;

        }

        private async void LoadStudentList()
        {
            if (Program.StudentList != null)
            {
                if (Program.StudentList.Count == 0)
                {
                    Program.StudentList = await studentService.GetStudentListsync();
                }
            }
            else
            {
                Program.StudentList = await studentService.GetStudentListsync();
            }
            StudentDropDownList.DataSource = Program.StudentList;
            StudentDropDownList.SelectedIndex = -1;
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            AddStudentButton.Click += AddStudentButton_Click;
            AddClassButton.Click += AddClassButton_Click;
            AddRoomButton.Click += AddRoomButton_Click;
            ClassDropDownList.SelectedValueChanged += ClassDropDownList_SelectedValueChanged;
        }

        internal void Init(StudentEnrolling enrolling)
        {
            
            if (enrolling != null) {
                ClassDropDownList.SelectedValue = enrolling.ClassId;
                LoadStudentRoom(enrolling.StudentId, enrolling.SchoolYearId);
                LoadPayments(enrolling.Id);
                selectedEnrolling = enrolling;
                EnrollingDateTimePicker.Value=enrolling.Date;
                StudentDropDownList.SelectedValue=enrolling.StudentId;               
                OldSchoolTextBox.Text=enrolling.OldSchool;
                RepeaterDropDownList.SelectedValue = enrolling.IsRepeater==true?1:0;
            }
            TransactionDateTimePicker.Enabled=false;
            TransactionIdTextBox.Enabled=false;
            DoneByTextBox.Enabled=false;
            PaymentMeanDropDownList.Enabled=false;
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
        private async void LoadStudentRoom(int studentId,int schoolYearId)
        {
            var studentRoom=await studentEnrollingService.GetStudentRoomAsync(studentId,schoolYearId);
            if (studentRoom != null) {
                RoomDropDownList.SelectedValue = studentRoom.RoomId;
            }
            else
            {
                StudentDropDownList.SelectedValue = null;
            }
        }
        private async void LoadPayments(int enrollingId)
        {
            var orders= await tuitionOrderService.GetTuitionOrdersByEnrollingAsync(enrollingId);
            var selectedOrder=orders.FirstOrDefault(x=>x.IsDuringEnrolling);
            if (selectedOrder != null) {
                selectedOrder.TuitionOrderItems=await tuitionOrderService.GetTuitionOrderItemsAsync(selectedOrder.Id);
                DoneByTextBox.Text=selectedOrder.DoneBy;
                TransactionIdTextBox.Text=selectedOrder.TransactionId;
                TransactionDateTimePicker.Value=selectedOrder.TransactionDate;
                PaymentMeanDropDownList.SelectedValue = selectedOrder.PaymentMean;
                if (selectedOrder.TuitionOrderItems.Count == 1) {
                }
                else
                {
                    foreach (var item in selectedOrder.TuitionOrderItems) { 

                    }
                }
            }
        } 
        private void OnShown(object sender, EventArgs e)
        {
            EnrollingDateTimePicker.Focus();

        }
        private void ClassDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ClassDropDownList.SelectedItem != null)
            {
                if (ClassDropDownList.SelectedItem.DataBoundItem is SchoolClass selectedRecord)
                {
                    RoomDropDownList.DataSource = Program.SchoolRoomList.Where(x => x.ClassId == selectedRecord.Id);
                    var payments = GetInitialPaymentList(selectedRecord.Id);
                    var amountToPaid = payments.Sum(x => x.Balance);
                    // chargement de la liste des frais scolaire
                    LoadFeesList(selectedRecord.Id);
                    // ajout total des frais scolarité
                    string totalText = Language.LabelAnnualTuitionFee;
                    if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                    {
                        totalText = $" {totalText}: {amountToPaid} CFA ( {amountToPaid.ToLetter(CountryLanguage.French, Currency.CFA)}) ";
                    }
                    else
                    {
                        totalText = $"{totalText}: {amountToPaid} CFA ( {amountToPaid.ToLetter(CountryLanguage.English, Currency.CFA)}) ";
                    }
                    FeesTotalLabel.Text = totalText;
                }
               
            }
        }
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
        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            if (StudentDropDownList.SelectedItem != null)
            {
                if (StudentDropDownList.SelectedItem.DataBoundItem is Student record)
                {
                    ShowStudentEditForm(record);
                }
            }
            else
            {
                ShowStudentAddForm();
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var selectedStudent = StudentDropDownList.SelectedItem.DataBoundItem as Student;
                var selectedClass = ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass;
                var selectedRoom = RoomDropDownList.SelectedItem.DataBoundItem as SchoolRoom;
                selectedEnrolling.Date = EnrollingDateTimePicker.Value;
                selectedEnrolling.StudentId = selectedStudent.Id;
                selectedEnrolling.Student = selectedStudent;
                selectedEnrolling.ClassId = selectedClass.Id;
                selectedEnrolling.SchoolClass = selectedClass;
                selectedEnrolling.IsRepeater = (int)RepeaterDropDownList.SelectedValue == 0 ? false : true;
                selectedEnrolling.OldSchool = OldSchoolTextBox.Text;
                selectedEnrolling.DoneBy = DoneByTextBox.Text;
                //Mise à jour de l'inscription
                var isDone = studentEnrollingService.UpdateStudentEnrollingAsync(selectedEnrolling).Result;
                if (isDone)
                {
                    //enregistrement du log
                    Log logEnrol = new()
                    {
                        UserAction = $"Mise à jour de l'inscription de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(logEnrol);
                    //affectation d'une salle de classe
                    var studentRoom = new StudentRoom()
                    {
                        Room = selectedRoom,
                        RoomId = selectedRoom.Id,
                        StudentId = selectedStudent.Id,
                        Student = selectedStudent,
                        SchoolYearId = selectedEnrolling.SchoolYearId,
                        Note = Language.labelRegistration
                    };
                    //suppression de l'ancienne salle
                    studentEnrollingService.DeleteStudentRoomAsync(selectedEnrolling.StudentId,selectedEnrolling.SchoolYearId).Wait();
                    
                    if (studentEnrollingService.CreateStudentRoomAsync(studentRoom).Result)
                    {
                        Log logRoom = new()
                        {
                            UserAction = $"Affectation de la salle {studentRoom.Room.Name} à l'élève {studentRoom.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(logRoom);
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
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
                    var data = studentService.GetStudentAsync(form.IdNumberTextBox.Text).Result;
                    StudentDropDownList.DataSource = null;
                    StudentDropDownList.DataSource = Program.StudentList;
                    StudentDropDownList.SelectedValue = data;
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
                var data = studentService.GetStudentAsync(form.IdNumberTextBox.Text).Result;
                Program.StudentList.Add(data);
                StudentDropDownList.DataSource = null;
                StudentDropDownList.DataSource = Program.StudentList;
                StudentDropDownList.SelectedValue = data;
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
       
    }
}
