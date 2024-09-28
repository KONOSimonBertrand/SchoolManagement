using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace Primary.SchoolApp.UI
{
    internal class AddStudentEnrollingForm : SchoolManagement.UI.EditStudentEnrollingForm
    {
        private readonly ILogService logService;
        private readonly IStudentService studentService;
        private readonly ICashFlowService cashFlowService;
        private readonly ISchoolClassService classService;
        private readonly ISchoolRoomService roomService;
        private readonly IPaymentMeanService paymentMeanService;
        private readonly IStudentEnrollingService studentEnrollingService;
        private readonly IPrintService printService;
        private readonly ClientApp clientApp;
        private SchoolYear selectedSchoolYear;
        public AddStudentEnrollingForm(ILogService logService, IStudentService studentService, ICashFlowService cashFlowService, IPaymentMeanService paymentMeanService, ClientApp clientApp, IPrintService printService,
                                ISchoolClassService classService, ISchoolRoomService roomService, IStudentEnrollingService studentEnrollingService)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.cashFlowService = cashFlowService;
            this.paymentMeanService = paymentMeanService;
            this.classService = classService;
            this.roomService = roomService;
            this.studentEnrollingService = studentEnrollingService;
            this.clientApp = clientApp;
            this.printService = printService;
            selectedSchoolYear = new SchoolYear();
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
        internal void Init(SchoolYear schoolYear)
        {
            EnrollingDateTimePicker.Value = DateTime.Now;
            selectedSchoolYear = schoolYear;
            SchoolYearTexBox.Text = schoolYear.Name;
            AmountTextBox.Text = "0";
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            AddStudentButton.Click += AddStudentButton_Click;
            AddClassButton.Click += AddClassButton_Click;
            AddRoomButton.Click += AddRoomButton_Click;
            ClassDropDownList.SelectedValueChanged += ClassDropDownList_SelectedValueChanged;
            StudentDropDownList.SelectedValueChanged += StudentDropDownList_SelectedValueChanged;
            AmountTextBox.TextChanged += AmountTextBox_TextChanged;
        }

        private void StudentDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (StudentDropDownList.SelectedItem != null) {
                if (StudentDropDownList.SelectedItem.DataBoundItem is Student student) { 
                    DoneByTextBox.Text=student.FullName;
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            EnrollingDateTimePicker.Focus();

        }
        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PaymentsExist())
            {
                PaymentsGridView.Enabled = true;
                if (ClassDropDownList.SelectedIndex < 0)
                {
                    AmountTextBox.Text = "0";
                    DataErrorProvider.Clear();
                    DataErrorProvider.SetError(AmountTextBox, Language.messageFillField);
                    ErrorLabel.Text = Language.messageFillField;
                    ClassDropDownList.Focus();
                    return;
                }
                var selectedClass = ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass;
                if (selectedClass != null)
                {
                    double amountPaid = 0;
                    if (double.TryParse(AmountTextBox.Text, out amountPaid))
                    {
                        var feeList = Program.SchoolingCostList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.IsPayable == true && x.SchoolClassId == selectedClass.Id).ToList();
                        var oldList = GetInitialPaymentList(selectedClass.Id);
                        foreach (var item in oldList)
                        {
                            var amountToPaid = feeList.FirstOrDefault(x => x.CashFlowTypeId == item.CashFlowTypeId).Amount;
                            if (amountPaid > 0)
                            {
                                if (amountPaid > amountToPaid)
                                {
                                    item.Amount = amountToPaid;
                                }
                                else
                                {
                                    item.Amount = amountPaid;
                                }
                                item.Balance = amountToPaid - item.Amount;
                                amountPaid -= item.Amount;
                            }
                        }
                        //update payment gridview 
                        PaymentsGridView.DataSource = oldList;
                    }
                    else
                    {
                        AmountTextBox.Text = "0";
                    }
                }
            }
            else
            {
                PaymentsGridView.DataSource = new List<TuitionPayment>();
                PaymentsGridView.Enabled = false;
            }
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

                    //charge les données initiales dans le payments gridview
                    if (PaymentsExist())
                    {
                        
                        PaymentsGridView.DataSource = payments;                  
                        var amount = double.Parse(AmountTextBox.Text);
                        AmountTextBox.Text = string.Empty;
                        AmountTextBox.Text = amount.ToString();
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
                if (IsGoodRepartition())
                {
                    if (!IsRecordExist(selectedStudent.Id, selectedSchoolYear.Id))
                    {
                        if (!PaymentsExist())
                        {
                            DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmEnrollingWithoutPayment, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                            if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }
                        var record = new StudentEnrolling()
                        {
                            Date = EnrollingDateTimePicker.Value,
                            SchoolYear = selectedSchoolYear,
                            SchoolYearId = selectedSchoolYear.Id,
                            StudentId = selectedStudent.Id,
                            Student = selectedStudent,
                            ClassId = selectedClass.Id,
                            SchoolClass = selectedClass,
                            IsRepeater = (int)RepeaterDropDownList.SelectedValue == 0 ? false : true,
                            OldSchool = OldSchoolTextBox.Text,
                            DoneBy=DoneByTextBox.Text,
                        };
                        //enregistrement de l'inscription
                        var isDone = studentEnrollingService.CreateStudentEnrollingAsync(record).Result;
                        if (isDone)
                        {
                            //enregistrement du log
                            Log logEnrol = new()
                            {
                                UserAction = $"Ajout de l'inscription de l'élève {record.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
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
                                SchoolYear = selectedSchoolYear,
                                SchoolYearId = selectedSchoolYear.Id,
                                Note=Language.labelRegistration
                            };
                            if (studentEnrollingService.CreateStudentRoomAsync(studentRoom).Result)
                            {
                                Log logRoom = new()
                                {
                                    UserAction = $"Affectation de la salle {studentRoom.Room.Name} à l'élève {studentRoom.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}",
                                    UserId = clientApp.UserConnected.Id
                                };
                                logService.CreateLog(logRoom);
                            }
                            // enregistrement des paiements
                            if (PaymentsExist())
                            {
                                // Récupération de l'inscription précédemment enregistré
                                var enrolling = studentEnrollingService.GetStudentEnrollingAsync(selectedStudent.Id, selectedSchoolYear.Id).Result;
                                if (enrolling != null)
                                {
                                    record.Id = enrolling.Id;
                                    var payments = GetPaymentListFromPaymentsGridView();
                                    foreach (var payment in payments)
                                    {
                                        if (payment.Amount > 0)
                                        {
                                            payment.Enrolling = enrolling;
                                            payment.EnrollingId = enrolling.Id;
                                            payment.DoneBy = enrolling.DoneBy;
                                            payment.IsDuringEnrolling = true;
                                            if (cashFlowService.CreateTuitionPayment(payment).Result)
                                            {
                                                enrolling.PaymentList.Add(payment);
                                                record.PaymentList.Add(payment);
                                                Log logPayment = new()
                                                {
                                                    UserAction = $"Ajout d'un versement de  {payment.Amount} pour {payment.CashFlowType.Name} de l'élève {record.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                                    UserId = clientApp.UserConnected.Id
                                                };
                                                logService.CreateLog(logPayment);
                                            }
                                            //enregistrement du cashflow
                                            var cashflow = new CashFlow()
                                            {
                                                Amount = payment.Amount,
                                                CashFlowType = payment.CashFlowType,
                                                CashFlowTypeId = payment.CashFlowTypeId,
                                                Date = payment.Date,
                                                DoneBy = payment.DoneBy,
                                                SchoolYear=enrolling.SchoolYear,
                                                SchoolYearId=enrolling.SchoolYearId,
                                                Note = payment.CashFlowType.Name+" "+record.Student.FullName,
                                            };
                                            if (cashFlowService.CreateCashFlow(cashflow).Result)
                                            {
                                                //enregistrement du log
                                                Log logCash = new()
                                                {
                                                    UserAction = $"Ajout d'un flux de trésorerie de {cashflow.Amount} pour {cashflow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                                    UserId = clientApp.UserConnected.Id
                                                };
                                                logService.CreateLog(logCash);
                                            }
                                        }
                                    }
                                }   
                            }
                            //impression du reçu
                            printService.PrintPaymentReceipt(record,false);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
                }
                else
                {
                    DataErrorProvider.SetError(PaymentsGridView, Language.messageBadDistribution);
                    ErrorLabel.Text = Language.messageBadDistribution;
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
        // vérifie le paiement sera effectué lors de l'inscription
        private bool PaymentsExist()
        {
            double amount = 0;
            double.TryParse(AmountTextBox.Text, out amount);
            if (amount == 0)
            {
                return false;
            }
            return true;
        }
        //vérifie si la somme repartie au niveau du gridview est égale montant de amountText
        private bool IsGoodRepartition()
        {
            double sum = GetPaymentListFromPaymentsGridView().Sum(x => x.Amount);
            return sum == double.Parse(AmountTextBox.Text);
        }

        // get payments from payment gridview
        private List<TuitionPayment> GetPaymentListFromPaymentsGridView()
        {
            var payments = new List<TuitionPayment>();
            foreach (var row in PaymentsGridView.Rows)
            {
                if (row.DataBoundItem is TuitionPayment payment)
                {
                    payments.Add(payment);
                }
            }
            return payments;
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
    }
}
