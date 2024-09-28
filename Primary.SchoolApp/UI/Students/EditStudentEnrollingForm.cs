

using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        public EditStudentEnrollingForm(ILogService logService, IStudentService studentService, ICashFlowService cashFlowService, ISchoolClassService classService,
             ISchoolRoomService roomService, IPaymentMeanService paymentMeanService, ClientApp clientApp, IStudentEnrollingService studentEnrollingService)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.cashFlowService = cashFlowService;
            this.classService = classService;
            this.roomService = roomService;
            this.paymentMeanService = paymentMeanService;
            this.studentEnrollingService = studentEnrollingService;
            this.clientApp = clientApp;
            InitPaymentsGridView();
            LoadStudentList();
            ClassDropDownList.DataSource = Program.SchoolClassList;
            ClassDropDownList.SelectedIndex = -1;
            InitEvents();
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
        //init gridview
        private void InitPaymentsGridView()
        {
            PaymentsGridView.MasterTemplate.EnableFiltering = true;
            PaymentsGridView.EnableFiltering = true;
            PaymentsGridView.ShowFilteringRow = false;
            PaymentsGridView.AllowAddNewRow = false;
            PaymentsGridView.AutoGenerateColumns = false;
            PaymentsGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            GridViewTextBoxColumn reasonColumn = new("CashFlowType.Name");
            GridViewTextBoxColumn idTransactionColumn = new("TransactionId");
            GridViewDecimalColumn amountColumn = new("Amount");
            GridViewDecimalColumn balanceColumn = new("Balance");
            GridViewDateTimeColumn dateColumn = new("TransactionDate");
            GridViewComboBoxColumn paymentMeanColumn = new("PaymentMeanId");
            reasonColumn.ReadOnly = true;
            balanceColumn.ReadOnly = true;
            idTransactionColumn.ReadOnly = true;
            amountColumn.ReadOnly = true;
            dateColumn.ReadOnly = true;
            paymentMeanColumn.ReadOnly = true;
            reasonColumn.HeaderText = Language.labelReason;
            amountColumn.HeaderText = Language.labelAmount;
            dateColumn.HeaderText = Language.labelDateTransaction;
            balanceColumn.HeaderText = Language.labelUnPaid;
            idTransactionColumn.HeaderText = Language.labelIdTransaction;
            paymentMeanColumn.HeaderText = Language.labelPaymentMean;
            reasonColumn.Width = 150;
            amountColumn.Width = 80;
            dateColumn.Width = 120;
            idTransactionColumn.Width = 150;
            paymentMeanColumn.Width = 150;
            balanceColumn.Width = 80;
            paymentMeanColumn.DataSource = Program.PaymentMeanList;
            paymentMeanColumn.ValueMember = "Id";
            paymentMeanColumn.DisplayMember = "FullName";

            dateColumn.CustomFormat = "dd/MM/yyyy";
            dateColumn.FormatString = "{0:dd/MM/yyyy}";

            PaymentsGridView.Columns.Add(reasonColumn);
            PaymentsGridView.Columns.Add(amountColumn);
            PaymentsGridView.Columns.Add(dateColumn);
            PaymentsGridView.Columns.Add(idTransactionColumn);
            PaymentsGridView.Columns.Add(paymentMeanColumn);
            PaymentsGridView.Columns.Add(balanceColumn);

            GridViewSummaryRowItem total = new()
            {
                new GridViewSummaryItem("Amount", " {0}", GridAggregateFunction.Sum),
                new GridViewSummaryItem("Balance", " {0}", GridAggregateFunction.Sum)
            };
            PaymentsGridView.MasterTemplate.SummaryRowsBottom.Add(total);
            foreach (GridViewDataColumn col in PaymentsGridView.Columns)
            {
                col.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            }
            // Chargement des frais           
        }
        internal void Init(StudentEnrolling enrolling)
        {
            
            if (enrolling != null) {
                ClassDropDownList.SelectedValue = enrolling.ClassId;
                LoadStudentRoom(enrolling.StudentId, enrolling.SchoolYearId);
                LoadPayments(enrolling.Id);
                selectedEnrolling = enrolling;
                SchoolYearTexBox.Text=enrolling.SchoolYear.Name;
                EnrollingDateTimePicker.Value=enrolling.Date;
                StudentDropDownList.SelectedValue=enrolling.StudentId;               
                OldSchoolTextBox.Text=enrolling.OldSchool;
                RepeaterDropDownList.SelectedValue = enrolling.IsRepeater==true?1:0;
            }
            PaymentsGridView.Enabled=false;
            AmountTextBox.Enabled=false;
            DoneByTextBox.Enabled=false;
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
        private async void  LoadStudentRoom(int studentId,int schoolYearId)
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
           var payments=await cashFlowService.GetTuitionPaymentByEnrollingList(enrollingId);
            if (payments != null) { 
                AmountTextBox.Text= payments.Where(x => x.IsDuringEnrolling && x.Amount>0).Sum(x => x.Amount).ToString();
                DoneByTextBox.Text = payments.Where(x => x.IsDuringEnrolling && x.Amount > 0).FirstOrDefault().DoneBy;
                PaymentsGridView.DataSource = payments.Where(x=>x.IsDuringEnrolling && x.Amount > 0);
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
                if (ClassDropDownList.SelectedItem.DataBoundItem is SchoolClass record)
                {
                    RoomDropDownList.DataSource = Program.SchoolRoomList.Where(x => x.ClassId == record.Id);
                    var payments = GetInitialPaymentList(record.Id);
                    var amountToPaid = payments.Sum(x => x.Balance);
                    if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                    {
                        SchoolFeeValueLabel.Text = amountToPaid + " CFA  ( " + amountToPaid.ToLetter(CountryLanguage.French, Currency.CFA) + ")";
                    }
                    else
                    {
                        SchoolFeeValueLabel.Text = amountToPaid + " CFA  ( " + amountToPaid.ToLetter(CountryLanguage.English, Currency.CFA) + ")";
                    }
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
                form.Init(record);
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
