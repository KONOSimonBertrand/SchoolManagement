using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.CustomElements;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            LoadStudentList();
            ClassDropDownList.DataSource = Program.SchoolClassList;
            ClassDropDownList.SelectedIndex = -1;
            PaymentMeanDropDownList.DataSource = Program.PaymentMeanList;
            PaymentMeanDropDownList.SelectedIndex = -1;
            InitListView();
            InitEvents();
        }

        private void InitListView()
        {



            ListViewDetailColumn nameColumn = new("Product")
            {
                Width = FeesDropDownList.Width
            };
            this.InvoiceItemListView.Columns.Add(nameColumn);
            ListViewDetailColumn priceColumn = new("Price")
            {
                Width = AmountTextBox.Width
            };
            this.InvoiceItemListView.Columns.Add(priceColumn);



            ListViewDetailColumn totalToPaidLabelColumn = new("Total")
            {
                Width = FeesDropDownList.Width
            };
            InvoiceTotalListView.Columns.Add(totalToPaidLabelColumn);
            ListViewDetailColumn totalToPaidPriceColumn = new("TotalPrice")
            {
                Width = AmountTextBox.Width
            };
            InvoiceTotalListView.Columns.Add(totalToPaidPriceColumn);

        }

        // Chargement des frais à payer.
        private void LoadFeesList(int classId)
        {

            var InfoItemList = new List<ReceiptItem>();
            int i = 0;
            var fsList = Program.CashFlowTypeList.Where(x => x.Category == "FS");
            var abList = Program.CashFlowTypeList.Where(x => x.Category == "AB");
            var ffList = Program.CashFlowTypeList.Where(x => x.Category == "FF");

            foreach (var fs in Program.SchoolingCostList.Where(x => x.SchoolClassId == classId && x.SchoolYearId == selectedSchoolYear.Id))
            {
                InfoItemList.Add(new()
                {
                    Id = i++,
                    AmountToPay = fs.Amount,
                    UnitPrice = fs.Amount,
                    Quantity = 1,
                    CashFlowTypeName = fs.CashFlowType.Name,
                    CashFlowCategory = fs.CashFlowType.Category,
                    Description = $"{fs.CashFlowType.Name}: {fs.Amount} FCFA, {Language.labelTrancheNumber}: {fs.TrancheNumber}"
                }
                    );
            }

            foreach (var ab in Program.SubscriptionFeeList.Where(x => x.SchoolYearId == selectedSchoolYear.Id))
            {
                InfoItemList.Add(new()
                {
                    Id = i++,
                    AmountToPay = ab.Amount,
                    UnitPrice = ab.Amount,
                    CashFlowTypeName = ab.CashFlowType.Name,
                    CashFlowCategory = ab.CashFlowType.Category,
                    Quantity = 1,
                    Description = $"{Language.labelSubscription}   {ab.CashFlowType.Name}: {ab.Amount} FCFA, {Language.labelDuration}: {ab.Duration}"
                }
                    );
            }

            foreach (var ff in Program.SchoolSupplieFeeList.Where(x => x.SchoolClassId == classId && x.SchoolYearId == selectedSchoolYear.Id))
            {
                InfoItemList.Add(new()
                {
                    Id = i++,
                    AmountToPay = ff.Amount,
                    UnitPrice = ff.Amount,
                    CashFlowTypeName = ff.CashFlowType.Name,
                    CashFlowCategory = ff.CashFlowType.Category,
                    Quantity = ff.RequiredQuantity,
                    Description = $"{ff.CashFlowType.Name}  {Language.LabelUnitPrice}: {ff.Amount} FCFA, {Language.LabelRequiredQuantity}: {ff.RequiredQuantity}"
                }
                    );
            }

            FeesDropDownList.DataSource = null;
            FeesDropDownList.ValueMember = "Id";
            FeesDropDownList.DisplayMember = "Description";
            FeesDropDownList.DataSource = InfoItemList;

        }
        // Chargement des elèves
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
            AmountTextBox.Text = "0";
            AmountTextBox.Enabled = Program.UserConnected.Modules.Any(m => m.ModuleId == 3 && m?.AllowCreate == true);
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
            StudentDropDownList.SelectedValueChanged += StudentDropDownList_SelectedValueChanged;
            AmountTextBox.TextChanged += AmountTextBox_TextChanged;
            QuantityTextBox.TextChanged += QuantityTextBox_TextChanged;
            FeesDropDownList.SelectedValueChanged += FeesDropDownList_SelectedValueChanged;
            AddInvoiceItemButton.Click += AddInvoiceItemButton_Click;
            RemoveInvoiceItemButton.Click += RemoveInvoiceItemButton_Click;
        }

        private void QuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(AmountTextBox.Text, out var amount) && double.TryParse(QuantityTextBox.Text, out var quantity))
            {
                var total = amount * quantity;
                TotalAmountTextBox.Text = total.ToString();
            }
        }

        private void RemoveInvoiceItemButton_Click(object sender, EventArgs e)
        {

        }

        private void AddInvoiceItemButton_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = string.Empty;
            ErrorProvider.Clear();
            if (FeesDropDownList.SelectedIndex < 0)
            {
                ErrorProvider.SetError(FeesDropDownList, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                FeesDropDownList.Focus();
                return;
            }
            if (double.TryParse(AmountTextBox.Text, out double amount) == false)
            {
                ErrorProvider.SetError(AmountTextBox, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                AmountTextBox.Focus();
                return;
            }
            if (double.TryParse(QuantityTextBox.Text, out double quantity) == false)
            {
                ErrorProvider.SetError(QuantityTextBox, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                QuantityTextBox.Focus();
                return;
            }

            if (FeesDropDownList?.SelectedItem.DataBoundItem is ReceiptItem receiptItem)
            {
                if(double.TryParse(TotalAmountTextBox.Text, out double totalAmount) && receiptItem.AmountToPay< totalAmount && receiptItem.CashFlowCategory!="FF")
                {
                    ErrorProvider.SetError(TotalAmountTextBox, Language.messageFillField);
                    ErrorLabel.Text = $"Total({totalAmount}) > {Language.LabelFeesToPay}({receiptItem.AmountToPay})";
                    TotalAmountTextBox.Focus();
                    return;
                }

                if ( amount> receiptItem.UnitPrice && receiptItem.CashFlowCategory == "FF")
                {
                    ErrorProvider.SetError(TotalAmountTextBox, Language.messageFillField);
                    ErrorLabel.Text = $"{Language.labelAmount}({amount}) > {Language.LabelFeesToPay}({receiptItem.AmountToPay})";
                    TotalAmountTextBox.Focus();
                    return;
                }
                // On vérifie si ça déjà été ajouté
                if (InvoiceItemListView.Items.Any(item=> item["Product"].ToString() == receiptItem.CashFlowTypeName))
                {
                    ErrorProvider.SetError(FeesDropDownList, Language.messageFillField);
                    ErrorLabel.Text = Language.messageDataAlreadyExist;
                    FeesDropDownList.Focus();
                    return;
                }
                
                ListViewDataItem dataItem = new()
                {
                    Tag = receiptItem
                };
                InvoiceItemListView.Items.Add(dataItem);
                dataItem["Product"] = receiptItem.CashFlowTypeName;
                dataItem["Price"] = string.Format("{0}", amount * quantity);
                dataItem.Tag = receiptItem;

                decimal total = InvoiceItemListView.Items.Sum(i => Convert.ToDecimal(i["Price"]));
                InvoiceTotalListView.Items.Clear();
                ListViewDataItem totalItem = new();
                InvoiceTotalListView.Items.Add(totalItem);
                totalItem["Total"] = "Total";
                totalItem["TotalPrice"] = string.Format("{0} CFA", total);
                FeesDropDownList.SelectedIndex = -1;
                AmountTextBox.Text = "0";
                QuantityTextBox.Text = "0";

            }
        }

        private void FeesDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FeesDropDownList.SelectedItem?.DataBoundItem is ReceiptItem receiptItem)
            {
                AmountTextBox.Text = receiptItem.UnitPrice.ToString();
                QuantityTextBox.Text = receiptItem.Quantity.ToString();
                QuantityTextBox.Enabled = receiptItem.CashFlowCategory == "FF";
            }
        }

        private void FeesCheckedListBox_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            var InfoItemList = new List<ReceiptItem>();
            if (e.Item.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                if (e.Item.DataBoundItem is ReceiptItem receiptItem)
                {
                    ListViewDataItem dataItem = new()
                    {
                        Tag = receiptItem
                    };
                    InvoiceItemListView.Items.Add(dataItem);
                    dataItem["Product"] = receiptItem.CashFlowTypeName;
                    dataItem["Price"] = string.Format("{0}", receiptItem.UnitPrice);
                    e.Item.Tag = receiptItem;

                    decimal total = 0;
                    total = InvoiceItemListView.Items.Sum(i => Convert.ToDecimal(i["Price"]));
                    InvoiceTotalListView.Items.Clear();
                    ListViewDataItem totalItem = new();
                    InvoiceTotalListView.Items.Add(totalItem);
                    totalItem["Total"] = "Total";
                    totalItem["TotalPrice"] = string.Format("{0} CFA", total);
                }
            }
            else
            {
                if (e.Item.Tag is ReceiptItem receiptItem)
                {
                    var itemToRemove = InvoiceItemListView.Items.FirstOrDefault(i => i.Tag == receiptItem);
                    if (itemToRemove != null)
                    {
                        this.InvoiceItemListView.Items.Remove(itemToRemove);
                        decimal total = 0;
                        total = InvoiceItemListView.Items.Sum(i => Convert.ToDecimal(i["Price"]));
                        InvoiceTotalListView.Items.Clear();
                        ListViewDataItem totalItem = new();
                        InvoiceTotalListView.Items.Add(totalItem);
                        totalItem["Total"] = "Total";
                        totalItem["TotalPrice"] = string.Format("{0} CFA", total);
                    }
                }
            }
        }

        private void StudentDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (StudentDropDownList.SelectedItem != null)
            {
                if (StudentDropDownList.SelectedItem.DataBoundItem is Student student)
                {
                    DoneByTextBox.Text = student.FullName;
                    StudentDropDownList.RootElement.ToolTipText = student.FullName;
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            EnrollingDateTimePicker.Focus();

        }
        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(AmountTextBox.Text, out var amount) && double.TryParse(QuantityTextBox.Text, out var quantity))
            {
                var total = amount * quantity;
                TotalAmountTextBox.Text = total.ToString();
            }
        }
        private void ClassDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ClassDropDownList.SelectedItem?.DataBoundItem is SchoolClass selectedRecord)
            {
                ClassDropDownList.RootElement.ToolTipText = selectedRecord.Name;
                RoomDropDownList.DataSource = Program.SchoolRoomList.Where(x => x.ClassId == selectedRecord.Id);
                var payments = GetInitialPaymentList(selectedRecord.Id);
                var amountToPaid = payments.Sum(x => x.Balance);
                // chargement de la liste des frais scolaire
                LoadFeesList(selectedRecord.Id);
                // ajout total des frais scolarité
                string totalText = Language.labelTuitionFees;
                if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                {
                    totalText = $" {totalText}: {amountToPaid} CFA ( {amountToPaid.ToLetter(CountryLanguage.French, Currency.CFA)}) ";
                }
                else
                {
                    totalText = $"{totalText}: {amountToPaid} CFA ( {amountToPaid.ToLetter(CountryLanguage.English, Currency.CFA)}) ";
                }
                ListViewDataItem dataItem = new();
                InvoiceItemListView.Items.Clear();
                FeesTotalLabel.Text = totalText;
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
                    var enrollingToAdd = new StudentEnrolling()
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
                        DoneBy = DoneByTextBox.Text,
                    };
                    //enregistrement de l'inscription
                    var isDone = studentEnrollingService.CreateStudentEnrollingAsync(enrollingToAdd).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log logEnrol = new()
                        {
                            UserAction = $"Ajout de l'inscription de l'élève {enrollingToAdd.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
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
                            Note = Language.labelRegistration
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
                                enrollingToAdd.Id = enrolling.Id;
                            }
                        }
                        //impression du reçu
                        printService.PrintPaymentReceiptAsync(enrollingToAdd, false);
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
